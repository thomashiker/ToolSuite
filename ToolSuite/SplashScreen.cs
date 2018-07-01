using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Text;

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
    public partial class SplashScreen : MetroCForm
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

        public SplashScreen()
        {
            InitializeComponent();
            AutoScaleMode = AutoScaleMode.Dpi;

            MetroTheme = new BlueTheme();
        }

        private void ThemeUpdate()
        {
            BorderColor = MetroTheme.ColorPalette.MainWindowStatusBarDefault.Background;
            BackColor = MetroTheme.ColorPalette.CommandBarToolbarDefault.Background;
            HeaderColor = BackColor;

            hyperLinkLabel.ForeColor = ColorInvert(BackColor);
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
