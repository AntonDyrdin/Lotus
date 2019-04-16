using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Runtime.InteropServices;

using AForge.Video;
using AForge.Video.DirectShow;
using System.Diagnostics;

namespace Lotus
{
    unsafe public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        int unloadingX;
        int unloadingY;
        int unloadingZ;

        int altitude;

        int objectsLevel;
        int objectSize;

        private FilterInfoCollection videoDevices;
        public VideoCaptureDevice videoDevice;
        private VideoCapabilities[] videoCapabilities;
        private VideoCapabilities[] snapshotCapabilities;

        // RDK holds the main object to interact with RoboDK.
        // The RoboDK application starts when a RoboDK object is created.
        RoboDK RDK = null;

        // Keep the ROBOT item as a global variable
        public RoboDK.Item ROBOT = null;

        // Define if the robot movements will be blocking
        const bool MOVE_BLOCKING = false;

        Point sheetPoseInRCS;
        Size sheetSize;
        List<Point> pointsInRCS;
        //public RoboDK.Item item;
        private void button5_Click(object sender, EventArgs e)
        {
            unloadingX = Convert.ToInt32(textBox1.Text);
            unloadingY = Convert.ToInt32(textBox2.Text);
            unloadingZ = Convert.ToInt32(textBox3.Text);

            altitude = Convert.ToInt32(textBox4.Text);

            objectsLevel = Convert.ToInt32(textBox5.Text);

            sheetPoseInRCS = new Point(Convert.ToInt32(textBox7.Text), Convert.ToInt32(textBox8.Text));
            sheetSize = new Size(Convert.ToInt32(textBox10.Text), Convert.ToInt32(textBox9.Text));
            objectSize = Convert.ToInt32(textBox11.Text);


            // notifybar.Text = RobotControl.pickAndPlace(this, new Point(0, 500), unloadingX, unloadingY, unloadingZ, objectsLevel, altitude, radioButton2.Checked);
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            //  sheetPoseInRCS = new Point(300, -200);
            //  sheetSize = new Size(400, 200);
            // This will create a new icon in the windows toolbar that shows how we can lock/unlock the application
            Setup_Notification_Icon();

            videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);

            if (videoDevices.Count != 0)
            {
                // add all devices to combo
                foreach (FilterInfo device in videoDevices)
                {
                    devicesCombo.Items.Add(device.Name);
                }
            }
            else
            {
                devicesCombo.Items.Add("No DirectShow devices found");
            }

            devicesCombo.SelectedIndex = 0;

