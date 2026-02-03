namespace JPSCURA
{
    partial class Material
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Material));
            panelMaterial = new Panel();
            tableLayoutPanelMaterial = new TableLayoutPanel();
            panelRight = new Panel();
            txtRate = new TextBox();
            txtParticular = new TextBox();
            lblText = new Label();
            lblMaterialSubCategory = new Label();
            cmbMaterialSubCategory = new ComboBox();
            lblParticular = new Label();
            lblLocation = new Label();
            txtLocation = new TextBox();
            panelLeft = new Panel();
            lblMaxThreshold = new Label();
            txtMaxThreshold = new TextBox();
            lblReciept = new Label();
            dtOpeningDate = new DateTimePicker();
            lblPackage = new Label();
            lblOpeningDate = new Label();
            lblMaterialName = new Label();
            cmbPackage = new ComboBox();
            txtReceipt = new TextBox();
            txtMaterialName = new TextBox();
            panelCenter = new Panel();
            txtMinThreshold = new TextBox();
            lblMinThreshold = new Label();
            cmbMaterialCategory = new ComboBox();
            btnClear = new Button();
            lblMaterialCategory = new Label();
            cmbTypesOfCategory = new ComboBox();
            txtvoucherorbillno = new TextBox();
            lblTypesOfCategory = new Label();
            lblVoucherOrBillNo = new Label();
            txtBalance = new TextBox();
            btnAddMaterial = new Button();
            lblBalance = new Label();
            panelMaterial.SuspendLayout();
            tableLayoutPanelMaterial.SuspendLayout();
            panelRight.SuspendLayout();
            panelLeft.SuspendLayout();
            panelCenter.SuspendLayout();
            SuspendLayout();
            // 
            // panelMaterial
            // 
            panelMaterial.BackColor = Color.RoyalBlue;
            panelMaterial.Controls.Add(tableLayoutPanelMaterial);
            panelMaterial.Dock = DockStyle.Fill;
            panelMaterial.Location = new Point(0, 0);
            panelMaterial.Margin = new Padding(2);
            panelMaterial.Name = "panelMaterial";
            panelMaterial.Size = new Size(1404, 580);
            panelMaterial.TabIndex = 0;
            // 
            // tableLayoutPanelMaterial
            // 
            tableLayoutPanelMaterial.BackColor = Color.FromArgb(83, 144, 204);
            tableLayoutPanelMaterial.ColumnCount = 3;
            tableLayoutPanelMaterial.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33F));
            tableLayoutPanelMaterial.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 34F));
            tableLayoutPanelMaterial.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33F));
            tableLayoutPanelMaterial.Controls.Add(panelRight, 2, 0);
            tableLayoutPanelMaterial.Controls.Add(panelLeft, 0, 0);
            tableLayoutPanelMaterial.Controls.Add(panelCenter, 1, 0);
            tableLayoutPanelMaterial.Dock = DockStyle.Fill;
            tableLayoutPanelMaterial.Location = new Point(0, 0);
            tableLayoutPanelMaterial.Margin = new Padding(3, 2, 3, 2);
            tableLayoutPanelMaterial.Name = "tableLayoutPanelMaterial";
            tableLayoutPanelMaterial.RowCount = 1;
            tableLayoutPanelMaterial.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanelMaterial.RowStyles.Add(new RowStyle(SizeType.Absolute, 15F));
            tableLayoutPanelMaterial.RowStyles.Add(new RowStyle(SizeType.Absolute, 15F));
            tableLayoutPanelMaterial.Size = new Size(1404, 580);
            tableLayoutPanelMaterial.TabIndex = 38;
            // 
            // panelRight
            // 
            panelRight.Controls.Add(txtRate);
            panelRight.Controls.Add(txtParticular);
            panelRight.Controls.Add(lblText);
            panelRight.Controls.Add(lblMaterialSubCategory);
            panelRight.Controls.Add(cmbMaterialSubCategory);
            panelRight.Controls.Add(lblParticular);
            panelRight.Controls.Add(lblLocation);
            panelRight.Controls.Add(txtLocation);
            panelRight.Dock = DockStyle.Fill;
            panelRight.Location = new Point(943, 2);
            panelRight.Margin = new Padding(3, 2, 3, 2);
            panelRight.Name = "panelRight";
            panelRight.Size = new Size(458, 576);
            panelRight.TabIndex = 2;
            // 
            // txtRate
            // 
            txtRate.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtRate.Location = new Point(225, 122);
            txtRate.Margin = new Padding(2);
            txtRate.Multiline = true;
            txtRate.Name = "txtRate";
            txtRate.RightToLeft = RightToLeft.No;
            txtRate.Size = new Size(219, 22);
            txtRate.TabIndex = 20;
            txtRate.TextAlign = HorizontalAlignment.Center;
            // 
            // txtParticular
            // 
            txtParticular.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtParticular.Location = new Point(225, 84);
            txtParticular.Margin = new Padding(2);
            txtParticular.Multiline = true;
            txtParticular.Name = "txtParticular";
            txtParticular.PlaceholderText = "   Write Particular";
            txtParticular.RightToLeft = RightToLeft.No;
            txtParticular.Size = new Size(219, 22);
            txtParticular.TabIndex = 17;
            // 
            // lblText
            // 
            lblText.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblText.AutoSize = true;
            lblText.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblText.ForeColor = Color.White;
            lblText.Location = new Point(18, 126);
            lblText.Margin = new Padding(2, 0, 2, 0);
            lblText.Name = "lblText";
            lblText.Size = new Size(53, 18);
            lblText.TabIndex = 37;
            lblText.Text = "Rate  :";
            lblText.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblMaterialSubCategory
            // 
            lblMaterialSubCategory.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblMaterialSubCategory.AutoSize = true;
            lblMaterialSubCategory.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblMaterialSubCategory.ForeColor = Color.White;
            lblMaterialSubCategory.Location = new Point(16, 22);
            lblMaterialSubCategory.Margin = new Padding(2, 0, 2, 0);
            lblMaterialSubCategory.Name = "lblMaterialSubCategory";
            lblMaterialSubCategory.Size = new Size(172, 18);
            lblMaterialSubCategory.TabIndex = 11;
            lblMaterialSubCategory.Text = "Material Sub Category :";
            lblMaterialSubCategory.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // cmbMaterialSubCategory
            // 
            cmbMaterialSubCategory.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            cmbMaterialSubCategory.Cursor = Cursors.Hand;
            cmbMaterialSubCategory.FormattingEnabled = true;
            cmbMaterialSubCategory.Location = new Point(225, 18);
            cmbMaterialSubCategory.Margin = new Padding(2);
            cmbMaterialSubCategory.Name = "cmbMaterialSubCategory";
            cmbMaterialSubCategory.Size = new Size(219, 23);
            cmbMaterialSubCategory.TabIndex = 11;
            cmbMaterialSubCategory.SelectedIndexChanged += cmbMaterialSubCategory_SelectionChangeCommitted;
            cmbMaterialSubCategory.SelectionChangeCommitted += cmbMaterialSubCategory_SelectionChangeCommitted;
            // 
            // lblParticular
            // 
            lblParticular.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblParticular.AutoSize = true;
            lblParticular.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblParticular.ForeColor = Color.White;
            lblParticular.Location = new Point(16, 88);
            lblParticular.Margin = new Padding(2, 0, 2, 0);
            lblParticular.Name = "lblParticular";
            lblParticular.Size = new Size(82, 18);
            lblParticular.TabIndex = 35;
            lblParticular.Text = "Particular :";
            lblParticular.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblLocation
            // 
            lblLocation.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblLocation.AutoSize = true;
            lblLocation.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblLocation.ForeColor = Color.White;
            lblLocation.Location = new Point(16, 53);
            lblLocation.Margin = new Padding(2, 0, 2, 0);
            lblLocation.Name = "lblLocation";
            lblLocation.Size = new Size(80, 18);
            lblLocation.TabIndex = 19;
            lblLocation.Text = "Location  :";
            lblLocation.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtLocation
            // 
            txtLocation.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtLocation.Location = new Point(225, 50);
            txtLocation.Margin = new Padding(2);
            txtLocation.Multiline = true;
            txtLocation.Name = "txtLocation";
            txtLocation.PlaceholderText = "   ";
            txtLocation.RightToLeft = RightToLeft.No;
            txtLocation.Size = new Size(219, 22);
            txtLocation.TabIndex = 14;
            // 
            // panelLeft
            // 
            panelLeft.Controls.Add(lblMaxThreshold);
            panelLeft.Controls.Add(txtMaxThreshold);
            panelLeft.Controls.Add(lblReciept);
            panelLeft.Controls.Add(dtOpeningDate);
            panelLeft.Controls.Add(lblPackage);
            panelLeft.Controls.Add(lblOpeningDate);
            panelLeft.Controls.Add(lblMaterialName);
            panelLeft.Controls.Add(cmbPackage);
            panelLeft.Controls.Add(txtReceipt);
            panelLeft.Controls.Add(txtMaterialName);
            panelLeft.Dock = DockStyle.Fill;
            panelLeft.Location = new Point(3, 2);
            panelLeft.Margin = new Padding(3, 2, 3, 2);
            panelLeft.Name = "panelLeft";
            panelLeft.Size = new Size(457, 576);
            panelLeft.TabIndex = 0;
            // 
            // lblMaxThreshold
            // 
            lblMaxThreshold.AutoSize = true;
            lblMaxThreshold.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblMaxThreshold.ForeColor = Color.White;
            lblMaxThreshold.Location = new Point(9, 158);
            lblMaxThreshold.Margin = new Padding(2, 0, 2, 0);
            lblMaxThreshold.Name = "lblMaxThreshold";
            lblMaxThreshold.Size = new Size(121, 18);
            lblMaxThreshold.TabIndex = 23;
            lblMaxThreshold.Text = "Max Threshold  :";
            lblMaxThreshold.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtMaxThreshold
            // 
            txtMaxThreshold.Location = new Point(175, 158);
            txtMaxThreshold.Margin = new Padding(2);
            txtMaxThreshold.Multiline = true;
            txtMaxThreshold.Name = "txtMaxThreshold";
            txtMaxThreshold.PlaceholderText = "   ";
            txtMaxThreshold.RightToLeft = RightToLeft.No;
            txtMaxThreshold.Size = new Size(219, 22);
            txtMaxThreshold.TabIndex = 24;
            txtMaxThreshold.KeyPress += txtMaxThreshold_KeyPress;
            // 
            // lblReciept
            // 
            lblReciept.AutoSize = true;
            lblReciept.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblReciept.ForeColor = Color.White;
            lblReciept.Location = new Point(9, 125);
            lblReciept.Margin = new Padding(2, 0, 2, 0);
            lblReciept.Name = "lblReciept";
            lblReciept.Size = new Size(74, 18);
            lblReciept.TabIndex = 15;
            lblReciept.Text = "Reciept  :";
            lblReciept.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // dtOpeningDate
            // 
            dtOpeningDate.Cursor = Cursors.Hand;
            dtOpeningDate.Format = DateTimePickerFormat.Short;
            dtOpeningDate.Location = new Point(175, 55);
            dtOpeningDate.Margin = new Padding(2);
            dtOpeningDate.Name = "dtOpeningDate";
            dtOpeningDate.Size = new Size(219, 23);
            dtOpeningDate.TabIndex = 12;
            // 
            // lblPackage
            // 
            lblPackage.AutoSize = true;
            lblPackage.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblPackage.ForeColor = Color.White;
            lblPackage.Location = new Point(9, 91);
            lblPackage.Margin = new Padding(2, 0, 2, 0);
            lblPackage.Name = "lblPackage";
            lblPackage.Size = new Size(83, 18);
            lblPackage.TabIndex = 22;
            lblPackage.Text = "Package  :";
            lblPackage.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblOpeningDate
            // 
            lblOpeningDate.AutoSize = true;
            lblOpeningDate.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblOpeningDate.ForeColor = Color.White;
            lblOpeningDate.Location = new Point(9, 58);
            lblOpeningDate.Margin = new Padding(2, 0, 2, 0);
            lblOpeningDate.Name = "lblOpeningDate";
            lblOpeningDate.Size = new Size(117, 18);
            lblOpeningDate.TabIndex = 13;
            lblOpeningDate.Text = "Opening Date  :";
            lblOpeningDate.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblMaterialName
            // 
            lblMaterialName.AutoSize = true;
            lblMaterialName.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblMaterialName.ForeColor = Color.White;
            lblMaterialName.Location = new Point(9, 25);
            lblMaterialName.Margin = new Padding(2, 0, 2, 0);
            lblMaterialName.Name = "lblMaterialName";
            lblMaterialName.Size = new Size(118, 18);
            lblMaterialName.TabIndex = 2;
            lblMaterialName.Text = "Material Name :";
            lblMaterialName.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // cmbPackage
            // 
            cmbPackage.Cursor = Cursors.Hand;
            cmbPackage.FormattingEnabled = true;
            cmbPackage.Location = new Point(175, 91);
            cmbPackage.Margin = new Padding(2);
            cmbPackage.Name = "cmbPackage";
            cmbPackage.Size = new Size(219, 23);
            cmbPackage.TabIndex = 15;
            cmbPackage.SelectedIndexChanged += cmbPackage_SelectionChangeCommitted;
            // 
            // txtReceipt
            // 
            txtReceipt.Location = new Point(175, 125);
            txtReceipt.Margin = new Padding(2);
            txtReceipt.Multiline = true;
            txtReceipt.Name = "txtReceipt";
            txtReceipt.PlaceholderText = "   ";
            txtReceipt.RightToLeft = RightToLeft.No;
            txtReceipt.Size = new Size(219, 22);
            txtReceipt.TabIndex = 18;
            txtReceipt.TextChanged += txtReceipt_TextChanged;
            txtReceipt.KeyPress += txtReceipt_KeyPress;
            // 
            // txtMaterialName
            // 
            txtMaterialName.Location = new Point(175, 25);
            txtMaterialName.Margin = new Padding(2);
            txtMaterialName.Multiline = true;
            txtMaterialName.Name = "txtMaterialName";
            txtMaterialName.PlaceholderText = "   Enter Material Name";
            txtMaterialName.RightToLeft = RightToLeft.No;
            txtMaterialName.Size = new Size(219, 22);
            txtMaterialName.TabIndex = 9;
            // 
            // panelCenter
            // 
            panelCenter.Controls.Add(txtMinThreshold);
            panelCenter.Controls.Add(lblMinThreshold);
            panelCenter.Controls.Add(cmbMaterialCategory);
            panelCenter.Controls.Add(btnClear);
            panelCenter.Controls.Add(lblMaterialCategory);
            panelCenter.Controls.Add(cmbTypesOfCategory);
            panelCenter.Controls.Add(txtvoucherorbillno);
            panelCenter.Controls.Add(lblTypesOfCategory);
            panelCenter.Controls.Add(lblVoucherOrBillNo);
            panelCenter.Controls.Add(txtBalance);
            panelCenter.Controls.Add(btnAddMaterial);
            panelCenter.Controls.Add(lblBalance);
            panelCenter.Dock = DockStyle.Fill;
            panelCenter.Location = new Point(466, 2);
            panelCenter.Margin = new Padding(3, 2, 3, 2);
            panelCenter.Name = "panelCenter";
            panelCenter.Size = new Size(471, 576);
            panelCenter.TabIndex = 1;
            // 
            // txtMinThreshold
            // 
            txtMinThreshold.Anchor = AnchorStyles.Top;
            txtMinThreshold.Location = new Point(197, 159);
            txtMinThreshold.Margin = new Padding(2);
            txtMinThreshold.Multiline = true;
            txtMinThreshold.Name = "txtMinThreshold";
            txtMinThreshold.PlaceholderText = "   ";
            txtMinThreshold.RightToLeft = RightToLeft.No;
            txtMinThreshold.Size = new Size(219, 22);
            txtMinThreshold.TabIndex = 33;
            txtMinThreshold.KeyPress += txtMinThreshold_KeyPress;
            // 
            // lblMinThreshold
            // 
            lblMinThreshold.Anchor = AnchorStyles.Top;
            lblMinThreshold.AutoSize = true;
            lblMinThreshold.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblMinThreshold.ForeColor = Color.White;
            lblMinThreshold.Location = new Point(22, 159);
            lblMinThreshold.Margin = new Padding(2, 0, 2, 0);
            lblMinThreshold.Name = "lblMinThreshold";
            lblMinThreshold.Size = new Size(117, 18);
            lblMinThreshold.TabIndex = 32;
            lblMinThreshold.Text = "Min Threshold  :";
            lblMinThreshold.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // cmbMaterialCategory
            // 
            cmbMaterialCategory.Anchor = AnchorStyles.Top;
            cmbMaterialCategory.Cursor = Cursors.Hand;
            cmbMaterialCategory.FormattingEnabled = true;
            cmbMaterialCategory.Location = new Point(197, 22);
            cmbMaterialCategory.Margin = new Padding(2);
            cmbMaterialCategory.Name = "cmbMaterialCategory";
            cmbMaterialCategory.Size = new Size(219, 23);
            cmbMaterialCategory.TabIndex = 10;
            cmbMaterialCategory.SelectedIndexChanged += cmbMaterialCategory_SelectedIndexChanged;
            // 
            // btnClear
            // 
            btnClear.Anchor = AnchorStyles.Top;
            btnClear.AutoSize = true;
            btnClear.BackColor = Color.LimeGreen;
            btnClear.Cursor = Cursors.Hand;
            btnClear.FlatAppearance.BorderSize = 0;
            btnClear.FlatAppearance.MouseDownBackColor = Color.Red;
            btnClear.FlatAppearance.MouseOverBackColor = Color.Red;
            btnClear.FlatStyle = FlatStyle.Flat;
            btnClear.Font = new Font("Arial", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnClear.ForeColor = Color.Black;
            btnClear.Location = new Point(303, 223);
            btnClear.Margin = new Padding(2);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(113, 30);
            btnClear.TabIndex = 23;
            btnClear.Text = "Clear";
            btnClear.UseVisualStyleBackColor = false;
            btnClear.Click += btnClear_Click;
            // 
            // lblMaterialCategory
            // 
            lblMaterialCategory.Anchor = AnchorStyles.Top;
            lblMaterialCategory.AutoSize = true;
            lblMaterialCategory.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblMaterialCategory.ForeColor = Color.White;
            lblMaterialCategory.Location = new Point(22, 23);
            lblMaterialCategory.Margin = new Padding(2, 0, 2, 0);
            lblMaterialCategory.Name = "lblMaterialCategory";
            lblMaterialCategory.Size = new Size(140, 18);
            lblMaterialCategory.TabIndex = 4;
            lblMaterialCategory.Text = "Material Category :";
            lblMaterialCategory.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // cmbTypesOfCategory
            // 
            cmbTypesOfCategory.Anchor = AnchorStyles.Top;
            cmbTypesOfCategory.Cursor = Cursors.Hand;
            cmbTypesOfCategory.FormattingEnabled = true;
            cmbTypesOfCategory.Location = new Point(197, 55);
            cmbTypesOfCategory.Margin = new Padding(2);
            cmbTypesOfCategory.Name = "cmbTypesOfCategory";
            cmbTypesOfCategory.Size = new Size(219, 23);
            cmbTypesOfCategory.TabIndex = 13;
            cmbTypesOfCategory.SelectedIndexChanged += cmbTypesOfCategory_SelectionChangeCommitted;
            // 
            // txtvoucherorbillno
            // 
            txtvoucherorbillno.Anchor = AnchorStyles.Top;
            txtvoucherorbillno.Location = new Point(197, 88);
            txtvoucherorbillno.Margin = new Padding(2);
            txtvoucherorbillno.Multiline = true;
            txtvoucherorbillno.Name = "txtvoucherorbillno";
            txtvoucherorbillno.PlaceholderText = "   ";
            txtvoucherorbillno.RightToLeft = RightToLeft.No;
            txtvoucherorbillno.Size = new Size(219, 22);
            txtvoucherorbillno.TabIndex = 16;
            // 
            // lblTypesOfCategory
            // 
            lblTypesOfCategory.Anchor = AnchorStyles.Top;
            lblTypesOfCategory.AutoSize = true;
            lblTypesOfCategory.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTypesOfCategory.ForeColor = Color.White;
            lblTypesOfCategory.Location = new Point(22, 55);
            lblTypesOfCategory.Margin = new Padding(2, 0, 2, 0);
            lblTypesOfCategory.Name = "lblTypesOfCategory";
            lblTypesOfCategory.Size = new Size(145, 18);
            lblTypesOfCategory.TabIndex = 31;
            lblTypesOfCategory.Text = "Types Of Materials :";
            lblTypesOfCategory.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblVoucherOrBillNo
            // 
            lblVoucherOrBillNo.Anchor = AnchorStyles.Top;
            lblVoucherOrBillNo.AutoSize = true;
            lblVoucherOrBillNo.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblVoucherOrBillNo.ForeColor = Color.White;
            lblVoucherOrBillNo.Location = new Point(22, 88);
            lblVoucherOrBillNo.Margin = new Padding(2, 0, 2, 0);
            lblVoucherOrBillNo.Name = "lblVoucherOrBillNo";
            lblVoucherOrBillNo.Size = new Size(126, 18);
            lblVoucherOrBillNo.TabIndex = 18;
            lblVoucherOrBillNo.Text = "Voucher/Bill No  :";
            lblVoucherOrBillNo.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // txtBalance
            // 
            txtBalance.Anchor = AnchorStyles.Top;
            txtBalance.Location = new Point(197, 122);
            txtBalance.Margin = new Padding(2);
            txtBalance.Multiline = true;
            txtBalance.Name = "txtBalance";
            txtBalance.PlaceholderText = "   ";
            txtBalance.RightToLeft = RightToLeft.No;
            txtBalance.Size = new Size(219, 22);
            txtBalance.TabIndex = 19;
            // 
            // btnAddMaterial
            // 
            btnAddMaterial.Anchor = AnchorStyles.Top;
            btnAddMaterial.AutoSize = true;
            btnAddMaterial.BackColor = Color.LimeGreen;
            btnAddMaterial.Cursor = Cursors.Hand;
            btnAddMaterial.FlatAppearance.BorderSize = 0;
            btnAddMaterial.FlatAppearance.MouseDownBackColor = Color.Gray;
            btnAddMaterial.FlatAppearance.MouseOverBackColor = Color.LightSteelBlue;
            btnAddMaterial.FlatStyle = FlatStyle.Flat;
            btnAddMaterial.Font = new Font("Arial", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAddMaterial.ForeColor = Color.SeaShell;
            btnAddMaterial.Image = (Image)resources.GetObject("btnAddMaterial.Image");
            btnAddMaterial.ImageAlign = ContentAlignment.MiddleLeft;
            btnAddMaterial.Location = new Point(22, 222);
            btnAddMaterial.Margin = new Padding(2);
            btnAddMaterial.Name = "btnAddMaterial";
            btnAddMaterial.Size = new Size(140, 31);
            btnAddMaterial.TabIndex = 21;
            btnAddMaterial.Text = "Add Material";
            btnAddMaterial.TextAlign = ContentAlignment.MiddleRight;
            btnAddMaterial.UseVisualStyleBackColor = false;
            btnAddMaterial.Click += btnAddMaterial_Click;
            // 
            // lblBalance
            // 
            lblBalance.Anchor = AnchorStyles.Top;
            lblBalance.AutoSize = true;
            lblBalance.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblBalance.ForeColor = Color.White;
            lblBalance.Location = new Point(22, 126);
            lblBalance.Margin = new Padding(2, 0, 2, 0);
            lblBalance.Name = "lblBalance";
            lblBalance.Size = new Size(77, 18);
            lblBalance.TabIndex = 25;
            lblBalance.Text = "Balance  :";
            lblBalance.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // Material
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1404, 580);
            Controls.Add(panelMaterial);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(2);
            Name = "Material";
            Text = "Material";
            Load += Material_Load;
            panelMaterial.ResumeLayout(false);
            tableLayoutPanelMaterial.ResumeLayout(false);
            panelRight.ResumeLayout(false);
            panelRight.PerformLayout();
            panelLeft.ResumeLayout(false);
            panelLeft.PerformLayout();
            panelCenter.ResumeLayout(false);
            panelCenter.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private Panel panelMaterial;
        private TableLayoutPanel tableLayoutPanelMaterial;
        private TextBox txtRate;
        private Label lblText;
        private TextBox txtParticular;
        private Label lblParticular;
        private Button btnClear;
        private ComboBox cmbTypesOfCategory;
        private Label lblTypesOfCategory;
        private TextBox txtBalance;
        private Label lblBalance;
        private TextBox txtLocation;
        private Label lblLocation;
        private Label lblVoucherOrBillNo;
        private TextBox txtvoucherorbillno;
        private ComboBox cmbMaterialSubCategory;
        private Label lblMaterialSubCategory;
        private ComboBox cmbMaterialCategory;
        private Button btnAddMaterial;
        private Label lblMaterialCategory;
        private Panel panelLeft;
        private Panel panelCenter;
        private Panel panelRight;
        private TextBox txtMinThreshold;
        private Label lblMinThreshold;
        private Label lblMaxThreshold;
        private TextBox txtMaxThreshold;
        private Label lblReciept;
        private DateTimePicker dtOpeningDate;
        private Label lblPackage;
        private Label lblOpeningDate;
        private Label lblMaterialName;
        private ComboBox cmbPackage;
        private TextBox txtReceipt;
        private TextBox txtMaterialName;
    }
}