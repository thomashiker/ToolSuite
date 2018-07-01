using System;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Text;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Xml.Linq;

using CSharpWin;
using MetroFramework;
using MetroFramework.Forms;

using WeifenLuo.WinFormsUI.Docking;
using WeifenLuo.WinFormsUI.ThemeVS2015;


namespace ToolSuite
{
    public partial class MainForm : MetroCForm
    {
        private string notepadApp = "notepad++.exe";
        private bool m_bSaveLayout = true;
        private DeserializeDockContent m_deserializeDockContent;
        private DummySolutionExplorer m_solutionExplorer;
        private DummyPropertyWindow m_propertyWindow;
        private DummyOutputWindow m_outputWindow;
        private bool _showSplash = true;
        private SplashScreen _splashScreen;
        private NewForm newform = new NewForm();
        //private NotifyForm notifyForm = new NotifyForm();
        private SearchForm searchForm;
        private readonly VS2015ThemeBase DefaultTheme = new BlueTheme();
        private AppearanceSetting appearanceSetting;
        //private CustomStyle customStyle = new CustomStyle();
        private string _defaultXmlTheme = null;


        public string DefaultXmlTheme
        {
            get { return _defaultXmlTheme; }
            set { _defaultXmlTheme = value; }
        }

        public CustomStyle MyStyle
        {
            get { return customStyle; }
            set
            {
                customStyle.Clone(value);
                UpdateDockContentColor();
            }
        }

        public MainForm()
        {
            InitializeComponent();
            AutoScaleMode = AutoScaleMode.Dpi;

            searchForm = new SearchForm(this);

            ModifyTheme(DefaultTheme, Color.White);

            MyStyle.GridSelectionColor = DefaultTheme.ColorPalette.MainWindowStatusBarDefault.Background;
            DefaultXmlTheme = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "theme.xml");
            MyStyle.LoadTheme(DefaultXmlTheme);

            ModifyStyle(DefaultTheme, MyStyle.StyleColor);
            ModifyTheme(DefaultTheme, MyStyle.ThemeColor);

            SetSplashScreen();
            CreateStandardControls();

            mainMenu.Visible = false;

            m_deserializeDockContent = new DeserializeDockContent(GetContentFromPersistString);

            SetSchema(DefaultTheme);
        }

        public ThemeBase DockPanelTheme
        {
            get { return this.dockPanel.Theme; }
            set { this.dockPanel.Theme = value; }
        }

        #region Methods

        private IDockContent FindDocument(string text)
        {
            if (dockPanel.DocumentStyle == DocumentStyle.SystemMdi)
            {
                foreach (Form form in MdiChildren)
                    if (form.Text == text)
                        return form as IDockContent;

                return null;
            }
            else
            {
                foreach (IDockContent content in dockPanel.Documents)
                    if (content.DockHandler.TabText == text)
                        return content;

                return null;
            }
        }

        /*private DummyDoc CreateNewDocument(string text)
        {
            DummyDoc dummyDoc = new DummyDoc();
            dummyDoc.Text = text;
            return dummyDoc;
        }*/

        private void CloseAllDocuments()
        {
            if (dockPanel.DocumentStyle == DocumentStyle.SystemMdi)
            {
                foreach (Form form in MdiChildren)
                    form.Close();
            }
            else
            {
                foreach (IDockContent document in dockPanel.DocumentsToArray())
                {
                    // IMPORANT: dispose all panes.
                    document.DockHandler.DockPanel = null;
                    document.DockHandler.Close();
                }
            }
        }

        private IDockContent GetContentFromPersistString(string persistString)
        {
            if (persistString == typeof(DummySolutionExplorer).ToString())
                return m_solutionExplorer;
            else if (persistString == typeof(DummyPropertyWindow).ToString())
                return m_propertyWindow;
            else if (persistString == typeof(DummyOutputWindow).ToString())
                return m_outputWindow;
            else
            {
                // DummyDoc overrides GetPersistString to add extra information into persistString.
                // Any DockContent may override this value to add any needed information for deserialization.

                /* string[] parsedStrings = persistString.Split(new char[] { ',' });
                 if (parsedStrings.Length != 3)
                     return null;

                 if (parsedStrings[0] != typeof(DummyDoc).ToString())
                     return null;

                 DummyDoc dummyDoc = new DummyDoc();
                 //if (parsedStrings[1] != string.Empty)
                 //    dummyDoc.FileName = parsedStrings[1];
                 //if (parsedStrings[2] != string.Empty)
                 //    dummyDoc.Text = parsedStrings[2];

                 return dummyDoc;*/
                return null;
            }
        }

        private void CloseAllContents()
        {
            // we don't want to create another instance of tool window, set DockPanel to null
            m_solutionExplorer.DockPanel = null;
            m_propertyWindow.DockPanel = null;
            m_outputWindow.DockPanel = null;

            // Close all other document windows
            CloseAllDocuments();

            // IMPORTANT: dispose all float windows.
            foreach (var window in dockPanel.FloatWindows.ToList())
                window.Dispose();

            System.Diagnostics.Debug.Assert(dockPanel.Panes.Count == 0);
            System.Diagnostics.Debug.Assert(dockPanel.Contents.Count == 0);
            System.Diagnostics.Debug.Assert(dockPanel.FloatWindows.Count == 0);
        }

