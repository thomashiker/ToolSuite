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

using MetroFramework.Components;
using MetroFramework.Interfaces;
using MetroFramework.Drawing;
using MetroFramework.Native;


namespace MetroFramework.Controls
{
    [ToolboxItem(true)]
    [ToolboxBitmap(typeof(MetroMenuButton), "Bitmaps.MetroMenuButton.bmp")]
    [DefaultProperty("Click")]
    [ComVisible(true)]
    [ClassInterface(ClassInterfaceType.AutoDispatch)]
    public class MetroMenuButton : Control, IMetroControl
    {
        #region Interface

        [Category(MetroDefaults.PropertyCategory.Appearance)]
        public event EventHandler<MetroPaintEventArgs> CustomPaintBackground;
        protected virtual void OnCustomPaintBackground(MetroPaintEventArgs e)
        {
            if (GetStyle(ControlStyles.UserPaint) && CustomPaintBackground != null)
            {
                CustomPaintBackground(this, e);
            }
        }

        [Category(MetroDefaults.PropertyCategory.Appearance)]
        public event EventHandler<MetroPaintEventArgs> CustomPaint;
        protected virtual void OnCustomPaint(MetroPaintEventArgs e)
        {
            if (GetStyle(ControlStyles.UserPaint) && CustomPaint != null)
            {
                CustomPaint(this, e);
            }
        }

        [Category(MetroDefaults.PropertyCategory.Appearance)]
        public event EventHandler<MetroPaintEventArgs> CustomPaintForeground;
        protected virtual void OnCustomPaintForeground(MetroPaintEventArgs e)
        {
            if (GetStyle(ControlStyles.UserPaint) && CustomPaintForeground != null)
            {
                CustomPaintForeground(this, e);
            }
        }

        private MetroColorStyle metroStyle = MetroColorStyle.Default;
        [Category(MetroDefaults.PropertyCategory.Appearance)]
        [DefaultValue(MetroColorStyle.Default)]
        public MetroColorStyle Style
        {
            get
            {
                if (DesignMode || metroStyle != MetroColorStyle.Default)
                {
                    return metroStyle;
                }

                if (StyleManager != null && metroStyle == MetroColorStyle.Default)
                {
                    return StyleManager.Style;
                }
                if (StyleManager == null && metroStyle == MetroColorStyle.Default)
                {
                    return MetroDefaults.Style;
                }

                return metroStyle;
            }
            set { metroStyle = value; }
        }

        private MetroThemeStyle metroTheme = MetroThemeStyle.Default;
        [Category(MetroDefaults.PropertyCategory.Appearance)]
        [DefaultValue(MetroThemeStyle.Default)]
        public MetroThemeStyle Theme
        {
            get
            {
                if (DesignMode || metroTheme != MetroThemeStyle.Default)
                {
                    return metroTheme;
                }

                if (StyleManager != null && metroTheme == MetroThemeStyle.Default)
                {
                    return StyleManager.Theme;
                }
                if (StyleManager == null && metroTheme == MetroThemeStyle.Default)
                {
                    return MetroDefaults.Theme;
                }

                return metroTheme;
            }
            set { metroTheme = value; }
        }

        private MetroStyleManager metroStyleManager = null;
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public MetroStyleManager StyleManager
        {
            get { return metroStyleManager; }
            set { metroStyleManager = value; }
        }

        private bool useCustomBackColor = false;
        [DefaultValue(false)]
        [Category(MetroDefaults.PropertyCategory.Appearance)]
        public bool UseCustomBackColor
        {
            get { return useCustomBackColor; }
            set { useCustomBackColor = value; }
        }

        private bool _useCustomForeColor = false;
        [DefaultValue(false)]
        [Category(MetroDefaults.PropertyCategory.Appearance)]
        public bool UseCustomForeColor
        {
            get { return _useCustomForeColor; }
            set { _useCustomForeColor = value; }
        }

        private bool useStyleColors = false;
        [DefaultValue(false)]
        [Category(MetroDefaults.PropertyCategory.Appearance)]
        public bool UseStyleColors
        {
            get { return useStyleColors; }
            set { useStyleColors = value; }
        }

        [Browsable(false)]
        [Category(MetroDefaults.PropertyCategory.Behaviour)]
        [DefaultValue(false)]
        public bool UseSelectable
        {
            get { return GetStyle(ControlStyles.Selectable); }
            set { SetStyle(ControlStyles.Selectable, value); }
        }

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

