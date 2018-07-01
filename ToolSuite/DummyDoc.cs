using System;
using System.Windows.Forms;
using System.IO;
using System.IO.Ports;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.ComponentModel;
using System.Diagnostics;
using System.Collections.Generic;

//using MetroSet_UI.Forms;
using MetroFramework;
using MetroFramework.Forms;
using MetroFramework.Drawing;

using WeifenLuo.WinFormsUI.Docking;
using FastColoredTextBoxNS;

namespace ToolSuite
{
    public partial class DummyDoc : DockContent
    {
        private string SavedLogPath;
        private string logPath = "log";
        private string logFileName = null;
        private Int64 rcvCharNum = 0;
        private Int64 sendCharNum = 0;
        private bool recordState = true;
        private bool fctbRcvAutoScroll = true;
        private bool Showable = false;

        private ReceiveSetting rcvSetting;

        public KeyWordStyleList TextKeyWordStyles { get; set; } = new KeyWordStyleList();

        public bool KeyWordHighLight { get; set; } = true;


        public DummyDoc(SerialPort p, CustomStyle style)
        {
            InitializeComponent();
            AutoScaleMode = AutoScaleMode.Dpi;

            rcvSetting = new ReceiveSetting(this);

            if (null != p)
            {
                Text = p.PortName;

                serialPort.PortName = p.PortName;
                serialPort.BaudRate = p.BaudRate;
                serialPort.DataBits = p.DataBits;
                serialPort.StopBits = p.StopBits;
                serialPort.Parity = p.Parity;
            }
            else
            {
                FCTB.AppendText("create fail");
            }

            UpdateStyle(style);
        }

        public override void UpdateStyle(object style)
        {
            ((CustomStyle)style).Update(FCTB);
        }

        private void DummyDoc_Load(object sender, EventArgs e)
        {
            OpenPort();
        }

        public void AddxHighlightStyle(string syntax, Color fore, Color back, FontStyle fontstyle)
        {
            rcvSetting.AddRow(syntax, fore, back, fontstyle);

            if (syntax != null && syntax != "")
            {
                KeyWordStyle style = new KeyWordStyle(fore, back, fontstyle, syntax);

                TextKeyWordStyles.Add(style);
            }
        }

        private void SyntaxHighlightSet()
        {

        }

        private void fctb_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (KeyWordHighLight)
            {
                //clear previous highlighting
                //e.ChangedRange.ClearStyle(RedStyle);
                //highlight tags
                //e.ChangedRange.SetStyle(RedStyle, "<[^>]+>");

                //HighLightList.RangeSetStyle(e.ChangedRange);
                TextKeyWordStyles.RangeSetStyle(e.ChangedRange);

                //keyword highlighting
                //e.ChangedRange.SetStyle(BlueStyle, @"\b(abstract|as|base|bool|break|byte|case|catch|char|where|yield)\b|#region\b|#endregion\b");
            }

        }

        public string LogPath
        {
            get { return SavedLogPath; }
            set { SavedLogPath = value; }
        }

        public string LogFile
        {
            get { return logFileName; }
            set { logFileName = value; }
        }

        public bool LogRecord
        {
            get { return recordState; }
            set { recordState = value; }
        }

        public bool AutoScroll
        {
            get { return fctbRcvAutoScroll; }
            set { fctbRcvAutoScroll = value; }
        }

        public bool PortOpened
        {
            get { return serialPort.IsOpen; }
        }

        public bool ShowLineNumbers
        {
            get { return FCTB.ShowLineNumbers; }
            set
            {
                FCTB.ShowLineNumbers = value;
                showLineToolStripMenuItem.Checked = value;
            }
        }

        public string PortInfo
        {
            get { return (
                    serialPort.PortName + ","
                    + serialPort.BaudRate.ToString() + ","
                    + serialPort.DataBits.ToString() + ","
                     + serialPort.StopBits.ToString() + ","
                    + serialPort.Parity.ToString()
                    );
                }
        }

        private void RefreshIcon()
        {
            this.CloseButtonVisible = false;
            this.CloseButtonVisible = true;
        }

