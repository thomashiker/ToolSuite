namespace WeifenLuo.WinFormsUI.Docking
{
    using ThemeVS2015;

    /// <summary>
    /// Visual Studio 2015 Light theme.
    /// </summary>
    public class RedTheme : VS2015ThemeBase
    {
        public RedTheme()
            : base(Decompress(Resources.Red_vstheme))
        {
        }
    }
}
