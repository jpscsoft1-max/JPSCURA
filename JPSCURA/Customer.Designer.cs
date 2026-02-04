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
            panelforbutton = new Panel();
            btnAddCustomer = new Button();
            tableLayoutPanelCustomer = new TableLayoutPanel();
            panelLeft = new Panel();
            txtCustomerAddress = new TextBox();
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
            txtAltContact = new TextBox();
            txtshippingaddress = new TextBox();
            lblCustomeraltno = new Label();
            lblCustShippingaddress = new Label();
            lblCustomerEmail = new Label();
            txtCustomerEmail = new TextBox();
            chksameas = new CheckBox();
            panelCustomer.SuspendLayout();
            panelcustomerdata.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgv).BeginInit();
            panelforbutton.SuspendLayout();
            tableLayoutPanelCustomer.SuspendLayout();
            panelLeft.SuspendLayout();
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
            panelMenu.Dock = DockStyle.Top;
            panelMenu.Location = new Point(0, 0);
            panelMenu.Name = "panelMenu";
            panelMenu.Size = new Size(1698, 50);
            panelMenu.TabIndex = 0;
            // 
            // panelforbutton
            // 
            panelforbutton.Controls.Add(btnAddCustomer);
            panelforbutton.Dock = DockStyle.Top;
            panelforbutton.Location = new Point(0, 300);
            panelforbutton.Name = "panelforbutton";
            panelforbutton.Size = new Size(1698, 40);
            panelforbutton.TabIndex = 30;
            // 
            // btnAddCustomer
            // 
            btnAddCustomer.Anchor = AnchorStyles.Top;
            btnAddCustomer.BackColor = Color.ForestGreen;
            btnAddCustomer.Cursor = Cursors.Hand;
            btnAddCustomer.FlatAppearance.BorderSize = 0;
            btnAddCustomer.FlatAppearance.MouseDownBackColor = Color.Gray;
            btnAddCustomer.FlatStyle = FlatStyle.Flat;
            btnAddCustomer.Font = new Font("Arial", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAddCustomer.ForeColor = Color.SeaShell;
            btnAddCustomer.Location = new Point(781, 6);
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
            panelLeft.Controls.Add(txtCustomerAddress);
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
            // txtCustomerAddress
            // 
            txtCustomerAddress.Location = new Point(430, 158);
            txtCustomerAddress.Margin = new Padding(3, 2, 3, 2);
            txtCustomerAddress.Multiline = true;
            txtCustomerAddress.Name = "txtCustomerAddress";
            txtCustomerAddress.PlaceholderText = "   Enter Billing Address";
            txtCustomerAddress.RightToLeft = RightToLeft.No;
            txtCustomerAddress.Size = new Size(410, 74);
            txtCustomerAddress.TabIndex = 28;
            // 
            // lblCustomerAddress
            // 
            lblCustomerAddress.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblCustomerAddress.ForeColor = Color.White;
            lblCustomerAddress.Location = new Point(231, 156);
            lblCustomerAddress.Name = "lblCustomerAddress";
            lblCustomerAddress.Size = new Size(170, 23);
            lblCustomerAddress.TabIndex = 27;
            lblCustomerAddress.Text = "Billing Address :";
            lblCustomerAddress.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtGSTNo
            // 
            txtGSTNo.Location = new Point(430, 115);
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
            txtCustomerMoNo.Location = new Point(430, 73);
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
            txtPANNo.Location = new Point(430, 115);
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
            lblCustomerMoNo.Location = new Point(231, 73);
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
            lblCustomerName.Location = new Point(231, 30);
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
            rdoGST.Location = new Point(229, 112);
            rdoGST.Name = "rdoGST";
            rdoGST.Size = new Size(74, 24);
            rdoGST.TabIndex = 33;
            rdoGST.TabStop = true;
            rdoGST.Text = "GST No";
            rdoGST.UseVisualStyleBackColor = true;
            // 
            // rdoPAN
            // 
            rdoPAN.AutoSize = true;
            rdoPAN.Font = new Font("Arial Narrow", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            rdoPAN.Location = new Point(306, 113);
            rdoPAN.Name = "rdoPAN";
            rdoPAN.Size = new Size(75, 24);
            rdoPAN.TabIndex = 34;
            rdoPAN.TabStop = true;
            rdoPAN.Text = "PAN No";
            rdoPAN.UseVisualStyleBackColor = true;
            // 
            // txtCustomerName
            // 
            txtCustomerName.Location = new Point(430, 30);
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
            panelRight.Controls.Add(txtAltContact);
            panelRight.Controls.Add(txtshippingaddress);
            panelRight.Controls.Add(lblCustomeraltno);
            panelRight.Controls.Add(lblCustShippingaddress);
            panelRight.Controls.Add(lblCustomerEmail);
            panelRight.Controls.Add(txtCustomerEmail);
            panelRight.Controls.Add(chksameas);
            panelRight.Dock = DockStyle.Fill;
            panelRight.Location = new Point(852, 3);
            panelRight.Name = "panelRight";
            panelRight.Size = new Size(843, 294);
            panelRight.TabIndex = 1;
            // 
            // txtAltContact
            // 
            txtAltContact.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtAltContact.Location = new Point(205, 31);
            txtAltContact.Margin = new Padding(3, 2, 3, 2);
            txtAltContact.Multiline = true;
            txtAltContact.Name = "txtAltContact";
            txtAltContact.PlaceholderText = "   Enter Customer ALT Mobile No";
            txtAltContact.RightToLeft = RightToLeft.No;
            txtAltContact.Size = new Size(410, 22);
            txtAltContact.TabIndex = 37;
            // 
            // txtshippingaddress
            // 
            txtshippingaddress.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtshippingaddress.Location = new Point(205, 160);
            txtshippingaddress.Margin = new Padding(3, 2, 3, 2);
            txtshippingaddress.Multiline = true;
            txtshippingaddress.Name = "txtshippingaddress";
            txtshippingaddress.PlaceholderText = "   Enter Shipping Address";
            txtshippingaddress.RightToLeft = RightToLeft.No;
            txtshippingaddress.Size = new Size(410, 74);
            txtshippingaddress.TabIndex = 31;
            // 
            // lblCustomeraltno
            // 
            lblCustomeraltno.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblCustomeraltno.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblCustomeraltno.ForeColor = Color.White;
            lblCustomeraltno.Location = new Point(6, 31);
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
            lblCustShippingaddress.Location = new Point(6, 158);
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
            lblCustomerEmail.Location = new Point(6, 72);
            lblCustomerEmail.Name = "lblCustomerEmail";
            lblCustomerEmail.Size = new Size(141, 23);
            lblCustomerEmail.TabIndex = 22;
            lblCustomerEmail.Text = "Customer Email :";
            lblCustomerEmail.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtCustomerEmail
            // 
            txtCustomerEmail.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtCustomerEmail.Location = new Point(205, 72);
            txtCustomerEmail.Margin = new Padding(3, 2, 3, 2);
            txtCustomerEmail.Multiline = true;
            txtCustomerEmail.Name = "txtCustomerEmail";
            txtCustomerEmail.PlaceholderText = "   Enter Customer Email";
            txtCustomerEmail.RightToLeft = RightToLeft.No;
            txtCustomerEmail.Size = new Size(410, 22);
            txtCustomerEmail.TabIndex = 23;
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
            chksameas.Location = new Point(205, 234);
            chksameas.Margin = new Padding(3, 2, 3, 2);
            chksameas.Name = "chksameas";
            chksameas.Size = new Size(410, 31);
            chksameas.TabIndex = 32;
            chksameas.Text = "   Same As Billing Address";
            chksameas.UseVisualStyleBackColor = false;
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
            panelforbutton.ResumeLayout(false);
            tableLayoutPanelCustomer.ResumeLayout(false);
            panelLeft.ResumeLayout(false);
            panelLeft.PerformLayout();
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
        private TextBox txtCustomerAddress;
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
        private TextBox txtshippingaddress;
        private Label lblCustomeraltno;
        private Label lblCustShippingaddress;
        private Label lblCustomerEmail;
        private TextBox txtCustomerEmail;
        private CheckBox chksameas;
        private Panel panelcustomerdata;
        private Panel panelMenu;
        private DataGridView dgv;
    }
}