using System;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;
using System.Drawing;
using MetroFramework;
using MetroFramework.Forms;
using MetroFramework.Drawing;
using MetroFramework.Components;
using MetroFramework.Interfaces;
using MetroFramework.Native;
using MetroFramework.Controls;
using WeifenLuo.WinFormsUI.Docking;

namespace ToolSuite
{
    public partial class AboutDialog : MetroCForm
    {
        private ThemeBase theme;

        public ThemeBase MetroTheme
        {
            get { return theme; }
            set
            {
                theme = value;
                ThemeUpdate();
            }
        }

        public AboutDialog()
        {
            InitializeComponent();
            AutoScaleMode = AutoScaleMode.Dpi;

            MetroTheme = new BlueTheme();
        }

        public AboutDialog(ThemeBase theme)
        {
            InitializeComponent();
            AutoScaleMode = AutoScaleMode.Dpi;

            MetroTheme = theme;
        }

        private void AboutDialog_Load(object sender, EventArgs e)
        {
            labelAppVersion.Text = typeof(MainForm).Assembly.GetName().Version.ToString();
        }

        private void ThemeUpdate()
        {
            BorderColor = MetroTheme.ColorPalette.MainWindowStatusBarDefault.Background;
            BackColor = MetroTheme.ColorPalette.CommandBarToolbarDefault.Background;
            HeaderColor = BackColor;

            foreach (Control lb in Controls)
            {
                if (lb is Label)
                {
                    lb.ForeColor = ColorInvert(BackColor);
                }
            }
        }

        private Color ColorInvert(Color oldColor)
        {
            byte A, R, G, B;

            A = oldColor.A;
            R = (byte)(255 - oldColor.R);
            G = (byte)(255 - oldColor.G);
            B = (byte)(255 - oldColor.B);

            if (R <= 0) R = 17;
            if (G <= 0) G = 17;
            if (B <= 0) B = 17;

            return Color.FromArgb((int)A, (int)R, (int)G, (int)B);
        }
    }
}