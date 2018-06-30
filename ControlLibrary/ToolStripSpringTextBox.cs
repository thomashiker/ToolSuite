using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ControlsLibrary
{
    public partial class ToolStripSpringTextBox : ToolStripTextBox
    {
        Color borderColor = Color.Black;

        [Description("border color"), Category("Customize")]
        public Color BorderColor
        {
            get { return borderColor; }
            set
            {
                borderColor = value;
                Invalidate();
            }
        }

        [Description("minimum"), Category("Customize")]
        public int Minimum { get; set; } = 200;

        [Description("Spring"), Category("Customize")]
        public bool Spring { get; set; } = true;

        [Description("ContextMenuStrip"), Category("Customize")]
        public ContextMenuStrip ContextMenuStrip
        {
            get { return TextBox.ContextMenuStrip;}
            set
            {
                TextBox.ContextMenuStrip = (null == value) ? menu : value;
            }
        }

        private ContextMenuStrip menu = new ContextMenuStrip();
        private ToolStripMenuItem copyItem = new ToolStripMenuItem("Copy");
        private ToolStripMenuItem pasteItem = new ToolStripMenuItem("Paste");
        private ToolStripMenuItem clearItem = new ToolStripMenuItem("Clear");

        public ToolStripSpringTextBox()
        {
            InitializeComponent();
            BorderStyle = BorderStyle.None;
            AutoSize = false;

            menu.Items.Add(copyItem);
            menu.Items.Add(pasteItem);
            menu.Items.Add(clearItem);

            copyItem.Click += ToolStripMenuItem_Changed;
            pasteItem.Click += ToolStripMenuItem_Changed;
            clearItem.Click += ToolStripMenuItem_Changed;

            TextBox.ContextMenuStrip = menu;
            TextBox.SizeChanged += textBox_SizeChanged;
        }

        private void textBox_SizeChanged(object sender, EventArgs e)
        {
            Size = new Size(Size.Width, TextBox.Size.Height + 2);
        }

        protected override void OnParentChanged(ToolStrip oldParent, ToolStrip newParent)
        {
            base.OnParentChanged(oldParent, newParent);

            if (null != oldParent)
            {
                oldParent.RendererChanged -= ownerRenderer_Changed;
                oldParent.SizeChanged += Parent_SizeChanged;
            }

            if (null != newParent)
            {
                TextBox.ContextMenuStrip.Renderer = newParent.Renderer;
                newParent.RendererChanged += ownerRenderer_Changed;
                newParent.SizeChanged += Parent_SizeChanged;
            }
        }

        private void ownerRenderer_Changed(object sender, EventArgs e)
        {
            TextBox.ContextMenuStrip.Renderer = Owner.Renderer;
        }

        private void ToolStripMenuItem_Changed(object sender, EventArgs e)
        {
            if (sender == copyItem)
            {
                Copy();
            }
            else if (sender == pasteItem)
            {
                Paste();
            }
            else if (sender == clearItem)
            {
                Clear();
            }
        }

        public void OnResize()
        {
            Parent_SizeChanged(this, EventArgs.Empty);
        }

        private void Parent_SizeChanged(object sender, EventArgs e)
        {
            if (Spring)
            {
                Size size = new Size(Minimum, Size.Height);
                Size = GetPreferredSize(size);
            }
        }

        public override Size GetPreferredSize(Size constrainingSize)
        {
            // Use the default size if the text box is on the overflow menu
            // or is on a vertical ToolStrip.
            if (IsOnOverflow || Owner.Orientation == Orientation.Vertical)
            {
                return DefaultSize;
            }

            // Declare a variable to store the total available width as 
            // it is calculated, starting with the display width of the 
            // owning ToolStrip.
            Int32 width = Owner.DisplayRectangle.Width;

            // Subtract the width of the overflow button if it is displayed. 
            if (Owner.OverflowButton.Visible)
            {
                width = width - Owner.OverflowButton.Width -
                    Owner.OverflowButton.Margin.Horizontal;
            }

            // Declare a variable to maintain a count of ToolStripSpringTextBox 
            // items currently displayed in the owning ToolStrip. 
            Int32 springBoxCount = 0;

            foreach (ToolStripItem item in Owner.Items)
            {
                // Ignore items on the overflow menu.
                if (item.IsOnOverflow) continue;

                if (item is ToolStripSpringTextBox)
                {
                    // For ToolStripSpringTextBox items, increment the count and 
                    // subtract the margin width from the total available width.
                    springBoxCount++;
                    width -= item.Margin.Horizontal;
                }
                else
                {
                    // For all other items, subtract the full width from the total
                    // available width.
                    width = width - item.Width - item.Margin.Horizontal;
                }
            }

            // If there are multiple ToolStripSpringTextBox items in the owning
            // ToolStrip, divide the total available width between them. 
            if (springBoxCount > 1) width /= springBoxCount;

            // If the available width is less than the default width, use the
            // default width, forcing one or more items onto the overflow menu.
            if (width < DefaultSize.Width) width = DefaultSize.Width;

            // Retrieve the preferred size from the base class, but change the
            // width to the calculated width. 
            //Size size = base.GetPreferredSize(constrainingSize);
            //size.Width = width;
            return new Size(width, Size.Height);// size;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            try
            {
                base.OnPaint(e);

                using (Pen p = new Pen(BorderColor))
                {
                    e.Graphics.DrawRectangle(p, new Rectangle(0, 0, TextBox.Size.Width + 1, TextBox.Size.Height+ 1));//Height - 5
                }
            }
            catch
            {
                Invalidate();
            }
        }
    }
}
