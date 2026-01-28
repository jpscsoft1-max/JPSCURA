namespace JPSCURA
{
    partial class SemiFinishedGoods
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
            panelMainContent = new Panel();
            dgv = new DataGridView();
            panelTopMenu = new Panel();
            txtpackage = new TextBox();
            txtsubcategory = new TextBox();
            txtcategory = new TextBox();
            txtLocation = new TextBox();
            txtMaterialname = new TextBox();
            panelMainContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgv).BeginInit();
            panelTopMenu.SuspendLayout();
            SuspendLayout();
            // 
            // panelMainContent
            // 
            panelMainContent.Controls.Add(dgv);
            panelMainContent.Controls.Add(panelTopMenu);
            panelMainContent.Dock = DockStyle.Fill;
            panelMainContent.Location = new Point(0, 0);
            panelMainContent.Name = "panelMainContent";
            panelMainContent.Size = new Size(1274, 685);
            panelMainContent.TabIndex = 0;
            // 
            // dgv
            // 
            dgv.BackgroundColor = Color.White;
            dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv.Dock = DockStyle.Fill;
            dgv.Location = new Point(0, 50);
            dgv.Name = "dgv";
            dgv.Size = new Size(1274, 635);
            dgv.TabIndex = 1;
            // 
            // panelTopMenu
            // 
            panelTopMenu.BackColor = Color.FromArgb(83, 144, 204);
            panelTopMenu.Controls.Add(txtpackage);
            panelTopMenu.Controls.Add(txtsubcategory);
            panelTopMenu.Controls.Add(txtcategory);
            panelTopMenu.Controls.Add(txtLocation);
            panelTopMenu.Controls.Add(txtMaterialname);
            panelTopMenu.Dock = DockStyle.Top;
            panelTopMenu.Location = new Point(0, 0);
            panelTopMenu.Name = "panelTopMenu";
            panelTopMenu.Size = new Size(1274, 50);
            panelTopMenu.TabIndex = 0;
            // 
            // txtpackage
            // 
            txtpackage.Location = new Point(799, 14);
            txtpackage.Name = "txtpackage";
            txtpackage.PlaceholderText = "   Search By Package";
            txtpackage.Size = new Size(100, 23);
            txtpackage.TabIndex = 19;
            // 
            // txtsubcategory
            // 
            txtsubcategory.Location = new Point(693, 14);
            txtsubcategory.Name = "txtsubcategory";
            txtsubcategory.PlaceholderText = "   Search By Category";
            txtsubcategory.Size = new Size(100, 23);
            txtsubcategory.TabIndex = 18;
            // 
            // txtcategory
            // 
            txtcategory.Location = new Point(587, 14);
            txtcategory.Name = "txtcategory";
            txtcategory.PlaceholderText = "   Search By Category";
            txtcategory.Size = new Size(100, 23);
            txtcategory.TabIndex = 17;
            // 
            // txtLocation
            // 
            txtLocation.Location = new Point(481, 14);
            txtLocation.Name = "txtLocation";
            txtLocation.PlaceholderText = "   Search By Location";
            txtLocation.Size = new Size(100, 23);
            txtLocation.TabIndex = 16;
            // 
            // txtMaterialname
            // 
            txtMaterialname.Location = new Point(375, 14);
            txtMaterialname.Name = "txtMaterialname";
            txtMaterialname.PlaceholderText = "   Search By Material Name";
            txtMaterialname.Size = new Size(100, 23);
            txtMaterialname.TabIndex = 15;
            // 
            // SemiFinishedGoods
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1274, 685);
            Controls.Add(panelMainContent);
            FormBorderStyle = FormBorderStyle.None;
            Name = "SemiFinishedGoods";
            Text = "SemiFinishedGoods";
            Load += SemiFinishedGoods_Load;
            Resize += SemiFinishedGoods_Resize;
            panelMainContent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgv).EndInit();
            panelTopMenu.ResumeLayout(false);
            panelTopMenu.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelMainContent;
        private DataGridView dgv;
        private Panel panelTopMenu;
        private TextBox txtpackage;
        private TextBox txtsubcategory;
        private TextBox txtcategory;
        private TextBox txtLocation;
        private TextBox txtMaterialname;
    }
}