namespace JPSCURA
{
    partial class Vendors
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
            panelmainVendors = new Panel();
            dgvVendors = new DataGridView();
            panel2 = new Panel();
            txtSearchVendorShippingAddress = new TextBox();
            txtSeachVendorBillingAddress = new TextBox();
            txtVendorSearchGST = new TextBox();
            txtVendorSearchPAN = new TextBox();
            txtSearchVendorEmail = new TextBox();
            txtSearchVendorNo = new TextBox();
            txtSearchVendors = new TextBox();
            panel1 = new Panel();
            btnClear = new Button();
            btnAddVendor = new Button();
            tableLayoutPanelVendors = new TableLayoutPanel();
            panelVendorsright = new Panel();
            txtCity = new TextBox();
            txtState = new TextBox();
            txtPinCode = new TextBox();
            txtAddressLine2 = new TextBox();
            txtAddressLine1 = new TextBox();
            lblVendorAddress = new Label();
            txtVendorMoNo = new TextBox();
            lblVendorMoNo = new Label();
            lblVendorName = new Label();
            rdoGST = new RadioButton();
            rdoPAN = new RadioButton();
            txtVendorName = new TextBox();
            txtGSTNo = new TextBox();
            txtPANNo = new TextBox();
            panelVendorsleft = new Panel();
            txtShipCity = new TextBox();
            chksameas = new CheckBox();
            txtShipState = new TextBox();
            txtShipPinCode = new TextBox();
            txtShipAddressLine2 = new TextBox();
            txtAltContact = new TextBox();
            txtShipAddressLine1 = new TextBox();
            lblVendoraltno = new Label();
            lblVenShippingaddress = new Label();
            lblVendorEmail = new Label();
            txtVendorEmail = new TextBox();
            panelmainVendors.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvVendors).BeginInit();
            panel2.SuspendLayout();
            panel1.SuspendLayout();
            tableLayoutPanelVendors.SuspendLayout();
            panelVendorsright.SuspendLayout();
            panelVendorsleft.SuspendLayout();
            SuspendLayout();
            // 
            // panelmainVendors
            // 
            panelmainVendors.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panelmainVendors.BackColor = Color.White;
            panelmainVendors.Controls.Add(dgvVendors);
            panelmainVendors.Controls.Add(panel2);
            panelmainVendors.Controls.Add(panel1);
            panelmainVendors.Controls.Add(tableLayoutPanelVendors);
            panelmainVendors.Location = new Point(0, 0);
            panelmainVendors.Name = "panelmainVendors";
            panelmainVendors.Size = new Size(1386, 677);
            panelmainVendors.TabIndex = 0;
            // 
            // dgvVendors
            // 
            dgvVendors.BackgroundColor = Color.White;
            dgvVendors.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvVendors.Dock = DockStyle.Fill;
            dgvVendors.Location = new Point(0, 390);
            dgvVendors.Name = "dgvVendors";
            dgvVendors.ReadOnly = true;
            dgvVendors.Size = new Size(1386, 287);
            dgvVendors.TabIndex = 3;
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(83, 144, 204);
            panel2.Controls.Add(txtSearchVendorShippingAddress);
            panel2.Controls.Add(txtSeachVendorBillingAddress);
            panel2.Controls.Add(txtVendorSearchGST);
            panel2.Controls.Add(txtVendorSearchPAN);
            panel2.Controls.Add(txtSearchVendorEmail);
            panel2.Controls.Add(txtSearchVendorNo);
            panel2.Controls.Add(txtSearchVendors);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 340);
            panel2.Name = "panel2";
            panel2.Size = new Size(1386, 50);
            panel2.TabIndex = 2;
            // 
            // txtSearchVendorShippingAddress
            // 
            txtSearchVendorShippingAddress.Location = new Point(962, 14);
            txtSearchVendorShippingAddress.Name = "txtSearchVendorShippingAddress";
            txtSearchVendorShippingAddress.PlaceholderText = "   Search By Shipping Address";
            txtSearchVendorShippingAddress.Size = new Size(100, 23);
            txtSearchVendorShippingAddress.TabIndex = 33;
            // 
            // txtSeachVendorBillingAddress
            // 
            txtSeachVendorBillingAddress.Location = new Point(856, 14);
            txtSeachVendorBillingAddress.Name = "txtSeachVendorBillingAddress";
            txtSeachVendorBillingAddress.PlaceholderText = "   Search By Billing Address";
            txtSeachVendorBillingAddress.Size = new Size(100, 23);
            txtSeachVendorBillingAddress.TabIndex = 32;
            // 
            // txtVendorSearchGST
            // 
            txtVendorSearchGST.Location = new Point(643, 14);
            txtVendorSearchGST.Name = "txtVendorSearchGST";
            txtVendorSearchGST.PlaceholderText = "   Search By GST No";
            txtVendorSearchGST.Size = new Size(100, 23);
            txtVendorSearchGST.TabIndex = 30;
            // 
            // txtVendorSearchPAN
            // 
            txtVendorSearchPAN.Location = new Point(749, 14);
            txtVendorSearchPAN.Name = "txtVendorSearchPAN";
            txtVendorSearchPAN.PlaceholderText = "   Search By PAN No";
            txtVendorSearchPAN.Size = new Size(100, 23);
            txtVendorSearchPAN.TabIndex = 31;
            // 
            // txtSearchVendorEmail
            // 
            txtSearchVendorEmail.Location = new Point(537, 14);
            txtSearchVendorEmail.Name = "txtSearchVendorEmail";
            txtSearchVendorEmail.PlaceholderText = "   Search By Vendor Email";
            txtSearchVendorEmail.Size = new Size(100, 23);
            txtSearchVendorEmail.TabIndex = 29;
            // 
            // txtSearchVendorNo
            // 
            txtSearchVendorNo.Location = new Point(431, 14);
            txtSearchVendorNo.Name = "txtSearchVendorNo";
            txtSearchVendorNo.PlaceholderText = "   Search By Contact No";
            txtSearchVendorNo.Size = new Size(100, 23);
            txtSearchVendorNo.TabIndex = 28;
            // 
            // txtSearchVendors
            // 
            txtSearchVendors.Location = new Point(325, 14);
            txtSearchVendors.Name = "txtSearchVendors";
            txtSearchVendors.PlaceholderText = "   Search By Vendor Name";
            txtSearchVendors.Size = new Size(100, 23);
            txtSearchVendors.TabIndex = 27;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(83, 144, 204);
            panel1.Controls.Add(btnClear);
            panel1.Controls.Add(btnAddVendor);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 300);
            panel1.Name = "panel1";
            panel1.Size = new Size(1386, 40);
            panel1.TabIndex = 1;
            // 
            // btnClear
            // 
            btnClear.Anchor = AnchorStyles.Top;
            btnClear.BackColor = Color.ForestGreen;
            btnClear.Cursor = Cursors.Hand;
            btnClear.FlatAppearance.BorderSize = 0;
            btnClear.FlatAppearance.MouseDownBackColor = Color.Red;
            btnClear.FlatAppearance.MouseOverBackColor = Color.Red;
            btnClear.FlatStyle = FlatStyle.Flat;
            btnClear.Font = new Font("Arial", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnClear.ForeColor = Color.SeaShell;
            btnClear.Location = new Point(699, 6);
            btnClear.Margin = new Padding(3, 2, 3, 2);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(141, 29);
            btnClear.TabIndex = 32;
            btnClear.Text = "Clear";
            btnClear.UseVisualStyleBackColor = false;
            btnClear.Click += btnClear_Click;
            // 
            // btnAddVendor
            // 
            btnAddVendor.Anchor = AnchorStyles.Top;
            btnAddVendor.BackColor = SystemColors.GradientInactiveCaption;
            btnAddVendor.Cursor = Cursors.Hand;
            btnAddVendor.FlatAppearance.BorderSize = 0;
            btnAddVendor.FlatAppearance.MouseDownBackColor = Color.Gray;
            btnAddVendor.FlatStyle = FlatStyle.Flat;
            btnAddVendor.Font = new Font("Arial", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAddVendor.ForeColor = Color.Black;
            btnAddVendor.Location = new Point(546, 6);
            btnAddVendor.Margin = new Padding(3, 2, 3, 2);
            btnAddVendor.Name = "btnAddVendor";
            btnAddVendor.Size = new Size(141, 29);
            btnAddVendor.TabIndex = 31;
            btnAddVendor.Text = "Add Vendor";
            btnAddVendor.UseVisualStyleBackColor = false;
            btnAddVendor.Click += btnAddVendor_Click;
            // 
            // tableLayoutPanelVendors
            // 
            tableLayoutPanelVendors.BackColor = Color.FromArgb(83, 144, 204);
            tableLayoutPanelVendors.ColumnCount = 2;
            tableLayoutPanelVendors.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanelVendors.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanelVendors.Controls.Add(panelVendorsright, 0, 0);
            tableLayoutPanelVendors.Controls.Add(panelVendorsleft, 1, 0);
            tableLayoutPanelVendors.Dock = DockStyle.Top;
            tableLayoutPanelVendors.Location = new Point(0, 0);
            tableLayoutPanelVendors.Name = "tableLayoutPanelVendors";
            tableLayoutPanelVendors.RowCount = 1;
            tableLayoutPanelVendors.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanelVendors.Size = new Size(1386, 300);
            tableLayoutPanelVendors.TabIndex = 0;
            // 
            // panelVendorsright
            // 
            panelVendorsright.BackColor = Color.FromArgb(83, 144, 204);
            panelVendorsright.Controls.Add(txtCity);
            panelVendorsright.Controls.Add(txtState);
            panelVendorsright.Controls.Add(txtPinCode);
            panelVendorsright.Controls.Add(txtAddressLine2);
            panelVendorsright.Controls.Add(txtAddressLine1);
            panelVendorsright.Controls.Add(lblVendorAddress);
            panelVendorsright.Controls.Add(txtVendorMoNo);
            panelVendorsright.Controls.Add(lblVendorMoNo);
            panelVendorsright.Controls.Add(lblVendorName);
            panelVendorsright.Controls.Add(rdoGST);
            panelVendorsright.Controls.Add(rdoPAN);
            panelVendorsright.Controls.Add(txtVendorName);
            panelVendorsright.Controls.Add(txtGSTNo);
            panelVendorsright.Controls.Add(txtPANNo);
            panelVendorsright.Dock = DockStyle.Fill;
            panelVendorsright.Location = new Point(3, 3);
            panelVendorsright.Name = "panelVendorsright";
            panelVendorsright.Size = new Size(687, 294);
            panelVendorsright.TabIndex = 0;
            panelVendorsright.Paint += panelVendorsright_Paint;
            // 
            // txtCity
            // 
            txtCity.Location = new Point(238, 238);
            txtCity.Margin = new Padding(3, 2, 3, 2);
            txtCity.Multiline = true;
            txtCity.Name = "txtCity";
            txtCity.PlaceholderText = "   Enter City";
            txtCity.RightToLeft = RightToLeft.No;
            txtCity.Size = new Size(410, 21);
            txtCity.TabIndex = 53;
            // 
            // txtState
            // 
            txtState.Location = new Point(238, 264);
            txtState.Margin = new Padding(3, 2, 3, 2);
            txtState.Multiline = true;
            txtState.Name = "txtState";
            txtState.PlaceholderText = "   Enter State";
            txtState.RightToLeft = RightToLeft.No;
            txtState.Size = new Size(410, 21);
            txtState.TabIndex = 52;
            // 
            // txtPinCode
            // 
            txtPinCode.Location = new Point(238, 212);
            txtPinCode.Margin = new Padding(3, 2, 3, 2);
            txtPinCode.Multiline = true;
            txtPinCode.Name = "txtPinCode";
            txtPinCode.PlaceholderText = "   Enter Pin Code";
            txtPinCode.RightToLeft = RightToLeft.No;
            txtPinCode.Size = new Size(410, 21);
            txtPinCode.TabIndex = 51;
            // 
            // txtAddressLine2
            // 
            txtAddressLine2.Location = new Point(238, 187);
            txtAddressLine2.Margin = new Padding(3, 2, 3, 2);
            txtAddressLine2.Multiline = true;
            txtAddressLine2.Name = "txtAddressLine2";
            txtAddressLine2.PlaceholderText = "   Address Line 2";
            txtAddressLine2.RightToLeft = RightToLeft.No;
            txtAddressLine2.Size = new Size(410, 21);
            txtAddressLine2.TabIndex = 50;
            // 
            // txtAddressLine1
            // 
            txtAddressLine1.Location = new Point(238, 162);
            txtAddressLine1.Margin = new Padding(3, 2, 3, 2);
            txtAddressLine1.Multiline = true;
            txtAddressLine1.Name = "txtAddressLine1";
            txtAddressLine1.PlaceholderText = "   Address Line 1";
            txtAddressLine1.RightToLeft = RightToLeft.No;
            txtAddressLine1.Size = new Size(410, 21);
            txtAddressLine1.TabIndex = 47;
            // 
            // lblVendorAddress
            // 
            lblVendorAddress.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblVendorAddress.ForeColor = Color.White;
            lblVendorAddress.Location = new Point(38, 160);
            lblVendorAddress.Name = "lblVendorAddress";
            lblVendorAddress.Size = new Size(170, 23);
            lblVendorAddress.TabIndex = 46;
            lblVendorAddress.Text = "Billing Address :";
            lblVendorAddress.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtVendorMoNo
            // 
            txtVendorMoNo.Location = new Point(239, 52);
            txtVendorMoNo.Margin = new Padding(3, 2, 3, 2);
            txtVendorMoNo.Multiline = true;
            txtVendorMoNo.Name = "txtVendorMoNo";
            txtVendorMoNo.PlaceholderText = "   Enter Vendor Mobile No";
            txtVendorMoNo.RightToLeft = RightToLeft.No;
            txtVendorMoNo.Size = new Size(410, 22);
            txtVendorMoNo.TabIndex = 44;
            // 
            // lblVendorMoNo
            // 
            lblVendorMoNo.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblVendorMoNo.ForeColor = Color.White;
            lblVendorMoNo.Location = new Point(40, 52);
            lblVendorMoNo.Name = "lblVendorMoNo";
            lblVendorMoNo.Size = new Size(176, 23);
            lblVendorMoNo.TabIndex = 43;
            lblVendorMoNo.Text = "Vendor Mobile No :";
            lblVendorMoNo.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblVendorName
            // 
            lblVendorName.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblVendorName.ForeColor = Color.White;
            lblVendorName.Location = new Point(40, 9);
            lblVendorName.Name = "lblVendorName";
            lblVendorName.Size = new Size(170, 23);
            lblVendorName.TabIndex = 41;
            lblVendorName.Text = "Vendor Name :";
            lblVendorName.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // rdoGST
            // 
            rdoGST.AutoSize = true;
            rdoGST.Font = new Font("Arial Narrow", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            rdoGST.ForeColor = Color.White;
            rdoGST.Location = new Point(38, 92);
            rdoGST.Name = "rdoGST";
            rdoGST.Size = new Size(74, 24);
            rdoGST.TabIndex = 48;
            rdoGST.TabStop = true;
            rdoGST.Text = "GST No";
            rdoGST.UseVisualStyleBackColor = true;
            rdoGST.CheckedChanged += RadioChanged;
            // 
            // rdoPAN
            // 
            rdoPAN.AutoSize = true;
            rdoPAN.Font = new Font("Arial Narrow", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            rdoPAN.ForeColor = Color.White;
            rdoPAN.Location = new Point(115, 92);
            rdoPAN.Name = "rdoPAN";
            rdoPAN.Size = new Size(75, 24);
            rdoPAN.TabIndex = 49;
            rdoPAN.TabStop = true;
            rdoPAN.Text = "PAN No";
            rdoPAN.UseVisualStyleBackColor = true;
            rdoPAN.CheckedChanged += RadioChanged;
            // 
            // txtVendorName
            // 
            txtVendorName.Location = new Point(239, 9);
            txtVendorName.Margin = new Padding(3, 2, 3, 2);
            txtVendorName.Multiline = true;
            txtVendorName.Name = "txtVendorName";
            txtVendorName.PlaceholderText = "   Enter Vendor Name";
            txtVendorName.RightToLeft = RightToLeft.No;
            txtVendorName.Size = new Size(410, 22);
            txtVendorName.TabIndex = 42;
            // 
            // txtGSTNo
            // 
            txtGSTNo.Location = new Point(238, 95);
            txtGSTNo.Margin = new Padding(3, 2, 3, 2);
            txtGSTNo.Multiline = true;
            txtGSTNo.Name = "txtGSTNo";
            txtGSTNo.PlaceholderText = "   Enter Vendor GST No";
            txtGSTNo.RightToLeft = RightToLeft.No;
            txtGSTNo.Size = new Size(410, 24);
            txtGSTNo.TabIndex = 45;
            // 
            // txtPANNo
            // 
            txtPANNo.Location = new Point(238, 95);
            txtPANNo.Margin = new Padding(3, 2, 3, 2);
            txtPANNo.Multiline = true;
            txtPANNo.Name = "txtPANNo";
            txtPANNo.PlaceholderText = "   Enter Vendor PAN No";
            txtPANNo.RightToLeft = RightToLeft.No;
            txtPANNo.Size = new Size(410, 24);
            txtPANNo.TabIndex = 54;
            // 
            // panelVendorsleft
            // 
            panelVendorsleft.Controls.Add(txtShipCity);
            panelVendorsleft.Controls.Add(chksameas);
            panelVendorsleft.Controls.Add(txtShipState);
            panelVendorsleft.Controls.Add(txtShipPinCode);
            panelVendorsleft.Controls.Add(txtShipAddressLine2);
            panelVendorsleft.Controls.Add(txtAltContact);
            panelVendorsleft.Controls.Add(txtShipAddressLine1);
            panelVendorsleft.Controls.Add(lblVendoraltno);
            panelVendorsleft.Controls.Add(lblVenShippingaddress);
            panelVendorsleft.Controls.Add(lblVendorEmail);
            panelVendorsleft.Controls.Add(txtVendorEmail);
            panelVendorsleft.Dock = DockStyle.Fill;
            panelVendorsleft.Location = new Point(696, 3);
            panelVendorsleft.Name = "panelVendorsleft";
            panelVendorsleft.Size = new Size(687, 294);
            panelVendorsleft.TabIndex = 1;
            // 
            // txtShipCity
            // 
            txtShipCity.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtShipCity.Location = new Point(238, 237);
            txtShipCity.Margin = new Padding(3, 2, 3, 2);
            txtShipCity.Multiline = true;
            txtShipCity.Name = "txtShipCity";
            txtShipCity.PlaceholderText = "   Enter City";
            txtShipCity.RightToLeft = RightToLeft.No;
            txtShipCity.Size = new Size(410, 21);
            txtShipCity.TabIndex = 55;
            // 
            // chksameas
            // 
            chksameas.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            chksameas.BackColor = Color.Transparent;
            chksameas.FlatAppearance.BorderSize = 0;
            chksameas.FlatAppearance.CheckedBackColor = Color.Black;
            chksameas.FlatStyle = FlatStyle.Flat;
            chksameas.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            chksameas.ForeColor = Color.Black;
            chksameas.Location = new Point(237, 124);
            chksameas.Margin = new Padding(3, 2, 3, 2);
            chksameas.Name = "chksameas";
            chksameas.Size = new Size(410, 31);
            chksameas.TabIndex = 49;
            chksameas.Text = "   Same As Billing Address";
            chksameas.UseVisualStyleBackColor = false;
            chksameas.CheckedChanged += chksameas_CheckedChanged;
            // 
            // txtShipState
            // 
            txtShipState.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtShipState.Location = new Point(238, 263);
            txtShipState.Margin = new Padding(3, 2, 3, 2);
            txtShipState.Multiline = true;
            txtShipState.Name = "txtShipState";
            txtShipState.PlaceholderText = "   Enter State";
            txtShipState.RightToLeft = RightToLeft.No;
            txtShipState.Size = new Size(410, 21);
            txtShipState.TabIndex = 54;
            // 
            // txtShipPinCode
            // 
            txtShipPinCode.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtShipPinCode.Location = new Point(238, 212);
            txtShipPinCode.Margin = new Padding(3, 2, 3, 2);
            txtShipPinCode.Multiline = true;
            txtShipPinCode.Name = "txtShipPinCode";
            txtShipPinCode.PlaceholderText = "   Enter Pin Code";
            txtShipPinCode.RightToLeft = RightToLeft.No;
            txtShipPinCode.Size = new Size(410, 21);
            txtShipPinCode.TabIndex = 53;
            // 
            // txtShipAddressLine2
            // 
            txtShipAddressLine2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtShipAddressLine2.Location = new Point(238, 187);
            txtShipAddressLine2.Margin = new Padding(3, 2, 3, 2);
            txtShipAddressLine2.Multiline = true;
            txtShipAddressLine2.Name = "txtShipAddressLine2";
            txtShipAddressLine2.PlaceholderText = "   Address Line 2";
            txtShipAddressLine2.RightToLeft = RightToLeft.No;
            txtShipAddressLine2.Size = new Size(410, 21);
            txtShipAddressLine2.TabIndex = 52;
            // 
            // txtAltContact
            // 
            txtAltContact.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtAltContact.Location = new Point(238, 10);
            txtAltContact.Margin = new Padding(3, 2, 3, 2);
            txtAltContact.Multiline = true;
            txtAltContact.Name = "txtAltContact";
            txtAltContact.PlaceholderText = "   Enter Vendor ALT Mobile No";
            txtAltContact.RightToLeft = RightToLeft.No;
            txtAltContact.Size = new Size(410, 22);
            txtAltContact.TabIndex = 51;
            // 
            // txtShipAddressLine1
            // 
            txtShipAddressLine1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtShipAddressLine1.Location = new Point(238, 162);
            txtShipAddressLine1.Margin = new Padding(3, 2, 3, 2);
            txtShipAddressLine1.Multiline = true;
            txtShipAddressLine1.Name = "txtShipAddressLine1";
            txtShipAddressLine1.PlaceholderText = "   Address Line 1";
            txtShipAddressLine1.RightToLeft = RightToLeft.No;
            txtShipAddressLine1.Size = new Size(410, 21);
            txtShipAddressLine1.TabIndex = 48;
            // 
            // lblVendoraltno
            // 
            lblVendoraltno.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblVendoraltno.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblVendoraltno.ForeColor = Color.White;
            lblVendoraltno.Location = new Point(39, 10);
            lblVendoraltno.Name = "lblVendoraltno";
            lblVendoraltno.Size = new Size(193, 23);
            lblVendoraltno.TabIndex = 50;
            lblVendoraltno.Text = "Vendor ALT Mobile No :";
            lblVendoraltno.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblVenShippingaddress
            // 
            lblVenShippingaddress.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblVenShippingaddress.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblVenShippingaddress.ForeColor = Color.White;
            lblVenShippingaddress.Location = new Point(39, 160);
            lblVenShippingaddress.Name = "lblVenShippingaddress";
            lblVenShippingaddress.Size = new Size(170, 23);
            lblVenShippingaddress.TabIndex = 47;
            lblVenShippingaddress.Text = "Shipping Address :";
            lblVenShippingaddress.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblVendorEmail
            // 
            lblVendorEmail.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblVendorEmail.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblVendorEmail.ForeColor = Color.White;
            lblVendorEmail.Location = new Point(39, 51);
            lblVendorEmail.Name = "lblVendorEmail";
            lblVendorEmail.Size = new Size(141, 23);
            lblVendorEmail.TabIndex = 45;
            lblVendorEmail.Text = "Vendor Email :";
            lblVendorEmail.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtVendorEmail
            // 
            txtVendorEmail.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtVendorEmail.Location = new Point(238, 51);
            txtVendorEmail.Margin = new Padding(3, 2, 3, 2);
            txtVendorEmail.Multiline = true;
            txtVendorEmail.Name = "txtVendorEmail";
            txtVendorEmail.PlaceholderText = "   Enter Vendor Email";
            txtVendorEmail.RightToLeft = RightToLeft.No;
            txtVendorEmail.Size = new Size(410, 22);
            txtVendorEmail.TabIndex = 46;
            // 
            // Vendors
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1386, 677);
            Controls.Add(panelmainVendors);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Vendors";
            Text = "Vendors";
            Load += Vendors_Load;
            panelmainVendors.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvVendors).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel1.ResumeLayout(false);
            tableLayoutPanelVendors.ResumeLayout(false);
            panelVendorsright.ResumeLayout(false);
            panelVendorsright.PerformLayout();
            panelVendorsleft.ResumeLayout(false);
            panelVendorsleft.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelmainVendors;
        private TableLayoutPanel tableLayoutPanelVendors;
        private Panel panelVendorsright;
        private Panel panelVendorsleft;
        private Panel panel1;
        private Panel panel2;
        private TextBox txtSearchVendorShippingAddress;
        private TextBox txtSeachVendorBillingAddress;
        private TextBox txtVendorSearchPAN;
        private TextBox txtVendorSearchGST;
        private TextBox txtSearchVendorEmail;
        private TextBox txtSearchVendorNo;
        private TextBox txtSearchVendors;
        private Button btnClear;
        private Button btnAddVendor;
        private TextBox txtCity;
        private TextBox txtState;
        private TextBox txtPinCode;
        private TextBox txtAddressLine2;
        private TextBox txtAddressLine1;
        private Label lblVendorAddress;
        private TextBox txtGSTNo;
        private TextBox txtVendorMoNo;
        private Label lblVendorMoNo;
        private Label lblVendorName;
        private RadioButton rdoGST;
        private RadioButton rdoPAN;
        private TextBox txtVendorName;
        private TextBox txtPANNo;
        private TextBox txtShipCity;
        private CheckBox chksameas;
        private TextBox txtShipState;
        private TextBox txtShipPinCode;
        private TextBox txtShipAddressLine2;
        private TextBox txtAltContact;
        private TextBox txtShipAddressLine1;
        private Label lblVendoraltno;
        private Label lblVenShippingaddress;
        private Label lblVendorEmail;
        private TextBox txtVendorEmail;
        private DataGridView dgvVendors;
    }
}