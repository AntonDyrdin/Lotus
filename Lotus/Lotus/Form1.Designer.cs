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
            this.components = new System.ComponentModel.Container();
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
            this.btnMovePose = new System.Windows.Forms.Button();
            this.btnGetJoints = new System.Windows.Forms.Button();
            this.txtPosition = new System.Windows.Forms.TextBox();
            this.lblJ1 = new System.Windows.Forms.Label();
            this.panel_rdk = new System.Windows.Forms.Panel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.notifybar = new System.Windows.Forms.ToolStripStatusLabel();
            this.button4 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButton4 = new System.Windows.Forms.RadioButton();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.label21 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.textBox11 = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.textBox9 = new System.Windows.Forms.TextBox();
            this.textBox10 = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.textBox8 = new System.Windows.Forms.TextBox();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.button5 = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.label10 = new System.Windows.Forms.Label();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
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
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // triggerButton
            // 
            this.triggerButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.triggerButton.ForeColor = System.Drawing.Color.White;
            this.triggerButton.Location = new System.Drawing.Point(261, 72);
            this.triggerButton.Name = "triggerButton";
            this.triggerButton.Size = new System.Drawing.Size(249, 23);
            this.triggerButton.TabIndex = 19;
            this.triggerButton.Text = "Trigger";
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
            this.videoSourcePlayer.ForeColor = System.Drawing.Color.Lime;
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
            this.disconnectButton.Location = new System.Drawing.Point(408, 42);
            this.disconnectButton.Name = "disconnectButton";
            this.disconnectButton.Size = new System.Drawing.Size(102, 23);
            this.disconnectButton.TabIndex = 17;
            this.disconnectButton.Text = "Disconnect";
            this.disconnectButton.UseVisualStyleBackColor = true;
            this.disconnectButton.Click += new System.EventHandler(this.disconnectButton_Click);
            // 
            // connectButton
            // 
            this.connectButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.connectButton.ForeColor = System.Drawing.Color.White;
            this.connectButton.Location = new System.Drawing.Point(408, 12);
            this.connectButton.Name = "connectButton";
            this.connectButton.Size = new System.Drawing.Size(102, 23);
            this.connectButton.TabIndex = 16;
            this.connectButton.Text = "Connect";
            this.connectButton.UseVisualStyleBackColor = true;
            this.connectButton.Click += new System.EventHandler(this.connectButton_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(197, 45);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "Snapshot resoluton:";
            // 
            // snapshotResolutionsCombo
            // 
            this.snapshotResolutionsCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.snapshotResolutionsCombo.FormattingEnabled = true;
            this.snapshotResolutionsCombo.Location = new System.Drawing.Point(302, 42);
            this.snapshotResolutionsCombo.Name = "snapshotResolutionsCombo";
            this.snapshotResolutionsCombo.Size = new System.Drawing.Size(100, 21);
            this.snapshotResolutionsCombo.TabIndex = 14;
            // 
            // videoResolutionsCombo
            // 
            this.videoResolutionsCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.videoResolutionsCombo.FormattingEnabled = true;
            this.videoResolutionsCombo.Location = new System.Drawing.Point(87, 42);
            this.videoResolutionsCombo.Name = "videoResolutionsCombo";
            this.videoResolutionsCombo.Size = new System.Drawing.Size(100, 21);
            this.videoResolutionsCombo.TabIndex = 13;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(2, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Video resoluton:";
            // 
            // devicesCombo
            // 
            this.devicesCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.devicesCombo.FormattingEnabled = true;
            this.devicesCombo.Location = new System.Drawing.Point(87, 12);
            this.devicesCombo.Name = "devicesCombo";
            this.devicesCombo.Size = new System.Drawing.Size(315, 21);
            this.devicesCombo.TabIndex = 11;
            this.devicesCombo.SelectedValueChanged += new System.EventHandler(this.devicesCombo_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(2, 15);
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
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(40)))));
            this.pictureBox2.Location = new System.Drawing.Point(5, 5);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(640, 480);
            this.pictureBox2.TabIndex = 22;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // button2
            // 
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(519, 253);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(74, 38);
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
            this.tabPage1.Text = "Recognition";
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
            this.tabPage2.Text = "Original image";
            // 
            // button3
            // 
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.ForeColor = System.Drawing.Color.White;
            this.button3.Location = new System.Drawing.Point(602, 253);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(63, 38);
            this.button3.TabIndex = 25;
            this.button3.Text = "Set work zone";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // btnMoveRobotHome
            // 
            this.btnMoveRobotHome.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMoveRobotHome.ForeColor = System.Drawing.Color.White;
            this.btnMoveRobotHome.Location = new System.Drawing.Point(659, 12);
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
            this.groupRunMode.Location = new System.Drawing.Point(519, 71);
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
            this.groupIncrementalMove.Location = new System.Drawing.Point(796, 9);
            this.groupIncrementalMove.Name = "groupIncrementalMove";
            this.groupIncrementalMove.Size = new System.Drawing.Size(144, 237);
            this.groupIncrementalMove.TabIndex = 68;
            this.groupIncrementalMove.TabStop = false;
            this.groupIncrementalMove.Text = "Incremental Move";
            // 
            // btnTXneg
            // 
            this.btnTXneg.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTXneg.ForeColor = System.Drawing.Color.White;
            this.btnTXneg.Location = new System.Drawing.Point(4, 77);
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
            this.numStep.Location = new System.Drawing.Point(73, 53);
            this.numStep.Maximum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.numStep.Name = "numStep";
            this.numStep.Size = new System.Drawing.Size(67, 20);
            this.numStep.TabIndex = 48;
            // 
            // lblstepIncrement
            // 
            this.lblstepIncrement.AutoSize = true;
            this.lblstepIncrement.ForeColor = System.Drawing.Color.White;
            this.lblstepIncrement.Location = new System.Drawing.Point(10, 60);
            this.lblstepIncrement.Name = "lblstepIncrement";
            this.lblstepIncrement.Size = new System.Drawing.Size(57, 13);
            this.lblstepIncrement.TabIndex = 47;
            this.lblstepIncrement.Text = "Step (mm):";
            // 
            // rad_Move_Joints
            // 
            this.rad_Move_Joints.AutoSize = true;
            this.rad_Move_Joints.ForeColor = System.Drawing.Color.White;
            this.rad_Move_Joints.Location = new System.Drawing.Point(6, 33);
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
            this.rad_Move_wrt_Tool.Location = new System.Drawing.Point(6, 16);
            this.rad_Move_wrt_Tool.Name = "rad_Move_wrt_Tool";
            this.rad_Move_wrt_Tool.Size = new System.Drawing.Size(46, 17);
            this.rad_Move_wrt_Tool.TabIndex = 1;
            this.rad_Move_wrt_Tool.TabStop = true;
            this.rad_Move_wrt_Tool.Text = "Tool";
            this.rad_Move_wrt_Tool.UseVisualStyleBackColor = true;
            this.rad_Move_wrt_Tool.CheckedChanged += new System.EventHandler(this.rad_Move_wrt_Tool_CheckedChanged);
            // 
            // btnTXpos
            // 
            this.btnTXpos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTXpos.ForeColor = System.Drawing.Color.White;
            this.btnTXpos.Location = new System.Drawing.Point(73, 77);
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
            this.btnTYneg.Location = new System.Drawing.Point(4, 104);
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
            this.btnTYpos.Location = new System.Drawing.Point(73, 104);
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
            this.btnRZpos.Location = new System.Drawing.Point(73, 208);
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
            this.btnTZneg.Location = new System.Drawing.Point(4, 130);
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
            this.btnRZneg.Location = new System.Drawing.Point(4, 208);
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
            this.btnTZpos.Location = new System.Drawing.Point(73, 129);
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
            this.btnRYpos.Location = new System.Drawing.Point(73, 183);
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
            this.btnRXneg.Location = new System.Drawing.Point(4, 158);
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
            this.btnRYneg.Location = new System.Drawing.Point(4, 183);
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
            this.btnRXpos.Location = new System.Drawing.Point(73, 158);
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
            this.btnRunTestProgram.Location = new System.Drawing.Point(519, 44);
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
            this.btnSelectStation.Location = new System.Drawing.Point(519, 12);
            this.btnSelectStation.Margin = new System.Windows.Forms.Padding(1);
            this.btnSelectStation.Name = "btnSelectStation";
            this.btnSelectStation.Size = new System.Drawing.Size(136, 28);
            this.btnSelectStation.TabIndex = 64;
            this.btnSelectStation.Text = "Load File";
            this.btnSelectStation.UseVisualStyleBackColor = true;
            this.btnSelectStation.Click += new System.EventHandler(this.btnLoadFile_Click);
            // 
            // btnMovePose
            // 
            this.btnMovePose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMovePose.ForeColor = System.Drawing.Color.White;
            this.btnMovePose.Location = new System.Drawing.Point(519, 152);
            this.btnMovePose.Margin = new System.Windows.Forms.Padding(1);
            this.btnMovePose.Name = "btnMovePose";
            this.btnMovePose.Size = new System.Drawing.Size(75, 38);
            this.btnMovePose.TabIndex = 56;
            this.btnMovePose.Text = "Move to Position";
            this.btnMovePose.UseVisualStyleBackColor = true;
            this.btnMovePose.Click += new System.EventHandler(this.btnMovePose_Click);
            // 
            // btnGetJoints
            // 
            this.btnGetJoints.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGetJoints.ForeColor = System.Drawing.Color.White;
            this.btnGetJoints.Location = new System.Drawing.Point(519, 192);
            this.btnGetJoints.Margin = new System.Windows.Forms.Padding(1);
            this.btnGetJoints.Name = "btnGetJoints";
            this.btnGetJoints.Size = new System.Drawing.Size(75, 54);
            this.btnGetJoints.TabIndex = 55;
            this.btnGetJoints.Text = "Read Current Position";
            this.btnGetJoints.UseVisualStyleBackColor = true;
            this.btnGetJoints.Click += new System.EventHandler(this.btnGetJoints_Click);
            // 
            // txtPosition
            // 
            this.txtPosition.Location = new System.Drawing.Point(601, 170);
            this.txtPosition.Margin = new System.Windows.Forms.Padding(1);
            this.txtPosition.Name = "txtPosition";
            this.txtPosition.Size = new System.Drawing.Size(191, 20);
            this.txtPosition.TabIndex = 54;
            this.txtPosition.Text = "0 , -90 , 90 , 0 , 90 , 90";
            // 
            // lblJ1
            // 
            this.lblJ1.AutoSize = true;
            this.lblJ1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblJ1.ForeColor = System.Drawing.Color.White;
            this.lblJ1.Location = new System.Drawing.Point(656, 151);
            this.lblJ1.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.lblJ1.Name = "lblJ1";
            this.lblJ1.Size = new System.Drawing.Size(74, 15);
            this.lblJ1.TabIndex = 53;
            this.lblJ1.Text = "x, y, z, a, b, c";
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
            this.panel_rdk.Size = new System.Drawing.Size(731, 658);
            this.panel_rdk.TabIndex = 71;
            this.panel_rdk.Paint += new System.Windows.Forms.PaintEventHandler(this.panel_rdk_Paint);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.notifybar});
            this.statusStrip1.Location = new System.Drawing.Point(0, 914);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1408, 22);
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
            this.button4.Location = new System.Drawing.Point(1305, 125);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(97, 122);
            this.button4.TabIndex = 73;
            this.button4.Text = "Load RoboDK API";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButton4);
            this.groupBox1.Controls.Add(this.radioButton3);
            this.groupBox1.Controls.Add(this.label21);
            this.groupBox1.Controls.Add(this.label20);
            this.groupBox1.Controls.Add(this.label19);
            this.groupBox1.Controls.Add(this.label18);
            this.groupBox1.Controls.Add(this.textBox11);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.textBox9);
            this.groupBox1.Controls.Add(this.textBox10);
            this.groupBox1.Controls.Add(this.label16);
            this.groupBox1.Controls.Add(this.label17);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.textBox8);
            this.groupBox1.Controls.Add(this.textBox7);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.textBox5);
            this.groupBox1.Controls.Add(this.button5);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.textBox4);
            this.groupBox1.Controls.Add(this.textBox3);
            this.groupBox1.Controls.Add(this.textBox2);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(958, 14);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(341, 232);
            this.groupBox1.TabIndex = 74;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Path and environment properties";
            // 
            // radioButton4
            // 
            this.radioButton4.AutoSize = true;
            this.radioButton4.Checked = true;
            this.radioButton4.ForeColor = System.Drawing.Color.White;
            this.radioButton4.Location = new System.Drawing.Point(170, 159);
            this.radioButton4.Name = "radioButton4";
            this.radioButton4.Size = new System.Drawing.Size(82, 17);
            this.radioButton4.TabIndex = 101;
            this.radioButton4.TabStop = true;
            this.radioButton4.Text = "Reconition2";
            this.radioButton4.UseVisualStyleBackColor = true;
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.ForeColor = System.Drawing.Color.White;
            this.radioButton3.Location = new System.Drawing.Point(82, 159);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(82, 17);
            this.radioButton3.TabIndex = 100;
            this.radioButton3.Text = "Reconition1";
            this.radioButton3.UseVisualStyleBackColor = true;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.ForeColor = System.Drawing.Color.White;
            this.label21.Location = new System.Drawing.Point(152, 104);
            this.label21.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(23, 13);
            this.label21.TabIndex = 99;
            this.label21.Text = "mm";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.ForeColor = System.Drawing.Color.White;
            this.label20.Location = new System.Drawing.Point(152, 78);
            this.label20.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(23, 13);
            this.label20.TabIndex = 98;
            this.label20.Text = "mm";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.ForeColor = System.Drawing.Color.White;
            this.label19.Location = new System.Drawing.Point(152, 131);
            this.label19.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(18, 13);
            this.label19.TabIndex = 97;
            this.label19.Text = "px";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.ForeColor = System.Drawing.Color.White;
            this.label18.Location = new System.Drawing.Point(58, 131);
            this.label18.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(59, 13);
            this.label18.TabIndex = 96;
            this.label18.Text = "Object size";
            // 
            // textBox11
            // 
            this.textBox11.Location = new System.Drawing.Point(121, 128);
            this.textBox11.Margin = new System.Windows.Forms.Padding(1);
            this.textBox11.Name = "textBox11";
            this.textBox11.Size = new System.Drawing.Size(29, 20);
            this.textBox11.TabIndex = 95;
            this.textBox11.Text = "80";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.ForeColor = System.Drawing.Color.White;
            this.label15.Location = new System.Drawing.Point(82, 104);
            this.label15.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(38, 13);
            this.label15.TabIndex = 94;
            this.label15.Text = "Height";
            this.label15.Click += new System.EventHandler(this.label15_Click);
            // 
            // textBox9
            // 
            this.textBox9.Location = new System.Drawing.Point(121, 100);
            this.textBox9.Margin = new System.Windows.Forms.Padding(1);
            this.textBox9.Name = "textBox9";
            this.textBox9.Size = new System.Drawing.Size(29, 20);
            this.textBox9.TabIndex = 93;
            this.textBox9.Text = "200";
            // 
            // textBox10
            // 
            this.textBox10.Location = new System.Drawing.Point(121, 74);
            this.textBox10.Margin = new System.Windows.Forms.Padding(1);
            this.textBox10.Name = "textBox10";
            this.textBox10.Size = new System.Drawing.Size(29, 20);
            this.textBox10.TabIndex = 92;
            this.textBox10.Text = "400";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.ForeColor = System.Drawing.Color.White;
            this.label16.Location = new System.Drawing.Point(82, 77);
            this.label16.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(35, 13);
            this.label16.TabIndex = 91;
            this.label16.Text = "Width";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.ForeColor = System.Drawing.Color.White;
            this.label17.Location = new System.Drawing.Point(16, 92);
            this.label17.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(56, 13);
            this.label17.TabIndex = 90;
            this.label17.Text = "Sheet size";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.ForeColor = System.Drawing.Color.White;
            this.label14.Location = new System.Drawing.Point(85, 53);
            this.label14.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(14, 13);
            this.label14.TabIndex = 89;
            this.label14.Text = "Y";
            // 
            // textBox8
            // 
            this.textBox8.Location = new System.Drawing.Point(101, 50);
            this.textBox8.Margin = new System.Windows.Forms.Padding(1);
            this.textBox8.Name = "textBox8";
            this.textBox8.Size = new System.Drawing.Size(49, 20);
            this.textBox8.TabIndex = 88;
            this.textBox8.Text = "-200";
            // 
            // textBox7
            // 
            this.textBox7.Location = new System.Drawing.Point(101, 20);
            this.textBox7.Margin = new System.Windows.Forms.Padding(1);
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(49, 20);
            this.textBox7.TabIndex = 87;
            this.textBox7.Text = "300";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.ForeColor = System.Drawing.Color.White;
            this.label13.Location = new System.Drawing.Point(85, 23);
            this.label13.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(14, 13);
            this.label13.TabIndex = 86;
            this.label13.Text = "X";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.ForeColor = System.Drawing.Color.White;
            this.label12.Location = new System.Drawing.Point(16, 41);
            this.label12.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(61, 13);
            this.label12.TabIndex = 85;
            this.label12.Text = "Sheet pose";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(184, 120);
            this.label11.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(68, 13);
            this.label11.TabIndex = 84;
            this.label11.Text = "Objects level";
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(254, 117);
            this.textBox5.Margin = new System.Windows.Forms.Padding(1);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(74, 20);
            this.textBox5.TabIndex = 83;
            this.textBox5.Text = "40";
            // 
            // button5
            // 
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.ForeColor = System.Drawing.Color.White;
            this.button5.Location = new System.Drawing.Point(6, 182);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(331, 44);
            this.button5.TabIndex = 75;
            this.button5.Text = "Set";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(210, 95);
            this.label9.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(42, 13);
            this.label9.TabIndex = 79;
            this.label9.Text = "Altitude";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(155, 48);
            this.label8.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(81, 13);
            this.label8.TabIndex = 78;
            this.label8.Text = "Unloading point";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(238, 70);
            this.label7.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(14, 13);
            this.label7.TabIndex = 77;
            this.label7.Text = "Z";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(238, 45);
            this.label6.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(14, 13);
            this.label6.TabIndex = 76;
            this.label6.Text = "Y";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(238, 20);
            this.label4.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(14, 13);
            this.label4.TabIndex = 75;
            this.label4.Text = "X";
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(254, 92);
            this.textBox4.Margin = new System.Windows.Forms.Padding(1);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(74, 20);
            this.textBox4.TabIndex = 62;
            this.textBox4.Text = "300";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(254, 67);
            this.textBox3.Margin = new System.Windows.Forms.Padding(1);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(74, 20);
            this.textBox3.TabIndex = 61;
            this.textBox3.Text = "40";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(254, 42);
            this.textBox2.Margin = new System.Windows.Forms.Padding(1);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(74, 20);
            this.textBox2.TabIndex = 60;
            this.textBox2.Text = "500";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(254, 17);
            this.textBox1.Margin = new System.Windows.Forms.Padding(1);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(74, 20);
            this.textBox1.TabIndex = 59;
            this.textBox1.Text = "0";
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Checked = true;
            this.radioButton2.ForeColor = System.Drawing.Color.White;
            this.radioButton2.Location = new System.Drawing.Point(7, 54);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(60, 17);
            this.radioButton2.TabIndex = 82;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "Vertical";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(4, 32);
            this.label10.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(93, 13);
            this.label10.TabIndex = 81;
            this.label10.Text = "Gripper orientation";
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.ForeColor = System.Drawing.Color.White;
            this.radioButton1.Location = new System.Drawing.Point(7, 77);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(72, 17);
            this.radioButton1.TabIndex = 80;
            this.radioButton1.Text = "Horizontal";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(601, 226);
            this.textBox6.Margin = new System.Windows.Forms.Padding(1);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(191, 20);
            this.textBox6.TabIndex = 75;
            this.textBox6.Text = "0 , -90 , 90 , 0 , 90 , 90";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(636, 210);
            this.label5.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(121, 15);
            this.label5.TabIndex = 76;
            this.label5.Text = "A1, A2, A3, A4, A5, A6";
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(519, 297);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(146, 97);
            this.button1.TabIndex = 77;
            this.button1.Text = "Collect objects";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 600;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // button6
            // 
            this.button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button6.ForeColor = System.Drawing.Color.White;
            this.button6.Location = new System.Drawing.Point(5, 72);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(135, 23);
            this.button6.TabIndex = 78;
            this.button6.Text = "Start timer";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button7
            // 
            this.button7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button7.ForeColor = System.Drawing.Color.White;
            this.button7.Location = new System.Drawing.Point(146, 72);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(109, 23);
            this.button7.TabIndex = 79;
            this.button7.Text = "Stop timer";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.radioButton1);
            this.groupBox2.Controls.Add(this.radioButton2);
            this.groupBox2.ForeColor = System.Drawing.Color.White;
            this.groupBox2.Location = new System.Drawing.Point(1305, 15);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(97, 104);
            this.groupBox2.TabIndex = 80;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Gripper";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(40)))));
            this.ClientSize = new System.Drawing.Size(1408, 936);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBox6);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.btnMoveRobotHome);
            this.Controls.Add(this.groupRunMode);
            this.Controls.Add(this.groupIncrementalMove);
            this.Controls.Add(this.btnRunTestProgram);
            this.Controls.Add(this.btnSelectStation);
            this.Controls.Add(this.btnMovePose);
            this.Controls.Add(this.btnGetJoints);
            this.Controls.Add(this.txtPosition);
            this.Controls.Add(this.lblJ1);
            this.Controls.Add(this.panel_rdk);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.tabControl1);
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
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
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
        private System.Windows.Forms.Button btnMovePose;
        private System.Windows.Forms.Button btnGetJoints;
        private System.Windows.Forms.TextBox txtPosition;
        private System.Windows.Forms.Label lblJ1;
        private System.Windows.Forms.Panel panel_rdk;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel notifybar;
        private System.Windows.Forms.Button btnTXneg;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox textBox8;
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox textBox9;
        private System.Windows.Forms.TextBox textBox10;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox textBox11;
        private System.Windows.Forms.RadioButton radioButton4;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}

