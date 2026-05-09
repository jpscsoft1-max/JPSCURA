namespace JPSCURA
{
    partial class purchasequotation
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
            pnlpruchasequotation = new Panel();
            dgvPurchaseQuotation = new DataGridView();
            panel1 = new Panel();
            txtSearchQuotationDate = new TextBox();
            txtSearchQuotationNo = new TextBox();
            txtSearchVendors = new TextBox();
            pnlQuotationButton = new Panel();
            txtFileName = new TextBox();
            btnSubmit = new Button();
            btnClear = new Button();
            btnAttach = new Button();
            tableLayoutPanelPurchaseQuotation = new TableLayoutPanel();
            panelleft = new Panel();
            cmbVendorName = new ComboBox();
            lblVendorName = new Label();
            panelmid = new Panel();
            txtQuotationNo = new TextBox();
            lblQuotationNo = new Label();
            panelRight = new Panel();
            dtQuotationDate = new DateTimePicker();
            lblquotationdate = new Label();
            pnlpruchasequotation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPurchaseQuotation).BeginInit();
            panel1.SuspendLayout();
            pnlQuotationButton.SuspendLayout();
            tableLayoutPanelPurchaseQuotation.SuspendLayout();
            panelleft.SuspendLayout();
            panelmid.SuspendLayout();
            panelRight.SuspendLayout();
            SuspendLayout();
            // 
            // pnlpruchasequotation
            // 
            pnlpruchasequotation.BackColor = Color.White;
            pnlpruchasequotation.Controls.Add(dgvPurchaseQuotation);
            pnlpruchasequotation.Controls.Add(panel1);
            pnlpruchasequotation.Controls.Add(pnlQuotationButton);
            pnlpruchasequotation.Controls.Add(tableLayoutPanelPurchaseQuotation);
            pnlpruchasequotation.Dock = DockStyle.Fill;
            pnlpruchasequotation.Location = new Point(0, 0);
            pnlpruchasequotation.Name = "pnlpruchasequotation";
            pnlpruchasequotation.Size = new Size(1386, 677);
            pnlpruchasequotation.TabIndex = 0;
            // 
            // dgvPurchaseQuotation
            // 
            dgvPurchaseQuotation.BackgroundColor = Color.White;
            dgvPurchaseQuotation.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPurchaseQuotation.Dock = DockStyle.Fill;
            dgvPurchaseQuotation.Location = new Point(0, 159);
            dgvPurchaseQuotation.Name = "dgvPurchaseQuotation";
            dgvPurchaseQuotation.Size = new Size(1386, 518);
            dgvPurchaseQuotation.TabIndex = 3;
            dgvPurchaseQuotation.CellClick += dgvPurchaseQuotation_CellClick;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(82, 144, 204);
            panel1.Controls.Add(txtSearchQuotationDate);
            panel1.Controls.Add(txtSearchQuotationNo);
            panel1.Controls.Add(txtSearchVendors);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 109);
            panel1.Name = "panel1";
            panel1.Size = new Size(1386, 50);
            panel1.TabIndex = 2;
            // 
            // txtSearchQuotationDate
            // 
            txtSearchQuotationDate.Location = new Point(749, 14);
            txtSearchQuotationDate.Name = "txtSearchQuotationDate";
            txtSearchQuotationDate.PlaceholderText = "   Search By Quotation Date";
            txtSearchQuotationDate.Size = new Size(100, 23);
            txtSearchQuotationDate.TabIndex = 32;
            // 
            // txtSearchQuotationNo
            // 
            txtSearchQuotationNo.Location = new Point(643, 14);
            txtSearchQuotationNo.Name = "txtSearchQuotationNo";
            txtSearchQuotationNo.PlaceholderText = "   Search By Quotation  No";
            txtSearchQuotationNo.Size = new Size(100, 23);
            txtSearchQuotationNo.TabIndex = 31;
            // 
            // txtSearchVendors
            // 
            txtSearchVendors.Location = new Point(537, 14);
            txtSearchVendors.Name = "txtSearchVendors";
            txtSearchVendors.PlaceholderText = "   Search By Vendor Name";
            txtSearchVendors.Size = new Size(100, 23);
            txtSearchVendors.TabIndex = 30;
            // 
            // pnlQuotationButton
            // 
            pnlQuotationButton.BackColor = Color.FromArgb(83, 144, 204);
            pnlQuotationButton.Controls.Add(txtFileName);
            pnlQuotationButton.Controls.Add(btnSubmit);
            pnlQuotationButton.Controls.Add(btnClear);
            pnlQuotationButton.Controls.Add(btnAttach);
            pnlQuotationButton.Dock = DockStyle.Top;
            pnlQuotationButton.Location = new Point(0, 67);
            pnlQuotationButton.Name = "pnlQuotationButton";
            pnlQuotationButton.Size = new Size(1386, 42);
            pnlQuotationButton.TabIndex = 1;
            // 
            // txtFileName
            // 
            txtFileName.Location = new Point(348, 9);
            txtFileName.Name = "txtFileName";
            txtFileName.PlaceholderText = "File must be belove 5MB";
            txtFileName.ReadOnly = true;
            txtFileName.Size = new Size(196, 23);
            txtFileName.TabIndex = 34;
            txtFileName.TextAlign = HorizontalAlignment.Center;
            // 
            // btnSubmit
            // 
            btnSubmit.Anchor = AnchorStyles.Top;
            btnSubmit.BackColor = Color.LimeGreen;
            btnSubmit.FlatAppearance.BorderSize = 0;
            btnSubmit.FlatStyle = FlatStyle.Flat;
            btnSubmit.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSubmit.ForeColor = Color.White;
            btnSubmit.Location = new Point(652, 6);
            btnSubmit.Name = "btnSubmit";
            btnSubmit.Size = new Size(89, 29);
            btnSubmit.TabIndex = 33;
            btnSubmit.Text = "Submit";
            btnSubmit.UseVisualStyleBackColor = false;
            btnSubmit.Click += btnSubmit_Click;
            // 
            // btnClear
            // 
            btnClear.Anchor = AnchorStyles.Top;
            btnClear.BackColor = Color.LightSalmon;
            btnClear.Cursor = Cursors.Hand;
            btnClear.FlatAppearance.BorderSize = 0;
            btnClear.FlatAppearance.MouseDownBackColor = Color.Red;
            btnClear.FlatAppearance.MouseOverBackColor = Color.Red;
            btnClear.FlatStyle = FlatStyle.Flat;
            btnClear.Font = new Font("Arial", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnClear.ForeColor = Color.SeaShell;
            btnClear.Location = new Point(749, 7);
            btnClear.Margin = new Padding(3, 2, 3, 2);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(89, 29);
            btnClear.TabIndex = 32;
            btnClear.Text = "Clear";
            btnClear.UseVisualStyleBackColor = false;
            btnClear.Click += btnClear_Click;
            // 
            // btnAttach
            // 
            btnAttach.Anchor = AnchorStyles.Top;
            btnAttach.BackColor = Color.Gray;
            btnAttach.FlatAppearance.BorderSize = 0;
            btnAttach.FlatStyle = FlatStyle.Flat;
            btnAttach.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAttach.ForeColor = Color.White;
            btnAttach.Location = new Point(554, 6);
            btnAttach.Name = "btnAttach";
            btnAttach.Size = new Size(89, 29);
            btnAttach.TabIndex = 0;
            btnAttach.Text = "Attach";
            btnAttach.UseVisualStyleBackColor = false;
            btnAttach.Click += btnAttach_Click;
            // 
            // tableLayoutPanelPurchaseQuotation
            // 
            tableLayoutPanelPurchaseQuotation.BackColor = Color.FromArgb(83, 144, 204);
            tableLayoutPanelPurchaseQuotation.ColumnCount = 3;
            tableLayoutPanelPurchaseQuotation.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanelPurchaseQuotation.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333359F));
            tableLayoutPanelPurchaseQuotation.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333359F));
            tableLayoutPanelPurchaseQuotation.Controls.Add(panelleft, 0, 0);
            tableLayoutPanelPurchaseQuotation.Controls.Add(panelmid, 1, 0);
            tableLayoutPanelPurchaseQuotation.Controls.Add(panelRight, 2, 0);
            tableLayoutPanelPurchaseQuotation.Dock = DockStyle.Top;
            tableLayoutPanelPurchaseQuotation.Location = new Point(0, 0);
            tableLayoutPanelPurchaseQuotation.Margin = new Padding(3, 2, 3, 2);
            tableLayoutPanelPurchaseQuotation.Name = "tableLayoutPanelPurchaseQuotation";
            tableLayoutPanelPurchaseQuotation.RowCount = 1;
            tableLayoutPanelPurchaseQuotation.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanelPurchaseQuotation.Size = new Size(1386, 67);
            tableLayoutPanelPurchaseQuotation.TabIndex = 0;
            // 
            // panelleft
            // 
            panelleft.Controls.Add(cmbVendorName);
            panelleft.Controls.Add(lblVendorName);
            panelleft.Dock = DockStyle.Fill;
            panelleft.Location = new Point(3, 3);
            panelleft.Name = "panelleft";
            panelleft.Size = new Size(455, 61);
            panelleft.TabIndex = 0;
            // 
            // cmbVendorName
            // 
            cmbVendorName.FormattingEnabled = true;
            cmbVendorName.Location = new Point(143, 18);
            cmbVendorName.Name = "cmbVendorName";
            cmbVendorName.Size = new Size(283, 23);
            cmbVendorName.TabIndex = 44;
            // 
            // lblVendorName
            // 
            lblVendorName.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblVendorName.ForeColor = Color.White;
            lblVendorName.Location = new Point(15, 18);
            lblVendorName.Name = "lblVendorName";
            lblVendorName.Size = new Size(122, 22);
            lblVendorName.TabIndex = 43;
            lblVendorName.Text = "Vendor Name :";
            lblVendorName.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // panelmid
            // 
            panelmid.Controls.Add(txtQuotationNo);
            panelmid.Controls.Add(lblQuotationNo);
            panelmid.Dock = DockStyle.Fill;
            panelmid.Location = new Point(464, 3);
            panelmid.Name = "panelmid";
            panelmid.Size = new Size(456, 61);
            panelmid.TabIndex = 1;
            // 
            // txtQuotationNo
            // 
            txtQuotationNo.Anchor = AnchorStyles.Top;
            txtQuotationNo.Location = new Point(150, 18);
            txtQuotationNo.Name = "txtQuotationNo";
            txtQuotationNo.PlaceholderText = "   Quotation No";
            txtQuotationNo.Size = new Size(283, 23);
            txtQuotationNo.TabIndex = 3;
            // 
            // lblQuotationNo
            // 
            lblQuotationNo.Anchor = AnchorStyles.Top;
            lblQuotationNo.AutoSize = true;
            lblQuotationNo.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblQuotationNo.ForeColor = Color.White;
            lblQuotationNo.Location = new Point(15, 18);
            lblQuotationNo.Name = "lblQuotationNo";
            lblQuotationNo.Size = new Size(120, 19);
            lblQuotationNo.TabIndex = 2;
            lblQuotationNo.Text = "Quotation No :";
            // 
            // panelRight
            // 
            panelRight.BackColor = Color.FromArgb(83, 144, 204);
            panelRight.Controls.Add(dtQuotationDate);
            panelRight.Controls.Add(lblquotationdate);
            panelRight.Dock = DockStyle.Fill;
            panelRight.Location = new Point(926, 3);
            panelRight.Name = "panelRight";
            panelRight.Size = new Size(457, 61);
            panelRight.TabIndex = 2;
            // 
            // dtQuotationDate
            // 
            dtQuotationDate.Location = new Point(156, 18);
            dtQuotationDate.Name = "dtQuotationDate";
            dtQuotationDate.Size = new Size(283, 23);
            dtQuotationDate.TabIndex = 5;
            // 
            // lblquotationdate
            // 
            lblquotationdate.AutoSize = true;
            lblquotationdate.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblquotationdate.ForeColor = Color.White;
            lblquotationdate.Location = new Point(15, 18);
            lblquotationdate.Name = "lblquotationdate";
            lblquotationdate.Size = new Size(133, 19);
            lblquotationdate.TabIndex = 4;
            lblquotationdate.Text = "Quotation Date :";
            // 
            // purchasequotation
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1386, 677);
            Controls.Add(pnlpruchasequotation);
            FormBorderStyle = FormBorderStyle.None;
            Name = "purchasequotation";
            Text = "purchasequotation";
            Load += purchasequotation_Load;
            pnlpruchasequotation.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvPurchaseQuotation).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            pnlQuotationButton.ResumeLayout(false);
            pnlQuotationButton.PerformLayout();
            tableLayoutPanelPurchaseQuotation.ResumeLayout(false);
            panelleft.ResumeLayout(false);
            panelmid.ResumeLayout(false);
            panelmid.PerformLayout();
            panelRight.ResumeLayout(false);
            panelRight.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlpruchasequotation;
        private Panel pnlQuotationtool;
        private Button btnADDQuotation;
        private Button btnDeleteQuotation;
        private Panel pnl;
        private TableLayoutPanel tableLayoutPanelPurchaseQuotation;
        private Panel panelleft;
        private Panel panelmid;
        private Panel panelRight;
        private Panel pnlQuotationButton;
        private Label lblVendorName;
        private DateTimePicker dtQuotationDate;
        private Label lblquotationdate;
        private Label lblQuotationNo;
        private TextBox txtQuotationNo;
        private Button btnAttach;
        private Button btnClear;
        private Button btnSubmit;
        private Panel panel1;
        private TextBox txtSearchQuotationDate;
        private TextBox txtSearchQuotationNo;
        private TextBox txtSearchVendors;
        private TextBox txtFileName;
        private DataGridView dgvPurchaseQuotation;
        private ComboBox cmbVendorName;
    }
}