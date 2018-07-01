using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.IO.Ports;
using System.Xml;

using MetroFramework;
using MetroFramework.Forms;
using MetroFramework.Controls;
using System.Management;
using WeifenLuo.WinFormsUI.Docking;
using ControlsLibrary;

namespace ToolSuite
{
    public partial class NewForm : MetroCForm
    {
        #region PortSetting
        public SerialPort PortSetting = new SerialPort();
        private string[] portsLast = null;
        private ToolStripSpringTextBox tbBaudRate;

        public NewForm()
        {
            InitializeComponent();

            LoadSerialPortProperty();

            BaudRateCustominit();

            UploadHighLightFile();

            //MetroColors.Custom = Color.Red;

            //metroStyleManager.Style = MetroColorStyle.Custom;
        }

        private void NewForm_Load(object sender, EventArgs e)
        {
            //LoadSerialPortProperty(); 
        }

        public ThemeBase MetroTheme
        {
            set
            {
                SetTheme(value);
            }
        }

        public void SetTheme(ThemeBase theme)
        {
            Color styleColor = theme.ColorPalette.MainWindowStatusBarDefault.Background;
            BorderColor = styleColor;
            toolSettingTabControl.TabSelectedColor = styleColor;

            Color backColor = theme.ColorPalette.CommandBarToolbarDefault.Background;
            HeaderColor = backColor;
            toolSettingTabControl.BackColor = backColor;
            //portListBox.BackColor = backColor;

            foreach (MetroTabPage page in toolSettingTabControl.TabPages)
            {
                page.BackColor = backColor;
            }
        }

        readonly int [] BaudRateArray = {
            2400  ,
            4800  ,
            9600  ,
            14400 ,
            19200 ,
            38400 ,
            56000 ,
            57600 ,
            128000,
            115200,
            256000,
        };

        readonly int[] DataBitsArray = {
            5,
            6,
            7,
            8,
        };

        readonly string[] StopBitsArray =
        {
            "0",
            "1",
            "1.5",
            "2"
        };

        readonly Parity[] ParityArray =
        {
            Parity.None,
            Parity.Odd,
            Parity.Even,
            Parity.Mark,
            Parity.Space
        };

        private void LoadSerialPortProperty()
        {
            RefreshPortInfo();

            for (int i = 0; i < BaudRateArray.Length; i++)
            {
                ToolStripItem item = tsDropDownButtonBaudRate.DropDownItems.Add(BaudRateArray[i].ToString());
                item.Tag = BaudRateArray[i];
                item.Alignment = ToolStripItemAlignment.Left;
            }

            for (int i = 0; i < DataBitsArray.Length; i++)
            {
                ToolStripItem item = tsDropDownButtonDataBits.DropDownItems.Add(DataBitsArray[i].ToString());
                item.Tag = DataBitsArray[i];
                item.Alignment = ToolStripItemAlignment.Left;
            }

            for (int i = 0; i < StopBitsArray.Length; i++)
            {
                ToolStripItem item = tsDropDownButtonStopBits.DropDownItems.Add(StopBitsArray[i].ToString());
                item.Tag = (StopBits)i;
                item.Alignment = ToolStripItemAlignment.Left;
            }

            for (int i = 0; i < ParityArray.Length; i++)
            {
                ToolStripItem item = tsDropDownButtonParity.DropDownItems.Add(ParityArray[i].ToString());
                item.Tag = ParityArray[i];
                item.Alignment = ToolStripItemAlignment.Left;
            }

            /*event*/
            tsDropDownButtonBaudRate.DropDownItemClicked += PortProperty_DropDownItemClicked;
            tsDropDownButtonDataBits.DropDownItemClicked += PortProperty_DropDownItemClicked;
            tsDropDownButtonStopBits.DropDownItemClicked += PortProperty_DropDownItemClicked;
            tsDropDownButtonParity.DropDownItemClicked += PortProperty_DropDownItemClicked;

            /*default value*/
            foreach (ToolStripItem item  in tsDropDownButtonBaudRate.DropDownItems)
            {
                if (item.Text.IndexOf("115200", 0) >= 0)
                {
                    //richTextBox.AppendText(index.ToString());
                    tsDropDownButtonBaudRate.Text = item.Text;
                    tsDropDownButtonBaudRate.Tag = item.Tag;
                }
            }

            foreach (ToolStripItem item in tsDropDownButtonDataBits.DropDownItems)
            {
                if (item.Text.IndexOf("8", 0) >= 0)
                {
                    //richTextBox.AppendText(index.ToString());
                    tsDropDownButtonDataBits.Text = item.Text;
                    tsDropDownButtonDataBits.Tag = item.Tag;
                }
            }

            foreach (ToolStripItem item in tsDropDownButtonStopBits.DropDownItems)
            {
                if (item.Text.Equals("1"))
                {
                    //richTextBox.AppendText(index.ToString());
                    tsDropDownButtonStopBits.Text = item.Text;
                    tsDropDownButtonStopBits.Tag = item.Tag;
                }
            }

            foreach (ToolStripItem item in tsDropDownButtonParity.DropDownItems)
            {
                if (item.Text.IndexOf("None", 0) >= 0)
                {
                    //richTextBox.AppendText(index.ToString());
                    tsDropDownButtonParity.Text = item.Text;
                    tsDropDownButtonParity.Tag = item.Tag;
                }
            }
        }

