using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
namespace Lotus
{
    unsafe class Recognition1
    {
        public FastBitmap background;
        public Color backAVG;

        double delta = 150;
        public Recognition1(string background)
        {
            this.background = new FastBitmap(Image.FromFile(background));
            setBackAVG();
        }
        public Recognition1(Image background)
        {
            this.background = new FastBitmap(background);
            setBackAVG();
        }
        void setBackAVG()
        {
            double R_back_avg_sum = 0;
            double G_back_avg_sum = 0;
            double B_back_avg_sum = 0;

            int pixels_count = 0;

            for (int i = 0; i < background.Bitmap.Width; i++)
                for (int j = 0; j < background.Bitmap.Height; j++)
                {
                    var pixel = background.bitmap.GetPixel(i, j);
                    if (pixel.R != 255 | pixel.G != 255 | pixel.B != 255)
                    {
                        R_back_avg_sum += pixel.R;
                        G_back_avg_sum += pixel.G;
                        B_back_avg_sum += pixel.B;
                        pixels_count++;
                    }
                }

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
        public List<Point> objectMask;
        public Point getXpxYpx(FastBitmap bitmap)
        {
            objectMask = new List<Point>();
            bitmap.LockBitmap();
            background.LockBitmap();
            for (int i = 0; i < bitmap.Bitmap.Width; i++)
                for (int j = 0; j < bitmap.Bitmap.Height; j++)
                {
                    var pixel = bitmap.GetPixel(i, j);
                    var backgroundPixel = background.GetPixel(i, j);

                    if (backgroundPixel.R != 255 | backgroundPixel.G != 255 | backgroundPixel.B != 255)
                    {
                        var distance = getDistance(Color.FromArgb(255, pixel.R, pixel.G, pixel.B), backAVG);
                        if (distance >= delta)
                        {
                            objectMask.Add(new Point(i, j));
                        }
                    }
                }
            background.UnlockBitmap();
            bitmap.UnlockBitmap();
            //поиск центра
            if (objectMask.Count > 0)
            {
                double X_sum = 0;
                double Y_sum = 0;
                for (int i = 0; i < objectMask.Count; i++)
                {
                    X_sum += objectMask[i].X;
                    Y_sum += objectMask[i].Y;
                }
                double X = X_sum / objectMask.Count;
                double Y = Y_sum / objectMask.Count;
                return new Point(Convert.ToInt32(X), Convert.ToInt32(Y));
            }
            return new Point();
        }
    }
}
