using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.IO;
using MetroFramework;
using MetroFramework.Forms;
using MetroFramework.Drawing;
using MetroFramework.Controls;
using WeifenLuo.WinFormsUI.Docking;
using FastColoredTextBoxNS;

namespace ToolSuite
{
    public partial class DummyOutputWindow : ToolWindow
    {
        private DummyDoc DocActived = null;
        private bool _editMode = true;
        private bool ActivedBySelect = false;
        private string _defaultHistoryFile = null;
        private string _defaultHistoryFile2 = null;
        private ToolStripMenuItem textBoxSendItem = new ToolStripMenuItem("Send");
        //Create style for highlighting
        private TextStyle brownStyle = new TextStyle(Brushes.Red, null, FontStyle.Regular);


        public string DefaultHistoryFile
        {
            get { return _defaultHistoryFile; }
            set { _defaultHistoryFile = value; }
        }

        public string DefaultHistoryFile2
        {
            get { return _defaultHistoryFile2; }
            set { _defaultHistoryFile2 = value; }
        }

        public DummyOutputWindow()
        {
            InitializeComponent();
            CustomInitialize();
        }

        public DummyOutputWindow(CustomStyle style)
        {
            InitializeComponent();
            UpdateStyle(style);
            CustomInitialize();
        }

        private void CustomInitialize()
        {
            EditMode = true;
            DefaultHistoryFile = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "out.txt");
            DefaultHistoryFile2 = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "out2.txt");

            textBoxSendItem.Click += outputTextBox_SendEvent;
            outputTextBox.ContextMenuStrip.Items.Add(textBoxSendItem);

