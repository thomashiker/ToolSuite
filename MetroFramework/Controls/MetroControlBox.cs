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
    [ToolboxBitmap(typeof(MetroControlBox), "Bitmaps.ControlButton.bmp")]
    [DefaultProperty("Click")]
    [ComVisible(true)]
    [ClassInterface(ClassInterfaceType.AutoDispatch)]
    public class MetroControlBox : Control, IMetroControl
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

        public MetroControlBox()
        {
            SetStyle(
                ControlStyles.ResizeRedraw |
                ControlStyles.OptimizedDoubleBuffer |
                ControlStyles.SupportsTransparentBackColor, true);
            DoubleBuffered = true;
            UpdateStyles();

            Anchor = AnchorStyles.Top | AnchorStyles.Right;
        }

        #endregion Constructors

        private int ButtonCount = 3;
        private void UpdateButtonCount()
        {
            int count = 0;

            if (minimizeBox)
            {
                count += 1;
                MinimizeButtonLocation = new Point(ButtonPadding, 0);
            }

            if (MaximizeBox)
            {
                MaximizeButtonLocation = new Point(ButtonPadding + (ButtonPadding * 2 + ButtonWidth) * count, 0);
                count += 1;
            }

            if (CloseBox)
            {
                CloseButtonLocation = new Point(ButtonPadding + (ButtonPadding * 2 + ButtonWidth)*count, 0);
                count += 1;
            }
            ButtonCount = count;
            OnResize(null);
        }

        #region Properties

        #region Public

        private bool closeBox = true;
        /// <summary>
        /// Gets or sets a value indicating whether the Maximize button is Enabled in the caption bar of the form.
        /// </summary>
        [Category("MetroFramework"), Description("Gets or sets a value indicating whether the Close button is Enabled in the caption bar of the form.")]
        public bool CloseBox
        {
            get { return closeBox; }
            set
            {
                closeBox = value;
                UpdateButtonCount();
            }
        }

        private bool maximizeBox = true;
        /// <summary>
        /// Gets or sets a value indicating whether the Maximize button is Enabled in the caption bar of the form.
        /// </summary>
        [Category("MetroFramework"), Description("Gets or sets a value indicating whether the Maximize button is Enabled in the caption bar of the form.")]
        public bool MaximizeBox
        {
            get { return maximizeBox; }
            set
            {
                maximizeBox = value;
                UpdateButtonCount();
            }
        }

        private bool minimizeBox = true;
        /// <summary>
        /// Gets or sets a value indicating whether the Minimize button is Enabled in the caption bar of the form.
        /// </summary>
        [Category("MetroFramework"), Description("Gets or sets a value indicating whether the Minimize button is Enabled in the caption bar of the form.")]
        public bool MinimizeBox
        {
            get { return minimizeBox; }
            set
            {
                minimizeBox = value;
                UpdateButtonCount();
            }
        }

        /// <summary>
        /// Gets or sets Close forecolor used by the control
        /// </summary>
        [Category("MetroFramework"), Description("Gets or sets Close forecolor used by the control.")]
        public Color CloseNormalForeColor { get; set; } = Color.Black;

        /// <summary>
        /// Gets or sets Close forecolor used by the control
        /// </summary>
        [Category("MetroFramework"), Description("Gets or sets Close forecolor used by the control.")]
        public Color CloseHoverForeColor { get; set; } = Color.White;

        /// <summary>
        /// Gets or sets Close backcolor used by the control
        /// </summary>
        [Category("MetroFramework"), Description("Gets or sets Close backcolor used by the control.")]
        public Color CloseHoverBackColor { get; set; } = Color.Red;

        /// <summary>
        /// Gets or sets Maximize forecolor used by the control
        /// </summary>
        [Category("MetroFramework"), Description("Gets or sets Maximize forecolor used by the control.")]
        public Color MaximizeHoverForeColor { get; set; } = Color.White;

        /// <summary>
        /// Gets or sets Maximize backcolor used by the control
        /// </summary>
        [Category("MetroFramework"), Description("Gets or sets Maximize backcolor used by the control.")]
        public Color MaximizeHoverBackColor { get; set; } = Color.Blue;

        /// <summary>
        /// Gets or sets Maximize forecolor used by the control
        /// </summary>
        [Category("MetroFramework"), Description("Gets or sets Maximize forecolor used by the control.")]
        public Color MaximizeNormalForeColor { get; set; } = Color.Black;

        /// <summary>
        /// Gets or sets Minimize forecolor used by the control
        /// </summary>
        [Category("MetroFramework"), Description("Gets or sets Minimize forecolor used by the control.")]
        public Color MinimizeHoverForeColor { get; set; } = Color.White;

        /// <summary>
        /// Gets or sets Minimize backcolor used by the control
        /// </summary>
        [Category("MetroFramework"), Description("Gets or sets Minimize backcolor used by the control.")]
        public Color MinimizeHoverBackColor { get; set; } = Color.Blue;

        /// <summary>
        /// Gets or sets Minimize forecolor used by the control
        /// </summary>
        [Category("MetroFramework"), Description("Gets or sets Minimize forecolor used by the control.")]
        public Color MinimizeNormalForeColor { get; set; } = Color.Black;

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

        private int buttonWidth = 27;
        /// <summary>
        /// Gets or sets disabled forecolor used by the control
        /// </summary>
        [Category("MetroFramework"), Description("button width.")]
        public int ButtonWidth
        {
            get { return buttonWidth; }
            set { buttonWidth = value; OnResize(null); }
        }

        private int buttonPadding = 1;
        /// <summary>
        /// Gets or sets disabled forecolor used by the control
        /// </summary>
        [Category("MetroFramework"), Description("button padding.")]
        public int ButtonPadding
        {
            get { return buttonPadding; }
            set { buttonPadding = value; OnResize(null); }
        }

        /// <summary>
        /// Gets or sets disabled forecolor used by the control
        /// </summary>
        [Category("MetroFramework"), Description("Use Custom Style.")]
        public bool UseCustomStyle { get; set; } = true;

        #endregion

        #region Private 

        private bool MinimizeHovered { get; set; } = false;

        private bool MaximizeHovered { get; set; } = false;

        private bool CloseHovered { get; set; } = false;

        private Point CloseButtonLocation { get; set; } = new Point(0, 0);
        private Point MaximizeButtonLocation { get; set; } = new Point(0, 0);
        private Point MinimizeButtonLocation { get; set; } = new Point(0, 0);


        #endregion

        #endregion

        #region Draw Control

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics G = e.Graphics;
            G.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;

            if (CloseBox)
            {
                using (SolidBrush CloseBoxState = new SolidBrush(CloseHovered ? CloseHoverBackColor : Color.Transparent))
                {
                    using (Font F = new Font("Marlett", 10))
                    {
                        using (SolidBrush TB = new SolidBrush(CloseHovered ? CloseHoverForeColor : CloseNormalForeColor))
                        {
                            using (StringFormat SF = new StringFormat { Alignment = StringAlignment.Center })
                            {
                                G.FillRectangle(CloseBoxState, new Rectangle(CloseButtonLocation.X, CloseButtonLocation.Y, ButtonWidth, Height));
                                G.DrawString("r", F, TB, new Point(CloseButtonLocation.X + ButtonWidth / 2, 3), SF);
                            }
                        }
                    }
                }
            }
            
            if (MaximizeBox)
            {
                Color hoverBackColor = UseCustomStyle ? MaximizeHoverBackColor : MetroPaint.GetStyleColor(metroStyleManager.Style);
                using (SolidBrush MaximizeBoxState = new SolidBrush(MaximizeBox ? MaximizeHovered ? hoverBackColor : Color.Transparent : Color.Transparent))
                {
                    using (Font F = new Font("Marlett", 10))
                    {
                        using (SolidBrush TB = new SolidBrush(MaximizeBox ? MaximizeHovered ? MaximizeHoverForeColor : MaximizeNormalForeColor : DisabledForeColor))
                        {
                            using (StringFormat SF = new StringFormat { Alignment = StringAlignment.Center })
                            {
                                string maxSymbol = Parent.FindForm().WindowState == FormWindowState.Maximized ? "2" : "1";

                                G.FillRectangle(MaximizeBoxState, new Rectangle(MaximizeButtonLocation.X, MaximizeButtonLocation.Y, ButtonWidth, Height));
                                G.DrawString(maxSymbol, F, TB, new Point(MaximizeButtonLocation.X + ButtonWidth / 2, 3), SF);
                            }
                        }
                    }
                }
            }
            
            if (MinimizeBox)
            {
                Color hoverBackColor = UseCustomStyle ? MinimizeHoverBackColor : MetroPaint.GetStyleColor(metroStyleManager.Style);
                using (SolidBrush MinimizeBoxState = new SolidBrush(MinimizeBox ? MinimizeHovered ? hoverBackColor : Color.Transparent : Color.Transparent))
                {
                    using (Font F = new Font("Marlett", 10))
                    {
                        using (SolidBrush TB = new SolidBrush(MinimizeBox ? MinimizeHovered ? MinimizeHoverForeColor : MinimizeNormalForeColor : DisabledForeColor))
                        {
                            using (StringFormat SF = new StringFormat { Alignment = StringAlignment.Center })
                            {
                                G.FillRectangle(MinimizeBoxState, new Rectangle(MinimizeButtonLocation.X, MinimizeButtonLocation.Y, ButtonWidth, Height));
                                G.DrawString("0", F, TB, new Point(MinimizeButtonLocation.X + ButtonWidth / 2, 3), SF);
                            }
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
            Size = new Size((ButtonWidth + ButtonPadding * 2) * ButtonCount, 20); 
        }

        /// <summary>
        /// Handling mouse up event of the cotnrol so that we detect if cursor located in our need area.
        /// </summary>
        /// <param name="e">MouseEventArgs</param>
        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);

            bool active = false;
            if (e.Location.Y > 0 && e.Location.Y < (Height - 2))
            {
                if (MinimizeBox)
                {
                    if (e.Location.X > MinimizeButtonLocation.X && e.Location.X < (MinimizeButtonLocation.X + ButtonWidth))
                    {
                        Cursor = Cursors.Hand;
                        MinimizeHovered = true;
                        MaximizeHovered = false;
                        CloseHovered = false;

                        active = true;
                    }
                }

                if (MaximizeBox)
                {
                    if (e.Location.X > MaximizeButtonLocation.X && e.Location.X < (MaximizeButtonLocation.X + ButtonWidth))
                    {
                        Cursor = Cursors.Hand;
                        MinimizeHovered = false;
                        MaximizeHovered = true;
                        CloseHovered = false;

                        active = true;
                    }
                }

                if (CloseBox)
                {
                    if (e.Location.X > CloseButtonLocation.X && e.Location.X < (CloseButtonLocation.X + ButtonWidth))
                    {
                        Cursor = Cursors.Hand;
                        MinimizeHovered = false;
                        MaximizeHovered = false;
                        CloseHovered = true;

                        active = true;
                    }
                }

                if (!active)
                {
                    Cursor = Cursors.Arrow;
                    MinimizeHovered = false;
                    MaximizeHovered = false;
                    CloseHovered = false;
                }

                /*if (e.Location.X > ButtonPadding && e.Location.X < (ButtonPadding+ ButtonWidth))
                {
                    Cursor = Cursors.Hand;
                    MinimizeHovered = true;
                    MaximizeHovered = false;
                    CloseHovered = false;
                }
                else if (e.Location.X > (ButtonPadding*3 + ButtonWidth) && e.Location.X < (ButtonPadding * 3 + ButtonWidth*2))
                {
                    Cursor = Cursors.Hand;
                    MinimizeHovered = false;
                    MaximizeHovered = true;
                    CloseHovered = false;
                }
                else if (e.Location.X > (ButtonPadding * 5 + ButtonWidth * 2) && e.Location.X < (ButtonPadding * 5 + ButtonWidth * 3))
                {
                    Cursor = Cursors.Hand;
                    MinimizeHovered = false;
                    MaximizeHovered = false;
                    CloseHovered = true;
                }
                else
                {
                    Cursor = Cursors.Arrow;
                    MinimizeHovered = false;
                    MaximizeHovered = false;
                    CloseHovered = false;
                }*/
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
            if (CloseHovered)
            {
                Parent.FindForm().Close();
            }
            else if (MinimizeHovered)
            {
                if (MinimizeBox)
                    Parent.FindForm().WindowState = FormWindowState.Minimized;

            }
            else if (MaximizeHovered)
            {
                if (MaximizeBox)
                {
                    if (Parent.FindForm().WindowState == FormWindowState.Normal)
                    {
                        Parent.FindForm().WindowState = FormWindowState.Maximized;
                    }
                    else
                    {
                        Parent.FindForm().WindowState = FormWindowState.Normal;
                    }
                }
            }
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
            MaximizeHovered = false;
            CloseHovered = false;
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
        }

        #endregion

    }
}