namespace WeifenLuo.WinFormsUI.Docking
{
    using ThemeVS2015;

    /// <summary>
    /// Visual Studio 2015 Light theme.
    /// </summary>
    public class SilverTheme : VS2015ThemeBase
    {
        public SilverTheme()
            : base(Decompress(Resources.Silver_vstheme))
        {
        }
    }
}
