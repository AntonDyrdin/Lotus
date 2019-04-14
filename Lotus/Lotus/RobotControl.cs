using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
namespace Lotus
{
    public class RobotControl
    {
        public static void pickAndPlace(Form1 form,Point A, Point B, int objectsLevel, int altitude)
        {
            form.moveToPoint(A.X, A.Y, altitude, 0, 180, 0);
            form.moveToPoint(A.X, A.Y, objectsLevel, 0, 180, 0);
            form.moveToPoint(A.X, A.Y, altitude, 0, 180, 0);
            form.moveToPoint(B.X, B.Y, altitude, 0, 180, 0);
            form.moveToPoint(B.X, B.Y, objectsLevel, 0, 180, 0);
            form.moveToPoint(B.X, B.Y, altitude, 0, 180, 0);
        }
    }
}
