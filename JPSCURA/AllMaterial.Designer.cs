namespace JPSCURA
{
    partial class AllMaterial
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
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            panel2ndtableTopContent = new Panel();
            btnAddNew = new Button();
            btnBack = new Button();
            panelMainContent = new Panel();
            DgvMainTable = new DataGridView();
            ColSrNo = new DataGridViewTextBoxColumn();
            ColMaterialName = new DataGridViewLinkColumn();
            colLocation = new DataGridViewTextBoxColumn();
            ColCategory = new DataGridViewTextBoxColumn();
            ColSubCategory = new DataGridViewTextBoxColumn();
            ColPackage = new DataGridViewTextBoxColumn();
            ColumnBalance = new DataGridViewTextBoxColumn();
            panelSearch = new Panel();
            btnImport = new Button();
            btnExport = new Button();
            txtSearchType = new TextBox();
            txtSearchPackage = new TextBox();
            txtSearchSubCategory = new TextBox();
            txtSearchCategory = new TextBox();
            txtSearchLocation = new TextBox();
            txtSearchMaterial = new TextBox();
            panel2ndTable = new Panel();
            dgv2ndTable = new DataGridView();
            ColumSrNo = new DataGridViewTextBoxColumn();
            ColDate = new DataGridViewTextBoxColumn();
            ColVoucherorBillNo = new DataGridViewTextBoxColumn();
            ColReciept = new DataGridViewTextBoxColumn();
            ColIssued = new DataGridViewTextBoxColumn();
            ColRate = new DataGridViewTextBoxColumn();
            ColBalance = new DataGridViewTextBoxColumn();
            ColTotalValue = new DataGridViewTextBoxColumn();
            panel2ndtableTopContent.SuspendLayout();
            panelMainContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)DgvMainTable).BeginInit();
            panelSearch.SuspendLayout();
            panel2ndTable.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgv2ndTable).BeginInit();
            SuspendLayout();
            // 
            // panel2ndtableTopContent
            // 
            panel2ndtableTopContent.BackColor = Color.RoyalBlue;
            panel2ndtableTopContent.Controls.Add(btnAddNew);
            panel2ndtableTopContent.Controls.Add(btnBack);
            panel2ndtableTopContent.Dock = DockStyle.Top;
            panel2ndtableTopContent.Location = new Point(0, 0);
            panel2ndtableTopContent.Name = "panel2ndtableTopContent";
            panel2ndtableTopContent.Size = new Size(1354, 50);
            panel2ndtableTopContent.TabIndex = 2;
            // 
            // btnAddNew
            // 
            btnAddNew.BackColor = Color.Green;
            btnAddNew.Cursor = Cursors.Hand;
            btnAddNew.FlatAppearance.BorderSize = 0;
            btnAddNew.FlatStyle = FlatStyle.Flat;
            btnAddNew.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAddNew.ForeColor = Color.White;
            btnAddNew.Location = new Point(12, 12);
            btnAddNew.Name = "btnAddNew";
            btnAddNew.Size = new Size(105, 29);
            btnAddNew.TabIndex = 7;
            btnAddNew.Text = "Add New";
            btnAddNew.UseVisualStyleBackColor = false;
            btnAddNew.Click += btnAddNew_Click;
            // 
            // btnBack
            // 
            btnBack.Cursor = Cursors.Hand;
            btnBack.Dock = DockStyle.Right;
            btnBack.FlatAppearance.BorderSize = 0;
            btnBack.FlatStyle = FlatStyle.Flat;
            btnBack.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnBack.ForeColor = Color.White;
            btnBack.Location = new Point(1279, 0);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(75, 50);
            btnBack.TabIndex = 6;
            btnBack.Text = "Back";
            btnBack.UseVisualStyleBackColor = true;
            btnBack.Click += btnBack_Click;
            // 
            // panelMainContent
            // 
            panelMainContent.BackColor = Color.RoyalBlue;
            panelMainContent.Controls.Add(DgvMainTable);
            panelMainContent.Dock = DockStyle.Fill;
            panelMainContent.Location = new Point(0, 50);
            panelMainContent.Name = "panelMainContent";
            panelMainContent.Size = new Size(1354, 410);
            panelMainContent.TabIndex = 1;
            // 
            // DgvMainTable
            // 
            DgvMainTable.AllowUserToAddRows = false;
            DgvMainTable.AllowUserToDeleteRows = false;
            DgvMainTable.BackgroundColor = Color.White;
            DgvMainTable.BorderStyle = BorderStyle.None;
            DgvMainTable.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DgvMainTable.Columns.AddRange(new DataGridViewColumn[] { ColSrNo, ColMaterialName, colLocation, ColCategory, ColSubCategory, ColPackage, ColumnBalance });
            DgvMainTable.Dock = DockStyle.Fill;
            DgvMainTable.Location = new Point(0, 0);
            DgvMainTable.MultiSelect = false;
            DgvMainTable.Name = "DgvMainTable";
            DgvMainTable.ReadOnly = true;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Control;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(255, 255, 128);
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            DgvMainTable.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            DgvMainTable.RowHeadersVisible = false;
            DgvMainTable.RowHeadersWidth = 51;
            DgvMainTable.SelectionMode = DataGridViewSelectionMode.CellSelect;
            DgvMainTable.Size = new Size(1354, 410);
            DgvMainTable.TabIndex = 0;
            DgvMainTable.CellClick += DgvMainTable_CellClick;
            DgvMainTable.CellDoubleClick += DgvMainTable_CellDoubleClick;
            DgvMainTable.CellFormatting += DgvMainTable_CellFormatting;
            DgvMainTable.CellMouseDown += DgvMainTable_CellMouseDown;
            DgvMainTable.CellValueChanged += DgvMainTable_CellValueChanged;
            DgvMainTable.ColumnWidthChanged += DgvMainTable_ColumnWidthChanged;
            DgvMainTable.CurrentCellDirtyStateChanged += DgvMainTable_CurrentCellDirtyStateChanged;
            DgvMainTable.Scroll += DgvMainTable_Scroll;
            // 
            // ColSrNo
            // 
            ColSrNo.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            ColSrNo.HeaderText = "Sr No";
            ColSrNo.MinimumWidth = 6;
            ColSrNo.Name = "ColSrNo";
            ColSrNo.ReadOnly = true;
            // 
            // ColMaterialName
            // 
            ColMaterialName.ActiveLinkColor = Color.Black;
            ColMaterialName.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle1.ForeColor = Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = Color.White;
            dataGridViewCellStyle1.SelectionForeColor = Color.Black;
            ColMaterialName.DefaultCellStyle = dataGridViewCellStyle1;
            ColMaterialName.HeaderText = "Material Name";
            ColMaterialName.LinkBehavior = LinkBehavior.HoverUnderline;
            ColMaterialName.LinkColor = Color.Black;
            ColMaterialName.MinimumWidth = 6;
            ColMaterialName.Name = "ColMaterialName";
            ColMaterialName.ReadOnly = true;
            ColMaterialName.TrackVisitedState = false;
            // 
            // colLocation
            // 
            colLocation.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colLocation.HeaderText = "Location";
            colLocation.MinimumWidth = 6;
            colLocation.Name = "colLocation";
            colLocation.ReadOnly = true;
            // 
            // ColCategory
            // 
            ColCategory.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            ColCategory.HeaderText = "Category";
            ColCategory.MinimumWidth = 6;
            ColCategory.Name = "ColCategory";
            ColCategory.ReadOnly = true;
            // 
            // ColSubCategory
            // 
            ColSubCategory.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            ColSubCategory.HeaderText = "Sub Category";
            ColSubCategory.MinimumWidth = 6;
            ColSubCategory.Name = "ColSubCategory";
            ColSubCategory.ReadOnly = true;
            // 
            // ColPackage
            // 
            ColPackage.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            ColPackage.HeaderText = "Package";
            ColPackage.MinimumWidth = 6;
            ColPackage.Name = "ColPackage";
            ColPackage.ReadOnly = true;
            // 
            // ColumnBalance
            // 
            ColumnBalance.HeaderText = "Balance";
            ColumnBalance.MinimumWidth = 6;
            ColumnBalance.Name = "ColumnBalance";
            ColumnBalance.ReadOnly = true;
            ColumnBalance.Width = 125;
            // 
            // panelSearch
            // 
            panelSearch.BackColor = Color.RoyalBlue;
            panelSearch.Controls.Add(panel2ndtableTopContent);
            panelSearch.Controls.Add(btnImport);
            panelSearch.Controls.Add(btnExport);
            panelSearch.Controls.Add(txtSearchType);
            panelSearch.Controls.Add(txtSearchPackage);
            panelSearch.Controls.Add(txtSearchSubCategory);
            panelSearch.Controls.Add(txtSearchCategory);
            panelSearch.Controls.Add(txtSearchLocation);
            panelSearch.Controls.Add(txtSearchMaterial);
            panelSearch.Dock = DockStyle.Top;
            panelSearch.Location = new Point(0, 0);
            panelSearch.Name = "panelSearch";
            panelSearch.Size = new Size(1354, 50);
            panelSearch.TabIndex = 2;
            // 
            // btnImport
            // 
            btnImport.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnImport.AutoSize = true;
            btnImport.Cursor = Cursors.Hand;
            btnImport.FlatAppearance.BorderSize = 0;
            btnImport.FlatStyle = FlatStyle.Flat;
            btnImport.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnImport.ForeColor = Color.White;
            btnImport.Image = Properties.Resources.icons8_export_excel_25;
            btnImport.ImageAlign = ContentAlignment.MiddleLeft;
            btnImport.Location = new Point(1145, 0);
            btnImport.Name = "btnImport";
            btnImport.Size = new Size(97, 50);
            btnImport.TabIndex = 24;
            btnImport.Text = "Import";
            btnImport.TextAlign = ContentAlignment.MiddleRight;
            btnImport.UseVisualStyleBackColor = true;
            btnImport.Click += btnImport_Click;
            // 
            // btnExport
            // 
            btnExport.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnExport.AutoSize = true;
            btnExport.Cursor = Cursors.Hand;
            btnExport.FlatAppearance.BorderSize = 0;
            btnExport.FlatStyle = FlatStyle.Flat;
            btnExport.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnExport.ForeColor = Color.White;
            btnExport.Image = Properties.Resources.icons8_export_excel_25;
            btnExport.ImageAlign = ContentAlignment.MiddleLeft;
            btnExport.Location = new Point(1257, 0);
            btnExport.Name = "btnExport";
            btnExport.Size = new Size(97, 50);
            btnExport.TabIndex = 23;
            btnExport.Text = "Export";
            btnExport.TextAlign = ContentAlignment.MiddleRight;
            btnExport.UseVisualStyleBackColor = true;
            btnExport.Click += btnExport_Click;
            // 
            // txtSearchType
            // 
            txtSearchType.Location = new Point(224, 12);
            txtSearchType.Name = "txtSearchType";
            txtSearchType.PlaceholderText = "   Search By types Of Material";
            txtSearchType.Size = new Size(100, 23);
            txtSearchType.TabIndex = 5;
            txtSearchType.TextChanged += ApplyMultiSearch;
            // 
            // txtSearchPackage
            // 
            txtSearchPackage.Location = new Point(880, 12);
            txtSearchPackage.Name = "txtSearchPackage";
            txtSearchPackage.PlaceholderText = "   Search By Package";
            txtSearchPackage.Size = new Size(100, 23);
            txtSearchPackage.TabIndex = 4;
            txtSearchPackage.TextChanged += ApplyMultiSearch;
            // 
            // txtSearchSubCategory
            // 
            txtSearchSubCategory.Location = new Point(741, 12);
            txtSearchSubCategory.Name = "txtSearchSubCategory";
            txtSearchSubCategory.PlaceholderText = "   Search By Sub Category";
            txtSearchSubCategory.Size = new Size(100, 23);
            txtSearchSubCategory.TabIndex = 3;
            txtSearchSubCategory.TextChanged += ApplyMultiSearch;
            // 
            // txtSearchCategory
            // 
            txtSearchCategory.Location = new Point(559, 12);
            txtSearchCategory.Name = "txtSearchCategory";
            txtSearchCategory.PlaceholderText = "   Search By Category";
            txtSearchCategory.Size = new Size(100, 23);
            txtSearchCategory.TabIndex = 2;
            txtSearchCategory.TextChanged += ApplyMultiSearch;
            // 
            // txtSearchLocation
            // 
            txtSearchLocation.Location = new Point(393, 12);
            txtSearchLocation.Name = "txtSearchLocation";
            txtSearchLocation.PlaceholderText = "   Search By Location";
            txtSearchLocation.Size = new Size(100, 23);
            txtSearchLocation.TabIndex = 1;
            txtSearchLocation.TextChanged += ApplyMultiSearch;
            // 
            // txtSearchMaterial
            // 
            txtSearchMaterial.Location = new Point(28, 12);
            txtSearchMaterial.Name = "txtSearchMaterial";
            txtSearchMaterial.PlaceholderText = "   Search By Material";
            txtSearchMaterial.Size = new Size(100, 23);
            txtSearchMaterial.TabIndex = 0;
            txtSearchMaterial.TextChanged += ApplyMultiSearch;
            // 
            // panel2ndTable
            // 
            panel2ndTable.Controls.Add(dgv2ndTable);
            panel2ndTable.Dock = DockStyle.Fill;
            panel2ndTable.Location = new Point(0, 50);
            panel2ndTable.Name = "panel2ndTable";
            panel2ndTable.Size = new Size(1354, 410);
            panel2ndTable.TabIndex = 1;
            panel2ndTable.Visible = false;
            // 
            // dgv2ndTable
            // 
            dgv2ndTable.AllowUserToAddRows = false;
            dgv2ndTable.AllowUserToDeleteRows = false;
            dgv2ndTable.AllowUserToResizeColumns = false;
            dgv2ndTable.AllowUserToResizeRows = false;
            dgv2ndTable.BackgroundColor = Color.White;
            dgv2ndTable.BorderStyle = BorderStyle.None;
            dgv2ndTable.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv2ndTable.Columns.AddRange(new DataGridViewColumn[] { ColumSrNo, ColDate, ColVoucherorBillNo, ColReciept, ColIssued, ColRate, ColBalance, ColTotalValue });
            dgv2ndTable.Dock = DockStyle.Fill;
            dgv2ndTable.Location = new Point(0, 0);
            dgv2ndTable.Name = "dgv2ndTable";
            dgv2ndTable.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = SystemColors.Control;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(255, 192, 192);
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            dgv2ndTable.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dgv2ndTable.RowHeadersVisible = false;
            dgv2ndTable.RowHeadersWidth = 51;
            dgv2ndTable.SelectionMode = DataGridViewSelectionMode.CellSelect;
            dgv2ndTable.Size = new Size(1354, 410);
            dgv2ndTable.TabIndex = 0;
            dgv2ndTable.CellBeginEdit += dgv2ndTable_CellBeginEdit;
            dgv2ndTable.CellClick += dgv2ndTable_CellClick;
            dgv2ndTable.CellEndEdit += dgv2ndTable_CellEndEdit;
            dgv2ndTable.CellFormatting += dgv2ndTable_CellFormatting;
            dgv2ndTable.CellValueChanged += dgv2ndTable_CellValueChanged;
            dgv2ndTable.CurrentCellDirtyStateChanged += dgv2ndTable_CurrentCellDirtyStateChanged;
            // 
            // ColumSrNo
            // 
            ColumSrNo.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            ColumSrNo.HeaderText = "Sr No";
            ColumSrNo.MinimumWidth = 6;
            ColumSrNo.Name = "ColumSrNo";
            ColumSrNo.ReadOnly = true;
            // 
            // ColDate
            // 
            ColDate.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            ColDate.HeaderText = "Date";
            ColDate.MinimumWidth = 6;
            ColDate.Name = "ColDate";
            ColDate.ReadOnly = true;
            // 
            // ColVoucherorBillNo
            // 
            ColVoucherorBillNo.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            ColVoucherorBillNo.HeaderText = "Voucher/Bill No";
            ColVoucherorBillNo.MinimumWidth = 6;
            ColVoucherorBillNo.Name = "ColVoucherorBillNo";
            ColVoucherorBillNo.ReadOnly = true;
            // 
            // ColReciept
            // 
            ColReciept.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            ColReciept.HeaderText = "Reciept";
            ColReciept.MinimumWidth = 6;
            ColReciept.Name = "ColReciept";
            ColReciept.ReadOnly = true;
            // 
            // ColIssued
            // 
            ColIssued.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            ColIssued.HeaderText = "Issued";
            ColIssued.MinimumWidth = 6;
            ColIssued.Name = "ColIssued";
            ColIssued.ReadOnly = true;
            // 
            // ColRate
            // 
            ColRate.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            ColRate.HeaderText = "Rate";
            ColRate.MinimumWidth = 6;
            ColRate.Name = "ColRate";
            ColRate.ReadOnly = true;
            // 
            // ColBalance
            // 
            ColBalance.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            ColBalance.HeaderText = "Balance";
            ColBalance.MinimumWidth = 6;
            ColBalance.Name = "ColBalance";
            ColBalance.ReadOnly = true;
            // 
            // ColTotalValue
            // 
            ColTotalValue.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            ColTotalValue.HeaderText = "Total Value";
            ColTotalValue.MinimumWidth = 6;
            ColTotalValue.Name = "ColTotalValue";
            ColTotalValue.ReadOnly = true;
            // 
            // AllMaterial
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1354, 460);
            Controls.Add(panel2ndTable);
            Controls.Add(panelMainContent);
            Controls.Add(panelSearch);
            FormBorderStyle = FormBorderStyle.None;
            Name = "AllMaterial";
            Text = "AllMaterial";
            Load += AllMaterial_Load;
            Resize += AllMaterial_Resize;
            panel2ndtableTopContent.ResumeLayout(false);
            panelMainContent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)DgvMainTable).EndInit();
            panelSearch.ResumeLayout(false);
            panelSearch.PerformLayout();
            panel2ndTable.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgv2ndTable).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Panel panelMainContent;
        private DataGridView DgvMainTable;
        private Panel panel2ndTable;
        private DataGridView dgv2ndTable;
        private DataGridViewTextBoxColumn ColSrNo;
        private DataGridViewLinkColumn ColMaterialName;
        private DataGridViewTextBoxColumn colLocation;
        private DataGridViewTextBoxColumn ColCategory;
        private DataGridViewTextBoxColumn ColSubCategory;
        private DataGridViewTextBoxColumn ColPackage;
        private DataGridViewTextBoxColumn ColumnBalance;
        private DataGridViewTextBoxColumn ColumSrNo;
        private DataGridViewTextBoxColumn ColDate;
        private DataGridViewTextBoxColumn ColVoucherorBillNo;
        private DataGridViewTextBoxColumn ColReciept;
        private DataGridViewTextBoxColumn ColIssued;
        private DataGridViewTextBoxColumn ColRate;
        private DataGridViewTextBoxColumn ColBalance;
        private DataGridViewTextBoxColumn ColTotalValue;
        private Panel panel2ndtableTopContent;
        private Button btnAddNew;
        private Button btnBack;
        private Panel panelSearch;
        private TextBox txtSearchType;
        private TextBox txtSearchPackage;
        private TextBox txtSearchSubCategory;
        private TextBox txtSearchCategory;
        private TextBox txtSearchLocation;
        private TextBox txtSearchMaterial;
        private Button btnExport;
        private Button btnImport;
    }
}