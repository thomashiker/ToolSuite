namespace WeifenLuo.WinFormsUI.Docking
{
    using ThemeVS2015;

    /// <summary>
    /// Visual Studio 2015 Light theme.
    /// </summary>
    public class PinkTheme : VS2015ThemeBase
    {
        public PinkTheme()
            : base(Decompress(Resources.Pink_vstheme))
        {
        }
    }
}
