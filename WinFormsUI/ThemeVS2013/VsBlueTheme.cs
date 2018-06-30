namespace WeifenLuo.WinFormsUI.Docking
{
    using ThemeVS2013;

    /// <summary>
    /// Visual Studio 2013 Light theme.
    /// </summary>
    public class VsBlueTheme : VS2013ThemeBase
    {
        public VsBlueTheme()
            : base(Decompress(Resources.blue_vstheme))
        {
        }
    }
}
