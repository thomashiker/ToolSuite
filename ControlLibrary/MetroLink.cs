﻿/**
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
using System.Drawing;
using System.ComponentModel;
using System.Windows.Forms;
using System.Drawing.Imaging;

namespace ControlLibrary
{
    [Designer("ControlLibrary.MetroLinkDesigner")]
    [ToolboxBitmap(typeof(LinkLabel))]
    [DefaultEvent("Click")]
    public class MetroLink : Button
    {
        #region Interface

        private Image _image = null;
        [DefaultValue(null)]
        [Category("Customize")]
        public virtual new Image Image
        {
            get { return _image; }
            set
            {
                _image = value;
                createimages();
            }
        }


        private Image _nofocus = null;
        [DefaultValue(null)]
        [Category("Customize")]
        public Image NoFocusImage
        {
            get { return _nofocus; }
            set { _nofocus = value; }
        }


        Int32 _imagesize = 16;

        [DefaultValue(16)]
        [Category("Customize")]
        public Int32 ImageSize
        {
            get { return _imagesize; }
            set
            {
                _imagesize = value;
                Invalidate();
            }
        }

        [Category("Customize")]
        public Font LinkFont { get; set; } = new Font("SimSun", 9f);

        [Category("Customize")]
        public Color HoveredForeColor { get; set; } = Color.Red;

        [Category("Customize")]
        public Color PressedForeColor { get; set; } = Color.Green;

        [Category("Customize")]
        public bool DisplayFocusRectangle { get; set; } = true;
        
        public override string Text
        {
            get
            {
                return base.Text;
            }
            set
            {
                base.Text = value;

                if (AutoSize && _image != null)
                {
                    base.Width = TextRenderer.MeasureText(value, LinkFont).Width;
                    base.Width += _imagesize + 2;
                }
            }
        }

        #endregion

        #region Fields


        [Browsable(false)]
        public override Font Font
        {
            get
            {
                return base.Font;
            }
            set
            {
                base.Font = value;
            }
        }

        private bool isHovered = false;
        private bool isPressed = false;
        private bool isFocused = false;

        #endregion

        #region Constructor

        public MetroLink()
        {
            SetStyle(ControlStyles.SupportsTransparentBackColor |
                     ControlStyles.OptimizedDoubleBuffer |
                     ControlStyles.ResizeRedraw |
                     ControlStyles.UserPaint, true);
        }
        #endregion

        #region Paint Methods

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            try
            {
                Color backColor = BackColor;

                if (backColor.A == 255 && BackgroundImage == null)
                {
                    e.Graphics.Clear(backColor);
                    return;
                }

                base.OnPaintBackground(e);
            }
            catch
            {
                Invalidate();
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            try
            {
                if (GetStyle(ControlStyles.AllPaintingInWmPaint))
                {
                    OnPaintBackground(e);
                }
                OnPaintForeground(e);
            }
            catch
            {
                Invalidate();
            }
        }

        Color foreColor;

        protected virtual void OnPaintForeground(PaintEventArgs e)
        {
            if (isHovered && !isPressed && Enabled)
            {
                foreColor = HoveredForeColor;
            }
            else if (isHovered && isPressed && Enabled)
            {
                foreColor = PressedForeColor;
            }
            else if (!Enabled)
            {
                foreColor = Color.Gray;
            }
            else
            {
                foreColor = ForeColor;
            }

            TextRenderer.DrawText(e.Graphics, Text, LinkFont, ClientRectangle, foreColor);//, MetroPaint.GetTextFormatFlags(TextAlign)

            if (DisplayFocusRectangle && isFocused)
                ControlPaint.DrawFocusRectangle(e.Graphics, ClientRectangle);

            if (_image != null) DrawIcon(e.Graphics);
        }

        private void DrawIcon(Graphics g)
        {
            if (Image != null)
            {
                int _imgW = _imagesize;
                int _imgH = _imagesize;

                if (_imagesize == 0)
                {
                    _imgW = _image.Width;
                    _imgH = _image.Height;
                }

                Point iconLocation = new Point(2, (ClientRectangle.Height - _imagesize) / 2);
                int _filler = 0;

                switch (ImageAlign)
                {
                    case ContentAlignment.BottomCenter:
                        iconLocation = new Point((ClientRectangle.Width - _imgW) / 2, (ClientRectangle.Height - _imgH) - _filler);
                        break;
                    case ContentAlignment.BottomLeft:
                        iconLocation = new Point(_filler, (ClientRectangle.Height - _imgH) - _filler);
                        break;
                    case ContentAlignment.BottomRight:
                        iconLocation = new Point((ClientRectangle.Width - _imgW) - _filler, (ClientRectangle.Height - _imgH) - _filler);
                        break;
                    case ContentAlignment.MiddleCenter:
                        iconLocation = new Point((ClientRectangle.Width - _imgW) / 2, (ClientRectangle.Height - _imgH) / 2);
                        break;
                    case ContentAlignment.MiddleLeft:
                        iconLocation = new Point(_filler, (ClientRectangle.Height - _imgH) / 2);
                        break;
                    case ContentAlignment.MiddleRight:
                        iconLocation = new Point((ClientRectangle.Width - _imgW) - _filler, (ClientRectangle.Height - _imgH) / 2);
                        break;
                    case ContentAlignment.TopCenter:
                        iconLocation = new Point((ClientRectangle.Width - _imgW) / 2, _filler);
                        break;
                    case ContentAlignment.TopLeft:
                        iconLocation = new Point(_filler, _filler);
                        break;
                    case ContentAlignment.TopRight:
                        iconLocation = new Point((ClientRectangle.Width - _imgW) - _filler, _filler);
                        break;
                }

                iconLocation.Y += 1;

                if (_nofocus == null)
                {
                        g.DrawImage((isHovered && !isPressed) ? _lightimg : _lightlightimg, new Rectangle(iconLocation, new Size(_imgW, _imgH)));
                }
                else
                {
                        g.DrawImage((isHovered && !isPressed) ? _image : _nofocus, new Rectangle(iconLocation, new Size(_imgW, _imgH)));
                }
            }
        }

        Image _lightlightimg = null;
        Image _darklightimg = null;
        Image _lightimg = null;
        Image _darkimg = null;

        private void createimages()
        {
            if (_image != null)
            {
                _lightimg = _image;
                _darkimg = ApplyInvert(new Bitmap(_image));

                _darklightimg = ApplyLight(new Bitmap(_darkimg));
                _lightlightimg = ApplyLight(new Bitmap(_lightimg));
            }
        }
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
                    bitmapImage.SetPixel(x, y, Color.FromArgb((int)A, (int)R, (int)G, (int)B));
                }
            }

            return bitmapImage;
        }

        public Bitmap ApplyLight(Bitmap bitmapImage)
        {
            byte A, R, G, B;
            Color pixelColor;

            for (int y = 0; y < bitmapImage.Height; y++)
            {
                for (int x = 0; x < bitmapImage.Width; x++)
                {
                    pixelColor = bitmapImage.GetPixel(x, y);

                    A = pixelColor.A;
                    if (pixelColor.A <= 255 && pixelColor.A >= 100)
                    { A = 90; }

                    R = (byte)(pixelColor.R);
                    G = (byte)(pixelColor.G);
                    B = (byte)(pixelColor.B);
                    bitmapImage.SetPixel(x, y, Color.FromArgb((int)A, (int)R, (int)G, (int)B));
                }
            }

            return bitmapImage;
        }
        #endregion

        #region Focus Methods

        protected override void OnGotFocus(EventArgs e)
        {
            isFocused = true;
            // isHovered = true;
            isPressed = false;
            Invalidate();

            base.OnGotFocus(e);
        }

        protected override void OnLostFocus(EventArgs e)
        {
            isFocused = false;
            isHovered = false;
            isPressed = false;
            Invalidate();

            base.OnLostFocus(e);
        }

        protected override void OnEnter(EventArgs e)
        {
            isFocused = true;
            //isHovered = true;
            isPressed = true;
            Invalidate();

            base.OnEnter(e);
        }

        protected override void OnLeave(EventArgs e)
        {
            isFocused = false;
            isHovered = false;
            isPressed = false;
            Invalidate();

            base.OnLeave(e);
        }

        #endregion

        #region Keyboard Methods

        protected override void OnKeyDown(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                isHovered = true;
                isPressed = true;
                Invalidate();
            }

            base.OnKeyDown(e);
        }

        protected override void OnKeyUp(KeyEventArgs e)
        {
            if (!isFocused)
            {
                isHovered = false;
                isPressed = false;
            }
            Invalidate();

            base.OnKeyUp(e);
        }

        #endregion

        #region Mouse Methods

        protected override void OnMouseEnter(EventArgs e)
        {
            isHovered = true;
            Invalidate();

            base.OnMouseEnter(e);
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isPressed = true;
                Invalidate();

                if (Name == "lnkClear" && Parent.GetType().Name == "MetroTextBox") this.PerformClick();
                if (Name == "lnkClear" && Parent.GetType().Name == "SearchControl") this.PerformClick();
            }

            base.OnMouseDown(e);
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            isPressed = false;
            Invalidate();

            base.OnMouseUp(e);
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            isHovered = false;
            isPressed = false;

            Invalidate();

            base.OnMouseLeave(e);
        }

        #endregion

        #region Overridden Methods

        protected override void OnEnabledChanged(EventArgs e)
        {
            base.OnEnabledChanged(e);
            Invalidate();
        }

        #endregion
    }
}
