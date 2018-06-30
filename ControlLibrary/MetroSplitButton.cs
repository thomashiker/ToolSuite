using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Text;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Security;

namespace ControlLibrary
{
    [ToolboxItem(true)]
    [ToolboxBitmap(typeof(MetroSplitButton), "Bitmaps.MetroMenuButton.bmp")]
    [DefaultProperty("Click")]
    [ComVisible(true)]
    [ClassInterface(ClassInterfaceType.AutoDispatch)]
    public class MetroSplitButton : Control
    {
        #region Interface

        #endregion

        #region Constructors

        public MetroSplitButton()
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

        private int buttonWidth = 20;
        /// <summary>
        /// Gets or sets font
        /// </summary>
        [Browsable(true)]
        [Category("Customize")]
        public int ButtonWidth
        {
            get { return buttonWidth; }
            set
            {
                buttonWidth = value;
                Width = buttonWidth + SplitWidth;
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
        /// Gets or sets Minimize forecolor used by the control
        /// </summary>
        [Category("Customize")]
        public Color NormalForeColor { get; set; } = Color.Black;

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
        [Category("Split")]
        public int SplitWidth { get; set; } = 10;

        /// <summary>
        /// Gets or sets checked
        /// </summary>
        [Category("Split")]
        public int SplitBottom { get; set; } = 5;

        /// <summary>
        /// Gets or sets checked
        /// </summary>
        [Category("Split")]
        public int SplitLeft { get; set; } = 0;



        #endregion

        #region Private 

        private bool Hovered { get; set; } = false;
        private bool Pressed { get; set; } = false;
        private bool SplitHovered { get; set; } = false;
        private bool SplitPressed { get; set; } = false;


        #endregion

        #endregion

        #region Draw Control

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics G = e.Graphics;
            G.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;

            Color hoverBackColor = HoverBackColor;
            Color foreColor = NormalForeColor;
            if ((Hovered && !Pressed) || (SplitHovered && !SplitPressed))
            {
                foreColor = HoverForeColor;
            }
            else if ((Hovered && Pressed) || (SplitHovered && SplitPressed))
            {
                foreColor = PressedForeColor;
            }
            if (ShowBorder)
            {
                using (Pen pen = new Pen(BorderColor))
                {
                    G.DrawRectangle(pen, new Rectangle(0, 0, Width - 1, Height - 1));
                    G.DrawLine(pen, ButtonWidth, 0, ButtonWidth, Height - 1);
                }
            }

            using (SolidBrush SB = new SolidBrush(SplitHovered ? hoverBackColor : Color.Transparent))
            {
                using (Font F = new Font("Marlett", 8.5f))
                {
                    using (SolidBrush TB = new SolidBrush(foreColor))
                    {
                        using (StringFormat SF = new StringFormat { Alignment = StringAlignment.Center })
                        {
                            G.FillRectangle(SB, new Rectangle(ButtonWidth+1, 1, SplitWidth-2, Height-2));
                            G.DrawString("6", F, TB, new Point(ButtonWidth + SplitWidth / 2 + SplitLeft, Height / 2 - SplitBottom), SF);
                        }
                    }
                }
            }


            using (SolidBrush SB = new SolidBrush(Hovered ? hoverBackColor : Color.Transparent))
            {
                using (Font F = new Font(ButtonFont, ButtonFont.Style))
                {
                    using (SolidBrush TB = new SolidBrush(foreColor))
                    {
                        using (StringFormat SF = new StringFormat { Alignment = StringAlignment.Center })
                        {
                            G.FillRectangle(SB, new Rectangle(1, 1, ButtonWidth-1, Height-2));
                            G.DrawString(Text, F, TB, new Point(ButtonWidth / 2 + Padding.Left, 3 + Padding.Top - Padding.Bottom), SF);
                        }

                        if (null != Image)
                        {
                            G.DrawImage(Image, new Rectangle((ButtonWidth - Image.Width) / 2, (Height - Image.Height) / 2, Image.Width, Image.Height));
                        }
                    }
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

            if (e.Location.Y > 0 && e.Location.Y < Height)
            {
                if (e.Location.X > 0 && e.Location.X < ButtonWidth)
                {
                    Cursor = Cursors.Hand;
                    Hovered = true;
                }
                else
                {
                    Cursor = Cursors.Arrow;
                    Hovered = false;
                }

                if (e.Location.X > ButtonWidth && e.Location.X < Width)
                {
                    Cursor = Cursors.Hand;
                    SplitHovered = true;
                }
                else
                {
                    Cursor = Cursors.Arrow;
                    SplitHovered = false;
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
            SplitPressed = false;
            base.OnMouseUp(e);
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
            SplitHovered = false;
            Invalidate();
        }

        /// <summary>
        /// Handling mouse down event of the cotnrol.
        /// </summary>
        /// <param name="e">MouseEventArgs</param>
        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (e.Location.Y > 0 && e.Location.Y < Height)
            {
                if (e.Location.X > 0 && e.Location.X < ButtonWidth)
                {
                    Pressed = true;
                }
                else
                {
                    Pressed = false;
                }

                if (e.Location.X > ButtonWidth && e.Location.X < Width)
                {
                    SplitPressed = true;
                }
                else
                {
                    SplitPressed = false;
                }
            }

            //Pressed = true;
            //SplitPressed = true;

            if (SplitPressed)
            {
                menu?.Show(this, 0, this.Height-1);
            }
            else
            {
                menu?.Hide();
                base.OnMouseDown(e);
            }
            
            Focus();
            Invalidate();
        }

        #endregion

    }
}
