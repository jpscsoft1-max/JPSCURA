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
            chksameas = new CheckBox();
            textBox1 = new TextBox();
            lblCustShippingaddress = new Label();
            btnAddCustomer = new Button();
            txtVendorAddress = new TextBox();
            lblCustomerAddress = new Label();
            txtCustomerGSTORPAN = new TextBox();
            lblCustomerGSTORPAN = new Label();
            txtVendorMoNo = new TextBox();
            lblCustomerMoNo = new Label();
            textCustomerEmail = new TextBox();
            lblCustomerEmail = new Label();
            txtVendorName = new TextBox();
            lblCustomerName = new Label();
            panelCustomer.SuspendLayout();
            SuspendLayout();
            // 
            // panelCustomer
            // 
            panelCustomer.BackColor = Color.RoyalBlue;
            panelCustomer.Controls.Add(chksameas);
            panelCustomer.Controls.Add(textBox1);
            panelCustomer.Controls.Add(lblCustShippingaddress);
            panelCustomer.Controls.Add(btnAddCustomer);
            panelCustomer.Controls.Add(txtVendorAddress);
            panelCustomer.Controls.Add(lblCustomerAddress);
            panelCustomer.Controls.Add(txtCustomerGSTORPAN);
            panelCustomer.Controls.Add(lblCustomerGSTORPAN);
            panelCustomer.Controls.Add(txtVendorMoNo);
            panelCustomer.Controls.Add(lblCustomerMoNo);
            panelCustomer.Controls.Add(textCustomerEmail);
            panelCustomer.Controls.Add(lblCustomerEmail);
            panelCustomer.Controls.Add(txtVendorName);
            panelCustomer.Controls.Add(lblCustomerName);
            panelCustomer.Dock = DockStyle.Fill;
            panelCustomer.ForeColor = Color.White;
            panelCustomer.Location = new Point(0, 0);
            panelCustomer.Name = "panelCustomer";
            panelCustomer.Size = new Size(1942, 903);
            panelCustomer.TabIndex = 1;
            // 
            // chksameas
            // 
            chksameas.BackColor = Color.RoyalBlue;
            chksameas.FlatAppearance.BorderSize = 0;
            chksameas.FlatAppearance.CheckedBackColor = Color.Black;
            chksameas.FlatStyle = FlatStyle.Flat;
            chksameas.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            chksameas.ForeColor = Color.Black;
            chksameas.Location = new Point(239, 541);
            chksameas.Name = "chksameas";
            chksameas.Size = new Size(468, 30);
            chksameas.TabIndex = 14;
            chksameas.Text = "   Same As Billing Address";
            chksameas.UseVisualStyleBackColor = false;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(239, 438);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.PlaceholderText = "   Enter Shipping Address";
            textBox1.RightToLeft = RightToLeft.No;
            textBox1.Size = new Size(468, 97);
            textBox1.TabIndex = 13;
            // 
            // lblCustShippingaddress
            // 
            lblCustShippingaddress.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblCustShippingaddress.ForeColor = Color.White;
            lblCustShippingaddress.Location = new Point(12, 438);
            lblCustShippingaddress.Name = "lblCustShippingaddress";
            lblCustShippingaddress.Size = new Size(194, 31);
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
            btnAddCustomer.Location = new Point(239, 599);
            btnAddCustomer.Name = "btnAddCustomer";
            btnAddCustomer.Size = new Size(468, 39);
            btnAddCustomer.TabIndex = 11;
            btnAddCustomer.Text = "Add Customer";
            btnAddCustomer.UseVisualStyleBackColor = false;
            // 
            // txtVendorAddress
            // 
            txtVendorAddress.Location = new Point(239, 251);
            txtVendorAddress.Multiline = true;
            txtVendorAddress.Name = "txtVendorAddress";
            txtVendorAddress.PlaceholderText = "   Enter Billing Address";
            txtVendorAddress.RightToLeft = RightToLeft.No;
            txtVendorAddress.Size = new Size(468, 157);
            txtVendorAddress.TabIndex = 10;
            // 
            // lblCustomerAddress
            // 
            lblCustomerAddress.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblCustomerAddress.ForeColor = Color.White;
            lblCustomerAddress.Location = new Point(12, 248);
            lblCustomerAddress.Name = "lblCustomerAddress";
            lblCustomerAddress.Size = new Size(194, 31);
            lblCustomerAddress.TabIndex = 9;
            lblCustomerAddress.Text = "Billing Address :";
            lblCustomerAddress.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtCustomerGSTORPAN
            // 
            txtCustomerGSTORPAN.Location = new Point(239, 194);
            txtCustomerGSTORPAN.Multiline = true;
            txtCustomerGSTORPAN.Name = "txtCustomerGSTORPAN";
            txtCustomerGSTORPAN.PlaceholderText = "   Enter Customer GST/PAN No";
            txtCustomerGSTORPAN.RightToLeft = RightToLeft.No;
            txtCustomerGSTORPAN.Size = new Size(468, 28);
            txtCustomerGSTORPAN.TabIndex = 8;
            // 
            // lblCustomerGSTORPAN
            // 
            lblCustomerGSTORPAN.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblCustomerGSTORPAN.ForeColor = Color.White;
            lblCustomerGSTORPAN.Location = new Point(12, 172);
            lblCustomerGSTORPAN.Name = "lblCustomerGSTORPAN";
            lblCustomerGSTORPAN.Size = new Size(171, 50);
            lblCustomerGSTORPAN.TabIndex = 7;
            lblCustomerGSTORPAN.Text = "Customer GST/PAN No :";
            lblCustomerGSTORPAN.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtVendorMoNo
            // 
            txtVendorMoNo.Location = new Point(239, 66);
            txtVendorMoNo.Multiline = true;
            txtVendorMoNo.Name = "txtVendorMoNo";
            txtVendorMoNo.PlaceholderText = "   Enter Customer Mobile No";
            txtVendorMoNo.RightToLeft = RightToLeft.No;
            txtVendorMoNo.Size = new Size(468, 28);
            txtVendorMoNo.TabIndex = 6;
            // 
            // lblCustomerMoNo
            // 
            lblCustomerMoNo.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblCustomerMoNo.ForeColor = Color.White;
            lblCustomerMoNo.Location = new Point(12, 66);
            lblCustomerMoNo.Name = "lblCustomerMoNo";
            lblCustomerMoNo.Size = new Size(201, 31);
            lblCustomerMoNo.TabIndex = 5;
            lblCustomerMoNo.Text = "Customer Mobile No :";
            lblCustomerMoNo.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // textCustomerEmail
            // 
            textCustomerEmail.Location = new Point(239, 121);
            textCustomerEmail.Multiline = true;
            textCustomerEmail.Name = "textCustomerEmail";
            textCustomerEmail.PlaceholderText = "   Enter Customer Email";
            textCustomerEmail.RightToLeft = RightToLeft.No;
            textCustomerEmail.Size = new Size(468, 28);
            textCustomerEmail.TabIndex = 4;
            // 
            // lblCustomerEmail
            // 
            lblCustomerEmail.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblCustomerEmail.ForeColor = Color.White;
            lblCustomerEmail.Location = new Point(12, 121);
            lblCustomerEmail.Name = "lblCustomerEmail";
            lblCustomerEmail.Size = new Size(161, 31);
            lblCustomerEmail.TabIndex = 3;
            lblCustomerEmail.Text = "Customer Email :";
            lblCustomerEmail.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtVendorName
            // 
            txtVendorName.Location = new Point(239, 9);
            txtVendorName.Multiline = true;
            txtVendorName.Name = "txtVendorName";
            txtVendorName.PlaceholderText = "   Enter Customer Name";
            txtVendorName.RightToLeft = RightToLeft.No;
            txtVendorName.Size = new Size(468, 28);
            txtVendorName.TabIndex = 2;
            // 
            // lblCustomerName
            // 
            lblCustomerName.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblCustomerName.ForeColor = Color.White;
            lblCustomerName.Location = new Point(12, 9);
            lblCustomerName.Name = "lblCustomerName";
            lblCustomerName.Size = new Size(194, 31);
            lblCustomerName.TabIndex = 1;
            lblCustomerName.Text = "Customer Name :";
            lblCustomerName.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // Customer
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1942, 903);
            Controls.Add(panelCustomer);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Customer";
            Text = "Customer";
            panelCustomer.ResumeLayout(false);
            panelCustomer.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelCustomer;
        private Button btnAddCustomer;
        private TextBox txtVendorAddress;
        private Label lblCustomerAddress;
        private TextBox txtCustomerGSTORPAN;
        private Label lblCustomerGSTORPAN;
        private TextBox txtVendorMoNo;
        private Label lblCustomerMoNo;
        private TextBox textCustomerEmail;
        private Label lblCustomerEmail;
        private TextBox txtVendorName;
        private Label lblCustomerName;
        private TextBox textBox1;
        private Label lblCustShippingaddress;
        private CheckBox chksameas;
    }
}