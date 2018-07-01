using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

using MetroFramework;
using MetroFramework.Forms;
using FastColoredTextBoxNS;



namespace ToolSuite
{
    public partial class ReceiveSetting : MetroCForm
    {
        private DummyDoc Parent;
        private PaletteDialog ColorSelector = new PaletteDialog();


        public ReceiveSetting(DummyDoc parent)
        {
            InitializeComponent();

            Parent = parent;
        }

        private void ReceiveSettingForm_Load(object sender, EventArgs e)
        {
            SyntaxHighlight_Load();
        }

        public string CmdListDefaultFile { get; set; }

        private void SyntaxHighlight_Load()
        {
            /*HighLightList.Rows.Clear();
            for (int i = 0; i < SyntaxHighlight.Count; i++)
            {
                HighLightList.Rows.Add();
                HighLightList.Rows[i].Cells[0].Value = SyntaxHighlight[i];
            }*/
        }

        private void SyntaxHighlight_Set()
        {
            try
            {
                Parent.TextKeyWordStyles.Clear();
                foreach (DataGridViewRow row in HighLightList.Rows)
                {
                    string keyword = (string)row.Cells[1].Value;
                    if (keyword != null && keyword != "" && true == (bool)row.Cells[0].Value)
                    {
                        KeyWordStyle style = new KeyWordStyle(row.Cells[2].Style.ForeColor,
                                                          row.Cells[2].Style.BackColor,
                                                          row.Cells[2].Style.Font.Style,
                                                          (string)row.Cells[1].Value);

                        Parent.TextKeyWordStyles.Add(style);
                    }
                    
                }
            }
            catch
            {

            }
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            Hide();
            Parent.Activate();
            Parent.Focus();
        }

        private void btOK_Click(object sender, EventArgs e)
        {
            SyntaxHighlight_Set();

            Hide();
            Parent.Activate();
            Parent.Focus();
        }

        private void btAdd_Click(object sender, EventArgs e)
        {
            if (syntaxTextBox.Text != "")
            {
                HighLightList.SuspendLayout();

                DataGridViewRow dataGridViewRow = new DataGridViewRow();
                dataGridViewRow.CreateCells(HighLightList);
                dataGridViewRow.Cells[0].Value = true;

                dataGridViewRow.Cells[1].Value = syntaxTextBox.Text;
                //dataGridViewRow.Cells[1].Style.BackColor = syntaxSample.BackColor;
                //dataGridViewRow.Cells[1].Style.ForeColor = syntaxSample.ForeColor;
                //dataGridViewRow.Cells[1].Style.Font = new Font(syntaxSample.Font.FontFamily, syntaxSample.Font.Size, syntaxSample.Font.Style);

                dataGridViewRow.Cells[2].Value = "sample";
                dataGridViewRow.Cells[2].Style.BackColor = syntaxSample.BackColor;
                dataGridViewRow.Cells[2].Style.ForeColor = syntaxSample.ForeColor;
                dataGridViewRow.Cells[2].Style.Font = syntaxSample.Font;

                HighLightList.Rows.Add(dataGridViewRow);

                dataGridViewRow.Selected = true;

                HighLightList.ResumeLayout();
            }
            
        }

        private void btDel_Click(object sender, EventArgs e)
        {
            List<DataGridViewRow> toBeDeleted = new List<DataGridViewRow>();

            foreach (DataGridViewRow row in HighLightList.SelectedRows)
            {
                toBeDeleted.Add(row);
            }

            foreach (DataGridViewRow row in toBeDeleted)
            {
                HighLightList.Rows.Remove(row);
            }
        }

