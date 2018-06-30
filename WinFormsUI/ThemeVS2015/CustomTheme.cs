using System;
using System.Drawing;
using System.Reflection;
using WeifenLuo.WinFormsUI.Docking;
using System.ComponentModel;
using System.Linq;
using System.Xml.Linq;
using System.Xml;


namespace WeifenLuo.WinFormsUI.Docking
{
    using ThemeVS2015;

    /// <summary>
    /// Visual Studio 2015 Light theme.
    /// </summary>
    public class CustomTheme : Component
    {
        public ThemeBase Theme = new BlueTheme();
        private const string Env = "Environment";

        public CustomTheme()
        {
            //Theme = new BlueTheme();
        }

        public Color TabSelectedActiveBackground
        {
            get { return Theme.ColorPalette.TabSelectedActive.Background; }
            set { Theme.ColorPalette.TabSelectedActive.Background = value; }
        }

        private Color ColorTranslatorFromHtml(XDocument _xml, string name, bool foreground = false)
        {
            var color = _xml.Root.Element("Theme")
                .Elements("Category").FirstOrDefault(item => item.Attribute("Name").Value == Env)?
                .Elements("Color").FirstOrDefault(item => item.Attribute("Name").Value == name)?
                .Element(foreground ? "Foreground" : "Background").Attribute("Source").Value;
            if (color == null)
            {
                return Color.Transparent;
            }

            return ColorTranslator.FromHtml($"#{color}");
        }

