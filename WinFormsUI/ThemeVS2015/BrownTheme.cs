namespace WeifenLuo.WinFormsUI.Docking
{
    using ThemeVS2015;

    /// <summary>
    /// Visual Studio 2015 Light theme.
    /// </summary>
    public class BrownTheme : VS2015ThemeBase
    {
        public BrownTheme()
            : base(Decompress(Resources.Brown_vstheme))
        {
        }
    }
}
