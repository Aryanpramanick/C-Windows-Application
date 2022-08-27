namespace CraneDashboard
{
    partial class Form1
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.pnlNav = new System.Windows.Forms.Panel();
            this.btnSettings = new System.Windows.Forms.Button();
            this.btnSiteLayout = new System.Windows.Forms.Button();
            this.btnCalender = new System.Windows.Forms.Button();
            this.btnDataEntry = new System.Windows.Forms.Button();
            this.btnWelcome = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.pnlFormLoader = new System.Windows.Forms.Panel();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.pnlFormLoader.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(208)))), ((int)(((byte)(0)))));
            this.panel1.Controls.Add(this.pnlNav);
            this.panel1.Controls.Add(this.btnSettings);
            this.panel1.Controls.Add(this.btnSiteLayout);
            this.panel1.Controls.Add(this.btnCalender);
            this.panel1.Controls.Add(this.btnDataEntry);
            this.panel1.Controls.Add(this.btnWelcome);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(220, 911);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseMove);
            // 
            // pnlNav
            // 
            this.pnlNav.BackColor = System.Drawing.Color.Silver;
            this.pnlNav.Location = new System.Drawing.Point(0, 193);
            this.pnlNav.Name = "pnlNav";
            this.pnlNav.Size = new System.Drawing.Size(10, 100);
            this.pnlNav.TabIndex = 2;
            // 
            // btnSettings
            // 
            this.btnSettings.FlatAppearance.BorderSize = 0;
            this.btnSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSettings.Font = new System.Drawing.Font("Tw Cen MT Condensed", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSettings.ForeColor = System.Drawing.Color.Black;
            this.btnSettings.Image = global::CraneDashboard.Properties.Resources.config_removebg_preview_2__1_;
            this.btnSettings.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSettings.Location = new System.Drawing.Point(3, 443);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Padding = new System.Windows.Forms.Padding(15, 0, 10, 0);
            this.btnSettings.Size = new System.Drawing.Size(220, 54);
            this.btnSettings.TabIndex = 1;
            this.btnSettings.Text = "View";
            this.btnSettings.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSettings.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnSettings.UseVisualStyleBackColor = true;
            this.btnSettings.Click += new System.EventHandler(this.btnSettings_Click);
            // 
            // btnSiteLayout
            // 
            this.btnSiteLayout.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnSiteLayout.FlatAppearance.BorderSize = 0;
            this.btnSiteLayout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSiteLayout.Font = new System.Drawing.Font("Tw Cen MT Condensed", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSiteLayout.ForeColor = System.Drawing.Color.Black;
            this.btnSiteLayout.Image = global::CraneDashboard.Properties.Resources.construction_removebg_preview_1_;
            this.btnSiteLayout.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSiteLayout.Location = new System.Drawing.Point(0, 395);
            this.btnSiteLayout.Name = "btnSiteLayout";
            this.btnSiteLayout.Padding = new System.Windows.Forms.Padding(15, 0, 10, 0);
            this.btnSiteLayout.Size = new System.Drawing.Size(220, 54);
            this.btnSiteLayout.TabIndex = 1;
            this.btnSiteLayout.Text = "Site Layout";
            this.btnSiteLayout.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSiteLayout.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnSiteLayout.UseVisualStyleBackColor = true;
            this.btnSiteLayout.Click += new System.EventHandler(this.btnSiteLayout_Click);
            // 
            // btnCalender
            // 
            this.btnCalender.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnCalender.FlatAppearance.BorderSize = 0;
            this.btnCalender.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCalender.Font = new System.Drawing.Font("Tw Cen MT Condensed", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCalender.ForeColor = System.Drawing.Color.Black;
            this.btnCalender.Image = global::CraneDashboard.Properties.Resources.selection_removebg_preview_2__2_;
            this.btnCalender.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCalender.Location = new System.Drawing.Point(0, 341);
            this.btnCalender.Name = "btnCalender";
            this.btnCalender.Padding = new System.Windows.Forms.Padding(15, 0, 10, 0);
            this.btnCalender.Size = new System.Drawing.Size(220, 54);
            this.btnCalender.TabIndex = 1;
            this.btnCalender.Text = "Crane Selection";
            this.btnCalender.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCalender.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnCalender.UseVisualStyleBackColor = true;
            this.btnCalender.Click += new System.EventHandler(this.btnCalender_Click);
            // 
            // btnDataEntry
            // 
            this.btnDataEntry.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnDataEntry.FlatAppearance.BorderSize = 0;
            this.btnDataEntry.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDataEntry.Font = new System.Drawing.Font("Tw Cen MT Condensed", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDataEntry.ForeColor = System.Drawing.Color.Black;
            this.btnDataEntry.Image = global::CraneDashboard.Properties.Resources.entry_removebg_preview_2__1_;
            this.btnDataEntry.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDataEntry.Location = new System.Drawing.Point(0, 287);
            this.btnDataEntry.Name = "btnDataEntry";
            this.btnDataEntry.Padding = new System.Windows.Forms.Padding(15, 0, 10, 0);
            this.btnDataEntry.Size = new System.Drawing.Size(220, 54);
            this.btnDataEntry.TabIndex = 1;
            this.btnDataEntry.Text = "Data Entry";
            this.btnDataEntry.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDataEntry.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnDataEntry.UseVisualStyleBackColor = true;
            this.btnDataEntry.Click += new System.EventHandler(this.btnDataEntry_Click);
            // 
            // btnWelcome
            // 
            this.btnWelcome.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnWelcome.FlatAppearance.BorderSize = 0;
            this.btnWelcome.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnWelcome.Font = new System.Drawing.Font("Tw Cen MT Condensed", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnWelcome.ForeColor = System.Drawing.Color.Black;
            this.btnWelcome.Image = global::CraneDashboard.Properties.Resources.home_removebg_preview_1_;
            this.btnWelcome.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnWelcome.Location = new System.Drawing.Point(0, 233);
            this.btnWelcome.Name = "btnWelcome";
            this.btnWelcome.Padding = new System.Windows.Forms.Padding(15, 0, 10, 0);
            this.btnWelcome.Size = new System.Drawing.Size(220, 54);
            this.btnWelcome.TabIndex = 1;
            this.btnWelcome.Text = "Welcome";
            this.btnWelcome.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnWelcome.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnWelcome.UseVisualStyleBackColor = true;
            this.btnWelcome.Click += new System.EventHandler(this.btnWelcome_Click);
            this.btnWelcome.Leave += new System.EventHandler(this.btnWelcome_Leave_1);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(220, 233);
            this.panel2.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tw Cen MT", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(47, 133);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 24);
            this.label1.TabIndex = 1;
            this.label1.Text = "User Name";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::CraneDashboard.Properties.Resources.ncsg_logo_header;
            this.pictureBox1.Location = new System.Drawing.Point(23, 25);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(180, 91);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Tw Cen MT", 36F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.Black;
            this.lblTitle.Location = new System.Drawing.Point(302, 25);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(194, 55);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "Welcome";
            // 
            // button1
            // 
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(1534, 25);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(25, 25);
            this.button1.TabIndex = 3;
            this.button1.Text = "X";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // pnlFormLoader
            // 
            this.pnlFormLoader.BackColor = System.Drawing.Color.White;
            this.pnlFormLoader.Controls.Add(this.splitter1);
            this.pnlFormLoader.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFormLoader.Location = new System.Drawing.Point(220, 104);
            this.pnlFormLoader.Name = "pnlFormLoader";
            this.pnlFormLoader.Size = new System.Drawing.Size(1364, 807);
            this.pnlFormLoader.TabIndex = 4;
            this.pnlFormLoader.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlFormLoader_Paint);
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(0, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 807);
            this.splitter1.TabIndex = 0;
            this.splitter1.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(190)))), ((int)(((byte)(0)))));
            this.ClientSize = new System.Drawing.Size(1584, 911);
            this.Controls.Add(this.pnlFormLoader);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.pnlFormLoader.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnDataEntry;
        private System.Windows.Forms.Button btnSettings;
        private System.Windows.Forms.Button btnSiteLayout;
        private System.Windows.Forms.Button btnCalender;
        private System.Windows.Forms.Panel pnlNav;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel pnlFormLoader;
        private System.Windows.Forms.Button btnWelcome;
        private System.Windows.Forms.Splitter splitter1;
    }
}