        public bool ColorPaletteUpdate(XDocument xmlDoc)
        {
            DockPanelColorPalette palette = Theme.ColorPalette;
            //XDocument xmlDoc = XDocument.Load(xmlFileName);
            if (null == xmlDoc)
            {
                return false;
            }


            palette.AutoHideStripDefault.Background = ColorTranslatorFromHtml(xmlDoc, "AutoHideTabBackgroundBegin");
            palette.AutoHideStripDefault.Border = ColorTranslatorFromHtml(xmlDoc, "AutoHideTabBorder");
            palette.AutoHideStripDefault.Text = ColorTranslatorFromHtml(xmlDoc, "AutoHideTabText");

            palette.AutoHideStripHovered.Background = ColorTranslatorFromHtml(xmlDoc, "AutoHideTabMouseOverBackgroundBegin");
            palette.AutoHideStripHovered.Border = ColorTranslatorFromHtml(xmlDoc, "AutoHideTabMouseOverBorder");
            palette.AutoHideStripHovered.Text = ColorTranslatorFromHtml(xmlDoc, "AutoHideTabMouseOverText");

            palette.CommandBarMenuDefault.Background = ColorTranslatorFromHtml(xmlDoc, "CommandShelfHighlightGradientBegin");
            palette.CommandBarMenuDefault.Text = ColorTranslatorFromHtml(xmlDoc, "CommandBarTextActive");

            palette.CommandBarMenuPopupDefault.Arrow = ColorTranslatorFromHtml(xmlDoc, "CommandBarMenuSubmenuGlyph");
            palette.CommandBarMenuPopupDefault.BackgroundBottom = ColorTranslatorFromHtml(xmlDoc, "CommandBarMenuBackgroundGradientEnd");
            palette.CommandBarMenuPopupDefault.BackgroundTop = ColorTranslatorFromHtml(xmlDoc, "CommandBarMenuBackgroundGradientBegin");
            palette.CommandBarMenuPopupDefault.Border = ColorTranslatorFromHtml(xmlDoc, "CommandBarMenuBorder");
            palette.CommandBarMenuPopupDefault.Checkmark = ColorTranslatorFromHtml(xmlDoc, "CommandBarCheckBox");
            palette.CommandBarMenuPopupDefault.CheckmarkBackground = ColorTranslatorFromHtml(xmlDoc, "CommandBarSelectedIcon");
            palette.CommandBarMenuPopupDefault.IconBackground = ColorTranslatorFromHtml(xmlDoc, "CommandBarMenuIconBackground");
            palette.CommandBarMenuPopupDefault.Separator = ColorTranslatorFromHtml(xmlDoc, "CommandBarMenuSeparator");

            palette.CommandBarMenuPopupDisabled.Checkmark = ColorTranslatorFromHtml(xmlDoc, "CommandBarCheckBoxDisabled");
            palette.CommandBarMenuPopupDisabled.CheckmarkBackground = ColorTranslatorFromHtml(xmlDoc, "CommandBarSelectedIconDisabled");
            palette.CommandBarMenuPopupDisabled.Text = ColorTranslatorFromHtml(xmlDoc, "CommandBarTextInactive");

            palette.CommandBarMenuPopupHovered.Arrow = ColorTranslatorFromHtml(xmlDoc, "CommandBarMenuMouseOverSubmenuGlyph");
            palette.CommandBarMenuPopupHovered.Checkmark = ColorTranslatorFromHtml(xmlDoc, "CommandBarCheckBoxMouseOver");
            palette.CommandBarMenuPopupHovered.CheckmarkBackground = ColorTranslatorFromHtml(xmlDoc, "CommandBarHoverOverSelectedIcon");
            palette.CommandBarMenuPopupHovered.ItemBackground = ColorTranslatorFromHtml(xmlDoc, "CommandBarMenuItemMouseOver");
            palette.CommandBarMenuPopupHovered.Text = ColorTranslatorFromHtml(xmlDoc, "CommandBarMenuItemMouseOver", true);

            palette.CommandBarMenuTopLevelHeaderHovered.Background = ColorTranslatorFromHtml(xmlDoc, "CommandBarMouseOverBackgroundBegin");
            palette.CommandBarMenuTopLevelHeaderHovered.Border = ColorTranslatorFromHtml(xmlDoc, "CommandBarBorder");
            palette.CommandBarMenuTopLevelHeaderHovered.Text = ColorTranslatorFromHtml(xmlDoc, "CommandBarTextHover");

            palette.CommandBarToolbarDefault.Background = ColorTranslatorFromHtml(xmlDoc, "CommandBarGradientBegin");
            palette.CommandBarToolbarDefault.Border = ColorTranslatorFromHtml(xmlDoc, "CommandBarToolBarBorder");
            palette.CommandBarToolbarDefault.Grip = ColorTranslatorFromHtml(xmlDoc, "CommandBarDragHandle");
            palette.CommandBarToolbarDefault.OverflowButtonBackground = ColorTranslatorFromHtml(xmlDoc, "CommandBarOptionsBackground");
            palette.CommandBarToolbarDefault.OverflowButtonGlyph = ColorTranslatorFromHtml(xmlDoc, "CommandBarOptionsGlyph");
            palette.CommandBarToolbarDefault.Separator = ColorTranslatorFromHtml(xmlDoc, "CommandBarToolBarSeparator");
            palette.CommandBarToolbarDefault.SeparatorAccent = ColorTranslatorFromHtml(xmlDoc, "CommandBarToolBarSeparatorHighlight");
            palette.CommandBarToolbarDefault.Tray = ColorTranslatorFromHtml(xmlDoc, "CommandShelfBackgroundGradientBegin");

            palette.CommandBarToolbarButtonChecked.Background = ColorTranslatorFromHtml(xmlDoc, "CommandBarSelected");
            palette.CommandBarToolbarButtonChecked.Border = ColorTranslatorFromHtml(xmlDoc, "CommandBarSelectedBorder");
            palette.CommandBarToolbarButtonChecked.Text = ColorTranslatorFromHtml(xmlDoc, "CommandBarTextSelected");

            palette.CommandBarToolbarButtonCheckedHovered.Border = ColorTranslatorFromHtml(xmlDoc, "CommandBarHoverOverSelectedIconBorder");
            palette.CommandBarToolbarButtonCheckedHovered.Text = ColorTranslatorFromHtml(xmlDoc, "CommandBarTextHoverOverSelected");

            palette.CommandBarToolbarButtonDefault.Arrow = ColorTranslatorFromHtml(xmlDoc, "DropDownGlyph");

            palette.CommandBarToolbarButtonHovered.Arrow = ColorTranslatorFromHtml(xmlDoc, "DropDownMouseOverGlyph");
            palette.CommandBarToolbarButtonHovered.Separator = ColorTranslatorFromHtml(xmlDoc, "CommandBarSplitButtonSeparator");

            palette.CommandBarToolbarButtonPressed.Arrow = ColorTranslatorFromHtml(xmlDoc, "DropDownMouseDownGlyph");
            palette.CommandBarToolbarButtonPressed.Background = ColorTranslatorFromHtml(xmlDoc, "CommandBarMouseDownBackgroundBegin");
            palette.CommandBarToolbarButtonPressed.Text = ColorTranslatorFromHtml(xmlDoc, "CommandBarTextMouseDown");

            palette.CommandBarToolbarOverflowHovered.Background = ColorTranslatorFromHtml(xmlDoc, "CommandBarOptionsMouseOverBackgroundBegin");
            palette.CommandBarToolbarOverflowHovered.Glyph = ColorTranslatorFromHtml(xmlDoc, "CommandBarOptionsMouseOverGlyph");

            palette.CommandBarToolbarOverflowPressed.Background = ColorTranslatorFromHtml(xmlDoc, "CommandBarOptionsMouseDownBackgroundBegin");
            palette.CommandBarToolbarOverflowPressed.Glyph = ColorTranslatorFromHtml(xmlDoc, "CommandBarOptionsMouseDownGlyph");

            palette.OverflowButtonDefault.Glyph = ColorTranslatorFromHtml(xmlDoc, "DocWellOverflowButtonGlyph");

            palette.OverflowButtonHovered.Background = ColorTranslatorFromHtml(xmlDoc, "DocWellOverflowButtonMouseOverBackground");
            palette.OverflowButtonHovered.Border = ColorTranslatorFromHtml(xmlDoc, "DocWellOverflowButtonMouseOverBorder");
            palette.OverflowButtonHovered.Glyph = ColorTranslatorFromHtml(xmlDoc, "DocWellOverflowButtonMouseOverGlyph");

            palette.OverflowButtonPressed.Background = ColorTranslatorFromHtml(xmlDoc, "DocWellOverflowButtonMouseDownBackground");
            palette.OverflowButtonPressed.Border = ColorTranslatorFromHtml(xmlDoc, "DocWellOverflowButtonMouseDownBorder");
            palette.OverflowButtonPressed.Glyph = ColorTranslatorFromHtml(xmlDoc, "DocWellOverflowButtonMouseDownGlyph");

            palette.TabSelectedActive.Background = ColorTranslatorFromHtml(xmlDoc, "FileTabSelectedBorder");
            palette.TabSelectedActive.Button = ColorTranslatorFromHtml(xmlDoc, "FileTabButtonSelectedActiveGlyph");
            palette.TabSelectedActive.Text = ColorTranslatorFromHtml(xmlDoc, "FileTabSelectedText");

            palette.TabSelectedInactive.Background = ColorTranslatorFromHtml(xmlDoc, "FileTabInactiveBorder");
            palette.TabSelectedInactive.Button = ColorTranslatorFromHtml(xmlDoc, "FileTabButtonSelectedInactiveGlyph");
            palette.TabSelectedInactive.Text = ColorTranslatorFromHtml(xmlDoc, "FileTabInactiveText");

            palette.TabUnselected.Text = ColorTranslatorFromHtml(xmlDoc, "FileTabText");
            palette.TabUnselected.Background = ColorTranslatorFromHtml(xmlDoc, "FileTabBackground");

            palette.TabUnselectedHovered.Background = ColorTranslatorFromHtml(xmlDoc, "FileTabHotBorder");
            palette.TabUnselectedHovered.Button = ColorTranslatorFromHtml(xmlDoc, "FileTabHotGlyph");
            palette.TabUnselectedHovered.Text = ColorTranslatorFromHtml(xmlDoc, "FileTabHotText");

            palette.TabButtonSelectedActiveHovered.Background = ColorTranslatorFromHtml(xmlDoc, "FileTabButtonHoverSelectedActive");
            palette.TabButtonSelectedActiveHovered.Border = ColorTranslatorFromHtml(xmlDoc, "FileTabButtonHoverSelectedActiveBorder");
            palette.TabButtonSelectedActiveHovered.Glyph = ColorTranslatorFromHtml(xmlDoc, "FileTabButtonHoverSelectedActiveGlyph");

            palette.TabButtonSelectedActivePressed.Background = ColorTranslatorFromHtml(xmlDoc, "FileTabButtonDownSelectedActive");
            palette.TabButtonSelectedActivePressed.Border = ColorTranslatorFromHtml(xmlDoc, "FileTabButtonDownSelectedActiveBorder");
            palette.TabButtonSelectedActivePressed.Glyph = ColorTranslatorFromHtml(xmlDoc, "FileTabButtonDownSelectedActiveGlyph");

            palette.TabButtonSelectedInactiveHovered.Background = ColorTranslatorFromHtml(xmlDoc, "FileTabButtonHoverSelectedInactive");
            palette.TabButtonSelectedInactiveHovered.Border = ColorTranslatorFromHtml(xmlDoc, "FileTabButtonHoverSelectedInactiveBorder");
            palette.TabButtonSelectedInactiveHovered.Glyph = ColorTranslatorFromHtml(xmlDoc, "FileTabButtonHoverSelectedInactiveGlyph");

            palette.TabButtonSelectedInactivePressed.Background = ColorTranslatorFromHtml(xmlDoc, "FileTabButtonDownSelectedInactive");
            palette.TabButtonSelectedInactivePressed.Border = ColorTranslatorFromHtml(xmlDoc, "FileTabButtonDownSelectedInactiveBorder");
            palette.TabButtonSelectedInactivePressed.Glyph = ColorTranslatorFromHtml(xmlDoc, "FileTabButtonDownSelectedInactiveGlyph");

            palette.TabButtonUnselectedTabHoveredButtonHovered.Background = ColorTranslatorFromHtml(xmlDoc, "FileTabButtonHoverInactive");
            palette.TabButtonUnselectedTabHoveredButtonHovered.Border = ColorTranslatorFromHtml(xmlDoc, "FileTabButtonHoverInactiveBorder");
            palette.TabButtonUnselectedTabHoveredButtonHovered.Glyph = ColorTranslatorFromHtml(xmlDoc, "FileTabButtonHoverInactiveGlyph");

            palette.TabButtonUnselectedTabHoveredButtonPressed.Background = ColorTranslatorFromHtml(xmlDoc, "FileTabButtonDownInactive");
            palette.TabButtonUnselectedTabHoveredButtonPressed.Border = ColorTranslatorFromHtml(xmlDoc, "FileTabButtonDownInactiveBorder");
            palette.TabButtonUnselectedTabHoveredButtonPressed.Glyph = ColorTranslatorFromHtml(xmlDoc, "FileTabButtonDownInactiveGlyph");

            palette.MainWindowActive.Background = ColorTranslatorFromHtml(xmlDoc, "EnvironmentBackground");
            palette.MainWindowStatusBarDefault.Background = ColorTranslatorFromHtml(xmlDoc, "StatusBarDefault");
            palette.MainWindowStatusBarDefault.Highlight = ColorTranslatorFromHtml(xmlDoc, "StatusBarHighlight");
            palette.MainWindowStatusBarDefault.HighlightText = ColorTranslatorFromHtml(xmlDoc, "StatusBarHighlight", true);
            palette.MainWindowStatusBarDefault.ResizeGrip = ColorTranslatorFromHtml(xmlDoc, "MainWindowResizeGripTexture1");
            palette.MainWindowStatusBarDefault.ResizeGripAccent = ColorTranslatorFromHtml(xmlDoc, "MainWindowResizeGripTexture2");
            palette.MainWindowStatusBarDefault.Text = ColorTranslatorFromHtml(xmlDoc, "StatusBarText");

            palette.ToolWindowCaptionActive.Background = ColorTranslatorFromHtml(xmlDoc, "TitleBarActiveBorder");
            palette.ToolWindowCaptionActive.Button = ColorTranslatorFromHtml(xmlDoc, "ToolWindowButtonActiveGlyph");
            palette.ToolWindowCaptionActive.Grip = ColorTranslatorFromHtml(xmlDoc, "TitleBarDragHandleActive");
            palette.ToolWindowCaptionActive.Text = ColorTranslatorFromHtml(xmlDoc, "TitleBarActiveText");

            palette.ToolWindowCaptionInactive.Background = ColorTranslatorFromHtml(xmlDoc, "TitleBarInactive");
            palette.ToolWindowCaptionInactive.Button = ColorTranslatorFromHtml(xmlDoc, "ToolWindowButtonInactiveGlyph");
            palette.ToolWindowCaptionInactive.Grip = ColorTranslatorFromHtml(xmlDoc, "TitleBarDragHandle");
            palette.ToolWindowCaptionInactive.Text = ColorTranslatorFromHtml(xmlDoc, "TitleBarInactiveText");

            palette.ToolWindowCaptionButtonActiveHovered.Background = ColorTranslatorFromHtml(xmlDoc, "ToolWindowButtonHoverActive");
            palette.ToolWindowCaptionButtonActiveHovered.Border = ColorTranslatorFromHtml(xmlDoc, "ToolWindowButtonHoverActiveBorder");
            palette.ToolWindowCaptionButtonActiveHovered.Glyph = ColorTranslatorFromHtml(xmlDoc, "ToolWindowButtonHoverActiveGlyph");

            palette.ToolWindowCaptionButtonPressed.Background = ColorTranslatorFromHtml(xmlDoc, "ToolWindowButtonDown");
            palette.ToolWindowCaptionButtonPressed.Border = ColorTranslatorFromHtml(xmlDoc, "ToolWindowButtonDownBorder");
            palette.ToolWindowCaptionButtonPressed.Glyph = ColorTranslatorFromHtml(xmlDoc, "ToolWindowButtonDownActiveGlyph");

            palette.ToolWindowCaptionButtonInactiveHovered.Background = ColorTranslatorFromHtml(xmlDoc, "ToolWindowButtonHoverInactive");
            palette.ToolWindowCaptionButtonInactiveHovered.Border = ColorTranslatorFromHtml(xmlDoc, "ToolWindowButtonHoverInactiveBorder");
            palette.ToolWindowCaptionButtonInactiveHovered.Glyph = ColorTranslatorFromHtml(xmlDoc, "ToolWindowButtonHoverInactiveGlyph");

            palette.ToolWindowTabSelectedActive.Background = ColorTranslatorFromHtml(xmlDoc, "ToolWindowTabSelectedTab");
            palette.ToolWindowTabSelectedActive.Text = ColorTranslatorFromHtml(xmlDoc, "ToolWindowTabSelectedActiveText");

            palette.ToolWindowTabSelectedInactive.Background = palette.ToolWindowTabSelectedActive.Background;
            palette.ToolWindowTabSelectedInactive.Text = ColorTranslatorFromHtml(xmlDoc, "ToolWindowTabSelectedText");

            palette.ToolWindowTabUnselected.Text = ColorTranslatorFromHtml(xmlDoc, "ToolWindowTabText");
            palette.ToolWindowTabUnselected.Background = ColorTranslatorFromHtml(xmlDoc, "ToolWindowTabGradientBegin");

            palette.ToolWindowTabUnselectedHovered.Background = ColorTranslatorFromHtml(xmlDoc, "ToolWindowTabMouseOverBackgroundBegin");
            palette.ToolWindowTabUnselectedHovered.Text = ColorTranslatorFromHtml(xmlDoc, "ToolWindowTabMouseOverText");

            palette.ToolWindowSeparator = ColorTranslatorFromHtml(xmlDoc, "ToolWindowTabSeparator");
            palette.ToolWindowBorder = ColorTranslatorFromHtml(xmlDoc, "ToolWindowBorder");

            palette.DockTarget.Background = ColorTranslatorFromHtml(xmlDoc, "DockTargetBackground");
            palette.DockTarget.Border = ColorTranslatorFromHtml(xmlDoc, "DockTargetBorder");
            palette.DockTarget.ButtonBackground = ColorTranslatorFromHtml(xmlDoc, "DockTargetButtonBackgroundBegin");
            palette.DockTarget.ButtonBorder = ColorTranslatorFromHtml(xmlDoc, "DockTargetButtonBorder");
            palette.DockTarget.GlyphBackground = ColorTranslatorFromHtml(xmlDoc, "DockTargetGlyphBackgroundBegin");
            palette.DockTarget.GlyphArrow = ColorTranslatorFromHtml(xmlDoc, "DockTargetGlyphArrow");
            palette.DockTarget.GlyphBorder = ColorTranslatorFromHtml(xmlDoc, "DockTargetGlyphBorder");

            return true;
        }
    }
}
