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
    public partial class MetroTip : Control
    {
        private LinkLabel link = new LinkLabel();

        public string[] Lines { get; set; }
        public bool ShowBorder { get; set; } = true;
        public Color BorderColor { get; set; } = Color.WhiteSmoke;

        [Category("Link Setting")]
        public Font LinkFont
        {
            get { return link.Font; }
            set { link.Font = value; }
        }

        [Category("Link Setting")]
        public Color LinkColor
        {
            get { return link.LinkColor; }
            set { link.LinkColor = value; }
        }

        private Padding linkPadding = new Padding(0, 0, 0, 0);
        [Category("Link Setting")]
        public Padding LinkPadding
        {
            get { return linkPadding; }
            set
            {
                linkPadding = value;
                Invalidate();
            }
        }

        public MetroTip()
        {
            InitializeComponent();

            link.Text = "More...";
            link.BackColor = Color.Transparent;
            link.LinkColor = Color.FromArgb(0, 174, 219);
            link.AutoSize = true;
            this.Controls.Add(link);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            link.Location = new Point(this.Width - link.Width + linkPadding.Left - linkPadding.Right, this.Height - link.Height + linkPadding.Top - linkPadding.Bottom);

            using (Brush b = new SolidBrush(Color.White))
            {
                e.Graphics.FillRectangle(b, ClientRectangle);
            }

            if (ShowBorder)
            {
                using (Pen p = new Pen(BorderColor))
                {
                    e.Graphics.DrawRectangle(p, ClientRectangle.X, ClientRectangle.Y, ClientRectangle.Width - 1, ClientRectangle.Height - 1);
                }
            }

            StringFormat sf = new StringFormat();
            //sf.Alignment = StringAlignment.;
            sf.LineAlignment = StringAlignment.Near;

            StringBuilder sb = new StringBuilder();
            foreach(string line in Lines)
            {
                sb.AppendLine(line);
            }
            Rectangle rect = new Rectangle(ClientRectangle.X, ClientRectangle.Y, ClientRectangle.Width, link.Location.Y);//ClientRectangle.Height - 
            using (Brush b = new SolidBrush(ForeColor))
            {
                e.Graphics.DrawString(sb.ToString(), Font, b, rect, sf);
            }
        }
    }
}
