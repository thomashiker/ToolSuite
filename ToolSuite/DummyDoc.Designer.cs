namespace ToolSuite
{
    partial class DummyDoc
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DummyDoc));
            this.serialPort = new System.IO.Ports.SerialPort(this.components);
            this.sysMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.connectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showLineToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.clearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.settingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearBookMarksToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FCTB = new FastColoredTextBoxNS.FastColoredTextBox();
            this.highQualityImageList = new ControlsLibrary.HighQualityImageList();
            this.IconConnect = new ControlsLibrary.IconImage(this.components);
            this.IconDisconnect = new ControlsLibrary.IconImage(this.components);
            this.sysMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FCTB)).BeginInit();
            this.SuspendLayout();
            // 
            // serialPort
            // 
            this.serialPort.ReadBufferSize = 40960;
            this.serialPort.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort_DataReceived);
            // 
            // sysMenu
            // 
            this.sysMenu.DropShadowEnabled = false;
            this.sysMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.connectToolStripMenuItem,
            this.showLineToolStripMenuItem,
            this.toolStripSeparator1,
            this.clearToolStripMenuItem,
            this.copyToolStripMenuItem,
            this.copyAllToolStripMenuItem,
            this.toolStripSeparator2,
            this.settingToolStripMenuItem,
            this.clearBookMarksToolStripMenuItem});
            this.sysMenu.Name = "sysMenu";
            this.sysMenu.Size = new System.Drawing.Size(178, 170);
            // 
            // connectToolStripMenuItem
            // 
            this.connectToolStripMenuItem.Name = "connectToolStripMenuItem";
            this.connectToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.connectToolStripMenuItem.Text = "&Connect";
            this.connectToolStripMenuItem.Click += new System.EventHandler(this.connectToolStripMenuItem_Click);
            // 
            // showLineToolStripMenuItem
            // 
            this.showLineToolStripMenuItem.Checked = true;
            this.showLineToolStripMenuItem.CheckOnClick = true;
            this.showLineToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.showLineToolStripMenuItem.Name = "showLineToolStripMenuItem";
            this.showLineToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.showLineToolStripMenuItem.Text = "&Show Line";
            this.showLineToolStripMenuItem.Click += new System.EventHandler(this.showLineToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(174, 6);
            // 
            // clearToolStripMenuItem
            // 
            this.clearToolStripMenuItem.Name = "clearToolStripMenuItem";
            this.clearToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.clearToolStripMenuItem.Text = "Clear";
            this.clearToolStripMenuItem.Click += new System.EventHandler(this.clearToolStripMenuItem_Click);
            // 
            // copyToolStripMenuItem
            // 
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            this.copyToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.copyToolStripMenuItem.Text = "Copy";
            this.copyToolStripMenuItem.Click += new System.EventHandler(this.copyToolStripMenuItem_Click);
            // 
            // copyAllToolStripMenuItem
            // 
            this.copyAllToolStripMenuItem.Name = "copyAllToolStripMenuItem";
            this.copyAllToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.copyAllToolStripMenuItem.Text = "Copy All";
            this.copyAllToolStripMenuItem.Click += new System.EventHandler(this.copyAllToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(174, 6);
            // 
            // settingToolStripMenuItem
            // 
            this.settingToolStripMenuItem.Name = "settingToolStripMenuItem";
            this.settingToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.settingToolStripMenuItem.Text = "Setting";
            this.settingToolStripMenuItem.Click += new System.EventHandler(this.settingToolStripMenuItem_Click);
            // 
            // clearBookMarksToolStripMenuItem
            // 
            this.clearBookMarksToolStripMenuItem.Name = "clearBookMarksToolStripMenuItem";
            this.clearBookMarksToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.clearBookMarksToolStripMenuItem.Text = "Clear Bookmarks";
            this.clearBookMarksToolStripMenuItem.Click += new System.EventHandler(this.clearBookMarksToolStripMenuItem_Click);
            // 
            // FCTB
            // 
            this.FCTB.AutoCompleteBracketsList = new char[] {
        '(',
        ')',
        '{',
        '}',
        '[',
        ']',
        '\"',
        '\"',
        '\'',
        '\''};
            this.FCTB.AutoScrollMinSize = new System.Drawing.Size(27, 14);
            this.FCTB.BackBrush = null;
            this.FCTB.BookmarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(226)))), ((int)(((byte)(108)))));
            this.FCTB.CharHeight = 14;
            this.FCTB.CharWidth = 8;
            this.FCTB.ContextMenuStrip = this.sysMenu;
            this.FCTB.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.FCTB.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.FCTB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FCTB.FirstSearch = true;
            this.FCTB.Font = new System.Drawing.Font("Courier New", 9.75F);
            this.FCTB.ForeColor = System.Drawing.Color.Black;
            this.FCTB.IndentBackColor = System.Drawing.Color.White;
            this.FCTB.IsReplaceMode = false;
            this.FCTB.LineNumberColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.FCTB.Location = new System.Drawing.Point(0, 0);
            this.FCTB.Margin = new System.Windows.Forms.Padding(0);
            this.FCTB.MatchCase = false;
            this.FCTB.Name = "FCTB";
            this.FCTB.Paddings = new System.Windows.Forms.Padding(0);
            this.FCTB.ReadOnly = true;
            this.FCTB.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(117)))), ((int)(((byte)(217)))), ((int)(((byte)(117)))));
            this.FCTB.ServiceColors = ((FastColoredTextBoxNS.ServiceColors)(resources.GetObject("FCTB.ServiceColors")));
            this.FCTB.ServiceLinesColor = System.Drawing.Color.WhiteSmoke;
            this.FCTB.Size = new System.Drawing.Size(542, 330);
            this.FCTB.TabIndex = 0;
            this.FCTB.UseRegex = false;
            this.FCTB.WholeWord = false;
            this.FCTB.Zoom = 100;
            this.FCTB.TextChanged += new System.EventHandler<FastColoredTextBoxNS.TextChangedEventArgs>(this.fctb_TextChanged);
            this.FCTB.KeyDown += new System.Windows.Forms.KeyEventHandler(this.fctbRcv_KeyDown);
            this.FCTB.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.fctbRcv_MouseDoubleClick);
            // 
            // IconConnect
            // 
            this.IconConnect.Icon = ((System.Drawing.Icon)(resources.GetObject("IconConnect.Icon")));
            // 
            // IconDisconnect
            // 
            this.IconDisconnect.Icon = ((System.Drawing.Icon)(resources.GetObject("IconDisconnect.Icon")));
            // 
            // DummyDoc
            // 
            this.ClientSize = new System.Drawing.Size(542, 330);
            this.Controls.Add(this.FCTB);
            this.DockAreas = WeifenLuo.WinFormsUI.Docking.DockAreas.Document;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DummyDoc";
            this.Activated += new System.EventHandler(this.DummyDoc_Activated);
            this.Deactivate += new System.EventHandler(this.DummyDoc_Deactivate);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.DummyDoc_FormClosed);
            this.Load += new System.EventHandler(this.DummyDoc_Load);
            this.sysMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.FCTB)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        public FastColoredTextBoxNS.FastColoredTextBox FCTB;
        private System.IO.Ports.SerialPort serialPort;
        private System.Windows.Forms.ToolStripMenuItem connectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showLineToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem clearToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem copyAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearBookMarksToolStripMenuItem;
        private ControlsLibrary.HighQualityImageList highQualityImageList;
        private System.Windows.Forms.ContextMenuStrip sysMenu;
        private ControlsLibrary.IconImage IconConnect;
        private ControlsLibrary.IconImage IconDisconnect;
    }
}