using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace ControlLibrary
{
    public partial class TextBoxWithTitle : UserControl
    {
        public string Title
        {
            get { return titleTextBox.Text; }
            set { titleTextBox.Text = value; }
        }

        public string TitleWaterMark
        {
            get { return titleTextBox.WatermarkText; }
            set { titleTextBox.WatermarkText = value; }
        }

        public string Content
        {
            get { return contentTextBox.Text; }
            set { contentTextBox.Text = value; }
        }

        public override Color BackColor
        {
            get { return base.BackColor; }
            set
            {
                base.BackColor = value;
                titleTextBox.BackColor = value;
                contentTextBox.BackColor = value;
                BorderColor = value;
            }
        }

        public Color BorderColor
        {
            get { return titleTextBox.BorderColor; }
            set
            {
                titleTextBox.BorderColor = value;
                contentTextBox.BorderColor = value;
            }
        }

        public Color DividerColor
        {
            get { return divider.BackColor; }
            set
            {
                divider.BackColor = value;
            }
        }

        public TextBoxWithTitle()
        {
            InitializeComponent();
            BackColor = Color.White;
        }
    }
}
