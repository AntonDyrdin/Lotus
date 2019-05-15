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
        public static string pickAndPlace(Form1 form, Point A, int B_X, int B_Y, int B_Z, int objectsLevel, int altitude, bool verticalGripperOrientation)
        {
            try
            {
                int b;
                if (verticalGripperOrientation)
                    b = 180;
                else
                    b = 90;

                Mat pose_ref = form.ROBOT.Pose();
                var xyzabc = pose_ref.ToXYZRPW();

                bool blockA4 = true;
               


                    if (blockA4)
                    {
                        if (A.Y == 0)
                        { A.Y = 1; }
                        if (A.X == 0)
                        { A.X = 1; }
                        if (B_Y == 0)
                        { B_Y = 1; }
                        if (B_X == 0)
                        { B_X = 1; }
                        form.ROBOT.MoveJ(Mat.FromXYZRPW(new double[6] { A.X, A.Y, altitude, Math.Atan(A.Y / A.X) * 180 / 3.14, b, 0 }));
                        form.ROBOT.MoveJ(Mat.FromXYZRPW(new double[6] { A.X, A.Y, objectsLevel, Math.Atan(A.Y / A.X) * 180 / 3.14, b, 0 }));
                        form.ROBOT.MoveJ(Mat.FromXYZRPW(new double[6] { A.X, A.Y, altitude, Math.Atan(A.Y / A.X) * 180 / 3.14, b, 0 }));
                        form.ROBOT.MoveJ(Mat.FromXYZRPW(new double[6] { B_X, B_Y, altitude, Math.Atan(B_Y / B_X) * 180 / 3.14, b, 0 }));
                        form.ROBOT.MoveJ(Mat.FromXYZRPW(new double[6] { B_X, B_Y, B_Z, Math.Atan(B_Y / B_X) * 180 / 3.14, b, 0 }));
                        form.ROBOT.MoveJ(Mat.FromXYZRPW(new double[6] { B_X, B_Y, altitude, Math.Atan(B_Y / B_X) * 180 / 3.14, b, 0 }));
                    }
                    else
                    {
                        form.ROBOT.MoveJ(Mat.FromXYZRPW(new double[6] { A.X, A.Y, altitude, 0, b, 0 }));
                        form.ROBOT.MoveJ(Mat.FromXYZRPW(new double[6] { A.X, A.Y, objectsLevel, 0, b, 0 }));
                        form.ROBOT.MoveJ(Mat.FromXYZRPW(new double[6] { A.X, A.Y, altitude, 0, b, 0 }));
                        form.ROBOT.MoveJ(Mat.FromXYZRPW(new double[6] { B_X, B_Y, altitude, 0, b, 0 }));
                        form.ROBOT.MoveJ(Mat.FromXYZRPW(new double[6] { B_X, B_Y, B_Z, 0, b, 0 }));
                        form.ROBOT.MoveJ(Mat.FromXYZRPW(new double[6] { B_X, B_Y, altitude, 0, b, 0 }));
                    }
            
                return "done";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
    }
}
