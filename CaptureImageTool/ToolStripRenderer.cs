using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace CSharpWin
{
    public class ToolStripRenderer : ToolStripProfessionalRenderer
    {
        private static Rectangle[] baseSizeGripRectangles =
        {
            new Rectangle(6,0,1,1),
            new Rectangle(6,2,1,1),
            new Rectangle(6,4,1,1),
            new Rectangle(6,6,1,1),
            new Rectangle(4,2,1,1),
            new Rectangle(4,4,1,1),
            new Rectangle(4,6,1,1),
            new Rectangle(2,4,1,1),
            new Rectangle(2,6,1,1),
            new Rectangle(0,6,1,1)
        };

        private const int GRIP_PADDING = 4;
        //private SolidBrush _statusBarBrush;
        //private SolidBrush _statusGripBrush;
        //private SolidBrush _statusGripAccentBrush;
        private SolidBrush _toolBarBrush;
        private SolidBrush _gripBrush;
        private Pen _toolBarBorderPen;
        //private VisualStudioColorTable _table;
        //private DockPanelColorPalette _palette;

        public bool UseGlassOnMenuStrip { get; set; }

        /*public VisualStudioToolStripRenderer(DockPanelColorPalette palette)
            : base(new VisualStudioColorTable(palette))*/
        public ToolStripRenderer()
        {
            //_table = (VisualStudioColorTable)ColorTable;
            //_palette = palette;
            RoundedEdges = false;
            //_statusBarBrush = new SolidBrush(Color.White);// palette.MainWindowStatusBarDefault.Background);
            //_statusGripBrush = new SolidBrush(Color.Black);// palette.MainWindowStatusBarDefault.ResizeGrip);
            //_statusGripAccentBrush = new SolidBrush(Color.Black);// palette.MainWindowStatusBarDefault.ResizeGripAccent);
            _toolBarBrush = new SolidBrush(Color.White);//palette.CommandBarToolbarDefault.Background);
            _gripBrush = new SolidBrush(Color.Black);// palette.CommandBarToolbarDefault.Grip);
            _toolBarBorderPen = new Pen(Color.Transparent);// palette.CommandBarToolbarDefault.Border);

            UseGlassOnMenuStrip = true;
        }

        public Color ToolBarBackground
        {
            set
            {
                _toolBarBrush = new SolidBrush(value);
            }
        }

        public Color ToolBarBorder
        {
            set
            {
                _toolBarBorderPen = new Pen(value);
            }
        }

        public Color ItemNormalColor { get; set; } = Color.FromArgb(0, 174, 219);

        public void Refresh()
        {
                //_toolBarBrush = new SolidBrush(Color.White);//_palette.CommandBarToolbarDefault.Background);
                //_toolBarBorderPen = new Pen(Color.Transparent);//_palette.CommandBarToolbarDefault.Border);
        }

        #region Rendering Improvements (includes fixes for bugs occured when Windows Classic theme is on).
        //*
        protected override void OnRenderMenuItemBackground(ToolStripItemRenderEventArgs e)
        {
            // Do not draw disabled item background.
            if (e.Item.Enabled)
            {
                bool isMenuDropDown = e.Item.Owner is MenuStrip;
                if (isMenuDropDown && e.Item.Pressed)
                {
                    base.OnRenderMenuItemBackground(e);
                }
                else if (e.Item.Selected)
                {
                    // Rect of item's content area.
                    Rectangle contentRect = e.Item.ContentRectangle;

                    // Fix item rect.
                    Rectangle itemRect = isMenuDropDown
                                             ? new Rectangle(
                                                   contentRect.X + 2, contentRect.Y - 2,
                                                   contentRect.Width - 5, contentRect.Height + 3)
                                             : new Rectangle(
                                                   contentRect.X, contentRect.Y - 1,
                                                   contentRect.Width, contentRect.Height + 1);

                    // Border pen and fill brush.
                    Color pen = ColorTable.MenuItemBorder;
                    Color brushBegin;
                    Color brushEnd;

                    if (isMenuDropDown)
                    {
                        brushBegin = ColorTable.MenuItemSelectedGradientBegin;
                        brushEnd = ColorTable.MenuItemSelectedGradientEnd;
                    }
                    else
                    {
                        brushBegin = ColorTable.MenuItemSelected;
                        brushEnd = Color.Empty;
                    }

                    DrawRectangle(e.Graphics, itemRect, brushBegin, brushEnd, pen, UseGlassOnMenuStrip);
                }
            }
        }

        protected override void OnRenderToolStripBorder(ToolStripRenderEventArgs e)
        {
            var status = e.ToolStrip as StatusStrip;
            if (status != null)
            {
                // IMPORTANT: left empty to remove white border.
                return;
            }

            var context = e.ToolStrip as MenuStrip;
            if (context != null)
            {
                base.OnRenderToolStripBorder(e);
                return;
            }

            var drop = e.ToolStrip as ToolStripDropDown;
            if (drop != null)
            {
                base.OnRenderToolStripBorder(e);
                return;
            }

            var rect = e.ToolStrip.ClientRectangle;
            e.Graphics.DrawRectangle(_toolBarBorderPen, new Rectangle(rect.Location, new Size(rect.Width - 1, rect.Height - 1)));
        }

        protected override void OnRenderToolStripBackground(ToolStripRenderEventArgs e)
        {
            var status = e.ToolStrip as StatusStrip;
            if (status != null)
            {
                base.OnRenderToolStripBackground(e);
                return;
            }

            var context = e.ToolStrip as MenuStrip;
            if (context != null)
            {
                base.OnRenderToolStripBackground(e);
                return;
            }

            var drop = e.ToolStrip as ToolStripDropDown;
            if (drop != null)
            {
                base.OnRenderToolStripBackground(e);
                return;
            }

            e.Graphics.FillRectangle(_toolBarBrush, e.ToolStrip.ClientRectangle);
        }

        protected override void OnRenderGrip(ToolStripGripRenderEventArgs e)
        {
            Graphics g = e.Graphics;
            Rectangle bounds = e.GripBounds;
            ToolStrip toolStrip = e.ToolStrip;

            bool rightToLeft = (e.ToolStrip.RightToLeft == RightToLeft.Yes);

            int height = (toolStrip.Orientation == Orientation.Horizontal) ? bounds.Height : bounds.Width;
            int width = (toolStrip.Orientation == Orientation.Horizontal) ? bounds.Width : bounds.Height;

            int numRectangles = (height - (GRIP_PADDING * 2)) / 4;

            if (numRectangles > 0)
            {
                numRectangles++;
                // a MenuStrip starts its grip lower and has fewer grip rectangles.
                int yOffset = (toolStrip is MenuStrip) ? 2 : 0;

                Rectangle[] shadowRects = new Rectangle[numRectangles];
                int startY = GRIP_PADDING + 1 + yOffset;
                int startX = (width / 2);

                for (int i = 0; i < numRectangles; i++)
                {
                    shadowRects[i] = (toolStrip.Orientation == Orientation.Horizontal) ?
                                        new Rectangle(startX, startY, 1, 1) :
                                        new Rectangle(startY, startX, 1, 1);

                    startY += 4;
                }

                // in RTL the GripLight rects should paint to the left of the GripDark rects.
                int xOffset = (rightToLeft) ? 2 : -2;

                if (rightToLeft)
                {
                    // scoot over the rects in RTL so they fit within the bounds.
                    for (int i = 0; i < numRectangles; i++)
                    {
                        shadowRects[i].Offset(-xOffset, 0);
                    }
                }

                Brush b = _gripBrush;
                for (int i = 0; i < numRectangles - 1; i++)
                {
                    g.FillRectangle(b, shadowRects[i]);
                }

                for (int i = 0; i < numRectangles; i++)
                {
                    shadowRects[i].Offset(xOffset, -2);
                }

                g.FillRectangles(b, shadowRects);

                for (int i = 0; i < numRectangles; i++)
                {
                    shadowRects[i].Offset(-2 * xOffset, 0);
                }

                g.FillRectangles(b, shadowRects);
            }
        }

        /*
         * ¼ÓÉî£ºcorrectionFactor<0
           ±äÁÁ£ºcorrectionFactor>0
           -1.0f <= correctionFactor <= 1.0f
        */
        private static Color ChangeColor(Color color, float correctionFactor)
        {
            float red = (float)color.R;
            float green = (float)color.G;
            float blue = (float)color.B;

            if (correctionFactor < 0)
            {
                correctionFactor = 1 + correctionFactor;
                red *= correctionFactor;
                green *= correctionFactor;
                blue *= correctionFactor;
            }
            else
            {
                red = (255 - red) * correctionFactor + red;
                green = (255 - green) * correctionFactor + green;
                blue = (255 - blue) * correctionFactor + blue;
            }

            if (red < 0) red = 0;

            if (red > 255) red = 255;

            if (green < 0) green = 0;

            if (green > 255) green = 255;

            if (blue < 0) blue = 0;

            if (blue > 255) blue = 255;



            return Color.FromArgb(color.A, (int)red, (int)green, (int)blue);
        }

        protected override void OnRenderButtonBackground(ToolStripItemRenderEventArgs e)
        {
            ToolStripButton button = e.Item as ToolStripButton;
            if (button != null && button.Enabled)
            {
                if (button.Selected || button.Checked)
                {
                    // Rect of item's content area.
                    Rectangle contentRect = new Rectangle(0, 0, button.Width - 1, button.Height - 1);

                    Color pen;
                    Color brushBegin;
                    Color brushMiddle;
                    Color brushEnd;

                    if (button.Checked)
                    {
                        if (button.Selected)
                        {
                            pen = ItemNormalColor;// _table.ButtonCheckedHoveredBorder;
                            brushBegin = ItemNormalColor;// _table.ButtonCheckedHoveredBackground;
                            brushMiddle = ItemNormalColor;// _table.ButtonCheckedHoveredBackground;
                            brushEnd = ItemNormalColor;// _table.ButtonCheckedHoveredBackground;
                        }
                        else
                        {
                            pen = ItemNormalColor;//  _table.ButtonCheckedBorder;
                            brushBegin = ItemNormalColor;//ColorTable.ButtonCheckedGradientBegin;
                            brushMiddle = ItemNormalColor;//ColorTable.ButtonCheckedGradientMiddle;
                            brushEnd = ItemNormalColor;//ColorTable.ButtonCheckedGradientEnd;
                        }
                    }
                    else if (button.Pressed)
                    {
                        pen = ChangeColor(ItemNormalColor, 0.3f);//ColorTable.ButtonPressedBorder;
                        brushBegin = pen;// ColorTable.ButtonPressedGradientBegin;
                        brushMiddle = pen;// ColorTable.ButtonPressedGradientMiddle;
                        brushEnd = pen;// ColorTable.ButtonPressedGradientEnd;
                    }
                    else
                    {
                        pen = ItemNormalColor; //ColorTable.ButtonSelectedBorder;
                        brushBegin = ItemNormalColor; //ColorTable.ButtonSelectedGradientBegin;
                        brushMiddle = ItemNormalColor; //ColorTable.ButtonSelectedGradientMiddle;
                        brushEnd = ItemNormalColor; //ColorTable.ButtonSelectedGradientEnd;
                    }

                    DrawRectangle(e.Graphics, contentRect,
                        brushBegin, brushMiddle, brushEnd, pen, false);
                }
            }
            else
            {
                base.OnRenderButtonBackground(e);
            }
        }

        protected override void Initialize(ToolStrip toolStrip)
        {
            base.Initialize(toolStrip);
            // IMPORTANT: enlarge grip area so grip can be rendered fully.
            toolStrip.GripMargin = new Padding(toolStrip.GripMargin.All + 1);
        }

        /*protected override void OnRenderOverflowButtonBackground(ToolStripItemRenderEventArgs e)
        {
            var cache = Color.YellowGreen// _palette.CommandBarMenuPopupDefault.BackgroundTop;

            // IMPORTANT: not 100% accurate as the color change should only happen when the overflow menu is hovered.
            // here color change happens when the overflow menu is displayed.
            if (e.Item.Pressed)
                _palette.CommandBarMenuPopupDefault.BackgroundTop = _palette.CommandBarToolbarOverflowPressed.Background;
            base.OnRenderOverflowButtonBackground(e);
            if (e.Item.Pressed)
                _palette.CommandBarMenuPopupDefault.BackgroundTop = cache;
        }*/

        /*protected override void OnRenderItemText(ToolStripItemTextRenderEventArgs e)
        {
            Color color = Color.Black;
            var toolStrip = e.ToolStrip;
            if (toolStrip is StatusStrip)
            {
                if (e.Item.Selected)
                {
                    color = Color.Black; //_palette.MainWindowStatusBarDefault.HighlightText;
                }
                else
                {
                    color = Color.Chocolate; //_palette.MainWindowStatusBarDefault.Text;
                }
            }
            else if (toolStrip is MenuStrip)
            {
                var button = e.Item as ToolStripButton;
                var checkedButton = button != null && button.Checked;
                if (!e.Item.Enabled)
                {
                    color = _palette.CommandBarMenuPopupDisabled.Text;
                }
                else if (button != null && button.Pressed)
                {
                    color = _palette.CommandBarToolbarButtonPressed.Text;
                }
                else if (e.Item.Selected && checkedButton)
                {
                    color = _palette.CommandBarToolbarButtonCheckedHovered.Text;
                }
                else if (e.Item.Selected)
                {
                    color = _palette.CommandBarMenuTopLevelHeaderHovered.Text;
                }
                else if (checkedButton)
                {
                    color = _palette.CommandBarToolbarButtonChecked.Text;
                }
                else
                {
                    color = _palette.CommandBarMenuDefault.Text;
                }
            }
            else if (toolStrip is ToolStripDropDown)
            {
                // This might differ from above branch, but left the same here.
                var button = e.Item as ToolStripButton;
                var checkedButton = button != null && button.Checked;
                if (!e.Item.Enabled)
                {
                    color = _palette.CommandBarMenuPopupDisabled.Text;
                }
                else if (button != null && button.Pressed)
                {
                    color = _palette.CommandBarToolbarButtonPressed.Text;
                }
                else if (e.Item.Selected && checkedButton)
                {
                    color = _palette.CommandBarToolbarButtonCheckedHovered.Text;
                }
                else if (e.Item.Selected)
                {
                    color = _palette.CommandBarMenuTopLevelHeaderHovered.Text;
                }
                else if (checkedButton)
                {
                    color = _palette.CommandBarToolbarButtonChecked.Text;
                }
                else
                {
                    color = _palette.CommandBarMenuDefault.Text;
                }
            }
            else 
            {
                // Default color, if not it will be black no matter what 
                if (!e.Item.Enabled)
                {
                    color = _palette.CommandBarMenuPopupDisabled.Text;
                } 
                else
                {
                    color = _palette.CommandBarMenuDefault.Text;
                }
            }

            TextRenderer.DrawText(e.Graphics, e.Text, e.TextFont, e.TextRectangle, color, e.TextFormat);
        }*/

        #region helpers
        private static void DrawRectangle(Graphics graphics, Rectangle rect, Color brushBegin, 
            Color brushMiddle, Color brushEnd, Color penColor, bool glass)
        {
            RectangleF firstHalf = new RectangleF(
                rect.X, rect.Y, 
                rect.Width, (float)rect.Height / 2);

            RectangleF secondHalf = new RectangleF(
                rect.X, rect.Y + (float)rect.Height / 2, 
                rect.Width, (float)rect.Height / 2);

            if (brushMiddle.IsEmpty && brushEnd.IsEmpty)
            {
                graphics.FillRectangle(new SolidBrush(brushBegin), rect);
            }
            if (brushMiddle.IsEmpty)
            {
                Brush gradient = new LinearGradientBrush(rect, brushBegin,
                    brushEnd, LinearGradientMode.Vertical);

                graphics.FillRectangle(gradient, rect);
            }
            else
            {
                Brush first = new LinearGradientBrush(
                    firstHalf, brushBegin, brushMiddle, LinearGradientMode.Vertical);
                Brush second = new LinearGradientBrush(
                    secondHalf, brushMiddle, brushEnd, LinearGradientMode.Vertical);

                graphics.FillRectangle(first, firstHalf);
                graphics.FillRectangle(second, secondHalf);
            }

            if (glass)
            {
                Brush glassBrush = new SolidBrush(Color.FromArgb(120, Color.White));
                graphics.FillRectangle(glassBrush, firstHalf);
            }

            if (penColor.A > 0)
            {
                graphics.DrawRectangle(new Pen(penColor), rect);
            }
        }

        private static void DrawRectangle(Graphics graphics, Rectangle rect, Color brushBegin,
            Color brushEnd, Color penColor, bool glass)
        {
            DrawRectangle(graphics, rect, brushBegin, Color.Empty, brushEnd, penColor, glass);
        }

        private static void DrawRectangle(Graphics graphics, Rectangle rect, Color brush, 
            Color penColor, bool glass)
        {
            DrawRectangle(graphics, rect, brush, Color.Empty, Color.Empty, penColor, glass);
        }

        private static void FillRoundRectangle(Graphics graphics, Brush brush, Rectangle rect, int radius)
        {
            float fx = Convert.ToSingle(rect.X);
            float fy = Convert.ToSingle(rect.Y);
            float fwidth = Convert.ToSingle(rect.Width);
            float fheight = Convert.ToSingle(rect.Height);
            float fradius = Convert.ToSingle(radius);
            FillRoundRectangle(graphics, brush, fx, fy, fwidth, fheight, fradius);
        }

        private static void FillRoundRectangle(Graphics graphics, Brush brush, float x, float y, float width, float height, float radius)
        {
            RectangleF rectangle = new RectangleF(x, y, width, height);
            GraphicsPath path = GetRoundedRect(rectangle, radius);
            graphics.FillPath(brush, path);
        }

        private static void DrawRoundRectangle(Graphics graphics, Pen pen, Rectangle rect, int radius)
        {
            float fx = Convert.ToSingle(rect.X);
            float fy = Convert.ToSingle(rect.Y);
            float fwidth = Convert.ToSingle(rect.Width);
            float fheight = Convert.ToSingle(rect.Height);
            float fradius = Convert.ToSingle(radius);
            DrawRoundRectangle(graphics, pen, fx, fy, fwidth, fheight, fradius);
        }

        private static void DrawRoundRectangle(Graphics graphics, Pen pen, float x, float y, float width, float height, float radius)
        {
            RectangleF rectangle = new RectangleF(x, y, width, height);
            GraphicsPath path = GetRoundedRect(rectangle, radius);
            graphics.DrawPath(pen, path);
        }

        private static GraphicsPath GetRoundedRect(RectangleF baseRect, float radius)
        {
            // if corner radius is less than or equal to zero, 
            // return the original rectangle 

            if (radius <= 0)
            {
                GraphicsPath mPath = new GraphicsPath();
                mPath.AddRectangle(baseRect);
                mPath.CloseFigure();
                return mPath;
            }

            // if the corner radius is greater than or equal to 
            // half the width, or height (whichever is shorter) 
            // then return a capsule instead of a lozenge 

            if (radius >= (Math.Min(baseRect.Width, baseRect.Height)) / 2.0)
                return GetCapsule(baseRect);

            // create the arc for the rectangle sides and declare 
            // a graphics path object for the drawing 

            float diameter = radius * 2.0F;
            SizeF sizeF = new SizeF(diameter, diameter);
            RectangleF arc = new RectangleF(baseRect.Location, sizeF);
            GraphicsPath path = new GraphicsPath();

            // top left arc 
            path.AddArc(arc, 180, 90);

            // top right arc 
            arc.X = baseRect.Right - diameter;
            path.AddArc(arc, 270, 90);

            // bottom right arc 
            arc.Y = baseRect.Bottom - diameter;
            path.AddArc(arc, 0, 90);

            // bottom left arc
            arc.X = baseRect.Left;
            path.AddArc(arc, 90, 90);

            path.CloseFigure();
            return path;
        }

        private static GraphicsPath GetCapsule(RectangleF baseRect)
        {
            RectangleF arc;
            GraphicsPath path = new GraphicsPath();

            try
            {
                float diameter;
                if (baseRect.Width > baseRect.Height)
                {
                    // return horizontal capsule 
                    diameter = baseRect.Height;
                    SizeF sizeF = new SizeF(diameter, diameter);
                    arc = new RectangleF(baseRect.Location, sizeF);
                    path.AddArc(arc, 90, 180);
                    arc.X = baseRect.Right - diameter;
                    path.AddArc(arc, 270, 180);
                }
                else if (baseRect.Width < baseRect.Height)
                {
                    // return vertical capsule 
                    diameter = baseRect.Width;
                    SizeF sizeF = new SizeF(diameter, diameter);
                    arc = new RectangleF(baseRect.Location, sizeF);
                    path.AddArc(arc, 180, 180);
                    arc.Y = baseRect.Bottom - diameter;
                    path.AddArc(arc, 0, 180);
                }
                else
                {
                    // return circle 
                    path.AddEllipse(baseRect);
                }
            }
            catch
            {
                path.AddEllipse(baseRect);
            }
            finally
            {
                path.CloseFigure();
            }

            return path;
        }
        #endregion
        // */
        #endregion
    }
}