        public void SetFormStyle(Color color)
        {
            BorderColor = color;
            HeaderColor = this.dockPanel.Theme.ColorPalette.CommandBarToolbarDefault.Background;
            sysMenuButton.HoverBackColor = color;
        }

        public void SetSchema(ThemeBase theme)
        {
            // Persist settings when rebuilding UI
            string configFile = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "DockPanel.temp.config");

            dockPanel.SaveAsXml(configFile);
            CloseAllContents();

            DockPanelTheme = theme;
			EnableVSRenderer(VisualStudioToolStripExtender.VsVersion.Vs2015, theme);

            if (dockPanel.Theme.ColorPalette != null)
            {
                statusBar.BackColor = dockPanel.Theme.ColorPalette.MainWindowStatusBarDefault.Background;
            }

            if (File.Exists(configFile))
                dockPanel.LoadFromXml(configFile, m_deserializeDockContent);

            EnableRenderer(appearanceSetting);
            EnableRenderer(newform);

            newform.MetroTheme = theme;
            _splashScreen.MetroTheme = theme;
        }

        private void EnableVSRenderer(VisualStudioToolStripExtender.VsVersion version, ThemeBase theme)
        {
            vS2015ToolStripExtender.SetStyle(mainMenu, theme);
            vS2015ToolStripExtender.SetStyle(toolBar, theme);

            EnableRenderer(this);

            SetFormStyle(theme.ColorPalette.MainWindowStatusBarDefault.Background);
        }

        public void EnableRenderer(Form form)
        {
            if (null == form)
            {
                return;
            }
            System.Reflection.FieldInfo[] fieldInfo = form.GetType().GetFields(System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);

            for (int i = 0; i < fieldInfo.Length; i++)
            {
                switch (fieldInfo[i].FieldType.Name)
                {
                    case "MenuStrip":
                        MenuStrip ms = (MenuStrip)fieldInfo[i].GetValue(form);
                        vS2015ToolStripExtender.SetStyle(ms, VisualStudioToolStripExtender.VsVersion.Vs2015, dockPanel.Theme);
                        break;
                    case "ToolStrip":
                        ToolStrip ts = (ToolStrip)fieldInfo[i].GetValue(form);
                        vS2015ToolStripExtender.SetStyle(ts, VisualStudioToolStripExtender.VsVersion.Vs2015, dockPanel.Theme);
                        break;
                    case "ContextMenuStrip":
                        ContextMenuStrip cms = (ContextMenuStrip)fieldInfo[i].GetValue(form);
                        cms.DropShadowEnabled = false;
                        vS2015ToolStripExtender.SetStyle(cms, VisualStudioToolStripExtender.VsVersion.Vs2015, dockPanel.Theme);
                        break;
                    case "StatusStrip":
                        StatusStrip ss = (StatusStrip)fieldInfo[i].GetValue(form);
                        vS2015ToolStripExtender.SetStyle(ss, VisualStudioToolStripExtender.VsVersion.Vs2015, dockPanel.Theme);
                        break;
                }
            }
        }

        public void UpdateDockContentColor()
        {
            if (dockPanel.DocumentStyle == DocumentStyle.SystemMdi)
            {
                //foreach (Form form in MdiChildren)
                //    form.Close();
            }
            else
            {
                foreach (DockContent dc in dockPanel.Contents)
                {
                    /*if (dc is DummyOutputWindow)
                    {
                       ((DummyOutputWindow)dc).UpdateStyle(MyStyle);
                    }
                    if (dc is DummyDoc)
                    {
                        ((DummyDoc)dc).UpdateStyle(MyStyle);
                    }*/
                    dc.UpdateStyle(MyStyle);
                }
            }
        }

        public void ModifyTheme(VS2015ThemeBase theme, Color color)
        {
            DockPanelColorPalette palette = theme.ColorPalette;
            //Color value = color;

            palette.CommandBarToolbarDefault.Background = color;
            palette.CommandBarToolbarDefault.Border = color;
            palette.CommandBarToolbarDefault.SeparatorAccent = color;
            palette.CommandBarToolbarDefault.OverflowButtonBackground = color;

            palette.CommandBarToolbarButtonChecked.Background = color;
            //palette.CommandBarToolbarButtonCheckedHovered.Border = Color.Red;
            //palette.CommandBarToolbarButtonPressed.Background = Color.Red;
            //palette.CommandBarMenuTopLevelHeaderHovered.Background = Color.Red;

            palette.MainWindowActive.Background = color;
            //palette.ToolWindowBorder = Color.Black;
            palette.ToolWindowSeparator = color;
            palette.ToolWindowTabUnselected.Background = color;
            palette.ToolWindowTabSelectedInactive.Background = color;
            palette.ToolWindowCaptionInactive.Background = color;

            palette.DockTarget.Background = color;
            palette.DockTarget.GlyphBackground = color;

            palette.CommandBarMenuDefault.Background = color;
            palette.CommandBarMenuPopupDefault.BackgroundBottom = color;// Color.White;
            palette.CommandBarMenuPopupDefault.BackgroundTop = color;// Color.White;
            palette.CommandBarMenuPopupDefault.IconBackground = color;// Color.White;
            palette.CommandBarMenuPopupDefault.Checkmark = color;
            palette.CommandBarMenuPopupDefault.CheckmarkBackground = color;
            palette.CommandBarMenuPopupDefault.IconBackground = color;


            theme.RefreshImageService();
        }

        public void SetTheme(Color color)
        {
            /*DockPanelColorPalette palette = DockPanelTheme.ColorPalette;
            Color value = theme;

            palette.CommandBarToolbarDefault.Background = value;
            palette.CommandBarToolbarDefault.Border = value;
            palette.CommandBarToolbarDefault.SeparatorAccent = value;
            palette.CommandBarToolbarDefault.OverflowButtonBackground = value;

            palette.CommandBarToolbarButtonChecked.Background = value;
            //palette.CommandBarToolbarButtonCheckedHovered.Border = Color.Red;
            //palette.CommandBarToolbarButtonPressed.Background = Color.Red;
            //palette.CommandBarMenuTopLevelHeaderHovered.Background = Color.Red;

            palette.MainWindowActive.Background = value;
            //palette.ToolWindowBorder = Color.Black;
            palette.ToolWindowSeparator = value;
            palette.ToolWindowTabUnselected.Background = value;
            palette.ToolWindowTabSelectedInactive.Background = value;
            palette.ToolWindowCaptionInactive.Background = value;

            palette.DockTarget.Background = value;
            palette.DockTarget.GlyphBackground = value;

            palette.CommandBarMenuDefault.Background = value;
            palette.CommandBarMenuPopupDefault.BackgroundBottom = value;// Color.White;
            palette.CommandBarMenuPopupDefault.BackgroundTop = value;// Color.White;
            palette.CommandBarMenuPopupDefault.IconBackground = value;// Color.White;
            palette.CommandBarMenuPopupDefault.Checkmark = value;
            palette.CommandBarMenuPopupDefault.CheckmarkBackground = value;
            palette.CommandBarMenuPopupDefault.IconBackground = value;


            ((WeifenLuo.WinFormsUI.ThemeVS2015.VS2015ThemeBase)DockPanelTheme).RefreshImageService();
            */
            ModifyTheme((VS2015ThemeBase)DockPanelTheme, color);
            SetSchema(DockPanelTheme);
        }

        public void ModifyStyle(VS2015ThemeBase theme, Color style)
        {
            DockPanelColorPalette palette = theme.ColorPalette;
            Color value = style;

            //palette.CommandBarToolbarButtonChecked.Background = value;
            palette.CommandBarToolbarButtonCheckedHovered.Border = value;
            palette.CommandBarToolbarButtonPressed.Background = value;
            //palette.CommandBarToolbarOverflowHovered.Background = value;
            //palette.CommandBarToolbarOverflowPressed.Background = value;
            palette.CommandBarMenuTopLevelHeaderHovered.Background = value;
            palette.CommandBarMenuPopupHovered.CheckmarkBackground = value;
            palette.CommandBarToolbarButtonChecked.Border = value;

            palette.CommandBarMenuPopupHovered.ItemBackground = value;
            palette.CommandBarMenuPopupHovered.Checkmark = value;
            palette.CommandBarMenuPopupHovered.CheckmarkBackground = value;
            palette.CommandBarMenuPopupDefault.Border = value;
            palette.CommandBarMenuPopupDefault.Separator = value;

            //palette.CommandBarMenuDefault.Background = value;


            //ThemeOwner.DockPanelTheme.ColorPalette.DockTarget.Background = Color.Black;
            //ThemeOwner.DockPanelTheme.ColorPalette.TabButtonSelectedActiveHovered.Background = Color.Black;
            palette.TabSelectedActive.Background = value;
            //palette.TabSelectedActive.Text = value;

            palette.ToolWindowTabUnselectedHovered.Background = value;
            palette.ToolWindowTabUnselectedHovered.Text = Color.White;//============
            palette.ToolWindowTabSelectedActive.Text = Color.Black;
            palette.ToolWindowTabSelectedInactive.Text = value;

            //ThemeOwner.DockPanelTheme.ColorPalette.ToolWindowCaptionButtonActiveHovered.Background = value;
            palette.ToolWindowCaptionActive.Background = value;


            //ThemeOwner.DockPanelTheme.ColorPalette.AutoHideStripDefault.Border = Color.Red;
            //==ThemeOwner.DockPanelTheme.ColorPalette.AutoHideStripHovered.Background = value;
            palette.AutoHideStripHovered.Border = value;
            palette.AutoHideStripHovered.Text = value;


            palette.ToolWindowCaptionActive.Background = value;
            palette.MainWindowStatusBarDefault.Background = value;

            //palette.TabButtonUnselectedTabHoveredButtonHovered.Background = Color.Red;
            //palette.TabButtonUnselectedTabHoveredButtonHovered.Border = Color.Red;
            Color hoverColor = ColorConvert.ChangeColor(value, 0.2f);//ChangeColor(value, 0.2f);
            Color pressedColor = ColorConvert.ChangeColor(value, -0.2f);
            Color inactiveHoveredColor =  ColorConvert.ChangeColor(value, 0.2f);

            palette.ToolWindowCaptionButtonActiveHovered.Background = hoverColor;
            palette.ToolWindowCaptionButtonActiveHovered.Border = hoverColor;
            palette.ToolWindowCaptionButtonPressed.Background = pressedColor;
            palette.ToolWindowCaptionButtonPressed.Border = pressedColor;
            palette.ToolWindowCaptionButtonInactiveHovered.Background = inactiveHoveredColor;
            palette.ToolWindowCaptionButtonInactiveHovered.Border = inactiveHoveredColor;


            palette.TabButtonSelectedActivePressed.Background = pressedColor;
            palette.TabButtonSelectedActivePressed.Border = pressedColor;
            palette.TabButtonSelectedActiveHovered.Background = inactiveHoveredColor;
            palette.TabButtonSelectedActiveHovered.Border = inactiveHoveredColor;

            palette.OverflowButtonHovered.Background = hoverColor;
            palette.OverflowButtonHovered.Border = hoverColor;
            palette.OverflowButtonHovered.Glyph = Color.Black;
            palette.OverflowButtonPressed.Background = pressedColor;
            palette.OverflowButtonPressed.Border = pressedColor;

            Color tabUnselectedHovered = Color.FromArgb(204, 206, 219);// ColorConvert.ChangeColor(palette.CommandBarToolbarDefault.Background, -0.2f);
            Color hoverColorUnselected = ColorConvert.ChangeColor(tabUnselectedHovered, 0.2f);
            Color pressedColorUnselected = ColorConvert.ChangeColor(tabUnselectedHovered, -0.2f);
            palette.TabUnselectedHovered.Background = tabUnselectedHovered;
            palette.TabButtonUnselectedTabHoveredButtonHovered.Background = hoverColorUnselected;
            palette.TabButtonUnselectedTabHoveredButtonHovered.Border = hoverColorUnselected;
            palette.TabButtonUnselectedTabHoveredButtonPressed.Background = pressedColorUnselected;
            palette.TabButtonUnselectedTabHoveredButtonPressed.Border = pressedColorUnselected;


            theme.RefreshImageService();
            //ThemeOwner.DockPanelTheme.Skin = new DockPanelSkin();
            //ThemeOwner.DockPanelTheme.PaintingService = new WeifenLuo.WinFormsUI.ThemeVS2012.PaintingService();
            //ThemeOwner.DockPanelTheme.ImageService = new WeifenLuo.WinFormsUI.ThemeVS2012.ImageService(this);
        }

        public void SetStyle(Color style)
        {
            /*DockPanelColorPalette palette = DockPanelTheme.ColorPalette;
            Color value = style;

            //palette.CommandBarToolbarButtonChecked.Background = value;
            palette.CommandBarToolbarButtonCheckedHovered.Border = value;
            palette.CommandBarToolbarButtonPressed.Background = value;
            //palette.CommandBarToolbarOverflowHovered.Background = value;
            //palette.CommandBarToolbarOverflowPressed.Background = value;
            palette.CommandBarMenuTopLevelHeaderHovered.Background = value;
            palette.CommandBarMenuPopupHovered.CheckmarkBackground = value;
            palette.CommandBarToolbarButtonChecked.Border = value;

            palette.CommandBarMenuPopupHovered.ItemBackground = value;
            palette.CommandBarMenuPopupHovered.Checkmark = value;
            palette.CommandBarMenuPopupHovered.CheckmarkBackground = value;
            palette.CommandBarMenuPopupDefault.Border = value;
            palette.CommandBarMenuPopupDefault.Separator = value;

            //palette.CommandBarMenuDefault.Background = value;


            //ThemeOwner.DockPanelTheme.ColorPalette.DockTarget.Background = Color.Black;
            //ThemeOwner.DockPanelTheme.ColorPalette.TabButtonSelectedActiveHovered.Background = Color.Black;
            palette.TabSelectedActive.Background = value;
            //palette.TabSelectedActive.Text = value;

            palette.ToolWindowTabUnselectedHovered.Background = value;
            palette.ToolWindowTabUnselectedHovered.Text = Color.White;//============
            palette.ToolWindowTabSelectedActive.Text = Color.Black;
            palette.ToolWindowTabSelectedInactive.Text = value;

            //ThemeOwner.DockPanelTheme.ColorPalette.ToolWindowCaptionButtonActiveHovered.Background = value;
            palette.ToolWindowCaptionActive.Background = value;


            //ThemeOwner.DockPanelTheme.ColorPalette.AutoHideStripDefault.Border = Color.Red;
            //==ThemeOwner.DockPanelTheme.ColorPalette.AutoHideStripHovered.Background = value;
            palette.AutoHideStripHovered.Border = value;
            palette.AutoHideStripHovered.Text = value;


            palette.ToolWindowCaptionActive.Background = value;
            palette.MainWindowStatusBarDefault.Background = value;

            //palette.TabButtonUnselectedTabHoveredButtonHovered.Background = Color.Red;
            //palette.TabButtonUnselectedTabHoveredButtonHovered.Border = Color.Red;
            Color hoverColor = ColorConvert.ChangeColor(value, 0.2f);//ChangeColor(value, 0.2f);
            Color pressedColor = ColorConvert.ChangeColor(value, -0.2f);
            Color inactiveHoveredColor = ColorConvert.ChangeColor(value, 0.2f);

            palette.ToolWindowCaptionButtonActiveHovered.Background = hoverColor;
            palette.ToolWindowCaptionButtonActiveHovered.Border = hoverColor;
            palette.ToolWindowCaptionButtonPressed.Background = pressedColor;
            palette.ToolWindowCaptionButtonPressed.Border = pressedColor;
            palette.ToolWindowCaptionButtonInactiveHovered.Background = inactiveHoveredColor;
            palette.ToolWindowCaptionButtonInactiveHovered.Border = inactiveHoveredColor;


            palette.TabButtonSelectedActivePressed.Background = pressedColor;
            palette.TabButtonSelectedActivePressed.Border = pressedColor;
            palette.TabButtonSelectedActiveHovered.Background = inactiveHoveredColor;
            palette.TabButtonSelectedActiveHovered.Border = inactiveHoveredColor;

            palette.OverflowButtonHovered.Background = hoverColor;
            palette.OverflowButtonHovered.Border = hoverColor;
            palette.OverflowButtonHovered.Glyph = Color.Black;
            palette.OverflowButtonPressed.Background = pressedColor;
            palette.OverflowButtonPressed.Border = pressedColor;

            Color tabUnselectedHovered = ColorConvert.ChangeColor(palette.CommandBarToolbarDefault.Background, -0.2f);
            Color hoverColorUnselected = ColorConvert.ChangeColor(tabUnselectedHovered, 0.2f);
            Color pressedColorUnselected = ColorConvert.ChangeColor(tabUnselectedHovered, -0.2f);
            palette.TabUnselectedHovered.Background = tabUnselectedHovered;
            palette.TabButtonUnselectedTabHoveredButtonHovered.Background = hoverColorUnselected;
            palette.TabButtonUnselectedTabHoveredButtonHovered.Border = hoverColorUnselected;
            palette.TabButtonUnselectedTabHoveredButtonPressed.Background = pressedColorUnselected;
            palette.TabButtonUnselectedTabHoveredButtonPressed.Border = pressedColorUnselected;


            ((WeifenLuo.WinFormsUI.ThemeVS2015.VS2015ThemeBase)DockPanelTheme).RefreshImageService();
            //ThemeOwner.DockPanelTheme.Skin = new DockPanelSkin();
            //ThemeOwner.DockPanelTheme.PaintingService = new WeifenLuo.WinFormsUI.ThemeVS2012.PaintingService();
            //ThemeOwner.DockPanelTheme.ImageService = new WeifenLuo.WinFormsUI.ThemeVS2012.ImageService(this);
            */
            ModifyStyle((VS2015ThemeBase)DockPanelTheme, style);
            SetSchema(DockPanelTheme);
        }

        #endregion

        #region Event Handlers

        private void menuItemExit_Click(object sender, System.EventArgs e)
        {
            Close();
        }

        private void menuItemSolutionExplorer_Click(object sender, System.EventArgs e)
        {
            m_solutionExplorer.Show(dockPanel);
        }

        private void menuItemPropertyWindow_Click(object sender, System.EventArgs e)
        {
            m_propertyWindow.Show(dockPanel);
        }

        private void menuItemOutputWindow_Click(object sender, System.EventArgs e)
        {
            m_outputWindow.Show(dockPanel);
        }

        private void menuItemAbout_Click(object sender, System.EventArgs e)
        {
            AboutDialog aboutDialog = new AboutDialog(DefaultTheme);
            aboutDialog.ShowDialog(this);
        }

        private void menuItemFile_Popup(object sender, System.EventArgs e)
        {
            if (dockPanel.DocumentStyle == DocumentStyle.SystemMdi)
            {
                menuItemClose.Enabled =
                    menuItemCloseAll.Enabled =
                    menuItemCloseAllButThisOne.Enabled = (ActiveMdiChild != null);
            }
            else
            {
                menuItemClose.Enabled = (dockPanel.ActiveDocument != null);
                menuItemCloseAll.Enabled =
                    menuItemCloseAllButThisOne.Enabled = (dockPanel.DocumentsCount > 0);
            }
        }

        private void menuItemClose_Click(object sender, System.EventArgs e)
        {
            if (dockPanel.DocumentStyle == DocumentStyle.SystemMdi)
                ActiveMdiChild.Close();
            else if (dockPanel.ActiveDocument != null)
                dockPanel.ActiveDocument.DockHandler.Close();
        }

        private void menuItemCloseAll_Click(object sender, System.EventArgs e)
        {
            CloseAllDocuments();
        }

        private void MainForm_Load(object sender, System.EventArgs e)
        {
            string configFile = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "layout.xml");

            if (File.Exists(configFile))
            {
                try
                {
                    dockPanel.LoadFromXml(configFile, m_deserializeDockContent);
                }
                catch
                {
                    loadByCode();
                }
            }
        }

        private void MainForm_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            string configFile = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "layout.xml");

            if (m_bSaveLayout)
                dockPanel.SaveAsXml(configFile);
            else if (File.Exists(configFile))
                File.Delete(configFile);

            if (null != m_solutionExplorer)
            {
                m_solutionExplorer.SaveHistory();
            }
            if (null != m_propertyWindow)
            {
                m_propertyWindow.SaveHistory();
            }
            if (null != m_outputWindow)
            {
                m_outputWindow.SaveHistory();
            }
        }

        private void menuItemStatusBar_Click(object sender, System.EventArgs e)
        {
            statusBar.Visible = menuItemStatusBar.Checked = !menuItemStatusBar.Checked;
        }

        private void menuItemTools_Popup(object sender, System.EventArgs e)
        {
            menuItemLockLayout.Checked = !this.dockPanel.AllowEndUserDocking;
        }

        private bool LayoutLock
        {
            get { return dockPanel.AllowEndUserDocking; }
            set
            {
                dockPanel.AllowEndUserDocking = value;
                menuItemLockLayout.Checked = lockToolStripMenuItem.Checked = !dockPanel.AllowEndUserDocking;
                if (dockPanel.AllowEndUserDocking)
                {
                    lockLayoutToolStripMenuItem.DisplayStyle = ToolStripItemDisplayStyle.Text;
                }
                else
                {
                    lockLayoutToolStripMenuItem.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText;
                }
            }
        }

        private void menuItemLockLayout_Click(object sender, System.EventArgs e)
        {
            LayoutLock = !LayoutLock;
        }

        private void loadByCode()
        {
            dockPanel.SuspendLayout(true);

            CloseAllContents();

            CreateStandardControls();

            m_propertyWindow.Show(dockPanel, DockState.DockRight);
            m_outputWindow.Show(dockPanel, DockState.DockBottom);
            m_solutionExplorer.Show(m_propertyWindow.Pane, m_propertyWindow);

            dockPanel.ResumeLayout(true, true);
        }

        private void menuItemDefautLayout_Click(object sender, System.EventArgs e)
        {
            loadByCode();
        }

        private void SetSplashScreen()
        {
            if (null == _splashScreen)
            {
                _splashScreen = new SplashScreen();
            }
            _showSplash = true;

            _splashScreen.Show(this);
            _splashScreen.Visible = true;
            _splashScreen.TopMost = true;

            Timer _timer = new Timer();
            _timer.Tick += (sender, e) =>
            {
                _splashScreen.Visible = false;
                _timer.Enabled = false;
                _showSplash = false;
            };
            _timer.Interval = 2000;
            _timer.Enabled = true;
        }

        private void CreateStandardControls()
        {
            m_solutionExplorer = new DummySolutionExplorer();
            m_propertyWindow = new DummyPropertyWindow();
            m_outputWindow = new DummyOutputWindow(customStyle);
            appearanceSetting = new AppearanceSetting(this);

            m_solutionExplorer.RightToLeftLayout = RightToLeftLayout;

            //m_solutionExplorer.EnableVSRenderer(DefaultTheme, VisualStudioToolStripExtender.VsVersion.Vs2015);
            //m_propertyWindow.EnableVSRenderer(DefaultTheme, VisualStudioToolStripExtender.VsVersion.Vs2015);
            //m_outputWindow.EnableVSRenderer(DefaultTheme, VisualStudioToolStripExtender.VsVersion.Vs2015);
        }

        private void menuItemLayoutByXml_Click(object sender, System.EventArgs e)
        {
            dockPanel.SuspendLayout(true);

            // In order to load layout from XML, we need to close all the DockContents
            CloseAllContents();

            CreateStandardControls();

            Assembly assembly = Assembly.GetAssembly(typeof(MainForm));
            Stream xmlStream = assembly.GetManifestResourceStream("ToolSuite.Resources.DockPanel.xml");
            dockPanel.LoadFromXml(xmlStream, m_deserializeDockContent);
            xmlStream.Close();

            dockPanel.ResumeLayout(true, true);
        }

        private void menuItemCloseAllButThisOne_Click(object sender, System.EventArgs e)
        {
            if (dockPanel.DocumentStyle == DocumentStyle.SystemMdi)
            {
                Form activeMdi = ActiveMdiChild;
                foreach (Form form in MdiChildren)
                {
                    if (form != activeMdi)
                        form.Close();
                }
            }
            else
            {
                foreach (IDockContent document in dockPanel.DocumentsToArray())
                {
                    if (!document.DockHandler.IsActivated)
                        document.DockHandler.Close();
                }
            }
        }

        private void exitWithoutSavingLayout_Click(object sender, EventArgs e)
        {
            m_bSaveLayout = false;
            Close();
            m_bSaveLayout = true;
        }

        #endregion

        public DummyDoc GetActivedReceiveWindow()
        {
            return (DummyDoc)dockPanel.ActiveDocument;
        }

        public DummyDoc NewPortForm(SerialPort p)
        {
            return new DummyDoc(p, customStyle);
        }

        public void ShowPortForm(DummyDoc pForm)
        {
            pForm.Show(dockPanel);
        }

        private void tsbTopMost_Click(object sender, EventArgs e)
        {
            TopMost = tsbtTopMost.Checked;
        }

        #region Events

        //定义delegate
        public delegate void SerialPortSendEventHandler(object sender, System.EventArgs e);

        /// <summary>
        /// DialogBox Event
        /// </summary>
        [Category("Customize"), Description("Serial Port Send Event.")]
        public event SerialPortSendEventHandler SerialPortSendEvent;

        //事件触发方法
        protected virtual void OnSingleBoxEvent(EventArgs e)
        {
            if (SerialPortSendEvent != null)
                SerialPortSendEvent(this, e);
        }
        #endregion

        private void RecordState(bool state)
        {
            tsbtRecord.ToolTipText = state ? "record enable" : "record disable";
            tsbtRecord.Image = state ? highQualityImageList.ImageItems[0].Image : highQualityImageList.ImageItems[1].Image;
        }

        private void LoadActiveDocState(DummyDoc doc)
        {
            BeginInvoke(new Action(() =>
            {
                if (null != doc)
                {
                    RecordState(doc.LogRecord);
                    tsbtAutoScroll.Checked = doc.AutoScroll;
                    statusLabelPortInfo.Text = doc.PortInfo;
                }
            })); 
        }

        private void dockPanel_ActiveDocumentChanged(object sender, EventArgs e)
        {
            DummyDoc doc = (DummyDoc)dockPanel.ActiveDocument;
            if (null != m_outputWindow)
            {
                m_outputWindow.DocActivedChangedNotify(doc);
            }

            LoadActiveDocState(doc);

            if (null != searchForm)
            {
                searchForm.FCTB = (null == doc) ? null : doc.FCTB;
            }
        }

        private void dockPanel_ContentAdded(object sender, DockContentEventArgs e)
        {
            DockContent content = e.Content as DockContent;
            if (content is DummyDoc)
            {
                DummyDoc doc = (DummyDoc)content;
                m_outputWindow.DocAddedNotify(doc);
            }
        }

        private void dockPanel_ContentRemoved(object sender, DockContentEventArgs e)
        {
            DockContent content = e.Content as DockContent;
            if (content is DummyDoc)
            {
                DummyDoc doc = (DummyDoc)content;
                m_outputWindow.DocRemovedNotify(doc);
            }
            //foreach (IDockContent content in dockPanel.Documents)
            //    if (content.DockHandler.TabText == text)
            //        return content;
        }

        private void notifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal || this.WindowState == FormWindowState.Maximized)
            {
                this.WindowState = FormWindowState.Minimized;
                this.Hide();
            }
            else if (this.WindowState == FormWindowState.Minimized)
            {
                this.Show();
                this.WindowState = FormWindowState.Normal;
                this.Activate();
            }
        }

        private void ScreenShot()
        {
            CaptureImageTool capture = new CaptureImageTool();
            capture.BackColor = Color.White;
            capture.StyleColor = this.BorderColor;// Color.FromArgb(0, 174, 219);

            capture.SelectCursor = Cursors.Default;
            capture.DrawCursor = Cursors.Default;
            if (capture.ShowDialog() == DialogResult.OK)
            {
            }
        }

        private void OpenLogWithApp(string file)
        {
            try
            {
                Process.Start(notepadApp, file);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void OpenLogDirectory(string path)
        {
            try
            {
                System.Diagnostics.ProcessStartInfo psi = new System.Diagnostics.ProcessStartInfo("Explorer.exe");
                psi.Arguments = "/e,/select," + path;
                System.Diagnostics.Process.Start(psi);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void toolBarItem_Click(object sender, EventArgs e)
        {
            ToolStripButton tsbt = sender as ToolStripButton;
            DummyDoc form = GetActivedReceiveWindow();
            if (null == form)
            {
                return;
            }

            if (tsbtShowLineNumber == tsbt)
            {
                form.ShowLineNumbers = !form.ShowLineNumbers;
            }
            else if (tsbtSaveToFile == tsbt)
            {
                form.SaveToFile();
            }
            else if (tsbtClear == tsbt)
            {
                form.Clear();
            }
            else if (tsbtClearBookmarks == tsbt)
            {
                form.ClearBookmarks();
            }
            else if (tsbtRecord == tsbt)
            {
                form.LogRecord = !form.LogRecord;
            }
            else if (tsbtNewLog == tsbt)
            {
                form.NewLogFile();
            }
            else if (tsbtOpenWithApp == tsbt)
            {
                OpenLogWithApp(form.LogFile);
            }
            else if (tsbtOpenLogDirectory == tsbt)
            {
                OpenLogDirectory(form.LogPath);
            }
            else if (tsbtAutoScroll == tsbt)
            {
                form.AutoScroll = !form.AutoScroll;
            }

            LoadActiveDocState(form);
        }
        
        private void tsbtNew_Click(object sender, EventArgs e)
        {
            if (!newform.Visible)
            {
                newform.Show(this);
            }
        }

        private void tebtScreenShot_Click(object sender, EventArgs e)
        {
            ScreenShot();
        }

        private void tsbtTopMost_Click(object sender, EventArgs e)
        {
            TopMost = tsbtTopMost.Checked;
            tsbtTopMost.Checked = TopMost;
        }

        public void LayoutRcvWindows(MdiLayout layout)
        {
            int index = 0;
            IDockContent pre = null;
            DockStyle style = DockStyle.Fill;

            dockPanel.SuspendLayout(true);

            switch (layout)
            {
                case MdiLayout.TileHorizontal:
                    style = DockStyle.Bottom;
                    break;
                case MdiLayout.TileVertical:
                    style = DockStyle.Right;
                    break;
                case MdiLayout.Cascade:
                default:
                    style = DockStyle.Fill;
                    break;
            }

            foreach (IDockContent document in dockPanel.DocumentsToArray())
            {
                if (0 != index)
                {
                    document.DockHandler.DockTo(pre.DockHandler.Pane, style, index);
                }
                index++;
                pre = document;
            }

            dockPanel.ResumeLayout(true, true);
        }

        private MdiLayout CurrentLayoutItem = MdiLayout.TileVertical;
        private void tssbtLayout_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem item = sender as ToolStripMenuItem;

            if (item == lockToolStripMenuItem)
            {
                LayoutLock = !LayoutLock;
                lockToolStripMenuItem.Checked = !LayoutLock;
                return;
            }
            else if (item == horizontalToolStripMenuItem)
            {
                tssbtLayout.Image = horizontalToolStripMenuItem.Image;
                CurrentLayoutItem = MdiLayout.TileHorizontal;
                LayoutRcvWindows(CurrentLayoutItem);
            }
            else if (item == verticalToolStripMenuItem)
            {
                tssbtLayout.Image = verticalToolStripMenuItem.Image;
                CurrentLayoutItem = MdiLayout.TileVertical;
                LayoutRcvWindows(CurrentLayoutItem);
            }
            else if (item == stackToolStripMenuItem)
            {
                tssbtLayout.Image = stackToolStripMenuItem.Image;
                CurrentLayoutItem = MdiLayout.Cascade;
                LayoutRcvWindows(CurrentLayoutItem);
            }
        }

        private void tssbtLayout_ButtonClick(object sender, EventArgs e)
        {
            LayoutRcvWindows(CurrentLayoutItem);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void showSplashToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetSplashScreen();
        }

        public void StatusBarShowSendInfo(string info)
        {
            statusBar.BeginInvoke(new Action(() =>
            {
                statusLabelSendNum.Text = "s:" + info;
            }));
        }

        public void StatusBarShowRcvInfo(string info)
        {
            statusBar.BeginInvoke(new Action(() =>
            {
                statusLabelRcvNum.Text = "r:" + info;
            }));
        }

        private void showMenuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mainMenu.Visible = !mainMenu.Visible;
        }

        private void appearanceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            appearanceSetting.Show(this);
        }


        public void VComAdd(string portName)
        {
            foreach (ToolStripDropDownItem item in portListToolStripMenuItem.DropDownItems)
            {
                if (item.Text.Equals(portName))
                {
                    return;
                }
            }
            portListToolStripMenuItem.DropDownItems.Add(portName);
            //notifyForm.ShowNotify(portName + " is added!");
            notifyIcon.ShowBalloonTip(2000, "ToolSuite", portName + " is added!", ToolTipIcon.Info);


            //newform?.OnPortListChanged();
        }

        public void VComRemove(string portName)
        {
            List<ToolStripDropDownItem> removeList = new List<ToolStripDropDownItem>();

            foreach (ToolStripDropDownItem item in portListToolStripMenuItem.DropDownItems)
            {
                if (item.Text.Equals(portName))
                {
                    removeList.Add(item);
                }
            }
            foreach (ToolStripDropDownItem item in removeList)
            {
                portListToolStripMenuItem.DropDownItems.Remove(item);
            }
            //notifyForm.ShowNotify(portName + " is removed!");
            notifyIcon.ShowBalloonTip(2000, "ToolSuite", portName + " is removed!", ToolTipIcon.Info);

            //newform?.OnPortListChanged();
        }


        // usb消息定义
        public const int WM_DEVICE_CHANGE = 0x219;
        public const int DBT_DEVICEARRIVAL = 0x8000;
        public const int DBT_DEVICE_REMOVE_COMPLETE = 0x8004;
        public const UInt32 DBT_DEVTYP_PORT = 0x00000003;

        struct DEV_BROADCAST_HDR
        {
            public UInt32 dbch_size;
            public UInt32 dbch_devicetype;
            public UInt32 dbch_reserved;
        }

        struct DEV_BROADCAST_PORT
        {
            public uint dbcp_size;
            public uint dbcp_devicetype;
            public uint dbcp_reserved;
            //public char dbcp_name[1];
        }

        /// <summary>
        /// 检测USB串口的拔插
        /// </summary>
        /// <param name="m"></param>
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WM_DEVICE_CHANGE)        // 捕获USB设备的拔出消息WM_DEVICECHANGE
            {
                DEV_BROADCAST_HDR dbhdr;
                if (deviceTipsToolStripMenuItem.Checked)
                {
                    switch (m.WParam.ToInt32())
                    {
                        case DBT_DEVICE_REMOVE_COMPLETE:    // USB拔出     
                            dbhdr = (DEV_BROADCAST_HDR)Marshal.PtrToStructure(m.LParam, typeof(DEV_BROADCAST_HDR));
                            if (dbhdr.dbch_devicetype == DBT_DEVTYP_PORT)
                            {
                                string portName = Marshal.PtrToStringUni((IntPtr)(m.LParam.ToInt32() + Marshal.SizeOf(typeof(DEV_BROADCAST_PORT))));
                                VComRemove(portName);
                            }
                            break;
                        case DBT_DEVICEARRIVAL:             // USB插入获取对应串口名称
                            dbhdr = (DEV_BROADCAST_HDR)Marshal.PtrToStructure(m.LParam, typeof(DEV_BROADCAST_HDR));
                            if (dbhdr.dbch_devicetype == DBT_DEVTYP_PORT)
                            {
                                string portName = Marshal.PtrToStringUni((IntPtr)(m.LParam.ToInt32() + Marshal.SizeOf(typeof(DEV_BROADCAST_PORT))));
                                VComAdd(portName);
                            }
                            break;
                    }
                } 
            }
            base.WndProc(ref m);
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                this.Close();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void ShowFind()
        {
            if (null != dockPanel.ActiveDocument)
            {
                searchForm.ShowFind();
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            ShowFind();
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F && e.Control)
            {
                e.Handled = true;
                ShowFind();
            }
        }
    }
}