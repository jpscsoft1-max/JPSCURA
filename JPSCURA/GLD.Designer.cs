namespace JPSCURA
{
    partial class GLD
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
            panelMainGLD = new Panel();
            panelCenterGLD = new Panel();
            txtPassword = new TextBox();
            picTogglePassword = new PictureBox();
            btnClear = new Button();
            panelHeaderGLD = new Panel();
            lblGLD = new Label();
            btnSaveGLD = new Button();
            cmbDepartment = new ComboBox();
            cmbEmployee = new ComboBox();
            txtUsername = new TextBox();
            lblEmployee = new Label();
            lblDepartment = new Label();
            lblPassword = new Label();
            lblUsername = new Label();
            panelMainGLD.SuspendLayout();
            panelCenterGLD.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picTogglePassword).BeginInit();
            panelHeaderGLD.SuspendLayout();
            SuspendLayout();
            // 
            // panelMainGLD
            // 
            panelMainGLD.BackColor = Color.FromArgb(83, 144, 204);
            panelMainGLD.Controls.Add(panelCenterGLD);
            panelMainGLD.Dock = DockStyle.Fill;
            panelMainGLD.Location = new Point(0, 0);
            panelMainGLD.Name = "panelMainGLD";
            panelMainGLD.Size = new Size(1273, 704);
            panelMainGLD.TabIndex = 0;
            // 
            // panelCenterGLD
            // 
            panelCenterGLD.Anchor = AnchorStyles.None;
            panelCenterGLD.BackColor = Color.Transparent;
            panelCenterGLD.Controls.Add(picTogglePassword);
            panelCenterGLD.Controls.Add(btnClear);
            panelCenterGLD.Controls.Add(panelHeaderGLD);
            panelCenterGLD.Controls.Add(btnSaveGLD);
            panelCenterGLD.Controls.Add(cmbDepartment);
            panelCenterGLD.Controls.Add(cmbEmployee);
            panelCenterGLD.Controls.Add(txtUsername);
            panelCenterGLD.Controls.Add(lblEmployee);
            panelCenterGLD.Controls.Add(lblDepartment);
            panelCenterGLD.Controls.Add(lblPassword);
            panelCenterGLD.Controls.Add(lblUsername);
            panelCenterGLD.Controls.Add(txtPassword);
            panelCenterGLD.Location = new Point(307, 173);
            panelCenterGLD.Name = "panelCenterGLD";
            panelCenterGLD.Size = new Size(650, 380);
            panelCenterGLD.TabIndex = 0;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(210, 141);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(321, 23);
            txtPassword.TabIndex = 5;
            txtPassword.Leave += txtPassword_Leave;
            // 
            // picTogglePassword
            // 
            picTogglePassword.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            picTogglePassword.BackColor = Color.White;
            picTogglePassword.Cursor = Cursors.Hand;
            picTogglePassword.Image = Properties.Resources.eye_close;
            picTogglePassword.Location = new Point(493, 142);
            picTogglePassword.Name = "picTogglePassword";
            picTogglePassword.Size = new Size(38, 20);
            picTogglePassword.SizeMode = PictureBoxSizeMode.Zoom;
            picTogglePassword.TabIndex = 11;
            picTogglePassword.TabStop = false;
            picTogglePassword.Click += picTogglePassword_Click;
            // 
            // btnClear
            // 
            btnClear.AutoSize = true;
            btnClear.BackColor = Color.LimeGreen;
            btnClear.Cursor = Cursors.Hand;
            btnClear.FlatAppearance.BorderSize = 0;
            btnClear.FlatAppearance.MouseDownBackColor = Color.Red;
            btnClear.FlatAppearance.MouseOverBackColor = Color.Red;
            btnClear.FlatStyle = FlatStyle.Flat;
            btnClear.Font = new Font("Arial", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnClear.ImageAlign = ContentAlignment.MiddleLeft;
            btnClear.Location = new Point(450, 266);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(81, 32);
            btnClear.TabIndex = 10;
            btnClear.Text = "Clear";
            btnClear.UseVisualStyleBackColor = false;
            btnClear.Click += btnClear_Click;
            // 
            // panelHeaderGLD
            // 
            panelHeaderGLD.Controls.Add(lblGLD);
            panelHeaderGLD.Dock = DockStyle.Top;
            panelHeaderGLD.Location = new Point(0, 0);
            panelHeaderGLD.Name = "panelHeaderGLD";
            panelHeaderGLD.Padding = new Padding(0, 15, 0, 10);
            panelHeaderGLD.Size = new Size(650, 80);
            panelHeaderGLD.TabIndex = 9;
            // 
            // lblGLD
            // 
            lblGLD.AutoSize = true;
            lblGLD.Font = new Font("Arial", 21.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblGLD.ForeColor = Color.White;
            lblGLD.Location = new Point(150, 24);
            lblGLD.Name = "lblGLD";
            lblGLD.Size = new Size(348, 34);
            lblGLD.TabIndex = 0;
            lblGLD.Text = "Generate Login Detailes";
            lblGLD.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnSaveGLD
            // 
            btnSaveGLD.AutoSize = true;
            btnSaveGLD.BackColor = Color.White;
            btnSaveGLD.Cursor = Cursors.Hand;
            btnSaveGLD.FlatAppearance.BorderSize = 0;
            btnSaveGLD.FlatStyle = FlatStyle.Flat;
            btnSaveGLD.Font = new Font("Arial", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSaveGLD.Image = Properties.Resources.save_file;
            btnSaveGLD.ImageAlign = ContentAlignment.MiddleLeft;
            btnSaveGLD.Location = new Point(322, 266);
            btnSaveGLD.Name = "btnSaveGLD";
            btnSaveGLD.Size = new Size(81, 32);
            btnSaveGLD.TabIndex = 8;
            btnSaveGLD.Text = "Save";
            btnSaveGLD.TextAlign = ContentAlignment.MiddleRight;
            btnSaveGLD.UseVisualStyleBackColor = false;
            btnSaveGLD.Click += btnSave_Click;
            // 
            // cmbDepartment
            // 
            cmbDepartment.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbDepartment.FormattingEnabled = true;
            cmbDepartment.Location = new Point(209, 182);
            cmbDepartment.Name = "cmbDepartment";
            cmbDepartment.Size = new Size(321, 23);
            cmbDepartment.TabIndex = 7;
            cmbDepartment.SelectedIndexChanged += cmbDepartment_SelectedIndexChanged;
            // 
            // cmbEmployee
            // 
            cmbEmployee.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbEmployee.FormattingEnabled = true;
            cmbEmployee.Location = new Point(210, 224);
            cmbEmployee.Name = "cmbEmployee";
            cmbEmployee.Size = new Size(321, 23);
            cmbEmployee.TabIndex = 6;
            // 
            // txtUsername
            // 
            txtUsername.Location = new Point(210, 99);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(321, 23);
            txtUsername.TabIndex = 4;
            // 
            // lblEmployee
            // 
            lblEmployee.AutoSize = true;
            lblEmployee.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblEmployee.ForeColor = Color.White;
            lblEmployee.Location = new Point(99, 225);
            lblEmployee.Name = "lblEmployee";
            lblEmployee.Size = new Size(95, 19);
            lblEmployee.TabIndex = 3;
            lblEmployee.Text = "Employee :";
            lblEmployee.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblDepartment
            // 
            lblDepartment.AutoSize = true;
            lblDepartment.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblDepartment.ForeColor = Color.White;
            lblDepartment.Location = new Point(99, 183);
            lblDepartment.Name = "lblDepartment";
            lblDepartment.Size = new Size(108, 19);
            lblDepartment.TabIndex = 2;
            lblDepartment.Text = "Department :";
            lblDepartment.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblPassword.ForeColor = Color.White;
            lblPassword.Location = new Point(99, 143);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(96, 19);
            lblPassword.TabIndex = 1;
            lblPassword.Text = "Password :";
            lblPassword.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblUsername
            // 
            lblUsername.AutoSize = true;
            lblUsername.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblUsername.ForeColor = Color.White;
            lblUsername.Location = new Point(99, 101);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(97, 19);
            lblUsername.TabIndex = 0;
            lblUsername.Text = "Username :";
            lblUsername.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // GLD
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1273, 704);
            Controls.Add(panelMainGLD);
            FormBorderStyle = FormBorderStyle.None;
            Name = "GLD";
            Text = "GLD";
            Load += GLD_Load;
            Resize += GLD_Resize;
            panelMainGLD.ResumeLayout(false);
            panelCenterGLD.ResumeLayout(false);
            panelCenterGLD.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picTogglePassword).EndInit();
            panelHeaderGLD.ResumeLayout(false);
            panelHeaderGLD.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelMainGLD;
        private Panel panelCenterGLD;
        private Panel panelHeaderGLD;
        private Label lblGLD;
        private Button btnSaveGLD;
        private ComboBox cmbDepartment;
        private ComboBox cmbEmployee;
        private TextBox txtPassword;
        private TextBox txtUsername;
        private Label lblEmployee;
        private Label lblDepartment;
        private Label lblPassword;
        private Label lblUsername;
        private Button btnClear;
        private PictureBox picTogglePassword;
    }
}