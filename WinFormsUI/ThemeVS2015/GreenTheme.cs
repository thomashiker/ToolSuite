namespace WeifenLuo.WinFormsUI.Docking
{
    using ThemeVS2015;

    /// <summary>
    /// Visual Studio 2015 Light theme.
    /// </summary>
    public class GreenTheme : VS2015ThemeBase
    {
        public GreenTheme()
            : base(Decompress(Resources.Green_vstheme))
        {
        }
    }
}
