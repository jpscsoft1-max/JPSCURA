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
            panelCustomer = new Panel();
            txtAltContact = new TextBox();
            lblCustomeraltno = new Label();
            txtPANNo = new TextBox();
            rdoPAN = new RadioButton();
            rdoGST = new RadioButton();
            chksameas = new CheckBox();
            txtshippingaddress = new TextBox();
            lblCustShippingaddress = new Label();
            btnAddCustomer = new Button();
            txtCustomerAddress = new TextBox();
            lblCustomerAddress = new Label();
            txtGSTNo = new TextBox();
            txtCustomerMoNo = new TextBox();
            lblCustomerMoNo = new Label();
            txtCustomerEmail = new TextBox();
            lblCustomerEmail = new Label();
            txtCustomerName = new TextBox();
            lblCustomerName = new Label();
            panelCustomer.SuspendLayout();
            SuspendLayout();
            // 
            // panelCustomer
            // 
            panelCustomer.BackColor = Color.FromArgb(83, 144, 204);
            panelCustomer.Controls.Add(txtAltContact);
            panelCustomer.Controls.Add(lblCustomeraltno);
            panelCustomer.Controls.Add(txtPANNo);
            panelCustomer.Controls.Add(rdoPAN);
            panelCustomer.Controls.Add(rdoGST);
            panelCustomer.Controls.Add(chksameas);
            panelCustomer.Controls.Add(txtshippingaddress);
            panelCustomer.Controls.Add(lblCustShippingaddress);
            panelCustomer.Controls.Add(btnAddCustomer);
            panelCustomer.Controls.Add(txtCustomerAddress);
            panelCustomer.Controls.Add(lblCustomerAddress);
            panelCustomer.Controls.Add(txtGSTNo);
            panelCustomer.Controls.Add(txtCustomerMoNo);
            panelCustomer.Controls.Add(lblCustomerMoNo);
            panelCustomer.Controls.Add(txtCustomerEmail);
            panelCustomer.Controls.Add(lblCustomerEmail);
            panelCustomer.Controls.Add(txtCustomerName);
            panelCustomer.Controls.Add(lblCustomerName);
            panelCustomer.Dock = DockStyle.Fill;
            panelCustomer.ForeColor = Color.White;
            panelCustomer.Location = new Point(0, 0);
            panelCustomer.Margin = new Padding(3, 2, 3, 2);
            panelCustomer.Name = "panelCustomer";
            panelCustomer.Size = new Size(1698, 677);
            panelCustomer.TabIndex = 1;
            // 
            // txtAltContact
            // 
            txtAltContact.Location = new Point(209, 90);
            txtAltContact.Margin = new Padding(3, 2, 3, 2);
            txtAltContact.Multiline = true;
            txtAltContact.Name = "txtAltContact";
            txtAltContact.PlaceholderText = "   Enter Customer ALT Mobile No";
            txtAltContact.RightToLeft = RightToLeft.No;
            txtAltContact.Size = new Size(410, 22);
            txtAltContact.TabIndex = 19;
            // 
            // lblCustomeraltno
            // 
            lblCustomeraltno.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblCustomeraltno.ForeColor = Color.White;
            lblCustomeraltno.Location = new Point(11, 90);
            lblCustomeraltno.Name = "lblCustomeraltno";
            lblCustomeraltno.Size = new Size(176, 23);
            lblCustomeraltno.TabIndex = 18;
            lblCustomeraltno.Text = "Customer ALT Mobile No :";
            lblCustomeraltno.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtPANNo
            // 
            txtPANNo.Location = new Point(209, 176);
            txtPANNo.Margin = new Padding(3, 2, 3, 2);
            txtPANNo.Multiline = true;
            txtPANNo.Name = "txtPANNo";
            txtPANNo.PlaceholderText = "   Enter Customer PAN No";
            txtPANNo.RightToLeft = RightToLeft.No;
            txtPANNo.Size = new Size(410, 22);
            txtPANNo.TabIndex = 17;
            // 
            // rdoPAN
            // 
            rdoPAN.AutoSize = true;
            rdoPAN.Font = new Font("Arial Narrow", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            rdoPAN.Location = new Point(87, 175);
            rdoPAN.Name = "rdoPAN";
            rdoPAN.Size = new Size(75, 24);
            rdoPAN.TabIndex = 16;
            rdoPAN.TabStop = true;
            rdoPAN.Text = "PAN No";
            rdoPAN.UseVisualStyleBackColor = true;
            // 
            // rdoGST
            // 
            rdoGST.AutoSize = true;
            rdoGST.Font = new Font("Arial Narrow", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            rdoGST.Location = new Point(10, 174);
            rdoGST.Name = "rdoGST";
            rdoGST.Size = new Size(74, 24);
            rdoGST.TabIndex = 15;
            rdoGST.TabStop = true;
            rdoGST.Text = "GST No";
            rdoGST.UseVisualStyleBackColor = true;
            // 
            // chksameas
            // 
            chksameas.BackColor = Color.Transparent;
            chksameas.FlatAppearance.BorderSize = 0;
            chksameas.FlatAppearance.CheckedBackColor = Color.Black;
            chksameas.FlatStyle = FlatStyle.Flat;
            chksameas.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            chksameas.ForeColor = Color.Black;
            chksameas.Location = new Point(209, 389);
            chksameas.Margin = new Padding(3, 2, 3, 2);
            chksameas.Name = "chksameas";
            chksameas.Size = new Size(410, 31);
            chksameas.TabIndex = 14;
            chksameas.Text = "   Same As Billing Address";
            chksameas.UseVisualStyleBackColor = false;
            // 
            // txtshippingaddress
            // 
            txtshippingaddress.Location = new Point(209, 313);
            txtshippingaddress.Margin = new Padding(3, 2, 3, 2);
            txtshippingaddress.Multiline = true;
            txtshippingaddress.Name = "txtshippingaddress";
            txtshippingaddress.PlaceholderText = "   Enter Shipping Address";
            txtshippingaddress.RightToLeft = RightToLeft.No;
            txtshippingaddress.Size = new Size(410, 74);
            txtshippingaddress.TabIndex = 13;
            // 
            // lblCustShippingaddress
            // 
            lblCustShippingaddress.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblCustShippingaddress.ForeColor = Color.White;
            lblCustShippingaddress.Location = new Point(10, 319);
            lblCustShippingaddress.Name = "lblCustShippingaddress";
            lblCustShippingaddress.Size = new Size(170, 23);
            lblCustShippingaddress.TabIndex = 12;
            lblCustShippingaddress.Text = "Shipping Address :";
            lblCustShippingaddress.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // btnAddCustomer
            // 
            btnAddCustomer.BackColor = Color.LightSlateGray;
            btnAddCustomer.Cursor = Cursors.Hand;
            btnAddCustomer.FlatAppearance.BorderSize = 0;
            btnAddCustomer.FlatAppearance.MouseDownBackColor = Color.Gray;
            btnAddCustomer.FlatAppearance.MouseOverBackColor = Color.LightSteelBlue;
            btnAddCustomer.FlatStyle = FlatStyle.Flat;
            btnAddCustomer.Font = new Font("Arial", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAddCustomer.ForeColor = Color.SeaShell;
            btnAddCustomer.Location = new Point(209, 432);
            btnAddCustomer.Margin = new Padding(3, 2, 3, 2);
            btnAddCustomer.Name = "btnAddCustomer";
            btnAddCustomer.Size = new Size(410, 29);
            btnAddCustomer.TabIndex = 11;
            btnAddCustomer.Text = "Add Customer";
            btnAddCustomer.UseVisualStyleBackColor = false;
            btnAddCustomer.Click += btnAddCustomer_Click;
            // 
            // txtCustomerAddress
            // 
            txtCustomerAddress.Location = new Point(209, 218);
            txtCustomerAddress.Margin = new Padding(3, 2, 3, 2);
            txtCustomerAddress.Multiline = true;
            txtCustomerAddress.Name = "txtCustomerAddress";
            txtCustomerAddress.PlaceholderText = "   Enter Billing Address";
            txtCustomerAddress.RightToLeft = RightToLeft.No;
            txtCustomerAddress.Size = new Size(410, 74);
            txtCustomerAddress.TabIndex = 10;
            // 
            // lblCustomerAddress
            // 
            lblCustomerAddress.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblCustomerAddress.ForeColor = Color.White;
            lblCustomerAddress.Location = new Point(10, 216);
            lblCustomerAddress.Name = "lblCustomerAddress";
            lblCustomerAddress.Size = new Size(170, 23);
            lblCustomerAddress.TabIndex = 9;
            lblCustomerAddress.Text = "Billing Address :";
            lblCustomerAddress.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtGSTNo
            // 
            txtGSTNo.Location = new Point(209, 176);
            txtGSTNo.Margin = new Padding(3, 2, 3, 2);
            txtGSTNo.Multiline = true;
            txtGSTNo.Name = "txtGSTNo";
            txtGSTNo.PlaceholderText = "   Enter Customer GST No";
            txtGSTNo.RightToLeft = RightToLeft.No;
            txtGSTNo.Size = new Size(410, 22);
            txtGSTNo.TabIndex = 8;
            // 
            // txtCustomerMoNo
            // 
            txtCustomerMoNo.Location = new Point(209, 50);
            txtCustomerMoNo.Margin = new Padding(3, 2, 3, 2);
            txtCustomerMoNo.Multiline = true;
            txtCustomerMoNo.Name = "txtCustomerMoNo";
            txtCustomerMoNo.PlaceholderText = "   Enter Customer Mobile No";
            txtCustomerMoNo.RightToLeft = RightToLeft.No;
            txtCustomerMoNo.Size = new Size(410, 22);
            txtCustomerMoNo.TabIndex = 6;
            // 
            // lblCustomerMoNo
            // 
            lblCustomerMoNo.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblCustomerMoNo.ForeColor = Color.White;
            lblCustomerMoNo.Location = new Point(10, 50);
            lblCustomerMoNo.Name = "lblCustomerMoNo";
            lblCustomerMoNo.Size = new Size(176, 23);
            lblCustomerMoNo.TabIndex = 5;
            lblCustomerMoNo.Text = "Customer Mobile No :";
            lblCustomerMoNo.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtCustomerEmail
            // 
            txtCustomerEmail.Location = new Point(209, 131);
            txtCustomerEmail.Margin = new Padding(3, 2, 3, 2);
            txtCustomerEmail.Multiline = true;
            txtCustomerEmail.Name = "txtCustomerEmail";
            txtCustomerEmail.PlaceholderText = "   Enter Customer Email";
            txtCustomerEmail.RightToLeft = RightToLeft.No;
            txtCustomerEmail.Size = new Size(410, 22);
            txtCustomerEmail.TabIndex = 4;
            // 
            // lblCustomerEmail
            // 
            lblCustomerEmail.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblCustomerEmail.ForeColor = Color.White;
            lblCustomerEmail.Location = new Point(10, 131);
            lblCustomerEmail.Name = "lblCustomerEmail";
            lblCustomerEmail.Size = new Size(141, 23);
            lblCustomerEmail.TabIndex = 3;
            lblCustomerEmail.Text = "Customer Email :";
            lblCustomerEmail.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtCustomerName
            // 
            txtCustomerName.Location = new Point(209, 7);
            txtCustomerName.Margin = new Padding(3, 2, 3, 2);
            txtCustomerName.Multiline = true;
            txtCustomerName.Name = "txtCustomerName";
            txtCustomerName.PlaceholderText = "   Enter Customer Name";
            txtCustomerName.RightToLeft = RightToLeft.No;
            txtCustomerName.Size = new Size(410, 22);
            txtCustomerName.TabIndex = 2;
            // 
            // lblCustomerName
            // 
            lblCustomerName.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblCustomerName.ForeColor = Color.White;
            lblCustomerName.Location = new Point(10, 7);
            lblCustomerName.Name = "lblCustomerName";
            lblCustomerName.Size = new Size(170, 23);
            lblCustomerName.TabIndex = 1;
            lblCustomerName.Text = "Customer Name :";
            lblCustomerName.TextAlign = ContentAlignment.MiddleLeft;
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
            panelCustomer.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelCustomer;
        private Button btnAddCustomer;
        private TextBox txtCustomerAddress;
        private Label lblCustomerAddress;
        private TextBox txtCustomerGSTORPAN;
        private TextBox txtCustomerMoNo;
        private Label lblCustomerMoNo;
        private TextBox txtCustomerEmail;
        private Label lblCustomerEmail;
        private TextBox txtCustomerName;
        private Label lblCustomerName;
        private TextBox txtshippingaddress;
        private Label lblCustShippingaddress;
        private CheckBox chksameas;
        private RadioButton rdoGST;
        private TextBox txtPANNo;
        private RadioButton rdoPAN;
        private TextBox txtGSTNo;
        private TextBox txtAltContact;
        private Label lblCustomeraltno;
    }
}