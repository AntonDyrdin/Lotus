using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using AForge.Video;
using AForge.Video.DirectShow;

namespace Lotus
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private FilterInfoCollection videoDevices;
        public VideoCaptureDevice videoDevice;
        private VideoCapabilities[] videoCapabilities;
        private VideoCapabilities[] snapshotCapabilities;

        private void Form1_Load(object sender, EventArgs e)
        {

            g = pictureBox1.CreateGraphics();
            g2 = pictureBox2.CreateGraphics();

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
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                pictureBox1.Image.Save("background.bmp");
            }
            else
            {
                MessageBox.Show("Get the background first!");
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (background == null)
            {
                background = Image.FromFile("background.bmp");
                back = new Mat(background);
            }
            image = pictureBox1.Image;
            Color A = find(image);
            //     A = Color.FromArgb(sumRA / sumPixA-averege.R, sumGA / sumPixA-averege.G, sumBA / sumPixA-averege.B);

            int min = 666666;
            for (int i = 0; i < colors.Count; i++)
            {
                if (min > modul(A, colors[i]))
                {
                    min = modul(A, colors[i]);
                    X = colors[i];
                }
            }
            Font font = new Font(Font.Name, 40);
            SolidBrush BrushA = new SolidBrush(X);
            g.DrawString(X.Name, font, BrushA, 10, 10);
            font = new Font(Font.Name, 20);
            BrushA = new SolidBrush(Color.Black);
            g.DrawString(Convert.ToString(A.R) + "   " + Convert.ToString(A.G) + "   " + Convert.ToString(A.B), font, BrushA, 10, 60);
        }
        // New snapshot frame is available
        private void videoDevice_SnapshotFrame(object sender, NewFrameEventArgs eventArgs)
        {
            pictureBox1.Image = (Bitmap)eventArgs.Frame.Clone();

        }

        Image image;
        Image background;
        Graphics g;
        Graphics g2;
        Color X;

        Mat back;
        Color averegeBack;
        List<Color> colors = new List<Color>();
        Color find(Image image)
        {

            Color A = Color.Black;

            Mat img = new Mat(image);

            A = deviation(img);

            return A;
        }
        int modul(Color A, Color B)
        {

            int ans = (int)Math.Sqrt((A.R - B.R) * (A.R - B.R) + (A.G - B.G) * (A.G - B.G) + (A.B - B.B) * (A.B - B.B));
            return ans;
        }

        Color deviation(Mat img)
        {
            Bitmap dev = new Bitmap(320, 240);
            int deviationR = 0;
            int deviationG = 0;
            int deviationB = 0;
            int R;
            int G;
            int B;
            int S = 0;
            int d = 7;
            int up = 0;
            for (int i = 0; i < img.resolution; i++)
                for (int j = 0; j < img.resolution; j++)
                {
                    if ((back.m[i, j].R - img.m[i, j].R) > d || (back.m[i, j].G - img.m[i, j].G) > d || (back.m[i, j].B - img.m[i, j].B) > d)
                    {
                        S++;
                        /*  R = img.m[i, j].R + (255 - averegeBack.R) - up;
                          if (R < 0)
                              R = 0;
                          else if (R > 255)
                              R = 255;

                          G = (img.m[i, j].G + (255 - averegeBack.G))-up;
                          if (G < 0)
                              G = 0;
                          else if (G > 255)
                              G = 255;

                          B = (img.m[i, j].B + (255 - averegeBack.B))-up;
                          if (B < 0)
                              B = 0;
                          else if (B > 255)
                              B = 255;*/

                        R = img.m[i, j].R + (255 - averegeBack.R) - up;
                        if (R < 0)
                            R = 0;
                        else if (R > 255)
                            R = 255;

                        G = (img.m[i, j].G + (255 - averegeBack.G)) - up;
                        if (G < 0)
                            G = 0;
                        else if (G > 255)
                            G = 255;

                        B = (img.m[i, j].B + (255 - averegeBack.B)) - up;
                        if (B < 0)
                            B = 0;
                        else if (B > 255)
                            B = 255;


                        deviationR += R;
                        deviationG += G;
                        deviationB += B;

                        dev.SetPixel(i, j, Color.FromArgb(R, G, B));
                    }


                }

            pictureBox2.Refresh();
            g2.ScaleTransform((float)3.2, (float)2.4);
            g2.DrawImage(dev, 0, 0);
            g2.ResetTransform();
            //    try
            // { 
            if (modul(Color.White, Color.FromArgb(deviationR / S, deviationG / S, deviationB / S)) < 50 || S < 100)
                return Color.White;
            return Color.FromArgb(deviationR / S, deviationG / S, deviationB / S);

            //return Color.FromArgb(255 - deviationR / S, 255 - deviationG / S, 255 - deviationB / S);
            // }
            // catch
            //  {
            //     return Color.Black;
            //  }
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
        // Simulate snapshot trigger
        private void triggerButton_Click(object sender, EventArgs e)
        {
            if ((videoDevice != null) && (videoDevice.ProvideSnapshots))
            {
                videoDevice.SimulateTrigger();
            }
        }
        private void videoSourcePlayer1_Click(object sender, EventArgs e)
        {

        }


    }
}
