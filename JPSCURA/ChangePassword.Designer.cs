namespace JPSCURA
{
    partial class ChangePassword
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
            pnlChangepass = new Panel();
            btncancel = new Button();
            btnChange = new Button();
            piceye2 = new PictureBox();
            lblcurrentpass = new Label();
            lblnewpassword = new Label();
            picEye = new PictureBox();
            txtOldPassword = new TextBox();
            txtNewPassword = new TextBox();
            pnlChangepass.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)piceye2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picEye).BeginInit();
            SuspendLayout();
            // 
            // pnlChangepass
            // 
            pnlChangepass.BackColor = Color.FromArgb(83, 144, 203);
            pnlChangepass.Controls.Add(btncancel);
            pnlChangepass.Controls.Add(btnChange);
            pnlChangepass.Controls.Add(piceye2);
            pnlChangepass.Controls.Add(lblcurrentpass);
            pnlChangepass.Controls.Add(lblnewpassword);
            pnlChangepass.Controls.Add(picEye);
            pnlChangepass.Controls.Add(txtOldPassword);
            pnlChangepass.Controls.Add(txtNewPassword);
            pnlChangepass.Dock = DockStyle.Fill;
            pnlChangepass.Location = new Point(0, 0);
            pnlChangepass.Name = "pnlChangepass";
            pnlChangepass.Size = new Size(356, 219);
            pnlChangepass.TabIndex = 0;
            // 
            // btncancel
            // 
            btncancel.Location = new Point(222, 157);
            btncancel.Name = "btncancel";
            btncancel.Size = new Size(75, 23);
            btncancel.TabIndex = 13;
            btncancel.Text = "Cancel";
            btncancel.UseVisualStyleBackColor = true;
            btncancel.Click += btncancel_Click;
            // 
            // btnChange
            // 
            btnChange.Location = new Point(139, 157);
            btnChange.Name = "btnChange";
            btnChange.Size = new Size(75, 23);
            btnChange.TabIndex = 12;
            btnChange.Text = "Change ";
            btnChange.UseVisualStyleBackColor = true;
            btnChange.Click += btnChange_Click;
            // 
            // piceye2
            // 
            piceye2.BackColor = Color.White;
            piceye2.Cursor = Cursors.Hand;
            piceye2.Image = Properties.Resources.eye_close;
            piceye2.Location = new Point(277, 70);
            piceye2.Name = "piceye2";
            piceye2.Size = new Size(15, 15);
            piceye2.SizeMode = PictureBoxSizeMode.StretchImage;
            piceye2.TabIndex = 11;
            piceye2.TabStop = false;
            piceye2.Click += picEye_Click;
            // 
            // lblcurrentpass
            // 
            lblcurrentpass.AutoSize = true;
            lblcurrentpass.BackColor = Color.FromArgb(0, 0, 0, 0);
            lblcurrentpass.Font = new Font("Tahoma", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblcurrentpass.ForeColor = Color.White;
            lblcurrentpass.Location = new Point(106, 41);
            lblcurrentpass.Name = "lblcurrentpass";
            lblcurrentpass.Size = new Size(142, 18);
            lblcurrentpass.TabIndex = 9;
            lblcurrentpass.Text = "Current Password";
            // 
            // lblnewpassword
            // 
            lblnewpassword.AutoSize = true;
            lblnewpassword.BackColor = Color.FromArgb(0, 0, 0, 0);
            lblnewpassword.Font = new Font("Tahoma", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblnewpassword.ForeColor = Color.White;
            lblnewpassword.Location = new Point(115, 94);
            lblnewpassword.Name = "lblnewpassword";
            lblnewpassword.Size = new Size(119, 18);
            lblnewpassword.TabIndex = 10;
            lblnewpassword.Text = "New Password";
            // 
            // picEye
            // 
            picEye.BackColor = Color.White;
            picEye.Cursor = Cursors.Hand;
            picEye.Image = Properties.Resources.eye_close;
            picEye.Location = new Point(277, 119);
            picEye.Name = "picEye";
            picEye.Size = new Size(15, 15);
            picEye.SizeMode = PictureBoxSizeMode.StretchImage;
            picEye.TabIndex = 8;
            picEye.TabStop = false;
            picEye.Click += picEye2_Click;
            // 
            // txtOldPassword
            // 
            txtOldPassword.BackColor = Color.White;
            txtOldPassword.Location = new Point(51, 66);
            txtOldPassword.Name = "txtOldPassword";
            txtOldPassword.Size = new Size(245, 23);
            txtOldPassword.TabIndex = 6;
            // 
            // txtNewPassword
            // 
            txtNewPassword.Location = new Point(51, 115);
            txtNewPassword.Name = "txtNewPassword";
            txtNewPassword.Size = new Size(245, 23);
            txtNewPassword.TabIndex = 7;
            // 
            // ChangePassword
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(356, 219);
            Controls.Add(pnlChangepass);
            FormBorderStyle = FormBorderStyle.SizableToolWindow;
            MaximizeBox = false;
            MaximumSize = new Size(409, 400);
            MinimizeBox = false;
            Name = "ChangePassword";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Change Password";
            Load += ChangePassword_Load;
            pnlChangepass.ResumeLayout(false);
            pnlChangepass.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)piceye2).EndInit();
            ((System.ComponentModel.ISupportInitialize)picEye).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlChangepass;
        private PictureBox picEye;
        private TextBox txtOldPassword;
        private TextBox txtNewPassword;
        private PictureBox piceye2;
        private Label lblcurrentpass;
        private Label lblnewpassword;
        private Button btncancel;
        private Button btnChange;
    }
}