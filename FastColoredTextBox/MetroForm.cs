/**
 * MetroFramework - Modern UI for WinForms
 * 
 * The MIT License (MIT)
 * Copyright (c) 2011 Sven Walter, http://github.com/viperneo
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
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.ComponentModel;
using System.Collections.Generic;
using System.Reflection;
using System.Security;
using System.Windows.Forms;
using System.Runtime.InteropServices;


namespace FastColoredTextBoxNS
{
/*    [SuppressUnmanagedCodeSecurity]
    internal class DwmApi
    {
        #region Structs

        [StructLayout(LayoutKind.Explicit)]
        public struct RECT
        {
            [FieldOffset(12)]
            public int bottom;
            [FieldOffset(0)]
            public int left;
            [FieldOffset(8)]
            public int right;
            [FieldOffset(4)]
            public int top;

            public RECT(Rectangle rect)
            {
                this.left = rect.Left;
                this.top = rect.Top;
                this.right = rect.Right;
                this.bottom = rect.Bottom;
            }

            public RECT(int left, int top, int right, int bottom)
            {
                this.left = left;
                this.top = top;
                this.right = right;
                this.bottom = bottom;
            }

            public void Set()
            {
                this.left = InlineAssignHelper(ref this.top, InlineAssignHelper(ref this.right, InlineAssignHelper(ref this.bottom, 0)));
            }

            public void Set(Rectangle rect)
            {
                this.left = rect.Left;
                this.top = rect.Top;
                this.right = rect.Right;
                this.bottom = rect.Bottom;
            }

            public void Set(int left, int top, int right, int bottom)
            {
                this.left = left;
                this.top = top;
                this.right = right;
                this.bottom = bottom;
            }

            public Rectangle ToRectangle()
            {
                return new Rectangle(this.left, this.top, this.right - this.left, this.bottom - this.top);
            }

            public int Height
            {
                get { return (this.bottom - this.top); }
            }

            public Size Size
            {
                get { return new Size(this.Width, this.Height); }
            }

            public int Width
            {
                get { return (this.right - this.left); }
            }
            private static T InlineAssignHelper<T>(ref T target, T value)
            {
                target = value;
                return value;
            }
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct DWM_BLURBEHIND
        {
            public int dwFlags;
            public int fEnable;
            public IntPtr hRgnBlur;
            public int fTransitionOnMaximized;

            private DWM_BLURBEHIND(bool enable)
            {
                dwFlags = DWM_BB_ENABLE;
                fEnable = enable ? 1 : 0;
                hRgnBlur = IntPtr.Zero;
                fTransitionOnMaximized = 0;
            }

            public static DWM_BLURBEHIND Enable = new DWM_BLURBEHIND(true);
            public static DWM_BLURBEHIND Disable = new DWM_BLURBEHIND(false);

            public const int DWM_BB_ENABLE = 1;
            public const int DWM_BB_BLURREGION = 2;
            public const int DWM_BB_TRANSITIONONMAXIMIZED = 4;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct DWM_PRESENT_PARAMETERS
        {
            public int cbSize;
            public int fQueue;
            public long cRefreshStart;
            public int cBuffer;
            public int fUseSourceRate;
            public UNSIGNED_RATIO rateSource;
            public int cRefreshesPerFrame;
            public DWM_SOURCE_FRAME_SAMPLING eSampling;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct DWM_THUMBNAIL_PROPERTIES
        {
            public int dwFlags;
            public RECT rcDestination;
            public RECT rcSource;
            public byte opacity;
            public int fVisible;
            public int fSourceClientAreaOnly;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct DWM_TIMING_INFO
        {
            public int cbSize;
            public UNSIGNED_RATIO rateRefresh;
            public UNSIGNED_RATIO rateCompose;
            public long qpcVBlank;
            public long cRefresh;
            public long qpcCompose;
            public long cFrame;
            public long cRefreshFrame;
            public long cRefreshConfirmed;
            public int cFlipsOutstanding;
            public long cFrameCurrent;
            public long cFramesAvailable;
            public long cFrameCleared;
            public long cFramesReceived;
            public long cFramesDisplayed;
            public long cFramesDropped;
            public long cFramesMissed;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct UNSIGNED_RATIO
        {
            public int uiNumerator;
            public int uiDenominator;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct MARGINS
        {
            public int cxLeftWidth;
            public int cxRightWidth;
            public int cyTopHeight;
            public int cyBottomHeight;
            public MARGINS(int Left, int Right, int Top, int Bottom)
            {
                this.cxLeftWidth = Left;
                this.cxRightWidth = Right;
                this.cyTopHeight = Top;
                this.cyBottomHeight = Bottom;
            }
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct WTA_OPTIONS
        {
            public uint Flags;
            public uint Mask;
        }

        #endregion

        #region Enums

        public enum DWM_SOURCE_FRAME_SAMPLING
        {
            DWM_SOURCE_FRAME_SAMPLING_POINT,
            DWM_SOURCE_FRAME_SAMPLING_COVERAGE,
            DWM_SOURCE_FRAME_SAMPLING_LAST
        }

        public enum DWMNCRENDERINGPOLICY
        {
            DWMNCRP_USEWINDOWSTYLE,
            DWMNCRP_DISABLED,
            DWMNCRP_ENABLED
        }

        public enum DWMWINDOWATTRIBUTE
        {
            DWMWA_ALLOW_NCPAINT = 4,
            DWMWA_CAPTION_BUTTON_BOUNDS = 5,
            DWMWA_FLIP3D_POLICY = 8,
            DWMWA_FORCE_ICONIC_REPRESENTATION = 7,
            DWMWA_LAST = 9,
            DWMWA_NCRENDERING_ENABLED = 1,
            DWMWA_NCRENDERING_POLICY = 2,
            DWMWA_NONCLIENT_RTL_LAYOUT = 6,
            DWMWA_TRANSITIONS_FORCEDISABLED = 3
        }

        public enum WindowThemeAttributeType
        {
            WTA_NONCLIENT = 1
        }

        #endregion

        #region Fields

        public static uint WTNCA_NODRAWCAPTION = 0x1;
        public static uint WTNCA_NODRAWICON = 0x2;
        public static uint WTNCA_NOSYSMENU = 0x4;
        public static uint WTNCA_NOMIRRORHELP = 0x8;

        public const int DWM_BB_BLURREGION = 2;
        public const int DWM_BB_ENABLE = 1;
        public const int DWM_BB_TRANSITIONONMAXIMIZED = 4;
        public const string DWM_COMPOSED_EVENT_BASE_NAME = "DwmComposedEvent_";
        public const string DWM_COMPOSED_EVENT_NAME_FORMAT = "%s%d";
        public const int DWM_COMPOSED_EVENT_NAME_MAX_LENGTH = 0x40;
        public const int DWM_FRAME_DURATION_DEFAULT = -1;
        public const int DWM_TNP_OPACITY = 4;
        public const int DWM_TNP_RECTDESTINATION = 1;
        public const int DWM_TNP_RECTSOURCE = 2;
        public const int DWM_TNP_SOURCECLIENTAREAONLY = 0x10;
        public const int DWM_TNP_VISIBLE = 8;
        public static readonly bool DwmApiAvailable = (Environment.OSVersion.Version.Major >= 6);

        public const int WM_DWMCOMPOSITIONCHANGED = 0x31e;

        #endregion

        #region API Calls

        [DllImport("dwmapi.dll")]
        public static extern int DwmDefWindowProc(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, ref IntPtr result);
        [DllImport("dwmapi.dll")]
        public static extern int DwmEnableComposition(int fEnable);
        [DllImport("dwmapi.dll")]
        public static extern int DwmEnableMMCSS(int fEnableMMCSS);
        [DllImport("dwmapi.dll")]
        public static extern int DwmExtendFrameIntoClientArea(IntPtr hdc, ref MARGINS marInset);
        [DllImport("dwmapi.dll")]
        public static extern int DwmGetColorizationColor(ref int pcrColorization, ref int pfOpaqueBlend);
        [DllImport("dwmapi.dll")]
        public static extern int DwmGetCompositionTimingInfo(IntPtr hwnd, ref DWM_TIMING_INFO pTimingInfo);
        [DllImport("dwmapi.dll")]
        public static extern int DwmGetWindowAttribute(IntPtr hwnd, int dwAttribute, IntPtr pvAttribute, int cbAttribute);
        [DllImport("dwmapi.dll")]
        public static extern int DwmIsCompositionEnabled(ref int pfEnabled);
        [DllImport("dwmapi.dll")]
        public static extern int DwmIsCompositionEnabled(out bool pfEnabled);
        [DllImport("dwmapi.dll")]
        public static extern int DwmModifyPreviousDxFrameDuration(IntPtr hwnd, int cRefreshes, int fRelative);
        [DllImport("dwmapi.dll")]
        public static extern int DwmQueryThumbnailSourceSize(IntPtr hThumbnail, ref Size pSize);
        [DllImport("dwmapi.dll")]
        public static extern int DwmRegisterThumbnail(IntPtr hwndDestination, IntPtr hwndSource, ref Size pMinimizedSize, ref IntPtr phThumbnailId);
        [DllImport("dwmapi.dll")]
        public static extern int DwmSetDxFrameDuration(IntPtr hwnd, int cRefreshes);
        [DllImport("dwmapi.dll")]
        public static extern int DwmSetPresentParameters(IntPtr hwnd, ref DWM_PRESENT_PARAMETERS pPresentParams);
        [DllImport("dwmapi.dll")]
        public static extern int DwmSetWindowAttribute(IntPtr hwnd, int dwAttribute, IntPtr pvAttribute, int cbAttribute);
        [DllImport("dwmapi.dll", PreserveSig = true)]
        public static extern int DwmSetWindowAttribute(IntPtr hwnd, int attr, ref int attrValue, int attrSize);
        [DllImport("dwmapi.dll")]
        public static extern int DwmUnregisterThumbnail(IntPtr hThumbnailId);
        [DllImport("dwmapi.dll")]
        public static extern int DwmUpdateThumbnailProperties(IntPtr hThumbnailId, ref DWM_THUMBNAIL_PROPERTIES ptnProperties);

        [DllImport("dwmapi.dll")]
        public static extern int DwmEnableBlurBehindWindow(IntPtr hWnd, ref DWM_BLURBEHIND pBlurBehind);

        [DllImport("uxtheme.dll")]
        public static extern int SetWindowThemeAttribute(IntPtr hWnd, WindowThemeAttributeType wtype, ref WTA_OPTIONS attributes, uint size);

        #endregion
    }*/
    public class MetroForm : Form, IDisposable
    {
        #region Interface

        #endregion

        #region HideProperty

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override Image BackgroundImage
        {
            get { return base.BackgroundImage; }
            set { base.BackgroundImage = value; }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override ImageLayout BackgroundImageLayout
        {
            get { return base.BackgroundImageLayout; }
            set { base.BackgroundImageLayout = value; }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override string Text
        {
            get { return base.Text; }
            set { base.Text = value; }
        }

        #endregion

        #region Fields

        private Color formBackColor = Color.FromKnownColor(KnownColor.Control);
        [Category("Appearance")]
        public override Color BackColor
        {
            get { return formBackColor; }
            set { formBackColor = value; Refresh(); }
        }

        private Color headerColor = Color.FromKnownColor(KnownColor.Control);
        [Category("Appearance")]
        public Color HeaderColor
        {
            get { return headerColor; }
            set { headerColor = value; Refresh(); }
        }

        private bool formBorderShow = true;
        [Category("Appearance")]
        public bool BorderShow
        {
            get { return formBorderShow; }
            set { formBorderShow = value; Refresh(); }
        }

        private Color formBorderColor = Color.White;
        [Category("Appearance")]
        public Color BorderColor
        {
            get { return formBorderColor; }
            set { formBorderColor = value; Refresh(); }
        }

        private bool isMovable = true;
        [Category("Appearance")]
        public bool Movable
        {
            get { return isMovable; }
            set { isMovable = value; }
        }

        public new Padding Padding
        {
            get { return base.Padding; }
            set
            {
                base.Padding = value;
                Invalidate();
            }
        }

        protected override Padding DefaultPadding
        {
            get { return new Padding(2, 30, 2, 2); }
        }

        private bool isResizable = true;
        [Category("Appearance")]
        public bool Resizable
        {
            get { return isResizable; }
            set { isResizable = value; }
        }

        [Category("Appearance")]
        public bool LeftResizable { get; set; } = false;
        [Category("Appearance")]
        public bool RightResizable { get; set; } = false;
        [Category("Appearance")]
        public bool TopResizable { get; set; } = false;
        [Category("Appearance")]
        public bool BottomResizable { get; set; } = false;

        [Browsable(false)]
        public new FormBorderStyle FormBorderStyle
        {
            get { return base.FormBorderStyle; }
            set { base.FormBorderStyle = value; }
        }

        public new Form MdiParent
        {
            get { return base.MdiParent; }
            set
            {
                base.MdiParent = value;
            }
        }

        private const int borderWidth = 1;

        private Image headImage;
        [Category("Appearance")]
        [DefaultValue(null)]
        public Image HeaderImage
        {
            get { return headImage; }
            set
            {
                headImage = value;
                Refresh();
            }
        }

        private Padding headImagePadding;
        [Category("Appearance")]
        public Padding HeaderImagePadding
        {
            get { return headImagePadding; }
            set
            {
                headImagePadding = value;
                Refresh();
            }
        }

        [Category("Appearance")]
        public string Title
        {
            get { return Text; }
            set
            {
                Text = value;
                Refresh();
            }
        }

        private Font titleFont = new Font("SimSun", 10);
        [Category("Appearance")]
        public Font TitleFont
        {
            get { return titleFont; }
            set
            {
                titleFont = value;
                Refresh();
            }
        }

        private Padding titlePadding = new Padding(2,2,0,0);
        [Category("Appearance")]
        public Padding TitlePadding
        {
            get { return titlePadding; }
            set
            {
                titlePadding = value;
                Refresh();
            }
        }

        private Color titleColor = Color.Black;
        [Category("Appearance")]
        public Color TitleColor
        {
            get { return titleColor; }
            set
            {
                titleColor = value;
                Refresh();
            }
        }

        private string titleAppendText;
        [Category("Appearance")]
        public string TitleAppendText
        {
            get { return titleAppendText; }
            set
            {
                titleAppendText = value;
                Refresh();
            }
        }

        /*private int backMaxSize;
        [Category("Appearance")]
        public int BackMaxSize
        {
            get { return backMaxSize; }
            set
            {
                backMaxSize = value;
                Refresh();
            }
        }*/

        #endregion

        #region Constructor

        public MetroForm()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint |
                     ControlStyles.OptimizedDoubleBuffer |
                     ControlStyles.ResizeRedraw |
                     ControlStyles.UserPaint, true);

            FormBorderStyle = FormBorderStyle.None;
            Name = "MetroForm";
            StartPosition = FormStartPosition.CenterScreen;
            TransparencyKey = Color.Lavender;
        }

        /*protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                RemoveShadow();
            }

            base.Dispose(disposing);
        }*/

        #endregion

        #region Paint Methods

        public Bitmap ApplyInvert(Bitmap bitmapImage)
        {
            byte A, R, G, B;
            Color pixelColor;

            for (int y = 0; y < bitmapImage.Height; y++)
            {
                for (int x = 0; x < bitmapImage.Width; x++)
                {
                    pixelColor = bitmapImage.GetPixel(x, y);
                    A = pixelColor.A;
                    R = (byte)(255 - pixelColor.R);
                    G = (byte)(255 - pixelColor.G);
                    B = (byte)(255 - pixelColor.B);

                    if (R <= 0) R = 17;
                    if (G <= 0) G = 17;
                    if (B <= 0) B = 17;
                    //bitmapImage.SetPixel(x, y, Color.FromArgb((int)A, (int)R, (int)G, (int)B));
                    bitmapImage.SetPixel(x, y, Color.FromArgb((int)R, (int)G, (int)B));
                }
            }

            return bitmapImage;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Color backColor = BackColor;
            Color foreColor = ForeColor;

            e.Graphics.Clear(backColor);

            using (SolidBrush b = new SolidBrush(BackColor)) // MetroPaint.GetStyleBrush(Style))
            {
                //Rectangle topRect = new Rectangle(0, 0, Width, borderWidth);
                //e.Graphics.FillRectangle(b, topRect);
                e.Graphics.FillRectangle(b, new RectangleF(0, 0, Width, Height));
                
            }

            using (SolidBrush b = new SolidBrush(HeaderColor)) // MetroPaint.GetStyleBrush(Style))
            {
                e.Graphics.FillRectangle(b, new RectangleF(2, 2, Width - 4, Padding.Top + Padding.Bottom - 2));

            }

            if (BorderShow)
            {
                Color bcolor = BorderColor;
                using (Pen pen = new Pen(bcolor))
                {
                    e.Graphics.DrawRectangle(pen, new Rectangle(0, 0, Width-1, Height-1));
                }
            }

            if (HeaderImage != null)
            {
                int width = Padding.Top - 1 - HeaderImagePadding.Top - HeaderImagePadding.Bottom;
                int height = width;
                Image img = HeaderImage;// MetroImage.ResizeImage(HeaderImage, new Rectangle(0, 0, width, height));
                e.Graphics.DrawImage(img, HeaderImagePadding.Left, HeaderImagePadding.Top);

                int titleleft = width + HeaderImagePadding.Left + HeaderImagePadding.Right + TitlePadding.Left;
                int titletop = TitlePadding.Top;
                using (SolidBrush TB = new SolidBrush(TitleColor))
                {
                    string text = Title;
                    if ((null != TitleAppendText) && (0 != TitleAppendText.Length))
                    {
                        text += " - " + TitleAppendText;
                    }
                    e.Graphics.DrawString(text, TitleFont, TB, new Point(titleleft, titletop), StringFormat.GenericDefault);
                }
            }
            else
            {
                int titleleft = TitlePadding.Left;
                int titletop = TitlePadding.Top;
                using (SolidBrush TB = new SolidBrush(TitleColor))
                {
                    e.Graphics.DrawString(Title, TitleFont, TB, new Point(titleleft, titletop), StringFormat.GenericDefault);
                }
            }

            if (Resizable && (SizeGripStyle == SizeGripStyle.Auto || SizeGripStyle == SizeGripStyle.Show))
            {
                using (SolidBrush b = new SolidBrush(Color.White))//fixme
                {
                    Size resizeHandleSize = new Size(2, 2);
                    e.Graphics.FillRectangles(b, new Rectangle[] {
                        new Rectangle(new Point(ClientRectangle.Width-6,ClientRectangle.Height-6), resizeHandleSize),
                        new Rectangle(new Point(ClientRectangle.Width-10,ClientRectangle.Height-10), resizeHandleSize),
                        new Rectangle(new Point(ClientRectangle.Width-10,ClientRectangle.Height-6), resizeHandleSize),
                        new Rectangle(new Point(ClientRectangle.Width-6,ClientRectangle.Height-10), resizeHandleSize),
                        new Rectangle(new Point(ClientRectangle.Width-14,ClientRectangle.Height-6), resizeHandleSize),
                        new Rectangle(new Point(ClientRectangle.Width-6,ClientRectangle.Height-14), resizeHandleSize)
                    });
                }
            }
        }

        private TextFormatFlags GetTextFormatFlags()
        {
            /*switch (TextAlign)
            {
                case MetroFormTextAlign.Left: return TextFormatFlags.Left;
                case MetroFormTextAlign.Center: return TextFormatFlags.HorizontalCenter;
                case MetroFormTextAlign.Right: return TextFormatFlags.Right;
            }*/
            return TextFormatFlags.Left;
            //throw new InvalidOperationException();
        }

        #endregion

        #region Management Methods

        /*protected override void OnClosing(CancelEventArgs e)
        {
            if (!(this is MetroTaskWindow))
                MetroTaskWindow.ForceClose();

            base.OnClosing(e);
        }*/

        protected override void OnClosed(EventArgs e)
        {
            if (this.Owner != null) this.Owner = null;

            base.OnClosed(e);
        }

        [SecuritySafeCritical]
        public bool FocusMe()
        {
            return WinApi.SetForegroundWindow(Handle);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            if (DesignMode) return;

            switch (StartPosition)
            {
                case FormStartPosition.CenterParent:
                    CenterToParent();
                    break;
                case FormStartPosition.CenterScreen:
                    if (IsMdiChild)
                    {
                        CenterToParent();
                    }
                    else
                    {
                        CenterToScreen();
                    }
                    break;
            }

            RemoveCloseButton();
        }

        /*protected override void OnActivated(EventArgs e)
        {
            base.OnActivated(e);
            if (shadowType == MetroFormShadowType.AeroShadow &&
                IsAeroThemeEnabled() && IsDropShadowSupported())
            {
                int val = 2;
                DwmApi.DwmSetWindowAttribute(Handle, 2, ref val, 4);
                var m = new DwmApi.MARGINS
                {
                    cyBottomHeight = 1,
                    cxLeftWidth = 0,
                    cxRightWidth = 0,
                    cyTopHeight = 0
                };

                DwmApi.DwmExtendFrameIntoClientArea(Handle, ref m);
            }
        }*/

        protected override void OnEnabledChanged(EventArgs e)
        {
            base.OnEnabledChanged(e);

            Invalidate();
        }

        protected override void OnResizeEnd(EventArgs e)
        {
            base.OnResizeEnd(e);
        }

        const int HTLEFT = 10;
        const int HTRIGHT = 11;
        const int HTTOP = 12;
        const int HTTOPLEFT = 13;
        const int HTTOPRIGHT = 14;
        const int HTBOTTOM = 15;
        const int HTBOTTOMLEFT = 0x10;
        const int HTBOTTOMRIGHT = 17;

        protected override void WndProc(ref Message m)
        {
            if (DesignMode)
            {
                base.WndProc(ref m);
                return;
            }


            switch (m.Msg)
            {
                case (int)WinApi.Messages.WM_SYSCOMMAND:
                    int sc = m.WParam.ToInt32() & 0xFFF0;
                    switch (sc)
                    {
                        case (int)WinApi.Messages.SC_MOVE:
                            if (!Movable) return;
                            break;
                        case (int)WinApi.Messages.SC_MAXIMIZE:
                            break;
                        case (int)WinApi.Messages.SC_RESTORE:
                            break;
                    }
                    break;

                case (int)WinApi.Messages.WM_NCLBUTTONDBLCLK:
                case (int)WinApi.Messages.WM_LBUTTONDBLCLK:
                    if (!MaximizeBox) return;
                    break;

                case (int)WinApi.Messages.WM_NCHITTEST:
                    WinApi.HitTest ht = HitTestNCA(m.HWnd, m.WParam, m.LParam);
                    if (ht != WinApi.HitTest.HTCLIENT)
                    {
                        m.Result = (IntPtr)ht;
                        return;
                    }
                    break;

                case (int)WinApi.Messages.WM_DWMCOMPOSITIONCHANGED:
                    break;
            }

            base.WndProc(ref m);

            if (Resizable)
            {
                switch (m.Msg)
                {
                    case (int)WinApi.Messages.WM_GETMINMAXINFO:
                        OnGetMinMaxInfo(m.HWnd, m.LParam);
                        break;
                    case (int)WinApi.Messages.WM_NCHITTEST:
                        Point vPoint = new Point((int)m.LParam & 0xFFFF,
                            (int)m.LParam >> 16 & 0xFFFF);
                        vPoint = PointToClient(vPoint);
                        if (vPoint.X <= 5)//LeftResizable
                        {
                            if (LeftResizable)
                                m.Result = (IntPtr)HTLEFT;
                        }
                        else if (vPoint.X >= ClientSize.Width - 5)
                        {
                            if (RightResizable)
                                m.Result = (IntPtr)HTRIGHT;
                        }
                        else if (vPoint.Y <= 5)
                        {
                            if (TopResizable)
                                m.Result = (IntPtr)HTTOP;
                        }
                        else if (vPoint.Y >= ClientSize.Height - 5)
                        {
                            if (BottomResizable)
                                m.Result = (IntPtr)HTBOTTOM;
                        }
                        break;
                }
            }
        }

        [SecuritySafeCritical]
        private unsafe void OnGetMinMaxInfo(IntPtr hwnd, IntPtr lParam)
        {
            WinApi.MINMAXINFO* pmmi = (WinApi.MINMAXINFO*)lParam;

            //YOROCA MDI PARENT
            Screen s = Screen.FromHandle(hwnd);
            //if (IsMdiChild)
            if(this.Parent != null)
            {
                pmmi->ptMaxSize.x = this.Parent.ClientRectangle.Size.Width;
                pmmi->ptMaxSize.y = this.Parent.ClientRectangle.Size.Height;
            }
            else
            {
                pmmi->ptMaxSize.x = s.WorkingArea.Width;
                pmmi->ptMaxSize.y = s.WorkingArea.Height;
            }
            pmmi->ptMaxPosition.x = Math.Abs(s.WorkingArea.Left - s.Bounds.Left);
            pmmi->ptMaxPosition.y = Math.Abs(s.WorkingArea.Top - s.Bounds.Top);

            //if (MinimumSize.Width > 0) pmmi->ptMinTrackSize.x = MinimumSize.Width;
            //if (MinimumSize.Height > 0) pmmi->ptMinTrackSize.y = MinimumSize.Height;
            //if (MaximumSize.Width > 0) pmmi->ptMaxTrackSize.x = MaximumSize.Width;
            //if (MaximumSize.Height > 0) pmmi->ptMaxTrackSize.y = MaximumSize.Height;
        }

        private WinApi.HitTest HitTestNCA(IntPtr hwnd, IntPtr wparam, IntPtr lparam)
        {
            //Point vPoint = PointToClient(new Point((int)lparam & 0xFFFF, (int)lparam >> 16 & 0xFFFF));
            //Point vPoint = PointToClient(new Point((Int16)lparam, (Int16)((int)lparam >> 16)));
            Point vPoint = new Point((Int16)lparam, (Int16)((int)lparam >> 16));
            int vPadding = Math.Max(Padding.Right, Padding.Bottom);

            if (Resizable)
            {
                int padding = vPadding < 6 ? 6 : vPadding;
                if (RectangleToScreen(new Rectangle(ClientRectangle.Width - padding, ClientRectangle.Height - padding, padding, padding)).Contains(vPoint))
                    return WinApi.HitTest.HTBOTTOMRIGHT;
            }

            if (RectangleToScreen(new Rectangle(borderWidth, borderWidth, ClientRectangle.Width - 2 * borderWidth, 50)).Contains(vPoint))
                return WinApi.HitTest.HTCAPTION;

            return WinApi.HitTest.HTCLIENT;
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);

            if (e.Button == MouseButtons.Left && Movable)
            {
                if (WindowState == FormWindowState.Maximized) return;
                if (Width - borderWidth > e.Location.X && e.Location.X > borderWidth && e.Location.Y > borderWidth)
                {
                    MoveControl();
                }
            }

        }

        [SecuritySafeCritical]
        private void MoveControl()
        {
            WinApi.ReleaseCapture();
            WinApi.SendMessage(Handle, (int)WinApi.Messages.WM_NCLBUTTONDOWN, (int)WinApi.HitTest.HTCAPTION, 0);
        }

        [SecuritySafeCritical]
        private static bool IsAeroThemeEnabled()
        {
            if (Environment.OSVersion.Version.Major <= 5) return false;

            bool aeroEnabled;
            DwmApi.DwmIsCompositionEnabled(out aeroEnabled);
            return aeroEnabled;
        }

        private static bool IsDropShadowSupported()
        {
            return Environment.OSVersion.Version.Major > 5 && SystemInformation.IsDropShadowEnabled;
        }

        #endregion

        #region Shadows

        private const int CS_DROPSHADOW = 0x20000;
        const int WS_MINIMIZEBOX = 0x20000;
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.Style |= WS_MINIMIZEBOX;
                return cp;
            }
        }

        #region MetroShadowBase

        protected abstract class MetroShadowBase : Form
        {
            protected Form TargetForm { get; private set; }

            private readonly int shadowSize;
            private readonly int wsExStyle;

            protected MetroShadowBase(Form targetForm, int shadowSize, int wsExStyle)
            {
                TargetForm = targetForm;
                this.shadowSize = shadowSize;
                this.wsExStyle = wsExStyle;

                TargetForm.Activated += OnTargetFormActivated;
                TargetForm.ResizeBegin += OnTargetFormResizeBegin;
                TargetForm.ResizeEnd += OnTargetFormResizeEnd;
                TargetForm.VisibleChanged += OnTargetFormVisibleChanged;
                TargetForm.SizeChanged += OnTargetFormSizeChanged;

                TargetForm.Move += OnTargetFormMove;
                TargetForm.Resize += OnTargetFormResize;

                if (TargetForm.Owner != null)
                    Owner = TargetForm.Owner;

                TargetForm.Owner = this;

                MaximizeBox = false;
                MinimizeBox = false;
                ShowInTaskbar = false;
                ShowIcon = false;
                FormBorderStyle = FormBorderStyle.None;

                Bounds = GetShadowBounds();
            }

            protected override CreateParams CreateParams
            {
                get
                {
                    CreateParams cp = base.CreateParams;
                    cp.ExStyle |= wsExStyle;
                    return cp;
                }
            }

            private Rectangle GetShadowBounds()
            {
                Rectangle r = TargetForm.Bounds;
                r.Inflate(shadowSize, shadowSize);
                return r;
            }

            protected abstract void PaintShadow();

            protected abstract void ClearShadow();

            #region Event Handlers

            private bool isBringingToFront;

            protected override void OnDeactivate(EventArgs e)
            {
                base.OnDeactivate(e);
                isBringingToFront = true;
            }

            private void OnTargetFormActivated(object sender, EventArgs e)
            {
                if (Visible) Update();
                if (isBringingToFront)
                {
                    Visible = true;
                    isBringingToFront = false;
                    return;
                }
                BringToFront();
            }

            private void OnTargetFormVisibleChanged(object sender, EventArgs e)
            {
                Visible = TargetForm.Visible && TargetForm.WindowState != FormWindowState.Minimized;
                Update();
            }

            private long lastResizedOn;

            private bool IsResizing { get { return lastResizedOn > 0; } }

            private void OnTargetFormResizeBegin(object sender, EventArgs e)
            {
                lastResizedOn = DateTime.Now.Ticks;
            }

            private void OnTargetFormMove(object sender, EventArgs e)
            {
                if (!TargetForm.Visible || TargetForm.WindowState != FormWindowState.Normal)
                {
                    Visible = false;
                }
                else
                {
                    Bounds = GetShadowBounds();
                }
            }

            private void OnTargetFormResize(object sender, EventArgs e)
            {
                ClearShadow();
            }

            private void OnTargetFormSizeChanged(object sender, EventArgs e)
            {
                Bounds = GetShadowBounds();

                if (IsResizing)
                {
                    return;
                }

                PaintShadowIfVisible();
            }

            private void OnTargetFormResizeEnd(object sender, EventArgs e)
            {
                lastResizedOn = 0;
                PaintShadowIfVisible();
            }

            private void PaintShadowIfVisible()
            {
                if (TargetForm.Visible && TargetForm.WindowState != FormWindowState.Minimized)
                    PaintShadow();
            }

            #endregion

            #region Constants

            protected const int WS_EX_TRANSPARENT = 0x20;
            protected const int WS_EX_LAYERED = 0x80000;
            protected const int WS_EX_NOACTIVATE = 0x8000000;

            private const int TICKS_PER_MS = 10000;
            private const long RESIZE_REDRAW_INTERVAL = 1000 * TICKS_PER_MS;

            #endregion
        }

        #endregion

        #region Aero DropShadow

        protected class MetroAeroDropShadow : MetroShadowBase
        {
            public MetroAeroDropShadow(Form targetForm)
                : base(targetForm, 0, WS_EX_TRANSPARENT | WS_EX_NOACTIVATE)
            {
                FormBorderStyle = FormBorderStyle.SizableToolWindow;
            }

            protected override void SetBoundsCore(int x, int y, int width, int height, BoundsSpecified specified)
            {
                if (specified == BoundsSpecified.Size) return;
                base.SetBoundsCore(x, y, width, height, specified);
            }

            protected override void PaintShadow() { Visible = true; }

            protected override void ClearShadow() { }

        }

        #endregion

        #region Flat DropShadow

        protected class MetroFlatDropShadow : MetroShadowBase
        {
            private Point Offset = new Point(-6, -6);

            public MetroFlatDropShadow(Form targetForm)
                : base(targetForm, 6, WS_EX_LAYERED | WS_EX_TRANSPARENT | WS_EX_NOACTIVATE)
            {
            }

            protected override void OnLoad(EventArgs e)
            {
                base.OnLoad(e);
                PaintShadow();
            }

            protected override void OnPaint(PaintEventArgs e)
            {
                Visible = true;
                PaintShadow();
            }

            protected override void PaintShadow()
            {
                using (Bitmap getShadow = DrawBlurBorder())
                    SetBitmap(getShadow, 255);
            }

            protected override void ClearShadow()
            {
                Bitmap img = new Bitmap(Width, Height, PixelFormat.Format32bppArgb);
                Graphics g = Graphics.FromImage(img);
                g.Clear(Color.Transparent);
                g.Flush();
                g.Dispose();
                SetBitmap(img, 255);
                img.Dispose();
            }

            #region Drawing methods

            [SecuritySafeCritical]
            private void SetBitmap(Bitmap bitmap, byte opacity)
            {
                if (bitmap.PixelFormat != PixelFormat.Format32bppArgb)
                    throw new ApplicationException("The bitmap must be 32ppp with alpha-channel.");

                IntPtr screenDc = WinApi.GetDC(IntPtr.Zero);
                IntPtr memDc = WinApi.CreateCompatibleDC(screenDc);
                IntPtr hBitmap = IntPtr.Zero;
                IntPtr oldBitmap = IntPtr.Zero;

                try
                {
                    hBitmap = bitmap.GetHbitmap(Color.FromArgb(0));
                    oldBitmap = WinApi.SelectObject(memDc, hBitmap);

                    WinApi.SIZE size = new WinApi.SIZE(bitmap.Width, bitmap.Height);
                    WinApi.POINT pointSource = new WinApi.POINT(0, 0);
                    WinApi.POINT topPos = new WinApi.POINT(Left, Top);
                    WinApi.BLENDFUNCTION blend = new WinApi.BLENDFUNCTION();
                    blend.BlendOp = WinApi.AC_SRC_OVER;
                    blend.BlendFlags = 0;
                    blend.SourceConstantAlpha = opacity;
                    blend.AlphaFormat = WinApi.AC_SRC_ALPHA;

                    WinApi.UpdateLayeredWindow(Handle, screenDc, ref topPos, ref size, memDc, ref pointSource, 0, ref blend, WinApi.ULW_ALPHA);
                }
                finally
                {
                    WinApi.ReleaseDC(IntPtr.Zero, screenDc);
                    if (hBitmap != IntPtr.Zero)
                    {
                        WinApi.SelectObject(memDc, oldBitmap);
                        WinApi.DeleteObject(hBitmap);
                    }
                    WinApi.DeleteDC(memDc);
                }
            }

            private Bitmap DrawBlurBorder()
            {
                return (Bitmap)DrawOutsetShadow(Color.Black, new Rectangle(0, 0, ClientRectangle.Width, ClientRectangle.Height));
            }

            private Image DrawOutsetShadow(Color color, Rectangle shadowCanvasArea)
            {
                Rectangle rOuter = shadowCanvasArea;
                Rectangle rInner = new Rectangle(shadowCanvasArea.X + (-Offset.X - 1), shadowCanvasArea.Y + (-Offset.Y - 1), shadowCanvasArea.Width - (-Offset.X * 2 - 1), shadowCanvasArea.Height - (-Offset.Y * 2 - 1));

                Bitmap img = new Bitmap(rOuter.Width, rOuter.Height, PixelFormat.Format32bppArgb);
                Graphics g = Graphics.FromImage(img);
                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;

                using (Brush bgBrush = new SolidBrush(Color.FromArgb(30, Color.Black)))
                {
                    g.FillRectangle(bgBrush, rOuter);
                }
                using (Brush bgBrush = new SolidBrush(Color.FromArgb(60, Color.Black)))
                {
                    g.FillRectangle(bgBrush, rInner);
                }

                g.Flush();
                g.Dispose();

                return img;
            }

            #endregion
        }

        #endregion

        #region Realistic DropShadow

        protected class MetroRealisticDropShadow : MetroShadowBase
        {
            public MetroRealisticDropShadow(Form targetForm)
                : base(targetForm, 15, WS_EX_LAYERED | WS_EX_TRANSPARENT | WS_EX_NOACTIVATE)
            {
            }

            protected override void OnLoad(EventArgs e)
            {
                base.OnLoad(e);
                PaintShadow();
            }

            protected override void OnPaint(PaintEventArgs e)
            {
                Visible = true;
                PaintShadow();
            }

            protected override void PaintShadow()
            {
                using (Bitmap getShadow = DrawBlurBorder())
                    SetBitmap(getShadow, 255);
            }

            protected override void ClearShadow()
            {
                Bitmap img = new Bitmap(Width, Height, PixelFormat.Format32bppArgb);
                Graphics g = Graphics.FromImage(img);
                g.Clear(Color.Transparent);
                g.Flush();
                g.Dispose();
                SetBitmap(img, 255);
                img.Dispose();
            }

            #region Drawing methods

            [SecuritySafeCritical]
            private void SetBitmap(Bitmap bitmap, byte opacity)
            {
                if (bitmap.PixelFormat != PixelFormat.Format32bppArgb)
                    throw new ApplicationException("The bitmap must be 32ppp with alpha-channel.");

                IntPtr screenDc = WinApi.GetDC(IntPtr.Zero);
                IntPtr memDc = WinApi.CreateCompatibleDC(screenDc);
                IntPtr hBitmap = IntPtr.Zero;
                IntPtr oldBitmap = IntPtr.Zero;

                try
                {
                    hBitmap = bitmap.GetHbitmap(Color.FromArgb(0));
                    oldBitmap = WinApi.SelectObject(memDc, hBitmap);

                    WinApi.SIZE size = new WinApi.SIZE(bitmap.Width, bitmap.Height);
                    WinApi.POINT pointSource = new WinApi.POINT(0, 0);
                    WinApi.POINT topPos = new WinApi.POINT(Left, Top);
                    WinApi.BLENDFUNCTION blend = new WinApi.BLENDFUNCTION
                        {
                            BlendOp = WinApi.AC_SRC_OVER,
                            BlendFlags = 0,
                            SourceConstantAlpha = opacity,
                            AlphaFormat = WinApi.AC_SRC_ALPHA
                        };

                    WinApi.UpdateLayeredWindow(Handle, screenDc, ref topPos, ref size, memDc, ref pointSource, 0, ref blend, WinApi.ULW_ALPHA);
                }
                finally
                {
                    WinApi.ReleaseDC(IntPtr.Zero, screenDc);
                    if (hBitmap != IntPtr.Zero)
                    {
                        WinApi.SelectObject(memDc, oldBitmap);
                        WinApi.DeleteObject(hBitmap);
                    }
                    WinApi.DeleteDC(memDc);
                }
            }

            private Bitmap DrawBlurBorder()
            {
                return (Bitmap)DrawOutsetShadow(0, 0, 40, 1, Color.Black, new Rectangle(1, 1, ClientRectangle.Width, ClientRectangle.Height));
            }

            private Image DrawOutsetShadow(int hShadow, int vShadow, int blur, int spread, Color color, Rectangle shadowCanvasArea)
            {
                Rectangle rOuter = shadowCanvasArea;
                Rectangle rInner = shadowCanvasArea;
                rInner.Offset(hShadow, vShadow);
                rInner.Inflate(-blur, -blur);
                rOuter.Inflate(spread, spread);
                rOuter.Offset(hShadow, vShadow);

                Rectangle originalOuter = rOuter;

                Bitmap img = new Bitmap(originalOuter.Width, originalOuter.Height, PixelFormat.Format32bppArgb);
                Graphics g = Graphics.FromImage(img);
                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;

                var currentBlur = 0;
                do
                {
                    var transparency = (rOuter.Height - rInner.Height) / (double)(blur * 2 + spread * 2);
                    var shadowColor = Color.FromArgb(((int)(200 * (transparency * transparency))), color);
                    var rOutput = rInner;
                    rOutput.Offset(-originalOuter.Left, -originalOuter.Top);

                    DrawRoundedRectangle(g, rOutput, currentBlur, Pens.Transparent, shadowColor);
                    rInner.Inflate(1, 1);
                    currentBlur = (int)((double)blur * (1 - (transparency * transparency)));

                } while (rOuter.Contains(rInner));

                g.Flush();
                g.Dispose();

                return img;
            }

            private void DrawRoundedRectangle(Graphics g, Rectangle bounds, int cornerRadius, Pen drawPen, Color fillColor)
            {
                int strokeOffset = Convert.ToInt32(Math.Ceiling(drawPen.Width));
                bounds = Rectangle.Inflate(bounds, -strokeOffset, -strokeOffset);

                var gfxPath = new GraphicsPath();

                if (cornerRadius > 0)
                {
                    gfxPath.AddArc(bounds.X, bounds.Y, cornerRadius, cornerRadius, 180, 90);
                    gfxPath.AddArc(bounds.X + bounds.Width - cornerRadius, bounds.Y, cornerRadius, cornerRadius, 270, 90);
                    gfxPath.AddArc(bounds.X + bounds.Width - cornerRadius, bounds.Y + bounds.Height - cornerRadius, cornerRadius, cornerRadius, 0, 90);
                    gfxPath.AddArc(bounds.X, bounds.Y + bounds.Height - cornerRadius, cornerRadius, cornerRadius, 90, 90);
                }
                else
                {
                    gfxPath.AddRectangle(bounds);
                }

                gfxPath.CloseAllFigures();

                if (cornerRadius > 5)
                {
                    using (SolidBrush b = new SolidBrush(fillColor))
                    {
                        g.FillPath(b, gfxPath);
                    }
                }
                if (drawPen != Pens.Transparent)
                {
                    using (Pen p = new Pen(drawPen.Color))
                    {
                        p.EndCap = p.StartCap = LineCap.Round;
                        g.DrawPath(p, gfxPath);
                    }
                }
            }

            #endregion
        }

        #endregion

        #endregion

        #region Helper Methods

        [SecuritySafeCritical]
        public void RemoveCloseButton()
        {
            IntPtr hMenu = WinApi.GetSystemMenu(Handle, false);
            if (hMenu == IntPtr.Zero) return;

            int n = WinApi.GetMenuItemCount(hMenu);
            if (n <= 0) return;

            WinApi.RemoveMenu(hMenu, (uint)(n - 1), WinApi.MfByposition | WinApi.MfRemove);
            WinApi.RemoveMenu(hMenu, (uint)(n - 2), WinApi.MfByposition | WinApi.MfRemove);
            WinApi.DrawMenuBar(Handle);
        }

        private Rectangle MeasureText(Graphics g, Rectangle clientRectangle, Font font, string text, TextFormatFlags flags)
        {
            var proposedSize = new Size(int.MaxValue, int.MinValue);
            var actualSize = TextRenderer.MeasureText(g, text, font, proposedSize, flags);
            return new Rectangle(clientRectangle.X, clientRectangle.Y, actualSize.Width, actualSize.Height);
        }

        #endregion
    }
}
