namespace JPSCURA
{
    partial class EditEmployee
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
            pnlEditemployee = new Panel();
            cmbRole = new ComboBox();
            cmbDepartment = new ComboBox();
            btnDelete = new Button();
            btncancel = new Button();
            btnUpdate = new Button();
            txtContact = new TextBox();
            txtAltContact = new TextBox();
            txtEmail = new TextBox();
            txtIFSC = new TextBox();
            txtBloodGroup = new TextBox();
            txtAccountNo = new TextBox();
            txtAadhar = new TextBox();
            txtAddress = new TextBox();
            txtEmpName = new TextBox();
            txtEmpCode = new TextBox();
            lblIfsccode = new Label();
            lblEmpRole = new Label();
            lblEmpAccountno = new Label();
            lblEmpDep = new Label();
            lblEmpBloodGroup = new Label();
            lblAdharcard = new Label();
            lblAddress = new Label();
            lblEmpEmail = new Label();
            lblEmployeealtcno = new Label();
            lblEmployeeName = new Label();
            lblEmpcontact = new Label();
            lblEmployeeCode = new Label();
            pnlEditemployee.SuspendLayout();
            SuspendLayout();
            // 
            // pnlEditemployee
            // 
            pnlEditemployee.BackColor = Color.FromArgb(83, 144, 203);
            pnlEditemployee.Controls.Add(cmbRole);
            pnlEditemployee.Controls.Add(cmbDepartment);
            pnlEditemployee.Controls.Add(btnDelete);
            pnlEditemployee.Controls.Add(btncancel);
            pnlEditemployee.Controls.Add(btnUpdate);
            pnlEditemployee.Controls.Add(txtContact);
            pnlEditemployee.Controls.Add(txtAltContact);
            pnlEditemployee.Controls.Add(txtEmail);
            pnlEditemployee.Controls.Add(txtIFSC);
            pnlEditemployee.Controls.Add(txtBloodGroup);
            pnlEditemployee.Controls.Add(txtAccountNo);
            pnlEditemployee.Controls.Add(txtAadhar);
            pnlEditemployee.Controls.Add(txtAddress);
            pnlEditemployee.Controls.Add(txtEmpName);
            pnlEditemployee.Controls.Add(txtEmpCode);
            pnlEditemployee.Controls.Add(lblIfsccode);
            pnlEditemployee.Controls.Add(lblEmpRole);
            pnlEditemployee.Controls.Add(lblEmpAccountno);
            pnlEditemployee.Controls.Add(lblEmpDep);
            pnlEditemployee.Controls.Add(lblEmpBloodGroup);
            pnlEditemployee.Controls.Add(lblAdharcard);
            pnlEditemployee.Controls.Add(lblAddress);
            pnlEditemployee.Controls.Add(lblEmpEmail);
            pnlEditemployee.Controls.Add(lblEmployeealtcno);
            pnlEditemployee.Controls.Add(lblEmployeeName);
            pnlEditemployee.Controls.Add(lblEmpcontact);
            pnlEditemployee.Controls.Add(lblEmployeeCode);
            pnlEditemployee.Dock = DockStyle.Fill;
            pnlEditemployee.Location = new Point(0, 0);
            pnlEditemployee.Name = "pnlEditemployee";
            pnlEditemployee.Size = new Size(393, 430);
            pnlEditemployee.TabIndex = 0;
            // 
            // cmbRole
            // 
            cmbRole.Cursor = Cursors.Hand;
            cmbRole.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbRole.FormattingEnabled = true;
            cmbRole.Location = new Point(113, 347);
            cmbRole.Name = "cmbRole";
            cmbRole.Size = new Size(258, 23);
            cmbRole.TabIndex = 28;
            // 
            // cmbDepartment
            // 
            cmbDepartment.Cursor = Cursors.Hand;
            cmbDepartment.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbDepartment.FormattingEnabled = true;
            cmbDepartment.Location = new Point(113, 318);
            cmbDepartment.Name = "cmbDepartment";
            cmbDepartment.Size = new Size(258, 23);
            cmbDepartment.TabIndex = 27;
            cmbDepartment.SelectedIndexChanged += cmbDepartment_SelectedIndexChanged;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.FromArgb(255, 128, 128);
            btnDelete.FlatAppearance.BorderSize = 0;
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.Location = new Point(12, 396);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(127, 23);
            btnDelete.TabIndex = 26;
            btnDelete.Text = "Delete Employee";
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += btnDelete_Click;
            // 
            // btncancel
            // 
            btncancel.BackColor = Color.FromArgb(255, 255, 128);
            btncancel.FlatAppearance.BorderSize = 0;
            btncancel.FlatAppearance.MouseDownBackColor = Color.Red;
            btncancel.FlatAppearance.MouseOverBackColor = Color.Red;
            btncancel.FlatStyle = FlatStyle.Flat;
            btncancel.Font = new Font("Segoe UI", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btncancel.Location = new Point(198, 396);
            btncancel.Name = "btncancel";
            btncancel.Size = new Size(75, 23);
            btncancel.TabIndex = 25;
            btncancel.Text = "Cancle";
            btncancel.UseVisualStyleBackColor = false;
            btncancel.Click += btnCancel_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.BackColor = Color.FromArgb(192, 192, 255);
            btnUpdate.FlatAppearance.BorderSize = 0;
            btnUpdate.FlatAppearance.MouseOverBackColor = Color.SpringGreen;
            btnUpdate.FlatStyle = FlatStyle.Flat;
            btnUpdate.Font = new Font("Segoe UI", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnUpdate.ForeColor = Color.Black;
            btnUpdate.Location = new Point(279, 396);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(92, 23);
            btnUpdate.TabIndex = 24;
            btnUpdate.Text = "Update Details";
            btnUpdate.UseVisualStyleBackColor = false;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // txtContact
            // 
            txtContact.Location = new Point(113, 83);
            txtContact.Name = "txtContact";
            txtContact.Size = new Size(258, 23);
            txtContact.TabIndex = 23;
            // 
            // txtAltContact
            // 
            txtAltContact.Location = new Point(113, 112);
            txtAltContact.Name = "txtAltContact";
            txtAltContact.Size = new Size(258, 23);
            txtAltContact.TabIndex = 22;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(113, 141);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(258, 23);
            txtEmail.TabIndex = 21;
            // 
            // txtIFSC
            // 
            txtIFSC.Location = new Point(113, 286);
            txtIFSC.Name = "txtIFSC";
            txtIFSC.Size = new Size(258, 23);
            txtIFSC.TabIndex = 20;
            // 
            // txtBloodGroup
            // 
            txtBloodGroup.Location = new Point(113, 228);
            txtBloodGroup.Name = "txtBloodGroup";
            txtBloodGroup.Size = new Size(258, 23);
            txtBloodGroup.TabIndex = 17;
            // 
            // txtAccountNo
            // 
            txtAccountNo.Location = new Point(113, 257);
            txtAccountNo.Name = "txtAccountNo";
            txtAccountNo.Size = new Size(258, 23);
            txtAccountNo.TabIndex = 16;
            // 
            // txtAadhar
            // 
            txtAadhar.Location = new Point(113, 199);
            txtAadhar.Name = "txtAadhar";
            txtAadhar.Size = new Size(258, 23);
            txtAadhar.TabIndex = 15;
            // 
            // txtAddress
            // 
            txtAddress.Location = new Point(113, 170);
            txtAddress.Name = "txtAddress";
            txtAddress.Size = new Size(258, 23);
            txtAddress.TabIndex = 14;
            // 
            // txtEmpName
            // 
            txtEmpName.Location = new Point(113, 54);
            txtEmpName.Name = "txtEmpName";
            txtEmpName.Size = new Size(258, 23);
            txtEmpName.TabIndex = 13;
            // 
            // txtEmpCode
            // 
            txtEmpCode.Location = new Point(113, 25);
            txtEmpCode.Name = "txtEmpCode";
            txtEmpCode.Size = new Size(258, 23);
            txtEmpCode.TabIndex = 12;
            // 
            // lblIfsccode
            // 
            lblIfsccode.AutoSize = true;
            lblIfsccode.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblIfsccode.ForeColor = Color.White;
            lblIfsccode.Location = new Point(18, 289);
            lblIfsccode.Name = "lblIfsccode";
            lblIfsccode.Size = new Size(63, 15);
            lblIfsccode.TabIndex = 11;
            lblIfsccode.Text = "IFSC-code";
            // 
            // lblEmpRole
            // 
            lblEmpRole.AutoSize = true;
            lblEmpRole.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblEmpRole.ForeColor = Color.White;
            lblEmpRole.Location = new Point(18, 347);
            lblEmpRole.Name = "lblEmpRole";
            lblEmpRole.Size = new Size(32, 15);
            lblEmpRole.TabIndex = 10;
            lblEmpRole.Text = "Role";
            // 
            // lblEmpAccountno
            // 
            lblEmpAccountno.AutoSize = true;
            lblEmpAccountno.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblEmpAccountno.ForeColor = Color.White;
            lblEmpAccountno.Location = new Point(18, 261);
            lblEmpAccountno.Name = "lblEmpAccountno";
            lblEmpAccountno.Size = new Size(72, 15);
            lblEmpAccountno.TabIndex = 9;
            lblEmpAccountno.Text = "Account No";
            // 
            // lblEmpDep
            // 
            lblEmpDep.AutoSize = true;
            lblEmpDep.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblEmpDep.ForeColor = Color.White;
            lblEmpDep.Location = new Point(18, 318);
            lblEmpDep.Name = "lblEmpDep";
            lblEmpDep.Size = new Size(76, 15);
            lblEmpDep.TabIndex = 8;
            lblEmpDep.Text = "Department";
            // 
            // lblEmpBloodGroup
            // 
            lblEmpBloodGroup.AutoSize = true;
            lblEmpBloodGroup.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblEmpBloodGroup.ForeColor = Color.White;
            lblEmpBloodGroup.ImageAlign = ContentAlignment.TopRight;
            lblEmpBloodGroup.Location = new Point(18, 231);
            lblEmpBloodGroup.Name = "lblEmpBloodGroup";
            lblEmpBloodGroup.Size = new Size(74, 15);
            lblEmpBloodGroup.TabIndex = 7;
            lblEmpBloodGroup.Text = "BloodGroup";
            // 
            // lblAdharcard
            // 
            lblAdharcard.AutoSize = true;
            lblAdharcard.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblAdharcard.ForeColor = Color.White;
            lblAdharcard.Location = new Point(18, 202);
            lblAdharcard.Name = "lblAdharcard";
            lblAdharcard.Size = new Size(83, 15);
            lblAdharcard.TabIndex = 6;
            lblAdharcard.Text = "Adharcard No";
            // 
            // lblAddress
            // 
            lblAddress.AutoSize = true;
            lblAddress.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblAddress.ForeColor = Color.White;
            lblAddress.Location = new Point(18, 173);
            lblAddress.Name = "lblAddress";
            lblAddress.Size = new Size(51, 15);
            lblAddress.TabIndex = 5;
            lblAddress.Text = "Address";
            // 
            // lblEmpEmail
            // 
            lblEmpEmail.AutoSize = true;
            lblEmpEmail.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblEmpEmail.ForeColor = Color.White;
            lblEmpEmail.Location = new Point(18, 144);
            lblEmpEmail.Name = "lblEmpEmail";
            lblEmpEmail.Size = new Size(50, 15);
            lblEmpEmail.TabIndex = 4;
            lblEmpEmail.Text = "Email Id";
            // 
            // lblEmployeealtcno
            // 
            lblEmployeealtcno.AutoSize = true;
            lblEmployeealtcno.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblEmployeealtcno.ForeColor = Color.White;
            lblEmployeealtcno.Location = new Point(18, 115);
            lblEmployeealtcno.Name = "lblEmployeealtcno";
            lblEmployeealtcno.Size = new Size(79, 15);
            lblEmployeealtcno.TabIndex = 3;
            lblEmployeealtcno.Text = "Alternate No";
            // 
            // lblEmployeeName
            // 
            lblEmployeeName.AutoSize = true;
            lblEmployeeName.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblEmployeeName.ForeColor = Color.White;
            lblEmployeeName.Location = new Point(18, 57);
            lblEmployeeName.Name = "lblEmployeeName";
            lblEmployeeName.Size = new Size(94, 15);
            lblEmployeeName.TabIndex = 2;
            lblEmployeeName.Text = "EmployeeName";
            // 
            // lblEmpcontact
            // 
            lblEmpcontact.AutoSize = true;
            lblEmpcontact.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblEmpcontact.ForeColor = Color.White;
            lblEmpcontact.Location = new Point(18, 86);
            lblEmpcontact.Name = "lblEmpcontact";
            lblEmpcontact.Size = new Size(69, 15);
            lblEmpcontact.TabIndex = 1;
            lblEmpcontact.Text = "Contact No";
            // 
            // lblEmployeeCode
            // 
            lblEmployeeCode.AutoSize = true;
            lblEmployeeCode.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblEmployeeCode.ForeColor = Color.White;
            lblEmployeeCode.Location = new Point(18, 29);
            lblEmployeeCode.Name = "lblEmployeeCode";
            lblEmployeeCode.Size = new Size(89, 15);
            lblEmployeeCode.TabIndex = 0;
            lblEmployeeCode.Text = "EmployeeCode";
            // 
            // EditEmployee
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(393, 430);
            Controls.Add(pnlEditemployee);
            FormBorderStyle = FormBorderStyle.SizableToolWindow;
            MaximizeBox = false;
            MaximumSize = new Size(409, 469);
            MinimizeBox = false;
            MinimumSize = new Size(409, 469);
            Name = "EditEmployee";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Edit Employee";
            Load += EditEmployee_Load;
            pnlEditemployee.ResumeLayout(false);
            pnlEditemployee.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlEditemployee;
        private Label lblEmployeeCode;
        private Label lblEmpBloodGroup;
        private Label lblAdharcard;
        private Label lblAddress;
        private Label lblEmpEmail;
        private Label lblEmployeealtcno;
        private Label lblEmployeeName;
        private Label lblEmpcontact;
        private Label lblIfsccode;
        private Label lblEmpRole;
        private Label lblEmpAccountno;
        private Label lblEmpDep;
        private TextBox txtContact;
        private TextBox txtAltContact;
        private TextBox txtEmail;
        private TextBox txtIFSC;
        private TextBox txtBloodGroup;
        private TextBox txtAccountNo;
        private TextBox txtAadhar;
        private TextBox txtAddress;
        private TextBox txtEmpName;
        private TextBox txtEmpCode;
        private Button btnUpdate;
        private Button btncancel;
        private Button btnDelete;
        private ComboBox cmbRole;
        private ComboBox cmbDepartment;
    }
}