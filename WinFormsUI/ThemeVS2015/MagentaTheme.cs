namespace WeifenLuo.WinFormsUI.Docking
{
    using ThemeVS2015;

    /// <summary>
    /// Visual Studio 2015 Light theme.
    /// </summary>
    public class MagentaTheme : VS2015ThemeBase
    {
        public MagentaTheme()
            : base(Decompress(Resources.Magenta_vstheme))
        {
        }
    }
}
