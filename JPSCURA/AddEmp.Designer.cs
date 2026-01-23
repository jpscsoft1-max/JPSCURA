namespace JPSCURA
{
    partial class AddEmp
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
            panelContentEMP = new Panel();
            tableLayoutPanelEMP = new TableLayoutPanel();
            panelLeft = new Panel();
            txtaddress = new TextBox();
            lblAddress = new Label();
            txtEMP = new TextBox();
            lblEMPName = new Label();
            panelCenter = new Panel();
            btnAddEmp = new Button();
            txtAadhar = new TextBox();
            lblemail = new Label();
            lblEmpContact = new Label();
            textBox5 = new TextBox();
            txtContact = new TextBox();
            lblAadharCard = new Label();
            panelRight = new Panel();
            txtEMPCode = new TextBox();
            label1 = new Label();
            txtAltContact = new TextBox();
            cmbBloodGrp = new ComboBox();
            lblEMPALTContact = new Label();
            lblBloodgrp = new Label();
            panelContentEMP.SuspendLayout();
            tableLayoutPanelEMP.SuspendLayout();
            panelLeft.SuspendLayout();
            panelCenter.SuspendLayout();
            panelRight.SuspendLayout();
            SuspendLayout();
            // 
            // panelContentEMP
            // 
            panelContentEMP.BackColor = Color.RoyalBlue;
            panelContentEMP.Controls.Add(tableLayoutPanelEMP);
            panelContentEMP.Dock = DockStyle.Fill;
            panelContentEMP.Location = new Point(0, 0);
            panelContentEMP.Margin = new Padding(3, 2, 3, 2);
            panelContentEMP.Name = "panelContentEMP";
            panelContentEMP.Size = new Size(1240, 620);
            panelContentEMP.TabIndex = 0;
            // 
            // tableLayoutPanelEMP
            // 
            tableLayoutPanelEMP.ColumnCount = 3;
            tableLayoutPanelEMP.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33F));
            tableLayoutPanelEMP.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 34F));
            tableLayoutPanelEMP.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33F));
            tableLayoutPanelEMP.Controls.Add(panelLeft, 0, 0);
            tableLayoutPanelEMP.Controls.Add(panelCenter, 1, 0);
            tableLayoutPanelEMP.Controls.Add(panelRight, 2, 0);
            tableLayoutPanelEMP.Dock = DockStyle.Fill;
            tableLayoutPanelEMP.Location = new Point(0, 0);
            tableLayoutPanelEMP.Margin = new Padding(3, 2, 3, 2);
            tableLayoutPanelEMP.Name = "tableLayoutPanelEMP";
            tableLayoutPanelEMP.RowCount = 1;
            tableLayoutPanelEMP.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanelEMP.Size = new Size(1240, 620);
            tableLayoutPanelEMP.TabIndex = 0;
            // 
            // panelLeft
            // 
            panelLeft.Controls.Add(txtaddress);
            panelLeft.Controls.Add(lblAddress);
            panelLeft.Controls.Add(txtEMP);
            panelLeft.Controls.Add(lblEMPName);
            panelLeft.Dock = DockStyle.Fill;
            panelLeft.Location = new Point(3, 2);
            panelLeft.Margin = new Padding(3, 2, 3, 2);
            panelLeft.Name = "panelLeft";
            panelLeft.Size = new Size(403, 616);
            panelLeft.TabIndex = 0;
            // 
            // txtaddress
            // 
            txtaddress.Location = new Point(157, 64);
            txtaddress.Margin = new Padding(3, 2, 3, 2);
            txtaddress.Name = "txtaddress";
            txtaddress.PlaceholderText = "   Enter Address";
            txtaddress.Size = new Size(245, 23);
            txtaddress.TabIndex = 10;
            // 
            // lblAddress
            // 
            lblAddress.AutoSize = true;
            lblAddress.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblAddress.ForeColor = Color.White;
            lblAddress.Location = new Point(7, 64);
            lblAddress.Margin = new Padding(2, 0, 2, 0);
            lblAddress.Name = "lblAddress";
            lblAddress.Size = new Size(75, 18);
            lblAddress.TabIndex = 9;
            lblAddress.Text = "Address :";
            lblAddress.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtEMP
            // 
            txtEMP.Location = new Point(157, 31);
            txtEMP.Margin = new Padding(3, 2, 3, 2);
            txtEMP.Name = "txtEMP";
            txtEMP.PlaceholderText = "   Enter Employee Name";
            txtEMP.Size = new Size(245, 23);
            txtEMP.TabIndex = 4;
            // 
            // lblEMPName
            // 
            lblEMPName.AutoSize = true;
            lblEMPName.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblEMPName.ForeColor = Color.White;
            lblEMPName.Location = new Point(7, 31);
            lblEMPName.Margin = new Padding(2, 0, 2, 0);
            lblEMPName.Name = "lblEMPName";
            lblEMPName.Size = new Size(132, 18);
            lblEMPName.TabIndex = 3;
            lblEMPName.Text = "Employee Name :";
            lblEMPName.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // panelCenter
            // 
            panelCenter.Anchor = AnchorStyles.Top;
            panelCenter.Controls.Add(btnAddEmp);
            panelCenter.Controls.Add(txtAadhar);
            panelCenter.Controls.Add(lblemail);
            panelCenter.Controls.Add(lblEmpContact);
            panelCenter.Controls.Add(textBox5);
            panelCenter.Controls.Add(txtContact);
            panelCenter.Controls.Add(lblAadharCard);
            panelCenter.Location = new Point(412, 2);
            panelCenter.Margin = new Padding(3, 2, 3, 2);
            panelCenter.Name = "panelCenter";
            panelCenter.Size = new Size(415, 616);
            panelCenter.TabIndex = 1;
            // 
            // btnAddEmp
            // 
            btnAddEmp.Anchor = AnchorStyles.Top;
            btnAddEmp.AutoSize = true;
            btnAddEmp.BackColor = Color.LightSkyBlue;
            btnAddEmp.Cursor = Cursors.Hand;
            btnAddEmp.FlatAppearance.BorderColor = Color.FromArgb(192, 255, 255);
            btnAddEmp.FlatAppearance.BorderSize = 2;
            btnAddEmp.Font = new Font("Arial", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAddEmp.ForeColor = SystemColors.ActiveCaptionText;
            btnAddEmp.Location = new Point(167, 164);
            btnAddEmp.Margin = new Padding(3, 2, 3, 2);
            btnAddEmp.Name = "btnAddEmp";
            btnAddEmp.Size = new Size(151, 38);
            btnAddEmp.TabIndex = 9;
            btnAddEmp.Text = "Add Employee";
            btnAddEmp.UseVisualStyleBackColor = false;
            // 
            // txtAadhar
            // 
            txtAadhar.Anchor = AnchorStyles.Top;
            txtAadhar.Location = new Point(167, 31);
            txtAadhar.Margin = new Padding(3, 2, 3, 2);
            txtAadhar.Name = "txtAadhar";
            txtAadhar.PlaceholderText = "   Enter Aadhar No";
            txtAadhar.Size = new Size(245, 23);
            txtAadhar.TabIndex = 12;
            // 
            // lblemail
            // 
            lblemail.Anchor = AnchorStyles.Top;
            lblemail.AutoSize = true;
            lblemail.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblemail.ForeColor = Color.White;
            lblemail.Location = new Point(18, 102);
            lblemail.Margin = new Padding(2, 0, 2, 0);
            lblemail.Name = "lblemail";
            lblemail.Size = new Size(60, 18);
            lblemail.TabIndex = 9;
            lblemail.Text = "Email  :";
            lblemail.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblEmpContact
            // 
            lblEmpContact.Anchor = AnchorStyles.Top;
            lblEmpContact.AutoSize = true;
            lblEmpContact.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblEmpContact.ForeColor = Color.White;
            lblEmpContact.Location = new Point(18, 66);
            lblEmpContact.Margin = new Padding(2, 0, 2, 0);
            lblEmpContact.Name = "lblEmpContact";
            lblEmpContact.Size = new Size(98, 18);
            lblEmpContact.TabIndex = 5;
            lblEmpContact.Text = "Contact No  :";
            lblEmpContact.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // textBox5
            // 
            textBox5.Anchor = AnchorStyles.Top;
            textBox5.Location = new Point(167, 102);
            textBox5.Margin = new Padding(3, 2, 3, 2);
            textBox5.Name = "textBox5";
            textBox5.PlaceholderText = "   Enter Email";
            textBox5.Size = new Size(245, 23);
            textBox5.TabIndex = 10;
            // 
            // txtContact
            // 
            txtContact.Anchor = AnchorStyles.Top;
            txtContact.Location = new Point(167, 66);
            txtContact.Margin = new Padding(3, 2, 3, 2);
            txtContact.Name = "txtContact";
            txtContact.PlaceholderText = "   Enter Contact No";
            txtContact.Size = new Size(245, 23);
            txtContact.TabIndex = 6;
            // 
            // lblAadharCard
            // 
            lblAadharCard.Anchor = AnchorStyles.Top;
            lblAadharCard.AutoSize = true;
            lblAadharCard.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblAadharCard.ForeColor = Color.White;
            lblAadharCard.Location = new Point(17, 31);
            lblAadharCard.Margin = new Padding(2, 0, 2, 0);
            lblAadharCard.Name = "lblAadharCard";
            lblAadharCard.Size = new Size(99, 18);
            lblAadharCard.TabIndex = 11;
            lblAadharCard.Text = "Aadhar  No  :";
            lblAadharCard.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // panelRight
            // 
            panelRight.Controls.Add(txtEMPCode);
            panelRight.Controls.Add(label1);
            panelRight.Controls.Add(txtAltContact);
            panelRight.Controls.Add(cmbBloodGrp);
            panelRight.Controls.Add(lblEMPALTContact);
            panelRight.Controls.Add(lblBloodgrp);
            panelRight.Dock = DockStyle.Fill;
            panelRight.Location = new Point(833, 2);
            panelRight.Margin = new Padding(3, 2, 3, 2);
            panelRight.Name = "panelRight";
            panelRight.Size = new Size(404, 616);
            panelRight.TabIndex = 2;
            // 
            // txtEMPCode
            // 
            txtEMPCode.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtEMPCode.Location = new Point(159, 102);
            txtEMPCode.Margin = new Padding(3, 2, 3, 2);
            txtEMPCode.Name = "txtEMPCode";
            txtEMPCode.PlaceholderText = "   Enter Email";
            txtEMPCode.Size = new Size(245, 23);
            txtEMPCode.TabIndex = 13;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(11, 107);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(133, 18);
            label1.TabIndex = 12;
            label1.Text = "Employee Code  :";
            label1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtAltContact
            // 
            txtAltContact.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtAltContact.Location = new Point(159, 31);
            txtAltContact.Margin = new Padding(3, 2, 3, 2);
            txtAltContact.Name = "txtAltContact";
            txtAltContact.PlaceholderText = "   Enter ALT Contact No";
            txtAltContact.Size = new Size(245, 23);
            txtAltContact.TabIndex = 8;
            // 
            // cmbBloodGrp
            // 
            cmbBloodGrp.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            cmbBloodGrp.FormattingEnabled = true;
            cmbBloodGrp.Location = new Point(159, 67);
            cmbBloodGrp.Margin = new Padding(3, 2, 3, 2);
            cmbBloodGrp.Name = "cmbBloodGrp";
            cmbBloodGrp.Size = new Size(245, 23);
            cmbBloodGrp.TabIndex = 11;
            // 
            // lblEMPALTContact
            // 
            lblEMPALTContact.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblEMPALTContact.AutoSize = true;
            lblEMPALTContact.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblEMPALTContact.ForeColor = Color.White;
            lblEMPALTContact.Location = new Point(11, 36);
            lblEMPALTContact.Margin = new Padding(2, 0, 2, 0);
            lblEMPALTContact.Name = "lblEMPALTContact";
            lblEMPALTContact.Size = new Size(126, 18);
            lblEMPALTContact.TabIndex = 7;
            lblEMPALTContact.Text = "ALT Contact No :";
            lblEMPALTContact.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblBloodgrp
            // 
            lblBloodgrp.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblBloodgrp.AutoSize = true;
            lblBloodgrp.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblBloodgrp.ForeColor = Color.White;
            lblBloodgrp.Location = new Point(11, 72);
            lblBloodgrp.Margin = new Padding(2, 0, 2, 0);
            lblBloodgrp.Name = "lblBloodgrp";
            lblBloodgrp.Size = new Size(104, 18);
            lblBloodgrp.TabIndex = 7;
            lblBloodgrp.Text = "Blood Group :";
            lblBloodgrp.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // AddEmp
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1240, 620);
            Controls.Add(panelContentEMP);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 2, 3, 2);
            Name = "AddEmp";
            Text = "AddEmp";
            panelContentEMP.ResumeLayout(false);
            tableLayoutPanelEMP.ResumeLayout(false);
            panelLeft.ResumeLayout(false);
            panelLeft.PerformLayout();
            panelCenter.ResumeLayout(false);
            panelCenter.PerformLayout();
            panelRight.ResumeLayout(false);
            panelRight.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelContentEMP;
        private TableLayoutPanel tableLayoutPanelEMP;
        private Panel panelLeft;
        private Panel panelCenter;
        private Panel panelRight;
        private Label lblEMPName;
        private TextBox txtaddress;
        private Label lblAddress;
        private TextBox txtAltContact;
        private Label lblEMPALTContact;
        private TextBox txtContact;
        private Label lblEmpContact;
        private TextBox txtEMP;
        private TextBox txtAadhar;
        private Label lblAadharCard;
        private TextBox textBox6;
        private Label lblBloodgrp;
        private Label lblemail;
        private TextBox textBox5;
        private ComboBox cmbBloodGrp;
        private Button btnAddEmp;
        private TextBox txtEMPCode;
        private Label label1;
    }
}