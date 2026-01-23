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
            txtPassword = new TextBox();
            txtUsername = new TextBox();
            label2 = new Label();
            picEye = new PictureBox();
            btnLogin = new Button();
            label1 = new Label();
            pnlLogin = new Panel();
            label3 = new Label();
            ((System.ComponentModel.ISupportInitialize)picEye).BeginInit();
            pnlLogin.SuspendLayout();
            SuspendLayout();
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(20, 123);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.Size = new Size(291, 23);
            txtPassword.TabIndex = 3;
            // 
            // txtUsername
            // 
            txtUsername.Location = new Point(20, 79);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(291, 23);
            txtUsername.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(20, 105);
            label2.Name = "label2";
            label2.Size = new Size(57, 15);
            label2.TabIndex = 2;
            label2.Text = "Password";
            // 
            // picEye
            // 
            picEye.BackColor = Color.White;
            picEye.Cursor = Cursors.Hand;
            picEye.Image = (Image)resources.GetObject("picEye.Image");
            picEye.Location = new Point(291, 127);
            picEye.Name = "picEye";
            picEye.Size = new Size(15, 15);
            picEye.SizeMode = PictureBoxSizeMode.StretchImage;
            picEye.TabIndex = 5;
            picEye.TabStop = false;
            picEye.Click += picEye_Click;
            // 
            // btnLogin
            // 
            btnLogin.BackColor = Color.White;
            btnLogin.BackgroundImageLayout = ImageLayout.None;
            btnLogin.FlatAppearance.BorderSize = 0;
            btnLogin.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLogin.ForeColor = SystemColors.Highlight;
            btnLogin.Location = new Point(126, 165);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(75, 23);
            btnLogin.TabIndex = 4;
            btnLogin.Text = "Login";
            btnLogin.UseVisualStyleBackColor = false;
            btnLogin.Click += btnLogin_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(20, 61);
            label1.Name = "label1";
            label1.Size = new Size(60, 15);
            label1.TabIndex = 0;
            label1.Text = "Username";
            // 
            // pnlLogin
            // 
            pnlLogin.BackColor = SystemColors.MenuBar;
            pnlLogin.Controls.Add(label3);
            pnlLogin.Controls.Add(label1);
            pnlLogin.Controls.Add(btnLogin);
            pnlLogin.Controls.Add(picEye);
            pnlLogin.Controls.Add(label2);
            pnlLogin.Controls.Add(txtUsername);
            pnlLogin.Controls.Add(txtPassword);
            pnlLogin.Location = new Point(103, 51);
            pnlLogin.Name = "pnlLogin";
            pnlLogin.Size = new Size(330, 200);
            pnlLogin.TabIndex = 6;
            pnlLogin.Paint += pnlLogin_Paint;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.FlatStyle = FlatStyle.Flat;
            label3.Font = new Font("Impact", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.SteelBlue;
            label3.Location = new Point(107, 14);
            label3.Name = "label3";
            label3.Size = new Size(116, 40);
            label3.TabIndex = 7;
            label3.Text = "WELCOME";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            label3.UseCompatibleTextRendering = true;
            // 
            // LoginForm
            // 
            AcceptButton = btnLogin;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.CornflowerBlue;
            BackgroundImageLayout = ImageLayout.None;
            ClientSize = new Size(541, 298);
            Controls.Add(pnlLogin);
            ForeColor = SystemColors.ActiveCaptionText;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "LoginForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "JPSCURA";
            Load += LoginForm_Load;
            ((System.ComponentModel.ISupportInitialize)picEye).EndInit();
            pnlLogin.ResumeLayout(false);
            pnlLogin.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TextBox txtPassword;
        private TextBox txtUsername;
        private Label label2;
        private PictureBox picEye;
        private Button btnLogin;
        private Label label1;
        private Panel pnlLogin;
        private Label label3;
    }
}