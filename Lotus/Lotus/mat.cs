using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Lotus
{
    public class Mat
    {
        public int resolution = 100;
        public Color[,] m;
        public double dx;
        public double dy;
        public Mat(Image image)
        {
            Bitmap bmp = new Bitmap(image);
            dx = image.Width / resolution;
            dy = image.Height / resolution;
            m = new Color[resolution, resolution];
            double i = 0, j = 0;
            for (int x = 0; x < resolution; x++)
            {
                j = 0;
                for (int y = 0; y < resolution; y++)
                {
                    m[x, y] = bmp.GetPixel((int)i, (int)j);
                    j += dy;
                }
                i += dx;
            }

        }
    }
}
