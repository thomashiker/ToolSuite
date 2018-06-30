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

using MetroSet_UI.Design;
using MetroSet_UI.Extensions;
using MetroSet_UI.Interfaces;

using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Text;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace MetroSet_UI.Controls
{
    [ToolboxItem(true)]
    [ToolboxBitmap(typeof(MetroSetSingleBox), "Bitmaps.ControlButton.bmp")]
    [Designer(typeof(MetroSetSingleBoxDesigner))]
    [DefaultProperty("Click")]
    [ComVisible(true)]
    [ClassInterface(ClassInterfaceType.AutoDispatch)]
    public class MetroSetSingleBox : Control, iControl
    {

        #region Interfaces

        /// <summary>
        /// Gets or sets the style associated with the control.
        /// </summary>
        [Category("MetroSet Framework"), Description("Gets or sets the style associated with the control.")]
        public Style Style
        {
            get
            {
                return StyleManager?.Style ?? style;
            }
            set
            {
                style = value;
                switch (value)
                {
                    case Style.Light:
                        ApplyTheme();
                        break;

                    case Style.Dark:
                        ApplyTheme(Style.Dark);
                        break;

                    case Style.Custom:
                        ApplyTheme(Style.Custom);
                        break;

                    default:
                        ApplyTheme();
                        break;
                }
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the Style Manager associated with the control.
        /// </summary>
        [Category("MetroSet Framework"), Description("Gets or sets the Style Manager associated with the control.")]
        public StyleManager StyleManager
        {
            get { return _StyleManager; }
            set { _StyleManager = value; Invalidate(); }
        }

        /// <summary>
        /// Gets or sets the The Author name associated with the theme.
        /// </summary>
        [Category("MetroSet Framework"), Description("Gets or sets the The Author name associated with the theme.")]
        public string ThemeAuthor { get; set; }

        /// <summary>
        /// Gets or sets the The Theme name associated with the theme.
        /// </summary>
        [Category("MetroSet Framework"), Description("Gets or sets the The Theme name associated with the theme.")]
        public string ThemeName { get; set; }

        #endregion Interfaces

        #region Global Vars

        private Methods mth;
        private Utilites utl;

        #endregion Global Vars

        #region Internal Vars

        private Style style;
        private StyleManager _StyleManager;

        #endregion Internal Vars

        #region Constructors

        public MetroSetSingleBox()
        {
            SetStyle(
                ControlStyles.ResizeRedraw |
                ControlStyles.OptimizedDoubleBuffer |
                ControlStyles.SupportsTransparentBackColor, true);
            DoubleBuffered = true;
            UpdateStyles();
            mth = new Methods();
            utl = new Utilites();
            Anchor = AnchorStyles.Top | AnchorStyles.Right;
            ApplyTheme();
        }

        #endregion Constructors

        #region ApplyTheme

        /// <summary>
        /// Gets or sets the style provided by the user.
        /// </summary>
        /// <param name="style">The Style.</param>
        internal void ApplyTheme(Style style = Style.Light)
        {
            switch (style)
            {
                case Style.Light:
                    CloseHoverBackColor = Color.FromArgb(183, 40, 40);
                    CloseHoverForeColor = Color.White;
                    CloseNormalForeColor = Color.Gray;
                    DisabledForeColor = Color.DimGray;
                    ThemeAuthor = "Narwin";
                    ThemeName = "MetroLite";
                    break;

                case Style.Dark:
                    CloseHoverBackColor = Color.FromArgb(183, 40, 40);
                    CloseHoverForeColor = Color.White;
                    CloseNormalForeColor = Color.Gray;
                    DisabledForeColor = Color.Silver;
                    ThemeAuthor = "Narwin";
                    ThemeName = "MetroDark";
                    break;

                case Style.Custom:
                    if (StyleManager != null)
                        foreach (var varkey in StyleManager.ControlBoxDictionary)
                        {
                            switch (varkey.Key)
                            {
                                case "CloseHoverBackColor":
                                    CloseHoverBackColor = utl.HexColor((string)varkey.Value);
                                    break;

                                case "CloseHoverForeColor":
                                    CloseHoverForeColor = utl.HexColor((string)varkey.Value);
                                    break;

                                case "CloseNormalForeColor":
                                    CloseNormalForeColor = utl.HexColor((string)varkey.Value);
                                    break;

                                case "DisabledForeColor":
                                    DisabledForeColor = utl.HexColor((string)varkey.Value);
                                    break;

                                default:
                                    return;
                            }
                        }
                    ;
                    break;

            }
            Invalidate();
        }

        #endregion Theme Changing

        #region Properties

        #region Public


        /// <summary>
        /// Gets or sets Close forecolor used by the control
        /// </summary>
        [Category("MetroSet Framework"), Description("Gets or sets Close forecolor used by the control.")]
        public Color CloseNormalForeColor { get; set; }

        /// <summary>
        /// Gets or sets Close forecolor used by the control
        /// </summary>
        [Category("MetroSet Framework"), Description("Gets or sets Close forecolor used by the control.")]
        public Color CloseHoverForeColor { get; set; }

        /// <summary>
        /// Gets or sets Close backcolor used by the control
        /// </summary>
        [Category("MetroSet Framework"), Description("Gets or sets Close backcolor used by the control.")]
        public Color CloseHoverBackColor { get; set; }

        /// <summary>
        /// Gets or sets disabled forecolor used by the control
        /// </summary>
        [Category("MetroSet Framework"), Description("Gets or sets disabled forecolor used by the control.")]
        public Color DisabledForeColor { get; set; }
        
        /// <summary>
        /// I make backcolor inaccessible cause we have not use of it. 
        /// </summary>
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public override Color BackColor
        {
            get { return Color.Transparent; }
        }

        private string singleBoxText = "r";
        private Font singleBoxFont = new Font("Marlett", 12);

        /// <summary>
        /// Gets or sets SingleBoxFont used by the control
        /// </summary>
        [Category("SingleBox"), Description("SingleBox Font.")]
        public Font SingleBoxFont
        {
            get { return singleBoxFont; }
            set {
                singleBoxFont = value;
                this.Refresh();
            }
        }

        /// <summary>
        /// Gets or sets SingleBoxText used by the control
        /// </summary>
        [Category("SingleBox"), Description("SingleBox Text.")]
        public string SingleBoxText
        {
            get { return singleBoxText; }
            set {
                singleBoxText = value;
                this.Refresh();
            }
        }

        #endregion

        #region Private 

        private bool CloseHovered { get; set; } = false;

        #endregion

        #endregion

        #region Draw Control

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics G = e.Graphics;
            G.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;

            using (SolidBrush CloseBoxState = new SolidBrush(CloseHovered ? CloseHoverBackColor : Color.Transparent))
            {
                using (Font F = new Font(SingleBoxFont.FontFamily, 12))//new Font("Marlett", 12)
                {
                    using (SolidBrush TB = new SolidBrush(CloseHovered ? CloseHoverForeColor : CloseNormalForeColor))
                    {
                        using (StringFormat SF = new StringFormat { Alignment = StringAlignment.Center })
                        {
                            G.FillRectangle(CloseBoxState, new Rectangle(3, 5, 27, Height));
                            G.DrawString(SingleBoxText, F, CloseHovered ? TB : Brushes.Gray, new Point(Width - 16, 8), SF);
                        }
                    }
                }
            }
        }

        #endregion

        #region Events

        //定义delegate
        public delegate void SingleBoxEventHandler(object sender, System.EventArgs e);

        /// <summary>
        /// DialogBox Event
        /// </summary>
        [Category("Customize"), Description("SingleBox Event.")]
        public event SingleBoxEventHandler SingleBoxEvent;

        //事件触发方法
        protected virtual void OnSingleBoxEvent(EventArgs e)
        {
            if (SingleBoxEvent != null)
                SingleBoxEvent(this, e);
        }

        /// <summary>
        /// Here we provide the fixed size while resizing.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            Size = new Size(33, 25);
        }

        /// <summary>
        /// Handling mouse up event of the cotnrol so that we detect if cursor located in our need area.
        /// </summary>
        /// <param name="e">MouseEventArgs</param>
        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (e.Location.Y > 0 && e.Location.Y < (Height - 2))
            {
                if (e.Location.X > 0 && e.Location.X < Width)
                {
                    Cursor = Cursors.Hand;
                    CloseHovered = true;
                }
                else
                {
                    Cursor = Cursors.Arrow;
                    CloseHovered = false;
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
            if (CloseHovered)
            {
                //Parent.FindForm().Hide();
                OnSingleBoxEvent(e);
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