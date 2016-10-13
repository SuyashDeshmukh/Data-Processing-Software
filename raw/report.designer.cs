namespace Project
{
    partial class report
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(report));
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.FromDate = new System.Windows.Forms.DateTimePicker();
            this.ToDate = new System.Windows.Forms.DateTimePicker();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.GenerateReport = new System.Windows.Forms.Button();
            this.ClearReport = new System.Windows.Forms.Button();
            this.ExportToExcel = new System.Windows.Forms.Button();
            this.Exit = new System.Windows.Forms.Button();
            this.reportView = new System.Windows.Forms.DataGridView();
            this.reportView1 = new System.Windows.Forms.DataGridView();
            this.GenerateGraphs = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.reportView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.reportView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(170, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Report Type";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Reports for stations with complete statistics for the received burst"});
            this.comboBox1.Location = new System.Drawing.Point(264, 36);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(358, 21);
            this.comboBox1.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(170, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Date Range";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(173, 97);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "From Date";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(173, 126);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "To Date";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // FromDate
            // 
            this.FromDate.Location = new System.Drawing.Point(264, 91);
            this.FromDate.Name = "FromDate";
            this.FromDate.Size = new System.Drawing.Size(202, 20);
            this.FromDate.TabIndex = 5;
            // 
            // ToDate
            // 
            this.ToDate.Location = new System.Drawing.Point(264, 120);
            this.ToDate.Name = "ToDate";
            this.ToDate.Size = new System.Drawing.Size(202, 20);
            this.ToDate.TabIndex = 6;
            this.ToDate.ValueChanged += new System.EventHandler(this.dateTimePicker2_ValueChanged);
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "Current hour"});
            this.comboBox2.Location = new System.Drawing.Point(264, 66);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(202, 21);
            this.comboBox2.TabIndex = 7;
            this.comboBox2.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // GenerateReport
            // 
            this.GenerateReport.Location = new System.Drawing.Point(237, 156);
            this.GenerateReport.Name = "GenerateReport";
            this.GenerateReport.Size = new System.Drawing.Size(154, 33);
            this.GenerateReport.TabIndex = 9;
            this.GenerateReport.Text = "Generate Report";
            this.GenerateReport.UseVisualStyleBackColor = true;
            this.GenerateReport.Click += new System.EventHandler(this.GenerateReport_Click);
            // 
            // ClearReport
            // 
            this.ClearReport.Location = new System.Drawing.Point(27, 548);
            this.ClearReport.Name = "ClearReport";
            this.ClearReport.Size = new System.Drawing.Size(106, 37);
            this.ClearReport.TabIndex = 10;
            this.ClearReport.Text = "Clear Reoprt";
            this.ClearReport.UseVisualStyleBackColor = true;
            this.ClearReport.Click += new System.EventHandler(this.ClearReport_Click);
            // 
            // ExportToExcel
            // 
            this.ExportToExcel.Location = new System.Drawing.Point(200, 548);
            this.ExportToExcel.Name = "ExportToExcel";
            this.ExportToExcel.Size = new System.Drawing.Size(95, 37);
            this.ExportToExcel.TabIndex = 11;
            this.ExportToExcel.Text = "Export Report to Excel";
            this.ExportToExcel.UseVisualStyleBackColor = true;
            this.ExportToExcel.Click += new System.EventHandler(this.ExportToExcel_Click);
            // 
            // Exit
            // 
            this.Exit.Location = new System.Drawing.Point(512, 548);
            this.Exit.Name = "Exit";
            this.Exit.Size = new System.Drawing.Size(103, 37);
            this.Exit.TabIndex = 12;
            this.Exit.Text = "Exit to Main Form";
            this.Exit.UseVisualStyleBackColor = true;
            this.Exit.Click += new System.EventHandler(this.Exit_Click);
            // 
            // reportView
            // 
            this.reportView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.reportView.Location = new System.Drawing.Point(27, 226);
            this.reportView.Name = "reportView";
            this.reportView.Size = new System.Drawing.Size(272, 298);
            this.reportView.TabIndex = 13;
            this.reportView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.reportView_CellContentClick);
            // 
            // reportView1
            // 
            this.reportView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.reportView1.Location = new System.Drawing.Point(343, 226);
            this.reportView1.Name = "reportView1";
            this.reportView1.ReadOnly = true;
            this.reportView1.Size = new System.Drawing.Size(272, 298);
            this.reportView1.TabIndex = 14;
            // 
            // GenerateGraphs
            // 
            this.GenerateGraphs.Location = new System.Drawing.Point(344, 548);
            this.GenerateGraphs.Name = "GenerateGraphs";
            this.GenerateGraphs.Size = new System.Drawing.Size(110, 37);
            this.GenerateGraphs.TabIndex = 15;
            this.GenerateGraphs.Text = "Generate Graphs";
            this.GenerateGraphs.UseVisualStyleBackColor = true;
            this.GenerateGraphs.Click += new System.EventHandler(this.GenerateGraphs_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(74, 200);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(183, 19);
            this.label5.TabIndex = 16;
            this.label5.Text = "List of Functional Stations";
            this.label5.Click += new System.EventHandler(this.label5_Click_1);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(376, 200);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(216, 19);
            this.label6.TabIndex = 17;
            this.label6.Text = "List of Non-Functional Stations";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(27, 36);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(117, 143);
            this.pictureBox1.TabIndex = 18;
            this.pictureBox1.TabStop = false;
            // 
            // report
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(646, 610);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.GenerateGraphs);
            this.Controls.Add(this.reportView1);
            this.Controls.Add(this.reportView);
            this.Controls.Add(this.Exit);
            this.Controls.Add(this.ExportToExcel);
            this.Controls.Add(this.ClearReport);
            this.Controls.Add(this.GenerateReport);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.ToDate);
            this.Controls.Add(this.FromDate);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label1);
            this.Name = "report";
            this.Text = "Form3";
            this.Load += new System.EventHandler(this.report_Load);
            ((System.ComponentModel.ISupportInitialize)(this.reportView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.reportView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker FromDate;
        private System.Windows.Forms.DateTimePicker ToDate;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Button GenerateReport;
        private System.Windows.Forms.Button ClearReport;
        private System.Windows.Forms.Button ExportToExcel;
        private System.Windows.Forms.Button Exit;
        private System.Windows.Forms.DataGridView reportView;
        private System.Windows.Forms.DataGridView reportView1;
        private System.Windows.Forms.Button GenerateGraphs;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}