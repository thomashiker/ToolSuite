/**
* MetroSet UI - MetroSet UI Framewrok
* 
* The MIT License (MIT)
* Copyright (c) 2017 Narwin, https://github.com/N-a-r-w-i-n
* 
* Permission is hereby granted, free of charge, to any person obtaining a copy of 
* this software and associated documentation files (the "Software"), to deal in the 
* Software without restriction, including without limitation the rights to use, copy, 
* modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, 
* and to permit persons to whom the Software is furnished to do so, subject to the 
* following conditions:
* 
* The above copyright notice and this permission notice shall be included in 
* all copies or substantial portions of the Software.
* 
* THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, 
* INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A 
* PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT 
* HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF 
* CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE 
* OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
*/

using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Text;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Security;


namespace ControlsLibrary
{
    [ToolboxItem(true)]
    [ToolboxBitmap(typeof(MetroMenuButton), "Bitmaps.MetroMenuButton.bmp")]
    [DefaultProperty("Click")]
    [ComVisible(true)]
    [ClassInterface(ClassInterfaceType.AutoDispatch)]
    public class MetroMenuButton : Control
    {
        #region Interface

        #endregion

        #region Constructors

        public MetroMenuButton()
        {
            SetStyle(
                ControlStyles.ResizeRedraw |
                ControlStyles.OptimizedDoubleBuffer |
                ControlStyles.SupportsTransparentBackColor, true);
            DoubleBuffered = true;
            UpdateStyles();

            Anchor = AnchorStyles.Top | AnchorStyles.Right;
            Size = new Size(27, 20);
        }

        #endregion Constructors

        #region Properties

        #region Public

        private Font _font = new Font("Marlett", 12);
        /// <summary>
        /// Gets or sets font
        /// </summary>
        [Browsable(true)]
        [Category("Customize")]
        public Font ButtonFont
        {
            get { return _font; }
            set
            {
                _font = value;
                Invalidate();
            }
        }

        private string _text;
        /// <summary>
        /// Gets or sets text
        /// </summary>
        [Category("Customize")]
        public override string Text
        {
            get { return _text; }
            set
            {
                _text = value;
                Invalidate();
            }
        }

