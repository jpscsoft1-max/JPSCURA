namespace JPSCURA
{
    partial class PasswordConfirmForm
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
            pnlpassword = new Panel();
            picEye = new PictureBox();
            btnpassConfirm = new Button();
            btnpasscancel = new Button();
            txtPassword = new TextBox();
            lblPassword = new Label();
            pnlpassword.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picEye).BeginInit();
            SuspendLayout();
            // 
            // pnlpassword
            // 
            pnlpassword.BackColor = Color.WhiteSmoke;
            pnlpassword.Controls.Add(picEye);
            pnlpassword.Controls.Add(btnpassConfirm);
            pnlpassword.Controls.Add(btnpasscancel);
            pnlpassword.Controls.Add(txtPassword);
            pnlpassword.Controls.Add(lblPassword);
            pnlpassword.Dock = DockStyle.Fill;
            pnlpassword.Location = new Point(0, 0);
            pnlpassword.Name = "pnlpassword";
            pnlpassword.Size = new Size(232, 121);
            pnlpassword.TabIndex = 0;
            // 
            // picEye
            // 
            picEye.BackColor = SystemColors.Window;
            picEye.Image = Properties.Resources.eye_close;
            picEye.InitialImage = null;
            picEye.Location = new Point(170, 51);
            picEye.Name = "picEye";
            picEye.Size = new Size(15, 15);
            picEye.SizeMode = PictureBoxSizeMode.Zoom;
            picEye.TabIndex = 4;
            picEye.TabStop = false;
            picEye.Click += picEye_Click;
            // 
            // btnpassConfirm
            // 
            btnpassConfirm.Location = new Point(115, 86);
            btnpassConfirm.Name = "btnpassConfirm";
            btnpassConfirm.Size = new Size(75, 23);
            btnpassConfirm.TabIndex = 3;
            btnpassConfirm.Text = "Confirm";
            btnpassConfirm.UseVisualStyleBackColor = true;
            btnpassConfirm.Click += btnConfirm_Click;
            // 
            // btnpasscancel
            // 
            btnpasscancel.Location = new Point(34, 86);
            btnpasscancel.Name = "btnpasscancel";
            btnpasscancel.Size = new Size(75, 23);
            btnpasscancel.TabIndex = 2;
            btnpasscancel.Text = "Cancel";
            btnpasscancel.UseVisualStyleBackColor = true;
            btnpasscancel.Click += btnCancel_Click;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(34, 47);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(156, 23);
            txtPassword.TabIndex = 1;
            txtPassword.UseSystemPasswordChar = true;
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblPassword.Location = new Point(29, 18);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(169, 17);
            lblPassword.TabIndex = 0;
            lblPassword.Text = "Insert Password to proceed";
            // 
            // PasswordConfirmForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(232, 121);
            Controls.Add(pnlpassword);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MaximumSize = new Size(248, 160);
            MinimizeBox = false;
            MinimumSize = new Size(248, 160);
            Name = "PasswordConfirmForm";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterScreen;
            Load += PasswordConfirmForm_Load;
            pnlpassword.ResumeLayout(false);
            pnlpassword.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picEye).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlpassword;
        private TextBox txtPassword;
        private Label lblPassword;
        private Button btnpassConfirm;
        private Button btnpasscancel;
        private PictureBox picEye;
    }
}