        /// <summary>
        /// ת��ImageΪIcon
        /// </summary>
        /// <param name="image">Ҫת��Ϊͼ���Image����</param>
        /// <param name="nullTonull">��imageΪnullʱ�Ƿ񷵻�null��false���׿������쳣</param>
        /// <exception cref="ArgumentNullException" />
        public static Icon ConvertToIcon(Image image, bool nullTonull = false)
        {
            if (image == null)
            {
                if (nullTonull) { return null; }
                throw new ArgumentNullException("image");
            }

            using (MemoryStream msImg = new MemoryStream()
                              , msIco = new MemoryStream())
            {
                image.Save(msImg, ImageFormat.Png);

                using (var bin = new BinaryWriter(msIco))
                {
                    //дͼ��ͷ��
                    bin.Write((short)0);           //0-1����
                    bin.Write((short)1);           //2-3�ļ����͡�1=ͼ��, 2=���
                    bin.Write((short)1);           //4-5ͼ��������ͼ����԰������ͼ��

                    bin.Write((byte)image.Width);  //6ͼ����
                    bin.Write((byte)image.Height); //7ͼ��߶�
                    bin.Write((byte)0);            //8��ɫ����������λ��>=8����0��������Ȼ�ģ��ﵽ8bpp����ɫ��������256��byte������ʾ��
                    bin.Write((byte)0);            //9����������Ϊ0
                    bin.Write((short)0);           //10-11��ɫ��
                    bin.Write((short)32);          //12-13λ��
                    bin.Write((int)msImg.Length);  //14-17λͼ���ݴ�С
                    bin.Write(22);                 //18-21λͼ������ʼ�ֽ�

                    //дͼ������
                    bin.Write(msImg.ToArray());

                    bin.Flush();
                    bin.Seek(0, SeekOrigin.Begin);
                    return new Icon(msIco);
                }
            }
        }
       
        private void PortStateUpdate()
        {
            if (PortOpened)
            {
                Icon = IconConnect.Icon;// ConvertToIcon(highQualityImageList.ImageItems[0].Image, false);
                //fctbRcv.AppendText(serialPort.PortName + " " + serialPort.BaudRate.ToString() + " Opened\n");
                connectToolStripMenuItem.Text = "Disconnect";
            }
            else
            {
                Icon = IconDisconnect.Icon;//ConvertToIcon(highQualityImageList.ImageItems[1].Image, false);
                //fctbRcv.AppendText(serialPort.PortName + " " + serialPort.BaudRate.ToString() + " Open Failed\n");
                connectToolStripMenuItem.Text = "Connect";
            }

            RefreshIcon();
            this.UpdateStyles();
        }

        public bool OpenPort()
        {
            if (null == serialPort)
                return false;

            if (!PortOpened)
            {
                //MessageBox.Show(serialPort.PortName + " is openning!");
                try
                {
                    serialPort.Open();
                }
                catch
                {
                    //serialPort.Dispose();
                    //serialPort = new SerialPort();
                }
            }

            NewLogFile();

            PortStateUpdate();

            return true;
        }

        public bool ClosePort()
        {
            if (null == serialPort)
                return false;

            if (PortOpened)
            {
                try
                {
                    serialPort.Close();
                }
                catch
                {
                    serialPort.Dispose();
                    serialPort = new SerialPort();
                }
            }

            PortStateUpdate();

            return true;
        }

        private void AppendRcvText(string msg)
        {
            LogToFile(msg);
        
            BeginInvoke(new Action(() =>
            {
                FCTB.BeginUpdate();
                FCTB.AppendText(msg);
                if (fctbRcvAutoScroll)
                {
                    //fctbRcv.GoEnd();
                    FCTB.GoEndHead();
                }
                FCTB.EndUpdate();
            }));
        }

        private void UpdateRcvCharDisplay(Int64 num)
        {
            //
            MainForm parent = (MainForm)MdiParent;
            if (null != parent && Showable)
            {
                parent.StatusBarShowRcvInfo(num.ToString());
            }
        }

        private void UpdateSendCharDisplay(Int64 num)
        {
            //
            MainForm parent = (MainForm)MdiParent;
            if (null != parent && Showable)
            {
                parent.StatusBarShowSendInfo(num.ToString());
            }
        }

        public string NewLogFile()
        {
            if (!Directory.Exists(logPath))
            {
                Directory.CreateDirectory(logPath);
            }

            LogFile = logPath + "\\" + "[" + serialPort.PortName + "]" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".txt";
            if (!File.Exists(this.LogFile))
            {
                FileStream fs = new FileStream(this.LogFile, FileMode.Create, FileAccess.ReadWrite);
                fs.Close();
            }

            return this.LogFile;
        }

