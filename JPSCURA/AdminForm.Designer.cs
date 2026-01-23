namespace JPSCURA
{
    partial class AdminForm
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
            Label lblMeetingSchedule;
            Label lblTopicOfDiscussion;
            Label lblMeetingDateAndTime;
            Label lblAssignedBy;
            btnAdd = new Button();
            btnUpcomingMeetings = new Button();
            txtTopicOfDiscussion = new TextBox();
            dtpMeetingDateandTime = new DateTimePicker();
            txtAssignedBy = new TextBox();
            btnDone = new Button();
            lblMeetingSchedule = new Label();
            lblTopicOfDiscussion = new Label();
            lblMeetingDateAndTime = new Label();
            lblAssignedBy = new Label();
            SuspendLayout();
            // 
            // lblMeetingSchedule
            // 
            lblMeetingSchedule.AutoSize = true;
            lblMeetingSchedule.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblMeetingSchedule.ForeColor = Color.White;
            lblMeetingSchedule.Location = new Point(12, 9);
            lblMeetingSchedule.Name = "lblMeetingSchedule";
            lblMeetingSchedule.Size = new Size(280, 41);
            lblMeetingSchedule.TabIndex = 0;
            lblMeetingSchedule.Text = " Meeting Schedule";
            // 
            // lblTopicOfDiscussion
            // 
            lblTopicOfDiscussion.AutoSize = true;
            lblTopicOfDiscussion.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTopicOfDiscussion.ForeColor = Color.White;
            lblTopicOfDiscussion.Location = new Point(26, 124);
            lblTopicOfDiscussion.Name = "lblTopicOfDiscussion";
            lblTopicOfDiscussion.Size = new Size(235, 31);
            lblTopicOfDiscussion.TabIndex = 3;
            lblTopicOfDiscussion.Text = "Topic Of Discussion :";
            // 
            // lblMeetingDateAndTime
            // 
            lblMeetingDateAndTime.AutoSize = true;
            lblMeetingDateAndTime.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblMeetingDateAndTime.ForeColor = Color.White;
            lblMeetingDateAndTime.Location = new Point(26, 206);
            lblMeetingDateAndTime.Name = "lblMeetingDateAndTime";
            lblMeetingDateAndTime.Size = new Size(281, 31);
            lblMeetingDateAndTime.TabIndex = 5;
            lblMeetingDateAndTime.Text = "Meeting Date And Time :";
            // 
            // lblAssignedBy
            // 
            lblAssignedBy.AutoSize = true;
            lblAssignedBy.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblAssignedBy.ForeColor = Color.White;
            lblAssignedBy.Location = new Point(26, 288);
            lblAssignedBy.Name = "lblAssignedBy";
            lblAssignedBy.Size = new Size(156, 31);
            lblAssignedBy.TabIndex = 7;
            lblAssignedBy.Text = "Assigned By :";
            // 
            // btnAdd
            // 
            btnAdd.BackColor = Color.MediumTurquoise;
            btnAdd.FlatStyle = FlatStyle.Flat;
            btnAdd.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAdd.Location = new Point(26, 53);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(100, 40);
            btnAdd.TabIndex = 1;
            btnAdd.Text = "Add";
            btnAdd.UseVisualStyleBackColor = false;
            // 
            // btnUpcomingMeetings
            // 
            btnUpcomingMeetings.BackColor = Color.MediumTurquoise;
            btnUpcomingMeetings.FlatStyle = FlatStyle.Flat;
            btnUpcomingMeetings.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnUpcomingMeetings.Location = new Point(132, 53);
            btnUpcomingMeetings.Name = "btnUpcomingMeetings";
            btnUpcomingMeetings.Size = new Size(200, 40);
            btnUpcomingMeetings.TabIndex = 2;
            btnUpcomingMeetings.Text = "Upcoming Meetings";
            btnUpcomingMeetings.UseVisualStyleBackColor = false;
            // 
            // txtTopicOfDiscussion
            // 
            txtTopicOfDiscussion.BorderStyle = BorderStyle.FixedSingle;
            txtTopicOfDiscussion.Location = new Point(26, 158);
            txtTopicOfDiscussion.Multiline = true;
            txtTopicOfDiscussion.Name = "txtTopicOfDiscussion";
            txtTopicOfDiscussion.Size = new Size(306, 34);
            txtTopicOfDiscussion.TabIndex = 4;
            // 
            // dtpMeetingDateandTime
            // 
            dtpMeetingDateandTime.Location = new Point(26, 240);
            dtpMeetingDateandTime.Name = "dtpMeetingDateandTime";
            dtpMeetingDateandTime.Size = new Size(306, 27);
            dtpMeetingDateandTime.TabIndex = 6;
            // 
            // txtAssignedBy
            // 
            txtAssignedBy.BorderStyle = BorderStyle.FixedSingle;
            txtAssignedBy.Location = new Point(26, 322);
            txtAssignedBy.Multiline = true;
            txtAssignedBy.Name = "txtAssignedBy";
            txtAssignedBy.Size = new Size(306, 34);
            txtAssignedBy.TabIndex = 8;
            // 
            // btnDone
            // 
            btnDone.BackColor = Color.MediumTurquoise;
            btnDone.FlatStyle = FlatStyle.Flat;
            btnDone.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnDone.Location = new Point(26, 374);
            btnDone.Name = "btnDone";
            btnDone.Size = new Size(100, 40);
            btnDone.TabIndex = 9;
            btnDone.Text = "Done";
            btnDone.UseVisualStyleBackColor = false;
            // 
            // AdminForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LightSteelBlue;
            ClientSize = new Size(1217, 623);
            Controls.Add(btnDone);
            Controls.Add(txtAssignedBy);
            Controls.Add(lblAssignedBy);
            Controls.Add(dtpMeetingDateandTime);
            Controls.Add(lblMeetingDateAndTime);
            Controls.Add(txtTopicOfDiscussion);
            Controls.Add(lblTopicOfDiscussion);
            Controls.Add(btnUpcomingMeetings);
            Controls.Add(btnAdd);
            Controls.Add(lblMeetingSchedule);
            FormBorderStyle = FormBorderStyle.None;
            Name = "AdminForm";
            Text = "AdminForm";
            Load += AdminForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnAdd;
        private Button btnUpcomingMeetings;
        private TextBox txtTopicOfDiscussion;
        private DateTimePicker dtpMeetingDateandTime;
        private TextBox txtAssignedBy;
        private Button btnDone;
    }
}