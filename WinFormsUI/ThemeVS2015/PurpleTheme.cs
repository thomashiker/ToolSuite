namespace WeifenLuo.WinFormsUI.Docking
{
    using ThemeVS2015;

    /// <summary>
    /// Visual Studio 2015 Light theme.
    /// </summary>
    public class PurpleTheme : VS2015ThemeBase
    {
        public PurpleTheme()
            : base(Decompress(Resources.Purple_vstheme))
        {
        }
    }
}
