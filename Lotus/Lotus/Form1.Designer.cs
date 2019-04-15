namespace Lotus
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.triggerButton = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.videoSourcePlayer = new AForge.Controls.VideoSourcePlayer();
            this.disconnectButton = new System.Windows.Forms.Button();
            this.connectButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.snapshotResolutionsCombo = new System.Windows.Forms.ComboBox();
            this.videoResolutionsCombo = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.devicesCombo = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.button2 = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.button3 = new System.Windows.Forms.Button();
            this.btnMoveRobotHome = new System.Windows.Forms.Button();
            this.groupRunMode = new System.Windows.Forms.GroupBox();
            this.btnOLPdone = new System.Windows.Forms.Button();
            this.rad_RunMode_Simulation = new System.Windows.Forms.RadioButton();
            this.rad_RunMode_Online = new System.Windows.Forms.RadioButton();
            this.rad_RunMode_Program = new System.Windows.Forms.RadioButton();
            this.groupIncrementalMove = new System.Windows.Forms.GroupBox();
            this.btnTXneg = new System.Windows.Forms.Button();
            this.numStep = new System.Windows.Forms.NumericUpDown();
            this.lblstepIncrement = new System.Windows.Forms.Label();
            this.rad_Move_Joints = new System.Windows.Forms.RadioButton();
            this.rad_Move_wrt_Tool = new System.Windows.Forms.RadioButton();
            this.rad_Move_wrt_Reference = new System.Windows.Forms.RadioButton();
            this.btnTXpos = new System.Windows.Forms.Button();
            this.btnTYneg = new System.Windows.Forms.Button();
            this.btnTYpos = new System.Windows.Forms.Button();
            this.btnRZpos = new System.Windows.Forms.Button();
            this.btnTZneg = new System.Windows.Forms.Button();
            this.btnRZneg = new System.Windows.Forms.Button();
            this.btnTZpos = new System.Windows.Forms.Button();
            this.btnRYpos = new System.Windows.Forms.Button();
            this.btnRXneg = new System.Windows.Forms.Button();
            this.btnRYneg = new System.Windows.Forms.Button();
            this.btnRXpos = new System.Windows.Forms.Button();
            this.btnRunTestProgram = new System.Windows.Forms.Button();
            this.btnSelectStation = new System.Windows.Forms.Button();
            this.btnMoveJoints = new System.Windows.Forms.Button();
            this.txtJoints = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnMovePose = new System.Windows.Forms.Button();
            this.btnGetJoints = new System.Windows.Forms.Button();
            this.txtPosition = new System.Windows.Forms.TextBox();
            this.lblJ1 = new System.Windows.Forms.Label();
            this.panel_rdk = new System.Windows.Forms.Panel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.notifybar = new System.Windows.Forms.ToolStripStatusLabel();
            this.button4 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupRunMode.SuspendLayout();
            this.groupIncrementalMove.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numStep)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // triggerButton
            // 
            this.triggerButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.triggerButton.ForeColor = System.Drawing.Color.White;
            this.triggerButton.Location = new System.Drawing.Point(435, 72);
            this.triggerButton.Name = "triggerButton";
            this.triggerButton.Size = new System.Drawing.Size(75, 23);
            this.triggerButton.TabIndex = 19;
            this.triggerButton.Text = "&Trigger";
            this.triggerButton.UseVisualStyleBackColor = true;
            this.triggerButton.Click += new System.EventHandler(this.triggerButton_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.videoSourcePlayer);
            this.panel1.Location = new System.Drawing.Point(5, 101);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(505, 293);
            this.panel1.TabIndex = 18;
            // 
            // videoSourcePlayer
            // 
            this.videoSourcePlayer.AutoSizeControl = true;
            this.videoSourcePlayer.BackColor = System.Drawing.SystemColors.ControlDark;
            this.videoSourcePlayer.ForeColor = System.Drawing.Color.Yellow;
            this.videoSourcePlayer.Location = new System.Drawing.Point(91, 25);
            this.videoSourcePlayer.Name = "videoSourcePlayer";
            this.videoSourcePlayer.Size = new System.Drawing.Size(322, 242);
            this.videoSourcePlayer.TabIndex = 1;
            this.videoSourcePlayer.VideoSource = null;
            this.videoSourcePlayer.Click += new System.EventHandler(this.videoSourcePlayer1_Click);
            // 
            // disconnectButton
            // 
            this.disconnectButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.disconnectButton.ForeColor = System.Drawing.Color.White;
            this.disconnectButton.Location = new System.Drawing.Point(435, 42);
            this.disconnectButton.Name = "disconnectButton";
            this.disconnectButton.Size = new System.Drawing.Size(75, 23);
            this.disconnectButton.TabIndex = 17;
            this.disconnectButton.Text = "&Disconnect";
            this.disconnectButton.UseVisualStyleBackColor = true;
            this.disconnectButton.Click += new System.EventHandler(this.disconnectButton_Click);
            // 
            // connectButton
            // 
            this.connectButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.connectButton.ForeColor = System.Drawing.Color.White;
            this.connectButton.Location = new System.Drawing.Point(435, 12);
            this.connectButton.Name = "connectButton";
            this.connectButton.Size = new System.Drawing.Size(75, 23);
            this.connectButton.TabIndex = 16;
            this.connectButton.Text = "&Connect";
            this.connectButton.UseVisualStyleBackColor = true;
            this.connectButton.Click += new System.EventHandler(this.connectButton_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(210, 45);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "Snapshot resoluton:";
            // 
            // snapshotResolutionsCombo
            // 
            this.snapshotResolutionsCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.snapshotResolutionsCombo.FormattingEnabled = true;
            this.snapshotResolutionsCombo.Location = new System.Drawing.Point(315, 42);
            this.snapshotResolutionsCombo.Name = "snapshotResolutionsCombo";
            this.snapshotResolutionsCombo.Size = new System.Drawing.Size(100, 21);
            this.snapshotResolutionsCombo.TabIndex = 14;
            // 
            // videoResolutionsCombo
            // 
            this.videoResolutionsCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.videoResolutionsCombo.FormattingEnabled = true;
            this.videoResolutionsCombo.Location = new System.Drawing.Point(100, 42);
            this.videoResolutionsCombo.Name = "videoResolutionsCombo";
            this.videoResolutionsCombo.Size = new System.Drawing.Size(100, 21);
            this.videoResolutionsCombo.TabIndex = 13;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(15, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Video resoluton:";
            // 
            // devicesCombo
            // 
            this.devicesCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.devicesCombo.FormattingEnabled = true;
            this.devicesCombo.Location = new System.Drawing.Point(100, 12);
            this.devicesCombo.Name = "devicesCombo";
            this.devicesCombo.Size = new System.Drawing.Size(315, 21);
            this.devicesCombo.TabIndex = 11;
            this.devicesCombo.SelectedValueChanged += new System.EventHandler(this.devicesCombo_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(15, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Video devices:";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(40)))));
            this.pictureBox1.Location = new System.Drawing.Point(5, 5);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(640, 480);
            this.pictureBox1.TabIndex = 20;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(516, 220);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(145, 54);
            this.button1.TabIndex = 21;
            this.button1.Text = "Save bachground";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(40)))));
            this.pictureBox2.Location = new System.Drawing.Point(5, 5);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(640, 480);
            this.pictureBox2.TabIndex = 22;
            this.pictureBox2.TabStop = false;
            // 
            // button2
            // 
            this.button2.Enabled = false;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(516, 280);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(145, 54);
            this.button2.TabIndex = 23;
            this.button2.Text = "Recognize";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(5, 400);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(660, 519);
            this.tabControl1.TabIndex = 24;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(40)))));
            this.tabPage1.Controls.Add(this.pictureBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(652, 493);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Original image";
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(40)))));
            this.tabPage2.Controls.Add(this.pictureBox2);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(652, 493);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Recognition";
            // 
            // button3
            // 
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.ForeColor = System.Drawing.Color.White;
            this.button3.Location = new System.Drawing.Point(516, 340);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(145, 54);
            this.button3.TabIndex = 25;
            this.button3.Text = "Set work zone";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // btnMoveRobotHome
            // 
            this.btnMoveRobotHome.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMoveRobotHome.ForeColor = System.Drawing.Color.White;
            this.btnMoveRobotHome.Location = new System.Drawing.Point(811, 13);
            this.btnMoveRobotHome.Name = "btnMoveRobotHome";
            this.btnMoveRobotHome.Size = new System.Drawing.Size(131, 54);
            this.btnMoveRobotHome.TabIndex = 70;
            this.btnMoveRobotHome.Text = "Move Robot Home";
            this.btnMoveRobotHome.UseVisualStyleBackColor = true;
            this.btnMoveRobotHome.Click += new System.EventHandler(this.btnMoveRobotHome_Click);
            // 
            // groupRunMode
            // 
            this.groupRunMode.Controls.Add(this.btnOLPdone);
            this.groupRunMode.Controls.Add(this.rad_RunMode_Simulation);
            this.groupRunMode.Controls.Add(this.rad_RunMode_Online);
            this.groupRunMode.Controls.Add(this.rad_RunMode_Program);
            this.groupRunMode.ForeColor = System.Drawing.Color.White;
            this.groupRunMode.Location = new System.Drawing.Point(671, 72);
            this.groupRunMode.Name = "groupRunMode";
            this.groupRunMode.Size = new System.Drawing.Size(271, 77);
            this.groupRunMode.TabIndex = 69;
            this.groupRunMode.TabStop = false;
            this.groupRunMode.Text = "Run Mode";
            // 
            // btnOLPdone
            // 
            this.btnOLPdone.Location = new System.Drawing.Point(140, 42);
            this.btnOLPdone.Name = "btnOLPdone";
            this.btnOLPdone.Size = new System.Drawing.Size(119, 23);
            this.btnOLPdone.TabIndex = 0;
            this.btnOLPdone.Text = "Generate Prog";
            this.btnOLPdone.Click += new System.EventHandler(this.btnOLPdone_Click);
            // 
            // rad_RunMode_Simulation
            // 
            this.rad_RunMode_Simulation.AutoSize = true;
            this.rad_RunMode_Simulation.ForeColor = System.Drawing.Color.White;
            this.rad_RunMode_Simulation.Location = new System.Drawing.Point(7, 21);
            this.rad_RunMode_Simulation.Name = "rad_RunMode_Simulation";
            this.rad_RunMode_Simulation.Size = new System.Drawing.Size(73, 17);
            this.rad_RunMode_Simulation.TabIndex = 49;
            this.rad_RunMode_Simulation.TabStop = true;
            this.rad_RunMode_Simulation.Text = "Simulation";
            this.rad_RunMode_Simulation.UseVisualStyleBackColor = true;
            this.rad_RunMode_Simulation.CheckedChanged += new System.EventHandler(this.rad_RunMode_Simulation_CheckedChanged);
            // 
            // rad_RunMode_Online
            // 
            this.rad_RunMode_Online.AutoSize = true;
            this.rad_RunMode_Online.ForeColor = System.Drawing.Color.White;
            this.rad_RunMode_Online.Location = new System.Drawing.Point(6, 44);
            this.rad_RunMode_Online.Name = "rad_RunMode_Online";
            this.rad_RunMode_Online.Size = new System.Drawing.Size(94, 17);
            this.rad_RunMode_Online.TabIndex = 47;
            this.rad_RunMode_Online.TabStop = true;
            this.rad_RunMode_Online.Text = "Run On Robot";
            this.rad_RunMode_Online.UseVisualStyleBackColor = true;
            this.rad_RunMode_Online.CheckedChanged += new System.EventHandler(this.rad_RunMode_Online_CheckedChanged);
            // 
            // rad_RunMode_Program
            // 
            this.rad_RunMode_Program.AutoSize = true;
            this.rad_RunMode_Program.ForeColor = System.Drawing.Color.White;
            this.rad_RunMode_Program.Location = new System.Drawing.Point(140, 17);
            this.rad_RunMode_Program.Name = "rad_RunMode_Program";
            this.rad_RunMode_Program.Size = new System.Drawing.Size(119, 17);
            this.rad_RunMode_Program.TabIndex = 48;
            this.rad_RunMode_Program.TabStop = true;
            this.rad_RunMode_Program.Text = "Offline Programming";
            this.rad_RunMode_Program.UseVisualStyleBackColor = true;
            this.rad_RunMode_Program.CheckedChanged += new System.EventHandler(this.rad_RunMode_Program_CheckedChanged);
            // 
            // groupIncrementalMove
            // 
            this.groupIncrementalMove.Controls.Add(this.btnTXneg);
            this.groupIncrementalMove.Controls.Add(this.numStep);
            this.groupIncrementalMove.Controls.Add(this.lblstepIncrement);
            this.groupIncrementalMove.Controls.Add(this.rad_Move_Joints);
            this.groupIncrementalMove.Controls.Add(this.rad_Move_wrt_Tool);
            this.groupIncrementalMove.Controls.Add(this.rad_Move_wrt_Reference);
            this.groupIncrementalMove.Controls.Add(this.btnTXpos);
            this.groupIncrementalMove.Controls.Add(this.btnTYneg);
            this.groupIncrementalMove.Controls.Add(this.btnTYpos);
            this.groupIncrementalMove.Controls.Add(this.btnRZpos);
            this.groupIncrementalMove.Controls.Add(this.btnTZneg);
            this.groupIncrementalMove.Controls.Add(this.btnRZneg);
            this.groupIncrementalMove.Controls.Add(this.btnTZpos);
            this.groupIncrementalMove.Controls.Add(this.btnRYpos);
            this.groupIncrementalMove.Controls.Add(this.btnRXneg);
            this.groupIncrementalMove.Controls.Add(this.btnRYneg);
            this.groupIncrementalMove.Controls.Add(this.btnRXpos);
            this.groupIncrementalMove.ForeColor = System.Drawing.Color.White;
            this.groupIncrementalMove.Location = new System.Drawing.Point(948, 10);
            this.groupIncrementalMove.Name = "groupIncrementalMove";
            this.groupIncrementalMove.Size = new System.Drawing.Size(351, 237);
            this.groupIncrementalMove.TabIndex = 68;
            this.groupIncrementalMove.TabStop = false;
            this.groupIncrementalMove.Text = "Incremental Move";
            // 
            // btnTXneg
            // 
            this.btnTXneg.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTXneg.ForeColor = System.Drawing.Color.White;
            this.btnTXneg.Location = new System.Drawing.Point(175, 10);
            this.btnTXneg.Margin = new System.Windows.Forms.Padding(1);
            this.btnTXneg.Name = "btnTXneg";
            this.btnTXneg.Size = new System.Drawing.Size(67, 23);
            this.btnTXneg.TabIndex = 49;
            this.btnTXneg.Text = "X-";
            this.btnTXneg.UseVisualStyleBackColor = true;
            this.btnTXneg.Click += new System.EventHandler(this.btnTXneg_Click);
            // 
            // numStep
            // 
            this.numStep.DecimalPlaces = 1;
            this.numStep.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numStep.Location = new System.Drawing.Point(73, 77);
            this.numStep.Maximum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.numStep.Name = "numStep";
            this.numStep.Size = new System.Drawing.Size(70, 20);
            this.numStep.TabIndex = 48;
            // 
            // lblstepIncrement
            // 
            this.lblstepIncrement.AutoSize = true;
            this.lblstepIncrement.ForeColor = System.Drawing.Color.White;
            this.lblstepIncrement.Location = new System.Drawing.Point(6, 81);
            this.lblstepIncrement.Name = "lblstepIncrement";
            this.lblstepIncrement.Size = new System.Drawing.Size(57, 13);
            this.lblstepIncrement.TabIndex = 47;
            this.lblstepIncrement.Text = "Step (mm):";
            // 
            // rad_Move_Joints
            // 
            this.rad_Move_Joints.AutoSize = true;
            this.rad_Move_Joints.ForeColor = System.Drawing.Color.White;
            this.rad_Move_Joints.Location = new System.Drawing.Point(11, 57);
            this.rad_Move_Joints.Name = "rad_Move_Joints";
            this.rad_Move_Joints.Size = new System.Drawing.Size(77, 17);
            this.rad_Move_Joints.TabIndex = 2;
            this.rad_Move_Joints.TabStop = true;
            this.rad_Move_Joints.Text = "Joint Move";
            this.rad_Move_Joints.UseVisualStyleBackColor = true;
            this.rad_Move_Joints.CheckedChanged += new System.EventHandler(this.rad_Move_Joints_CheckedChanged);
            // 
            // rad_Move_wrt_Tool
            // 
            this.rad_Move_wrt_Tool.AutoSize = true;
            this.rad_Move_wrt_Tool.ForeColor = System.Drawing.Color.White;
            this.rad_Move_wrt_Tool.Location = new System.Drawing.Point(11, 37);
            this.rad_Move_wrt_Tool.Name = "rad_Move_wrt_Tool";
            this.rad_Move_wrt_Tool.Size = new System.Drawing.Size(46, 17);
            this.rad_Move_wrt_Tool.TabIndex = 1;
            this.rad_Move_wrt_Tool.TabStop = true;
            this.rad_Move_wrt_Tool.Text = "Tool";
            this.rad_Move_wrt_Tool.UseVisualStyleBackColor = true;
            this.rad_Move_wrt_Tool.CheckedChanged += new System.EventHandler(this.rad_Move_wrt_Tool_CheckedChanged);
            // 
            // rad_Move_wrt_Reference
            // 
            this.rad_Move_wrt_Reference.AutoSize = true;
            this.rad_Move_wrt_Reference.ForeColor = System.Drawing.Color.White;
            this.rad_Move_wrt_Reference.Location = new System.Drawing.Point(11, 17);
            this.rad_Move_wrt_Reference.Name = "rad_Move_wrt_Reference";
            this.rad_Move_wrt_Reference.Size = new System.Drawing.Size(75, 17);
            this.rad_Move_wrt_Reference.TabIndex = 0;
            this.rad_Move_wrt_Reference.TabStop = true;
            this.rad_Move_wrt_Reference.Text = "Reference";
            this.rad_Move_wrt_Reference.UseVisualStyleBackColor = true;
            this.rad_Move_wrt_Reference.CheckedChanged += new System.EventHandler(this.rad_Move_wrt_Reference_CheckedChanged);
            // 
            // btnTXpos
            // 
            this.btnTXpos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTXpos.ForeColor = System.Drawing.Color.White;
            this.btnTXpos.Location = new System.Drawing.Point(271, 10);
            this.btnTXpos.Margin = new System.Windows.Forms.Padding(1);
            this.btnTXpos.Name = "btnTXpos";
            this.btnTXpos.Size = new System.Drawing.Size(67, 23);
            this.btnTXpos.TabIndex = 28;
            this.btnTXpos.Text = "X+";
            this.btnTXpos.UseVisualStyleBackColor = true;
            this.btnTXpos.Click += new System.EventHandler(this.btnTXpos_Click);
            // 
            // btnTYneg
            // 
            this.btnTYneg.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTYneg.ForeColor = System.Drawing.Color.White;
            this.btnTYneg.Location = new System.Drawing.Point(174, 50);
            this.btnTYneg.Margin = new System.Windows.Forms.Padding(1);
            this.btnTYneg.Name = "btnTYneg";
            this.btnTYneg.Size = new System.Drawing.Size(67, 23);
            this.btnTYneg.TabIndex = 29;
            this.btnTYneg.Text = "Y-";
            this.btnTYneg.UseVisualStyleBackColor = true;
            this.btnTYneg.Click += new System.EventHandler(this.btnTYneg_Click);
            // 
            // btnTYpos
            // 
            this.btnTYpos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTYpos.ForeColor = System.Drawing.Color.White;
            this.btnTYpos.Location = new System.Drawing.Point(271, 50);
            this.btnTYpos.Margin = new System.Windows.Forms.Padding(1);
            this.btnTYpos.Name = "btnTYpos";
            this.btnTYpos.Size = new System.Drawing.Size(67, 23);
            this.btnTYpos.TabIndex = 30;
            this.btnTYpos.Text = "Y+";
            this.btnTYpos.UseVisualStyleBackColor = true;
            this.btnTYpos.Click += new System.EventHandler(this.btnTYpos_Click);
            // 
            // btnRZpos
            // 
            this.btnRZpos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRZpos.ForeColor = System.Drawing.Color.White;
            this.btnRZpos.Location = new System.Drawing.Point(271, 210);
            this.btnRZpos.Margin = new System.Windows.Forms.Padding(1);
            this.btnRZpos.Name = "btnRZpos";
            this.btnRZpos.Size = new System.Drawing.Size(67, 23);
            this.btnRZpos.TabIndex = 38;
            this.btnRZpos.Text = "rZ+";
            this.btnRZpos.UseVisualStyleBackColor = true;
            this.btnRZpos.Click += new System.EventHandler(this.btnRZpos_Click);
            // 
            // btnTZneg
            // 
            this.btnTZneg.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTZneg.ForeColor = System.Drawing.Color.White;
            this.btnTZneg.Location = new System.Drawing.Point(174, 90);
            this.btnTZneg.Margin = new System.Windows.Forms.Padding(1);
            this.btnTZneg.Name = "btnTZneg";
            this.btnTZneg.Size = new System.Drawing.Size(67, 23);
            this.btnTZneg.TabIndex = 31;
            this.btnTZneg.Text = "Z-";
            this.btnTZneg.UseVisualStyleBackColor = true;
            this.btnTZneg.Click += new System.EventHandler(this.btnTZneg_Click);
            // 
            // btnRZneg
            // 
            this.btnRZneg.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRZneg.ForeColor = System.Drawing.Color.White;
            this.btnRZneg.Location = new System.Drawing.Point(174, 210);
            this.btnRZneg.Margin = new System.Windows.Forms.Padding(1);
            this.btnRZneg.Name = "btnRZneg";
            this.btnRZneg.Size = new System.Drawing.Size(67, 23);
            this.btnRZneg.TabIndex = 37;
            this.btnRZneg.Text = "rZ-";
            this.btnRZneg.UseVisualStyleBackColor = true;
            this.btnRZneg.Click += new System.EventHandler(this.btnRZneg_Click);
            // 
            // btnTZpos
            // 
            this.btnTZpos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTZpos.ForeColor = System.Drawing.Color.White;
            this.btnTZpos.Location = new System.Drawing.Point(271, 90);
            this.btnTZpos.Margin = new System.Windows.Forms.Padding(1);
            this.btnTZpos.Name = "btnTZpos";
            this.btnTZpos.Size = new System.Drawing.Size(67, 23);
            this.btnTZpos.TabIndex = 32;
            this.btnTZpos.Text = "Z+";
            this.btnTZpos.UseVisualStyleBackColor = true;
            this.btnTZpos.Click += new System.EventHandler(this.btnTZpos_Click);
            // 
            // btnRYpos
            // 
            this.btnRYpos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRYpos.ForeColor = System.Drawing.Color.White;
            this.btnRYpos.Location = new System.Drawing.Point(271, 170);
            this.btnRYpos.Margin = new System.Windows.Forms.Padding(1);
            this.btnRYpos.Name = "btnRYpos";
            this.btnRYpos.Size = new System.Drawing.Size(67, 23);
            this.btnRYpos.TabIndex = 36;
            this.btnRYpos.Text = "rY+";
            this.btnRYpos.UseVisualStyleBackColor = true;
            this.btnRYpos.Click += new System.EventHandler(this.btnRYpos_Click);
            // 
            // btnRXneg
            // 
            this.btnRXneg.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRXneg.ForeColor = System.Drawing.Color.White;
            this.btnRXneg.Location = new System.Drawing.Point(174, 130);
            this.btnRXneg.Margin = new System.Windows.Forms.Padding(1);
            this.btnRXneg.Name = "btnRXneg";
            this.btnRXneg.Size = new System.Drawing.Size(67, 23);
            this.btnRXneg.TabIndex = 33;
            this.btnRXneg.Text = "rX-";
            this.btnRXneg.UseVisualStyleBackColor = true;
            this.btnRXneg.Click += new System.EventHandler(this.btnRXneg_Click);
            // 
            // btnRYneg
            // 
            this.btnRYneg.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRYneg.ForeColor = System.Drawing.Color.White;
            this.btnRYneg.Location = new System.Drawing.Point(174, 170);
            this.btnRYneg.Margin = new System.Windows.Forms.Padding(1);
            this.btnRYneg.Name = "btnRYneg";
            this.btnRYneg.Size = new System.Drawing.Size(67, 23);
            this.btnRYneg.TabIndex = 35;
            this.btnRYneg.Text = "rY-";
            this.btnRYneg.UseVisualStyleBackColor = true;
            this.btnRYneg.Click += new System.EventHandler(this.btnRYneg_Click);
            // 
            // btnRXpos
            // 
            this.btnRXpos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRXpos.ForeColor = System.Drawing.Color.White;
            this.btnRXpos.Location = new System.Drawing.Point(271, 130);
            this.btnRXpos.Margin = new System.Windows.Forms.Padding(1);
            this.btnRXpos.Name = "btnRXpos";
            this.btnRXpos.Size = new System.Drawing.Size(67, 23);
            this.btnRXpos.TabIndex = 34;
            this.btnRXpos.Text = "rX+";
            this.btnRXpos.UseVisualStyleBackColor = true;
            this.btnRXpos.Click += new System.EventHandler(this.btnRXpos_Click);
            // 
            // btnRunTestProgram
            // 
            this.btnRunTestProgram.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRunTestProgram.ForeColor = System.Drawing.Color.White;
            this.btnRunTestProgram.Location = new System.Drawing.Point(671, 45);
            this.btnRunTestProgram.Name = "btnRunTestProgram";
            this.btnRunTestProgram.Size = new System.Drawing.Size(136, 22);
            this.btnRunTestProgram.TabIndex = 65;
            this.btnRunTestProgram.Text = "Run Test Program";
            this.btnRunTestProgram.UseVisualStyleBackColor = true;
            this.btnRunTestProgram.Click += new System.EventHandler(this.btnRunTestProgram_Click);
            // 
            // btnSelectStation
            // 
            this.btnSelectStation.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSelectStation.ForeColor = System.Drawing.Color.White;
            this.btnSelectStation.Location = new System.Drawing.Point(671, 13);
            this.btnSelectStation.Margin = new System.Windows.Forms.Padding(1);
            this.btnSelectStation.Name = "btnSelectStation";
            this.btnSelectStation.Size = new System.Drawing.Size(136, 28);
            this.btnSelectStation.TabIndex = 64;
            this.btnSelectStation.Text = "Load File";
            this.btnSelectStation.UseVisualStyleBackColor = true;
            this.btnSelectStation.Click += new System.EventHandler(this.btnLoadFile_Click);
            // 
            // btnMoveJoints
            // 
            this.btnMoveJoints.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMoveJoints.ForeColor = System.Drawing.Color.White;
            this.btnMoveJoints.Location = new System.Drawing.Point(841, 153);
            this.btnMoveJoints.Margin = new System.Windows.Forms.Padding(1);
            this.btnMoveJoints.Name = "btnMoveJoints";
            this.btnMoveJoints.Size = new System.Drawing.Size(101, 21);
            this.btnMoveJoints.TabIndex = 59;
            this.btnMoveJoints.Text = "Move to Joints";
            this.btnMoveJoints.UseVisualStyleBackColor = true;
            this.btnMoveJoints.Click += new System.EventHandler(this.btnMoveJoints_Click);
            // 
            // txtJoints
            // 
            this.txtJoints.Location = new System.Drawing.Point(751, 175);
            this.txtJoints.Margin = new System.Windows.Forms.Padding(1);
            this.txtJoints.Name = "txtJoints";
            this.txtJoints.Size = new System.Drawing.Size(191, 20);
            this.txtJoints.TabIndex = 58;
            this.txtJoints.Text = "90 , -90 , 90 , 90 , 90 , -90";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(748, 157);
            this.label5.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 13);
            this.label5.TabIndex = 57;
            this.label5.Text = "Joint Values";
            // 
            // btnMovePose
            // 
            this.btnMovePose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMovePose.ForeColor = System.Drawing.Color.White;
            this.btnMovePose.Location = new System.Drawing.Point(841, 204);
            this.btnMovePose.Margin = new System.Windows.Forms.Padding(1);
            this.btnMovePose.Name = "btnMovePose";
            this.btnMovePose.Size = new System.Drawing.Size(101, 21);
            this.btnMovePose.TabIndex = 56;
            this.btnMovePose.Text = "Move to Position";
            this.btnMovePose.UseVisualStyleBackColor = true;
            this.btnMovePose.Click += new System.EventHandler(this.btnMovePose_Click);
            // 
            // btnGetJoints
            // 
            this.btnGetJoints.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGetJoints.ForeColor = System.Drawing.Color.White;
            this.btnGetJoints.Location = new System.Drawing.Point(671, 154);
            this.btnGetJoints.Margin = new System.Windows.Forms.Padding(1);
            this.btnGetJoints.Name = "btnGetJoints";
            this.btnGetJoints.Size = new System.Drawing.Size(75, 93);
            this.btnGetJoints.TabIndex = 55;
            this.btnGetJoints.Text = "Read Current Position";
            this.btnGetJoints.UseVisualStyleBackColor = true;
            this.btnGetJoints.Click += new System.EventHandler(this.btnGetJoints_Click);
            // 
            // txtPosition
            // 
            this.txtPosition.Location = new System.Drawing.Point(751, 227);
            this.txtPosition.Margin = new System.Windows.Forms.Padding(1);
            this.txtPosition.Name = "txtPosition";
            this.txtPosition.Size = new System.Drawing.Size(191, 20);
            this.txtPosition.TabIndex = 54;
            this.txtPosition.Text = "0 , -90 , 90 , 0 , 90 , 90";
            // 
            // lblJ1
            // 
            this.lblJ1.AutoSize = true;
            this.lblJ1.ForeColor = System.Drawing.Color.White;
            this.lblJ1.Location = new System.Drawing.Point(748, 208);
            this.lblJ1.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.lblJ1.Name = "lblJ1";
            this.lblJ1.Size = new System.Drawing.Size(91, 13);
            this.lblJ1.TabIndex = 53;
            this.lblJ1.Text = "Cartesian Position";
            // 
            // panel_rdk
            // 
            this.panel_rdk.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel_rdk.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel_rdk.BackColor = System.Drawing.Color.Transparent;
            this.panel_rdk.Location = new System.Drawing.Point(671, 253);
            this.panel_rdk.Name = "panel_rdk";
            this.panel_rdk.Size = new System.Drawing.Size(640, 658);
            this.panel_rdk.TabIndex = 71;
            this.panel_rdk.Paint += new System.Windows.Forms.PaintEventHandler(this.panel_rdk_Paint);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.notifybar});
            this.statusStrip1.Location = new System.Drawing.Point(0, 914);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1311, 22);
            this.statusStrip1.TabIndex = 72;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // notifybar
            // 
            this.notifybar.ForeColor = System.Drawing.Color.White;
            this.notifybar.Name = "notifybar";
            this.notifybar.Size = new System.Drawing.Size(95, 17);
            this.notifybar.Text = "Notification area";
            // 
            // button4
            // 
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.ForeColor = System.Drawing.Color.White;
            this.button4.Location = new System.Drawing.Point(516, 12);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(145, 202);
            this.button4.TabIndex = 73;
            this.button4.Text = "Load RoboDK API";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(40)))));
            this.ClientSize = new System.Drawing.Size(1311, 936);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.btnMoveRobotHome);
            this.Controls.Add(this.groupRunMode);
            this.Controls.Add(this.groupIncrementalMove);
            this.Controls.Add(this.btnRunTestProgram);
            this.Controls.Add(this.btnSelectStation);
            this.Controls.Add(this.btnMoveJoints);
            this.Controls.Add(this.txtJoints);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnMovePose);
            this.Controls.Add(this.btnGetJoints);
            this.Controls.Add(this.txtPosition);
            this.Controls.Add(this.lblJ1);
            this.Controls.Add(this.panel_rdk);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.triggerButton);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.disconnectButton);
            this.Controls.Add(this.connectButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.snapshotResolutionsCombo);
            this.Controls.Add(this.videoResolutionsCombo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.devicesCombo);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Lotus";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormRobot_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Shown += new System.EventHandler(this.Form1_Shown);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.groupRunMode.ResumeLayout(false);
            this.groupRunMode.PerformLayout();
            this.groupIncrementalMove.ResumeLayout(false);
            this.groupIncrementalMove.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numStep)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button triggerButton;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button disconnectButton;
        private System.Windows.Forms.Button connectButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox snapshotResolutionsCombo;
        private System.Windows.Forms.ComboBox videoResolutionsCombo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox devicesCombo;
        private System.Windows.Forms.Label label1;
        private AForge.Controls.VideoSourcePlayer videoSourcePlayer;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button button3;

        private System.Windows.Forms.Button btnMoveRobotHome;
        private System.Windows.Forms.GroupBox groupRunMode;
        private System.Windows.Forms.Button btnOLPdone;
        private System.Windows.Forms.RadioButton rad_RunMode_Simulation;
        private System.Windows.Forms.RadioButton rad_RunMode_Online;
        private System.Windows.Forms.RadioButton rad_RunMode_Program;
        private System.Windows.Forms.GroupBox groupIncrementalMove;
        private System.Windows.Forms.NumericUpDown numStep;
        private System.Windows.Forms.Label lblstepIncrement;
        private System.Windows.Forms.RadioButton rad_Move_Joints;
        private System.Windows.Forms.RadioButton rad_Move_wrt_Tool;
        private System.Windows.Forms.RadioButton rad_Move_wrt_Reference;
        private System.Windows.Forms.Button btnTXpos;
        private System.Windows.Forms.Button btnTYneg;
        private System.Windows.Forms.Button btnTYpos;
        private System.Windows.Forms.Button btnRZpos;
        private System.Windows.Forms.Button btnTZneg;
        private System.Windows.Forms.Button btnRZneg;
        private System.Windows.Forms.Button btnTZpos;
        private System.Windows.Forms.Button btnRYpos;
        private System.Windows.Forms.Button btnRXneg;
        private System.Windows.Forms.Button btnRYneg;
        private System.Windows.Forms.Button btnRXpos;
        private System.Windows.Forms.Button btnRunTestProgram;
        private System.Windows.Forms.Button btnSelectStation;
        private System.Windows.Forms.Button btnMoveJoints;
        private System.Windows.Forms.TextBox txtJoints;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnMovePose;
        private System.Windows.Forms.Button btnGetJoints;
        private System.Windows.Forms.TextBox txtPosition;
        private System.Windows.Forms.Label lblJ1;
        private System.Windows.Forms.Panel panel_rdk;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel notifybar;
        private System.Windows.Forms.Button btnTXneg;
        private System.Windows.Forms.Button button4;
    }
}

