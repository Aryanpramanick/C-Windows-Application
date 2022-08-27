namespace CraneDashboard
{
    partial class frmAnalytics
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
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.dgv1 = new System.Windows.Forms.DataGridView();
            this.Type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CraneInfo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MastLength = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MastRadius = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Rmax = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Capacity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaxEquipmWt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Rigging = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalLiftWeight = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PercChartCapacity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WindSpeed = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TailswingRadius = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TailswingGantry = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaxGBP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnRetrieveData = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnToDB = new System.Windows.Forms.Button();
            this.dgv2 = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv2)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(77, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(341, 31);
            this.label1.TabIndex = 2;
            this.label1.Text = "Crane / Module Information";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::CraneDashboard.Properties.Resources.kindpng_2684156_3;
            this.pictureBox1.Location = new System.Drawing.Point(529, 96);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(83, 66);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // dgv1
            // 
            this.dgv1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Type,
            this.CraneInfo,
            this.MastLength,
            this.MastRadius,
            this.Rmax,
            this.Capacity,
            this.MaxEquipmWt,
            this.Rigging,
            this.TotalLiftWeight,
            this.PercChartCapacity,
            this.WindSpeed,
            this.TailswingRadius,
            this.TailswingGantry,
            this.MaxGBP});
            this.dgv1.Location = new System.Drawing.Point(12, 182);
            this.dgv1.Name = "dgv1";
            this.dgv1.Size = new System.Drawing.Size(1229, 204);
            this.dgv1.TabIndex = 4;
            this.dgv1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv1_CellContentClick);
            // 
            // Type
            // 
            this.Type.DataPropertyName = "Type";
            this.Type.HeaderText = "Crane Type";
            this.Type.Name = "Type";
            // 
            // CraneInfo
            // 
            this.CraneInfo.DataPropertyName = "Crane Info";
            this.CraneInfo.HeaderText = "Crane Info";
            this.CraneInfo.Name = "CraneInfo";
            // 
            // MastLength
            // 
            this.MastLength.DataPropertyName = "Mast Length(m)";
            this.MastLength.HeaderText = "Mast Length(m)";
            this.MastLength.Name = "MastLength";
            // 
            // MastRadius
            // 
            this.MastRadius.DataPropertyName = "Mast Radius(ft)";
            this.MastRadius.HeaderText = "Mast Radius(ft)";
            this.MastRadius.Name = "MastRadius";
            // 
            // Rmax
            // 
            this.Rmax.DataPropertyName = "Rmax(ft)";
            this.Rmax.HeaderText = "Rmax(ft)";
            this.Rmax.Name = "Rmax";
            // 
            // Capacity
            // 
            this.Capacity.DataPropertyName = "Capacity(lbs)";
            this.Capacity.HeaderText = "Capacity(lbs)";
            this.Capacity.Name = "Capacity";
            // 
            // MaxEquipmWt
            // 
            this.MaxEquipmWt.DataPropertyName = "Max Equipment Wt(lbs)";
            this.MaxEquipmWt.HeaderText = "Max Equipment Wt(lbs)";
            this.MaxEquipmWt.Name = "MaxEquipmWt";
            // 
            // Rigging
            // 
            this.Rigging.DataPropertyName = "Rigging(lbs)";
            this.Rigging.HeaderText = "Rigging(lbs)";
            this.Rigging.Name = "Rigging";
            // 
            // TotalLiftWeight
            // 
            this.TotalLiftWeight.DataPropertyName = "Total Lift Wight(lbs)";
            this.TotalLiftWeight.HeaderText = "Total Lift Weight(lbs)";
            this.TotalLiftWeight.Name = "TotalLiftWeight";
            // 
            // PercChartCapacity
            // 
            this.PercChartCapacity.DataPropertyName = "% of Chart Capacity";
            this.PercChartCapacity.HeaderText = "% of Chart Capacity";
            this.PercChartCapacity.Name = "PercChartCapacity";
            // 
            // WindSpeed
            // 
            this.WindSpeed.DataPropertyName = "Permissible wind speed(mph)";
            this.WindSpeed.HeaderText = "Permissible wind speed(mph)";
            this.WindSpeed.Name = "WindSpeed";
            // 
            // TailswingRadius
            // 
            this.TailswingRadius.DataPropertyName = "Tailsw SL-Mast Radius(ft)";
            this.TailswingRadius.HeaderText = "Tailswing SL-Mast Radius(ft)";
            this.TailswingRadius.Name = "TailswingRadius";
            // 
            // TailswingGantry
            // 
            this.TailswingGantry.DataPropertyName = "Tailswing Gantry(ft)";
            this.TailswingGantry.HeaderText = "Tailswing Gantry(ft)";
            this.TailswingGantry.Name = "TailswingGantry";
            // 
            // MaxGBP
            // 
            this.MaxGBP.DataPropertyName = "Max GBP(psf)";
            this.MaxGBP.HeaderText = "Maximum GBP(psf)";
            this.MaxGBP.Name = "MaxGBP";
            // 
            // btnRetrieveData
            // 
            this.btnRetrieveData.Location = new System.Drawing.Point(106, 139);
            this.btnRetrieveData.Name = "btnRetrieveData";
            this.btnRetrieveData.Size = new System.Drawing.Size(137, 23);
            this.btnRetrieveData.TabIndex = 5;
            this.btnRetrieveData.Text = "Retrieve Data from DB";
            this.btnRetrieveData.UseVisualStyleBackColor = true;
            this.btnRetrieveData.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(12, 139);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 25);
            this.label2.TabIndex = 2;
            this.label2.Text = "Cranes";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(12, 423);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 25);
            this.label3.TabIndex = 2;
            this.label3.Text = "Modules";
            // 
            // btnToDB
            // 
            this.btnToDB.Location = new System.Drawing.Point(265, 139);
            this.btnToDB.Name = "btnToDB";
            this.btnToDB.Size = new System.Drawing.Size(137, 23);
            this.btnToDB.TabIndex = 6;
            this.btnToDB.Text = "Save into Database";
            this.btnToDB.UseVisualStyleBackColor = true;
            // 
            // dgv2
            // 
            this.dgv2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn7,
            this.dataGridViewTextBoxColumn8});
            this.dgv2.Location = new System.Drawing.Point(12, 467);
            this.dgv2.Name = "dgv2";
            this.dgv2.Size = new System.Drawing.Size(1229, 204);
            this.dgv2.TabIndex = 4;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Module";
            this.dataGridViewTextBoxColumn2.HeaderText = "Module";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "Length";
            this.dataGridViewTextBoxColumn3.HeaderText = "Length";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "COG_long_side";
            this.dataGridViewTextBoxColumn4.HeaderText = "COG_long_side";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "Width";
            this.dataGridViewTextBoxColumn6.HeaderText = "Width";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "COG_short_side";
            this.dataGridViewTextBoxColumn5.HeaderText = "COG_short_side";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "Rigging_Height_ft";
            this.dataGridViewTextBoxColumn7.HeaderText = "Rigging_Height_ft";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.DataPropertyName = "CraneID";
            this.dataGridViewTextBoxColumn8.HeaderText = "CraneID";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            // 
            // frmAnalytics
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.ClientSize = new System.Drawing.Size(1364, 830);
            this.Controls.Add(this.btnToDB);
            this.Controls.Add(this.btnRetrieveData);
            this.Controls.Add(this.dgv2);
            this.Controls.Add(this.dgv1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmAnalytics";
            this.Text = "frmAnalytics";
            this.Load += new System.EventHandler(this.frmAnalytics_Load);
            this.Leave += new System.EventHandler(this.frmAnalytics_Leave);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgv1;
        private System.Windows.Forms.Button btnRetrieveData;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Type;
        private System.Windows.Forms.DataGridViewTextBoxColumn CraneInfo;
        private System.Windows.Forms.DataGridViewTextBoxColumn MastLength;
        private System.Windows.Forms.DataGridViewTextBoxColumn MastRadius;
        private System.Windows.Forms.DataGridViewTextBoxColumn Rmax;
        private System.Windows.Forms.DataGridViewTextBoxColumn Capacity;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaxEquipmWt;
        private System.Windows.Forms.DataGridViewTextBoxColumn Rigging;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalLiftWeight;
        private System.Windows.Forms.DataGridViewTextBoxColumn PercChartCapacity;
        private System.Windows.Forms.DataGridViewTextBoxColumn WindSpeed;
        private System.Windows.Forms.DataGridViewTextBoxColumn TailswingRadius;
        private System.Windows.Forms.DataGridViewTextBoxColumn TailswingGantry;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaxGBP;
        private System.Windows.Forms.Button btnToDB;
        private System.Windows.Forms.DataGridView dgv2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
    }
}