using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
namespace Lotus
{
    unsafe class Recognition2
    {
        public FastBitmap background;
        public Color backAVG;

        public double delta = 170;
        public int objectSize;
        public Recognition2(string background, int objectSize)
        {
            this.objectSize = objectSize;
            this.background = new FastBitmap(Image.FromFile(background));
            setBackAVG();
        }
        public Recognition2(Image background, int objectSize)
        {
            this.objectSize = objectSize;
            this.background = new FastBitmap(background);
            setBackAVG();
        }
        void setBackAVG()
        {
            double R_back_avg_sum = 0;
            double G_back_avg_sum = 0;
            double B_back_avg_sum = 0;

            int pixels_count = 0;
            background.LockBitmap();
            for (int i = 0; i < background.Bitmap.Width; i++)
                for (int j = 0; j < background.Bitmap.Height; j++)
                {
                    var pixel = background.GetPixel(i, j);
                    if (pixel.R != 255 | pixel.G != 255 | pixel.B != 255)
                    {
                        R_back_avg_sum += pixel.R;
                        G_back_avg_sum += pixel.G;
                        B_back_avg_sum += pixel.B;
                        pixels_count++;
                    }
                }
            background.UnlockBitmap();
            double R_back_avg = R_back_avg_sum / pixels_count;
            double G_back_avg = G_back_avg_sum / pixels_count;
            double B_back_avg = B_back_avg_sum / pixels_count;

            backAVG = Color.FromArgb(255, Convert.ToInt32(R_back_avg), Convert.ToInt32(G_back_avg), Convert.ToInt32(B_back_avg));
        }
        double getDistance(Color A, Color B)
        {
            int ans = (int)Math.Sqrt((A.R - B.R) * (A.R - B.R) + (A.G - B.G) * (A.G - B.G) + (A.B - B.B) * (A.B - B.B));
            return ans;
        }
        public List<List<Point>> objectsMasks;
        public List<Point> objects;
        public List<Point> someShit;
        public List<Point> getXpxYpx(Bitmap image)
        {
            var bitmap = new FastBitmap((Image)image);
            objects = new List<Point>();

            objectsMasks = new List<List<Point>>();
            someShit = new List<Point>();
            bitmap.LockBitmap();
            background.LockBitmap();
            for (int i = 0; i < bitmap.Bitmap.Width; i++)
            {
                var height = bitmap.Bitmap.Height;
                for (int j = 0; j < height; j++)
                {

                    var pixel = bitmap.GetPixel(i, j);
                    var backgroundPixel = background.GetPixel(i, j);

                    if (backgroundPixel.R != 255 | backgroundPixel.G != 255 | backgroundPixel.B != 255)
                    {
                        var distance = getDistance(Color.FromArgb(255, pixel.R, pixel.G, pixel.B), backAVG);
                        if (distance >= delta)
                        {
                            someShit.Add(new Point(i, j));
                        }
                    }
                }
            }
            background.UnlockBitmap();
            bitmap.UnlockBitmap();

            List<List<Point>> falseObjectsMasks = new List<List<Point>>();
            List<Point> falseObjects = new List<Point>();
            for (int i = 0; i < someShit.Count; i++)
            {

                bool isOutOfRecogmizedObjects = true;
                foreach (Point anObject in objects)
                {
                    if (Math.Sqrt(((anObject.X - someShit[i].X) * (anObject.X - someShit[i].X)) + ((anObject.Y - someShit[i].Y) * (anObject.Y - someShit[i].Y))) < objectSize)
                    {
                        isOutOfRecogmizedObjects = false;
                    }
                }
                if (isOutOfRecogmizedObjects)
                {
                    objectsMasks.Add(new List<Point>());

                    for (int j = 0; j < someShit.Count; j++)
                    {

                        if (Math.Sqrt((someShit[i].X - someShit[j].X) * (someShit[i].X - someShit[j].X) + (someShit[i].Y - someShit[j].Y) * (someShit[i].Y - someShit[j].Y)) < objectSize)
                        {
                            objectsMasks.Last().Add(someShit[j]);
                        }
                    }



                    if (objectsMasks.Count > 0)
                    {

                        //проверка размера объекта
                        /* double max = 0;
                           if (objectsMasks.Last().Count > objectSize * objectSize / 4)
                               for (int k = objectsMasks.Last().Count - 1; k > 0; k = k - 500)
                           {
                               var r = Math.Sqrt((objectsMasks.Last()[0].X - objectsMasks.Last()[k].X) * (objectsMasks.Last()[0].X - objectsMasks.Last()[k].X) + (objectsMasks.Last()[0].Y - objectsMasks.Last()[k].Y) * (objectsMasks.Last()[0].Y - objectsMasks.Last()[k].Y));
                               if (r > objectSize / 2)
                               {
                                   max = r;
                                   break;
                               }
                               if (max < r)
                                   max = r;
                           }*/
                        double X_sum = 0;
                        double Y_sum = 0;
                        for (int j = 0; j < objectsMasks.Last().Count; j++)
                        {
                            X_sum += objectsMasks.Last()[j].X;
                            Y_sum += objectsMasks.Last()[j].Y;
                        }

                        double X = X_sum / objectsMasks.Last().Count;
                        double Y = Y_sum / objectsMasks.Last().Count;
                        objects.Add(new Point(Convert.ToInt32(X), Convert.ToInt32(Y)));
                        if (objectsMasks.Last().Count < objectSize * objectSize / 4)
                        {
                            falseObjects.Add(new Point(Convert.ToInt32(X), Convert.ToInt32(Y)));
                            falseObjectsMasks.Add(objectsMasks.Last());
                        }
                    }
                }
            }

            for (int j = 0; j < falseObjects.Count; j++)
            {
                objects.Remove(falseObjects[j]);
                objectsMasks.Remove( falseObjectsMasks[j]);
            }
            return objects;
        }
    }
}
