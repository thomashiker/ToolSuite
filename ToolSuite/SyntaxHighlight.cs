using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using FastColoredTextBoxNS;

namespace ToolSuite
{
    public class KeyWordStyle
    {
        public string KeyWord { get; set; }
        public TextStyle Style { get; set; }

        public KeyWordStyle(Color fore, Color back, FontStyle style, string keyword)
        {
            Style = new TextStyle(new SolidBrush(fore), new SolidBrush(back), style);
            KeyWord = keyword;
        }

        public void Dispose()
        {
            Style.Dispose();
            KeyWord = null;
            Style = null;
        }
    }

    public class KeyWordStyleList
    {
        private List<KeyWordStyle> keyWordList;

        public KeyWordStyleList()
        {
            keyWordList = new List<KeyWordStyle>();
        }

        public void Add(KeyWordStyle style)
        {
            keyWordList.Add(style);
        }

        public void Clear()
        {
            foreach (KeyWordStyle style in keyWordList)
            {
                style.Dispose();
            }
            keyWordList.Clear();
        }

        public void RangeSetStyle(Range range)
        {
            try
            {
                foreach (KeyWordStyle style in keyWordList)
                {
                    //clear previous highlighting
                    range.ClearStyle(style.Style);
                    //highlight tags
                    range.SetStyle(style.Style, style.KeyWord);
                }
            }
            catch
            {

            }
        }
    }
}
