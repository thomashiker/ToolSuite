using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Design;
using System.Runtime.InteropServices;
using System.Security;
using System.Security.Permissions;
using System.Windows.Forms;
using System.Text;
using WeifenLuo.WinFormsUI.Docking;
using System.Xml;
using System.IO;

namespace ToolSuite
{
    public partial class DummyPropertyWindow : ToolWindow
    {
        private string _cmdListDefaultFile;
        private string _defaultHistoryFile = null;


        public string CmdListDefaultFile
        {
            get { return _cmdListDefaultFile; }
            set
            {
                _cmdListDefaultFile = value;
                reloadToolStripMenuItem.ToolTipText = _cmdListDefaultFile;
            }
        }

        public string DefaultHistoryFile
        {
            get { return _defaultHistoryFile; }
            set { _defaultHistoryFile = value; }
        }

        public DummyPropertyWindow()
        {
            InitializeComponent();
            DefaultHistoryFile = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "script.xml");
        }

        private void SendData(string data)
        {
            DummyDoc doc = (DummyDoc)this.DockPanel.ActiveDocument;
            if (null != doc)
            {
                doc.SendMessage(data);
            }
        }

        private void UploadFile()
        {
            try
            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Filter = "(*.xml)|*.xml";
                ofd.InitialDirectory = (null == CmdListDefaultFile) ? Application.StartupPath : CmdListDefaultFile;

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    XmlDocument xml = new XmlDocument();

                    xml.Load(@ofd.FileName);

                    XmlNodeList nodeList = xml.DocumentElement.GetElementsByTagName("listitem");
                    foreach (XmlNode element in nodeList)
                    {
                        int index = metroGridTitle.Rows.Add();
                        StringBuilder builder = new StringBuilder();

                        if (null != element.Attributes["title"])
                        {
                            string title = element.Attributes["title"].InnerText;
                            metroGridTitle.Rows[index].Cells[0].Value = title;
                        }
                        foreach (XmlNode node in element.ChildNodes)
                        {
                            if (null != node.Attributes["cmd"])
                            {
                                string detail = node.Attributes["cmd"].InnerText;
                                builder.Append(detail + "\r\n");
                            }
                        }
                        metroGridTitle.Rows[index].Cells[0].Tag = (string)builder.ToString();
                    }
                    CmdListDefaultFile = ofd.FileName;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Reload()
        {
            try
            {
                if (null != CmdListDefaultFile)
                {
                    XmlDocument xml = new XmlDocument();

                    xml.Load(@CmdListDefaultFile);

                    metroGridTitle.Rows.Clear();
                    XmlNodeList nodeList = xml.DocumentElement.GetElementsByTagName("listitem");
                    foreach (XmlNode element in nodeList)
                    {
                        int index = metroGridTitle.Rows.Add();
                        StringBuilder builder = new StringBuilder();

                        if (null != element.Attributes["title"])
                        {
                            string title = element.Attributes["title"].InnerText;
                            metroGridTitle.Rows[index].Cells[0].Value = title;
                        }
                        foreach (XmlNode node in element.ChildNodes)
                        {
                            if (null != node.Attributes["cmd"])
                            {
                                string detail = node.Attributes["cmd"].InnerText;
                                builder.Append(detail + "\r\n");
                            }
                        }
                        metroGridTitle.Rows[index].Cells[0].Tag = (string)builder.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void SaveHistory()
        {
            if (null != DefaultHistoryFile)
            {
                SaveToXml(DefaultHistoryFile);
            }
        }

        private void SaveToXml(string file)
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                XmlDeclaration dec = doc.CreateXmlDeclaration("1.0", "utf-8", null);
                doc.AppendChild(dec);

                XmlElement root = doc.CreateElement("utensils");
                doc.AppendChild(root);
                foreach (DataGridViewRow row in metroGridTitle.Rows)
                {
                    string collection = (string)row.Cells[0].Tag;
                    if (null == collection)
                    {
                        continue;
                    }
                    XmlElement element = doc.CreateElement("listitem");
                    element.SetAttribute("title", (string)row.Cells[0].Value);

                    //string collection = (string)row.Cells[0].Tag;
                    string[] sArray = collection.Split(new string[] { "\r\n", "\r", "\n" }, StringSplitOptions.RemoveEmptyEntries);
                    foreach (string value in sArray)
                    {
                        XmlElement node = doc.CreateElement("detail");
                        node.SetAttribute("cmd", value);
                        element.AppendChild(node);
                    }

                    root.AppendChild(element);
                }

                doc.Save(@file);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "MetroMessagebox");
            }
        }

        private void SaveToFile()
        {
            SaveFileDialog fileDialog = new SaveFileDialog();
            fileDialog.Filter = "(*.xml)|*.xml";
            fileDialog.DefaultExt = "xml";

            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                SaveToXml(fileDialog.FileName);
            }
        }

        private void tsbtAddRow_Click(object sender, System.EventArgs e)
        {
            metroGridTitle.Rows.Add();
        }

        private void tsbtRemoveRow_Click(object sender, System.EventArgs e)
        {
            foreach (DataGridViewRow vr in metroGridTitle.SelectedRows)
            {
                metroGridTitle.Rows.Remove(vr);
            }
        }
       

        private void tsbtEdit_Click(object sender, EventArgs e)
        {
            if(0 == metroGridTitle.SelectedCells.Count)
            {
                tsbtEdit.Checked = false;
                return;
            }
            if (tsbtEdit.Checked)
            {
                Animate.AnimateWindow(metroGridTitle.Handle, 200, Animate.AW_SLIDE + Animate.AW_HOR_NEGATIVE + Animate.AW_HIDE);
                textBoxWithTitle.Title = (string)metroGridTitle.SelectedCells[0].Value;
                textBoxWithTitle.Content = (string)metroGridTitle.SelectedCells[0].Tag;
            }
            else
            {
                Animate.AnimateWindow(metroGridTitle.Handle, 200, Animate.AW_SLIDE + Animate.AW_HOR_POSITIVE);
                metroGridTitle.SelectedCells[0].Value = textBoxWithTitle.Title;
                metroGridTitle.SelectedCells[0].Tag = textBoxWithTitle.Content;
            }
        }

        class Animate
        {
            #region 常量申明
            /// <summary>
            /// 自左向右显示控件.当使用AW_CENTER标志时,该标志将被忽略.
            /// </summary>
            public const Int32 AW_HOR_POSITIVE = 0x00000001;

            /// <summary>
            /// 自右向左显示控件.当使用AW_CENTER标志时,该标志将被忽略.
            /// </summary>
            public const Int32 AW_HOR_NEGATIVE = 0x00000002;

            /// <summary>
            /// 自顶向下显示控件.该标志可以在滚动动画和滑动动画中使用.当使用AW_CENTER标志时,该标志将被忽略.
            /// </summary>
            public const Int32 AW_VER_POSITIVE = 0x00000004;

            /// <summary>
            /// 自下向上显示控件.该标志可以在滚动动画和滑动动画中使用.当使用AW_CENTER标志时,该标志将被忽略.
            /// </summary>
            public const Int32 AW_VER_NEGATIVE = 0x00000008;

            /// <summary>
            /// 若使用AW_HIDE标志,则使控件向内重叠;若未使用AW_HIDE标志,则使控件向外扩展.
            /// </summary>
            public const Int32 AW_CENTER = 0x00000010;

            /// <summary>
            /// 隐藏控件.默认则显示控件.
            /// </summary>
            public const Int32 AW_HIDE = 0x00010000;

            /// <summary>
            /// 激活控件.在使用AW_HIDE标志后不要使用这个标志.
            /// </summary>
            public const Int32 AW_ACTIVATE = 0x00020000;

            /// <summary>
            /// 使用滑动类型.默认则为滚动动画类型.当使用AW_CENTER标志时,这个标志就被忽略.
            /// </summary>
            public const Int32 AW_SLIDE = 0x00040000;

            /// <summary>
            /// 使用淡入效果.只有当hWnd为顶层控件时才可以使用此标志.
            /// </summary>
            public const Int32 AW_BLEND = 0x00080000;
            #endregion

            [DllImportAttribute("user32.dll")]
            public static extern bool AnimateWindow(IntPtr hWnd, int dwTime, int dwFlags);
        }

        private void sendSelectionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewCell cell in metroGridTitle.SelectedCells)
            {
                if (cell.Selected)
                {
                    SendData((string)cell.Tag);
                }
            }
        }

        private void repeatToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void uploadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UploadFile();
        }

        private void reloadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reload();
        }

        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            metroGridTitle.Rows.Clear();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveToFile();
        }

        private void metroGridTitle_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (0 == e.ColumnIndex)
            {
                DataGridViewCell cell = metroGridTitle.Rows[e.RowIndex].Cells[e.ColumnIndex];
                if (null != cell)
                {
                    SendData((string)cell.Tag);
                }
            }
        }

        private void cmSend_Click(object sender, EventArgs e)
        {
            sendSelectionsToolStripMenuItem_Click(sender, e);
        }

        private void cmClear_Click(object sender, EventArgs e)
        {
            clearToolStripMenuItem_Click(sender, e);
        }

        private void DummyPropertyWindow_DockStateChanged(object sender, EventArgs e)
        {
            Color style = this.DockPanel.Theme.ColorPalette.MainWindowStatusBarDefault.Background;
            metroGridTitle.DefaultCellStyle.SelectionBackColor = style;
            textBoxWithTitle.DividerColor = style;
        }
    }
}