        private void BaudRateCustominit()
        {
            tbBaudRate = new ToolStripSpringTextBox();
            tbBaudRate.AutoSize = false;
            tbBaudRate.Spring = false;
            tbBaudRate.BorderColor = Color.Gainsboro;
            tbBaudRate.BorderStyle = System.Windows.Forms.BorderStyle.None;
            tbBaudRate.Minimum = 80;
            tbBaudRate.Padding = new System.Windows.Forms.Padding(1, 0, 1, 0);
            tbBaudRate.Size = new System.Drawing.Size(98, 18);
            tbBaudRate.KeyPress += new KeyPressEventHandler(tbBaudRate_KeyPress);

            tbBaudRate.Visible = false;
            toolStripBaudRate.Items.Insert(2, tbBaudRate);
        }

        /// <summary>
        /// 枚举win32 api
        /// </summary>
        public enum HardwareEnum
        {
            // 硬件
            Win32_Processor, // CPU 处理器
            Win32_PhysicalMemory, // 物理内存条
            Win32_Keyboard, // 键盘
            Win32_PointingDevice, // 点输入设备，包括鼠标。
            Win32_FloppyDrive, // 软盘驱动器
            Win32_DiskDrive, // 硬盘驱动器
            Win32_CDROMDrive, // 光盘驱动器
            Win32_BaseBoard, // 主板
            Win32_BIOS, // BIOS 芯片
            Win32_ParallelPort, // 并口
            Win32_SerialPort, // 串口
            Win32_SerialPortConfiguration, // 串口配置
            Win32_SoundDevice, // 多媒体设置，一般指声卡。
            Win32_SystemSlot, // 主板插槽 (ISA & PCI & AGP)
            Win32_USBController, // USB 控制器
            Win32_NetworkAdapter, // 网络适配器
            Win32_NetworkAdapterConfiguration, // 网络适配器设置
            Win32_Printer, // 打印机
            Win32_PrinterConfiguration, // 打印机设置
            Win32_PrintJob, // 打印机任务
            Win32_TCPIPPrinterPort, // 打印机端口
            Win32_POTSModem, // MODEM
            Win32_POTSModemToSerialPort, // MODEM 端口
            Win32_DesktopMonitor, // 显示器
            Win32_DisplayConfiguration, // 显卡
            Win32_DisplayControllerConfiguration, // 显卡设置
            Win32_VideoController, // 显卡细节。
            Win32_VideoSettings, // 显卡支持的显示模式。

            // 操作系统
            Win32_TimeZone, // 时区
            Win32_SystemDriver, // 驱动程序
            Win32_DiskPartition, // 磁盘分区
            Win32_LogicalDisk, // 逻辑磁盘
            Win32_LogicalDiskToPartition, // 逻辑磁盘所在分区及始末位置。
            Win32_LogicalMemoryConfiguration, // 逻辑内存配置
            Win32_PageFile, // 系统页文件信息
            Win32_PageFileSetting, // 页文件设置
            Win32_BootConfiguration, // 系统启动配置
            Win32_ComputerSystem, // 计算机信息简要
            Win32_OperatingSystem, // 操作系统信息
            Win32_StartupCommand, // 系统自动启动程序
            Win32_Service, // 系统安装的服务
            Win32_Group, // 系统管理组
            Win32_GroupUser, // 系统组帐号
            Win32_UserAccount, // 用户帐号
            Win32_Process, // 系统进程
            Win32_Thread, // 系统线程
            Win32_Share, // 共享
            Win32_NetworkClient, // 已安装的网络客户端
            Win32_NetworkProtocol, // 已安装的网络协议
            Win32_PnPEntity,//all device
        }
        /// <summary>
        /// WMI取硬件信息
        /// </summary>
        /// <param name="hardType"></param>
        /// <param name="propKey"></param>
        /// <returns></returns>
        public static List<string> MulGetHardwareInfo(HardwareEnum hardType, string propKey)
        {

            List<string> strs = new List<string>();
            try
            {
                //using (ManagementObjectSearcher searcher = new ManagementObjectSearcher("select * from " + hardType))
                //using (ManagementObjectSearcher searcher = new ManagementObjectSearcher(@"root\cimv2", "SELECT * FROM Win32_SerialPort"))
                ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_PnPEntity");
                foreach (ManagementObject obj in searcher.Get())
                {
                    if (null != obj.Properties[propKey])
                    {
                        if (null != obj.Properties[propKey].Value)
                        {
                            if (obj.Properties["Name"].Value.ToString().Contains("COM"))
                            {
                                strs.Add(obj.Properties[propKey].Value.ToString());
                            }
                            else if (obj.Properties["Caption"].Value.ToString().Contains("COM"))
                            {
                                strs.Add(obj.Properties["Caption"].Value.ToString());
                            }
                        }
                    }

                }
                searcher.Dispose();
                return strs;
            }
            catch
            {
                return null;
            }
            finally
            { strs = null; }
        }

