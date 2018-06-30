namespace WeifenLuo.WinFormsUI.Docking
{
    using ThemeVS2015;

    /// <summary>
    /// Visual Studio 2015 Light theme.
    /// </summary>
    public class BlueTheme : VS2015ThemeBase
    {
        public BlueTheme()
            : base(Decompress(Resources.Blue_vstheme))
        {
        }
    }
}
