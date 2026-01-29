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
            pnllogintitlebar = new Panel();
            loginclosebutton = new Button();
            lblappname = new Label();
            pctboxlogo = new PictureBox();
            pnlLogin = new Panel();
            lbljpsucrawithlogo = new Label();
            lblusername = new Label();
            btnLogin = new Button();
            picEye = new PictureBox();
            lblpassword = new Label();
            txtUsername = new TextBox();
            txtPassword = new TextBox();
            panel1.SuspendLayout();
            pnllogintitlebar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pctboxlogo).BeginInit();
            pnlLogin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picEye).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(70, 225, 225, 225);
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(pnllogintitlebar);
            panel1.Controls.Add(pnlLogin);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(429, 408);
            panel1.TabIndex = 0;
            // 
            // pnllogintitlebar
            // 
            pnllogintitlebar.BackColor = Color.White;
            pnllogintitlebar.Controls.Add(loginclosebutton);
            pnllogintitlebar.Controls.Add(lblappname);
            pnllogintitlebar.Controls.Add(pctboxlogo);
            pnllogintitlebar.Dock = DockStyle.Top;
            pnllogintitlebar.Location = new Point(0, 0);
            pnllogintitlebar.Name = "pnllogintitlebar";
            pnllogintitlebar.Size = new Size(427, 31);
            pnllogintitlebar.TabIndex = 8;
            // 
            // loginclosebutton
            // 
            loginclosebutton.Cursor = Cursors.Hand;
            loginclosebutton.Dock = DockStyle.Right;
            loginclosebutton.FlatAppearance.BorderSize = 0;
            loginclosebutton.FlatAppearance.MouseDownBackColor = Color.FromArgb(230, 15, 35);
            loginclosebutton.FlatAppearance.MouseOverBackColor = Color.FromArgb(230, 15, 35);
            loginclosebutton.FlatStyle = FlatStyle.Flat;
            loginclosebutton.Image = Properties.Resources.close3;
            loginclosebutton.Location = new Point(396, 0);
            loginclosebutton.Name = "loginclosebutton";
            loginclosebutton.Size = new Size(31, 31);
            loginclosebutton.TabIndex = 2;
            loginclosebutton.UseVisualStyleBackColor = true;
            loginclosebutton.Click += loginclosebutton_Click;
            // 
            // lblappname
            // 
            lblappname.AutoSize = true;
            lblappname.BackColor = Color.White;
            lblappname.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblappname.ForeColor = Color.FromArgb(59, 43, 151);
            lblappname.Location = new Point(26, 9);
            lblappname.Name = "lblappname";
            lblappname.Size = new Size(340, 15);
            lblappname.TabIndex = 1;
            lblappname.Text = "JPSCURA – An Indigenous Software Of JPSCUBE ENGINEERS";
            // 
            // pctboxlogo
            // 
            pctboxlogo.BackColor = Color.Transparent;
            pctboxlogo.Image = Properties.Resources.logo_32;
            pctboxlogo.Location = new Point(4, 5);
            pctboxlogo.Name = "pctboxlogo";
            pctboxlogo.Size = new Size(22, 22);
            pctboxlogo.SizeMode = PictureBoxSizeMode.Zoom;
            pctboxlogo.TabIndex = 0;
            pctboxlogo.TabStop = false;
            // 
            // pnlLogin
            // 
            pnlLogin.BackColor = Color.FromArgb(190, 225, 225, 225);
            pnlLogin.Controls.Add(lbljpsucrawithlogo);
            pnlLogin.Controls.Add(lblusername);
            pnlLogin.Controls.Add(btnLogin);
            pnlLogin.Controls.Add(picEye);
            pnlLogin.Controls.Add(lblpassword);
            pnlLogin.Controls.Add(txtUsername);
            pnlLogin.Controls.Add(txtPassword);
            pnlLogin.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            pnlLogin.Location = new Point(70, 107);
            pnlLogin.Name = "pnlLogin";
            pnlLogin.Size = new Size(289, 222);
            pnlLogin.TabIndex = 7;
            pnlLogin.Paint += pnlLogin_Paint;
            // 
            // lbljpsucrawithlogo
            // 
            lbljpsucrawithlogo.BackColor = Color.Transparent;
            lbljpsucrawithlogo.FlatStyle = FlatStyle.Flat;
            lbljpsucrawithlogo.Font = new Font("Impact", 21F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbljpsucrawithlogo.ForeColor = Color.FromArgb(59, 43, 151);
            lbljpsucrawithlogo.Image = (Image)resources.GetObject("lbljpsucrawithlogo.Image");
            lbljpsucrawithlogo.ImageAlign = ContentAlignment.MiddleLeft;
            lbljpsucrawithlogo.Location = new Point(71, 17);
            lbljpsucrawithlogo.Name = "lbljpsucrawithlogo";
            lbljpsucrawithlogo.Size = new Size(143, 40);
            lbljpsucrawithlogo.TabIndex = 7;
            lbljpsucrawithlogo.Text = "JPSCURA";
            lbljpsucrawithlogo.TextAlign = ContentAlignment.MiddleRight;
            lbljpsucrawithlogo.UseCompatibleTextRendering = true;
            // 
            // lblusername
            // 
            lblusername.AutoSize = true;
            lblusername.BackColor = Color.FromArgb(0, 0, 0, 0);
            lblusername.Font = new Font("Tahoma", 8.5F, FontStyle.Bold);
            lblusername.ForeColor = Color.FromArgb(59, 43, 151);
            lblusername.Location = new Point(19, 76);
            lblusername.Name = "lblusername";
            lblusername.Size = new Size(66, 14);
            lblusername.TabIndex = 0;
            lblusername.Text = "Username";
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
            picEye.Image = Properties.Resources.eye_close;
            picEye.Location = new Point(248, 150);
            picEye.Name = "picEye";
            picEye.Size = new Size(15, 15);
            picEye.SizeMode = PictureBoxSizeMode.StretchImage;
            picEye.TabIndex = 5;
            picEye.TabStop = false;
            picEye.Click += picEye_Click;
            // 
            // lblpassword
            // 
            lblpassword.AutoSize = true;
            lblpassword.BackColor = Color.FromArgb(0, 0, 0, 0);
            lblpassword.Font = new Font("Tahoma", 8.5F, FontStyle.Bold);
            lblpassword.ForeColor = Color.FromArgb(59, 43, 151);
            lblpassword.Location = new Point(18, 128);
            lblpassword.Name = "lblpassword";
            lblpassword.Size = new Size(66, 14);
            lblpassword.TabIndex = 2;
            lblpassword.Text = "Password";
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
            BackgroundImage = Properties.Resources.login_image;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(429, 408);
            Controls.Add(panel1);
            ForeColor = SystemColors.ActiveCaptionText;
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "LoginForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "JPSCURA – An Indigenous Software Of JPSCUBE ENGINEERS ";
            Load += LoginForm_Load;
            panel1.ResumeLayout(false);
            pnllogintitlebar.ResumeLayout(false);
            pnllogintitlebar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pctboxlogo).EndInit();
            pnlLogin.ResumeLayout(false);
            pnlLogin.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picEye).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel pnlLogin;
        private Label lbljpsucrawithlogo;
        private Label lblusername;
        private Button btnLogin;
        private PictureBox picEye;
        private Label lblpassword;
        private TextBox txtUsername;
        private TextBox txtPassword;
        private Panel pnllogintitlebar;
        private PictureBox pctboxlogo;
        private Label lblappname;
        private Button loginclosebutton;
    }
}