namespace JPSCURA
{
    partial class SalesQuote2ndpage
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
            panelTerms = new Panel();
            txtPaymentTerms = new TextBox();
            lblPayment = new Label();
            txtDeliveryPeriod = new TextBox();
            lblDelivery = new Label();
            cmbValidity = new ComboBox();
            lblValidity = new Label();
            dgvItems = new DataGridView();
            panelTOP = new Panel();
            btnGenerate = new Button();
            btnSave = new Button();
            btnDelete = new Button();
            btnAddRow = new Button();
            btnClear = new Button();
            tblpanelmain = new TableLayoutPanel();
            panelleft = new Panel();
            txtCity = new TextBox();
            txtBuyersreferenceanddate = new TextBox();
            lblreferncedate = new Label();
            txtkindattname = new TextBox();
            txtState = new TextBox();
            lblKingAttn = new Label();
            lblCustomerAddress = new Label();
            txtPinCode = new TextBox();
            dtQuotationDate = new DateTimePicker();
            txtAddressLine1 = new TextBox();
            lblquotationdate = new Label();
            txtAddressLine2 = new TextBox();
            cmbselectcustomer = new ComboBox();
            lblSelectCustomer = new Label();
            panelright = new Panel();
            txtShipCity = new TextBox();
            txtPANNo = new TextBox();
            txtShipState = new TextBox();
            txtGSTno = new TextBox();
            txtShipPinCode = new TextBox();
            txtShipAddressLine2 = new TextBox();
            rdoPAN = new RadioButton();
            txtShipAddressLine1 = new TextBox();
            rdoGST = new RadioButton();
            lblCustShippingaddress = new Label();
            cmbgst = new ComboBox();
            lblGST = new Label();
            txtQuotationNo = new TextBox();
            lblQuotationNo = new Label();
            panelMain.SuspendLayout();
            panelTerms.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvItems).BeginInit();
            panelTOP.SuspendLayout();
            tblpanelmain.SuspendLayout();
            panelleft.SuspendLayout();
            panelright.SuspendLayout();
            SuspendLayout();
            // 
            // panelMain
            // 
            panelMain.BackColor = Color.FromArgb(83, 144, 204);
            panelMain.Controls.Add(panelTerms);
            panelMain.Controls.Add(dgvItems);
            panelMain.Controls.Add(panelTOP);
            panelMain.Controls.Add(tblpanelmain);
            panelMain.Dock = DockStyle.Fill;
            panelMain.Location = new Point(0, 0);
            panelMain.Name = "panelMain";
            panelMain.Size = new Size(1370, 806);
            panelMain.TabIndex = 0;
            // 
            // panelTerms
            // 
            panelTerms.BackColor = Color.FromArgb(83, 144, 204);
            panelTerms.Controls.Add(txtPaymentTerms);
            panelTerms.Controls.Add(lblPayment);
            panelTerms.Controls.Add(txtDeliveryPeriod);
            panelTerms.Controls.Add(lblDelivery);
            panelTerms.Controls.Add(cmbValidity);
            panelTerms.Controls.Add(lblValidity);
            panelTerms.Location = new Point(3, 686);
            panelTerms.Name = "panelTerms";
            panelTerms.Size = new Size(400, 120);
            panelTerms.TabIndex = 3;
            // 
            // txtPaymentTerms
            // 
            txtPaymentTerms.Location = new Point(156, 75);
            txtPaymentTerms.Name = "txtPaymentTerms";
            txtPaymentTerms.Size = new Size(241, 23);
            txtPaymentTerms.TabIndex = 5;
            // 
            // lblPayment
            // 
            lblPayment.AutoSize = true;
            lblPayment.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblPayment.ForeColor = Color.White;
            lblPayment.Location = new Point(9, 75);
            lblPayment.Name = "lblPayment";
            lblPayment.Size = new Size(86, 19);
            lblPayment.TabIndex = 4;
            lblPayment.Text = "Payment :";
            // 
            // txtDeliveryPeriod
            // 
            txtDeliveryPeriod.Location = new Point(156, 41);
            txtDeliveryPeriod.Name = "txtDeliveryPeriod";
            txtDeliveryPeriod.Size = new Size(241, 23);
            txtDeliveryPeriod.TabIndex = 3;
            // 
            // lblDelivery
            // 
            lblDelivery.AutoSize = true;
            lblDelivery.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblDelivery.ForeColor = Color.White;
            lblDelivery.Location = new Point(9, 45);
            lblDelivery.Name = "lblDelivery";
            lblDelivery.Size = new Size(134, 19);
            lblDelivery.TabIndex = 2;
            lblDelivery.Text = "Delivery period :";
            // 
            // cmbValidity
            // 
            cmbValidity.BackColor = Color.White;
            cmbValidity.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbValidity.FormattingEnabled = true;
            cmbValidity.Location = new Point(156, 8);
            cmbValidity.Name = "cmbValidity";
            cmbValidity.Size = new Size(241, 23);
            cmbValidity.TabIndex = 1;
            // 
            // lblValidity
            // 
            lblValidity.AutoSize = true;
            lblValidity.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblValidity.ForeColor = Color.White;
            lblValidity.Location = new Point(9, 12);
            lblValidity.Name = "lblValidity";
            lblValidity.Size = new Size(74, 19);
            lblValidity.TabIndex = 0;
            lblValidity.Text = "Validity :";
            // 
            // dgvItems
            // 
            dgvItems.AllowUserToAddRows = false;
            dgvItems.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvItems.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvItems.Location = new Point(9, 371);
            dgvItems.Name = "dgvItems";
            dgvItems.RowHeadersVisible = false;
            dgvItems.Size = new Size(1358, 150);
            dgvItems.TabIndex = 2;
            // 
            // panelTOP
            // 
            panelTOP.Controls.Add(btnGenerate);
            panelTOP.Controls.Add(btnSave);
            panelTOP.Controls.Add(btnDelete);
            panelTOP.Controls.Add(btnAddRow);
            panelTOP.Controls.Add(btnClear);
            panelTOP.Dock = DockStyle.Top;
            panelTOP.Location = new Point(0, 315);
            panelTOP.Name = "panelTOP";
            panelTOP.Size = new Size(1370, 50);
            panelTOP.TabIndex = 1;
            // 
            // btnGenerate
            // 
            btnGenerate.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnGenerate.BackColor = Color.White;
            btnGenerate.Cursor = Cursors.Hand;
            btnGenerate.FlatAppearance.BorderSize = 0;
            btnGenerate.FlatAppearance.MouseDownBackColor = Color.Red;
            btnGenerate.FlatAppearance.MouseOverBackColor = Color.Red;
            btnGenerate.Font = new Font("Arial", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnGenerate.ForeColor = Color.SandyBrown;
            btnGenerate.Location = new Point(931, 10);
            btnGenerate.Margin = new Padding(3, 2, 3, 2);
            btnGenerate.Name = "btnGenerate";
            btnGenerate.Size = new Size(141, 29);
            btnGenerate.TabIndex = 35;
            btnGenerate.Text = "Generate";
            btnGenerate.UseVisualStyleBackColor = false;
            btnGenerate.Click += btnGenerate_Click;
            // 
            // btnSave
            // 
            btnSave.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnSave.AutoSize = true;
            btnSave.BackColor = Color.White;
            btnSave.Cursor = Cursors.Hand;
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.FlatAppearance.MouseDownBackColor = Color.Honeydew;
            btnSave.FlatAppearance.MouseOverBackColor = Color.Lime;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Font = new Font("Arial", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSave.ForeColor = Color.FromArgb(64, 64, 64);
            btnSave.Image = Properties.Resources.save;
            btnSave.ImageAlign = ContentAlignment.MiddleLeft;
            btnSave.Location = new Point(843, 10);
            btnSave.Margin = new Padding(3, 2, 3, 2);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(72, 29);
            btnSave.TabIndex = 34;
            btnSave.Text = "Save";
            btnSave.TextAlign = ContentAlignment.MiddleRight;
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // btnDelete
            // 
            btnDelete.Anchor = AnchorStyles.Right;
            btnDelete.BackColor = Color.White;
            btnDelete.Cursor = Cursors.Hand;
            btnDelete.FlatAppearance.BorderSize = 0;
            btnDelete.FlatAppearance.MouseDownBackColor = Color.Red;
            btnDelete.FlatAppearance.MouseOverBackColor = Color.Red;
            btnDelete.Font = new Font("Arial", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnDelete.ForeColor = Color.Red;
            btnDelete.Location = new Point(1079, 10);
            btnDelete.Margin = new Padding(3, 2, 3, 2);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(141, 29);
            btnDelete.TabIndex = 33;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnAddRow
            // 
            btnAddRow.Anchor = AnchorStyles.Right;
            btnAddRow.BackColor = Color.White;
            btnAddRow.Cursor = Cursors.Hand;
            btnAddRow.FlatAppearance.BorderSize = 0;
            btnAddRow.FlatAppearance.MouseDownBackColor = Color.Red;
            btnAddRow.FlatAppearance.MouseOverBackColor = Color.Red;
            btnAddRow.Font = new Font("Arial", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAddRow.ForeColor = Color.SeaGreen;
            btnAddRow.Location = new Point(1226, 10);
            btnAddRow.Margin = new Padding(3, 2, 3, 2);
            btnAddRow.Name = "btnAddRow";
            btnAddRow.Size = new Size(141, 29);
            btnAddRow.TabIndex = 32;
            btnAddRow.Text = "Add New Row";
            btnAddRow.UseVisualStyleBackColor = false;
            btnAddRow.Click += btnAddRow_Click;
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
            btnClear.Location = new Point(531, 10);
            btnClear.Margin = new Padding(3, 2, 3, 2);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(141, 29);
            btnClear.TabIndex = 31;
            btnClear.Text = "Clear";
            btnClear.UseVisualStyleBackColor = false;
            btnClear.Click += btnClear_Click;
            // 
            // tblpanelmain
            // 
            tblpanelmain.ColumnCount = 2;
            tblpanelmain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tblpanelmain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tblpanelmain.Controls.Add(panelleft, 0, 0);
            tblpanelmain.Controls.Add(panelright, 1, 0);
            tblpanelmain.Dock = DockStyle.Top;
            tblpanelmain.Location = new Point(0, 0);
            tblpanelmain.Name = "tblpanelmain";
            tblpanelmain.RowCount = 1;
            tblpanelmain.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tblpanelmain.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tblpanelmain.Size = new Size(1370, 315);
            tblpanelmain.TabIndex = 0;
            // 
            // panelleft
            // 
            panelleft.Controls.Add(txtCity);
            panelleft.Controls.Add(txtBuyersreferenceanddate);
            panelleft.Controls.Add(lblreferncedate);
            panelleft.Controls.Add(txtkindattname);
            panelleft.Controls.Add(txtState);
            panelleft.Controls.Add(lblKingAttn);
            panelleft.Controls.Add(lblCustomerAddress);
            panelleft.Controls.Add(txtPinCode);
            panelleft.Controls.Add(dtQuotationDate);
            panelleft.Controls.Add(txtAddressLine1);
            panelleft.Controls.Add(lblquotationdate);
            panelleft.Controls.Add(txtAddressLine2);
            panelleft.Controls.Add(cmbselectcustomer);
            panelleft.Controls.Add(lblSelectCustomer);
            panelleft.Dock = DockStyle.Top;
            panelleft.Location = new Point(3, 3);
            panelleft.Name = "panelleft";
            panelleft.Size = new Size(679, 309);
            panelleft.TabIndex = 0;
            // 
            // txtCity
            // 
            txtCity.BackColor = SystemColors.Window;
            txtCity.Location = new Point(248, 259);
            txtCity.Margin = new Padding(3, 2, 3, 2);
            txtCity.Multiline = true;
            txtCity.Name = "txtCity";
            txtCity.PlaceholderText = "   Enter City";
            txtCity.ReadOnly = true;
            txtCity.RightToLeft = RightToLeft.No;
            txtCity.Size = new Size(410, 21);
            txtCity.TabIndex = 46;
            // 
            // txtBuyersreferenceanddate
            // 
            txtBuyersreferenceanddate.Location = new Point(248, 145);
            txtBuyersreferenceanddate.Name = "txtBuyersreferenceanddate";
            txtBuyersreferenceanddate.PlaceholderText = "    Reference Note";
            txtBuyersreferenceanddate.Size = new Size(410, 23);
            txtBuyersreferenceanddate.TabIndex = 7;
            // 
            // lblreferncedate
            // 
            lblreferncedate.AutoSize = true;
            lblreferncedate.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblreferncedate.ForeColor = Color.White;
            lblreferncedate.Location = new Point(9, 147);
            lblreferncedate.Name = "lblreferncedate";
            lblreferncedate.Size = new Size(233, 19);
            lblreferncedate.TabIndex = 6;
            lblreferncedate.Text = "Buyer's Reference And Date :";
            // 
            // txtkindattname
            // 
            txtkindattname.Location = new Point(248, 105);
            txtkindattname.Name = "txtkindattname";
            txtkindattname.PlaceholderText = "   Concerned Person Name";
            txtkindattname.Size = new Size(410, 23);
            txtkindattname.TabIndex = 5;
            // 
            // txtState
            // 
            txtState.BackColor = SystemColors.Window;
            txtState.Location = new Point(248, 285);
            txtState.Margin = new Padding(3, 2, 3, 2);
            txtState.Multiline = true;
            txtState.Name = "txtState";
            txtState.PlaceholderText = "   Enter State";
            txtState.ReadOnly = true;
            txtState.RightToLeft = RightToLeft.No;
            txtState.Size = new Size(410, 21);
            txtState.TabIndex = 45;
            // 
            // lblKingAttn
            // 
            lblKingAttn.AutoSize = true;
            lblKingAttn.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblKingAttn.ForeColor = Color.White;
            lblKingAttn.Location = new Point(9, 107);
            lblKingAttn.Name = "lblKingAttn";
            lblKingAttn.Size = new Size(175, 19);
            lblKingAttn.TabIndex = 4;
            lblKingAttn.Text = "Kind Attention Name :";
            // 
            // lblCustomerAddress
            // 
            lblCustomerAddress.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblCustomerAddress.ForeColor = Color.White;
            lblCustomerAddress.Location = new Point(9, 184);
            lblCustomerAddress.Name = "lblCustomerAddress";
            lblCustomerAddress.Size = new Size(170, 23);
            lblCustomerAddress.TabIndex = 41;
            lblCustomerAddress.Text = "Billing Address :";
            lblCustomerAddress.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtPinCode
            // 
            txtPinCode.BackColor = SystemColors.Window;
            txtPinCode.Location = new Point(248, 234);
            txtPinCode.Margin = new Padding(3, 2, 3, 2);
            txtPinCode.Multiline = true;
            txtPinCode.Name = "txtPinCode";
            txtPinCode.PlaceholderText = "   Enter Pin Code";
            txtPinCode.ReadOnly = true;
            txtPinCode.RightToLeft = RightToLeft.No;
            txtPinCode.Size = new Size(410, 21);
            txtPinCode.TabIndex = 44;
            // 
            // dtQuotationDate
            // 
            dtQuotationDate.Location = new Point(248, 59);
            dtQuotationDate.Name = "dtQuotationDate";
            dtQuotationDate.Size = new Size(410, 23);
            dtQuotationDate.TabIndex = 3;
            // 
            // txtAddressLine1
            // 
            txtAddressLine1.BackColor = SystemColors.Window;
            txtAddressLine1.Location = new Point(248, 184);
            txtAddressLine1.Margin = new Padding(3, 2, 3, 2);
            txtAddressLine1.Multiline = true;
            txtAddressLine1.Name = "txtAddressLine1";
            txtAddressLine1.PlaceholderText = "   Address Line 1";
            txtAddressLine1.ReadOnly = true;
            txtAddressLine1.RightToLeft = RightToLeft.No;
            txtAddressLine1.Size = new Size(410, 21);
            txtAddressLine1.TabIndex = 42;
            // 
            // lblquotationdate
            // 
            lblquotationdate.AutoSize = true;
            lblquotationdate.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblquotationdate.ForeColor = Color.White;
            lblquotationdate.Location = new Point(9, 63);
            lblquotationdate.Name = "lblquotationdate";
            lblquotationdate.Size = new Size(142, 19);
            lblquotationdate.TabIndex = 2;
            lblquotationdate.Text = "Quoatation Date :";
            // 
            // txtAddressLine2
            // 
            txtAddressLine2.BackColor = SystemColors.Window;
            txtAddressLine2.Location = new Point(248, 209);
            txtAddressLine2.Margin = new Padding(3, 2, 3, 2);
            txtAddressLine2.Multiline = true;
            txtAddressLine2.Name = "txtAddressLine2";
            txtAddressLine2.PlaceholderText = "   Address Line 2";
            txtAddressLine2.ReadOnly = true;
            txtAddressLine2.RightToLeft = RightToLeft.No;
            txtAddressLine2.Size = new Size(410, 21);
            txtAddressLine2.TabIndex = 43;
            // 
            // cmbselectcustomer
            // 
            cmbselectcustomer.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbselectcustomer.FormattingEnabled = true;
            cmbselectcustomer.Location = new Point(248, 22);
            cmbselectcustomer.Name = "cmbselectcustomer";
            cmbselectcustomer.Size = new Size(410, 23);
            cmbselectcustomer.TabIndex = 1;
            cmbselectcustomer.SelectedIndexChanged += cmbselectcustomer_SelectedIndexChanged;
            // 
            // lblSelectCustomer
            // 
            lblSelectCustomer.AutoSize = true;
            lblSelectCustomer.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblSelectCustomer.ForeColor = Color.White;
            lblSelectCustomer.Location = new Point(9, 22);
            lblSelectCustomer.Name = "lblSelectCustomer";
            lblSelectCustomer.Size = new Size(145, 19);
            lblSelectCustomer.TabIndex = 0;
            lblSelectCustomer.Text = "Select Customer :";
            // 
            // panelright
            // 
            panelright.Controls.Add(txtShipCity);
            panelright.Controls.Add(txtPANNo);
            panelright.Controls.Add(txtShipState);
            panelright.Controls.Add(txtGSTno);
            panelright.Controls.Add(txtShipPinCode);
            panelright.Controls.Add(txtShipAddressLine2);
            panelright.Controls.Add(rdoPAN);
            panelright.Controls.Add(txtShipAddressLine1);
            panelright.Controls.Add(rdoGST);
            panelright.Controls.Add(lblCustShippingaddress);
            panelright.Controls.Add(cmbgst);
            panelright.Controls.Add(lblGST);
            panelright.Controls.Add(txtQuotationNo);
            panelright.Controls.Add(lblQuotationNo);
            panelright.Dock = DockStyle.Top;
            panelright.Location = new Point(688, 3);
            panelright.Name = "panelright";
            panelright.Size = new Size(679, 309);
            panelright.TabIndex = 1;
            // 
            // txtShipCity
            // 
            txtShipCity.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtShipCity.BackColor = SystemColors.Window;
            txtShipCity.Location = new Point(188, 259);
            txtShipCity.Margin = new Padding(3, 2, 3, 2);
            txtShipCity.Multiline = true;
            txtShipCity.Name = "txtShipCity";
            txtShipCity.PlaceholderText = "   Enter City";
            txtShipCity.ReadOnly = true;
            txtShipCity.RightToLeft = RightToLeft.No;
            txtShipCity.Size = new Size(410, 21);
            txtShipCity.TabIndex = 50;
            // 
            // txtPANNo
            // 
            txtPANNo.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtPANNo.Location = new Point(188, 105);
            txtPANNo.Name = "txtPANNo";
            txtPANNo.PlaceholderText = "   PAN No";
            txtPANNo.Size = new Size(410, 23);
            txtPANNo.TabIndex = 37;
            // 
            // txtShipState
            // 
            txtShipState.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtShipState.BackColor = SystemColors.Window;
            txtShipState.Location = new Point(188, 285);
            txtShipState.Margin = new Padding(3, 2, 3, 2);
            txtShipState.Multiline = true;
            txtShipState.Name = "txtShipState";
            txtShipState.PlaceholderText = "   Enter State";
            txtShipState.ReadOnly = true;
            txtShipState.RightToLeft = RightToLeft.No;
            txtShipState.Size = new Size(410, 21);
            txtShipState.TabIndex = 49;
            // 
            // txtGSTno
            // 
            txtGSTno.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtGSTno.Location = new Point(188, 105);
            txtGSTno.Name = "txtGSTno";
            txtGSTno.PlaceholderText = "   GST No";
            txtGSTno.Size = new Size(410, 23);
            txtGSTno.TabIndex = 36;
            // 
            // txtShipPinCode
            // 
            txtShipPinCode.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtShipPinCode.BackColor = SystemColors.Window;
            txtShipPinCode.Location = new Point(188, 234);
            txtShipPinCode.Margin = new Padding(3, 2, 3, 2);
            txtShipPinCode.Multiline = true;
            txtShipPinCode.Name = "txtShipPinCode";
            txtShipPinCode.PlaceholderText = "   Enter Pin Code";
            txtShipPinCode.ReadOnly = true;
            txtShipPinCode.RightToLeft = RightToLeft.No;
            txtShipPinCode.Size = new Size(410, 21);
            txtShipPinCode.TabIndex = 48;
            // 
            // txtShipAddressLine2
            // 
            txtShipAddressLine2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtShipAddressLine2.BackColor = SystemColors.Window;
            txtShipAddressLine2.Location = new Point(188, 209);
            txtShipAddressLine2.Margin = new Padding(3, 2, 3, 2);
            txtShipAddressLine2.Multiline = true;
            txtShipAddressLine2.Name = "txtShipAddressLine2";
            txtShipAddressLine2.PlaceholderText = "   Address Line 2";
            txtShipAddressLine2.ReadOnly = true;
            txtShipAddressLine2.RightToLeft = RightToLeft.No;
            txtShipAddressLine2.Size = new Size(410, 21);
            txtShipAddressLine2.TabIndex = 47;
            // 
            // rdoPAN
            // 
            rdoPAN.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            rdoPAN.AutoSize = true;
            rdoPAN.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            rdoPAN.ForeColor = Color.White;
            rdoPAN.Location = new Point(96, 105);
            rdoPAN.Name = "rdoPAN";
            rdoPAN.Size = new Size(86, 23);
            rdoPAN.TabIndex = 35;
            rdoPAN.TabStop = true;
            rdoPAN.Text = "PAN No";
            rdoPAN.UseVisualStyleBackColor = true;
            // 
            // txtShipAddressLine1
            // 
            txtShipAddressLine1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtShipAddressLine1.BackColor = SystemColors.Window;
            txtShipAddressLine1.Location = new Point(188, 184);
            txtShipAddressLine1.Margin = new Padding(3, 2, 3, 2);
            txtShipAddressLine1.Multiline = true;
            txtShipAddressLine1.Name = "txtShipAddressLine1";
            txtShipAddressLine1.PlaceholderText = "   Address Line 1";
            txtShipAddressLine1.ReadOnly = true;
            txtShipAddressLine1.RightToLeft = RightToLeft.No;
            txtShipAddressLine1.Size = new Size(410, 21);
            txtShipAddressLine1.TabIndex = 46;
            // 
            // rdoGST
            // 
            rdoGST.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            rdoGST.AutoSize = true;
            rdoGST.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            rdoGST.ForeColor = Color.White;
            rdoGST.Location = new Point(4, 105);
            rdoGST.Name = "rdoGST";
            rdoGST.Size = new Size(86, 23);
            rdoGST.TabIndex = 34;
            rdoGST.TabStop = true;
            rdoGST.Text = "GST No";
            rdoGST.UseVisualStyleBackColor = true;
            // 
            // lblCustShippingaddress
            // 
            lblCustShippingaddress.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblCustShippingaddress.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblCustShippingaddress.ForeColor = Color.White;
            lblCustShippingaddress.Location = new Point(4, 184);
            lblCustShippingaddress.Name = "lblCustShippingaddress";
            lblCustShippingaddress.Size = new Size(170, 23);
            lblCustShippingaddress.TabIndex = 45;
            lblCustShippingaddress.Text = "Shipping Address :";
            lblCustShippingaddress.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // cmbgst
            // 
            cmbgst.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            cmbgst.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbgst.FormattingEnabled = true;
            cmbgst.Location = new Point(188, 63);
            cmbgst.Name = "cmbgst";
            cmbgst.Size = new Size(410, 23);
            cmbgst.TabIndex = 4;
            // 
            // lblGST
            // 
            lblGST.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblGST.AutoSize = true;
            lblGST.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblGST.ForeColor = Color.White;
            lblGST.Location = new Point(7, 65);
            lblGST.Name = "lblGST";
            lblGST.Size = new Size(52, 19);
            lblGST.TabIndex = 3;
            lblGST.Text = "GST :";
            // 
            // txtQuotationNo
            // 
            txtQuotationNo.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtQuotationNo.Location = new Point(188, 19);
            txtQuotationNo.Name = "txtQuotationNo";
            txtQuotationNo.PlaceholderText = "   Quotation No";
            txtQuotationNo.Size = new Size(410, 23);
            txtQuotationNo.TabIndex = 2;
            // 
            // lblQuotationNo
            // 
            lblQuotationNo.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblQuotationNo.AutoSize = true;
            lblQuotationNo.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblQuotationNo.ForeColor = Color.White;
            lblQuotationNo.Location = new Point(4, 22);
            lblQuotationNo.Name = "lblQuotationNo";
            lblQuotationNo.Size = new Size(120, 19);
            lblQuotationNo.TabIndex = 1;
            lblQuotationNo.Text = "Quotation No :";
            // 
            // SalesQuote2ndpage
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1370, 806);
            Controls.Add(panelMain);
            FormBorderStyle = FormBorderStyle.None;
            Name = "SalesQuote2ndpage";
            Text = "SalesQuote2ndpage";
            Load += SalesQuote2ndpage_Load;
            panelMain.ResumeLayout(false);
            panelTerms.ResumeLayout(false);
            panelTerms.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvItems).EndInit();
            panelTOP.ResumeLayout(false);
            panelTOP.PerformLayout();
            tblpanelmain.ResumeLayout(false);
            panelleft.ResumeLayout(false);
            panelleft.PerformLayout();
            panelright.ResumeLayout(false);
            panelright.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelMain;
        private TableLayoutPanel tblpanelmain;
        private Panel panelleft;
        private Label lblSelectCustomer;
        private Panel panelright;
        private ComboBox cmbselectcustomer;
        private TextBox txtQuotationNo;
        private Label lblQuotationNo;
        private DateTimePicker dtQuotationDate;
        private Label lblquotationdate;
        private ComboBox cmbgst;
        private Label lblGST;
        private RadioButton rdoGST;
        private RadioButton rdoPAN;
        private TextBox txtPANNo;
        private TextBox txtGSTno;
        private TextBox txtkindattname;
        private Label lblKingAttn;
        private TextBox txtBuyersreferenceanddate;
        private Label lblreferncedate;
        private TextBox txtCity;
        private TextBox txtState;
        private TextBox txtPinCode;
        private TextBox txtAddressLine2;
        private TextBox txtAddressLine1;
        private Label lblCustomerAddress;
        private Panel panelTOP;
        private TextBox txtShipCity;
        private TextBox txtShipState;
        private TextBox txtShipPinCode;
        private TextBox txtShipAddressLine2;
        private TextBox txtShipAddressLine1;
        private Label lblCustShippingaddress;
        private Button btnClear;
        private DataGridView dgvItems;
        private Button btnAddRow;
        private Button btnDelete;
        private Panel panelTerms;
        private TextBox txtPaymentTerms;
        private Label lblPayment;
        private TextBox txtDeliveryPeriod;
        private Label lblDelivery;
        private ComboBox cmbValidity;
        private Label lblValidity;
        private Button btnGenerate;
        private Button btnSave;
    }
}