using Microsoft.Data.SqlClient;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace JPSCURA
{
    public partial class AllEmployee : Form
    {
        private const int SEARCH_GAP = 8;

        public AllEmployee()
        {
            InitializeComponent();
        }

        // ================= FORM LOAD =================
        private void AllEmployee_Load(object sender, EventArgs e)
        {
            panelEmployee.Dock = DockStyle.Fill;
            dgvEmployee.Dock = DockStyle.Fill;

            SetupEmployeeGrid();
            LoadEmployeeGrid();
            WireSearchEvents();

            EnableDoubleBuffering(this);
        }
        private void AlignSearchBoxes()
        {
            if (dgvEmployee.Columns.Count == 0) return;

            int left = dgvEmployee.RowHeadersVisible
                ? dgvEmployee.RowHeadersWidth
                : 0;

            void Place(TextBox txt, string colName)
            {
                if (!dgvEmployee.Columns.Contains(colName)) return;

                int colWidth = dgvEmployee.Columns[colName].Width;
                int width = colWidth - SEARCH_GAP;
                if (width < 40) width = 40;

                txt.SetBounds(
                    left + (SEARCH_GAP / 2),
                    6,          // same top alignment
                    width,
                    txt.Height
                );

                left += colWidth;
            }

            Place(txtSearchEmpCode, "EmpCode");
            Place(txtSearchEmpName, "EmpName");
            Place(txtSearchContact, "Contact");
            Place(txtSearchDepartment, "Department");
            Place(txtSearchRole, "Role");
        }

        // ================= GRID SETUP =================
        private void SetupEmployeeGrid()
        {
            // ===== BASIC RESET =====
            dgvEmployee.SuspendLayout();
            dgvEmployee.Columns.Clear();
            dgvEmployee.Rows.Clear();

            dgvEmployee.AutoGenerateColumns = false;
            dgvEmployee.AllowUserToAddRows = false;
            dgvEmployee.AllowUserToResizeRows = false;
            dgvEmployee.AllowUserToResizeColumns = false;

            dgvEmployee.ReadOnly = true;
            dgvEmployee.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvEmployee.MultiSelect = false;

            dgvEmployee.Dock = DockStyle.Fill;

            // ===== INVENTORY STYLE LOOK =====
            dgvEmployee.BackgroundColor = Color.White;
            dgvEmployee.GridColor = Color.LightGray;
            dgvEmployee.BorderStyle = BorderStyle.FixedSingle;

            dgvEmployee.EnableHeadersVisualStyles = false;
            dgvEmployee.RowHeadersVisible = false;

            dgvEmployee.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dgvEmployee.CellBorderStyle = DataGridViewCellBorderStyle.Single;

            dgvEmployee.ColumnHeadersDefaultCellStyle.BackColor = Color.WhiteSmoke;
            dgvEmployee.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            dgvEmployee.ColumnHeadersDefaultCellStyle.Font =
                new Font("Segoe UI", 9F, FontStyle.Bold);
            dgvEmployee.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.False;
            dgvEmployee.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.WhiteSmoke;
            dgvEmployee.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.Black;

            dgvEmployee.DefaultCellStyle.BackColor = Color.White;
            dgvEmployee.DefaultCellStyle.ForeColor = Color.Black;
            dgvEmployee.DefaultCellStyle.SelectionBackColor = Color.White;
            dgvEmployee.DefaultCellStyle.SelectionForeColor = Color.Black;
            dgvEmployee.DefaultCellStyle.WrapMode = DataGridViewTriState.False;

            dgvEmployee.RowTemplate.Height = 26;

            // ===== COLUMN MODE =====
            dgvEmployee.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // ===== HIDDEN DB ID =====
            dgvEmployee.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "EmpId",
                DataPropertyName = "Emp_id",
                Visible = false
            });

            // ===== SR NO (DYNAMIC) =====
            dgvEmployee.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "SrNo",
                HeaderText = "Sr No",
                Width = 60,
                FillWeight = 4
            });

            dgvEmployee.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "EmpCode",
                HeaderText = "Employee Code",
                DataPropertyName = "Emp_code",
                FillWeight = 6
            });

            dgvEmployee.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "EmpName",
                HeaderText = "Employee Name",
                DataPropertyName = "Emp_Name",
                FillWeight = 10
            });

            dgvEmployee.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Contact",
                HeaderText = "Contact",
                DataPropertyName = "Contact_no",
                FillWeight = 6
            });

            dgvEmployee.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "AltContact",
                HeaderText = "Alt Contact",
                DataPropertyName = "Alt_Contact",
                FillWeight = 6
            });

            dgvEmployee.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Email",
                HeaderText = "Email",
                DataPropertyName = "Email",
                FillWeight = 12
            });

            dgvEmployee.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Address",
                HeaderText = "Address",
                DataPropertyName = "Address",
                FillWeight = 14
            });

            dgvEmployee.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Aadhar",
                HeaderText = "Aadhar No",
                DataPropertyName = "Aadharcard",
                FillWeight = 8
            });

            dgvEmployee.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Blood",
                HeaderText = "Blood Group",
                DataPropertyName = "Blood_Grp",
                FillWeight = 5
            });

            dgvEmployee.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Account",
                HeaderText = "Bank Acc No",
                DataPropertyName = "Account_No",
                FillWeight = 10
            });

            dgvEmployee.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Department",
                HeaderText = "Department",
                DataPropertyName = "DepartmentName",
                FillWeight = 8
            });

            dgvEmployee.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Role",
                HeaderText = "Role",
                DataPropertyName = "RoleName",
                FillWeight = 8
            });

            // ===== EVENTS FOR SEARCH ALIGN =====
            dgvEmployee.ColumnWidthChanged += (s, e) => AlignSearchBoxes();
            dgvEmployee.SizeChanged += (s, e) => AlignSearchBoxes();
            dgvEmployee.Scroll += (s, e) =>
            {
                if (e.ScrollOrientation == ScrollOrientation.HorizontalScroll)
                    AlignSearchBoxes();
            };

            dgvEmployee.ResumeLayout(true);
        }

        // ================= LOAD DATA =================
        private void LoadEmployeeGrid()
        {
            dgvEmployee.SuspendLayout();
            dgvEmployee.Rows.Clear();

            using SqlConnection con = new SqlConnection(DBconection.GetConnectionString());
            using SqlCommand cmd = new SqlCommand(@"
SELECT
    e.Emp_id,
    e.Emp_code,
    e.Emp_Name,
    e.Contact_no,
    e.Alt_Contact,
    e.Email,
    e.Address,
    e.Aadharcard,
    e.Blood_Grp,
    e.Account_No,
    d.DepartmentName,
    r.RoleName
FROM EMPLOYEE_MASTER..Employees e
LEFT JOIN EMPLOYEE_MASTER..Departments d
    ON e.DepartmentId = d.DepartmentId
LEFT JOIN EMPLOYEE_MASTER..Roles r
    ON e.RoleId = r.RoleId
ORDER BY e.Emp_Name
", con);

            con.Open();
            using SqlDataReader dr = cmd.ExecuteReader();

            int sr = 1;
            while (dr.Read())
            {
                dgvEmployee.Rows.Add(
                    dr["Emp_id"],
                    sr++,
                    dr["Emp_code"],
                    dr["Emp_Name"],
                    dr["Contact_no"],
                    dr["Alt_Contact"],
                    dr["Email"],
                    dr["Address"],
                    dr["Aadharcard"],
                    dr["Blood_Grp"],
                    dr["Account_No"],
                    dr["DepartmentName"],
                    dr["RoleName"]
                );
            }

            dgvEmployee.ResumeLayout();

            SyncSearchBoxesWithGrid();
        }

        // ================= SEARCH =================
        private void WireSearchEvents()
        {
            txtSearchEmpCode.TextChanged += ApplySearch;
            txtSearchEmpName.TextChanged += ApplySearch;
            txtSearchContact.TextChanged += ApplySearch;
            txtSearchDepartment.TextChanged += ApplySearch;
            txtSearchRole.TextChanged += ApplySearch;
        }

        private void ApplySearch(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvEmployee.Rows)
            {
                if (row.IsNewRow) continue;

                bool visible = true;

                visible &= Match(row, "EmpCode", txtSearchEmpCode.Text);
                visible &= Match(row, "EmpName", txtSearchEmpName.Text);
                visible &= Match(row, "Contact", txtSearchContact.Text);
                visible &= Match(row, "Department", txtSearchDepartment.Text);
                visible &= Match(row, "Role", txtSearchRole.Text);

                row.Visible = visible;
            }

            ReassignSrNo();
        }

        private bool Match(DataGridViewRow row, string col, string text)
        {
            if (string.IsNullOrWhiteSpace(text)) return true;

            string val = row.Cells[col].Value?.ToString() ?? "";
            return val.IndexOf(text, StringComparison.OrdinalIgnoreCase) >= 0;
        }

        private void ReassignSrNo()
        {
            int sr = 1;
            foreach (DataGridViewRow row in dgvEmployee.Rows)
            {
                if (row.IsNewRow || !row.Visible) continue;
                row.Cells["SrNo"].Value = sr++;
            }
        }

        // ================= SEARCH ALIGN =================
        private void SyncSearchBoxesWithGrid()
        {
            if (dgvEmployee.Columns.Count == 0) return;

            SetSearchBox(txtSearchEmpCode, "EmpCode");
            SetSearchBox(txtSearchEmpName, "EmpName");
            SetSearchBox(txtSearchContact, "Contact");
            SetSearchBox(txtSearchDepartment, "Department");
            SetSearchBox(txtSearchRole, "Role");
        }

        private void SetSearchBox(TextBox txt, string columnName)
        {
            if (!dgvEmployee.Columns.Contains(columnName)) return;

            Rectangle rect = dgvEmployee.GetColumnDisplayRectangle(
                dgvEmployee.Columns[columnName].Index, true);

            txt.Left = rect.Left + dgvEmployee.Left + (SEARCH_GAP / 2);
            txt.Width = rect.Width - SEARCH_GAP;
        }

        // ================= EVENTS =================
        private void AllEmployee_Resize(object sender, EventArgs e)
        {
            SyncSearchBoxesWithGrid();
        }

        private void dgvEmployee_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {
            SyncSearchBoxesWithGrid();
        }

        private void dgvEmployee_Scroll(object sender, ScrollEventArgs e)
        {
            if (e.ScrollOrientation == ScrollOrientation.HorizontalScroll)
                SyncSearchBoxesWithGrid();
        }

        // ================= UTIL =================
        private void EnableDoubleBuffering(Control control)
        {
            typeof(Control)
                .GetProperty("DoubleBuffered",
                    System.Reflection.BindingFlags.NonPublic |
                    System.Reflection.BindingFlags.Instance)
                ?.SetValue(control, true, null);

            foreach (Control child in control.Controls)
                EnableDoubleBuffering(child);
        }

        private void dgvEmployee_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            dgvEmployee.Rows[e.RowIndex].Cells["SrNo"].Value = e.RowIndex + 1;
        }
    }
}