        private void btModify_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in HighLightList.SelectedRows)
            {
                HighLightList.SuspendLayout();

                if (syntaxTextBox.Text != "")
                {
                    row.Cells[1].Value = syntaxTextBox.Text;
                    row.Cells[2].Style.BackColor = syntaxSample.BackColor;
                    row.Cells[2].Style.ForeColor = syntaxSample.ForeColor;
                    row.Cells[2].Style.Font = syntaxSample.Font;
                }
                else
                {
                    //
                }

                HighLightList.ResumeLayout();

                return;
            }
        }


        /*private void SaveToXml(string file)
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                XmlDeclaration dec = doc.CreateXmlDeclaration("1.0", "utf-8", null);
                doc.AppendChild(dec);

                XmlElement root = doc.CreateElement("cmdlist");
                doc.AppendChild(root);
                foreach (DataGridViewRow row in metroGrid.Rows)
                {
                    XmlElement element = doc.CreateElement("CMD");
                    element.SetAttribute("cmd", (string)row.Cells["ColumnCmd"].Value);
                    element.SetAttribute("discription", (string)row.Cells["ColumnDiscription"].Value);
                    root.AppendChild(element);
                }

                doc.Save(@file);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "MetroMessagebox");
            }
        }*/

        public void AddRow(string syntax, Color fore, Color back, FontStyle style)
        {
            if (syntax != "")
            {
                HighLightList.SuspendLayout();

                DataGridViewRow dataGridViewRow = new DataGridViewRow();
                dataGridViewRow.CreateCells(HighLightList);
                dataGridViewRow.Cells[0].Value = true;
                dataGridViewRow.Cells[1].Value = syntax;
                dataGridViewRow.Cells[2].Value = "sample";
                dataGridViewRow.Cells[2].Style.BackColor = back;
                dataGridViewRow.Cells[2].Style.ForeColor = fore;
                dataGridViewRow.Cells[2].Style.Font = new Font("SimSun", 10f, style);

                HighLightList.Rows.Add(dataGridViewRow);

                dataGridViewRow.Selected = true;

                HighLightList.ResumeLayout();
            }
        }

        private void UploadFile()
        {
            string syntax="";
            Color fore = Color.Empty;
            Color back = Color.Empty;
            FontStyle style = FontStyle.Regular;

            try
            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Filter = "(*.xml)|*.xml";
                ofd.InitialDirectory = (null == CmdListDefaultFile) ? Application.StartupPath : CmdListDefaultFile;

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    XmlDocument xml = new XmlDocument();

                    xml.Load(@ofd.FileName);

                    XmlNodeList nodeList = xml.DocumentElement.GetElementsByTagName("HighLight");
                    foreach (XmlNode node in nodeList) //当然也能用nodeList的值
                    {
                        XmlNodeList list = ((XmlElement)node).GetElementsByTagName("Syntax");
                        if (list.Count > 0)
                        {
                            syntax = list.Item(0).Attributes["Value"].Value;
                        }

                        list = ((XmlElement)node).GetElementsByTagName("ForeColor");
                        if (list.Count > 0)
                        {
                            var color = list.Item(0).Attributes["Color"].Value;
                            fore = ColorTranslator.FromHtml($"#{color}");
                        }

                        list = ((XmlElement)node).GetElementsByTagName("BackColor");
                        if (list.Count > 0)
                        {
                            var color = list.Item(0).Attributes["Color"].Value;
                            back = ColorTranslator.FromHtml($"#{color}");
                        }

                        list = ((XmlElement)node).GetElementsByTagName("FontStyle");
                        if (list.Count > 0)
                        {
                            if ("true" == list.Item(0).Attributes["Bold"].InnerText)
                            {
                                style |= FontStyle.Bold;
                            }
                            if ("true" == list.Item(0).Attributes["Italic"].InnerText)
                            {
                                style |= FontStyle.Italic;
                            }
                            if ("true" == list.Item(0).Attributes["Underline"].InnerText)
                            {
                                style |= FontStyle.Underline;
                            }
                            if ("true" == list.Item(0).Attributes["Strikeout"].InnerText)
                            {
                                style |= FontStyle.Strikeout;
                            }
                        }

                        AddRow(syntax, fore, back, style);
                    }
                    CmdListDefaultFile = ofd.FileName;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void btUpload_Click(object sender, EventArgs e)
        {
            UploadFile();
        }

        private void HighLightList_SelectionChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in HighLightList.SelectedRows)
            {
                //DataGridViewCell tb = row.Cells[1];
                syntaxTextBox.Text = (string)row.Cells[1].Value;
                syntaxSample.BackColor = row.Cells[2].Style.BackColor;
                syntaxSample.ForeColor = row.Cells[2].Style.ForeColor;

                cbBold.Checked      = row.Cells[2].Style.Font.Bold;
                cbItalic.Checked    = row.Cells[2].Style.Font.Italic;
                cbStrikeout.Checked = row.Cells[2].Style.Font.Strikeout;
                cbUnderline.Checked = row.Cells[2].Style.Font.Underline;

                return;
            }
        }

        private void btColor_Click(object sender, EventArgs e)
        {
            ControlsLibrary.MetroMenuButton bt = (ControlsLibrary.MetroMenuButton)sender;
            if (ColorSelector.ShowDialog() == DialogResult.OK)
            {
                bt.NormalBackColor = ColorSelector.SelectedColor;
            }
            syntaxSample.BackColor = btBackColor.NormalBackColor;
            syntaxSample.ForeColor = btFontColor.NormalBackColor;

            this.Focus();
        }

        private void FontStyle_CheckedChanged(object sender, EventArgs e)
        {
            FontStyle style = FontStyle.Regular;

            style |= cbBold.Checked ? FontStyle.Bold : 0;
            style |= cbItalic.Checked ? FontStyle.Italic : 0;
            style |= cbStrikeout.Checked ? FontStyle.Strikeout : 0;
            style |= cbUnderline.Checked ? FontStyle.Underline : 0;
            syntaxSample.Font = new Font(syntaxSample.Font.FontFamily, syntaxSample.Font.Size, style);
        }
    }
}
