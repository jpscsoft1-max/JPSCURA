namespace JPSCURA
{
    partial class LoginForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            panel1 = new Panel();
            pnlLogin = new Panel();
            label3 = new Label();
            label1 = new Label();
            btnLogin = new Button();
            picEye = new PictureBox();
            label2 = new Label();
            txtUsername = new TextBox();
            txtPassword = new TextBox();
            panel1.SuspendLayout();
            pnlLogin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picEye).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(100, 225, 225, 225);
            panel1.Controls.Add(pnlLogin);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(429, 408);
            panel1.TabIndex = 0;
            // 
            // pnlLogin
            // 
            pnlLogin.BackColor = Color.FromArgb(190, 225, 225, 225);
            pnlLogin.Controls.Add(label3);
            pnlLogin.Controls.Add(label1);
            pnlLogin.Controls.Add(btnLogin);
            pnlLogin.Controls.Add(picEye);
            pnlLogin.Controls.Add(label2);
            pnlLogin.Controls.Add(txtUsername);
            pnlLogin.Controls.Add(txtPassword);
            pnlLogin.Location = new Point(70, 91);
            pnlLogin.Name = "pnlLogin";
            pnlLogin.Size = new Size(289, 222);
            pnlLogin.TabIndex = 7;
            pnlLogin.Paint += pnlLogin_Paint;
            // 
            // label3
            // 
            label3.BackColor = Color.Transparent;
            label3.FlatStyle = FlatStyle.Flat;
            label3.Font = new Font("Impact", 21F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.FromArgb(59, 43, 151);
            label3.Image = (Image)resources.GetObject("label3.Image");
            label3.ImageAlign = ContentAlignment.MiddleLeft;
            label3.Location = new Point(72, 17);
            label3.Name = "label3";
            label3.Size = new Size(143, 40);
            label3.TabIndex = 7;
            label3.Text = "JPSCURA";
            label3.TextAlign = ContentAlignment.MiddleRight;
            label3.UseCompatibleTextRendering = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.FromArgb(0, 0, 0, 0);
            label1.Font = new Font("Tahoma", 8.5F, FontStyle.Bold);
            label1.ForeColor = Color.FromArgb(59, 43, 151);
            label1.Location = new Point(19, 76);
            label1.Name = "label1";
            label1.Size = new Size(66, 14);
            label1.TabIndex = 0;
            label1.Text = "Username";
            // 
            // btnLogin
            // 
            btnLogin.BackColor = Color.White;
            btnLogin.BackgroundImageLayout = ImageLayout.None;
            btnLogin.FlatAppearance.BorderSize = 0;
            btnLogin.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLogin.ForeColor = SystemColors.Highlight;
            btnLogin.Location = new Point(103, 184);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(75, 23);
            btnLogin.TabIndex = 4;
            btnLogin.Text = "Login";
            btnLogin.UseVisualStyleBackColor = false;
            // 
            // picEye
            // 
            picEye.BackColor = Color.White;
            picEye.Cursor = Cursors.Hand;
            picEye.Image = (Image)resources.GetObject("picEye.Image");
            picEye.Location = new Point(248, 150);
            picEye.Name = "picEye";
            picEye.Size = new Size(15, 15);
            picEye.SizeMode = PictureBoxSizeMode.StretchImage;
            picEye.TabIndex = 5;
            picEye.TabStop = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.FromArgb(0, 0, 0, 0);
            label2.Font = new Font("Tahoma", 8.5F, FontStyle.Bold);
            label2.ForeColor = Color.FromArgb(59, 43, 151);
            label2.Location = new Point(18, 128);
            label2.Name = "label2";
            label2.Size = new Size(66, 14);
            label2.TabIndex = 2;
            label2.Text = "Password";
            // 
            // txtUsername
            // 
            txtUsername.BackColor = Color.White;
            txtUsername.Location = new Point(21, 95);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(245, 23);
            txtUsername.TabIndex = 1;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(21, 146);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.Size = new Size(245, 23);
            txtPassword.TabIndex = 3;
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Honeydew;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.None;
            ClientSize = new Size(429, 408);
            Controls.Add(panel1);
            ForeColor = SystemColors.ActiveCaptionText;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "LoginForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "JPSCURA";
            Load += LoginForm_Load;
            panel1.ResumeLayout(false);
            pnlLogin.ResumeLayout(false);
            pnlLogin.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picEye).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel pnlLogin;
        private Label label3;
        private Label label1;
        private Button btnLogin;
        private PictureBox picEye;
        private Label label2;
        private TextBox txtUsername;
        private TextBox txtPassword;
    }
}