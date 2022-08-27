namespace CraneDashboard
{
    partial class frmDataEntry
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.panel5 = new System.Windows.Forms.Panel();
            this.grbPickAreas = new System.Windows.Forms.GroupBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnPAClear = new System.Windows.Forms.Button();
            this.btnPASubmit = new System.Windows.Forms.Button();
            this.txtPA_Length = new System.Windows.Forms.TextBox();
            this.txtPA_Width = new System.Windows.Forms.TextBox();
            this.txtPA_TopLeftY = new System.Windows.Forms.TextBox();
            this.txtPA_TopLeftX = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.grbModules = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnModClear = new System.Windows.Forms.Button();
            this.btnModSubmit = new System.Windows.Forms.Button();
            this.label17 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtM1_Z = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.txtM1_Angle = new System.Windows.Forms.TextBox();
            this.lblModule1 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label15 = new System.Windows.Forms.Label();
            this.txtM1_X = new System.Windows.Forms.TextBox();
            this.txtM1_Y = new System.Windows.Forms.TextBox();
            this.dgv2 = new System.Windows.Forms.DataGridView();
            this.dgv1 = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.panel5.SuspendLayout();
            this.grbPickAreas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.grbModules.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.Transparent;
            this.panel5.BackgroundImage = global::CraneDashboard.Properties.Resources.im16;
            this.panel5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.panel5.Controls.Add(this.grbPickAreas);
            this.panel5.Controls.Add(this.grbModules);
            this.panel5.Controls.Add(this.dgv2);
            this.panel5.Controls.Add(this.dgv1);
            this.panel5.ForeColor = System.Drawing.SystemColors.Desktop;
            this.panel5.Location = new System.Drawing.Point(19, 12);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1333, 802);
            this.panel5.TabIndex = 8;
            this.panel5.Paint += new System.Windows.Forms.PaintEventHandler(this.panel5_Paint);
            // 
            // grbPickAreas
            // 
            this.grbPickAreas.BackColor = System.Drawing.Color.Silver;
            this.grbPickAreas.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.grbPickAreas.Controls.Add(this.pictureBox1);
            this.grbPickAreas.Controls.Add(this.btnPAClear);
            this.grbPickAreas.Controls.Add(this.btnPASubmit);
            this.grbPickAreas.Controls.Add(this.txtPA_Length);
            this.grbPickAreas.Controls.Add(this.txtPA_Width);
            this.grbPickAreas.Controls.Add(this.txtPA_TopLeftY);
            this.grbPickAreas.Controls.Add(this.txtPA_TopLeftX);
            this.grbPickAreas.Controls.Add(this.label12);
            this.grbPickAreas.Controls.Add(this.label24);
            this.grbPickAreas.Controls.Add(this.label25);
            this.grbPickAreas.Controls.Add(this.label26);
            this.grbPickAreas.Controls.Add(this.label27);
            this.grbPickAreas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.grbPickAreas.Font = new System.Drawing.Font("Tw Cen MT", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbPickAreas.ForeColor = System.Drawing.Color.DarkOrange;
            this.grbPickAreas.Location = new System.Drawing.Point(800, 50);
            this.grbPickAreas.Name = "grbPickAreas";
            this.grbPickAreas.Size = new System.Drawing.Size(500, 410);
            this.grbPickAreas.TabIndex = 15;
            this.grbPickAreas.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::CraneDashboard.Properties.Resources.clip;
            this.pictureBox1.Location = new System.Drawing.Point(385, 19);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(59, 65);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 21;
            this.pictureBox1.TabStop = false;
            // 
            // btnPAClear
            // 
            this.btnPAClear.BackColor = System.Drawing.Color.Transparent;
            this.btnPAClear.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnPAClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPAClear.Font = new System.Drawing.Font("Tw Cen MT", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPAClear.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnPAClear.Location = new System.Drawing.Point(38, 333);
            this.btnPAClear.Name = "btnPAClear";
            this.btnPAClear.Size = new System.Drawing.Size(190, 29);
            this.btnPAClear.TabIndex = 12;
            this.btnPAClear.Text = "&Clear";
            this.btnPAClear.UseVisualStyleBackColor = false;
            this.btnPAClear.Click += new System.EventHandler(this.btnPAClear_Click);
            this.btnPAClear.MouseLeave += new System.EventHandler(this.btnButtons_Leave);
            this.btnPAClear.MouseHover += new System.EventHandler(this.btnButtons_Hover);
            // 
            // btnPASubmit
            // 
            this.btnPASubmit.BackColor = System.Drawing.Color.Transparent;
            this.btnPASubmit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnPASubmit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPASubmit.Font = new System.Drawing.Font("Tw Cen MT", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPASubmit.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnPASubmit.Location = new System.Drawing.Point(263, 333);
            this.btnPASubmit.Name = "btnPASubmit";
            this.btnPASubmit.Size = new System.Drawing.Size(190, 29);
            this.btnPASubmit.TabIndex = 11;
            this.btnPASubmit.Text = "&Submit";
            this.btnPASubmit.UseVisualStyleBackColor = false;
            this.btnPASubmit.Click += new System.EventHandler(this.btnPASubmit_Click);
            this.btnPASubmit.MouseLeave += new System.EventHandler(this.btnButtons_Leave);
            this.btnPASubmit.MouseHover += new System.EventHandler(this.btnButtons_Hover);
            // 
            // txtPA_Length
            // 
            this.txtPA_Length.Location = new System.Drawing.Point(210, 280);
            this.txtPA_Length.Name = "txtPA_Length";
            this.txtPA_Length.Size = new System.Drawing.Size(183, 25);
            this.txtPA_Length.TabIndex = 10;
            // 
            // txtPA_Width
            // 
            this.txtPA_Width.Location = new System.Drawing.Point(210, 220);
            this.txtPA_Width.Name = "txtPA_Width";
            this.txtPA_Width.Size = new System.Drawing.Size(183, 25);
            this.txtPA_Width.TabIndex = 9;
            this.txtPA_Width.TextChanged += new System.EventHandler(this.txtPA_Width_TextChanged);
            // 
            // txtPA_TopLeftY
            // 
            this.txtPA_TopLeftY.Location = new System.Drawing.Point(210, 160);
            this.txtPA_TopLeftY.Name = "txtPA_TopLeftY";
            this.txtPA_TopLeftY.Size = new System.Drawing.Size(183, 25);
            this.txtPA_TopLeftY.TabIndex = 8;
            // 
            // txtPA_TopLeftX
            // 
            this.txtPA_TopLeftX.Location = new System.Drawing.Point(210, 100);
            this.txtPA_TopLeftX.Name = "txtPA_TopLeftX";
            this.txtPA_TopLeftX.Size = new System.Drawing.Size(183, 25);
            this.txtPA_TopLeftX.TabIndex = 7;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Tw Cen MT Condensed", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.Black;
            this.label12.Location = new System.Drawing.Point(32, 31);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(221, 34);
            this.label12.TabIndex = 0;
            this.label12.Text = "Potential Pick Areas";
            this.label12.Click += new System.EventHandler(this.label12_Click);
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("Tw Cen MT", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label24.ForeColor = System.Drawing.Color.Black;
            this.label24.Location = new System.Drawing.Point(50, 280);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(114, 19);
            this.label24.TabIndex = 0;
            this.label24.Text = "Pick Area Length";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("Tw Cen MT", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label25.ForeColor = System.Drawing.Color.Black;
            this.label25.Location = new System.Drawing.Point(50, 220);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(112, 19);
            this.label25.TabIndex = 0;
            this.label25.Text = "Pick Area Width";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Font = new System.Drawing.Font("Tw Cen MT", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label26.ForeColor = System.Drawing.Color.Black;
            this.label26.Location = new System.Drawing.Point(50, 160);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(145, 19);
            this.label26.TabIndex = 0;
            this.label26.Text = "Top-Left Y coordinate";
            this.label26.Click += new System.EventHandler(this.label26_Click);
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Font = new System.Drawing.Font("Tw Cen MT", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label27.ForeColor = System.Drawing.Color.Black;
            this.label27.Location = new System.Drawing.Point(50, 100);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(145, 19);
            this.label27.TabIndex = 0;
            this.label27.Text = "Top-Left X coordinate";
            // 
            // grbModules
            // 
            this.grbModules.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.grbModules.BackColor = System.Drawing.Color.Silver;
            this.grbModules.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.grbModules.Controls.Add(this.label6);
            this.grbModules.Controls.Add(this.label5);
            this.grbModules.Controls.Add(this.label4);
            this.grbModules.Controls.Add(this.textBox2);
            this.grbModules.Controls.Add(this.textBox1);
            this.grbModules.Controls.Add(this.comboBox2);
            this.grbModules.Controls.Add(this.comboBox1);
            this.grbModules.Controls.Add(this.label2);
            this.grbModules.Controls.Add(this.label1);
            this.grbModules.Controls.Add(this.btnModClear);
            this.grbModules.Controls.Add(this.btnModSubmit);
            this.grbModules.Controls.Add(this.label17);
            this.grbModules.Controls.Add(this.label3);
            this.grbModules.Controls.Add(this.txtM1_Z);
            this.grbModules.Controls.Add(this.label16);
            this.grbModules.Controls.Add(this.txtM1_Angle);
            this.grbModules.Controls.Add(this.lblModule1);
            this.grbModules.Controls.Add(this.pictureBox2);
            this.grbModules.Controls.Add(this.label15);
            this.grbModules.Controls.Add(this.txtM1_X);
            this.grbModules.Controls.Add(this.txtM1_Y);
            this.grbModules.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.grbModules.ForeColor = System.Drawing.Color.Silver;
            this.grbModules.Location = new System.Drawing.Point(118, 51);
            this.grbModules.Name = "grbModules";
            this.grbModules.Size = new System.Drawing.Size(500, 410);
            this.grbModules.TabIndex = 5;
            this.grbModules.TabStop = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(420, 317);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 13);
            this.label6.TabIndex = 29;
            this.label6.Text = "label6";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(420, 240);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 13);
            this.label5.TabIndex = 28;
            this.label5.Text = "label5";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(420, 199);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 27;
            this.label4.Text = "label4";
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox2.Location = new System.Drawing.Point(201, 163);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(209, 13);
            this.textBox2.TabIndex = 26;
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Location = new System.Drawing.Point(201, 107);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(209, 13);
            this.textBox1.TabIndex = 25;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // comboBox2
            // 
            this.comboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(201, 136);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(209, 21);
            this.comboBox2.TabIndex = 24;
            this.comboBox2.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(201, 80);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(209, 21);
            this.comboBox1.TabIndex = 23;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tw Cen MT", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(51, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 19);
            this.label2.TabIndex = 22;
            this.label2.Text = "Dimensions";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tw Cen MT", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(51, 135);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 19);
            this.label1.TabIndex = 21;
            this.label1.Text = "Weight";
            // 
            // btnModClear
            // 
            this.btnModClear.BackColor = System.Drawing.Color.Transparent;
            this.btnModClear.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnModClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnModClear.Font = new System.Drawing.Font("Tw Cen MT", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnModClear.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnModClear.Location = new System.Drawing.Point(31, 362);
            this.btnModClear.Name = "btnModClear";
            this.btnModClear.Size = new System.Drawing.Size(190, 29);
            this.btnModClear.TabIndex = 20;
            this.btnModClear.Text = "Clear";
            this.btnModClear.UseVisualStyleBackColor = false;
            this.btnModClear.Click += new System.EventHandler(this.btnModClear_Click_1);
            // 
            // btnModSubmit
            // 
            this.btnModSubmit.BackColor = System.Drawing.Color.Transparent;
            this.btnModSubmit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnModSubmit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnModSubmit.Font = new System.Drawing.Font("Tw Cen MT", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnModSubmit.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnModSubmit.Location = new System.Drawing.Point(251, 362);
            this.btnModSubmit.Name = "btnModSubmit";
            this.btnModSubmit.Size = new System.Drawing.Size(190, 29);
            this.btnModSubmit.TabIndex = 17;
            this.btnModSubmit.Text = "Submit";
            this.btnModSubmit.UseVisualStyleBackColor = false;
            this.btnModSubmit.Click += new System.EventHandler(this.btnM1_SetPos_Click);
            this.btnModSubmit.MouseLeave += new System.EventHandler(this.btnButtons_Leave);
            this.btnModSubmit.MouseHover += new System.EventHandler(this.btnButtons_Hover);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Tw Cen MT", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.ForeColor = System.Drawing.Color.Black;
            this.label17.Location = new System.Drawing.Point(51, 273);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(75, 19);
            this.label17.TabIndex = 16;
            this.label17.Text = "Z centroid:";
            this.label17.Click += new System.EventHandler(this.label17_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tw Cen MT", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(27, 313);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(148, 19);
            this.label3.TabIndex = 16;
            this.label3.Text = "Set Orientation Angle:";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // txtM1_Z
            // 
            this.txtM1_Z.Location = new System.Drawing.Point(201, 272);
            this.txtM1_Z.Name = "txtM1_Z";
            this.txtM1_Z.Size = new System.Drawing.Size(209, 20);
            this.txtM1_Z.TabIndex = 15;
            this.txtM1_Z.TextChanged += new System.EventHandler(this.txtM1_Z_TextChanged);
            this.txtM1_Z.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtInput_KeyPress);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Tw Cen MT", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.Color.Black;
            this.label16.Location = new System.Drawing.Point(51, 236);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(80, 19);
            this.label16.TabIndex = 16;
            this.label16.Text = "Y centroid :";
            this.label16.Click += new System.EventHandler(this.label16_Click);
            // 
            // txtM1_Angle
            // 
            this.txtM1_Angle.Location = new System.Drawing.Point(201, 312);
            this.txtM1_Angle.Name = "txtM1_Angle";
            this.txtM1_Angle.Size = new System.Drawing.Size(209, 20);
            this.txtM1_Angle.TabIndex = 16;
            this.txtM1_Angle.TextChanged += new System.EventHandler(this.txtM1_Angle_TextChanged);
            this.txtM1_Angle.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtInput_KeyPress);
            // 
            // lblModule1
            // 
            this.lblModule1.AutoSize = true;
            this.lblModule1.Font = new System.Drawing.Font("Tw Cen MT Condensed", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblModule1.ForeColor = System.Drawing.Color.Black;
            this.lblModule1.Location = new System.Drawing.Point(24, 31);
            this.lblModule1.Name = "lblModule1";
            this.lblModule1.Size = new System.Drawing.Size(138, 34);
            this.lblModule1.TabIndex = 11;
            this.lblModule1.Text = "Module Info";
            this.lblModule1.Click += new System.EventHandler(this.lblModule1_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::CraneDashboard.Properties.Resources.module_icon_5;
            this.pictureBox2.Location = new System.Drawing.Point(419, 11);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(78, 73);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 12;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Tw Cen MT", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.Black;
            this.label15.Location = new System.Drawing.Point(51, 197);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(80, 19);
            this.label15.TabIndex = 16;
            this.label15.Text = "X centroid :";
            this.label15.Click += new System.EventHandler(this.label15_Click);
            // 
            // txtM1_X
            // 
            this.txtM1_X.Location = new System.Drawing.Point(201, 196);
            this.txtM1_X.Name = "txtM1_X";
            this.txtM1_X.Size = new System.Drawing.Size(209, 20);
            this.txtM1_X.TabIndex = 13;
            this.txtM1_X.TextChanged += new System.EventHandler(this.txtM1_X_TextChanged);
            this.txtM1_X.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtInput_KeyPress);
            // 
            // txtM1_Y
            // 
            this.txtM1_Y.Location = new System.Drawing.Point(201, 235);
            this.txtM1_Y.Name = "txtM1_Y";
            this.txtM1_Y.Size = new System.Drawing.Size(209, 20);
            this.txtM1_Y.TabIndex = 14;
            this.txtM1_Y.TextChanged += new System.EventHandler(this.txtM1_Y_TextChanged);
            this.txtM1_Y.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtInput_KeyPress);
            // 
            // dgv2
            // 
            this.dgv2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv2.Location = new System.Drawing.Point(690, 522);
            this.dgv2.Name = "dgv2";
            this.dgv2.Size = new System.Drawing.Size(610, 230);
            this.dgv2.TabIndex = 9;
            this.dgv2.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv2_CellContentClick);
            this.dgv2.CellMouseUp += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgv2_CellMouseUp);
            // 
            // dgv1
            // 
            this.dgv1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv1.Location = new System.Drawing.Point(17, 522);
            this.dgv1.Name = "dgv1";
            this.dgv1.Size = new System.Drawing.Size(603, 230);
            this.dgv1.TabIndex = 10;
            this.dgv1.CellMouseUp += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgv1_CellMouseUp);
            this.dgv1.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.dgv1_RowsRemoved);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(134, 26);
            this.contextMenuStrip1.Click += new System.EventHandler(this.contextMenuStrip1_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(133, 22);
            this.toolStripMenuItem1.Text = "Delete Row";
            // 
            // frmDataEntry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1364, 830);
            this.Controls.Add(this.panel5);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmDataEntry";
            this.Text = "frmDashboard";
            this.Load += new System.EventHandler(this.frmDashboard_Load);
            this.Leave += new System.EventHandler(this.frmDashboard_Leave);
            this.panel5.ResumeLayout(false);
            this.grbPickAreas.ResumeLayout(false);
            this.grbPickAreas.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.grbModules.ResumeLayout(false);
            this.grbModules.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label lblModule1;
        private System.Windows.Forms.TextBox txtM1_X;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtM1_Z;
        private System.Windows.Forms.TextBox txtM1_Y;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Button btnModSubmit;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtM1_Angle;
        private System.Windows.Forms.GroupBox grbPickAreas;
        private System.Windows.Forms.Button btnPAClear;
        private System.Windows.Forms.Button btnPASubmit;
        private System.Windows.Forms.TextBox txtPA_Length;
        private System.Windows.Forms.TextBox txtPA_Width;
        private System.Windows.Forms.TextBox txtPA_TopLeftY;
        private System.Windows.Forms.TextBox txtPA_TopLeftX;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.GroupBox grbModules;
        private System.Windows.Forms.Button btnModClear;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.DataGridView dgv2;
        private System.Windows.Forms.DataGridView dgv1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
    }
}