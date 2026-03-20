namespace JPSCURA
{
    partial class Salesquotes
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
            panelMain = new Panel();
            dgvSalesQuotation = new DataGridView();
            PanelForSearch = new Panel();
            btnDelete = new Button();
            txtSerachCustomerName = new TextBox();
            btnModify = new Button();
            txtSearchStatus = new TextBox();
            btnADD = new Button();
            txtSearchQuotationNo = new TextBox();
            panelMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvSalesQuotation).BeginInit();
            PanelForSearch.SuspendLayout();
            SuspendLayout();
            // 
            // panelMain
            // 
            panelMain.Controls.Add(dgvSalesQuotation);
            panelMain.Controls.Add(PanelForSearch);
            panelMain.Dock = DockStyle.Fill;
            panelMain.Location = new Point(0, 0);
            panelMain.Name = "panelMain";
            panelMain.Size = new Size(1140, 541);
            panelMain.TabIndex = 0;
            // 
            // dgvSalesQuotation
            // 
            dgvSalesQuotation.BackgroundColor = Color.White;
            dgvSalesQuotation.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSalesQuotation.Dock = DockStyle.Fill;
            dgvSalesQuotation.Location = new Point(0, 50);
            dgvSalesQuotation.Name = "dgvSalesQuotation";
            dgvSalesQuotation.Size = new Size(1140, 491);
            dgvSalesQuotation.TabIndex = 2;
            dgvSalesQuotation.CellClick += dgvSalesQuotation_CellClick;
            dgvSalesQuotation.ColumnWidthChanged += dgvSalesQuotation_ColumnWidthChanged;
            dgvSalesQuotation.CurrentCellDirtyStateChanged += dgvSalesQuotation_CurrentCellDirtyStateChanged;
            dgvSalesQuotation.Scroll += dgvSalesQuotation_Scroll;
            dgvSalesQuotation.Resize += salesquotes_Resize;
            // 
            // PanelForSearch
            // 
            PanelForSearch.BackColor = Color.FromArgb(83, 144, 204);
            PanelForSearch.Controls.Add(btnDelete);
            PanelForSearch.Controls.Add(txtSerachCustomerName);
            PanelForSearch.Controls.Add(btnModify);
            PanelForSearch.Controls.Add(txtSearchStatus);
            PanelForSearch.Controls.Add(btnADD);
            PanelForSearch.Controls.Add(txtSearchQuotationNo);
            PanelForSearch.Dock = DockStyle.Top;
            PanelForSearch.Location = new Point(0, 0);
            PanelForSearch.Name = "PanelForSearch";
            PanelForSearch.Size = new Size(1140, 50);
            PanelForSearch.TabIndex = 1;
            // 
            // btnDelete
            // 
            btnDelete.Cursor = Cursors.Hand;
            btnDelete.Dock = DockStyle.Right;
            btnDelete.FlatAppearance.BorderSize = 0;
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.Font = new Font("Arial", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnDelete.Image = Properties.Resources.trash;
            btnDelete.ImageAlign = ContentAlignment.MiddleLeft;
            btnDelete.Location = new Point(1033, 0);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(107, 50);
            btnDelete.TabIndex = 2;
            btnDelete.Text = "Delete";
            btnDelete.TextAlign = ContentAlignment.MiddleRight;
            btnDelete.UseVisualStyleBackColor = true;
            // 
            // txtSerachCustomerName
            // 
            txtSerachCustomerName.Location = new Point(626, 14);
            txtSerachCustomerName.Name = "txtSerachCustomerName";
            txtSerachCustomerName.PlaceholderText = "   Search By Customer Name";
            txtSerachCustomerName.Size = new Size(100, 23);
            txtSerachCustomerName.TabIndex = 20;
            // 
            // btnModify
            // 
            btnModify.Cursor = Cursors.Hand;
            btnModify.Dock = DockStyle.Left;
            btnModify.FlatAppearance.BorderSize = 0;
            btnModify.FlatStyle = FlatStyle.Flat;
            btnModify.Font = new Font("Arial", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnModify.Image = Properties.Resources.development;
            btnModify.ImageAlign = ContentAlignment.MiddleLeft;
            btnModify.Location = new Point(90, 0);
            btnModify.Name = "btnModify";
            btnModify.Size = new Size(107, 50);
            btnModify.TabIndex = 1;
            btnModify.Text = "Modify";
            btnModify.TextAlign = ContentAlignment.MiddleRight;
            btnModify.UseVisualStyleBackColor = true;
            // 
            // txtSearchStatus
            // 
            txtSearchStatus.Location = new Point(520, 14);
            txtSearchStatus.Name = "txtSearchStatus";
            txtSearchStatus.PlaceholderText = "   Search By Status";
            txtSearchStatus.Size = new Size(100, 23);
            txtSearchStatus.TabIndex = 19;
            // 
            // btnADD
            // 
            btnADD.Cursor = Cursors.Hand;
            btnADD.Dock = DockStyle.Left;
            btnADD.FlatAppearance.BorderSize = 0;
            btnADD.FlatStyle = FlatStyle.Flat;
            btnADD.Font = new Font("Arial", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnADD.Image = Properties.Resources.addition;
            btnADD.ImageAlign = ContentAlignment.MiddleLeft;
            btnADD.Location = new Point(0, 0);
            btnADD.Name = "btnADD";
            btnADD.Size = new Size(90, 50);
            btnADD.TabIndex = 0;
            btnADD.Text = "ADD";
            btnADD.TextAlign = ContentAlignment.MiddleRight;
            btnADD.UseVisualStyleBackColor = true;
            btnADD.Click += btnADD_Click;
            // 
            // txtSearchQuotationNo
            // 
            txtSearchQuotationNo.Location = new Point(414, 14);
            txtSearchQuotationNo.Name = "txtSearchQuotationNo";
            txtSearchQuotationNo.PlaceholderText = "   Search By Quotation Number";
            txtSearchQuotationNo.Size = new Size(100, 23);
            txtSearchQuotationNo.TabIndex = 18;
            // 
            // Salesquotes
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1140, 541);
            Controls.Add(panelMain);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Salesquotes";
            Text = "salesquotes";
            Load += salesquotes_Load;
            panelMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvSalesQuotation).EndInit();
            PanelForSearch.ResumeLayout(false);
            PanelForSearch.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelMain;
        private Button btnADD;
        private Button btnDelete;
        private Button btnModify;
        private Panel PanelForSearch;
        private TextBox txtSerachCustomerName;
        private TextBox txtSearchStatus;
        private TextBox txtSearchQuotationNo;
        private DataGridView dgvSalesQuotation;
    }
}