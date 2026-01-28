using Microsoft.Data.SqlClient;
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace JPSCURA
{
    public partial class Vendors : Form
    {
        // ===== GLOBAL CONTROLS =====
        TextBox txtVendorName, txtVendorEmail, txtMobile, txtAltMobile;
        TextBox txtGST, txtPAN, txtAddress;
        RadioButton rbGST, rbPAN;

        public Vendors()
        {
            InitializeComponent();

            this.WindowState = FormWindowState.Maximized;
            this.BackColor = Color.FromArgb(83, 144, 209);

            BuildVendorUI();
        }

        // ================= UI BUILD =================
        private void BuildVendorUI()
        {
            panelContent.Controls.Clear();
            panelContent.Dock = DockStyle.Fill;
            panelContent.Padding = new Padding(40);
            panelContent.BackColor = Color.FromArgb(83, 144, 209);

            Label lblTitle = new Label
            {
                Text = "ADD VENDOR",
                Font = new Font("Arial", 18, FontStyle.Bold),
                ForeColor = Color.White,
                AutoSize = true
            };
            panelContent.Controls.Add(lblTitle);

            TableLayoutPanel table = new TableLayoutPanel
            {
                ColumnCount = 2,
                Location = new Point(0, 60),
                Width = 900,
                AutoSize = true
            };
            table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50));
            table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50));
            panelContent.Controls.Add(table);

            table.Controls.Add(CreateField("Vendor Name", "Enter Vendor Name", out txtVendorName), 0, 0);
            table.Controls.Add(CreateField("Vendor Email", "Enter Vendor Email", out txtVendorEmail), 1, 0);

            table.Controls.Add(CreateField("Mobile No", "Enter Mobile Number", out txtMobile), 0, 1);
            table.Controls.Add(CreateField("Alt Contact No", "Enter Alternate Number", out txtAltMobile), 1, 1);

            Panel gstPan = CreateGSTPANSection();
            table.Controls.Add(gstPan, 0, 2);
            table.SetColumnSpan(gstPan, 2);

            Panel addr = CreateAddressField();
            table.Controls.Add(addr, 0, 3);
            table.SetColumnSpan(addr, 2);

            Button btnAdd = new Button
            {
                Text = "+ ADD VENDOR",
                Size = new Size(220, 44),
                BackColor = Color.FromArgb(46, 204, 113),
                ForeColor = Color.White,
                Font = new Font("Arial", 12, FontStyle.Bold),
                Cursor = Cursors.Hand,
                FlatStyle = FlatStyle.Flat
            };
            btnAdd.FlatAppearance.BorderSize = 0;
            btnAdd.Top = table.Bottom + 30;
            btnAdd.Left = (table.Width - btnAdd.Width) / 2;

            btnAdd.MouseEnter += (s, e) => btnAdd.BackColor = Color.FromArgb(39, 174, 96);
            btnAdd.MouseLeave += (s, e) => btnAdd.BackColor = Color.FromArgb(46, 204, 113);

            ApplyRoundedButton(btnAdd, 12);
            btnAdd.Click += BtnAdd_Click;

            panelContent.Controls.Add(btnAdd);
        }

        // ================= FIELD =================
        private Panel CreateField(string label, string placeholder, out TextBox txt)
        {
            Panel panel = new Panel { Padding = new Padding(5), Dock = DockStyle.Fill };

            Label lbl = new Label
            {
                Text = label,
                Font = new Font("Arial", 12, FontStyle.Bold),
                ForeColor = Color.White,
                Dock = DockStyle.Top
            };

            txt = new TextBox
            {
                Height = 32,
                Dock = DockStyle.Top,
                Font = new Font("Segoe UI", 10.5f)
            };

            SetPlaceholder(txt, placeholder);

            panel.Controls.Add(txt);
            panel.Controls.Add(lbl);
            return panel;
        }

        // ================= GST / PAN =================
        private Panel CreateGSTPANSection()
        {
            Panel panel = new Panel { Padding = new Padding(5), Dock = DockStyle.Fill };

            Label lbl = new Label
            {
                Text = "GST No / PAN No",
                Font = new Font("Arial", 12, FontStyle.Bold),
                ForeColor = Color.White,
                Dock = DockStyle.Top
            };

            FlowLayoutPanel radios = new FlowLayoutPanel { Height = 30, Dock = DockStyle.Top };

            rbGST = new RadioButton { Text = "GST No", Font = lbl.Font, ForeColor = Color.White };
            rbPAN = new RadioButton { Text = "PAN No", Font = lbl.Font, ForeColor = Color.White };

            radios.Controls.Add(rbGST);
            radios.Controls.Add(rbPAN);

            txtGST = new TextBox
            {
                Visible = false,
                Height = 32,
                Dock = DockStyle.Top,
                Font = new Font("Segoe UI", 10.5f),
                CharacterCasing = CharacterCasing.Upper
            };

            txtPAN = new TextBox
            {
                Visible = false,
                Height = 32,
                Dock = DockStyle.Top,
                Font = new Font("Segoe UI", 10.5f),
                CharacterCasing = CharacterCasing.Upper
            };

            SetPlaceholder(txtGST, "Enter GST No");
            SetPlaceholder(txtPAN, "Enter PAN No");

            rbGST.CheckedChanged += (s, e) =>
            {
                if (rbGST.Checked)
                {
                    txtPAN.Visible = false;
                    txtGST.Visible = true;
                    ResetTextbox(txtGST, "Enter GST No");
                }
            };

            rbPAN.CheckedChanged += (s, e) =>
            {
                if (rbPAN.Checked)
                {
                    txtGST.Visible = false;
                    txtPAN.Visible = true;
                    ResetTextbox(txtPAN, "Enter PAN No");
                }
            };

            panel.Controls.Add(txtPAN);
            panel.Controls.Add(txtGST);
            panel.Controls.Add(radios);
            panel.Controls.Add(lbl);

            return panel;
        }

        // ================= ADDRESS =================
        private Panel CreateAddressField()
        {
            Panel panel = new Panel { Padding = new Padding(5, 10, 5, 10), Dock = DockStyle.Fill };

            Label lbl = new Label
            {
                Text = "Address",
                Font = new Font("Arial", 12, FontStyle.Bold),
                ForeColor = Color.White,
                Dock = DockStyle.Top
            };

            txtAddress = new TextBox
            {
                Multiline = true,
                Height = 60,
                Dock = DockStyle.Top,
                ScrollBars = ScrollBars.None,
                Font = new Font("Segoe UI", 10.5f)
            };

            SetPlaceholder(txtAddress, "Enter Address");

            panel.Controls.Add(txtAddress);
            panel.Controls.Add(lbl);
            return panel;
        }

        // ================= ADD CLICK =================
        private void BtnAdd_Click(object sender, EventArgs e)
        {
            if (txtVendorName.ForeColor == Color.Gray)
            {
                MessageBox.Show("Enter Vendor Name");
                return;
            }

            if (txtMobile.ForeColor == Color.Gray || txtMobile.Text.Length < 10)
            {
                MessageBox.Show("Enter valid Mobile Number");
                return;
            }

            using SqlConnection con = new SqlConnection(DBconection.GetConnectionString());
            using SqlCommand cmd = new SqlCommand(@"
INSERT INTO PURCHASE_MASTER..Vendors
(VendorName, VendorEmail, MobileNo, AltMobileNo, GSTNo, PANNo, Address, AddedBy)
VALUES
(@VendorName, @VendorEmail, @MobileNo, @AltMobileNo, @GSTNo, @PANNo, @Address, @AddedBy)", con);

            cmd.Parameters.AddWithValue("@VendorName", txtVendorName.Text.Trim());
            cmd.Parameters.AddWithValue("@VendorEmail", txtVendorEmail.ForeColor == Color.Gray ? "" : txtVendorEmail.Text.Trim());
            cmd.Parameters.AddWithValue("@MobileNo", txtMobile.Text.Trim());
            cmd.Parameters.AddWithValue("@AltMobileNo", txtAltMobile.ForeColor == Color.Gray ? "" : txtAltMobile.Text.Trim());
            cmd.Parameters.AddWithValue("@GSTNo", rbGST.Checked ? txtGST.Text.Trim() : "");
            cmd.Parameters.AddWithValue("@PANNo", rbPAN.Checked ? txtPAN.Text.Trim() : "");
            cmd.Parameters.AddWithValue("@Address", txtAddress.ForeColor == Color.Gray ? "" : txtAddress.Text.Trim());
            cmd.Parameters.AddWithValue("@AddedBy", Session.Username);

            con.Open();
            cmd.ExecuteNonQuery();

            MessageBox.Show("Vendor added successfully");
            ClearForm();
        }

        // ================= HELPERS =================
        private void ResetTextbox(TextBox txt, string placeholder)
        {
            txt.Text = placeholder;
            txt.ForeColor = Color.Gray;
            txt.Focus();
        }

        private void ClearForm()
        {
            SetPlaceholder(txtVendorName, "Enter Vendor Name");
            SetPlaceholder(txtVendorEmail, "Enter Vendor Email");
            SetPlaceholder(txtMobile, "Enter Mobile Number");
            SetPlaceholder(txtAltMobile, "Enter Alternate Number");
            SetPlaceholder(txtAddress, "Enter Address");

            txtGST.Visible = false;
            txtPAN.Visible = false;
            rbGST.Checked = rbPAN.Checked = false;
        }

        private void SetPlaceholder(TextBox txt, string text)
        {
            txt.Text = text;
            txt.ForeColor = Color.Gray;

            txt.GotFocus += (s, e) =>
            {
                if (txt.Text == text)
                {
                    txt.Text = "";
                    txt.ForeColor = Color.Black;
                }
            };

            txt.LostFocus += (s, e) =>
            {
                if (string.IsNullOrWhiteSpace(txt.Text))
                {
                    txt.Text = text;
                    txt.ForeColor = Color.Gray;
                }
            };
        }

        private void ApplyRoundedButton(Button btn, int radius)
        {
            btn.Resize += (s, e) =>
            {
                var path = new System.Drawing.Drawing2D.GraphicsPath();
                path.AddArc(0, 0, radius, radius, 180, 90);
                path.AddArc(btn.Width - radius, 0, radius, radius, 270, 90);
                path.AddArc(btn.Width - radius, btn.Height - radius, radius, radius, 0, 90);
                path.AddArc(0, btn.Height - radius, radius, radius, 90, 90);
                path.CloseFigure();
                btn.Region = new Region(path);
            };
        }
    }
}
