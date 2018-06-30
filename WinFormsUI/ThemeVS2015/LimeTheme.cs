namespace WeifenLuo.WinFormsUI.Docking
{
    using ThemeVS2015;

    /// <summary>
    /// Visual Studio 2015 Light theme.
    /// </summary>
    public class LimeTheme : VS2015ThemeBase
    {
        public LimeTheme()
            : base(Decompress(Resources.Lime_vstheme))
        {
        }
    }
}
