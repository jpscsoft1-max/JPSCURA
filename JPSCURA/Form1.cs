using ClosedXML.Excel;
using DocumentFormat.OpenXml.Bibliography;
using DocumentFormat.OpenXml.Office2013.Drawing.ChartStyle;
using DocumentFormat.OpenXml.Vml;
using Microsoft.Data.SqlClient;
using Microsoft.VisualBasic.Logging;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace JPSCURA
{
    public partial class Home : Form
    {
        // ================= STATE =================
        private Form activeForm = null;
        private Button activeTopButton = null;
        private bool isLogout = false;



        // ================= COLORS =================
        private Color menuNormalColor = Color.Transparent;
        private Color menuHoverColor = Color.FromArgb(90, 130, 255);   // hover (clear visible)
        private Color menuActiveColor = Color.FromArgb(25, 45, 150);  // active (dark)

        private Color menuTextNormal = Color.WhiteSmoke;
        private Color menuTextActive = Color.White;

        // ================= INIT =================
        public Home()
        {
            InitializeComponent();

            this.Load += Home_Load;
            this.Resize += (s, e) => CenterLogo();
            this.FormClosing += Home_FormClosing;
            this.DoubleBuffered = true;
            panelContent.DoubleBuffered(true);
            pnlLoading.DoubleBuffered(true);

        }






        public async Task RunWithLoadingAsync(Func<Task> work, int minDelayMs = 2000)

        {
            // 1️⃣ SHOW LOADER IMMEDIATELY
            pnlLoading.Visible = true;
            pnlLoading.BringToFront();
            DisableAllButtons();

            // force one UI paint
            await Task.Yield();

            // 2️⃣ MINIMUM LOADER TIME
            await Task.Delay(minDelayMs); // you can change to 5000 if needed

            // 3️⃣ RUN UI WORK (ON UI THREAD)
            if (work != null)
                await work();

            // 4️⃣ HIDE LOADER
            pnlLoading.Visible = false;
            EnableAllButtons();
        }






        private void DisableAllButtons()
        {
            foreach (Control c in panelTopMenu.Controls)
            {
                if (c is Button btn)
                    btn.Enabled = false;
            }

            panelSubMenu.Enabled = false;
            //panelContent.Enabled = false;
        }

        private void EnableAllButtons()
        {
            foreach (Control c in panelTopMenu.Controls)
            {
                if (c is Button btn)
                    btn.Enabled = true;
            }

            panelSubMenu.Enabled = true;
            panelContent.Enabled = true;
        }

        private void CenterLoaderBox()
        {
            pnlLoaderBox.Left =
                (pnlLoading.ClientSize.Width - pnlLoaderBox.Width) / 2;

            pnlLoaderBox.Top =
                (pnlLoading.ClientSize.Height - pnlLoaderBox.Height) / 2;
        }



        private void Home_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (activeForm != null)
                {
                    activeForm.Close();
                    activeForm.Dispose();
                }
            }
            catch { }

            // 🔴 IF user clicked ❌ (not logout)
            if (!isLogout)
            {
                Application.Exit();
                Environment.Exit(0); // 🔥 hard kill process
            }
        }

        private async void Home_Load(object sender, EventArgs e)
        {
            HookTopMenuEvents();
            SetActiveTopMenu(btnHome);
            panelSubMenu.Visible = false;
            ShowHome();

            ApplyMainModuleAccess();
            SetLoggedInUserInfo();

            ApplyButtonAccess();
            SetLoggedInUserInfo();
            btnClear.Visible = false;


            await Task.Delay(50);   // wait one paint cycle
            this.Opacity = 1;       // show smoothly
        }




        // ================= MENU HOVER + ACTIVE =================
        private void HookTopMenuEvents()
        {
            Button[] topButtons =
            {
                btnHome, btnDepartment, btnWorkorder, btnPurchasing,
                btnSales1, btnInventory, btnFinance,
                btnEmployees, btnCompanyinfo
            };

            foreach (Button btn in topButtons)
            {
                btn.MouseEnter += TopMenu_MouseEnter;
                btn.MouseLeave += TopMenu_MouseLeave;
            }
        }

        //Access using roles//

        private void ApplyMainModuleAccess()
        {
            // 1. Hide all top buttons
            foreach (Control c in panelTopMenu.Controls)
            {
                if (c is Button btn)
                    btn.Visible = false;
            }

            // 2. DB se allowed modules lao
            using (SqlConnection con = new SqlConnection(DBconection.GetConnectionString()))
            using (SqlCommand cmd = new SqlCommand(@"
        SELECT M.ModuleName
        FROM EMPLOYEE_MASTER..Modules M
        JOIN EMPLOYEE_MASTER..RoleModulePermissions RMP
            ON M.ModuleId = RMP.ModuleId
        WHERE RMP.RoleId = @RoleId
          AND M.IsActive = 1
        ORDER BY M.ModuleOrder
    ", con))
            {
                cmd.Parameters.AddWithValue("@RoleId", Session.RoleId);
                con.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        string name = dr["ModuleName"].ToString();

                        if (name == "Home") btnHome.Visible = true;
                        else if (name == "Department") btnDepartment.Visible = true;
                        else if (name == "Workorder") btnWorkorder.Visible = true;
                        else if (name == "Purchasing") btnPurchasing.Visible = true;
                        else if (name == "Sales") btnSales1.Visible = true;
                        else if (name == "Inventory") btnInventory.Visible = true;
                        else if (name == "Finance") btnFinance.Visible = true;
                        else if (name == "Employees") btnEmployees.Visible = true;
                        else if (name == "GLD") btnLogindetails.Visible = true;
                        else if (name == "Company Info") btnCompanyinfo.Visible = true;
                    }
                }
            }

            ReArrangeTopMenuButtons();
        }

        private void ReArrangeTopMenuButtons()
        {
            // 🔥 CORRECT ORDER (same as DB ModuleOrder should be)
            string[] correctOrder =
            {
        "btnHome",
        "btnDepartment",
        "btnWorkorder",
        "btnPurchasing",
        "btnSales1",
        "btnInventory",
        "btnFinance",
        "btnEmployees",
        "btnLogindetails",
        "btnCompanyinfo"
    };

            int startX = 10;
            int gap = 4;
            int y = btnHome.Top;

            // Loop through defined order
            foreach (string btnName in correctOrder)
            {
                var controls = panelTopMenu.Controls.Find(btnName, false);

                if (controls.Length > 0 && controls[0] is Button btn && btn.Visible)
                {
                    btn.Location = new Point(startX, y);
                    startX += btn.Width + gap;
                }
            }
        }

        // 🔥 GENERIC SUB MODULE ACCESS (WITH DEBUG)
        private void ApplySubModuleAccess(string moduleName, Panel subMenuPanel)
        {
            try
            {
                // 1️⃣ Hide all buttons
                foreach (Control c in subMenuPanel.Controls)
                {
                    if (c is Button btn)
                        btn.Visible = false;
                }

                // 🔥 Store ordered buttons
                List<Button> orderedButtons = new List<Button>();

                // 2️⃣ DB se allowed submodules WITH ORDER
                using (SqlConnection con = new SqlConnection(DBconection.GetConnectionString()))
                using (SqlCommand cmd = new SqlCommand(@"
            SELECT SM.SubModuleName
            FROM EMPLOYEE_MASTER..SubModules SM
            INNER JOIN EMPLOYEE_MASTER..RoleSubModulePermissions RSP
                ON SM.SubModuleId = RSP.SubModuleId
            INNER JOIN EMPLOYEE_MASTER..Modules M
                ON SM.ModuleId = M.ModuleId
            WHERE RSP.RoleId = @RoleId
              AND M.ModuleName = @ModuleName
              AND SM.IsActive = 1
            ORDER BY SM.SubModuleOrder
        ", con))
                {
                    cmd.Parameters.AddWithValue("@RoleId", Session.RoleId);
                    cmd.Parameters.AddWithValue("@ModuleName", moduleName);
                    con.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            string allowedSub = dr["SubModuleName"].ToString();

                            foreach (Control c in subMenuPanel.Controls)
                            {
                                if (c is Button btn && btn.Tag?.ToString() == allowedSub)
                                {
                                    btn.Visible = true;
                                    orderedButtons.Add(btn);
                                    break;
                                }
                            }
                        }
                    }
                }

                //  RE-ARRANGE IN ORDER
                ReArrangeSubMenuButtons(subMenuPanel, orderedButtons);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ReArrangeSubMenuButtons(Panel subMenuPanel, List<Button> orderedButtons)
        {
            if (orderedButtons.Count == 0) return;

            int startX = 10;
            int startY = 10;
            int gap = 5;

            // Detect horizontal vs vertical layout
            bool isHorizontal = subMenuPanel.Width > subMenuPanel.Height;

            if (isHorizontal)
            {
                // Horizontal arrangement
                foreach (Button btn in orderedButtons)
                {
                    btn.Location = new Point(startX, startY);
                    startX += btn.Width + gap;
                }
            }
            else
            {
                // Vertical arrangement
                foreach (Button btn in orderedButtons)
                {
                    btn.Location = new Point(startX, startY);
                    startY += btn.Height + gap;
                }
            }
        }


        private void SetLoggedInUserInfo()
        {
            // Safety check
            if (string.IsNullOrWhiteSpace(Session.RealName))
                return;

            btnUserInfo.Text = "👤 " + Session.RealName;
            btnUserInfo.TextAlign = ContentAlignment.MiddleCenter;
            btnUserInfo.ImageAlign = ContentAlignment.MiddleLeft;

            // Optional polish
            btnUserInfo.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
        }

        private void SetActiveTopMenu(Button btn)
        {
            if (activeTopButton != null)
            {
                activeTopButton.BackColor = menuNormalColor;
                activeTopButton.ForeColor = menuTextNormal;
                activeTopButton.Font = new Font(activeTopButton.Font, FontStyle.Regular);
            }

            activeTopButton = btn;
            activeTopButton.BackColor = menuActiveColor;
            activeTopButton.ForeColor = menuTextActive;
            activeTopButton.Font = new Font(activeTopButton.Font, FontStyle.Bold);
        }

        private void TopMenu_MouseEnter(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn != activeTopButton)
            {
                btn.BackColor = menuHoverColor;
                btn.ForeColor = Color.White;
            }
        }

        private void TopMenu_MouseLeave(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn != activeTopButton)
            {
                btn.BackColor = menuNormalColor;
                btn.ForeColor = menuTextNormal;
            }
        }

        // ================= HOME =================
        private void ShowHome()
        {
            if (activeForm != null)
            {
                activeForm.Close();
                activeForm = null;
            }

            RemoveOnlyChildForms();

            picJPSCURA.Visible = true;
            picJPSCURA.BringToFront();
            CenterLogo();
        }

        private void RemoveOnlyChildForms()
        {
            for (int i = panelContent.Controls.Count - 1; i >= 0; i--)
            {
                Control c = panelContent.Controls[i];
                if (c is Form)
                {
                    c.Dispose();
                    panelContent.Controls.Remove(c);
                }
            }
        }

        // OPEN FORM 
        private async Task OpenFormInPanelAsync(Form childForm)
        {
            picJPSCURA.Visible = false;
            RemoveOnlyChildForms();
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;

            panelContent.Controls.Add(childForm);
            childForm.Show();

            await Task.Yield();
        }










        // ================= CENTER LOGO =================
        private void CenterLogo()
        {
            if (!picJPSCURA.Visible) return;

            picJPSCURA.Left = (panelContent.Width - picJPSCURA.Width) / 2;
            picJPSCURA.Top = (panelContent.Height - picJPSCURA.Height) / 2;
        }

        // ================= TOP MENU CLICKS =================
        private void btnHome_Click(object sender, EventArgs e)
        {
            SetActiveTopMenu(btnHome);
            panelSubMenu.Controls.Clear();
            panelSubMenu.Visible = false;
            ShowHome();
        }

        private void btnDepartment_Click(object sender, EventArgs e)
        {
            SetActiveTopMenu(btnDepartment);
            panelSubMenu.Controls.Clear();
            panelDeptsubmenu.Visible = true;
            panelSubMenu.Visible = true;
            panelSubMenu.Controls.Add(panelDeptsubmenu);

            // 🔥 Apply submodule access
            ApplySubModuleAccess("Department", panelDeptsubmenu);
            ShowHome();
        }

        private void btnWorkorder_Click(object sender, EventArgs e)
        {
            SetActiveTopMenu(btnWorkorder);
            panelSubMenu.Controls.Clear();
            panelWorkOrderSubMenu.Visible = true;
            panelSubMenu.Visible = true;
            panelSubMenu.Controls.Add(panelWorkOrderSubMenu);

            // 🔥 Apply submodule access
            ApplySubModuleAccess("Workorder", panelWorkOrderSubMenu);
            ShowHome();
        }

        private void btnPurchasing_Click(object sender, EventArgs e)
        {
            SetActiveTopMenu(btnPurchasing);
            panelSubMenu.Controls.Clear();
            panelPurchasingSubMenu.Visible = true;
            panelSubMenu.Visible = true;
            panelSubMenu.Controls.Add(panelPurchasingSubMenu);

            // 🔥 Apply submodule access
            ApplySubModuleAccess("Purchasing", panelPurchasingSubMenu);
            ShowHome();
        }

        private void btnSales1_Click(object sender, EventArgs e)
        {
            SetActiveTopMenu(btnSales1);
            panelSubMenu.Controls.Clear();
            panelSalesSubMenu.Visible = true;
            panelSubMenu.Visible = true;
            panelSubMenu.Controls.Add(panelSalesSubMenu);

            // 🔥 Apply submodule access
            ApplySubModuleAccess("Sales", panelSalesSubMenu);
            ShowHome();
        }

        private void btnInventory_Click(object sender, EventArgs e)
        {
            SetActiveTopMenu(btnInventory);
            panelSubMenu.Controls.Clear();
            panelInventorySubMenu.Visible = true;
            panelSubMenu.Visible = true;
            panelSubMenu.Controls.Add(panelInventorySubMenu);

            // 🔥 Apply submodule access
            ApplySubModuleAccess("Inventory", panelInventorySubMenu);
            btnClear.Visible = false;
            ShowHome();
        }

        private void btnFinance_Click(object sender, EventArgs e)
        {
            SetActiveTopMenu(btnFinance);
            panelSubMenu.Controls.Clear();
            panelEMPSubMenu.Visible = false;

            panelFinanceSubMenu.Visible = true;
            panelSubMenu.Visible = true;
            panelSubMenu.Controls.Add(panelFinanceSubMenu);

            // 🔥 Apply submodule access
            ApplySubModuleAccess("Finance", panelFinanceSubMenu);
            ShowHome();
        }

        private void btnEmployees_Click(object sender, EventArgs e)
        {
            SetActiveTopMenu(btnEmployees);
            panelSubMenu.Controls.Clear();
            panelSubMenuUser.Visible = false;
            panelEMPSubMenu.Visible = true;
            panelSubMenu.Visible = true;
            panelSubMenu.Controls.Add(panelEMPSubMenu);

            // 🔥 Apply submodule access
            ApplySubModuleAccess("Employees", panelEMPSubMenu);
            ShowHome();
        }

        // ================= SUB MENU FORMS =================
        private async void btnAddorder_Click(object sender, EventArgs e)
        {
            await OpenFormInPanelAsync(new AddOrderForm());
            //await ShowLoadingAsync();
            //HideLoading();
        }

        private async void btnAddorderIcon_Click(object sender, EventArgs e)
        {
            await OpenFormInPanelAsync(new AddOrderForm());
        }

        private async void btnVendors_Click(object sender, EventArgs e)
        {
            await OpenFormInPanelAsync(new Vendors());
        }

        private async void btnVendoricon_Click(object sender, EventArgs e)
        {
            await OpenFormInPanelAsync(new Vendors());
        }

        private async void btnCustomers_Click(object sender, EventArgs e)
        {
            await OpenFormInPanelAsync(new Customer());
        }

        private async void btnCustomericon_Click(object sender, EventArgs e)
        {
            await OpenFormInPanelAsync(new Customer());
        }

        private async void btnAddMaterial_Click(object sender, EventArgs e)
        {
            await RunWithLoadingAsync(async () =>
            {
                await OpenFormInPanelAsync(new Material());
                btnClear.Visible = false;
            });
        }

        private async void btnAddMaterialIcon_Click(object sender, EventArgs e)
        {
            await RunWithLoadingAsync(async () =>
            {
                await OpenFormInPanelAsync(new Material());
                btnClear.Visible = false;
            });
        }



        private async void btnLogindetails_Click(object sender, EventArgs e)
        {
            panelSubMenu.Controls.Clear();
            panelSubMenu.Visible = false;
            SetActiveTopMenu(btnLogindetails);
            ShowHome();
        }
            SetActiveTopMenu(btnLogindetails);
            panelSubMenu.Controls.Clear();
            panelSubMenuUser.Visible = false;
            panelEMPSubMenu.Visible = false;
            panelSubMenu.Visible = false; // 🔥 SHOW PANEL
            //panelSubMenu.Controls.Add(panelEMPSubMenu);
            ShowHome();
            await RunWithLoadingAsync(async () =>
            {
                // 🔥 DB + FORM LOAD happens HERE
                await OpenFormInPanelAsync(new GLD());
            });
            }

        private void btnCompanyinfo_Click(object sender, EventArgs e)
        {
            panelSubMenu.Controls.Clear();
            panelSubMenu.Visible = false;
            SetActiveTopMenu(btnCompanyinfo);
            ShowHome();
        }

        private async void btnAllMaterials_Click(object sender, EventArgs e)
        {
            await RunWithLoadingAsync(async () =>
            {
                await OpenFormInPanelAsync(new AllMaterial());
                btnClear.Visible = true;

            });
        }

        private async void btnAllMaterialIcon_Click(object sender, EventArgs e)
        {
            await RunWithLoadingAsync(async () =>
            {
                await OpenFormInPanelAsync(new AllMaterial());
                btnClear.Visible = true;

            });
        }

        private async void btnAddEmp_Click(object sender, EventArgs e)
        {
            await OpenFormInPanelAsync(new AddEmp());
            await RunWithLoadingAsync(async () =>
            {
                await OpenFormInPanelAsync(new AddEmp());

            });
        }

        private async void picEmp_Click(object sender, EventArgs e)
        {
            await OpenFormInPanelAsync(new AddEmp());
            await RunWithLoadingAsync(async () =>
            {
                await OpenFormInPanelAsync(new AddEmp());

            });
        }

        private void pnlLoading_Resize(object sender, EventArgs e)
        {
            CenterLoaderBox();
        }

        private void btnBankPayVoucher_Click(object sender, EventArgs e)
        {

        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            if (activeForm is AllMaterial allMaterial)
            {
                allMaterial.ClearAllMaterialSelection();
            }
        }

        private async void btnAllEmp_Click(object sender, EventArgs e)
        {
            await RunWithLoadingAsync(async () =>
            {
                await OpenFormInPanelAsync(new AllEmployee());

            });
        }

        private void btnUserInfo_Click(object sender, EventArgs e)
        {
            SetActiveTopMenu(btnUserInfo);
            panelSubMenu.Controls.Clear();
            panelSubMenuUser.Visible = true;
            panelSubMenu.Visible = true; // 🔥 SHOW PANEL
            panelSubMenu.Controls.Add(panelSubMenuUser);
            ShowHome();
        }

        private async void btnEditInfo_Click(object sender, EventArgs e)
        {

            await OpenFormInPanelAsync(new EditInfo());
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            isLogout = true; // 👈 VERY IMPORTANT

            // clear session
            Session.UserId = 0;
            Session.RealName = "";
            Session.Role = "";

            LoginForm login = new LoginForm();

            login.FormClosed += (s, args) =>
            {
                Application.Exit(); // exit when login closes
            };

            login.Show();
            this.Close(); // close Home
        }


    }
}
