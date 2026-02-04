namespace JPSCURA
{
    partial class RawMaterial
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            pnlRawmaterial = new Panel();
            dataGridViewemployee = new DataGridView();
            pnlemployeesearch = new Panel();
            rawmsearchbycategory = new TextBox();
            rawmsearchbyname = new TextBox();
            rawmsearchbylocation = new TextBox();
            rawmsearchbypackage = new TextBox();
            rawmsearchbysubcat = new TextBox();
            pnlRawmaterial.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewemployee).BeginInit();
            pnlemployeesearch.SuspendLayout();
            SuspendLayout();
            // 
            // pnlRawmaterial
            // 
            pnlRawmaterial.Controls.Add(dataGridViewemployee);
            pnlRawmaterial.Controls.Add(pnlemployeesearch);
            pnlRawmaterial.Dock = DockStyle.Fill;
            pnlRawmaterial.Location = new Point(0, 0);
            pnlRawmaterial.Name = "pnlRawmaterial";
            pnlRawmaterial.Size = new Size(1280, 741);
            pnlRawmaterial.TabIndex = 0;
            // 
            // dataGridViewemployee
            // 
            dataGridViewemployee.BackgroundColor = Color.White;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = Color.White;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dataGridViewemployee.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewemployee.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewemployee.Dock = DockStyle.Fill;
            dataGridViewemployee.Location = new Point(0, 50);
            dataGridViewemployee.Name = "dataGridViewemployee";
            dataGridViewemployee.Size = new Size(1280, 691);
            dataGridViewemployee.TabIndex = 1;
            // 
            // pnlemployeesearch
            // 
            pnlemployeesearch.BackColor = Color.FromArgb(83, 144, 204);
            pnlemployeesearch.Controls.Add(rawmsearchbycategory);
            pnlemployeesearch.Controls.Add(rawmsearchbyname);
            pnlemployeesearch.Controls.Add(rawmsearchbylocation);
            pnlemployeesearch.Controls.Add(rawmsearchbypackage);
            pnlemployeesearch.Controls.Add(rawmsearchbysubcat);
            pnlemployeesearch.Dock = DockStyle.Top;
            pnlemployeesearch.Location = new Point(0, 0);
            pnlemployeesearch.Name = "pnlemployeesearch";
            pnlemployeesearch.Size = new Size(1280, 50);
            pnlemployeesearch.TabIndex = 0;
            // 
            // rawmsearchbycategory
            // 
            rawmsearchbycategory.Location = new Point(462, 21);
            rawmsearchbycategory.Name = "rawmsearchbycategory";
            rawmsearchbycategory.PlaceholderText = "Search by Categ..";
            rawmsearchbycategory.Size = new Size(100, 23);
            rawmsearchbycategory.TabIndex = 4;
            // 
            // rawmsearchbyname
            // 
            rawmsearchbyname.Location = new Point(106, 21);
            rawmsearchbyname.Name = "rawmsearchbyname";
            rawmsearchbyname.PlaceholderText = "Search by name";
            rawmsearchbyname.Size = new Size(244, 23);
            rawmsearchbyname.TabIndex = 3;
            rawmsearchbyname.TextAlign = HorizontalAlignment.Center;
            // 
            // rawmsearchbylocation
            // 
            rawmsearchbylocation.Location = new Point(356, 21);
            rawmsearchbylocation.Name = "rawmsearchbylocation";
            rawmsearchbylocation.PlaceholderText = "Serach By Locati..";
            rawmsearchbylocation.Size = new Size(100, 23);
            rawmsearchbylocation.TabIndex = 2;
            // 
            // rawmsearchbypackage
            // 
            rawmsearchbypackage.Location = new Point(674, 21);
            rawmsearchbypackage.Name = "rawmsearchbypackage";
            rawmsearchbypackage.PlaceholderText = "Serach by Packa..";
            rawmsearchbypackage.Size = new Size(100, 23);
            rawmsearchbypackage.TabIndex = 1;
            // 
            // rawmsearchbysubcat
            // 
            rawmsearchbysubcat.Location = new Point(568, 21);
            rawmsearchbysubcat.Name = "rawmsearchbysubcat";
            rawmsearchbysubcat.PlaceholderText = "Search by Subca..";
            rawmsearchbysubcat.Size = new Size(100, 23);
            rawmsearchbysubcat.TabIndex = 0;
            // 
            // RawMaterial
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1280, 741);
            Controls.Add(pnlRawmaterial);
            FormBorderStyle = FormBorderStyle.None;
            Name = "RawMaterial";
            Text = "RawMaterial";
            Load += RawMaterial_Load;
            pnlRawmaterial.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridViewemployee).EndInit();
            pnlemployeesearch.ResumeLayout(false);
            pnlemployeesearch.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlRawmaterial;
        private Panel pnlemployeesearch;
        private DataGridView dataGridViewemployee;
        private TextBox rawmsearchbycategory;
        private TextBox rawmsearchbyname;
        private TextBox rawmsearchbylocation;
        private TextBox rawmsearchbypackage;
        private TextBox rawmsearchbysubcat;
    }
}