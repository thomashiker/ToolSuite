using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MetroFramework.Forms;
using MetroFramework.Controls;
using WeifenLuo.WinFormsUI.Docking;

namespace ToolSuite
{
    public partial class AppearanceSetting : MetroCForm
    {
        private MainForm ThemeOwner;
        private CustomStyle customStyle = new CustomStyle();

        public AppearanceSetting(MainForm parent)
        {
            InitializeComponent();

            ThemeOwner = parent;
            customStyle.Clone(ThemeOwner.MyStyle);
        }

        private void SetTheme(Color theme)
        {
            if (null != ThemeOwner)
            {
                ThemeOwner.SetTheme(theme);
            }
        }

        private void SetStyle(Color style)
        {
            if (null != ThemeOwner)
            {
                ThemeOwner.SetStyle(style);
            }
        }

        private void SetItemColor(Color color)
        {
            if (btMenu.Text == "theme")
            {
                SetTheme(color);
            }
            if (btMenu.Text == "style")
            {
                SetStyle(color);
                BorderColor = color == Color.Transparent ? Color.White : color;
            }
            if (btMenu.Text == "Background")
            {
                customStyle.TextBoxBackColor = color;
                ThemeOwner.MyStyle = customStyle;
            }
            if (btMenu.Text == "Indent")
            {
                customStyle.IndentBackColor = color;
                ThemeOwner.MyStyle = customStyle;
            }
            if (btMenu.Text == "Caret")
            {
                customStyle.CaretColor = color;
                ThemeOwner.MyStyle = customStyle;
            }
            if (btMenu.Text == "Bookmark")
            {
                customStyle.BookmarkColor = color;
                ThemeOwner.MyStyle = customStyle;
            }
            if (btMenu.Text == "Selection")
            {
                customStyle.SelectionColor = color;
                ThemeOwner.MyStyle = customStyle;
            }
            if (btMenu.Text == "Line Number")
            {
                customStyle.LineNumColor = color;
                ThemeOwner.MyStyle = customStyle;
            }
            if (btMenu.Text == "Text")
            {
                customStyle.TextColor = color;
                ThemeOwner.MyStyle = customStyle;
            }
            if (btMenu.Text == "Service Line")
            {
                customStyle.ServiceLineColor = color;
                ThemeOwner.MyStyle = customStyle;
            }
        }

        public Color SelectedItemColor
        {
            get { return btMenu.BackColor; }
            set
            {
                btMenu.BackColor = value;
                btMenu.FlatAppearance.BorderColor = value == Color.Transparent ? Color.White : value;
                btMenu.FlatAppearance.MouseOverBackColor = ColorConvert.ChangeColor(value, 0.2f);
                btMenu.FlatAppearance.MouseDownBackColor = ColorConvert.ChangeColor(value, -0.1f);
                SetItemColor(value);
            }
        }

        private void btHide_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Hide();
        }

        private void btMenu_Click(object sender, EventArgs e)
        {
            selectMenu.Show(Cursor.Position);
        }

        private void selectMenu_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            btMenu.Text = e.ClickedItem.Text;
            btMenu.Tag = e.ClickedItem;

            if (e.ClickedItem.Text == "theme")
            {
                SelectedColor = ThemeOwner.DockPanelTheme.ColorPalette.CommandBarToolbarDefault.Background;
            }
            if (e.ClickedItem.Text == "style")
            {
                SelectedColor = ThemeOwner.DockPanelTheme.ColorPalette.MainWindowStatusBarDefault.Background;
            }
        }

        private void textToolStripMenuItem_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            btMenu.Text = e.ClickedItem.Text;
            btMenu.Tag = e.ClickedItem;

            if (e.ClickedItem.Text == "Background")
            {
                SelectedColor = customStyle.TextBoxBackColor;
            }
            if (e.ClickedItem.Text == "Indent")
            {
                SelectedColor = customStyle.IndentBackColor;
            }
            if (e.ClickedItem.Text == "Caret")
            {
                SelectedColor = customStyle.CaretColor;
            }
            if (e.ClickedItem.Text == "Bookmark")
            {
                SelectedColor = customStyle.BookmarkColor;
            }
            if (e.ClickedItem.Text == "Selection")
            {
                SelectedColor = customStyle.SelectionColor;
            }
            if (e.ClickedItem.Text == "Line Number")
            {
                SelectedColor = customStyle.LineNumColor;
            }
            if (e.ClickedItem.Text == "Text")
            {
                SelectedColor = customStyle.TextColor;
            }
            if (e.ClickedItem.Text == "Service Line")
            {
                SelectedColor = customStyle.ServiceLineColor;
            }
        }

        public Color SelectedColor
        {
            get { return colorEditorManager.Color; }
            set { colorEditorManager.Color = value; }
        }
        private void colorEditorManager_ColorChanged(object sender, EventArgs e)
        {
            SelectedItemColor = SelectedColor;
        }
    }
}
