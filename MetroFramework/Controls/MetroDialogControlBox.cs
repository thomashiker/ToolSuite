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
    [ToolboxBitmap(typeof(MetroDialogControlBox), "Bitmaps.ControlButton.bmp")]
    [DefaultProperty("Click")]
    [ComVisible(true)]
    [ClassInterface(ClassInterfaceType.AutoDispatch)]
    public class MetroDialogControlBox : Control, IMetroControl
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

        public MetroDialogControlBox()
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

        private int ButtonCount = 2;
        private void UpdateButtonCount()
        {
            int count = 0;

            if (SecondBox)
            {
                SecondButtonLocation = new Point(ButtonPadding + (ButtonPadding * 2 + ButtonWidth) * count, 0);
                count += 1;
            }

            if (FirstBox)
            {
                FirstButtonLocation = new Point(ButtonPadding + (ButtonPadding * 2 + ButtonWidth)*count, 0);
                count += 1;
            }
            ButtonCount = count;
            OnResize(null);
        }

        #region Properties

        #region Public

        private bool firstBox = true;
        /// <summary>
        /// Gets or sets a value indicating whether the Second button is Enabled in the caption bar of the form.
        /// </summary>
        [Category("MetroFramework"), Description("Gets or sets a value indicating whether the First button is Enabled in the caption bar of the form.")]
        public bool FirstBox
        {
            get { return firstBox; }
            set
            {
                firstBox = value;
                UpdateButtonCount();
            }
        }

        private bool secondBox = true;
        /// <summary>
        /// Gets or sets a value indicating whether the Second button is Enabled in the caption bar of the form.
        /// </summary>
        [Category("MetroFramework"), Description("Gets or sets a value indicating whether the Second button is Enabled in the caption bar of the form.")]
        public bool SecondBox
        {
            get { return secondBox; }
            set
            {
                secondBox = value;
                UpdateButtonCount();
            }
        }

        /// <summary>
        /// Gets or sets First forecolor used by the control
        /// </summary>
        [Category("MetroFramework"), Description("Gets or sets First forecolor used by the control.")]
        public Color FirstNormalForeColor { get; set; } = Color.Black;

        /// <summary>
        /// Gets or sets First forecolor used by the control
        /// </summary>
        [Category("MetroFramework"), Description("Gets or sets First forecolor used by the control.")]
        public Color FirstHoverForeColor { get; set; } = Color.White;

        /// <summary>
        /// Gets or sets First backcolor used by the control
        /// </summary>
        [Category("MetroFramework"), Description("Gets or sets First backcolor used by the control.")]
        public Color FirstHoverBackColor { get; set; } = Color.Red;

        private string firstButtonName = "r";
        /// <summary>
        /// Gets or sets First backcolor used by the control
        /// </summary>
        [Category("MetroFramework"), Description("FirstButtonName.")]
        public string FirstButtonName
        {
            get { return firstButtonName; }
            set
            {
                firstButtonName = value;
                Refresh();
            }
        }

        /// <summary>
        /// Gets or sets Second forecolor used by the control
        /// </summary>
        [Category("MetroFramework"), Description("Gets or sets Second forecolor used by the control.")]
        public Color SecondHoverForeColor { get; set; } = Color.White;

        /// <summary>
        /// Gets or sets Second backcolor used by the control
        /// </summary>
        [Category("MetroFramework"), Description("Gets or sets Second backcolor used by the control.")]
        public Color SecondHoverBackColor { get; set; } = Color.Blue;

        /// <summary>
        /// Gets or sets Second forecolor used by the control
        /// </summary>
        [Category("MetroFramework"), Description("Gets or sets Second forecolor used by the control.")]
        public Color SecondNormalForeColor { get; set; } = Color.Black;

        private string secondButtonName = "2";
        /// <summary>
        /// Gets or sets First backcolor used by the control
        /// </summary>
        [Category("MetroFramework"), Description("SecondButtonName.")]
        public string SecondButtonName
        {
            get { return secondButtonName; }
            set
            {
                secondButtonName = value;
                Refresh();
            }
        }

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

        private bool SecondHovered { get; set; } = false;
        private bool FirstHovered { get; set; } = false;

        private Point FirstButtonLocation { get; set; } = new Point(0, 0);
        private Point SecondButtonLocation { get; set; } = new Point(0, 0);


        #endregion

        #endregion

        #region Draw Control

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics G = e.Graphics;
            G.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;

            if (FirstBox)
            {
                using (SolidBrush FirstBoxState = new SolidBrush(FirstHovered ? FirstHoverBackColor : Color.Transparent))
                {
                    using (Font F = new Font("Marlett", 10))
                    {
                        using (SolidBrush TB = new SolidBrush(FirstHovered ? FirstHoverForeColor : FirstNormalForeColor))
                        {
                            using (StringFormat SF = new StringFormat { Alignment = StringAlignment.Center })
                            {
                                G.FillRectangle(FirstBoxState, new Rectangle(FirstButtonLocation.X, FirstButtonLocation.Y, ButtonWidth, Height));
                                G.DrawString(FirstButtonName, F, TB, new Point(FirstButtonLocation.X + ButtonWidth / 2, 3), SF);
                            }
                        }
                    }
                }
            }
            
            if (SecondBox)
            {
                Color hoverBackColor = UseCustomStyle ? SecondHoverBackColor : MetroPaint.GetStyleColor(metroStyleManager.Style);
                using (SolidBrush SecondBoxState = new SolidBrush(SecondHovered ? hoverBackColor : Color.Transparent))
                {
                    using (Font F = new Font("Marlett", 10))
                    {
                        using (SolidBrush TB = new SolidBrush(SecondBox ? SecondHovered ? SecondHoverForeColor : SecondNormalForeColor : DisabledForeColor))
                        {
                            using (StringFormat SF = new StringFormat { Alignment = StringAlignment.Center })
                            {
                                G.FillRectangle(SecondBoxState, new Rectangle(SecondButtonLocation.X, SecondButtonLocation.Y, ButtonWidth, Height));
                                G.DrawString(SecondButtonName, F, TB, new Point(SecondButtonLocation.X + ButtonWidth / 2, 3), SF);
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
                if (SecondBox)
                {
                    if (e.Location.X > SecondButtonLocation.X && e.Location.X < (SecondButtonLocation.X + ButtonWidth))
                    {
                        Cursor = Cursors.Hand;
                        SecondHovered = true;
                        FirstHovered = false;

                        active = true;
                    }
                }

                if (FirstBox)
                {
                    if (e.Location.X > FirstButtonLocation.X && e.Location.X < (FirstButtonLocation.X + ButtonWidth))
                    {
                        Cursor = Cursors.Hand;
                        SecondHovered = false;
                        FirstHovered = true;

                        active = true;
                    }
                }

                if (!active)
                {
                    Cursor = Cursors.Arrow;
                    SecondHovered = false;
                    FirstHovered = false;
                }
            }
            Invalidate();
        }

        //定义delegate
        public delegate void DialogBoxEventHandler(DialogResult e);

        /// <summary>
        /// DialogBox Event
        /// </summary>
        [Category("Customize"), Description("DialogBox Event.")]
        public event DialogBoxEventHandler DialogBoxEvent;

        //事件触发方法
        protected virtual void OnDialogBoxEvent(DialogResult e)
        {
            if (DialogBoxEvent != null)
                DialogBoxEvent(e);
        }

        /// <summary>
        /// Handling mouse up event of the cotnrol so that we can perform action commands.
        /// </summary>
        /// <param name="e">MouseEventArgs</param>
        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if (FirstHovered)
            {
                OnDialogBoxEvent(DialogResult.OK);
            }
            else if (SecondHovered)
            {
                OnDialogBoxEvent(DialogResult.Cancel);
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
            SecondHovered = false;
            FirstHovered = false;
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