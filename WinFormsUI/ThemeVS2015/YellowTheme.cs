namespace WeifenLuo.WinFormsUI.Docking
{
    using ThemeVS2015;

    /// <summary>
    /// Visual Studio 2015 Light theme.
    /// </summary>
    public class YellowTheme : VS2015ThemeBase
    {
        public YellowTheme()
            : base(Decompress(Resources.Yellow_vstheme))
        {
        }
    }
}
