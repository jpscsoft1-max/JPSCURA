using ClosedXML.Excel;
using DocumentFormat.OpenXml.Bibliography;
using DocumentFormat.OpenXml.Office2013.Drawing.ChartStyle;
using DocumentFormat.OpenXml.Vml;
using Microsoft.Data.SqlClient;
using WinFormsTextBox = System.Windows.Forms.TextBox;
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

        // ================= RESIZE STATE =================
        private const int RESIZE_HANDLE_SIZE = 10;
        private bool isResizing = false;
        private Point resizeStart;
        private Size resizeSizeStart;
        private ResizeDirection resizeDir;

        private enum ResizeDirection
        {
            None, Left, Right, Top, Bottom,
            TopLeft, TopRight, BottomLeft, BottomRight
        }

        // ================= INIT =================
        public Home()
        {
            InitializeComponent();

            // Title bar buttons anchor
            btnhomeclose.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnminimax.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnhideminimize.Anchor = AnchorStyles.Top | AnchorStyles.Right;

            this.Load += Home_Load;
            this.Resize += Home_Resize;
            this.FormClosing += Home_FormClosing;
            this.DoubleBuffered = true;

            panelContent.DoubleBuffered(true);
            pnlLoading.DoubleBuffered(true);

            // Attach resize events
            AttachResizeEventsRecursively(this);
        }

        // 🔥 FIX: OnHandleCreated override for proper maximize behavior
        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);

            // Get working area (excludes taskbar)
            Screen screen = Screen.FromHandle(this.Handle);
            System.Drawing.Rectangle workingArea = screen.WorkingArea;

            // Set bounds BEFORE maximizing
            this.MaximizedBounds = workingArea;

            // Set location and size explicitly to fill working area
            this.Location = workingArea.Location;
            this.Size = workingArea.Size;

            // Start in NORMAL state (not maximized) but fill working area
            this.WindowState = FormWindowState.Normal;
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
            await Task.Delay(minDelayMs);

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
            pnlLoaderBox.Left = (pnlLoading.ClientSize.Width - pnlLoaderBox.Width) / 2;
            pnlLoaderBox.Top = (pnlLoading.ClientSize.Height - pnlLoaderBox.Height) / 2;
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
                Environment.Exit(0);
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
            btnClear.Visible = false;

            await Task.Delay(50);
            this.Opacity = 1;
        }

        private void Home_Resize(object sender, EventArgs e)
        {
            UpdateMaximizeButtonIcon();
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
            string[] correctOrder =
            {
                "btnHome", "btnDepartment", "btnWorkorder", "btnPurchasing",
                "btnSales1", "btnInventory", "btnFinance", "btnEmployees",
                "btnLogindetails", "btnCompanyinfo"
            };

            int startX = 10;
            int gap = 4;
            int y = btnHome.Top;

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

        private void ApplySubModuleAccess(string moduleName, Panel subMenuPanel)
        {
            try
            {
                foreach (Control c in subMenuPanel.Controls)
                {
                    if (c is Button btn)
                        btn.Visible = false;
                }

                List<Button> orderedButtons = new List<Button>();

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

            bool isHorizontal = subMenuPanel.Width > subMenuPanel.Height;

            if (isHorizontal)
            {
                foreach (Button btn in orderedButtons)
                {
                    btn.Location = new Point(startX, startY);
                    startX += btn.Width + gap;
                }
            }
            else
            {
                foreach (Button btn in orderedButtons)
                {
                    btn.Location = new Point(startX, startY);
                    startY += btn.Height + gap;
                }
            }
        }

        private void SetLoggedInUserInfo()
        {
            if (string.IsNullOrWhiteSpace(Session.RealName))
                return;

            btnUserInfo.Text = "👤 " + Session.RealName;
            btnUserInfo.TextAlign = ContentAlignment.MiddleCenter;
            btnUserInfo.ImageAlign = ContentAlignment.MiddleLeft;
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
            ApplySubModuleAccess("Employees", panelEMPSubMenu);
            ShowHome();
        }

        // ================= SUB MENU FORMS =================
        private async void btnAddorder_Click(object sender, EventArgs e)
        {
            await OpenFormInPanelAsync(new AddOrderForm());
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

            await RunWithLoadingAsync(async () =>
            {
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
            await RunWithLoadingAsync(async () =>
            {
                await OpenFormInPanelAsync(new AddEmp());
            });
        }

        private async void picEmp_Click(object sender, EventArgs e)
        {
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
            panelSubMenu.Visible = true;
            panelSubMenu.Controls.Add(panelSubMenuUser);
            ShowHome();
        }

        private async void btnEditInfo_Click(object sender, EventArgs e)
        {
            await OpenFormInPanelAsync(new EditInfo());
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            isLogout = true;

            Session.UserId = 0;
            Session.RealName = "";
            Session.Role = "";

            LoginForm login = new LoginForm();

            login.FormClosed += (s, args) =>
            {
                Application.Exit();
            };

            login.Show();
            this.Close();
        }

        private void btnhomeclose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnhideminimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        // ================= MAXIMIZE/RESTORE LOGIC =================
        private void UpdateMaximizeButtonIcon()
        {
            if (IsWindowMaximized())
            {
                btnminimax.Image = Properties.Resources.maximize1;
                btnminimax.Tag = "restore";
            }
            else
            {
                btnminimax.Image = Properties.Resources.maximize11;
                btnminimax.Tag = "maximize";
            }
        }

        private bool IsWindowMaximized()
        {
            Screen screen = Screen.FromHandle(this.Handle);
            return this.Location == screen.WorkingArea.Location &&
                   this.Size == screen.WorkingArea.Size;
        }

        private void btnminimax_Click(object sender, EventArgs e)
        {
            Screen screen = Screen.FromHandle(this.Handle);
            System.Drawing.Rectangle workingArea = screen.WorkingArea;

            if (IsWindowMaximized())
            {
                // Switch to windowed mode
                this.FormBorderStyle = FormBorderStyle.None;

                int windowWidth = (int)(screen.Bounds.Width * 0.75);
                int windowHeight = (int)(screen.Bounds.Height * 0.75);
                int windowX = (screen.Bounds.Width - windowWidth) / 2;
                int windowY = (screen.Bounds.Height - windowHeight) / 2;

                this.Location = new Point(windowX, windowY);
                this.Size = new Size(windowWidth, windowHeight);
            }
            else
            {
                // Switch to maximized mode
                this.FormBorderStyle = FormBorderStyle.None;
                this.Location = workingArea.Location;
                this.Size = workingArea.Size;
            }
        }

 
        // ================= RECURSIVE EVENT ATTACHMENT =================
        private void AttachResizeEventsRecursively(Control control)
        {
            // 🔥 SKIP: Title bar buttons specifically by NAME
            if (control == btnhomeclose ||
                control == btnminimax ||
                control == btnhideminimize ||
                control == btnUserInfo)
            {
                // Don't attach events to these buttons
                return;
            }

            // Attach events to current control
            control.MouseDown += Home_MouseDown;
            control.MouseMove += Home_MouseMove;
            control.MouseUp += Home_MouseUp;

            foreach (Control child in control.Controls)
            {
                // Recursively attach to children
                AttachResizeEventsRecursively(child);
            }
        }

        // ================= CUSTOM RESIZE LOGIC =================
        private void Home_MouseMove(object sender, MouseEventArgs e)
        {
            // 🔥 Extra safety: Skip if source is a button
            Control sourceControl = (Control)sender;
            if (sourceControl is Button)
            {
                this.Cursor = Cursors.Default;
                return;
            }

            if (IsWindowMaximized())
            {
                this.Cursor = Cursors.Default;
                return;
            }

            Point formPoint = this.PointToClient(sourceControl.PointToScreen(e.Location));
            ResizeDirection dir = GetResizeDirection(formPoint);

            switch (dir)
            {
                case ResizeDirection.Left:
                case ResizeDirection.Right:
                    this.Cursor = Cursors.SizeWE;
                    break;
                case ResizeDirection.Top:
                case ResizeDirection.Bottom:
                    this.Cursor = Cursors.SizeNS;
                    break;
                case ResizeDirection.TopLeft:
                case ResizeDirection.BottomRight:
                    this.Cursor = Cursors.SizeNWSE;
                    break;
                case ResizeDirection.TopRight:
                case ResizeDirection.BottomLeft:
                    this.Cursor = Cursors.SizeNESW;
                    break;
                default:
                    this.Cursor = Cursors.Default;
                    break;
            }

            if (isResizing)
            {
                ResizeForm(formPoint);
            }
        }

        private void Home_MouseDown(object sender, MouseEventArgs e)
        {
            if (IsWindowMaximized()) return;

            Control sourceControl = (Control)sender;
            Point formPoint = this.PointToClient(sourceControl.PointToScreen(e.Location));

            resizeDir = GetResizeDirection(formPoint);

            if (resizeDir != ResizeDirection.None)
            {
                isResizing = true;
                resizeStart = formPoint;
                resizeSizeStart = this.Size;
            }
        }

        private void Home_MouseUp(object sender, MouseEventArgs e)
        {
            isResizing = false;
            resizeDir = ResizeDirection.None;
        }

        private ResizeDirection GetResizeDirection(Point point)
        {
            int x = point.X;
            int y = point.Y;
            int w = this.Width;
            int h = this.Height;

            // Corners (priority)
            if (x <= RESIZE_HANDLE_SIZE && y <= RESIZE_HANDLE_SIZE)
                return ResizeDirection.TopLeft;
            if (x >= w - RESIZE_HANDLE_SIZE && y <= RESIZE_HANDLE_SIZE)
                return ResizeDirection.TopRight;
            if (x <= RESIZE_HANDLE_SIZE && y >= h - RESIZE_HANDLE_SIZE)
                return ResizeDirection.BottomLeft;
            if (x >= w - RESIZE_HANDLE_SIZE && y >= h - RESIZE_HANDLE_SIZE)
                return ResizeDirection.BottomRight;

            // Edges
            if (x <= RESIZE_HANDLE_SIZE)
                return ResizeDirection.Left;
            if (x >= w - RESIZE_HANDLE_SIZE)
                return ResizeDirection.Right;
            if (y <= RESIZE_HANDLE_SIZE)
                return ResizeDirection.Top;
            if (y >= h - RESIZE_HANDLE_SIZE)
                return ResizeDirection.Bottom;

            return ResizeDirection.None;
        }

        private void ResizeForm(Point currentPoint)
        {
            int deltaX = currentPoint.X - resizeStart.X;
            int deltaY = currentPoint.Y - resizeStart.Y;

            int newWidth = resizeSizeStart.Width;
            int newHeight = resizeSizeStart.Height;
            int newX = this.Location.X;
            int newY = this.Location.Y;

            int minWidth = 800;
            int minHeight = 600;

            switch (resizeDir)
            {
                case ResizeDirection.Right:
                    newWidth = Math.Max(minWidth, resizeSizeStart.Width + deltaX);
                    break;

                case ResizeDirection.Left:
                    newWidth = Math.Max(minWidth, resizeSizeStart.Width - deltaX);
                    if (newWidth > minWidth)
                        newX = this.Location.X + deltaX;
                    break;

                case ResizeDirection.Bottom:
                    newHeight = Math.Max(minHeight, resizeSizeStart.Height + deltaY);
                    break;

                case ResizeDirection.Top:
                    newHeight = Math.Max(minHeight, resizeSizeStart.Height - deltaY);
                    if (newHeight > minHeight)
                        newY = this.Location.Y + deltaY;
                    break;

                case ResizeDirection.BottomRight:
                    newWidth = Math.Max(minWidth, resizeSizeStart.Width + deltaX);
                    newHeight = Math.Max(minHeight, resizeSizeStart.Height + deltaY);
                    break;

                case ResizeDirection.BottomLeft:
                    newWidth = Math.Max(minWidth, resizeSizeStart.Width - deltaX);
                    newHeight = Math.Max(minHeight, resizeSizeStart.Height + deltaY);
                    if (newWidth > minWidth)
                        newX = this.Location.X + deltaX;
                    break;

                case ResizeDirection.TopRight:
                    newWidth = Math.Max(minWidth, resizeSizeStart.Width + deltaX);
                    newHeight = Math.Max(minHeight, resizeSizeStart.Height - deltaY);
                    if (newHeight > minHeight)
                        newY = this.Location.Y + deltaY;
                    break;

                case ResizeDirection.TopLeft:
                    newWidth = Math.Max(minWidth, resizeSizeStart.Width - deltaX);
                    newHeight = Math.Max(minHeight, resizeSizeStart.Height - deltaY);
                    if (newWidth > minWidth)
                        newX = this.Location.X + deltaX;
                    if (newHeight > minHeight)
                        newY = this.Location.Y + deltaY;
                    break;
            }

            this.Location = new Point(newX, newY);
            this.Size = new Size(newWidth, newHeight);
        }

        private async void btnRawMaterials_Click(object sender, EventArgs e)
        {
            await RunWithLoadingAsync(async () =>
            {
                await OpenFormInPanelAsync(new RawMaterial());
                btnClear.Visible = false;
               
            });
        }
    }
}