        private Font _font = new Font("Marlett", 10);
        /// <summary>
        /// Gets or sets font
        /// </summary>
        [Category("MetroFramework"), Description("Gets or sets font.")]
        public override Font Font
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
        [Category("MetroFramework"), Description("Gets or sets text.")]
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
        [Category("MetroFramework"), Description("Gets or sets image.")]
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
        [Category("MetroFramework"), Description("Gets or sets ContextMenuStrip.")]
        public ContextMenuStrip menu { get; set; }

        /// <summary>
        /// Gets or sets Minimize forecolor used by the control
        /// </summary>
        [Category("MetroFramework"), Description("Gets or sets Minimize forecolor used by the control.")]
        public Color HoverForeColor { get; set; } = Color.White;

        /// <summary>
        /// pressed fore color
        /// </summary>
        [Category("MetroFramework"), Description("pressed fore color.")]
        public Color PressedForeColor { get; set; } = Color.Black;

        /// <summary>
        /// Gets or sets Minimize backcolor used by the control
        /// </summary>
        [Category("MetroFramework"), Description("Gets or sets Minimize backcolor used by the control.")]
        public Color HoverBackColor { get; set; } = Color.Blue;

        /// <summary>
        /// Gets or sets Minimize forecolor used by the control
        /// </summary>
        [Category("MetroFramework"), Description("Gets or sets Minimize forecolor used by the control.")]
        public Color NormalForeColor { get; set; } = Color.Black;

        /// <summary>
        /// checked color
        /// </summary>
        [Category("MetroFramework"), Description("checked color.")]
        public Color CheckedColor { get; set; } = Color.Black;

        /// <summary>
        /// show border
        /// </summary>
        [Category("MetroFramework"), Description("show border.")]
        public bool ShowBorder { get; set; } = true;

        /// <summary>
        /// border color
        /// </summary>
        [Category("MetroFramework"), Description("border color.")]
        public Color BorderColor { get; set; } = Color.Black;

        /// <summary>
        /// Gets or sets disabled forecolor used by the control
        /// </summary>
        [Category("MetroFramework"), Description("Gets or sets disabled forecolor used by the control.")]
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
        /// Gets or sets disabled forecolor used by the control
        /// </summary>
        [Category("MetroFramework"), Description("Use Custom Style.")]
        public bool UseCustomStyle { get; set; } = true;

        #endregion

        #region Private 

        private bool MinimizeHovered { get; set; } = false;


        #endregion

        #endregion

        #region Draw Control

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics G = e.Graphics;
            G.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;

            Color hoverBackColor = UseCustomStyle ? HoverBackColor : MetroPaint.GetStyleColor(metroStyleManager.Style);
            using (SolidBrush SB = new SolidBrush(MinimizeHovered ? hoverBackColor : Color.Transparent))
            {
                using (Font F = new Font(Font, FontStyle.Regular))//new Font("Marlett", 10)
                {
                    using (SolidBrush TB = new SolidBrush(MinimizeHovered ? HoverForeColor : NormalForeColor))
                    {
                        using (StringFormat SF = new StringFormat { Alignment = StringAlignment.Center })
                        {
                            G.FillRectangle(SB, new Rectangle(0, 0, Width, Height));
                            G.DrawString(Text, F, TB, new Point(Width/2, 3), SF);//"0"
                        }

                        if (null != Image)
                        {
                            G.DrawImage(Image, new Rectangle((Width - Image.Width)/2, (Height - Image.Height) / 2, Image.Width, Image.Height ));
                        }
                    }
                }
            }
        }

        #endregion

        #region Events

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
                    MinimizeHovered = true;
                    active = true;
                }

                if (!active)
                {
                    Cursor = Cursors.Arrow;
                    MinimizeHovered = false;
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
            base.OnMouseDown(e);
        }

        /// <summary>
        /// Handling mouse leave event of the cotnrol.
        /// </summary>
        /// <param name="e">EventArgs</param>
        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            Cursor = Cursors.Default;
            MinimizeHovered = false;
            Invalidate();
        }

        /// <summary>
        /// Handling mouse down event of the cotnrol.
        /// </summary>
        /// <param name="e">MouseEventArgs</param>
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            Focus();

            if (null != menu)
            {
                menu.Show(this, 0, this.Height);
            }   
        }

        #endregion

    }
}