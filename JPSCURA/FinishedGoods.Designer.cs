namespace JPSCURA
{
    partial class FinishedGoods
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
            dgvFinishedGoods = new DataGridView();
            panelTopMenu = new Panel();
            txtpackage = new TextBox();
            txtsubcategory = new TextBox();
            txtcategory = new TextBox();
            txtLocation = new TextBox();
            txtMaterialname = new TextBox();
            panelMainContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvFinishedGoods).BeginInit();
            panelTopMenu.SuspendLayout();
            SuspendLayout();
            // 
            // panelMainContent
            // 
            panelMainContent.BackColor = Color.White;
            panelMainContent.Controls.Add(dgvFinishedGoods);
            panelMainContent.Controls.Add(panelTopMenu);
            panelMainContent.Dock = DockStyle.Fill;
            panelMainContent.Location = new Point(0, 0);
            panelMainContent.Name = "panelMainContent";
            panelMainContent.Size = new Size(1284, 633);
            panelMainContent.TabIndex = 0;
            // 
            // dgvFinishedGoods
            // 
            dgvFinishedGoods.BackgroundColor = Color.White;
            dgvFinishedGoods.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvFinishedGoods.Dock = DockStyle.Fill;
            dgvFinishedGoods.GridColor = Color.White;
            dgvFinishedGoods.Location = new Point(0, 50);
            dgvFinishedGoods.Name = "dgvFinishedGoods";
            dgvFinishedGoods.Size = new Size(1284, 583);
            dgvFinishedGoods.TabIndex = 1;
            dgvFinishedGoods.ColumnWidthChanged += dgvFinishedGoods_ColumnWidthChanged;
            dgvFinishedGoods.RowPostPaint += dgvFinishedGoods_RowPostPaint;
            dgvFinishedGoods.Resize += FinishedGoods_Resize;
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
            panelTopMenu.Size = new Size(1284, 50);
            panelTopMenu.TabIndex = 0;
            // 
            // txtpackage
            // 
            txtpackage.Location = new Point(804, 14);
            txtpackage.Name = "txtpackage";
            txtpackage.PlaceholderText = "   Search By Package";
            txtpackage.Size = new Size(100, 23);
            txtpackage.TabIndex = 14;
            txtpackage.TextChanged += txtpackage_TextChanged;
            // 
            // txtsubcategory
            // 
            txtsubcategory.Location = new Point(698, 14);
            txtsubcategory.Name = "txtsubcategory";
            txtsubcategory.PlaceholderText = "   Search By Category";
            txtsubcategory.Size = new Size(100, 23);
            txtsubcategory.TabIndex = 13;
            txtsubcategory.TextChanged += txtsubcategory_TextChanged;
            // 
            // txtcategory
            // 
            txtcategory.Location = new Point(592, 14);
            txtcategory.Name = "txtcategory";
            txtcategory.PlaceholderText = "   Search By Category";
            txtcategory.Size = new Size(100, 23);
            txtcategory.TabIndex = 12;
            txtcategory.TextChanged += txtcategory_TextChanged;
            // 
            // txtLocation
            // 
            txtLocation.Location = new Point(486, 14);
            txtLocation.Name = "txtLocation";
            txtLocation.PlaceholderText = "   Search By Location";
            txtLocation.Size = new Size(100, 23);
            txtLocation.TabIndex = 11;
            txtLocation.TextChanged += txtLocation_TextChanged;
            // 
            // txtMaterialname
            // 
            txtMaterialname.Location = new Point(380, 14);
            txtMaterialname.Name = "txtMaterialname";
            txtMaterialname.PlaceholderText = "   Search By Material Name";
            txtMaterialname.Size = new Size(100, 23);
            txtMaterialname.TabIndex = 10;
            txtMaterialname.TextChanged += txtMaterialname_TextChanged;
            // 
            // FinishedGoods
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1284, 633);
            Controls.Add(panelMainContent);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FinishedGoods";
            Text = "FinishedGoods";
            Load += FinishedGoods_Load;
            panelMainContent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvFinishedGoods).EndInit();
            panelTopMenu.ResumeLayout(false);
            panelTopMenu.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelMainContent;
        private Panel panelTopMenu;
        private DataGridView dgvFinishedGoods;
        private TextBox txtpackage;
        private TextBox txtsubcategory;
        private TextBox txtcategory;
        private TextBox txtLocation;
        private TextBox txtMaterialname;
    }
}