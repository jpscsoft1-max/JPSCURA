using Microsoft.Data.SqlClient;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace JPSCURA
{
    public partial class Change_Password_Form : Form
    {
        public Change_Password_Form()
        {
            InitializeComponent();
        }

        private void Change_Password_Form_Load(object sender, EventArgs e)
        {
            
            if (Session.Role != "ADMIN")
            {
                MessageBox.Show("Access denied");
                this.Close();
                return;
            }

            SetupGrid();
            LoadRequests();

            // Search events
            txtSearchUsername.TextChanged += ApplySearch;
            txtSearchEmpName.TextChanged += ApplySearch;
            txtSearchStatus.TextChanged += ApplySearch;

            AlignSearchBoxes();
        }

        // ================= GRID SETUP =================
        private void SetupGrid()
        {

            dgvChangePassRequest.ReadOnly = true;
            dgvChangePassRequest.AllowUserToResizeColumns = false;
            dgvChangePassRequest.AllowUserToResizeRows = false;
            dgvChangePassRequest.Columns.Clear();

            dgvChangePassRequest.AllowUserToAddRows = false;
            dgvChangePassRequest.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvChangePassRequest.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvChangePassRequest.RowHeadersVisible = false;

            // ===== STYLE =====
            dgvChangePassRequest.BackgroundColor = Color.White;
            dgvChangePassRequest.GridColor = Color.LightGray;
            dgvChangePassRequest.BorderStyle = BorderStyle.FixedSingle;

            dgvChangePassRequest.EnableHeadersVisualStyles = false;

            dgvChangePassRequest.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dgvChangePassRequest.CellBorderStyle = DataGridViewCellBorderStyle.Single;

            dgvChangePassRequest.ColumnHeadersDefaultCellStyle.BackColor = Color.WhiteSmoke;
            dgvChangePassRequest.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            dgvChangePassRequest.ColumnHeadersDefaultCellStyle.Font =
                new Font("Segoe UI", 9F, FontStyle.Bold);

            dgvChangePassRequest.DefaultCellStyle.BackColor = Color.White;
            dgvChangePassRequest.DefaultCellStyle.ForeColor = Color.Black;
            dgvChangePassRequest.DefaultCellStyle.SelectionBackColor = Color.White;
            dgvChangePassRequest.DefaultCellStyle.SelectionForeColor = Color.Black;

            dgvChangePassRequest.RowTemplate.Height = 26;

            // ===== COLUMNS ===== (NO Approve/Reject button columns)
            dgvChangePassRequest.Columns.Add("Id", "Id");
            dgvChangePassRequest.Columns.Add("UserId", "UserId");
            dgvChangePassRequest.Columns.Add("Username", "Username");
            dgvChangePassRequest.Columns.Add("EmpName", "Employee Name");
            dgvChangePassRequest.Columns.Add("OldPassword", "Old Password");
            dgvChangePassRequest.Columns.Add("NewPassword", "New Password");
            dgvChangePassRequest.Columns.Add("Date", "Requested At");
            dgvChangePassRequest.Columns.Add("Status", "Status");

            dgvChangePassRequest.Columns["Id"].Visible = false;
            dgvChangePassRequest.Columns["UserId"].Visible = false;

            // FIX 2: Double-click opens action dialog instead of buttons
            dgvChangePassRequest.CellDoubleClick += dgvChangePassRequest_CellDoubleClick;

            // ALIGN EVENTS
            dgvChangePassRequest.ColumnWidthChanged += (s, ev) => AlignSearchBoxes();
            dgvChangePassRequest.SizeChanged += (s, ev) => AlignSearchBoxes();

            dgvChangePassRequest.Scroll += (s, ev) =>
            {
                if (ev.ScrollOrientation == ScrollOrientation.HorizontalScroll)
                    AlignSearchBoxes();
            };
        }

        // ================= LOAD DATA =================
        private void LoadRequests()
        {
            dgvChangePassRequest.Rows.Clear();

            using (SqlConnection con = new SqlConnection(DBconection.GetConnectionString()))
            {
                con.Open();

                SqlCommand cmd = new SqlCommand(@"
SELECT 
    R.Id,
    R.UserId,
    U.Username,
    E.Emp_Name,
    R.OldPassword,
    R.NewPassword,
    R.RequestedAt,
    R.Status
FROM EMPLOYEE_MASTER.dbo.PasswordChangeRequests AS R
INNER JOIN EMPLOYEE_MASTER.dbo.Users AS U ON R.UserId = U.UserId
INNER JOIN EMPLOYEE_MASTER.dbo.Employees AS E ON U.Emp_id = E.Emp_id
ORDER BY 
    CASE R.Status 
        WHEN 'Pending'  THEN 1 
        WHEN 'Approved' THEN 2 
        WHEN 'Rejected' THEN 3 
    END,
    R.Id DESC
", con);

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    int rowIndex = dgvChangePassRequest.Rows.Add(
                        dr["Id"],
                        dr["UserId"],
                        dr["Username"].ToString(),
                        dr["Emp_Name"].ToString(),
                        dr["OldPassword"].ToString(),
                        dr["NewPassword"].ToString(),
                        Convert.ToDateTime(dr["RequestedAt"]).ToString("dd-MM-yyyy HH:mm"),
                        dr["Status"].ToString()
                    );

                    // FIX 3: Use helper method for status color
                    ApplyStatusColor(dgvChangePassRequest.Rows[rowIndex], dr["Status"].ToString());
                }
            }
        }

        // ================= STATUS COLOR HELPER =================
        // FIX 3: Extracted to method — reused on load AND after approve/reject
        private void ApplyStatusColor(DataGridViewRow row, string status)
        {
            DataGridViewCell statusCell = row.Cells["Status"];

            if (status == "Approved")
            {
                statusCell.Style.ForeColor = Color.Green;
                statusCell.Style.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            }
            else if (status == "Rejected")
            {
                statusCell.Style.ForeColor = Color.Red;
                statusCell.Style.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            }
            else
            {
                statusCell.Style.ForeColor = Color.DarkOrange;
                statusCell.Style.Font = new Font("Segoe UI", 9F, FontStyle.Regular);
            }
        }

        // ================= SEARCH =================
        private void ApplySearch(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvChangePassRequest.Rows)
            {
                if (row.IsNewRow) continue;

                bool visible = true;

                visible &= Match(row, "Username", txtSearchUsername.Text);
                visible &= Match(row, "EmpName", txtSearchEmpName.Text);
                visible &= Match(row, "Status", txtSearchStatus.Text);

                row.Visible = visible;
            }
        }

        private bool Match(DataGridViewRow row, string col, string text)
        {
            if (string.IsNullOrWhiteSpace(text)) return true;

            string val = row.Cells[col].Value?.ToString() ?? "";
            return val.IndexOf(text, StringComparison.OrdinalIgnoreCase) >= 0;
        }

        // ================= DOUBLE CLICK — ACTION DIALOG =================
        // FIX 2: Double-click on row opens Approve/Reject MessageBox
        private void dgvChangePassRequest_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow selectedRow = dgvChangePassRequest.Rows[e.RowIndex];
            string status = selectedRow.Cells["Status"].Value?.ToString();

            if (status != "Pending")
            {
                MessageBox.Show("Request already processed.", "Info",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int requestId = Convert.ToInt32(selectedRow.Cells["Id"].Value);
            int userId = Convert.ToInt32(selectedRow.Cells["UserId"].Value);
            string username = selectedRow.Cells["Username"].Value?.ToString();
            string newPassword = selectedRow.Cells["NewPassword"].Value?.ToString();

            DialogResult result = MessageBox.Show(
                $"Employee: {username}\n\nWhat action do you want to take?\n\n" +
                "Click  YES  to Approve\n" +
                "Click  NO   to Reject\n" +
                "Click  CANCEL  to go back",
                "Password Change Request",
                MessageBoxButtons.YesNoCancel,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
                ApproveRequest(requestId, userId, newPassword, selectedRow);
            else if (result == DialogResult.No)
                RejectRequest(requestId, selectedRow);
            // Cancel — do nothing
        }

        // ================= APPROVE =================
        private void ApproveRequest(int requestId, int userId, string newPassword, DataGridViewRow row)
        {
            using (SqlConnection con = new SqlConnection(DBconection.GetConnectionString()))
            {
                con.Open();

                SqlCommand updateUser = new SqlCommand(@"
UPDATE EMPLOYEE_MASTER..Users
SET Password = @new
WHERE UserId = @uid
", con);
                updateUser.Parameters.AddWithValue("@new", newPassword);
                updateUser.Parameters.AddWithValue("@uid", userId);
                updateUser.ExecuteNonQuery();

                SqlCommand updateReq = new SqlCommand(@"
UPDATE EMPLOYEE_MASTER..PasswordChangeRequests
SET Status     = 'Approved',
    ApprovedBy = @admin,
    ApprovedAt = GETDATE(),
    IsNotified = 0
WHERE Id = @id
", con);
                updateReq.Parameters.AddWithValue("@admin", Session.UserId);
                updateReq.Parameters.AddWithValue("@id", requestId);
                updateReq.ExecuteNonQuery();
            }

            // FIX 3: Update row directly — color applies immediately without full reload
            row.Cells["Status"].Value = "Approved";
            ApplyStatusColor(row, "Approved");

            MessageBox.Show("Password request approved successfully.", "Approved",
                MessageBoxButtons.OK, MessageBoxIcon.Information);

            ApplySearch(null, null);
        }

        // ================= REJECT =================
        private void RejectRequest(int requestId, DataGridViewRow row)
        {
            using (SqlConnection con = new SqlConnection(DBconection.GetConnectionString()))
            {
                con.Open();

                SqlCommand cmd = new SqlCommand(@"
UPDATE EMPLOYEE_MASTER..PasswordChangeRequests
SET Status = 'Rejected'
WHERE Id = @id
", con);
                cmd.Parameters.AddWithValue("@id", requestId);
                cmd.ExecuteNonQuery();
            }

            // FIX 3: Update row directly — color applies immediately without full reload
            row.Cells["Status"].Value = "Rejected";
            ApplyStatusColor(row, "Rejected");

            MessageBox.Show("Password request rejected.", "Rejected",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);

            ApplySearch(null, null);
        }

        // ================= ALIGN SEARCH BOXES =================
        // FIX 1: Skip hidden columns, skip non-search columns to reach Status correctly
        private const int SEARCH_GAP = 8;

        private void AlignSearchBoxes()
        {
            if (dgvChangePassRequest.Columns.Count == 0) return;

            int left = dgvChangePassRequest.Left
                + (dgvChangePassRequest.RowHeadersVisible ? dgvChangePassRequest.RowHeadersWidth : 0)
                - dgvChangePassRequest.HorizontalScrollingOffset;

            // Place a search textbox over a column
            void Place(TextBox txt, string colName)
            {
                if (!dgvChangePassRequest.Columns.Contains(colName)) return;

                DataGridViewColumn col = dgvChangePassRequest.Columns[colName];
                if (!col.Visible) return;

                int colWidth = col.Width;
                int width = colWidth - SEARCH_GAP;
                if (width < 40) width = 40;

                txt.SetBounds(
                    left + (SEARCH_GAP / 2),
                    txt.Top,
                    width,
                    txt.Height
                );

                left += colWidth;
            }

            // Advance left past a column that has no search box
            void Skip(string colName)
            {
                if (!dgvChangePassRequest.Columns.Contains(colName)) return;
                DataGridViewColumn col = dgvChangePassRequest.Columns[colName];
                if (col.Visible) left += col.Width;
            }

            // Column order: Id(hidden), UserId(hidden), Username, EmpName, OldPassword, NewPassword, Date, Status
            Place(txtSearchUsername, "Username");
            Place(txtSearchEmpName, "EmpName");
            Skip("OldPassword");
            Skip("NewPassword");
            Skip("Date");
            Place(txtSearchStatus, "Status");
        }
    }
}