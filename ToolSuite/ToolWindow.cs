using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace ToolSuite
{
    public partial class ToolWindow : DockContent
    {
        //private readonly ToolStripRenderer _toolStripProfessionalRenderer = new ToolStripProfessionalRenderer();
        //private VisualStudioToolStripExtender vsToolStripExtender = new VisualStudioToolStripExtender();

        public ToolWindow()
        {
            InitializeComponent();
            AutoScaleMode = AutoScaleMode.Dpi;

            //vsToolStripExtender.DefaultRenderer = _toolStripProfessionalRenderer;
        }

        //public void EnableVSRenderer(VisualStudioToolStripExtender.VsVersion version, ThemeBase theme)
        //{
        //    System.Reflection.FieldInfo[] fieldInfo = this.GetType().GetFields(System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
        //
        //    for (int i = 0; i < fieldInfo.Length; i++)
        //    {
        //        switch (fieldInfo[i].FieldType.Name)
        //        {
        //            case "ContextMenuStrip":
        //            case "ToolStrip":
        //                ToolStrip ts = (ToolStrip)fieldInfo[i].GetValue(this);
        //                vsToolStripExtender.SetStyle(ts, version, theme);
        //                break;
        //        }
        //    }
        //}
    }
}