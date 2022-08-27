namespace CraneDashboard
{
    partial class frmSiteLayout
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
            this.button1 = new System.Windows.Forms.Button();
            this.panelResult = new System.Windows.Forms.Panel();
            this.BtSolution = new System.Windows.Forms.Button();
            this.LBCrane = new System.Windows.Forms.Label();
            this.CraneListCBox = new System.Windows.Forms.ComboBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.TxtOutPut = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblSetpositions = new System.Windows.Forms.Label();
            this.lblObjects = new System.Windows.Forms.Label();
            this.LEGEND = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.panelResult.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Image = global::CraneDashboard.Properties.Resources.zoom_2_;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.button1.Location = new System.Drawing.Point(0, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(28, 26);
            this.button1.TabIndex = 12;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panelResult
            // 
            this.panelResult.BackColor = System.Drawing.Color.Transparent;
            this.panelResult.BackgroundImage = global::CraneDashboard.Properties.Resources.imoutput;
            this.panelResult.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panelResult.Controls.Add(this.button2);
            this.panelResult.Controls.Add(this.BtSolution);
            this.panelResult.Controls.Add(this.LBCrane);
            this.panelResult.Controls.Add(this.CraneListCBox);
            this.panelResult.Controls.Add(this.pictureBox4);
            this.panelResult.Controls.Add(this.pictureBox3);
            this.panelResult.Controls.Add(this.label2);
            this.panelResult.Controls.Add(this.pictureBox2);
            this.panelResult.Controls.Add(this.pictureBox1);
            this.panelResult.Controls.Add(this.TxtOutPut);
            this.panelResult.Controls.Add(this.label1);
            this.panelResult.Controls.Add(this.lblSetpositions);
            this.panelResult.Controls.Add(this.lblObjects);
            this.panelResult.Controls.Add(this.LEGEND);
            this.panelResult.Location = new System.Drawing.Point(959, 12);
            this.panelResult.Name = "panelResult";
            this.panelResult.Size = new System.Drawing.Size(408, 738);
            this.panelResult.TabIndex = 11;
            // 
            // BtSolution
            // 
            this.BtSolution.BackColor = System.Drawing.Color.Gainsboro;
            this.BtSolution.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtSolution.Location = new System.Drawing.Point(8, 22);
            this.BtSolution.Name = "BtSolution";
            this.BtSolution.Size = new System.Drawing.Size(122, 23);
            this.BtSolution.TabIndex = 13;
            this.BtSolution.Text = "Show the solutions";
            this.BtSolution.UseVisualStyleBackColor = false;
            this.BtSolution.Click += new System.EventHandler(this.BtSolution_Click);
            // 
            // LBCrane
            // 
            this.LBCrane.AutoSize = true;
            this.LBCrane.Font = new System.Drawing.Font("Tw Cen MT", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBCrane.Location = new System.Drawing.Point(14, 267);
            this.LBCrane.Name = "LBCrane";
            this.LBCrane.Size = new System.Drawing.Size(61, 22);
            this.LBCrane.TabIndex = 25;
            this.LBCrane.Text = "Crane:";
            // 
            // CraneListCBox
            // 
            this.CraneListCBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CraneListCBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CraneListCBox.FormattingEnabled = true;
            this.CraneListCBox.Items.AddRange(new object[] {
            "ewwe"});
            this.CraneListCBox.Location = new System.Drawing.Point(90, 270);
            this.CraneListCBox.Name = "CraneListCBox";
            this.CraneListCBox.Size = new System.Drawing.Size(313, 21);
            this.CraneListCBox.TabIndex = 24;
            this.CraneListCBox.SelectedIndexChanged += new System.EventHandler(this.CraneListCBox_SelectedIndexChanged);
            this.CraneListCBox.Click += new System.EventHandler(this.CraneList_Click);
            // 
            // pictureBox4
            // 
            this.pictureBox4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox4.Image = global::CraneDashboard.Properties.Resources.fs;
            this.pictureBox4.Location = new System.Drawing.Point(306, 140);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(14, 14);
            this.pictureBox4.TabIndex = 17;
            this.pictureBox4.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox3.Image = global::CraneDashboard.Properties.Resources.fs;
            this.pictureBox3.Location = new System.Drawing.Point(268, 140);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(14, 14);
            this.pictureBox3.TabIndex = 16;
            this.pictureBox3.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Gainsboro;
            this.label2.Font = new System.Drawing.Font("Tw Cen MT", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(257, 103);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(114, 17);
            this.label2.TabIndex = 15;
            this.label2.Text = "Feasible Solution";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::CraneDashboard.Properties.Resources.set;
            this.pictureBox2.Location = new System.Drawing.Point(126, 128);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(86, 37);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 14;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::CraneDashboard.Properties.Resources.obs1;
            this.pictureBox1.Location = new System.Drawing.Point(17, 128);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(87, 37);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 13;
            this.pictureBox1.TabStop = false;
            // 
            // TxtOutPut
            // 
            this.TxtOutPut.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TxtOutPut.Font = new System.Drawing.Font("Tw Cen MT", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtOutPut.Location = new System.Drawing.Point(8, 307);
            this.TxtOutPut.Name = "TxtOutPut";
            this.TxtOutPut.ReadOnly = true;
            this.TxtOutPut.Size = new System.Drawing.Size(395, 418);
            this.TxtOutPut.TabIndex = 1;
            this.TxtOutPut.Text = "";
            this.TxtOutPut.TextChanged += new System.EventHandler(this.TxtOutPut_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tw Cen MT", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 212);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 28);
            this.label1.TabIndex = 0;
            this.label1.Text = "Output";
            // 
            // lblSetpositions
            // 
            this.lblSetpositions.AutoSize = true;
            this.lblSetpositions.BackColor = System.Drawing.Color.Gainsboro;
            this.lblSetpositions.Font = new System.Drawing.Font("Tw Cen MT", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSetpositions.ForeColor = System.Drawing.Color.Black;
            this.lblSetpositions.Location = new System.Drawing.Point(123, 103);
            this.lblSetpositions.Name = "lblSetpositions";
            this.lblSetpositions.Size = new System.Drawing.Size(86, 17);
            this.lblSetpositions.TabIndex = 10;
            this.lblSetpositions.Text = "Set Positions";
            // 
            // lblObjects
            // 
            this.lblObjects.AutoSize = true;
            this.lblObjects.BackColor = System.Drawing.Color.Gainsboro;
            this.lblObjects.Font = new System.Drawing.Font("Tw Cen MT", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblObjects.ForeColor = System.Drawing.Color.Black;
            this.lblObjects.Location = new System.Drawing.Point(18, 103);
            this.lblObjects.Name = "lblObjects";
            this.lblObjects.Size = new System.Drawing.Size(86, 17);
            this.lblObjects.TabIndex = 10;
            this.lblObjects.Text = "Obstructions";
            this.lblObjects.Click += new System.EventHandler(this.lblObjects_Click);
            // 
            // LEGEND
            // 
            this.LEGEND.AutoSize = true;
            this.LEGEND.BackColor = System.Drawing.Color.Transparent;
            this.LEGEND.Font = new System.Drawing.Font("Tw Cen MT", 17.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LEGEND.ForeColor = System.Drawing.Color.Black;
            this.LEGEND.Location = new System.Drawing.Point(13, 76);
            this.LEGEND.Name = "LEGEND";
            this.LEGEND.Size = new System.Drawing.Size(91, 27);
            this.LEGEND.TabIndex = 10;
            this.LEGEND.Text = "LEGEND";
            this.LEGEND.Click += new System.EventHandler(this.lblLegend_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Gainsboro;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Location = new System.Drawing.Point(260, 22);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(122, 23);
            this.button2.TabIndex = 26;
            this.button2.Text = "Site Layout";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // frmSiteLayout
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1379, 830);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.panelResult);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmSiteLayout";
            this.Text = "txtOutput";
            this.Load += new System.EventHandler(this.frmSiteLayout_Load);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.frmSiteLayout_MouseClick);
            this.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.frmSiteLayout_MouseDoubleClick);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.frmSiteLayout_MouseMove);
            this.panelResult.ResumeLayout(false);
            this.panelResult.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label LEGEND;
        private System.Windows.Forms.Label lblObjects;
        private System.Windows.Forms.Label lblSetpositions;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox TxtOutPut;
        private System.Windows.Forms.Panel panelResult;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox CraneListCBox;
        private System.Windows.Forms.Label LBCrane;
        private System.Windows.Forms.Button BtSolution;
        private System.Windows.Forms.Button button2;
    }
}