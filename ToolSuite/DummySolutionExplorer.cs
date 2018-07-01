using System;
using System.Drawing;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;
using System.Xml;
using System.IO;

namespace ToolSuite
{
    public partial class DummySolutionExplorer : ToolWindow
    {
        private string _cmdListDefaultFile;
        private string _defaultHistoryFile = null;
        private CustomStyle defaultCustomStyle = new CustomStyle();


        public DummySolutionExplorer()
        {
            InitializeComponent();
            DefaultHistoryFile = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "solution.xml");

            GridInit();
            tsbtEdit.Image = highQualityImageList.ImageItems[1].Image;
        }

        public DummySolutionExplorer(CustomStyle style)
        {
            InitializeComponent();
            DefaultHistoryFile = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "solution.xml");

            GridInit();
            tsbtEdit.Image = highQualityImageList.ImageItems[1].Image;

            metroGrid.DefaultCellStyle.SelectionBackColor = style.GridSelectionColor;
        }

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

        public override void UpdateStyle(object style)
        {
            metroGrid.DefaultCellStyle.SelectionBackColor = this.DockPanel.Theme.ColorPalette.MainWindowStatusBarDefault.Background;
        }

        private void tsbtAddRow_Click(object sender, EventArgs e)
        {
            metroGrid.Rows.Add();
        }

        private void tsbtRemoveRow_Click(object sender, EventArgs e)
        {
            //metroGrid.Rows.Remove(metroGrid.SelectedRows[0]);
            foreach (DataGridViewRow vr in metroGrid.SelectedRows)
            {
                metroGrid.Rows.Remove(vr);
            }
        }

        private void tsbtEdit_Click(object sender, EventArgs e)
        {
            metroGrid.Columns[1].ReadOnly = !metroGrid.Columns[1].ReadOnly;
            metroGrid.Columns[2].ReadOnly = !metroGrid.Columns[2].ReadOnly;

            if (metroGrid.Columns[1].ReadOnly)
            {
                tsbtEdit.Image = highQualityImageList.ImageItems[1].Image;// readOnlyToolStripMenuItem.Image;
            }
            else
            {
                tsbtEdit.Image = highQualityImageList.ImageItems[0].Image;// editToolStripMenuItem.Image;
            }
        }

        private void GridInit()
        {
            metroGrid.Columns[1].Visible = true;
            metroGrid.Columns[2].Visible = false;

            metroGrid.Columns[1].ReadOnly = true;
            metroGrid.Columns[2].ReadOnly = true;
        }

        private void ShowModeUpdate()
        {
            metroGrid.Columns[1].Visible = !tsbtView.Checked;// !metroGrid.Columns[1].Visible;
            metroGrid.Columns[2].Visible = tsbtView.Checked;// !metroGrid.Columns[1].Visible;
        }
        private void tsbtView_Click(object sender, EventArgs e)
        {
            ShowModeUpdate();
        }

        private void SendData(string data)
        {
            DummyDoc doc = (DummyDoc)this.DockPanel.ActiveDocument;
            if (null != doc)
            {
                doc.SendMessage(data);
            }
        }

        public void AddCmd(string cmd, string disc)
        {
            if (null == cmd || 0 == cmd.Length)
                return;

            foreach (DataGridViewRow row in metroGrid.Rows)
            {
                if (cmd.Equals(row.Cells[1].Value))
                {
                    return;
                }
            }

            int index = metroGrid.Rows.Add();
            metroGrid.Rows[index].Cells["ColumnCmd"].Value = cmd;
            metroGrid.Rows[index].Cells["ColumnDiscription"].Value = disc;
            //    string[] array = new string[] { "null", item };
            //gridCmdList.Rows.Insert(0, array);
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

                    XmlNodeList nodeList = xml.DocumentElement.GetElementsByTagName("CMD");
                    foreach (XmlNode node in nodeList) //当然也能用nodeList的值
                    {
                        if (null != node.Attributes["cmd"])
                        {
                            if (null != node.Attributes["discription"])
                            {
                                AddCmd(node.Attributes["cmd"].InnerText, node.Attributes["discription"].InnerText);
                            }
                            else
                            {
                                AddCmd(node.Attributes["cmd"].InnerText, null);
                            }
                        }
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

                    metroGrid.Rows.Clear();
                    XmlNodeList nodeList = xml.DocumentElement.GetElementsByTagName("CMD");
                    foreach (XmlNode node in nodeList) //当然也能用nodeList的值
                    {
                        if (null != node.Attributes["cmd"])
                        {
                            if (null != node.Attributes["discription"])
                            {
                                AddCmd(node.Attributes["cmd"].InnerText, node.Attributes["discription"].InnerText);
                            }
                            else
                            {
                                AddCmd(node.Attributes["cmd"].InnerText, null);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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

        private void tsbtUpload_Click(object sender, EventArgs e)
        {
            UploadFile();
        }

        private void metroGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex > 0)
            {
                //metroGrid.Rows[cell.RowIndex].Cells["ColumnCmd"].Value;
                //MessageBox.Show(metroGrid.Rows[e.RowIndex].Cells["ColumnCmd"].Value.ToString());
                if (null != metroGrid.Rows[e.RowIndex].Cells["ColumnCmd"].Value)
                {
                    SendData(metroGrid.Rows[e.RowIndex].Cells["ColumnCmd"].Value.ToString());
                }
            }
        }

        private void uploadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UploadFile();
        }

        private void repeatToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void sendSelectionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /*foreach (DataGridViewRow row in metroGrid.SelectedRows)
            {
                SendData(row.Cells["ColumnCmd"].Value.ToString());
            }*/
            foreach (DataGridViewRow row in metroGrid.Rows)
            {
                if (row.Selected)
                {
                    SendData(row.Cells["ColumnCmd"].Value.ToString());
                }
            }
        }

        private void sendCheckedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in metroGrid.Rows)
            {
                DataGridViewCheckBoxCell cc = (DataGridViewCheckBoxCell)row.Cells[0];
                if ((bool)cc.EditingCellFormattedValue && (bool)cc.FormattedValue)
                {
                    SendData(row.Cells["ColumnCmd"].Value.ToString());
                }
            }
        }

        private void checkAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in metroGrid.Rows)
            {
                /*DataGridViewCheckBoxCell checkCell = (DataGridViewCheckBoxCell)row.Cells[0];
                if ((bool)checkCell.EditedFormattedValue)
                {
                    SendMsg((string)row.Cells[1].Value);
                    Thread.Sleep(1);
                }*/
                row.Cells[0].Value = true;
            }
        }

        private void uncheckToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in metroGrid.Rows)
            {
                row.Cells[0].Value = false;
            }
        }

        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            metroGrid.Rows.Clear();
        }

        private void reloadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reload();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveToFile();
        }

        private void sendAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in metroGrid.Rows)
            {
                SendData(row.Cells["ColumnCmd"].Value.ToString());
            }
        }

        private void DummySolutionExplorer_DockStateChanged(object sender, EventArgs e)
        {
            metroGrid.DefaultCellStyle.SelectionBackColor = this.DockPanel.Theme.ColorPalette.MainWindowStatusBarDefault.Background;
        }
    }
}