            EnableConnectionControls(true);
            work_zone_points = new List<Point>();
            var lines = File.ReadAllLines("Work zone position.txt");
            foreach (string line in lines)
            {
                work_zone_points.Add(new Point(Convert.ToInt32(line.Split(' ')[1].Split(';')[0]), Convert.ToInt32(line.Split(' ')[1].Split(';')[1])));
            }
            button5_Click(null, null);
            items = new List<RoboDK.Item>();
        }


        private void button4_Click(object sender, EventArgs e)
        {

            if (Check_RDK()) { return; }
            try
            {
                rad_RoboDK_Integrated();
            }
            catch
            { rad_RoboDK_Integrated(); }
            string filename = "KUKA KR 6 R700 sixx.robot";

            // retrieve the newly added item
            RoboDK.Item item = RDK.AddFile(filename);
            if (item.Valid())
            {
                notifybar.Text = "Loaded: " + item.Name();
                // attempt to retrieve the ROBOT variable (a robot available in the station)
                SelectRobot();
            }
            else
            {
                notifybar.Text = "Could not load: " + filename;
            }
            RoboDK.Item sheet = RDK.AddFile("sheet.cadobj");
            sheet.setPose(Mat.FromXYZRPW(new double[6] { sheetPoseInRCS.X + sheetSize.Height, sheetPoseInRCS.Y, 0, 90, 0, 0 }));
            /*
           RoboDK.Item box = RDK.AddFile("box.sld");
           box.Scale(new double[3] { 0.3, 0.3, 0.3 });
           box.setPose(Mat.FromXYZRPW(new double[6] { sheetPoseInRCS.X , sheetPoseInRCS.Y, 18, 90, 0, 0 }));

           RobotControl.pickAndPlace(this, new Point(sheetPose.X, sheetPose.Y), new Point(500, -300), 40, 300);
           */
            RDK.setSimulationSpeed(1);
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            /*try
            {   */
            Task task = new Task(() =>
            {
                recognize();
            });
            task.Start();
            task.Wait();


            if (Check_RDK())
            {
               // var ViewPose = RDK.ViewPose();

                if (items != null)
                {
                    for (int i = 0; i < items.Count; i++)
                    {
                        items[i].Delete();
                    }
                    items.Clear();
                }
                if (pointsInRCS != null)
                {
                    items.Clear();
                    foreach (Point point in pointsInRCS)
                    {
                        RoboDK.Item item;
                        item = RDK.AddFile("object.sld");
                        item.Scale(new double[3] { 0.3, 0.3, 0.3 });
                        item.setPose(Mat.FromXYZRPW(new double[6] { point.X, point.Y, 18, 90, 0, 0 }));
                        items.Add(item);
                   //     RDK.setViewPose(ViewPose);
                    }

                }
            }
            /* }
             catch { }  */
        }
        List<RoboDK.Item> items;
        Recognition1 recognition1;
        Recognition2 recognition2;
        void recognize()
        {
            triggerButton_Click(null, null);
            if (currentImage != null)
            {
                if (radioButton3.Checked)
                {
                    if (recognition1 == null)
                        recognition1 = new Recognition1("mask.bmp");

                    var point = recognition1.getXpxYpx(new FastBitmap(currentImage));

                    Image toPicBox1 = currentImage;
                    Graphics g = Graphics.FromImage(toPicBox1);

                    //отрисовка маски
                    for (int i = 0; i < recognition1.objectMask.Count; i = i + 20)
                    {
                        g.DrawLine(new Pen(Color.Blue), recognition1.objectMask[i].X - 3, recognition1.objectMask[i].Y, recognition1.objectMask[i].X + 3, recognition1.objectMask[i].Y);
                        g.DrawLine(new Pen(Color.Blue), recognition1.objectMask[i].X, recognition1.objectMask[i].Y - 3, recognition1.objectMask[i].X, recognition1.objectMask[i].Y + 3);
                    }

                    g.DrawLine(new Pen(Color.Red, 3), point.X - 10, point.Y, point.X + 10, point.Y);
                    g.DrawLine(new Pen(Color.Red, 3), point.X, point.Y - 10, point.X, point.Y + 10);

                    g.DrawLine(new Pen(recognition1.backAVG, 40), 0, 20, 500, 20);

                    //перевод в систему координат робота
                    Point pointInRCS = convertToRobotCoordinateSystem(point);
                    g.DrawString("x = " + pointInRCS.X.ToString() + "mm ( " + point.X + "px )", new Font("Gotic", 15), Brushes.Red, 10, 50);
                    g.DrawString("y = " + pointInRCS.Y.ToString() + "mm ( " + point.Y + "px )", new Font("Gotic", 15), Brushes.Red, 10, 70);

                    pictureBox1.Image = toPicBox1;

                    pointsInRCS = new List<Point>();
                    pointsInRCS.Add(pointInRCS);
                }

                if (radioButton4.Checked)
                {
                    if (recognition2 == null)
                        recognition2 = new Recognition2("mask.bmp", objectSize);
                    List<Point> points = new List<Point>();

                    Image toPicBox1 = currentImage;
                    Graphics g = Graphics.FromImage(toPicBox1);


                    points = recognition2.getXpxYpx(currentImage);

                    //отрисовка маски
                    for (int i = 0; i < points.Count; i++)
                    {
                        g.DrawEllipse(new Pen(Color.LimeGreen, 2), points[i].X - objectSize / 2, points[i].Y - objectSize / 2, objectSize, objectSize);

                        g.DrawLine(new Pen(Color.Red, 3), points[i].X - 10, points[i].Y, points[i].X + 10, points[i].Y);
                        g.DrawLine(new Pen(Color.Red, 3), points[i].X, points[i].Y - 10, points[i].X, points[i].Y + 10);
                    }



                    g.DrawLine(new Pen(recognition2.backAVG, 40), 0, 20, 500, 20);


                    pictureBox1.Image = toPicBox1;
                    //перевод в систему координат робота
                    pointsInRCS = new List<Point>();
                    if (recognition2.objects.Count > 0)
                    {
                        for (int i = 0; i < recognition2.objects.Count; i++)
                        {
                            pointsInRCS.Add(convertToRobotCoordinateSystem(points[i]));
                            //   g.DrawString("x = " + pointInRCS.X.ToString() + "mm ( " + point.X + "px )", new Font("Gotic", 15), Brushes.Red, 10, 50);
                            //  g.DrawString("y = " + pointInRCS.Y.ToString() + "mm ( " + point.Y + "px )", new Font("Gotic", 15), Brushes.Red, 10, 70);
                        }
                    }
                }
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            //pictureBox1.Image = currentImage;
            recognize();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Stop();
         //   var ViewPose = RDK.ViewPose();
            if (Check_RDK())
            {
                if (items != null)
                {
                    for (int i = 0; i < items.Count; i++)
                    {
                        items[i].Delete();
                    }
                    items.Clear();
                }

                foreach (Point point in pointsInRCS)
                {
                    RoboDK.Item item;
                    item = RDK.AddFile("object.sld");
                    item.Scale(new double[3] { 0.3, 0.3, 0.3 });
                    item.setPose(Mat.FromXYZRPW(new double[6] { point.X, point.Y, 18, 90, 0, 0 }));
                 //   RDK.setViewPose(ViewPose);
                    ////////////////////////////////////
                    ///////  MOVE TO THE OBJECT    ////
                    ///////////////////////////////////

                    notifybar.Text = RobotControl.pickAndPlace(this, point, unloadingX, unloadingY, unloadingZ, objectsLevel, altitude, radioButton2.Checked);

                    item.setPose(Mat.FromXYZRPW(new double[6] { unloadingX, unloadingY, unloadingZ + 18, 90, 0, 0 }));
                    items.Add(item);
                  //  RDK.setViewPose(ViewPose);
                }
            }
            timer1.Start();
        }
        Point convertToRobotCoordinateSystem(Point point)
        {
            double Y = sheetPoseInRCS.Y + sheetSize.Width * (point.X - work_zone_points[0].X) / (work_zone_points[1].X - work_zone_points[0].X);
            double X = sheetPoseInRCS.X + sheetSize.Height * (point.Y - work_zone_points[0].Y) / (work_zone_points[3].Y - work_zone_points[0].Y);
            return new Point((int)(X), (int)(Y));
        }


        //////////////////////////////////////////////////////////////////
        ////////// Test button for general purpose tests ///////////////////////



        private void btnRunTestProgram_Click(object sender, EventArgs e)
        {
            if (!Check_ROBOT()) { return; }

            /* if (RDK.Connected())
             {
                 RDK.CloseRoboDK();
             }*/

            int n_sides = 6;

            Mat pose_ref = ROBOT.Pose();

            // Set the simulation speed (ratio = real time / simulated time)
            RDK.setSimulationSpeed(1); // 1 second of the simulator equals 1 second in real time

            try
            {

                // retrieve the reference frame and the tool frame (TCP)
                Mat frame = ROBOT.PoseFrame();
                Mat tool = ROBOT.PoseTool();
                int runmode = RDK.RunMode(); // retrieve the run mode 

                var xyzabc = pose_ref.ToXYZRPW();

                // Program start
                var newPose = pose_ref;

                var a = 0;
                var b = 180;
                var c = 0;

                ROBOT.setSpeed(100);        // Set Speed to 100 mm/s

                ROBOT.MoveJ(Mat.FromXYZRPW(new double[6] { 400, 0, 300, a, b, c }));
                ROBOT.MoveJ(Mat.FromXYZRPW(new double[6] { 400, 100, 300, a, b, c }));
                ROBOT.MoveJ(Mat.FromXYZRPW(new double[6] { 500, 100, 300, a, b, c }));
                ROBOT.MoveJ(Mat.FromXYZRPW(new double[6] { 500, -100, 300, a, b, c }));
                ROBOT.MoveJ(Mat.FromXYZRPW(new double[6] { 400, -100, 300, a, b, c }));
                ROBOT.MoveJ(Mat.FromXYZRPW(new double[6] { 400, 0, 300, a, b, c }));

                /*  ROBOT.MoveJ(pose_ref);
                  ROBOT.setPoseFrame(frame);  // set the reference frame
                  ROBOT.setPoseTool(tool);    // set the tool frame: important for Online Programming

                  ROBOT.setZoneData(5);       // set the rounding instruction (C_DIS & APO_DIS / CNT / ZoneData / Blend Radius / ...)
                  ROBOT.RunCodeCustom("CallOnStart");
                  for (int i = 0; i <= n_sides; i++)
                  {
                      double angle = ((double)i / n_sides) * 2.0 * Math.PI;
                      Mat pose_i = pose_ref * Mat.rotz(angle) * Mat.transl(100, 0, 0) * Mat.rotz(-angle);
                      ROBOT.RunCodeCustom("Moving to point " + i.ToString(), RoboDK.INSTRUCTION_COMMENT);
                      double[] xyzwpr = pose_i.ToXYZRPW();
                      ROBOT.MoveJ(pose_i);
                  }
                  ROBOT.RunCodeCustom("CallOnFinish");
                  ROBOT.MoveL(pose_ref);  */
            }
            catch (RoboDK.RDKException rdkex)
            {
                notifybar.Text = "Failed to complete the movement: " + rdkex.Message;
            }

            return;
            // Example to change the robot parameters (DHM parameters as defined by Craig 1986)
            // for joints 1 to 6, index i changes from 0 to 5:
            // dhm[i][] = [alpha, a, theta, d];


            // first point
            double[] p1 = { 0, 0, 0 };
            double[] p2 = { 1000, 0, 0 };
            Mat reference = Mat.transl(0, 0, 100);
            double[] p_collision = new double[3]; // this can be null if we don't need the collision point

            RoboDK.Item item = RDK.Collision_Line(p1, p2, reference, p_collision);

            string name;
            if (item.Valid())
            {
                name = item.Name();
            }
            else
            {
                // item not valid
            }

            return;



            double[][] dhm;
            Mat pose_base;
            Mat pose_tool;
            // get the current robot parameters:
            /* RDK.getRobotParams(ROBOT, out dhm, out pose_base, out pose_tool);

             // change the mastering values:
             for (int i = 0; i < 6; i++)
             {
                 dhm[i][2] = dhm[i][2] + 1 * Math.PI / 180.0; // change theta i (mastering value, add 1 degree)
             }

             // change the base and tool distances:
             dhm[0][3] = dhm[0][3] + 5; // add 5 mm to d1
             dhm[5][3] = dhm[5][3] + 5; // add 5 mm to d6

             // update the robot parameters back:
             RDK.setRobotParams(ROBOT, dhm, pose_base, pose_tool);*/

            return;

            // Example to rotate the view around the Z axis
            /*RoboDK.Item item_robot = RDK.ItemUserPick("Select the robot you want", RoboDK.ITEM_TYPE_ROBOT);
            item_robot.MoveL(item_robot.Pose() * Mat.transl(0, 0, 50));
            return;*/


            RDK.setViewPose(RDK.ViewPose() * Mat.rotx(10 * 3.141592 / 180));
            return;

            //---------------------------------------------------------
            // Sample to generate a program using a C# script
            if (ROBOT != null && ROBOT.Valid())
            {
                //ROBOT.Finish();
                //RDK.Finish();
                // RDK.Connect(); // redundant

                ROBOT.Finish(); // ignores any previous activity to generate the program
                RDK.setRunMode(RoboDK.RUNMODE_MAKE_ROBOTPROG); // Very important to set first
                RDK.ProgramStart("TestProg3", "D:\\Anton\\Desktop\\", "test.py", ROBOT);
                double[] joints3 = new double[6] { 10, 20, 30, 40, 50, 60 };
                double[] joints4 = new double[6] { -10, -20, -30, 40, 50, 60 };

                ROBOT.MoveJ(joints3);
                ROBOT.MoveJ(joints4);
                ROBOT.Finish(); // provoke program generation

            }
            else
            {
                Console.WriteLine("No robot selected");
            }
            return;

            //---------------------------------------------------------
            RoboDK.Item prog = RDK.getItem("", RoboDK.ITEM_TYPE_PROGRAM);
            string err_msg;
            Mat jnt_list;
            //prog.InstructionListJoints(out err_msg, out jnt_list, 0.5, 0.5);
            prog.InstructionListJoints(out err_msg, out jnt_list, 5, 5);
            for (int j = 0; j < jnt_list.cols; j++)
            {
                for (int i = 0; i < jnt_list.rows; i++)
                {
                    Console.Write(jnt_list[i, j]);
                    Console.Write("    ");
                }
                Console.WriteLine("");
            }

            /*RoboDK.Item frame = RDK.getItem("FrameTest");
            double[] xyzwpr = { 1000.0, 2000.0, 3000.0, 12.0 * Math.PI / 180.0, 84.98 * Math.PI / 180.0, 90.0 * Math.PI / 180.0 };
            Mat pose;
            pose = Mat.FromUR(xyzwpr);
            double[] xyzwpr_a = pose.ToUR();
            double[] xyzwpr_b = pose.ToUR_Alternative();
    */
        }
        // New snapshot frame is available
        Bitmap currentImage;
        private void videoDevice_SnapshotFrame(object sender, NewFrameEventArgs eventArgs)
        {
            currentImage = (Bitmap)eventArgs.Frame.Clone();
        }
        private void triggerButton_Click(object sender, EventArgs e)
        {
            if ((videoDevice != null) && (videoDevice.ProvideSnapshots))
            {
                videoDevice.SimulateTrigger();
                button2.Enabled = true;
            }
            if (sender != null)
            {
                System.Threading.Thread.Sleep(500);
                pictureBox2.Image = currentImage;
            }
        }
        private void videoSourcePlayer1_Click(object sender, EventArgs e)
        {

        }
        bool workZoneSetting = false;
        private void button3_Click(object sender, EventArgs e)
        {
            workZoneSetting = true;
            this.Cursor = Cursors.Cross;

        }

        int point_count = 0;
        List<Point> work_zone_points;
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (pictureBox2.Image != null)
            {
                if (workZoneSetting)
                {
                    if (point_count == 0)
                    {
                        work_zone_points = new List<Point>();
                    }

                    var X = MousePosition.X - this.Location.X - tabControl1.Location.X - pictureBox1.Location.X - 12;
                    var Y = MousePosition.Y - this.Location.Y - tabControl1.Location.Y - pictureBox1.Location.Y - 53;
                    work_zone_points.Add(new Point(X, Y));
                    point_count++;

                    if (point_count == 4)
                    {
                        point_count = 0;
                        workZoneSetting = false;
                        this.Cursor = Cursors.Default;
                        Image mask = (Image)pictureBox2.Image.Clone();
                        Bitmap bmp_original = (Bitmap)pictureBox2.Image.Clone();
                        Graphics g = Graphics.FromImage(mask);

                        var tempMaskBrush = Brushes.Cyan;
                        var tempMaskColor = Color.Cyan;
                        g.FillPolygon(tempMaskBrush, work_zone_points.ToArray());
                        pictureBox2.Image = mask;
                        //invert mask
                        Bitmap bmp_mask = (Bitmap)mask.Clone();
                        for (int i = 0; i < bmp_mask.Width; i++)
                            for (int j = 0; j < bmp_mask.Height; j++)
                            {
                                var B = tempMaskColor;
                                var A = bmp_mask.GetPixel(i, j);
                                if (A.R != B.R || A.G != B.G || A.B != B.B)
                                {
                                    bmp_mask.SetPixel(i, j, Color.Transparent);
                                }
                                else
                                {
                                    bmp_mask.SetPixel(i, j, bmp_original.GetPixel(i, j));
                                }
                            }

                        bmp_mask.Save("mask.bmp");

                        var old = File.ReadAllLines("Work zone position.txt");
                        string[] lines = new string[4];
                        for (int i = 0; i < work_zone_points.Count; i++)
                            lines[i] = old[i].Split(' ')[0] + ' ' + work_zone_points[i].X.ToString() + ';' + work_zone_points[i].Y.ToString();
                    }
                }
            }
            else
            {
                MessageBox.Show("Get snapshot first!");
            }

        }



        /// <summary>
        /// Check if the RDK object is ready.
        /// Returns True if the RoboDK API is available or False if the RoboDK API is not available.
        /// </summary>
        /// <returns></returns>
        public bool Check_RDK()
        {
            // check if the RDK object has been initialised:
            if (RDK == null)
            {
                notifybar.Text = "RoboDK has not been started";
                return false;
            }

            // Check if the RDK API is connected
            if (!RDK.Connected())
            {
                notifybar.Text = "Connecting to RoboDK...";
                // Attempt to connect to the RDK API
                if (!RDK.Connect())
                {
                    notifybar.Text = "Problems using the RoboDK API. The RoboDK API is not available...";
                    return false;
                }
            }
            return true;
        }

        private void btnLoadFile_Click(object sender, EventArgs e)
        {
            // Make sure the RoboDK API is running:
            if (!Check_RDK()) { return; }

            // Show the File dialog to select a file:
            OpenFileDialog select_file = new OpenFileDialog();
            select_file.Title = "Select a file to open with RoboDK";
            select_file.InitialDirectory = RDK.getParam("PATH_LIBRARY").Replace("/", "\\"); // open the RoboDK library by default
            if (select_file.ShowDialog() == DialogResult.OK)  // show the dialog
            {
                string filename = select_file.FileName;
                // Check if it is a RoboDK station file (.rdk extension)
                // If desired, close any other stations that have previously been open
                /*if (filename.EndsWith(".rdk", StringComparison.InvariantCultureIgnoreCase))
                {
                    CloseAllStations();
                }*/

                // retrieve the newly added item
                RoboDK.Item item = RDK.AddFile(select_file.FileName);
                if (item.Valid())
                {
                    notifybar.Text = "Loaded: " + item.Name();
                    // attempt to retrieve the ROBOT variable (a robot available in the station)
                    SelectRobot();
                }
                else
                {
                    notifybar.Text = "Could not load: " + filename;
                }
            }
        }

        /// <summary>
        /// Check if the ROBOT object is available and valid. It will make sure that we can operate with the ROBOT object.
        /// </summary>
        /// <returns></returns>
        public bool Check_ROBOT(bool ignore_busy_status = false)
        {
            if (!Check_RDK())
            {
                return false;
            }
            if (ROBOT == null || !ROBOT.Valid())
            {
                notifybar.Text = "A robot has not been selected. Load a station or a robot file first.";
                return false;
            }
            try
            {
                notifybar.Text = "Using robot: " + ROBOT.Name();
            }
            catch (RoboDK.RDKException rdkex)
            {
                notifybar.Text = "The robot has been deleted: " + rdkex.Message;
                return false;
            }

            // Safe check: If we are doing non blocking movements, we can check if the robot is doing other movements with the Busy command
            if (!MOVE_BLOCKING && (!ignore_busy_status && ROBOT.Busy()))
            {
                notifybar.Text = "The robot is busy!! Try later...";
                return false;
            }
            return true;
        }

        /// <summary>
        /// Close all the stations available in RoboDK (top level items)
        /// </summary>
        public void CloseAllStations()
        {
            // Get all the RoboDK stations available
            RoboDK.Item[] all_stations = RDK.getItemList(RoboDK.ITEM_TYPE_STATION);
            foreach (RoboDK.Item station in all_stations)
            {
                notifybar.Text = "Closing " + station.Name();
                // this will close a station without asking to save:
                station.Delete();
            }
        }




        ////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////
        //////////////// Example to get/set robot position /////////////////

        private void btnMoveRobotHome_Click(object sender, EventArgs e)
        {
            if (!Check_ROBOT()) { return; }

            double[] joints_home = ROBOT.JointsHome();

            ROBOT.MoveJ(joints_home);
        }

        private void btnGetJoints_Click(object sender, EventArgs e)
        {
            if (!Check_ROBOT(true)) { return; }

            double[] joints = ROBOT.Joints();
            Mat pose = ROBOT.Pose();

            // update the joints
            string strjoints = Values_2_String(joints);
            textBox6.Text = strjoints;

            // update the pose as xyzwpr
            double[] xyzwpr = pose.ToTxyzRxyz();
            string strpose = Values_2_String(xyzwpr);
            txtPosition.Text = strpose;
        }


        private void btnMovePose_Click(object sender, EventArgs e)
        {
            // retrieve the robot position from the text and validate input
            double[] xyzwpr = String_2_Values(txtPosition.Text);

            // make sure RDK is running and we have a valid input
            if (!Check_ROBOT() || xyzwpr == null) { return; }

            //Mat pose = Mat.FromXYZRPW(xyzwpr);
            Mat pose = Mat.FromTxyzRxyz(xyzwpr);
            try
            {
                ROBOT.MoveJ(pose, MOVE_BLOCKING);
            }
            catch (RoboDK.RDKException rdkex)
            {
                notifybar.Text = "Problems moving the robot: " + rdkex.Message;
                //MessageBox.Show("The robot can't move to " + new_pose.ToString());
            }
        }


        /// <summary>
        /// Convert a list of numbers provided as a string to an array of values
        /// </summary>
        /// <param name="strvalues"></param>
        /// <returns></returns>
        public double[] String_2_Values(string strvalues)
        {
            double[] dvalues = null;
            try
            {
                dvalues = Array.ConvertAll(strvalues.Split(','), Double.Parse);
            }
            catch (System.FormatException ex)
            {
                notifybar.Text = "Invalid input: " + strvalues;
            }
            return dvalues;
        }

        /// <summary>
        /// Convert an array of values as a string
        /// </summary>
        /// <param name="dvalues"></param>
        /// <returns></returns>
        public string Values_2_String(double[] dvalues)
        {
            if (dvalues == null || dvalues.Length < 1)
            {
                return "Invalid values";
            }
            // Not supported on .NET Framework 2.0:
            //string strvalues = String.Join(" , ", dvalues.Select(p => p.ToString("0.0")).ToArray());
            string strvalues = dvalues[0].ToString();
            for (int i = 1; i < dvalues.Length; i++)
            {
                strvalues += " , " + dvalues[i].ToString();
            }

            return strvalues;
            //return "";
        }

        //////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////
        ///////// Run mode types: ///////////////
        ///////// 1- Simulation (default): RUNMODE_SIMULATE
        ///////// 2- Offline programming (default): RUNMODE_MAKE_ROBOTPROG
        ///////// 3- Online programming: RUNMODE_RUN_ROBOT. It moves the real robot
        private void rad_RunMode_Simulation_CheckedChanged(object sender, EventArgs e)
        {
            // skip if the radio button became unchecked
            RadioButton rad_sender = (RadioButton)sender;
            if (!rad_sender.Checked) { return; }

            // Check that there is a link with RoboDK:
            btnOLPdone.Enabled = false;
            if (!Check_ROBOT()) { return; }

            // Important: stop any previous program generation (if we selected offline programming mode)
            RDK.Finish();

            // Set to simulation mode:
            RDK.setRunMode(RoboDK.RUNMODE_SIMULATE);
        }
        private void rad_RunMode_Program_CheckedChanged(object sender, EventArgs e)
        {
            // skip if the radio button became unchecked
            RadioButton rad_sender = (RadioButton)sender;
            if (!rad_sender.Checked) { return; }

            btnOLPdone.Enabled = true;
            if (!Check_ROBOT()) { return; }

            // Important: Disconnect from the robot for safety
            ROBOT.Finish();

            // Set to simulation mode:
            RDK.setRunMode(RoboDK.RUNMODE_MAKE_ROBOTPROG);

            // specify a program name, a folder to save the program and a post processor if desired
            RDK.ProgramStart("NewProgram");
        }
        private void btnOLPdone_Click(object sender, EventArgs e)
        {
            if (!Check_ROBOT()) { return; }

            // this will trigger program generation
            //RDK.Finish();
            ROBOT.Finish(); // we must close the socket linked to the robot

            // set back to simulation
            rad_RunMode_Simulation.PerformClick();
        }

        private void rad_RunMode_Online_CheckedChanged(object sender, EventArgs e)
        {
            // skip if the radio button became unchecked
            RadioButton rad_sender = (RadioButton)sender;
            if (!rad_sender.Checked) { return; }

            btnOLPdone.Enabled = false;
            // Check that there is a link with RoboDK:
            if (!Check_ROBOT()) { return; }

            // Important: stop any previous program generation (if we selected offline programming mode)
            RDK.Finish();

            // Connect to real robot
            if (ROBOT.Connect("192.168.1.47"))
            {
                // Set to Run on Robot robot mode:
                RDK.setRunMode(RoboDK.RUNMODE_RUN_ROBOT);
            }
            else
            {
                notifybar.Text = "Can't connect to the robot. Check connection and parameters.";
                rad_RunMode_Simulation.AutoCheck = true;

            }
        }
        /// <summary>
        /// Update the ROBOT variable by choosing the robot available in the currently open station
        /// If more than one robot is available, a popup will be displayed
        /// </summary>
        public void SelectRobot()
        {
            notifybar.Text = "Selecting robot...";
            if (!Check_RDK())
            {
                ROBOT = null;
                return;
            }
            ROBOT = RDK.ItemUserPick("Select a robot", RoboDK.ITEM_TYPE_ROBOT); // select robot among available robots
            //ROBOT = RL.getItem("ABB IRB120", ITEM_TYPE_ROBOT); // select by name
            //ITEM = RL.ItemUserPick("Select an item"); // Select any item in the station
            if (ROBOT.Valid())
            {
                ROBOT.NewLink(); // This will create a new communication link (another instance of the RoboDK API), this is useful if we are moving 2 robots at the same time.                
                notifybar.Text = "Using robot: " + ROBOT.Name();
            }
            else
            {
                notifybar.Text = "Robot not available. Load a file first";
            }
        }
        //////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////
        ///////////////// GROUP DISPLAY MODE ////////////////
        // Import SetParent/GetParent command from user32 dll to identify if the main window is a subprocess
        [DllImport("user32.dll")]
        static extern IntPtr SetParent(IntPtr hWndChild, IntPtr hWndNewParent);

        private void rad_RoboDK_show_CheckedChanged(object sender, EventArgs e)
        {
            // skip if the radio button became unchecked
            RadioButton rad_sender = (RadioButton)sender;
            if (!rad_sender.Checked) { return; }

            // Check RoboDK connection
            if (!Check_RDK()) { return; }

            // unhook from the integrated panel it is inside the main panel
            if (RDK.PROCESS != null)
            {
                SetParent(RDK.PROCESS.MainWindowHandle, IntPtr.Zero);
            }

            RDK.setWindowState(RoboDK.WINDOWSTATE_NORMAL); // removes Cinema mode and shows the screen
            RDK.setWindowState(RoboDK.WINDOWSTATE_MAXIMIZED); // shows maximized


            //Alternatively: RDK.ShowRoboDK();
            this.BringToFront(); // show on top of RoboDK
        }

        private void rad_RoboDK_hide_CheckedChanged(object sender, EventArgs e)
        {
            // skip if the radio button became unchecked
            RadioButton rad_sender = (RadioButton)sender;
            if (!rad_sender.Checked) { return; }

            if (!Check_RDK()) { return; }

            RDK.setWindowState(RoboDK.WINDOWSTATE_HIDDEN);
            //Alternatively: RDK.HideRoboDK();

        }

        private void rad_RoboDK_Integrated()
        {
            tryagain:
            if (!Check_RDK())
            {

                // RoboDK starts here. We can optionally pass arguments to start it hidden or start it remotely on another computer provided the computer IP.
                // If RoboDK was already running it will just connect to the API. We can force a new RoboDK instance and specify a communication port
                RDK = new RoboDK("", true);
                //RDK.setWindowState(RoboDK.WINDOWSTATE_CINEMA);
                RDK.HideRoboDK();

                // Check if RoboDK started properly
                if (Check_RDK())
                {
                    notifybar.Text = "RoboDK is Running...";

                    // attempt to auto select the robot:
                    SelectRobot();
                }

                // set default movement on the simulator only:
                // rad_RunMode_Simulation.PerformClick();

                // display RoboDK by default:
                // rad_RoboDK_show.PerformClick();

                // Set incremental moves in cartesian space with respect to the robot reference frame
                // rad_Move_wrt_Reference.PerformClick();

                numStep.Value = 10; // set movement steps of 50 mm or 50 deg by default


                // other ways to Start RoboDK
                //RDK = new RoboDK("", START_HIDDEN); // default connection, starts RoboDK visible if it has not been started
                //RDK = new RoboDK("localhost", false, 20599); //start visible, use specific communication port to not interfere with other applications
                //RDK = new RoboDK("localhost", true, 20599); //start hidden,  use specific communication port to not interfere with other applications

            }
            /*  if (sender != null)
              {
                  // skip if the radio button became unchecked
                  RadioButton rad_sender = (RadioButton)sender;
                  if (!rad_sender.Checked) { return; }
              }
              // skip if the radio button became unchecked
              if (!rad_RoboDK_Integrated.Checked) { return; }

              if (!Check_RDK()) { return; }
              if (RDK.PROCESS == null)
              {
                  notifybar.Text = "Invalid handle. Close RoboDK and open RoboDK with this application";
                  rad_RoboDK_show.PerformClick();
                  return;
              }     */

            // hook window pointer to the integrated panel
            RDK.ShowRoboDK();
            try
            {
                SetParent(RDK.PROCESS.MainWindowHandle, panel_rdk.Handle);
            }
            catch
            {
                Process[] proc = Process.GetProcesses();
                foreach (Process process in proc)
                    if (process.ProcessName == "RoboDK")
                    {
                        process.Kill();
                    }
                goto tryagain;
            }
            RDK.setWindowState(RoboDK.WINDOWSTATE_SHOW); // shows if it was hidden
            RDK.setWindowState(RoboDK.WINDOWSTATE_CINEMA); // sets cinema mode (no toolbar, no title bar)
            RDK.setWindowState(RoboDK.WINDOWSTATE_MAXIMIZED); // maximizes the screen
            MoveWindow(RDK.PROCESS.MainWindowHandle, 0, -28, panel_rdk.Width, panel_rdk.Height + 28, true);
        }


        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool MoveWindow(IntPtr hWnd, int X, int Y, int nWidth, int nHeight, bool bRepaint);

        private void panel_Resized(object sender, EventArgs e)
        {
            // resize the content of the panel_rdk when it is resized
            MoveWindow(RDK.PROCESS.MainWindowHandle, 0, 0, panel_rdk.Width, panel_rdk.Height, true);
        }

        //////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////
        /////////////////// FOR INCREMENTAL MOVEMENT ////////////////////////

        private void rad_Move_wrt_Reference_CheckedChanged(object sender, EventArgs e)
        {
            // skip if the radio button became unchecked
            RadioButton rad_sender = (RadioButton)sender;
            if (!rad_sender.Checked) { return; }

            Set_Incremental_Buttons_Cartesian();
        }

        private void rad_Move_wrt_Tool_CheckedChanged(object sender, EventArgs e)
        {
            // skip if the radio button became unchecked
            RadioButton rad_sender = (RadioButton)sender;
            if (!rad_sender.Checked) { return; }

            Set_Incremental_Buttons_Cartesian();
        }

        private void rad_Move_Joints_CheckedChanged(object sender, EventArgs e)
        {
            // skip if the radio button became unchecked
            RadioButton rad_sender = (RadioButton)sender;
            if (!rad_sender.Checked) { return; }

            Set_Incremental_Buttons_Joints();
        }

        private void Set_Incremental_Buttons_Cartesian()
        {
            // update label units for the step:
            lblstepIncrement.Text = "Step (mm):";

            // Text to display on the positive motion buttons for incremental Cartesian movements:
            btnTXpos.Text = "+Tx";
            btnTYpos.Text = "+Ty";
            btnTZpos.Text = "+Tz";
            btnRXpos.Text = "+Rx";
            btnRYpos.Text = "+Ry";
            btnRZpos.Text = "+Rz";

            // Text to display on the negative motion buttons for incremental Cartesian movements:
            btnTXneg.Text = "-Tx";
            btnTYneg.Text = "-Ty";
            btnTZneg.Text = "-Tz";
            btnRXneg.Text = "-Rx";
            btnRYneg.Text = "-Ry";
            btnRZneg.Text = "-Rz";
        }

        private void Set_Incremental_Buttons_Joints()
        {
            // update label units for the step:
            lblstepIncrement.Text = "Step (deg):";

            // Text to display on the positive motion buttons for Incremental Joint movement:
            btnTXpos.Text = "+J1";
            btnTYpos.Text = "+J2";
            btnTZpos.Text = "+J3";
            btnRXpos.Text = "+J4";
            btnRYpos.Text = "+J5";
            btnRZpos.Text = "+J6";

            // Text to display on the positive motion buttons for Incremental Joint movement:
            btnTXneg.Text = "-J1";
            btnTYneg.Text = "-J2";
            btnTZneg.Text = "-J3";
            btnRXneg.Text = "-J4";
            btnRYneg.Text = "-J5";
            btnRZneg.Text = "-J6";
        }


        /// <summary>
        /// Move the the robot relative to the TCP
        /// </summary>
        /// <param name="movement"></param>
        private void Incremental_Move(string button_name)
        {
            if (!Check_ROBOT()) { return; }

            notifybar.Text = "Button selected: " + button_name;

            if (button_name.Length < 3)
            {
                notifybar.Text = "Internal problem! Button name should be like +J1, -Tx, +Rz or similar";
                return;
            }

            // get the the sense of motion the first character as '+' or '-'
            double move_step = 0.0;
            if (button_name[0] == '+')
            {
                move_step = +Convert.ToDouble(numStep.Value);
            }
            else if (button_name[0] == '-')
            {
                move_step = -Convert.ToDouble(numStep.Value);
            }
            else
            {
                notifybar.Text = "Internal problem! Unexpected button name";
                return;
            }

            //////////////////////////////////////////////
            //////// if we are moving in the joint space:
            if (rad_Move_Joints.Checked)
            {
                double[] joints = ROBOT.Joints();

                // get the moving axis (1, 2, 3, 4, 5 or 6)
                int joint_id = Convert.ToInt32(button_name[2].ToString()) - 1; // important, double array starts at 0

                joints[joint_id] = joints[joint_id] + move_step;

                try
                {
                    ROBOT.MoveJ(joints, MOVE_BLOCKING);
                    //ROBOT.MoveL(joints, MOVE_BLOCKING);
                }
                catch (RoboDK.RDKException rdkex)
                {
                    notifybar.Text = "The robot can't move to the target joints: " + rdkex.Message;
                    //MessageBox.Show("The robot can't move to " + new_pose.ToString());
                }
            }
            else
            {
                //////////////////////////////////////////////
                //////// if we are moving in the cartesian space
                // Button name examples: +Tx, -Tz, +Rx, +Ry, +Rz

                int move_id = 0;

                string[] move_types = new string[6] { "Tx", "Ty", "Tz", "Rx", "Ry", "Rz" };

                for (int i = 0; i < 6; i++)
                {
                    if (button_name.EndsWith(move_types[i]))
                    {
                        move_id = i;
                        break;
                    }
                }
                double[] move_xyzwpr = new double[6] { 0, 0, 0, 0, 0, 0 };
                move_xyzwpr[move_id] = move_step;
                Mat movement_pose = Mat.FromTxyzRxyz(move_xyzwpr);

                // the the current position of the robot (as a 4x4 matrix)
                Mat robot_pose = ROBOT.Pose();

                // Calculate the new position of the robot
                Mat new_robot_pose;
                bool is_TCP_relative_move = rad_Move_wrt_Tool.Checked;
                if (is_TCP_relative_move)
                {
                    // if the movement is relative to the TCP we must POST MULTIPLY the movement
                    new_robot_pose = robot_pose * movement_pose;
                }
                else
                {
                    // if the movement is relative to the reference frame we must PRE MULTIPLY the XYZ translation:
                    // new_robot_pose = movement_pose * robot_pose;
                    // Note: Rotation applies from the robot axes.

                    Mat transformation_axes = new Mat(robot_pose);
                    transformation_axes.setPos(0, 0, 0);
                    Mat movement_pose_aligned = transformation_axes.inv() * movement_pose * transformation_axes;
                    new_robot_pose = robot_pose * movement_pose_aligned;
                }

                // Then, we can do the movement:
                try
                {
                    ROBOT.MoveJ(new_robot_pose, MOVE_BLOCKING);
                }
                catch (RoboDK.RDKException rdkex)
                {
                    notifybar.Text = "The robot can't move to " + new_robot_pose.ToString();
                    //MessageBox.Show("The robot can't move to " + new_pose.ToString());
                }


                // Some tips:
                // retrieve the current pose of the robot: the active TCP with respect to the current reference frame
                // Tip 1: use
                // ROBOT.setFrame()
                // to set a reference frame (object link or pose)
                //
                // Tip 2: use
                // ROBOT.setTool()
                // to set a tool frame (object link or pose)
                //
                // Tip 3: use
                // ROBOT.MoveL_Collision(j1, new_move)
                // to test if a movement is feasible by the robot before doing the movement
                //
            }

        }



        private void btnTXpos_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            Incremental_Move(btn.Text); // send the text of the button as parameter
        }

        private void btnTXneg_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            Incremental_Move(btn.Text); // send the text of the button as parameter
        }

        private void btnTYpos_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            Incremental_Move(btn.Text); // send the text of the button as parameter
        }

        private void btnTYneg_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            Incremental_Move(btn.Text); // send the text of the button as parameter
        }

        private void btnTZpos_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            Incremental_Move(btn.Text); // send the text of the button as parameter
        }

        private void btnTZneg_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            Incremental_Move(btn.Text); // send the text of the button as parameter
        }

        private void btnRXpos_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            Incremental_Move(btn.Text); // send the text of the button as parameter
        }

        private void btnRXneg_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            Incremental_Move(btn.Text); // send the text of the button as parameter
        }

        private void btnRYpos_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            Incremental_Move(btn.Text); // send the text of the button as parameter
        }

        private void btnRYneg_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            Incremental_Move(btn.Text); // send the text of the button as parameter
        }

        private void btnRZpos_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            Incremental_Move(btn.Text); // send the text of the button as parameter
        }

        private void btnRZneg_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            Incremental_Move(btn.Text); // send the text of the button as parameter
        }



        /*
        /// <summary>
        /// Move the the robot relative to the TCP
        /// </summary>
        /// <param name="movement"></param>
        private void Robot_Move_Cartesian(Mat add_move, bool is_relative_TCP = false)
        {
            if (!Check_ROBOT()) { return; }

            // retrieve the current pose of the robot: the active TCP with respect to the current reference frame
            // Tip 1: use
            // ROBOT.setPoseFrame()
            // to set a reference frame (object link or pose)
            //
            // Tip 2: use
            // ROBOT.setPoseTool()
            // to set a tool frame (object link or pose)
            //
            // Tip 3: use
            // ROBOT.MoveL_Collision(j1, new_move)
            // to test if a movement is feasible by the robot before doing the movement
            // Collisions are not detected if collision detection is turned off.
            Mat robot_pose = ROBOT.Pose();

            // calculate the new pose of the robot (post multiply)
            Mat new_pose = robot_pose * add_move;
            try
            {
                ROBOT.MoveJ(new_pose, MOVE_BLOCKING);
            }
            catch (RoboDK.RDKException rdkex)
            {
                notifybar.Text = "The robot can't move to " + new_pose.ToString();
                //MessageBox.Show("The robot can't move to " + new_pose.ToString());
            }
        }



        /// <summary>
        /// This shows an example that moves the robot to a relative position given joint coordinates. The forward kinematics is calculated.
        /// </summary>
        /// <param name="joints"></param>
        private void Move_2_Approach(double[] joints)
        {
            if (!Check_ROBOT()) { return; }
            double approach_dist = 100; // Double.Parse(txtApproach.Text);
            Mat approach_mat = Mat.transl(0, 0, -approach_dist);

            // calculate the position of the robot * tool            
            Mat tool_pose = ROBOT.PoseTool();                       // get the tool pose of the robot
            Mat robot_tool_pose = ROBOT.SolveFK(joints) * tool_pose * approach_mat; // get the new position (approach) of the robot*tool
            Mat robot_pose = robot_tool_pose * tool_pose.inv();  // get the position of the robot (from the base frame to the tool flange)
            double[] joints_app = ROBOT.SolveIK(robot_pose);           // calculate inverse kinematics to get the robot joints for the approach position
            if (joints_app == null)
            {
                MessageBox.Show("Position not reachable");
                return;
            }
            ROBOT.MoveJ(joints_app, MOVE_BLOCKING);
        }
        */



        //----------------------------------------------------------------------------------------------
        //----------------------------------------------------------------------------------------------
        //----------------------------------------------------------------------------------------------
        //----------------------------------------------------------------------------------------------
        // The following code is meant to show a sample to manage different administrator rights 
        // to provide acces to a subset of RoboDK features.
        // The Setup_Notification_Icon will add a notification icon in the task bar with lock/unlock options
        private void Setup_Notification_Icon()
        {
            // Create the NotifyIcon.
            NotifyIcon ProcessTaskBar = new System.Windows.Forms.NotifyIcon();

            // setup context menu
            Container components = new System.ComponentModel.Container();
            ContextMenu contextMenu = new System.Windows.Forms.ContextMenu();
            MenuItem option_Lock = new System.Windows.Forms.MenuItem();
            MenuItem option_Unlock = new System.Windows.Forms.MenuItem();

            // Initialize contextMenu
            contextMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] { option_Lock, option_Unlock });

            // Initialize option_Lock
            option_Lock.Index = 0;
            option_Lock.Text = "Lock RoboDK Station";
            option_Lock.Click += new System.EventHandler(this.RoboDK_Lock);
            // Initialize option_Unlock
            option_Unlock.Index = 1;
            option_Unlock.Text = "Unlock RoboDK Station";
            option_Unlock.Click += new System.EventHandler(this.RoboDK_Unlock);
            //
            ProcessTaskBar.ContextMenu = contextMenu;

            // The Text property sets the text that will be displayed,
            // in a tooltip, when the mouse hovers over the systray icon.
            // ProcessTaskBar.Icon = SamplePanelRoboDK.Properties.Resources.IconRoboDK;
            ProcessTaskBar.Text = "RoboDK";
            ProcessTaskBar.Visible = true;

            // Handle the DoubleClick event to activate the form.
            ProcessTaskBar.DoubleClick += new System.EventHandler(this.Show_RoboDK);
        }
        private void Show_RoboDK(Object sender, System.EventArgs e)
        {
            // Check RoboDK connection
            if (!Check_RDK()) { return; }
            RDK.ShowRoboDK();
        }

        private void RoboDK_Lock(Object sender, System.EventArgs e)
        {
            // Check RoboDK connection
            if (!Check_RDK()) { return; }

            //RDK.setFlagsRoboDK(RoboDK.FLAG_ROBODK_MENUEDIT_ACTIVE | RoboDK.FLAG_ROBODK_MENUEDIT_ACTIVE);
            RDK.setFlagsRoboDK(RoboDK.FLAG_ROBODK_NONE);
            RDK.setFlagsItem(null, RoboDK.FLAG_ITEM_NONE);
            if (ROBOT.Valid())
            {
                RDK.setFlagsItem(ROBOT, RoboDK.FLAG_ITEM_ALL);
            }
        }

        // Called when the user selects to unlock a feature
        private void RoboDK_Unlock(Object sender, System.EventArgs e)
        {
            // Check RoboDK connection
            if (!Check_RDK()) { return; }

            string code = "1234";
            if (ShowInputDialog(ref code, "Default admin: 1234 or 0000") == DialogResult.OK)
            {
                if (code == "1234")
                {
                    RDK.setFlagsRoboDK(RoboDK.FLAG_ROBODK_ALL);
                    RDK.setFlagsItem(null, RoboDK.FLAG_ITEM_ALL);
                    RDK.ShowRoboDK();
                }
                else if (code == "0000")
                {
                    RDK.setFlagsRoboDK(RoboDK.FLAG_ROBODK_DOUBLE_CLICK | RoboDK.FLAG_ROBODK_MENU_ACTIVE | RoboDK.FLAG_ROBODK_MENUEDIT_ACTIVE | RoboDK.FLAG_ROBODK_MENUTOOLS_ACTIVE);
                    RDK.setFlagsItem(null, RoboDK.FLAG_ITEM_EDITABLE);
                    RDK.ShowRoboDK();
                }
                else
                {
                    MessageBox.Show("Invalid code!");
                }
            }
        }

        // ShowInputDialog will create a dialog box on the fly to provide an access code
        private static DialogResult ShowInputDialog(ref string input, string message)
        {
            System.Drawing.Size size = new System.Drawing.Size(250, 70 + 23);
            Form inputBox = new Form();

            inputBox.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            inputBox.ClientSize = size;
            inputBox.Text = "Enter Code";// (default admin: 1234, or 0000)";

            System.Windows.Forms.Label label = new Label();
            label.Size = new System.Drawing.Size(size.Width - 10, 23);
            label.Location = new System.Drawing.Point(5, 5);
            label.Text = message;
            inputBox.Controls.Add(label);

            System.Windows.Forms.TextBox textBox = new TextBox();
            textBox.Size = new System.Drawing.Size(size.Width - 10, 23);
            textBox.Location = new System.Drawing.Point(5, 5 + 23);
            textBox.Text = input;
            inputBox.Controls.Add(textBox);

            Button okButton = new Button();
            okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            okButton.Name = "okButton";
            okButton.Size = new System.Drawing.Size(75, 23);
            okButton.Text = "&OK";
            okButton.Location = new System.Drawing.Point(size.Width - 80 - 80, 39 + 23);
            inputBox.Controls.Add(okButton);

            Button cancelButton = new Button();
            cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new System.Drawing.Size(75, 23);
            cancelButton.Text = "&Cancel";
            cancelButton.Location = new System.Drawing.Point(size.Width - 80, 39 + 23);
            inputBox.Controls.Add(cancelButton);

            inputBox.AcceptButton = okButton;
            inputBox.CancelButton = cancelButton;

            DialogResult result = inputBox.ShowDialog();
            input = textBox.Text;
            return result;
        }

        private void FormRobot_FormClosed(object sender, FormClosingEventArgs e)
        {
            if (!Check_RDK()) { return; }
            // Force to stop and close RoboDK (optional)
            // RDK.CloseAllStations(); // close all stations
            // RDK.Save("path_to_save.rdk"); // save the project if desired
            RDK.CloseRoboDK();
            RDK = null;
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            connectButton_Click(null, null);

            // pictureBox1.Image = Image.FromFile("test.bmp");
        }
        // Closing the main form
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Disconnect();
        }
        // Enable/disable connection related controls
        private void EnableConnectionControls(bool enable)
        {
            devicesCombo.Enabled = enable;
            videoResolutionsCombo.Enabled = enable;
            snapshotResolutionsCombo.Enabled = enable;
            connectButton.Enabled = enable;
            disconnectButton.Enabled = !enable;
            triggerButton.Enabled = (!enable) && (snapshotCapabilities.Length != 0);
        }
        // New video device is selected
        private void devicesCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (videoDevices.Count != 0)
            {
                videoDevice = new VideoCaptureDevice(videoDevices[devicesCombo.SelectedIndex].MonikerString);
                EnumeratedSupportedFrameSizes(videoDevice);
            }
        }
        // Collect supported video and snapshot sizes
        private void EnumeratedSupportedFrameSizes(VideoCaptureDevice videoDevice)
        {
            this.Cursor = Cursors.WaitCursor;

            videoResolutionsCombo.Items.Clear();
            snapshotResolutionsCombo.Items.Clear();

            try
            {
                videoCapabilities = videoDevice.VideoCapabilities;
                snapshotCapabilities = videoDevice.SnapshotCapabilities;

                foreach (VideoCapabilities capabilty in videoCapabilities)
                {
                    videoResolutionsCombo.Items.Add(string.Format("{0} x {1}",
                        capabilty.FrameSize.Width, capabilty.FrameSize.Height));
                }

                foreach (VideoCapabilities capabilty in snapshotCapabilities)
                {
                    snapshotResolutionsCombo.Items.Add(string.Format("{0} x {1}",
                        capabilty.FrameSize.Width, capabilty.FrameSize.Height));
                }

                if (videoCapabilities.Length == 0)
                {
                    videoResolutionsCombo.Items.Add("Not supported");
                }
                if (snapshotCapabilities.Length == 0)
                {
                    snapshotResolutionsCombo.Items.Add("Not supported");
                }

                videoResolutionsCombo.SelectedIndex = 0;
                snapshotResolutionsCombo.SelectedIndex = 0;
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }
        // On "Connect" button clicked
        private void connectButton_Click(object sender, EventArgs e)
        {
            if (videoDevice != null)
            {
                if ((videoCapabilities != null) && (videoCapabilities.Length != 0))
                {
                    videoDevice.VideoResolution = videoCapabilities[videoResolutionsCombo.SelectedIndex];
                }

                if ((snapshotCapabilities != null) && (snapshotCapabilities.Length != 0))
                {
                    videoDevice.ProvideSnapshots = true;
                    videoDevice.SnapshotResolution = snapshotCapabilities[snapshotResolutionsCombo.SelectedIndex];
                    videoDevice.SnapshotFrame += new NewFrameEventHandler(videoDevice_SnapshotFrame);
                }

                EnableConnectionControls(false);

                videoSourcePlayer.VideoSource = videoDevice;
                videoSourcePlayer.Start();
            }
        }
        // On "Disconnect" button clicked
        private void disconnectButton_Click(object sender, EventArgs e)
        {
            Disconnect();
        }
        // Disconnect from video device
        private void Disconnect()
        {
            if (videoSourcePlayer.VideoSource != null)
            {
                // stop video device
                videoSourcePlayer.SignalToStop();
                videoSourcePlayer.WaitForStop();
                videoSourcePlayer.VideoSource = null;

                if (videoDevice.ProvideSnapshots)
                {
                    videoDevice.SnapshotFrame -= new NewFrameEventHandler(videoDevice_SnapshotFrame);
                }

                EnableConnectionControls(true);
            }
        }

        private void panel_rdk_Paint(object sender, PaintEventArgs e)
        {
            button4_Click(null, null);
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            radioButton1.Checked = !radioButton2.Checked;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            radioButton2.Checked = !radioButton1.Checked;
        }



        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            timer1.Stop();
        }


    }
}