        private string GetPortDiscription(string pName)
        {
            List < string > list = MulGetHardwareInfo(HardwareEnum.Win32_PnPEntity, "Name"); //MulGetHardwareInfo(HardwareEnum.Win32_SerialPort, "Name");

            foreach (string drv in list)
            {
                if (drv.IndexOf(pName, 0) >= 0)//GetComList
                {
                    return drv;
                }
            }

            return null;
        }

        private void RefreshPortInfo()
        {
            List<string> list = MulGetHardwareInfo(HardwareEnum.Win32_PnPEntity, "Name"); //MulGetHardwareInfo(HardwareEnum.Win32_SerialPort, "Name");
            string[] ports = SerialPort.GetPortNames();

            //BeginInvoke(new Action(() =>
            //{
            tsDropDownButtonPort.DropDownItems.Clear();

            //list.Sort();
            foreach (string drv in list)
            {
                ToolStripItem item = tsDropDownButtonPort.DropDownItems.Add(drv);
                foreach (string port in ports)
                {
                    if (drv.IndexOf(port, 0) >= 0)
                    {
                        item.Tag = port;
                        break;
                    }
                }
            }

            if (tsDropDownButtonPort.DropDownItems.Count > 0)
            {
                tsDropDownButtonPort.Text = (string)tsDropDownButtonPort.DropDownItems[0].Tag;
            }
            else
            {
                tsDropDownButtonPort.Text = "";
            }

            //}));
        }

        private bool UpdatePortSetting()
        {
            if (null == tsDropDownButtonPort.Text || tsDropDownButtonPort.Text == "")
            {
                return false;
            }
            try
            {
                PortSetting.PortName = tsDropDownButtonPort.Text;
                PortSetting.BaudRate = (int)tsDropDownButtonBaudRate.Tag;
                PortSetting.DataBits = (int)tsDropDownButtonDataBits.Tag;
                PortSetting.StopBits = (StopBits)tsDropDownButtonStopBits.Tag;
                PortSetting.Parity = (Parity)tsDropDownButtonParity.Tag;

                if (tsButtonBaudRateCustom.Checked)
                {
                    PortSetting.BaudRate = int.Parse(tbBaudRate.Text);
                }
            }
            catch
            {
            }

            return true;
        }

        private void PortProperty_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            ToolStripDropDownButton ddbt = sender as ToolStripDropDownButton;

            ddbt.Text = e.ClickedItem.Text;
            ddbt.Tag = e.ClickedItem.Tag;
        }

        private void tsDropDownButtonPort_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            ToolStripDropDownButton ddbt = sender as ToolStripDropDownButton;
            string drvName = e.ClickedItem.Text;
            /*string[] ports = SerialPort.GetPortNames();

            foreach (string port in ports)
            {
                if (drvName.IndexOf(port, 0) >= 0)
                {
                    ddbt.Text = port;
                    break;
                }
            }*/