            InitOutTextBox();
        }

        private void InitOutTextBox()
        {
            if (File.Exists(DefaultHistoryFile))
            {
                mainFCTB.OpenFile(DefaultHistoryFile, Encoding.ASCII);
            }

            if (File.Exists(DefaultHistoryFile2))
            {
                secondFCTB.OpenFile(DefaultHistoryFile2, Encoding.ASCII);
            }
        }

        public override void UpdateStyle(object style)
        {
            ((CustomStyle)style).Update(mainFCTB);
        }

        private void fctb_TextChanged(object sender, TextChangedEventArgs e)
        {
            //clear previous highlighting
            e.ChangedRange.ClearStyle(brownStyle);
            //highlight tags
            e.ChangedRange.SetStyle(brownStyle, "<[^>]+>");
        }

        public bool EditMode
        {
            get { return _editMode; }
            set
            {
                _editMode = value;
                mainFCTB.ReadOnly = !_editMode;
                secondFCTB.ReadOnly = !_editMode;
                if (_editMode)
                {
                    tsbtEdit.Image = highQualityImageList.ImageItems[3].Image;
                    tsbtEdit.ToolTipText = "edit mode";
                }
                else
                {
                    tsbtEdit.Image = highQualityImageList.ImageItems[4].Image;
                    tsbtEdit.ToolTipText = "read only";
                }
            }
        }

        private void SendData(string data)
        {
            if (null != DocActived)
            {
                DocActived.SendMessage(data);
            }
        }

        private FastColoredTextBox SelectedFCTB
        {
            get
            {
                if (mainFCTB.Focused)
                {
                    return mainFCTB;
                }
                else if (secondFCTB.Focused)
                {
                    return secondFCTB;
                }
                else
                {
                    return null;
                }
            }
        }

        #region mainFCTB
        private void sendCurrentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (null != SelectedFCTB)
            {
                string msg = SelectedFCTB.GetLineText(SelectedFCTB.Selection.Start.iLine);//place.iLine
                SendData(msg);
            }
        }

        private void sendSelectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string msg = SelectedFCTB?.SelectedText;
            if (null != msg && 0 != msg.Length)
            {
                SendData(msg);
            }
        }

        private void sendBookmarksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //StringBuilder builder = new StringBuilder();
            //
            //foreach (Bookmark bm in fctbOutput.Bookmarks)
            //{
            //    string line = fctbOutput.GetLineText(bm.LineIndex);
            //    builder.AppendLine(line);
            //}
            //int line = 0;
            //while (line < fctbOutput.LinesCount)
            //{
            //    fctbOutput.Bookmarks.Remove(line);
            //    fctbOutput.Lines.
            //    line++;
            //}
            //SendData(builder.ToString());
        }

        private void copyToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            SelectedFCTB?.Copy();
        }

        private void pasteToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            SelectedFCTB?.Paste();
        }

        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SelectedFCTB?.Clear();
        }

        private void LoadFile()
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "(*.txt)|*.txt";
            ofd.InitialDirectory = Application.StartupPath;

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                SelectedFCTB?.OpenFile(ofd.FileName, Encoding.ASCII);
            }
        }

        public void SaveHistory()
        {
            try
            {
                if (null != DefaultHistoryFile)
                {
                    mainFCTB.SaveToFile(DefaultHistoryFile, Encoding.ASCII);
                    secondFCTB.SaveToFile(DefaultHistoryFile2, Encoding.ASCII);
                }
            }
            catch
            {
                MessageBox.Show("save failed");
            }
        }
        private void SaveToFile()
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "(*.txt)|*.txt";
            sfd.DefaultExt = "txt";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                SelectedFCTB?.SaveToFile(sfd.FileName, Encoding.ASCII);
            }
        }
        #endregion

        public void DocActivedChangedNotify(DummyDoc doc)
        {
            if (tsbtSendWinLock.Checked && !ActivedBySelect)
            {
                return;
            }

            ActivedBySelect = false;
            DocActived = doc;
            if (null != DocActived)
            {
                ddtbSelect.Text = DocActived.Text;
                ddtbSelect.Image = doc.PortOpened ? highQualityImageList.ImageItems[1].Image : highQualityImageList.ImageItems[0].Image;
            }
            else
            {
                ddtbSelect.Text = "No Select";
                ddtbSelect.Image = highQualityImageList.ImageItems[2].Image;
            }
        }

        public void DocAddedNotify(DummyDoc doc)
        {
            if (null != doc)
            {
                //fctbOutput.AppendText(doc.Text + " added\n");
                ToolStripItem item = ddtbSelect.DropDownItems.Add(doc.Text);
                //item.Image = doc.PortOpened ? imageList.Images[1] : imageList.Images[0];
                item.Tag = doc;
            }
        }

        public void DocRemovedNotify(DummyDoc doc)
        {
            if (null != doc)
            {
                foreach (ToolStripItem item in ddtbSelect.DropDownItems)
                {
                    if (item.Tag == doc)
                    {
                        if (DocActived == doc)
                        {
                            tsbtSendWinLock.Checked = false;
                        }
                        
                        ddtbSelect.DropDownItems.Remove(item);
                        //fctbOutput.AppendText(item.Text + " removed\n");
                        break;
                    }
                }
            }
        }

        private void ddtbSelect_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            DummyDoc doc = (DummyDoc)e.ClickedItem.Tag;
            if (null != doc)
            {
                ActivedBySelect = true;
                doc.Activate();
            }
        }

        private void outputTextBox_SendEvent(object sender, EventArgs e)
        {
            SendData(outputTextBox.Text);
        }

        private void sbtSend_ButtonClick(object sender, EventArgs e)
        {
            outputTextBox_SendEvent(sender, e);
            //SendData(outputTextBox.Text);
        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadFile();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveToFile();
        }

        private void fctbOutput_KeyDown(object sender, KeyEventArgs e)
        {
            FastColoredTextBox fctb = sender as FastColoredTextBox;
            if (!EditMode)
            {
                if (e.KeyCode == Keys.Enter)//enter
                {
                    string msg = fctb.GetLineText(fctb.Selection.Start.iLine);//place.iLine
                    SendData(msg);
                    fctb.Navigate(fctb.Selection.Start.iLine + 1);//NavigateBackward();
                    fctb.SelectionStart += fctb.GetLineLength(fctb.Selection.Start.iLine);

                    e.Handled = true;
                }
            }
        }

        private void fctbOutput_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            string text;
            FastColoredTextBox fctb = sender as FastColoredTextBox;

            if (e.X < fctb.LeftIndent)
            {
                var place = fctb.PointToPlace(e.Location);
                if (fctb.Bookmarks.Contains(place.iLine))
                {
                    fctb.Bookmarks.Remove(place.iLine);
                }
                else
                {
                    fctb.Bookmarks.Add(place.iLine);

                    text = fctb.GetLineText(place.iLine);
                    //selectCmdListBox.Items.Add(text);
                }
            }
        }

        public void RemoveAllBookmarks()
        {
            int line = 0;
            while (line < mainFCTB.LinesCount)
            {
                mainFCTB.Bookmarks.Remove(line);
                line++;
            }
        }

        private void outputTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (Keys.Enter == e.KeyCode)
            {
                SendData(outputTextBox.Text);
                e.Handled = true;
            }
        }

        private void tsbtEdit_Click(object sender, EventArgs e)
        {
            EditMode = !EditMode;
        }

        private void ddtbSelect_TextChanged(object sender, EventArgs e)
        {
            outputTextBox.OnResize();
        }

        private void fctbOutput_Scroll(object sender, ScrollEventArgs e)
        {
            //metroHScrollBar.Value = fctbOutput.LinesCount;
        }

        private void HScrollBar_ValueChanged(object sender, int newValue)
        {
            //ScrollEventArgs e = new ScrollEventArgs(ScrollEventType.EndScroll, metroHScrollBar.Value, ScrollOrientation.VerticalScroll);
            //e.ScrollOrientation = ScrollOrientation.VerticalScroll;
            //e.NewValue = HScrollBar.Value;
            //fctbOutput.OnScroll(e, true);
        }
    }
}