        private Image _image;
        /// <summary>
        /// Gets or sets image
        /// </summary>
        [Category("Customize")]
        public Image Image
        {
            get { return _image; }
            set
            {
                _image = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets image
        /// </summary>
        [Category("Customize")]
        public bool ShowImage { get; set; } = true;

        /// <summary>
        /// Gets or sets ContextMenuStrip
        /// </summary>
        [Category("Customize")]
        public ContextMenuStrip menu { get; set; }

        /// <summary>
        /// Gets or sets Minimize forecolor used by the control
        /// </summary>
        [Category("Customize")]
        public Color HoverForeColor { get; set; } = Color.White;

        /// <summary>
        /// Gets or sets Minimize forecolor used by the control
        /// </summary>
        [Category("Customize")]
        public Color PressedForeColor { get; set; } = Color.Black;

        /// <summary>
        /// Gets or sets Minimize backcolor used by the control
        /// </summary>
        [Category("Customize")]
        public Color HoverBackColor { get; set; } = Color.Blue;

        /// <summary>
        /// Gets or sets Minimize backcolor used by the control
        /// </summary>
        [Category("Customize")]
        public Color PressedBackColor { get; set; } = Color.Blue;

        /// <summary>
        /// Gets or sets Minimize forecolor used by the control
        /// </summary>
        [Category("Customize")]
        public Color NormalForeColor { get; set; } = Color.Black;

        /// <summary>
        /// Gets or sets Minimize forecolor used by the control
        /// </summary>
        [Category("Customize")]
        public Color NormalBackColor { get; set; } = Color.White;

        /// <summary>
        /// Gets or sets disabled forecolor used by the control
        /// </summary>
        [Category("Customize")]
        public Color CheckedColor { get; set; } = Color.Black;

        /// <summary>
        /// Gets or sets disabled forecolor used by the control
        /// </summary>
        [Category("Customize")]
        public bool ShowBorder { get; set; } = true;

        /// <summary>
        /// Gets or sets disabled forecolor used by the control
        /// </summary>
        [Category("Customize")]
        public Color BorderColor { get; set; } = Color.Black;

        /// <summary>
        /// Gets or sets disabled forecolor used by the control
        /// </summary>
        [Category("Customize")]
        public Color DisabledForeColor { get; set; } = Color.Transparent;
        
        /// <summary>
        /// I make backcolor inaccessible cause we have not use of it. 
        /// </summary>
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public override Color BackColor
        {
            get { return Color.Transparent; }
        }

        /// <summary>
        /// Gets or sets checked
        /// </summary>
        [Category("Customize")]
        public bool Checked
        {
            get { return _checked; }
            set
            {
                _checked = value;
                Invalidate();
            }
        }

        /// <summary>
        /// checked
        /// </summary>
        [Category("Customize")]
        public bool CheckedEnable { get; set; } = false;


        [Category("Customize")]
        public event EventHandler CheckedHander;


        #endregion

        #region Private 

        private bool Hovered { get; set; } = false;
        private bool Pressed { get; set; } = false;
        private bool _checked { get; set; } = false;


        #endregion

        #endregion

        #region Draw Control

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics G = e.Graphics;
            G.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;

            //Color hoverBackColor = HoverBackColor;
            Color foreColor = NormalForeColor;
            Color backColor = NormalBackColor;
            if (Hovered && !Pressed)
            {
                foreColor = HoverForeColor;
                backColor = HoverBackColor;
            }
            else if (Hovered && Pressed)
            {
                foreColor = PressedForeColor;
                backColor = PressedBackColor;
            }

            if (CheckedEnable && Checked)
            {
                backColor = CheckedColor;
            }

         
            using (SolidBrush SB = new SolidBrush(backColor))
            {
                using (Font F = new Font(ButtonFont, ButtonFont.Style))
                {
                    using (SolidBrush TB = new SolidBrush(foreColor))
                    {
                        using (StringFormat SF = new StringFormat { Alignment = StringAlignment.Center })
                        {
                            G.FillRectangle(SB, new Rectangle(0, 0, Width-1, Height-1));
                            G.DrawString(Text, F, TB, new Point(Width/2+ Padding.Left, 3 + Padding.Top - Padding.Bottom), SF);
                        }

                        if (null != Image && ShowImage)
                        {
                            G.DrawImage(Image, new Rectangle((Width - Image.Width)/2, (Height - Image.Height) / 2, Image.Width, Image.Height ));
                        }
                    }
                }
            }

            if (ShowBorder)
            {
                using (Pen pen = new Pen(BorderColor))
                {
                    G.DrawRectangle(pen, new Rectangle(0, 0, Width - 1, Height - 1));
                }
            }
        }

        #endregion

        #region Events

        public void PerformClick()
        {
            EventArgs e = new EventArgs();
            OnClick(e);
        }

        /// <summary>
        /// Here we provide the fixed size while resizing.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
        }

        /// <summary>
        /// Handling mouse up event of the cotnrol so that we detect if cursor located in our need area.
        /// </summary>
        /// <param name="e">MouseEventArgs</param>
        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);

            bool active = false;
            if (e.Location.Y > 0 && e.Location.Y < Height)
            {
                if (e.Location.X > 0 && e.Location.X < Width)
                {
                    Cursor = Cursors.Hand;
                    Hovered = true;
                    active = true;
                }

                if (!active)
                {
                    Cursor = Cursors.Arrow;
                    Hovered = false;
                }
            }
            Invalidate();
        }

        /// <summary>
        /// Handling mouse up event of the cotnrol so that we can perform action commands.
        /// </summary>
        /// <param name="e">MouseEventArgs</param>
        protected override void OnMouseUp(MouseEventArgs e)
        {
            Pressed = false;
            base.OnMouseDown(e);
            Invalidate();
        }

        /// <summary>
        /// Handling mouse leave event of the cotnrol.
        /// </summary>
        /// <param name="e">EventArgs</param>
        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            Cursor = Cursors.Default;
            Hovered = false;
            Invalidate();
        }

        /// <summary>
        /// Handling mouse down event of the cotnrol.
        /// </summary>
        /// <param name="e">MouseEventArgs</param>
        protected override void OnMouseDown(MouseEventArgs e)
        {
            Pressed = true;
            Checked = !Checked;
            if (null != CheckedHander)
            {
                CheckedHander(this, EventArgs.Empty);
            }
            base.OnMouseDown(e);
            Focus();
            Invalidate();

            if (null != menu)
            {
                menu.Show(this, 0, this.Height);
            }   
        }

        #endregion

    }
}