        private void LogToFile(string data)
        {
            if (recordState)
            {
                if (this.LogFile == null)
                {
                    NewLogFile();
                }

                try
                {
                    File.AppendAllText(this.LogFile, data);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private bool save2file = false;
        public bool SendMessage(string msg)
        {
            if (msg == null)
            {
                return true;
            }

            if (PortOpened)
            {
                try
                {
                    this.Invoke((EventHandler)(delegate
                    {
                        StringBuilder builder = new StringBuilder(msg);
                        builder.Append("\n");

                        serialPort.Write(builder.ToString());

                        sendCharNum += builder.Length;
                        UpdateSendCharDisplay(sendCharNum);

                        if (save2file)
                        {
                            //SaveSendLogToFile(msg);
                        }
                    }));
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return false;
                }
            }
            else
            {
                return false;
            }

            return true;
        }

        private void serialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
           int n;
           n = serialPort.BytesToRead;//�ȼ�¼����������ĳ��ԭ����Ϊ��ԭ�򣬲�������֮��ʱ�䳤�����治һ��  
           byte[] buf = new byte[n];//����һ����ʱ����洢��ǰ���Ĵ�������
           string rcvdata;
           rcvCharNum += n;//���ӽ��ռ���  
           serialPort.Read(buf, 0, n); ;//��ȡ��������
           
           //��ΪҪ����ui��Դ��������Ҫʹ��invoke��ʽͬ��ui�� 
           rcvdata = Encoding.Default.GetString(buf);
           AppendRcvText(rcvdata);
           UpdateRcvCharDisplay(rcvCharNum);
           
           Thread.Sleep(50);
           Application.DoEvents();
        }


        public string MsgToSend = "";

        private void ReceiveUserInput(string input)
        {
            MsgToSend = MsgToSend + input;
        }

        private void MinusUserInputChar()
        {
            string userInputMsg = MsgToSend;

            if (null != userInputMsg)
            {
                if (userInputMsg.Length > 1)
                {
                    userInputMsg = userInputMsg.Remove(userInputMsg.Length - 1);
                }
                else
                {
                    userInputMsg = null;
                }
            }

            MsgToSend = userInputMsg;
        }

        private void fctbRcv_KeyDown(object sender, KeyEventArgs e)
        {
            if (Keys.Enter == e.KeyCode)
            {
                SendMessage("");
                e.Handled = true;
            }
        }

        public void SaveToFile()
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "(*.txt)|*.txt";
            sfd.DefaultExt = "txt";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                FCTB.SaveToFile(sfd.FileName, Encoding.ASCII);
            }
        }

        public void Clear()
        {
            FCTB.Clear();
        }

        public void ClearBookmarks()
        {
            //int line = 0;
            //while (line < fctbOutput.LinesCount)
            //{
            //    fctbOutput.Bookmarks.Remove(line);
            //    fctbOutput.Lines.
            //    line++;
            //}
            FCTB.Bookmarks.Clear();
            FCTB.Refresh();
        }

        private void connectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (PortOpened)
            {
                ClosePort();
            }
            else
            {
                OpenPort();
            }
        }

        private void showLineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //ShowLineNumbers = !ShowLineNumbers;
            FCTB.ShowLineNumbers = showLineToolStripMenuItem.Checked;
        }

        private void ClearReceive()
        {
            FCTB.Clear();
            rcvCharNum = 0;
        }

        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClearReceive();
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FCTB.Copy();
        }

        private void settingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rcvSetting.Show(this);
        }

        private void copyAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clipboard.SetDataObject(FCTB.Text, true);
        }

        private void DummyDoc_FormClosed(object sender, FormClosedEventArgs e)
        {
            ClosePort();
            try
            {
                serialPort.DiscardOutBuffer();
                serialPort.DiscardInBuffer();
                serialPort.Dispose();
            }
            catch
            {
                //
            }
        }

        #region Events

        //����delegate
        public delegate void PortStateChangedEventHandler(object sender, System.EventArgs e);

        /// <summary>
        /// DialogBox Event
        /// </summary>
        [Category("Customize"), Description("Serial Port Send Event.")]
        public event PortStateChangedEventHandler _portStateChangedEventHandler;

        //�¼���������
        protected virtual void OnPortStateChangedEvent(EventArgs e)
        {
            if (_portStateChangedEventHandler != null)
                _portStateChangedEventHandler(this, e);
        }
        #endregion

        public void RemoveAllBookmarks()
        {
            int line = 0;
            while (line < FCTB.LinesCount)
            {
                FCTB.Bookmarks.Remove(line);
                line++;
            }
        }

        private void fctbRcv_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.X < FCTB.LeftIndent)
            {
                var place = FCTB.PointToPlace(e.Location);
                if (FCTB.Bookmarks.Contains(place.iLine))
                    FCTB.Bookmarks.Remove(place.iLine);
                else
                    FCTB.Bookmarks.Add(place.iLine);
            }
        }

        private void clearBookMarksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RemoveAllBookmarks();
        }

        private void DummyDoc_Activated(object sender, EventArgs e)
        {
            Showable = true;
            UpdateRcvCharDisplay(rcvCharNum);
            UpdateSendCharDisplay(sendCharNum);
        }

        private void DummyDoc_Deactivate(object sender, EventArgs e)
        {
            Showable = false;
        }
    }
}