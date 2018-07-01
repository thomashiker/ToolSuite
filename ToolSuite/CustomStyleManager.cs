using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using FastColoredTextBoxNS;
using System.Xml.Linq;
using System.IO;
using System.Drawing;

namespace ToolSuite
{
    public partial class CustomStyle: Component
    {
        XDocument _xml;


        //fastcoloredbox
        private Color _TextBoxBackColor = Color.White;
        private Color _IndentBackColor = Color.White;
        private Color _ServiceLineColor = Color.WhiteSmoke;
        private Color _TextColor = Color.Black;
        private Color _CaretColor = Color.Black;
        private Color _BookmarkColor = Color.FromArgb(108, 226, 108);
        private Color _LineNumColor = Color.FromArgb(0, 128, 0);
        private Color _SelectionColor = Color.FromArgb(117, 217, 117);

        //grid
        private Color _GridSelectionColor = Color.FromArgb(0, 174, 219);

        public Color ThemeColor { get; set; } = Color.FromArgb(255, 255, 255);

        public Color StyleColor { get; set; } = Color.FromArgb(0, 174, 219);


        public Color TextBoxBackColor
        {
            get { return _TextBoxBackColor; }
            set
            {
                _TextBoxBackColor = value;
            }
        }


        public Color IndentBackColor
        {
            get { return _IndentBackColor; }
            set
            {
                _IndentBackColor = value;
            }
        }


        public Color ServiceLineColor
        {
            get { return _ServiceLineColor; }
            set
            {
                _ServiceLineColor = value;
            }
        }


        public Color TextColor
        {
            get { return _TextColor; }
            set
            {
                _TextColor = value;
            }
        }


        public Color CaretColor
        {
            get { return _CaretColor; }
            set
            {
                _CaretColor = value;
            }
        }


        public Color BookmarkColor
        {
            get { return _BookmarkColor; }
            set
            {
                _BookmarkColor = value;
            }
        }


        public Color LineNumColor
        {
            get { return _LineNumColor; }
            set
            {
                _LineNumColor = value;
            }
        }

        public Color SelectionColor
        {
            get { return _LineNumColor; }
            set
            {
                _SelectionColor = value;
            }
        }

        //grid
        public Color GridSelectionColor
        {
            get { return _GridSelectionColor; }
            set
            {
                _GridSelectionColor = value;
            }
        }


        public CustomStyle()
        {
        }

        public CustomStyle(CustomStyle style)
        {
            _TextBoxBackColor = style.TextBoxBackColor;
            _TextColor = style.TextColor;
            _IndentBackColor = style.IndentBackColor;
            _ServiceLineColor = style.ServiceLineColor;
            _CaretColor = style.CaretColor;
            _BookmarkColor = style.BookmarkColor;
            _LineNumColor = style.LineNumColor;
            _SelectionColor = style.SelectionColor;
        }

        public CustomStyle(string file)
        {
            LoadTheme(file);
        }

        public void Clone(CustomStyle style)
        {
            _TextBoxBackColor = style.TextBoxBackColor;
            _TextColor = style.TextColor;
            _IndentBackColor = style.IndentBackColor;
            _ServiceLineColor = style.ServiceLineColor;
            _CaretColor = style.CaretColor;
            _BookmarkColor = style.BookmarkColor;
            _LineNumColor = style.LineNumColor;
            _SelectionColor = style.SelectionColor;
        }

        public void Update(FastColoredTextBox fctb)
        {
            fctb.BackColor = _TextBoxBackColor;
            fctb.ForeColor = _TextColor;
            fctb.IndentBackColor = _IndentBackColor;
            fctb.ServiceLinesColor = _ServiceLineColor;
            fctb.CaretColor = _CaretColor;
            fctb.BookmarkColor = _BookmarkColor;
            fctb.LineNumberColor = _LineNumColor;
            fctb.SelectionColor = _SelectionColor;
        }

        private Color ColorTranslatorFromHtml(string name, bool foreground = false)
        {
            if (null == _xml)
            {
                return Color.Empty;
            }

            try
            {
                var color = _xml.Root.Element("Theme")
                .Elements("Color").FirstOrDefault(item => item.Attribute("Name").Value == name)?
                .Element(foreground ? "Foreground" : "Background").Attribute("Source").Value;

                if (color == null)
                {
                    return Color.Empty;// Color.Transparent;
                }

                return ColorTranslator.FromHtml($"#{color}");
            }
            catch
            {
                return Color.Empty;
            }
        }

        private void ColorTranslatorToHtml(string name, Color color, bool foreground = false)
        {
            if (null == _xml)
            {
                return;
            }

            try
            {
                XAttribute attr = _xml.Root.Element("Theme")
                .Elements("Color").FirstOrDefault(item => item.Attribute("Name").Value == name)?
                .Element(foreground ? "Foreground" : "Background").Attribute("Source");

                if (null != attr)
                {
                    attr.SetValue(ColorTranslator.ToHtml(color));
                }
            }
            catch
            {
                //return Color.Empty; ;
            }
        }

        public void LoadTheme(string xmlFile)
        {
            if (File.Exists(xmlFile))
            {
                _xml = XDocument.Load(xmlFile);

                ThemeColor = ColorTranslatorFromHtml("Theme");
                StyleColor = ColorTranslatorFromHtml("Style");

                TextBoxBackColor = ColorTranslatorFromHtml("FastColoredTextBoxBackground");
                TextColor = ColorTranslatorFromHtml("FastColoredTextBoxForeground");
                IndentBackColor = ColorTranslatorFromHtml("FastColoredTextBoxIndent");
                CaretColor = ColorTranslatorFromHtml("FastColoredTextBoxCaret");
                BookmarkColor = ColorTranslatorFromHtml("FastColoredTextBoxBookmark");
                SelectionColor = ColorTranslatorFromHtml("FastColoredTextBoxSelection");
                LineNumColor = ColorTranslatorFromHtml("FastColoredTextBoxLineNumber");
                ServiceLineColor = ColorTranslatorFromHtml("FastColoredTextBoxServiceLine");
            }
        }

        public void SaveTheme(string xmlFile)
        {
            if (null == _xml)
            {
                //create
            }

            //MyStyle.TextBoxBackColor = ColorTranslatorFromHtml(_xml, "Theme");
            //MyStyle.TextBoxBackColor = ColorTranslatorFromHtml(_xml, "Style");

            ColorTranslatorToHtml("FastColoredTextBoxBackground", TextBoxBackColor);
            ColorTranslatorToHtml("FastColoredTextBoxForeground", TextColor);
            ColorTranslatorToHtml("FastColoredTextBoxIndent", IndentBackColor);
            ColorTranslatorToHtml("FastColoredTextBoxCaret", CaretColor);
            ColorTranslatorToHtml("FastColoredTextBoxBookmark", BookmarkColor);
            ColorTranslatorToHtml("FastColoredTextBoxSelection", SelectionColor);
            ColorTranslatorToHtml("FastColoredTextBoxLineNumber", LineNumColor);
            ColorTranslatorToHtml("FastColoredTextBoxServiceLine", ServiceLineColor);

            _xml.Save(xmlFile);
        }
    }
}
