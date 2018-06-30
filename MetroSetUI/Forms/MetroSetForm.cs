﻿/**
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

using MetroSet_UI.Controls;
using MetroSet_UI.Design;
using MetroSet_UI.Extensions;
using MetroSet_UI.Interfaces;
using MetroSet_UI.Native;

using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using static MetroSet_UI.Native.User32;

namespace MetroSet_UI.Forms
{
    [ToolboxItem(false)]
    [ToolboxBitmap(typeof(MetroSetForm), "Bitmaps.Form.bmp")]
    [DesignerCategory("Form")]
    [DefaultEvent("Load")]
    [DesignTimeVisible(false)]
    [ComVisible(true)]
    [InitializationEvent("Load")]
    [ClassInterface(ClassInterfaceType.AutoDispatch)]
    public class MetroSetForm : Form, iForm
    {

        #region Properties

        /// <summary>
        /// Gets or sets the form backcolor.
        /// </summary>
        [Category("MetroSet Framework"), Description("Gets or sets the form backcolor.")]
        public Color BackgroundColor { get; set; }

        /// <summary>
        /// Gets or sets the form forecolor.
        /// </summary>
        [Category("MetroSet Framework"), Description("Gets or sets the form forecolor.")]
        public override Color ForeColor { get; set; }

        /// <summary>
        /// Gets or sets the form bordercolor.
        /// </summary>
        [Category("MetroSet Framework"), Description("Gets or sets the form bordercolor.")]
        public Color BorderColor { get; set; }

        /// <summary>
        /// Gets or sets the form textcolor.
        /// </summary>
        [Category("MetroSet Framework"), Description("Gets or sets the form textcolor.")] 
        public Color TextColor { get; set; }

        /// <summary>
        /// Gets or sets the form small line color 1.
        /// </summary>
        [Category("MetroSet Framework"), Description("Gets or sets the form small line color 1.")]
        public Color SmallLineColor1 { get; set; }

        /// <summary>
        /// Gets or sets the form small line color 2.
        /// </summary>
        [Category("MetroSet Framework"), Description("Gets or sets the form small line color 2.")]
        public Color SmallLineColor2 { get; set; }

        /// <summary>
        /// Gets or sets the header color.
        /// </summary>
        [Category("MetroSet Framework"), Description("Gets or sets the header color.")]
        public Color HeaderColor { get; set; }

        /// <summary>
        /// Gets or sets whether display the header.
        /// </summary>
        [Category("MetroSet Framework"), Description("Gets or sets whether display the header.")]
        public bool DisplayHeader { get; set; } = false;

        /// <summary>
        /// Gets or sets the width of the small rectangle on top left of the window.
        /// </summary>
        [Category("MetroSet Framework"), Description("Gets or sets the width of the small rectangle on top left of the window.")]
        public int SmallRectThickness { get; set; } = 10;

        /// <summary>
        /// Gets or sets whether the border be shown.
        /// </summary>
        [Category("MetroSet Framework"), Description("Gets or sets whether the border be shown."), DefaultValue(true)]
        public bool ShowBorder { get; set; } = true;

        /// <summary>
        /// Gets or sets the border thickness.
        /// </summary>
        [Category("MetroSet Framework"), Description("Gets or sets the border thickness.")]
        public float BorderThickness { get; set; } = 1;

        /// <summary>Gets or sets the border style of the form.</summary>
        [DefaultValue(FormBorderStyle.None)]
        [Browsable(false)]
        public new FormBorderStyle FormBorderStyle
        {
            get
            {
                return FormBorderStyle.None;
            }
            set
            {
                base.FormBorderStyle = FormBorderStyle.None;
            }
        }

        /// <summary>Gets or sets a value indicating whether the Maximize button is displayed in the caption bar of the form.</summary>
        /// <returns>true to display a Maximize button for the form; otherwise, false. The default is true.</returns>
        [Category("WindowStyle")]
        [Browsable(false)]
        [DefaultValue(false)]
        [Description("FormMaximizeBox")]
        public new bool MaximizeBox
        {
            get
            {
                return false;
            }
            set
            {
                value = false;
            }
        }

        /// <summary>Gets or sets a value indicating whether the Minimize button is displayed in the caption bar of the form.</summary>
        /// <returns>true to display a Minimize button for the form; otherwise, false. The default is true.</returns>
        [Category("WindowStyle")]
        [Browsable(false)]
        [DefaultValue(false)]
        [Description("FormMinimizeBox")]
        public new bool MinimizeBox
        {
            get
            {
                return false;
            }
            set
            {
                value = false;
            }
        }

        /// <summary>
        /// Gets or sets whether the title be shown.
        /// </summary>
        [Category("MetroSet Framework"), Description("Gets or sets whether the title be shown.")]
        public bool ShowTitle { get; set; } = true;

        /// <summary>
        /// Gets or sets the title alignment.
        /// </summary>
        [Category("MetroSet Framework"), Description("Gets or sets the title alignment.")]
        public TextAlign TextAlign { get; set; } = Design.TextAlign.Left;


        /// <summary>
        /// Gets or sets whether show the header.
        /// </summary>
        [Category("MetroSet Framework"), Description("Gets or sets whether show the header.")]
        public bool ShowHeader
        {
            get { return showHeader; }
            set
            {
                showHeader = value;
                if (value)
                {
                    ShowLeftRect = false;
                    Padding = new Padding(2, HeaderHeight + 30, 2, 2);
                    Text = Text.ToUpper();
                    TextColor = Color.White;
                    ShowTitle = true;
                    foreach (Control C in Controls)
                    {
                        if (C.GetType() == typeof(MetroSetControlBox))
                        {
                            C.BringToFront();
                            C.Location = new Point(Width - 12, 11);
                        }
                    }
                }
                else
                {
                    Padding = new Padding(12, 60, 12, 12);
                    ShowTitle = false;
                }
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets whether the small rectangle on top left of the window be shown.
        /// </summary>
        [Category("MetroSet Framework"),
         Description("Gets or sets whether the small rectangle on top left of the window be shown.")]
        public bool ShowLeftRect
        {
            get { return showLeftRect; }
            set
            {
                showLeftRect = value;
                if (value)
                {
                    ShowHeader = false;
                }
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets whether the form can be move or not.
        /// </summary>
        [Category("MetroSet Framework"), Description("Gets or sets whether the form can be move or not."), DefaultValue(true)]
        public bool Moveable { get; set; } = true;

        /// <summary>
        /// Gets or sets whether the form use animation.
        /// </summary>
        [Category("MetroSet Framework"), Description("Gets or sets whether the form use animation.")]
        public bool UseSlideAnimation { get; set; } = false;

        [Browsable(false)]
        public new Padding Padding
        {
            get { return base.Padding; }
            set { base.Padding = value; }
        }

        /// <summary>
        /// Gets or sets the backgroundimage transparency.
        /// </summary>
        [Category("MetroSet Framework"), Description("Gets or sets the backgroundimage transparency.")]
        public float BackgroundImageTransparency
        {
            get
            {
                return backgorundImageTrasparency;
            }
            set
            {
                if (value > 1)
                    throw new Exception("The Value must be between 0-1.");

                backgorundImageTrasparency = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the header height.
        /// </summary>
        [Category("MetroSet Framework"), Description("Gets or sets the header height.")]
        public int HeaderHeight { get; set; } = 30;

        /// <summary>
        /// Gets or sets the background image displayed in the control.
        /// </summary>
        [Category("MetroSet Framework"), Description("Gets or sets the background image displayed in the control.")]
        public override Image BackgroundImage { get { return base.BackgroundImage; } set { base.BackgroundImage = value; } }

        #endregion Properties

        #region Constructor

        public MetroSetForm()
        {
            SetStyle(
                ControlStyles.UserPaint |
                ControlStyles.AllPaintingInWmPaint |
                ControlStyles.ResizeRedraw |
                ControlStyles.OptimizedDoubleBuffer |
                ControlStyles.ContainerControl |
                ControlStyles.SupportsTransparentBackColor, true);
            DoubleBuffered = true;
            UpdateStyles();
            Padding = new Padding(12, 70, 12, 12);
            FormBorderStyle = FormBorderStyle.None;
            backgorundImageTrasparency = 0.90f;
            Font = MetroSetFonts.SemiLight(13);
            mth = new Methods();
            utl = new Utilites();
            user32 = new User32();
            showLeftRect = true;
            showHeader = false;
            ApplyTheme();

        }

        #endregion Constructor

        #region Draw Control

        protected override void OnPaint(PaintEventArgs e)
        {

            e.Graphics.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
            e.Graphics.InterpolationMode = InterpolationMode.High;
            e.Graphics.CompositingQuality = CompositingQuality.HighQuality;

            using (SolidBrush B = new SolidBrush(BackgroundColor))
            {
                e.Graphics.FillRectangle(B, new Rectangle(0, 0, Width, Height));
                if (BackgroundImage != null)
                {
                    mth.DrawImageWithTransparency(e.Graphics, BackgroundImageTransparency, BackgroundImage, ClientRectangle);
                }
            }
            if (ShowBorder)
            {
                using (Pen P = new Pen(BorderColor, BorderThickness))
                {
                    e.Graphics.DrawRectangle(P, new Rectangle(0, 0, Width - 1, Height - 1));
                }
            }

            if (ShowLeftRect)
            {
                using (LinearGradientBrush B = new LinearGradientBrush(new Rectangle(0, 25, SmallRectThickness, 35), SmallLineColor1, SmallLineColor2, 90))
                {
                    using (SolidBrush textBrush = new SolidBrush(TextColor))
                    {
                        e.Graphics.FillRectangle(B, new Rectangle(0, 40, 10, 35));
                        e.Graphics.DrawString(Text, Font, textBrush, new Point(20, 46));
                    }
                }
            }
            else
            {
                if (ShowHeader)
                {
                    using (SolidBrush B = new SolidBrush(HeaderColor))
                    {
                        e.Graphics.FillRectangle(B, new Rectangle(1, 1, Width - 1, HeaderHeight));
                    }
                }

                SolidBrush textBrush = new SolidBrush(TextColor);
                if (ShowTitle)
                {
                    switch (TextAlign)
                    {
                        case TextAlign.Left:
                            using (StringFormat stringFormat = new StringFormat() { LineAlignment = StringAlignment.Center })
                            {
                                e.Graphics.DrawString(Text, Font, textBrush, new Rectangle(20, 0, Width, HeaderHeight), stringFormat);
                            }
                            break;

                        case TextAlign.Center:
                            using (StringFormat stringFormat = new StringFormat() { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center })
                            {
                                e.Graphics.DrawString(Text, Font, textBrush, new Rectangle(20, 0, Width - 21, HeaderHeight), stringFormat);
                            }
                            break;

                        case TextAlign.Right:
                            using (StringFormat stringFormat = new StringFormat() { Alignment = StringAlignment.Far, LineAlignment = StringAlignment.Center })
                            {
                                e.Graphics.DrawString(Text, Font, textBrush, new Rectangle(20, 0, Width - 26, HeaderHeight), stringFormat);
                            }
                            break;
                    }
                }
                textBrush.Dispose();
            }
        }

        #endregion Draw Control

        #region Methods

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);

            if (m.Msg == _WM_NCHITTEST)
            {
                if (Moveable)
                {
                    if ((int)m.Result == _HTCLIENT)
                        m.Result = new IntPtr(_HTCAPTION);
                }
            }
        }

        #endregion Methods

        #region Interfaces

        /// <summary>
        /// Gets or sets the style associated with the control.
        /// </summary>
        [Category("MetroSet Framework"), Description("Gets or sets the style associated with the control."), DefaultValue(Style.Light)]
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
            set
            {
                _StyleManager = value;
                Invalidate();
            }
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

        internal User32 User32 => User321;

        internal User32 User321 => user32;

        #endregion Interfaces

        #region Global Vars

        private readonly Utilites utl;
        private readonly User32 user32;
        private readonly Methods mth;

        #endregion Global Vars

        #region Internal Vars

        private Style style;
        private StyleManager _StyleManager;
        private bool showLeftRect;
        private bool showHeader;
        private float backgorundImageTrasparency;

        #endregion Internal Vars

        #region ApplyTheme

        /// <summary>
        /// Gets or sets the style provided by the user.
        /// </summary>
        /// <param name="style">The Style.</param>
        /// <param name="path">The path of the custom theme.</param>
        internal void ApplyTheme(Style style = Style.Light)
        {
            switch (style)
            {
                case Style.Light:
                    ForeColor = Color.Gray;
                    BackgroundColor = Color.White;
                    BorderColor = Color.FromArgb(65, 177, 225);
                    if (ShowHeader)
                    {
                        TextColor = Color.White;
                    }
                    else
                    {
                        TextColor = Color.Gray;
                    }
                    SmallLineColor1 = Color.FromArgb(65, 177, 225);
                    SmallLineColor2 = Color.FromArgb(65, 177, 225);
                    HeaderColor = Color.FromArgb(65, 177, 225);
                    ThemeAuthor = "Narwin";
                    ThemeName = "MetroLite";
                    UpdateProperties();
                    break;

                case Style.Dark:
                    ForeColor = Color.White;
                    BackgroundColor = Color.FromArgb(30, 30, 30);
                    BorderColor = Color.FromArgb(65, 177, 225);
                    SmallLineColor1 = Color.FromArgb(65, 177, 225);
                    SmallLineColor2 = Color.FromArgb(65, 177, 225);
                    HeaderColor = Color.FromArgb(65, 177, 225);
                    if (ShowHeader)
                    {
                        TextColor = Color.Gray;
                    }
                    else
                    {
                        TextColor = Color.White;
                    }
                    ThemeAuthor = "Narwin";
                    ThemeName = "MetroDark";
                    UpdateProperties();
                    break;

                case Style.Custom:
                    if ((StyleManager != null))
                        foreach (var varkey in StyleManager.FormDictionary)
                        {
                            if ((String.Equals(varkey.Key, null, StringComparison.Ordinal)) || varkey.Key == null)
                            {
                                throw new Exception("FormDictionary is empty");
                            }
                            if (varkey.Key == "ForeColor")
                            {
                                ForeColor = utl.HexColor((string)varkey.Value);
                            }
                            else if (varkey.Key == "BackColor")
                            {
                                BackgroundColor = utl.HexColor((string)varkey.Value);
                            }
                            else if (varkey.Key == "BorderColor")
                            {
                                BorderColor = utl.HexColor((string)varkey.Value);
                            }
                            else if (varkey.Key == "TextColor")
                            {
                                TextColor = utl.HexColor((string)varkey.Value);
                            }
                            else if (varkey.Key == "SmallLineColor1")
                            {
                                SmallLineColor1 = utl.HexColor((string)varkey.Value);
                            }
                            else if (varkey.Key == "SmallLineColor2")
                            {
                                SmallLineColor2 = utl.HexColor((string)varkey.Value);
                            }
                            else if (varkey.Key == "SmallRectThickness")
                            {
                                SmallRectThickness = int.Parse(varkey.Value.ToString());
                            }
                            else if (varkey.Key == "HeaderColor")
                            {
                                HeaderColor = utl.HexColor((string)varkey.Value);
                            }
                        }
                    UpdateProperties();
                    break;
            }
        }

        public void UpdateProperties()
        {
            try
            {
                 Invalidate();
            }
            catch (Exception ex) { throw new Exception(ex.StackTrace); }
        }

        #endregion Theme Changing

        #region Events

        protected override void OnHandleCreated(EventArgs e)
        {
            AutoScaleMode = AutoScaleMode.None;
            base.OnHandleCreated(e);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            // https://www.codeproject.com/Articles/30255/C-Fade-Form-Effect-With-the-AnimateWindow-API-Func
            AnimateWindow(Handle, 800, AnimateWindowFlags.AW_ACTIVATE | (UseSlideAnimation ?
                  AnimateWindowFlags.AW_HOR_POSITIVE | AnimateWindowFlags.AW_SLIDE : AnimateWindowFlags.AW_BLEND));
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
            // https://www.codeproject.com/Articles/30255/C-Fade-Form-Effect-With-the-AnimateWindow-API-Func
            if (e.Cancel == false)
            {
                AnimateWindow(Handle, 800, User32.AW_HIDE | (UseSlideAnimation ?
                              AnimateWindowFlags.AW_HOR_NEGATIVE | AnimateWindowFlags.AW_SLIDE : AnimateWindowFlags.AW_BLEND));
            }
        }

        #endregion

    }

}