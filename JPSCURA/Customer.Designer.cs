namespace JPSCURA
{
    partial class Customer
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
            panelCustomer = new Panel();
            panelcustomerdata = new Panel();
            dgv = new DataGridView();
            panelMenu = new Panel();
            txtSearchCustomerShippingAddress = new TextBox();
            txtSeachCustomerBillingAddress = new TextBox();
            txtCustomerSearchPAN = new TextBox();
            txtCustomerSearchGST = new TextBox();
            txtSearchCustomerEmail = new TextBox();
            txtSearchCustomerNo = new TextBox();
            txtSearchCustomer = new TextBox();
            panelforbutton = new Panel();
            btnClear = new Button();
            btnAddCustomer = new Button();
            tableLayoutPanelCustomer = new TableLayoutPanel();
            panelLeft = new Panel();
            btnRefreshCaptcha = new Button();
            txtCaptcha = new TextBox();
            picCaptcha = new PictureBox();
            txtCity = new TextBox();
            txtState = new TextBox();
            txtPinCode = new TextBox();
            txtAddressLine2 = new TextBox();
            btnFetch = new Button();
            txtAddressLine1 = new TextBox();
            lblCustomerAddress = new Label();
            txtGSTNo = new TextBox();
            txtCustomerMoNo = new TextBox();
            txtPANNo = new TextBox();
            lblCustomerMoNo = new Label();
            lblCustomerName = new Label();
            rdoGST = new RadioButton();
            rdoPAN = new RadioButton();
            txtCustomerName = new TextBox();
            panelRight = new Panel();
            txtShipCity = new TextBox();
            chksameas = new CheckBox();
            txtShipState = new TextBox();
            txtShipPinCode = new TextBox();
            txtShipAddressLine2 = new TextBox();
            txtAltContact = new TextBox();
            txtShipAddressLine1 = new TextBox();
            lblCustomeraltno = new Label();
            lblCustShippingaddress = new Label();
            lblCustomerEmail = new Label();
            txtCustomerEmail = new TextBox();
            panelCustomer.SuspendLayout();
            panelcustomerdata.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgv).BeginInit();
            panelMenu.SuspendLayout();
            panelforbutton.SuspendLayout();
            tableLayoutPanelCustomer.SuspendLayout();
            panelLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picCaptcha).BeginInit();
            panelRight.SuspendLayout();
            SuspendLayout();
            // 
            // panelCustomer
            // 
            panelCustomer.BackColor = Color.FromArgb(83, 144, 204);
            panelCustomer.Controls.Add(panelcustomerdata);
            panelCustomer.Controls.Add(panelforbutton);
            panelCustomer.Controls.Add(tableLayoutPanelCustomer);
            panelCustomer.Dock = DockStyle.Fill;
            panelCustomer.ForeColor = Color.White;
            panelCustomer.Location = new Point(0, 0);
            panelCustomer.Margin = new Padding(3, 2, 3, 2);
            panelCustomer.Name = "panelCustomer";
            panelCustomer.Size = new Size(1698, 677);
            panelCustomer.TabIndex = 1;
            // 
            // panelcustomerdata
            // 
            panelcustomerdata.Controls.Add(dgv);
            panelcustomerdata.Controls.Add(panelMenu);
            panelcustomerdata.Dock = DockStyle.Fill;
            panelcustomerdata.Location = new Point(0, 340);
            panelcustomerdata.Name = "panelcustomerdata";
            panelcustomerdata.Size = new Size(1698, 337);
            panelcustomerdata.TabIndex = 31;
            // 
            // dgv
            // 
            dgv.BackgroundColor = Color.White;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = Color.White;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv.Dock = DockStyle.Fill;
            dgv.Location = new Point(0, 50);
            dgv.Name = "dgv";
            dgv.Size = new Size(1698, 287);
            dgv.TabIndex = 1;
            // 
            // panelMenu
            // 
            panelMenu.Controls.Add(txtSearchCustomerShippingAddress);
            panelMenu.Controls.Add(txtSeachCustomerBillingAddress);
            panelMenu.Controls.Add(txtCustomerSearchPAN);
            panelMenu.Controls.Add(txtCustomerSearchGST);
            panelMenu.Controls.Add(txtSearchCustomerEmail);
            panelMenu.Controls.Add(txtSearchCustomerNo);
            panelMenu.Controls.Add(txtSearchCustomer);
            panelMenu.Dock = DockStyle.Top;
            panelMenu.Location = new Point(0, 0);
            panelMenu.Name = "panelMenu";
            panelMenu.Size = new Size(1698, 50);
            panelMenu.TabIndex = 0;
            // 
            // txtSearchCustomerShippingAddress
            // 
            txtSearchCustomerShippingAddress.Location = new Point(1022, 15);
            txtSearchCustomerShippingAddress.Name = "txtSearchCustomerShippingAddress";
            txtSearchCustomerShippingAddress.PlaceholderText = "   Search By Shipping Address";
            txtSearchCustomerShippingAddress.Size = new Size(100, 23);
            txtSearchCustomerShippingAddress.TabIndex = 26;
            // 
            // txtSeachCustomerBillingAddress
            // 
            txtSeachCustomerBillingAddress.Location = new Point(916, 16);
            txtSeachCustomerBillingAddress.Name = "txtSeachCustomerBillingAddress";
            txtSeachCustomerBillingAddress.PlaceholderText = "   Search By Billing Address";
            txtSeachCustomerBillingAddress.Size = new Size(100, 23);
            txtSeachCustomerBillingAddress.TabIndex = 25;
            // 
            // txtCustomerSearchPAN
            // 
            txtCustomerSearchPAN.Location = new Point(809, 16);
            txtCustomerSearchPAN.Name = "txtCustomerSearchPAN";
            txtCustomerSearchPAN.PlaceholderText = "   Search By PAN No";
            txtCustomerSearchPAN.Size = new Size(100, 23);
            txtCustomerSearchPAN.TabIndex = 24;
            // 
            // txtCustomerSearchGST
            // 
            txtCustomerSearchGST.Location = new Point(703, 16);
            txtCustomerSearchGST.Name = "txtCustomerSearchGST";
            txtCustomerSearchGST.PlaceholderText = "   Search By GST No";
            txtCustomerSearchGST.Size = new Size(100, 23);
            txtCustomerSearchGST.TabIndex = 23;
            // 
            // txtSearchCustomerEmail
            // 
            txtSearchCustomerEmail.Location = new Point(597, 15);
            txtSearchCustomerEmail.Name = "txtSearchCustomerEmail";
            txtSearchCustomerEmail.PlaceholderText = "   Search By Customer Email";
            txtSearchCustomerEmail.Size = new Size(100, 23);
            txtSearchCustomerEmail.TabIndex = 22;
            // 
            // txtSearchCustomerNo
            // 
            txtSearchCustomerNo.Location = new Point(491, 15);
            txtSearchCustomerNo.Name = "txtSearchCustomerNo";
            txtSearchCustomerNo.PlaceholderText = "   Search By Contact No";
            txtSearchCustomerNo.Size = new Size(100, 23);
            txtSearchCustomerNo.TabIndex = 21;
            // 
            // txtSearchCustomer
            // 
            txtSearchCustomer.Location = new Point(385, 15);
            txtSearchCustomer.Name = "txtSearchCustomer";
            txtSearchCustomer.PlaceholderText = "   Search By Customer Name";
            txtSearchCustomer.Size = new Size(100, 23);
            txtSearchCustomer.TabIndex = 20;
            // 
            // panelforbutton
            // 
            panelforbutton.Controls.Add(btnClear);
            panelforbutton.Controls.Add(btnAddCustomer);
            panelforbutton.Dock = DockStyle.Top;
            panelforbutton.Location = new Point(0, 300);
            panelforbutton.Name = "panelforbutton";
            panelforbutton.Size = new Size(1698, 40);
            panelforbutton.TabIndex = 30;
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
            btnClear.Location = new Point(856, 6);
            btnClear.Margin = new Padding(3, 2, 3, 2);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(141, 29);
            btnClear.TabIndex = 30;
            btnClear.Text = "Clear";
            btnClear.UseVisualStyleBackColor = false;
            btnClear.Click += btnClear_Click;
            // 
            // btnAddCustomer
            // 
            btnAddCustomer.Anchor = AnchorStyles.Top;
            btnAddCustomer.BackColor = SystemColors.GradientInactiveCaption;
            btnAddCustomer.Cursor = Cursors.Hand;
            btnAddCustomer.FlatAppearance.BorderSize = 0;
            btnAddCustomer.FlatAppearance.MouseDownBackColor = Color.Gray;
            btnAddCustomer.FlatStyle = FlatStyle.Flat;
            btnAddCustomer.Font = new Font("Arial", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAddCustomer.ForeColor = Color.Black;
            btnAddCustomer.Location = new Point(703, 6);
            btnAddCustomer.Margin = new Padding(3, 2, 3, 2);
            btnAddCustomer.Name = "btnAddCustomer";
            btnAddCustomer.Size = new Size(141, 29);
            btnAddCustomer.TabIndex = 29;
            btnAddCustomer.Text = "Add Customer";
            btnAddCustomer.UseVisualStyleBackColor = false;
            btnAddCustomer.Click += btnAddCustomer_Click;
            // 
            // tableLayoutPanelCustomer
            // 
            tableLayoutPanelCustomer.ColumnCount = 2;
            tableLayoutPanelCustomer.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanelCustomer.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanelCustomer.Controls.Add(panelLeft, 0, 0);
            tableLayoutPanelCustomer.Controls.Add(panelRight, 1, 0);
            tableLayoutPanelCustomer.Dock = DockStyle.Top;
            tableLayoutPanelCustomer.Location = new Point(0, 0);
            tableLayoutPanelCustomer.Name = "tableLayoutPanelCustomer";
            tableLayoutPanelCustomer.RowCount = 1;
            tableLayoutPanelCustomer.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanelCustomer.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanelCustomer.Size = new Size(1698, 300);
            tableLayoutPanelCustomer.TabIndex = 0;
            // 
            // panelLeft
            // 
            panelLeft.Controls.Add(btnRefreshCaptcha);
            panelLeft.Controls.Add(txtCaptcha);
            panelLeft.Controls.Add(picCaptcha);
            panelLeft.Controls.Add(txtCity);
            panelLeft.Controls.Add(txtState);
            panelLeft.Controls.Add(txtPinCode);
            panelLeft.Controls.Add(txtAddressLine2);
            panelLeft.Controls.Add(btnFetch);
            panelLeft.Controls.Add(txtAddressLine1);
            panelLeft.Controls.Add(lblCustomerAddress);
            panelLeft.Controls.Add(txtGSTNo);
            panelLeft.Controls.Add(txtCustomerMoNo);
            panelLeft.Controls.Add(txtPANNo);
            panelLeft.Controls.Add(lblCustomerMoNo);
            panelLeft.Controls.Add(lblCustomerName);
            panelLeft.Controls.Add(rdoGST);
            panelLeft.Controls.Add(rdoPAN);
            panelLeft.Controls.Add(txtCustomerName);
            panelLeft.Dock = DockStyle.Fill;
            panelLeft.Location = new Point(3, 3);
            panelLeft.Name = "panelLeft";
            panelLeft.Size = new Size(843, 294);
            panelLeft.TabIndex = 0;
            // 
            // btnRefreshCaptcha
            // 
            btnRefreshCaptcha.AutoSize = true;
            btnRefreshCaptcha.BackColor = Color.Transparent;
            btnRefreshCaptcha.Cursor = Cursors.Hand;
            btnRefreshCaptcha.FlatAppearance.BorderSize = 0;
            btnRefreshCaptcha.FlatAppearance.MouseDownBackColor = Color.Transparent;
            btnRefreshCaptcha.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btnRefreshCaptcha.FlatStyle = FlatStyle.Flat;
            btnRefreshCaptcha.Image = Properties.Resources.sync;
            btnRefreshCaptcha.Location = new Point(256, 122);
            btnRefreshCaptcha.Name = "btnRefreshCaptcha";
            btnRefreshCaptcha.Size = new Size(41, 30);
            btnRefreshCaptcha.TabIndex = 43;
            btnRefreshCaptcha.UseVisualStyleBackColor = false;
            btnRefreshCaptcha.Click += btnRefreshCaptcha_Click;
            // 
            // txtCaptcha
            // 
            txtCaptcha.Location = new Point(455, 127);
            txtCaptcha.Name = "txtCaptcha";
            txtCaptcha.PlaceholderText = "   Write Captcha";
            txtCaptcha.Size = new Size(96, 23);
            txtCaptcha.TabIndex = 42;
            // 
            // picCaptcha
            // 
            picCaptcha.BackColor = Color.White;
            picCaptcha.Location = new Point(301, 119);
            picCaptcha.Name = "picCaptcha";
            picCaptcha.Size = new Size(135, 37);
            picCaptcha.TabIndex = 41;
            picCaptcha.TabStop = false;
            // 
            // txtCity
            // 
            txtCity.Location = new Point(257, 236);
            txtCity.Margin = new Padding(3, 2, 3, 2);
            txtCity.Multiline = true;
            txtCity.Name = "txtCity";
            txtCity.PlaceholderText = "   Enter City";
            txtCity.RightToLeft = RightToLeft.No;
            txtCity.Size = new Size(410, 21);
            txtCity.TabIndex = 40;
            // 
            // txtState
            // 
            txtState.Location = new Point(256, 262);
            txtState.Margin = new Padding(3, 2, 3, 2);
            txtState.Multiline = true;
            txtState.Name = "txtState";
            txtState.PlaceholderText = "   Enter State";
            txtState.RightToLeft = RightToLeft.No;
            txtState.Size = new Size(410, 21);
            txtState.TabIndex = 39;
            // 
            // txtPinCode
            // 
            txtPinCode.Location = new Point(256, 210);
            txtPinCode.Margin = new Padding(3, 2, 3, 2);
            txtPinCode.Multiline = true;
            txtPinCode.Name = "txtPinCode";
            txtPinCode.PlaceholderText = "   Enter Pin Code";
            txtPinCode.RightToLeft = RightToLeft.No;
            txtPinCode.Size = new Size(410, 21);
            txtPinCode.TabIndex = 38;
            // 
            // txtAddressLine2
            // 
            txtAddressLine2.Location = new Point(256, 185);
            txtAddressLine2.Margin = new Padding(3, 2, 3, 2);
            txtAddressLine2.Multiline = true;
            txtAddressLine2.Name = "txtAddressLine2";
            txtAddressLine2.PlaceholderText = "   Address Line 2";
            txtAddressLine2.RightToLeft = RightToLeft.No;
            txtAddressLine2.Size = new Size(410, 21);
            txtAddressLine2.TabIndex = 37;
            // 
            // btnFetch
            // 
            btnFetch.BackColor = Color.Khaki;
            btnFetch.Cursor = Cursors.Hand;
            btnFetch.FlatAppearance.BorderSize = 0;
            btnFetch.FlatAppearance.MouseDownBackColor = Color.Gray;
            btnFetch.FlatStyle = FlatStyle.Flat;
            btnFetch.Font = new Font("Arial", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnFetch.ForeColor = Color.Black;
            btnFetch.Location = new Point(570, 128);
            btnFetch.Margin = new Padding(3, 2, 3, 2);
            btnFetch.Name = "btnFetch";
            btnFetch.Size = new Size(97, 22);
            btnFetch.TabIndex = 36;
            btnFetch.Text = "Fetch Details";
            btnFetch.UseVisualStyleBackColor = false;
            btnFetch.Click += btnFetchGST_Click;
            // 
            // txtAddressLine1
            // 
            txtAddressLine1.Location = new Point(256, 160);
            txtAddressLine1.Margin = new Padding(3, 2, 3, 2);
            txtAddressLine1.Multiline = true;
            txtAddressLine1.Name = "txtAddressLine1";
            txtAddressLine1.PlaceholderText = "   Address Line 1";
            txtAddressLine1.RightToLeft = RightToLeft.No;
            txtAddressLine1.Size = new Size(410, 21);
            txtAddressLine1.TabIndex = 28;
            // 
            // lblCustomerAddress
            // 
            lblCustomerAddress.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblCustomerAddress.ForeColor = Color.White;
            lblCustomerAddress.Location = new Point(56, 158);
            lblCustomerAddress.Name = "lblCustomerAddress";
            lblCustomerAddress.Size = new Size(170, 23);
            lblCustomerAddress.TabIndex = 27;
            lblCustomerAddress.Text = "Billing Address :";
            lblCustomerAddress.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtGSTNo
            // 
            txtGSTNo.Location = new Point(256, 92);
            txtGSTNo.Margin = new Padding(3, 2, 3, 2);
            txtGSTNo.Multiline = true;
            txtGSTNo.Name = "txtGSTNo";
            txtGSTNo.PlaceholderText = "   Enter Customer GST No";
            txtGSTNo.RightToLeft = RightToLeft.No;
            txtGSTNo.Size = new Size(410, 22);
            txtGSTNo.TabIndex = 26;
            // 
            // txtCustomerMoNo
            // 
            txtCustomerMoNo.Location = new Point(257, 50);
            txtCustomerMoNo.Margin = new Padding(3, 2, 3, 2);
            txtCustomerMoNo.Multiline = true;
            txtCustomerMoNo.Name = "txtCustomerMoNo";
            txtCustomerMoNo.PlaceholderText = "   Enter Customer Mobile No";
            txtCustomerMoNo.RightToLeft = RightToLeft.No;
            txtCustomerMoNo.Size = new Size(410, 22);
            txtCustomerMoNo.TabIndex = 25;
            // 
            // txtPANNo
            // 
            txtPANNo.Location = new Point(257, 92);
            txtPANNo.Margin = new Padding(3, 2, 3, 2);
            txtPANNo.Multiline = true;
            txtPANNo.Name = "txtPANNo";
            txtPANNo.PlaceholderText = "   Enter Customer PAN No";
            txtPANNo.RightToLeft = RightToLeft.No;
            txtPANNo.Size = new Size(410, 22);
            txtPANNo.TabIndex = 35;
            // 
            // lblCustomerMoNo
            // 
            lblCustomerMoNo.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblCustomerMoNo.ForeColor = Color.White;
            lblCustomerMoNo.Location = new Point(58, 50);
            lblCustomerMoNo.Name = "lblCustomerMoNo";
            lblCustomerMoNo.Size = new Size(176, 23);
            lblCustomerMoNo.TabIndex = 24;
            lblCustomerMoNo.Text = "Customer Mobile No :";
            lblCustomerMoNo.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblCustomerName
            // 
            lblCustomerName.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblCustomerName.ForeColor = Color.White;
            lblCustomerName.Location = new Point(58, 7);
            lblCustomerName.Name = "lblCustomerName";
            lblCustomerName.Size = new Size(170, 23);
            lblCustomerName.TabIndex = 20;
            lblCustomerName.Text = "Customer Name :";
            lblCustomerName.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // rdoGST
            // 
            rdoGST.AutoSize = true;
            rdoGST.Font = new Font("Arial Narrow", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            rdoGST.Location = new Point(56, 89);
            rdoGST.Name = "rdoGST";
            rdoGST.Size = new Size(74, 24);
            rdoGST.TabIndex = 33;
            rdoGST.TabStop = true;
            rdoGST.Text = "GST No";
            rdoGST.UseVisualStyleBackColor = true;
            rdoGST.CheckedChanged += rdoGST_CheckedChanged;
            // 
            // rdoPAN
            // 
            rdoPAN.AutoSize = true;
            rdoPAN.Font = new Font("Arial Narrow", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            rdoPAN.Location = new Point(133, 90);
            rdoPAN.Name = "rdoPAN";
            rdoPAN.Size = new Size(75, 24);
            rdoPAN.TabIndex = 34;
            rdoPAN.TabStop = true;
            rdoPAN.Text = "PAN No";
            rdoPAN.UseVisualStyleBackColor = true;
            rdoPAN.CheckedChanged += rdoPAN_CheckedChanged;
            // 
            // txtCustomerName
            // 
            txtCustomerName.Location = new Point(257, 7);
            txtCustomerName.Margin = new Padding(3, 2, 3, 2);
            txtCustomerName.Multiline = true;
            txtCustomerName.Name = "txtCustomerName";
            txtCustomerName.PlaceholderText = "   Enter Customer Name";
            txtCustomerName.RightToLeft = RightToLeft.No;
            txtCustomerName.Size = new Size(410, 22);
            txtCustomerName.TabIndex = 21;
            // 
            // panelRight
            // 
            panelRight.Controls.Add(txtShipCity);
            panelRight.Controls.Add(chksameas);
            panelRight.Controls.Add(txtShipState);
            panelRight.Controls.Add(txtShipPinCode);
            panelRight.Controls.Add(txtShipAddressLine2);
            panelRight.Controls.Add(txtAltContact);
            panelRight.Controls.Add(txtShipAddressLine1);
            panelRight.Controls.Add(lblCustomeraltno);
            panelRight.Controls.Add(lblCustShippingaddress);
            panelRight.Controls.Add(lblCustomerEmail);
            panelRight.Controls.Add(txtCustomerEmail);
            panelRight.Dock = DockStyle.Fill;
            panelRight.Location = new Point(852, 3);
            panelRight.Name = "panelRight";
            panelRight.Size = new Size(843, 294);
            panelRight.TabIndex = 1;
            // 
            // txtShipCity
            // 
            txtShipCity.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtShipCity.Location = new Point(204, 210);
            txtShipCity.Margin = new Padding(3, 2, 3, 2);
            txtShipCity.Multiline = true;
            txtShipCity.Name = "txtShipCity";
            txtShipCity.PlaceholderText = "   Enter City";
            txtShipCity.RightToLeft = RightToLeft.No;
            txtShipCity.Size = new Size(410, 21);
            txtShipCity.TabIndex = 44;
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
            chksameas.Location = new Point(204, 262);
            chksameas.Margin = new Padding(3, 2, 3, 2);
            chksameas.Name = "chksameas";
            chksameas.Size = new Size(410, 31);
            chksameas.TabIndex = 32;
            chksameas.Text = "   Same As Billing Address";
            chksameas.UseVisualStyleBackColor = false;
            // 
            // txtShipState
            // 
            txtShipState.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtShipState.Location = new Point(204, 236);
            txtShipState.Margin = new Padding(3, 2, 3, 2);
            txtShipState.Multiline = true;
            txtShipState.Name = "txtShipState";
            txtShipState.PlaceholderText = "   Enter State";
            txtShipState.RightToLeft = RightToLeft.No;
            txtShipState.Size = new Size(410, 21);
            txtShipState.TabIndex = 43;
            // 
            // txtShipPinCode
            // 
            txtShipPinCode.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtShipPinCode.Location = new Point(204, 185);
            txtShipPinCode.Margin = new Padding(3, 2, 3, 2);
            txtShipPinCode.Multiline = true;
            txtShipPinCode.Name = "txtShipPinCode";
            txtShipPinCode.PlaceholderText = "   Enter Pin Code";
            txtShipPinCode.RightToLeft = RightToLeft.No;
            txtShipPinCode.Size = new Size(410, 21);
            txtShipPinCode.TabIndex = 42;
            // 
            // txtShipAddressLine2
            // 
            txtShipAddressLine2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtShipAddressLine2.Location = new Point(204, 160);
            txtShipAddressLine2.Margin = new Padding(3, 2, 3, 2);
            txtShipAddressLine2.Multiline = true;
            txtShipAddressLine2.Name = "txtShipAddressLine2";
            txtShipAddressLine2.PlaceholderText = "   Address Line 2";
            txtShipAddressLine2.RightToLeft = RightToLeft.No;
            txtShipAddressLine2.Size = new Size(410, 21);
            txtShipAddressLine2.TabIndex = 41;
            // 
            // txtAltContact
            // 
            txtAltContact.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtAltContact.Location = new Point(204, 8);
            txtAltContact.Margin = new Padding(3, 2, 3, 2);
            txtAltContact.Multiline = true;
            txtAltContact.Name = "txtAltContact";
            txtAltContact.PlaceholderText = "   Enter Customer ALT Mobile No";
            txtAltContact.RightToLeft = RightToLeft.No;
            txtAltContact.Size = new Size(410, 22);
            txtAltContact.TabIndex = 37;
            // 
            // txtShipAddressLine1
            // 
            txtShipAddressLine1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtShipAddressLine1.Location = new Point(204, 135);
            txtShipAddressLine1.Margin = new Padding(3, 2, 3, 2);
            txtShipAddressLine1.Multiline = true;
            txtShipAddressLine1.Name = "txtShipAddressLine1";
            txtShipAddressLine1.PlaceholderText = "   Address Line 1";
            txtShipAddressLine1.RightToLeft = RightToLeft.No;
            txtShipAddressLine1.Size = new Size(410, 21);
            txtShipAddressLine1.TabIndex = 31;
            // 
            // lblCustomeraltno
            // 
            lblCustomeraltno.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblCustomeraltno.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblCustomeraltno.ForeColor = Color.White;
            lblCustomeraltno.Location = new Point(5, 8);
            lblCustomeraltno.Name = "lblCustomeraltno";
            lblCustomeraltno.Size = new Size(193, 23);
            lblCustomeraltno.TabIndex = 36;
            lblCustomeraltno.Text = "Customer ALT Mobile No :";
            lblCustomeraltno.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblCustShippingaddress
            // 
            lblCustShippingaddress.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblCustShippingaddress.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblCustShippingaddress.ForeColor = Color.White;
            lblCustShippingaddress.Location = new Point(5, 133);
            lblCustShippingaddress.Name = "lblCustShippingaddress";
            lblCustShippingaddress.Size = new Size(170, 23);
            lblCustShippingaddress.TabIndex = 30;
            lblCustShippingaddress.Text = "Shipping Address :";
            lblCustShippingaddress.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblCustomerEmail
            // 
            lblCustomerEmail.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblCustomerEmail.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblCustomerEmail.ForeColor = Color.White;
            lblCustomerEmail.Location = new Point(5, 49);
            lblCustomerEmail.Name = "lblCustomerEmail";
            lblCustomerEmail.Size = new Size(141, 23);
            lblCustomerEmail.TabIndex = 22;
            lblCustomerEmail.Text = "Customer Email :";
            lblCustomerEmail.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtCustomerEmail
            // 
            txtCustomerEmail.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtCustomerEmail.Location = new Point(204, 49);
            txtCustomerEmail.Margin = new Padding(3, 2, 3, 2);
            txtCustomerEmail.Multiline = true;
            txtCustomerEmail.Name = "txtCustomerEmail";
            txtCustomerEmail.PlaceholderText = "   Enter Customer Email";
            txtCustomerEmail.RightToLeft = RightToLeft.No;
            txtCustomerEmail.Size = new Size(410, 22);
            txtCustomerEmail.TabIndex = 23;
            // 
            // Customer
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1698, 677);
            Controls.Add(panelCustomer);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 2, 3, 2);
            Name = "Customer";
            Text = "Customer";
            Load += Customer_Load;
            panelCustomer.ResumeLayout(false);
            panelcustomerdata.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgv).EndInit();
            panelMenu.ResumeLayout(false);
            panelMenu.PerformLayout();
            panelforbutton.ResumeLayout(false);
            tableLayoutPanelCustomer.ResumeLayout(false);
            panelLeft.ResumeLayout(false);
            panelLeft.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picCaptcha).EndInit();
            panelRight.ResumeLayout(false);
            panelRight.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelCustomer;
        private TextBox txtCustomerGSTORPAN;
        private Panel panelforbutton;
        private Button btnAddCustomer;
        private TableLayoutPanel tableLayoutPanelCustomer;
        private Panel panelLeft;
        private TextBox txtAddressLine1;
        private Label lblCustomerAddress;
        private TextBox txtGSTNo;
        private TextBox txtCustomerMoNo;
        private TextBox txtPANNo;
        private Label lblCustomerMoNo;
        private Label lblCustomerName;
        private RadioButton rdoGST;
        private RadioButton rdoPAN;
        private TextBox txtCustomerName;
        private Panel panelRight;
        private TextBox txtAltContact;
        private TextBox txtShipAddressLine1;
        private Label lblCustomeraltno;
        private Label lblCustShippingaddress;
        private Label lblCustomerEmail;
        private TextBox txtCustomerEmail;
        private CheckBox chksameas;
        private Panel panelcustomerdata;
        private Panel panelMenu;
        private DataGridView dgv;
        private TextBox txtCustomerSearchPAN;
        private TextBox txtCustomerSearchGST;
        private TextBox txtSearchCustomerEmail;
        private TextBox txtSearchCustomerNo;
        private TextBox txtSearchCustomer;
        private TextBox txtSearchCustomerShippingAddress;
        private TextBox txtSeachCustomerBillingAddress;
        private Button btnFetch;
        private TextBox txtState;
        private TextBox txtPinCode;
        private TextBox txtAddressLine2;
        private Button btnClear;
        private TextBox txtCity;
        private TextBox txtShipCity;
        private TextBox txtShipState;
        private TextBox txtShipPinCode;
        private TextBox txtShipAddressLine2;
        private TextBox txtCaptcha;
        private PictureBox picCaptcha;
        private Button btnRefreshCaptcha;
    }
}