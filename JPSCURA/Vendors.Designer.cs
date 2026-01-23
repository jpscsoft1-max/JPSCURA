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
            panelVendor = new Panel();
            btnAddVendor = new Button();
            txtVendorAddress = new TextBox();
            lblVendorAddress = new Label();
            txtVendorGSTORPAN = new TextBox();
            lblVendorGSTORPAN = new Label();
            txtVendorMoNo = new TextBox();
            lblVendorMoNo = new Label();
            textVendorEmail = new TextBox();
            lblVendorEmail = new Label();
            txtVendorName = new TextBox();
            lblVendorName = new Label();
            panelVendor.SuspendLayout();
            SuspendLayout();
            // 
            // panelVendor
            // 
            panelVendor.BackColor = Color.RoyalBlue;
            panelVendor.Controls.Add(btnAddVendor);
            panelVendor.Controls.Add(txtVendorAddress);
            panelVendor.Controls.Add(lblVendorAddress);
            panelVendor.Controls.Add(txtVendorGSTORPAN);
            panelVendor.Controls.Add(lblVendorGSTORPAN);
            panelVendor.Controls.Add(txtVendorMoNo);
            panelVendor.Controls.Add(lblVendorMoNo);
            panelVendor.Controls.Add(textVendorEmail);
            panelVendor.Controls.Add(lblVendorEmail);
            panelVendor.Controls.Add(txtVendorName);
            panelVendor.Controls.Add(lblVendorName);
            panelVendor.Dock = DockStyle.Fill;
            panelVendor.Location = new Point(0, 0);
            panelVendor.Margin = new Padding(3, 2, 3, 2);
            panelVendor.Name = "panelVendor";
            panelVendor.Size = new Size(1213, 338);
            panelVendor.TabIndex = 0;
            // 
            // btnAddVendor
            // 
            btnAddVendor.BackColor = Color.LightSlateGray;
            btnAddVendor.Cursor = Cursors.Hand;
            btnAddVendor.FlatAppearance.BorderSize = 0;
            btnAddVendor.FlatAppearance.MouseDownBackColor = Color.Gray;
            btnAddVendor.FlatAppearance.MouseOverBackColor = Color.LightSteelBlue;
            btnAddVendor.FlatStyle = FlatStyle.Flat;
            btnAddVendor.Font = new Font("Arial", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAddVendor.ForeColor = Color.SeaShell;
            btnAddVendor.Location = new Point(10, 222);
            btnAddVendor.Margin = new Padding(3, 2, 3, 2);
            btnAddVendor.Name = "btnAddVendor";
            btnAddVendor.Size = new Size(540, 29);
            btnAddVendor.TabIndex = 11;
            btnAddVendor.Text = "Add Vendor";
            btnAddVendor.UseVisualStyleBackColor = false;
            // 
            // txtVendorAddress
            // 
            txtVendorAddress.Location = new Point(175, 91);
            txtVendorAddress.Margin = new Padding(3, 2, 3, 2);
            txtVendorAddress.Multiline = true;
            txtVendorAddress.Name = "txtVendorAddress";
            txtVendorAddress.PlaceholderText = "Enter Vendor Address";
            txtVendorAddress.RightToLeft = RightToLeft.No;
            txtVendorAddress.Size = new Size(376, 119);
            txtVendorAddress.TabIndex = 10;
            // 
            // lblVendorAddress
            // 
            lblVendorAddress.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblVendorAddress.ForeColor = Color.White;
            lblVendorAddress.Location = new Point(3, 88);
            lblVendorAddress.Name = "lblVendorAddress";
            lblVendorAddress.Size = new Size(158, 23);
            lblVendorAddress.TabIndex = 9;
            lblVendorAddress.Text = "Vendor Address :";
            lblVendorAddress.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // txtVendorGSTORPAN
            // 
            txtVendorGSTORPAN.Location = new Point(745, 55);
            txtVendorGSTORPAN.Margin = new Padding(3, 2, 3, 2);
            txtVendorGSTORPAN.Multiline = true;
            txtVendorGSTORPAN.Name = "txtVendorGSTORPAN";
            txtVendorGSTORPAN.PlaceholderText = "Enter Vendor GST/PAN No";
            txtVendorGSTORPAN.RightToLeft = RightToLeft.No;
            txtVendorGSTORPAN.Size = new Size(351, 22);
            txtVendorGSTORPAN.TabIndex = 8;
            // 
            // lblVendorGSTORPAN
            // 
            lblVendorGSTORPAN.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblVendorGSTORPAN.ForeColor = Color.White;
            lblVendorGSTORPAN.Location = new Point(556, 52);
            lblVendorGSTORPAN.Name = "lblVendorGSTORPAN";
            lblVendorGSTORPAN.Size = new Size(184, 23);
            lblVendorGSTORPAN.TabIndex = 7;
            lblVendorGSTORPAN.Text = "Vendor GST/PAN No :";
            lblVendorGSTORPAN.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // txtVendorMoNo
            // 
            txtVendorMoNo.Location = new Point(175, 52);
            txtVendorMoNo.Margin = new Padding(3, 2, 3, 2);
            txtVendorMoNo.Multiline = true;
            txtVendorMoNo.Name = "txtVendorMoNo";
            txtVendorMoNo.PlaceholderText = "Enter Vendor Mobile No";
            txtVendorMoNo.RightToLeft = RightToLeft.No;
            txtVendorMoNo.Size = new Size(376, 22);
            txtVendorMoNo.TabIndex = 6;
            // 
            // lblVendorMoNo
            // 
            lblVendorMoNo.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblVendorMoNo.ForeColor = Color.White;
            lblVendorMoNo.Location = new Point(10, 50);
            lblVendorMoNo.Name = "lblVendorMoNo";
            lblVendorMoNo.Size = new Size(159, 23);
            lblVendorMoNo.TabIndex = 5;
            lblVendorMoNo.Text = "Vendor Mobile No :";
            lblVendorMoNo.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // textVendorEmail
            // 
            textVendorEmail.Location = new Point(745, 12);
            textVendorEmail.Margin = new Padding(3, 2, 3, 2);
            textVendorEmail.Multiline = true;
            textVendorEmail.Name = "textVendorEmail";
            textVendorEmail.PlaceholderText = "Enter Vendor Email";
            textVendorEmail.RightToLeft = RightToLeft.No;
            textVendorEmail.Size = new Size(351, 22);
            textVendorEmail.TabIndex = 4;
            // 
            // lblVendorEmail
            // 
            lblVendorEmail.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblVendorEmail.ForeColor = Color.White;
            lblVendorEmail.Location = new Point(556, 9);
            lblVendorEmail.Name = "lblVendorEmail";
            lblVendorEmail.Size = new Size(125, 23);
            lblVendorEmail.TabIndex = 3;
            lblVendorEmail.Text = "Vendor Email :";
            lblVendorEmail.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // txtVendorName
            // 
            txtVendorName.Location = new Point(175, 9);
            txtVendorName.Margin = new Padding(3, 2, 3, 2);
            txtVendorName.Multiline = true;
            txtVendorName.Name = "txtVendorName";
            txtVendorName.PlaceholderText = "Enter Vendor Name";
            txtVendorName.RightToLeft = RightToLeft.No;
            txtVendorName.Size = new Size(376, 22);
            txtVendorName.TabIndex = 2;
            // 
            // lblVendorName
            // 
            lblVendorName.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblVendorName.ForeColor = Color.White;
            lblVendorName.Location = new Point(10, 7);
            lblVendorName.Name = "lblVendorName";
            lblVendorName.Size = new Size(125, 23);
            lblVendorName.TabIndex = 1;
            lblVendorName.Text = "Vendor Name :";
            lblVendorName.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // Vendors
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1213, 338);
            Controls.Add(panelVendor);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 2, 3, 2);
            Name = "Vendors";
            Text = "Vendors";
            panelVendor.ResumeLayout(false);
            panelVendor.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelVendor;
        private Label lblVendorName;
        private TextBox txtVendorName;
        private TextBox txtVendorGSTORPAN;
        private Label lblVendorGSTORPAN;
        private TextBox txtVendorMoNo;
        private Label lblVendorMoNo;
        private TextBox textVendorEmail;
        private Label lblVendorEmail;
        private TextBox txtVendorAddress;
        private Label lblVendorAddress;
        private Button btnAddVendor;
    }
}