            Regex portPattern = new Regex("COM\\d+");
            MatchCollection matches = portPattern.Matches(drvName);
            foreach (Match mch in matches)
            {
                //string x = mch.Value.Trim();
                //portListBox.Items.Add(x);
                ddbt.Text = mch.Value.Trim();
                break;
            }
        }

        private void tsButtonPortRefresh_Click(object sender, EventArgs e)
        {
            OnPortListChanged();
        }

        private void tbBaudRate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!((e.KeyChar >= 48 && e.KeyChar <= 57) || e.KeyChar == 8))
            {
                e.Handled = true;
            }
        }

        private void tsButtonBaudRateCustom_Click(object sender, EventArgs e)
        {
            tbBaudRate.Visible = tsButtonBaudRateCustom.Checked;
            tsDropDownButtonBaudRate.Visible = !tbBaudRate.Visible;
        }

        public void OnPortListChanged()
        {
            //BeginInvoke(new Action(() =>
            //{
                RefreshPortInfo();
            //}));
        }


        // usb消息定义
        /*public const int WM_DEVICE_CHANGE = 0x219;
        public const int DBT_DEVICEARRIVAL = 0x8000;
        public const int DBT_DEVICE_REMOVE_COMPLETE = 0x8004;
        public const UInt32 DBT_DEVTYP_PORT = 0x00000003;

        struct DEV_BROADCAST_HDR
        {
            public UInt32 dbch_size;
            public UInt32 dbch_devicetype;
            public UInt32 dbch_reserved;
        }

        struct DEV_BROADCAST_PORT
        {
            public uint dbcp_size;
            public uint dbcp_devicetype;
            public uint dbcp_reserved;
            //public char dbcp_name[1];
        }

        /// <summary>
        /// 检测USB串口的拔插
        /// </summary>
        /// <param name="m"></param>
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WM_DEVICE_CHANGE)        // 捕获USB设备的拔出消息WM_DEVICECHANGE
            {
                DEV_BROADCAST_HDR dbhdr;
                switch (m.WParam.ToInt32())
                {
                    case DBT_DEVICE_REMOVE_COMPLETE:    // USB拔出     
                    case DBT_DEVICEARRIVAL:             // USB插入获取对应串口名称
                        dbhdr = (DEV_BROADCAST_HDR)Marshal.PtrToStructure(m.LParam, typeof(DEV_BROADCAST_HDR));
                        if (dbhdr.dbch_devicetype == DBT_DEVTYP_PORT)
                        {
                            OnPortListChanged();
                        }
                        break;
                }
            }
            base.WndProc(ref m);
        }*/
        #endregion

        #region HighLight

        private void AddHighLightRow(string syntax, Color fore, Color back, FontStyle style)
        {
            if (syntax != "")
            {
                synaxHighLightGrid.SuspendLayout();

                DataGridViewRow dataGridViewRow = new DataGridViewRow();
                dataGridViewRow.CreateCells(synaxHighLightGrid);
                dataGridViewRow.Cells[0].Value = true;
                dataGridViewRow.Cells[1].Value = syntax;
                dataGridViewRow.Cells[1].Style.BackColor = back;
                dataGridViewRow.Cells[1].Style.SelectionBackColor = back;
                dataGridViewRow.Cells[1].Style.ForeColor = fore;
                dataGridViewRow.Cells[1].Style.SelectionForeColor = fore;
                dataGridViewRow.Cells[1].Style.Font = new Font("SimSun", 10f, style);

                synaxHighLightGrid.Rows.Add(dataGridViewRow);

                synaxHighLightGrid.ResumeLayout();
            }
        }

        private void UploadHighLightFile()
        {
            string syntax = "";
            Color fore = Color.Empty;
            Color back = Color.Empty;
            FontStyle fontstyle = FontStyle.Regular;

            try
            {
                XmlDocument xml = new XmlDocument();

                xml.Load(@"highlight.xml");

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
                            fontstyle |= FontStyle.Bold;
                        }
                        if ("true" == list.Item(0).Attributes["Italic"].InnerText)
                        {
                            fontstyle |= FontStyle.Italic;
                        }
                        if ("true" == list.Item(0).Attributes["Underline"].InnerText)
                        {
                            fontstyle |= FontStyle.Underline;
                        }
                        if ("true" == list.Item(0).Attributes["Strikeout"].InnerText)
                        {
                            fontstyle |= FontStyle.Strikeout;
                        }
                    }

                    AddHighLightRow(syntax, fore, back, fontstyle);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ClearHighLightListState()
        {
            synaxHighLightGrid.SuspendLayout();

            foreach (DataGridViewRow row in synaxHighLightGrid.Rows)
            {
                row.Cells[0].Value = false;
            }

            //HighLightList.ClearSelection();

            synaxHighLightGrid.ResumeLayout();
        }
        #endregion

        #region CreatePortForm
        private MainForm DockParent { get { return (MainForm)Owner; } }

        private void NewPortForm()
        {
            UpdatePortSetting();
            DummyDoc portform = DockParent.NewPortForm(PortSetting);

            foreach (DataGridViewRow row in synaxHighLightGrid.Rows)
            {
                if ((bool)row.Cells[0].Value)
                {
                    portform.AddxHighlightStyle((string)row.Cells[1].Value, row.Cells[1].Style.ForeColor, row.Cells[1].Style.BackColor, row.Cells[1].Style.Font.Style);
                }
            }



            DockParent.ShowPortForm(portform);
        }

        private void btNew_Click(object sender, EventArgs e)
        {
            NewPortForm();
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            Hide();
            Owner.Focus();
        }

        #endregion

        private void reloadHighlightList()
        {
            synaxHighLightGrid.SuspendLayout();
            synaxHighLightGrid.Rows.Clear();
            synaxHighLightGrid.ResumeLayout();

            UploadHighLightFile();
        }

        private void reloadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            reloadHighlightList();
        }
    }
}
