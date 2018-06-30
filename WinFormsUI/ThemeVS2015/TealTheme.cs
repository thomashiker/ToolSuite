namespace WeifenLuo.WinFormsUI.Docking
{
    using ThemeVS2015;

    /// <summary>
    /// Visual Studio 2015 Light theme.
    /// </summary>
    public class TealTheme : VS2015ThemeBase
    {
        public TealTheme()
            : base(Decompress(Resources.Teal_vstheme))
        {
        }
    }
}
