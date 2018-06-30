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
using System.Drawing;
using System.ComponentModel;
using System.Windows.Forms;


namespace FastColoredTextBoxNS
{
    [Designer("FastColoredTextBoxNS.MetroButtonDesigner")]
    [ToolboxBitmap(typeof(Button))]
    [DefaultEvent("Click")]
    public class MetroButton : Button
    {
        #region Interface
        [Category("Customize")]
        public Color BackColor { get; set; } = Color.FromArgb(238, 238, 238);
        [Category("Customize")]
        public Color HoveredBackColor { get; set; } = Color.FromArgb(102, 102, 102);
        [Category("Customize")]
        public Color PressedBackColor { get; set; } = Color.FromArgb(51, 51, 51);
        [Category("Customize")]
        public Color DisabledColor { get; set; } = Color.FromArgb(204, 204, 204);


        [Category("Customize")]
        public Color BorderColor { get; set; } = Color.FromArgb(204, 204, 204);
        [Category("Customize")]
        public Color HoveredBorderColor { get; set; } = Color.FromArgb(102, 102, 102);
        [Category("Customize")]
        public Color PressedBorderColor { get; set; } = Color.FromArgb(51, 51, 51);
        [Category("Customize")]
        public Color DisabledBorderColor { get; set; } = Color.FromArgb(136, 136, 136);


        [Category("Customize")]
        public Color ForeColor { get; set; } = Color.FromArgb(0, 0, 0);
        [Category("Customize")]
        public Color HoveredForeColor { get; set; } = Color.FromArgb(255, 255, 255);
        [Category("Customize")]
        public Color PressedForeColor { get; set; } = Color.FromArgb(255, 255, 255);
        [Category("Customize")]
        public Color DisabledForeColor { get; set; } = Color.FromArgb(136, 136, 136);

        [Category("Customize")]
        public Color HighLightColor { get; set; } = Color.FromArgb(155, 155, 155);


        #endregion

        #region Fields

        private bool displayFocusRectangle = false;
        [DefaultValue(false)]
        [Category("Customize")]
        public bool DisplayFocus
        {
            get { return displayFocusRectangle; }
            set { displayFocusRectangle = value; }
        }

        private bool highlight = false;
        [DefaultValue(false)]
        [Category("Customize")]
        public bool Highlight
        {
            get { return highlight; }
            set { highlight = value; }
        }

        private bool isHovered = false;
        private bool isPressed = false;
        private bool isFocused = false;

        #endregion

        #region Constructor

        public MetroButton()
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

                if (isHovered && !isPressed && Enabled)
                {
                    backColor = HoveredBackColor;
                }
                else if (isHovered && isPressed && Enabled)
                {
                    backColor = PressedBackColor;
                }
                else if (!Enabled)
                {
                    backColor = DisabledColor;
                }
                else
                {
                }

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

        protected virtual void OnPaintForeground(PaintEventArgs e)
        {
            Color borderColor, foreColor;

            if (isHovered && !isPressed && Enabled)
            {
                borderColor = HoveredBorderColor;
                foreColor = HoveredForeColor;
            }
            else if (isHovered && isPressed && Enabled)
            {
                borderColor = PressedBorderColor;
                foreColor = PressedForeColor;
            }
            else if (!Enabled)
            {
                borderColor = DisabledBorderColor;
                foreColor = DisabledForeColor;
            }
            else
            {
                borderColor = BorderColor;
                foreColor = ForeColor;
            }
            
            using (Pen p = new Pen(borderColor))
            {
                Rectangle borderRect = new Rectangle(0, 0, Width - 1, Height - 1);
                e.Graphics.DrawRectangle(p, borderRect);
            }

            if (Highlight && !isHovered && !isPressed && Enabled)
            {
                using (Pen p = new Pen(HighLightColor))
                {
                    Rectangle borderRect = new Rectangle(0, 0, Width - 1, Height - 1);
                    e.Graphics.DrawRectangle(p, borderRect);
                    borderRect = new Rectangle(1, 1, Width - 3, Height - 3);
                    e.Graphics.DrawRectangle(p, borderRect);
                }
            }

            TextRenderer.DrawText(e.Graphics, Text, Font, ClientRectangle, foreColor, TextFormatFlags.HorizontalCenter| TextFormatFlags.VerticalCenter);

            if (displayFocusRectangle && isFocused)
                ControlPaint.DrawFocusRectangle(e.Graphics, ClientRectangle);
        }

        #endregion

        #region Focus Methods

        protected override void OnGotFocus(EventArgs e)
        {
            isFocused = true;
            isHovered = true;
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
            isHovered = true;
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
            //Remove this code cause this prevents the focus color
            //isHovered = false;
            //isPressed = false;
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
            //This will check if control got the focus
            //If not thats the only it will remove the focus color
            if (!isFocused)
            {
                isHovered = false;
            }

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
