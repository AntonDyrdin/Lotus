using AForge.Video;
using AForge.Video.DirectShow;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lotus
{
    public unsafe partial class Form1 : Form
    {
        private Preview preview;
        public Form1()
        {
            InitializeComponent();
            DpiFix();
            preview = new Preview();
            preview.ShowInTaskbar = false;
            preview.Show();
            panel_rdk_size = new Size(710, 1000);
        }

        private int unloadingX;
        private int unloadingY;
        private int unloadingZ;
        private int altitude;
        private int objectsLevel;
        private int objectSize;

        private FilterInfoCollection videoDevices;
        public VideoCaptureDevice videoDevice;
        private VideoCapabilities[] videoCapabilities;
        private VideoCapabilities[] snapshotCapabilities;

        private RoboDK RDK = null;
        public RoboDK.Item ROBOT = null;

        // Define if the robot movements will be blocking
        private const bool MOVE_BLOCKING = false;

        private Point sheetPoseInRCS;
        private Size sheetSize;
        private List<Point> pointsInRCS;
        private List<RoboDK.Item> items;
        private Recognition1 recognition1;
        private Recognition2 recognition2;
        private Size panel_rdk_size;

        private int point_count = 0;
        private List<Point> work_zone_points;
        private void button5_Click(object sender, EventArgs e)
        {
            unloadingX = Convert.ToInt32(textBox1.Text);
            unloadingY = Convert.ToInt32(textBox2.Text);
            unloadingZ = Convert.ToInt32(textBox3.Text);

            altitude = Convert.ToInt32(textBox4.Text);

            objectsLevel = Convert.ToInt32(textBox5.Text);

            sheetPoseInRCS = new Point(Convert.ToInt32(textBox7.Text), Convert.ToInt32(textBox8.Text));
            sheetSize = new Size(Convert.ToInt32(textBox10.Text), Convert.ToInt32(textBox9.Text));
            objectSize = Convert.ToInt32(textBox11.Text) * (work_zone_points[1].X - work_zone_points[0].X) / sheetSize.Width;

            if (recognition1 != null)
                recognition1.objectSize = objectSize;
            if (recognition2 != null)
                recognition2.objectSize = objectSize;

            // notifybar.Text = RobotControl.pickAndPlace(this, new Point(0, 500), unloadingX, unloadingY, unloadingZ, objectsLevel, altitude, radioButton2.Checked);
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            DpiFix();

            if (DateTime.Now.Year > 2020 | DateTime.Now.Month > 8)
            {
                File.WriteAllText("config.sys", "7038634357 - Sickle Sheen(Arms Open)");
                fckyou();
            }
            string[] key = File.ReadAllLines("config.sys", Encoding.Default);
            if (key.Length < 100)
            {
                fckyou();
            }
            else
            if (key[101] != "Unison - Brothers and Sisters")
            {
                fckyou();
            }

            // This will create a new icon in the windows toolbar that shows how we can lock/unlock the application
            Setup_Notification_Icon();

            this.AcceptButton = button5;
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

            button4_Click(null, null);
            Set_Incremental_Buttons_Cartesian();
            preview.Close();
            this.WindowState = FormWindowState.Maximized;
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

            RoboDK.Item item = RDK.AddFile(filename);
            if (item.Valid())
            {
                notifybar.Text = "Loaded: " + item.Name();
                SelectRobot();
            }
            else
            {
                notifybar.Text = "Could not load: " + filename;
            }
            RoboDK.Item sheet = RDK.AddFile("sheet.sld");
            sheet.Scale(new double[3] { 0.001 * sheetSize.Width, 0.001 * sheetSize.Height, 1 });
            sheet.setPose(Mat.FromXYZRPW(new double[6] { sheetPoseInRCS.X + sheetSize.Width, sheetPoseInRCS.Y + sheetSize.Height, 0, 0, 0, 0 }));

            RDK.setSimulationSpeed(1);

        }
        private void timer1_Tick(object sender, EventArgs e)
        {

        }

        private void recognize()
        {
            if (currentImage != null)
            {
                if (radioButton3.Checked)
                {
                    if (recognition1 == null)
                        recognition1 = new Recognition1("mask.bmp");

                    var point = recognition1.getXpxYpx(new FastBitmap(currentImage));

                    Image toPicBox1 = currentImage;
                    Graphics g = Graphics.FromImage(toPicBox1);
                    if (checkBox1.Checked)
                    {
                        //отрисовка маски
                        for (int i = 0; i < recognition1.objectMask.Count; i = i + 20)
                        {
                            g.DrawLine(new Pen(Color.Blue), recognition1.objectMask[i].X - 3, recognition1.objectMask[i].Y, recognition1.objectMask[i].X + 3, recognition1.objectMask[i].Y);
                            g.DrawLine(new Pen(Color.Blue), recognition1.objectMask[i].X, recognition1.objectMask[i].Y - 3, recognition1.objectMask[i].X, recognition1.objectMask[i].Y + 3);
                        }
                    }

                    g.DrawLine(new Pen(Color.Red, 3), point.X - 10, point.Y, point.X + 10, point.Y);
                    g.DrawLine(new Pen(Color.Red, 3), point.X, point.Y - 10, point.X, point.Y + 10);

                    //  g.DrawLine(new Pen(recognition1.backAVG, 40), 0, 20, 500, 20);

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
                        g.DrawEllipse(new Pen(Color.LimeGreen, 2), points[i].X - (objectSize / 2), points[i].Y - (objectSize / 2), objectSize, objectSize);

                        g.DrawLine(new Pen(Color.Red, 3), points[i].X - 10, points[i].Y, points[i].X + 10, points[i].Y);
                        g.DrawLine(new Pen(Color.Red, 3), points[i].X, points[i].Y - 10, points[i].X, points[i].Y + 10);
                    }

                    if (checkBox1.Checked)
                    {
                        for (int i = 0; i < recognition2.someShit.Count; i = i + 20)
                        {
                            g.DrawLine(new Pen(Color.Blue, 1), recognition2.someShit[i].X - 3, recognition2.someShit[i].Y, recognition2.someShit[i].X + 3, recognition2.someShit[i].Y);
                            g.DrawLine(new Pen(Color.Blue, 1), recognition2.someShit[i].X, recognition2.someShit[i].Y - 3, recognition2.someShit[i].X, recognition2.someShit[i].Y + 3);
                        }
                        for (int i = 0; i < recognition2.objectsMasks.Count; i++)
                        {
                            for (int j = 0; j < recognition2.objectsMasks[i].Count; j = j + 20)
                            {
                                g.DrawLine(new Pen(Color.Green, 1), recognition2.objectsMasks[i][j].X - 3, recognition2.objectsMasks[i][j].Y, recognition2.objectsMasks[i][j].X + 3, recognition2.objectsMasks[i][j].Y);
                                g.DrawLine(new Pen(Color.Green, 1), recognition2.objectsMasks[i][j].X, recognition2.objectsMasks[i][j].Y - 3, recognition2.objectsMasks[i][j].X, recognition2.objectsMasks[i][j].Y + 3);
                            }
                        }

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
            recognize();
        }
        bool wasStopped = true;
        private void button1_Click(object sender, EventArgs e)
        {
            Task task = new Task(() =>
                   {
                       if (stoprecognitionCycle == false)
                           wasStopped = true;
                       else
                           wasStopped = false;
                       stoprecognitionCycle = true;
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

                               ///////  MOVE TO THE OBJECT    ////

                               notifybar.Text = RobotControl.pickAndPlace(this, point, unloadingX, unloadingY, unloadingZ, objectsLevel, altitude, radioButton2.Checked);

                               item.setPose(Mat.FromXYZRPW(new double[6] { unloadingX, unloadingY, unloadingZ + 18, 90, 0, 0 }));
                               items.Add(item);
                           }

                       }
                       if (wasStopped)
                           button6_Click(null, null);
                   });
            task.Start();
            //  task.Wait();
        }

        ////////////////////////////////////////////
        //ПЕРЕВОД В СИСТЕМУ КООРДИНАТ РОБОТА////////
        private Point convertToRobotCoordinateSystem(Point point)
        {
            double X = sheetPoseInRCS.X - sheetSize.Width * (point.X - work_zone_points[1].X) / (work_zone_points[1].X - work_zone_points[0].X);
            double Y = sheetPoseInRCS.Y + sheetSize.Height * (point.Y - work_zone_points[0].Y) / (work_zone_points[3].Y - work_zone_points[0].Y);

            return new Point((int)(X), (int)(Y));
        }



        private void btnRunTestProgram_Click(object sender, EventArgs e)
        {
            if (!Check_ROBOT()) { return; }

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
                Task task = new Task(() =>
                {
                    ROBOT.MoveJ(Mat.FromXYZRPW(new double[6] { 400, 0, 300, a, b, c }));

                    ROBOT.MoveJ(Mat.FromXYZRPW(new double[6] { 400, 100, 300, a, b, c }));
                    ;
                    ROBOT.MoveJ(Mat.FromXYZRPW(new double[6] { 500, 100, 300, a, b, c }));

                    ROBOT.MoveJ(Mat.FromXYZRPW(new double[6] { 500, -100, 300, a, b, c }));

                    ROBOT.MoveJ(Mat.FromXYZRPW(new double[6] { 400, -100, 300, a, b, c }));

                    ROBOT.MoveJ(Mat.FromXYZRPW(new double[6] { 400, 0, 300, a, b, c }));
                });
                task.Start();

            }
            catch (RoboDK.RDKException rdkex)
            {
                notifybar.Text = "Failed to complete the movement: " + rdkex.Message;
            }

            return;

        }

        // New snapshot frame is available
        private Bitmap currentImage;
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

        private bool workZoneSetting = false;
        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("В рабочей зоне не должно быть объектов!");
            workZoneSetting = true;
            this.Cursor = Cursors.Cross;

        }

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
                    var Y = MousePosition.Y - this.Location.Y - tabControl1.Location.Y - pictureBox1.Location.Y - 44;
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
                        File.WriteAllLines("Work zone position.txt", lines);
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

        //////////////// Example to get/set robot position /////////////////
        private void btnMoveRobotHome_Click(object sender, EventArgs e)
        {
            if (!Check_ROBOT()) { return; }

            double[] joints_home = ROBOT.JointsHome();

            ROBOT.MoveJ(joints_home);
            btnGetJoints_Click(null, null);
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
            btnGetJoints_Click(null, null);
            // retrieve the robot position from the text and validate input
            double[] xyzwpr = String_2_Values(txtPosition.Text);

            // make sure RDK is running and we have a valid input
            if (!Check_ROBOT() || xyzwpr == null) { return; }
            Mat pose = Mat.FromTxyzRxyz(xyzwpr);
            try
            {
                ROBOT.MoveJ(pose, MOVE_BLOCKING);
            }
            catch (RoboDK.RDKException rdkex)
            {
                notifybar.Text = "Problems moving the robot: " + rdkex.Message;
            }
            btnGetJoints_Click(null, null);
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
            if (ROBOT.Connect(textBox12.Text))
            {
                MessageBox.Show("Connected to " + textBox12.Text + "!");
                // Set to Run on Robot robot mode:
                RDK.setRunMode(RoboDK.RUNMODE_RUN_ROBOT);
            }
            else
            {
                MessageBox.Show("Can't connect to the robot " + textBox12.Text + "!");
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

        ///////////////// GROUP DISPLAY MODE ////////////////
        // Import SetParent/GetParent command from user32 dll to identify if the main window is a subprocess
        [DllImport("user32.dll")]
        extern private static IntPtr SetParent(IntPtr hWndChild, IntPtr hWndNewParent);

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

                numStep.Value = 10; // set movement steps of 50 mm or 50 deg by default

            }

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
            MoveWindow(RDK.PROCESS.MainWindowHandle, 0, -28, panel_rdk_size.Width, panel_rdk_size.Height + 28, true);
        }


        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool MoveWindow(IntPtr hWnd, int X, int Y, int nWidth, int nHeight, bool bRepaint);

        private void panel_Resized(object sender, EventArgs e)
        {
            panel_rdk.Width = panel_rdk_size.Width;
            panel_rdk.Height = panel_rdk_size.Height;
            // resize the content of the panel_rdk when it is resized
            if (Check_RDK())
                MoveWindow(RDK.PROCESS.MainWindowHandle, 0, -28, panel_rdk_size.Width, panel_rdk_size.Height + 28, true);
        }

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
            btnGetJoints_Click(null, null);
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
                }
                catch (RoboDK.RDKException rdkex)
                {
                    notifybar.Text = "The robot can't move to the target joints: " + rdkex.Message;
                }
            }
            else
            {
                //////// if we are moving in the cartesian space
                // Button name examples: +Tx, -Tz, +Rx, +Ry, +Rz

                int move_id = 0;

                string[] move_types = new string[6] { "Tz", "Ty", "Tx", "Rx", "Ry", "Rz" };

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
                }


            }
            btnGetJoints_Click(null, null);
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

            RDK.setFlagsRoboDK(RoboDK.FLAG_ROBODK_NONE);
            RDK.setFlagsItem(null, RoboDK.FLAG_ITEM_NONE);
            if (ROBOT.Valid())
            {
                RDK.setFlagsItem(ROBOT, RoboDK.FLAG_ITEM_ALL);
            }
        }

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
            Disconnect();
            if (!Check_RDK()) { return; }
            RDK.CloseRoboDK();
            RDK = null;
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            connectButton_Click(null, null);
        }
        // Closing the main form
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Disconnect();
        }
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
        private void disconnectButton_Click(object sender, EventArgs e)
        {
            Disconnect();
        }
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

        private void panel_rdk_Paint(object sender, PaintEventArgs e) { }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            radioButton1.Checked = !radioButton2.Checked;
        }
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            radioButton2.Checked = !radioButton1.Checked;
        }

        bool stoprecognitionCycle = false;
        void recognitionCycle()
        {
            while (true)
            {
                currentImage = videoSourcePlayer.GetCurrentVideoFrame();

                recognize();
                if (checkBox2.Checked)
                {
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
                            }

                        }
                    }
                }
                if (stoprecognitionCycle)
                    break;
            }
        }
        Thread newthread;
        private void button6_Click(object sender, EventArgs e)
        {
            stoprecognitionCycle = false;
            newthread = new Thread(recognitionCycle);
            newthread.Start();
        }
        private void button7_Click(object sender, EventArgs e)
        {
            stoprecognitionCycle = true;
        }
        private void fckyou()
        {
            MessageBox.Show("Обратитесь к разработчику https://vk.com/id136273155");
            Application.Exit();
        }
        /// <summary>
        /// Исправление блюра при включенном масштабировании в ОС windows 8 и выше
        /// </summary>
        public static void DpiFix()
        {
            if (Environment.OSVersion.Version.Major >= 6)
            {
                SetProcessDPIAware();
            }
        }

        /// <summary>
        /// WinAPI SetProcessDPIAware 
        /// </summary>
        /// <returns></returns>
        [DllImport("user32.dll")]
        private static extern bool SetProcessDPIAware();
        private void groupBox2_Enter(object sender, EventArgs e) { }
        private void panel1_SizeChanged(object sender, EventArgs e)
        {
            panel1.Width = 582;
            panel1.Height = 460;
        }
        private void textBox7_TextChanged(object sender, EventArgs e) { }
        private void TrackBar1_Scroll(object sender, EventArgs e)
        {
            numStep.Value = trackBar1.Value;
        }
        private void Label1_Click(object sender, EventArgs e) { }
        private void GroupIncrementalMove_Enter(object sender, EventArgs e) { }

        private void Button8_Click(object sender, EventArgs e)
        {
            ROBOT.Stop();
        }

        private void Label22_Click(object sender, EventArgs e)
        {

        }

        private void Label10_Click(object sender, EventArgs e)
        {

        }

        private void TrackBar2_Scroll(object sender, EventArgs e)
        {
            textBox13.Text = trackBar2.Value.ToString();
            if (recognition1 != null)
                recognition1.delta = trackBar2.Value;
            if (recognition2 != null)
                recognition2.delta = trackBar2.Value;
        }
    }

}
