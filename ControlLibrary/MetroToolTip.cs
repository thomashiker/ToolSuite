using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ControlLibrary
{
    public class MetroToolTip : ToolTip
    {
        #region interface
        [Category("Customize")]
        public Font Font { get; set; } = new Font("SimSun", 12f);

        [Category("Customize")]
        public Color BackColor { get; set; } = Color.White;

        [Category("Customize")]
        public Color BorderColor { get; set; } = Color.FromArgb(0, 174, 219);

        [Category("Customize")]
        public Color ForeColor { get; set; } = Color.FromArgb(0, 174, 219);
        #endregion

        public MetroToolTip()
        {
            OwnerDraw = true;
            ShowAlways = true;
            base.

            Draw += new DrawToolTipEventHandler(MetroToolTip_Draw);
            Popup += new PopupEventHandler(MetroToolTip_Popup);
        }

        private void MetroToolTip_Popup(object sender, PopupEventArgs e)
        {
            //e.ToolTipSize = new Size(e.ToolTipSize.Width + 24, e.ToolTipSize.Height + 9);
        }

        private void MetroToolTip_Draw(object sender, DrawToolTipEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(BackColor))
            {
                e.Graphics.FillRectangle(b, e.Bounds);
            }
            using (Pen p = new Pen(BorderColor))
            {
                e.Graphics.DrawRectangle(p, new Rectangle(e.Bounds.X, e.Bounds.Y, e.Bounds.Width - 1, e.Bounds.Height - 1));
            }

            TextRenderer.DrawText(e.Graphics, e.ToolTipText, Font, e.Bounds, ForeColor, TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
        }
    }
}
