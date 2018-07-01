namespace ToolSuite
{
    partial class DummyOutputWindow
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
            ControlsLibrary.ImageItem imageItem6 = new ControlsLibrary.ImageItem();
            ControlsLibrary.ImageItem imageItem7 = new ControlsLibrary.ImageItem();
            ControlsLibrary.ImageItem imageItem8 = new ControlsLibrary.ImageItem();
            ControlsLibrary.ImageItem imageItem9 = new ControlsLibrary.ImageItem();
            ControlsLibrary.ImageItem imageItem10 = new ControlsLibrary.ImageItem();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DummyOutputWindow));
            this.toolStripMenu = new System.Windows.Forms.ToolStrip();
            this.ddtbSelect = new System.Windows.Forms.ToolStripDropDownButton();
            this.tsbtSendWinLock = new System.Windows.Forms.ToolStripButton();
            this.tsbtEdit = new System.Windows.Forms.ToolStripButton();
            this.outputTextBox = new ControlsLibrary.ToolStripSpringTextBox();
            this.sbtSend = new System.Windows.Forms.ToolStripButton();
            this.textBoxMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.outputMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.sendCurrentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sendSelect1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sendBookmarks1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.copy1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.paste1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clear1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.file1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.load1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.save1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.highQualityImageList = new ControlsLibrary.HighQualityImageList();
            this.mainFCTB = new FastColoredTextBoxNS.FastColoredTextBox();
            this.splitter = new System.Windows.Forms.Splitter();
            this.secondFCTB = new FastColoredTextBoxNS.FastColoredTextBox();
            this.secondFctbMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem7 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem8 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem9 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenu.SuspendLayout();
            this.textBoxMenu.SuspendLayout();
            this.outputMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mainFCTB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.secondFCTB)).BeginInit();
            this.secondFctbMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripMenu
            // 
            this.toolStripMenu.AutoSize = false;
            this.toolStripMenu.BackColor = System.Drawing.Color.WhiteSmoke;
            this.toolStripMenu.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStripMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ddtbSelect,
            this.tsbtSendWinLock,
            this.tsbtEdit,
            this.outputTextBox,
            this.sbtSend});
            this.toolStripMenu.Location = new System.Drawing.Point(0, 0);
            this.toolStripMenu.Name = "toolStripMenu";
            this.toolStripMenu.Padding = new System.Windows.Forms.Padding(2, 0, 1, 0);
            this.toolStripMenu.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStripMenu.Size = new System.Drawing.Size(542, 25);
            this.toolStripMenu.TabIndex = 2;
            // 
            // ddtbSelect
            // 
            this.ddtbSelect.Image = global::ToolSuite.Properties.Resources.airport;
            this.ddtbSelect.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ddtbSelect.Name = "ddtbSelect";
            this.ddtbSelect.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never;
            this.ddtbSelect.Size = new System.Drawing.Size(93, 22);
            this.ddtbSelect.Text = "No Select";
            this.ddtbSelect.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.ddtbSelect_DropDownItemClicked);
            this.ddtbSelect.TextChanged += new System.EventHandler(this.ddtbSelect_TextChanged);
            // 
            // tsbtSendWinLock
            // 
            this.tsbtSendWinLock.CheckOnClick = true;
            this.tsbtSendWinLock.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtSendWinLock.Image = global::ToolSuite.Properties.Resources.padlock_closed;
            this.tsbtSendWinLock.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtSendWinLock.Name = "tsbtSendWinLock";
            this.tsbtSendWinLock.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never;
            this.tsbtSendWinLock.Size = new System.Drawing.Size(23, 22);
            this.tsbtSendWinLock.Text = "lock";
            // 
            // tsbtEdit
            // 
            this.tsbtEdit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtEdit.Image = global::ToolSuite.Properties.Resources.edit;
            this.tsbtEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtEdit.Name = "tsbtEdit";
            this.tsbtEdit.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never;
            this.tsbtEdit.Size = new System.Drawing.Size(23, 22);
            this.tsbtEdit.Text = "edit mode";
            this.tsbtEdit.Click += new System.EventHandler(this.tsbtEdit_Click);
            // 
            // outputTextBox
            // 
            this.outputTextBox.AutoSize = false;
            this.outputTextBox.BorderColor = System.Drawing.Color.Gainsboro;
            this.outputTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.outputTextBox.Margin = new System.Windows.Forms.Padding(2, 0, 1, 0);
            this.outputTextBox.Minimum = 200;
            this.outputTextBox.Name = "outputTextBox";
            this.outputTextBox.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never;
            this.outputTextBox.Padding = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.outputTextBox.Size = new System.Drawing.Size(343, 18);
            this.outputTextBox.Spring = true;
            this.outputTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.outputTextBox_KeyDown);
            // 
            // sbtSend
            // 
            this.sbtSend.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.sbtSend.Image = global::ToolSuite.Properties.Resources.chat_active1;
            this.sbtSend.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.sbtSend.Name = "sbtSend";
            this.sbtSend.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never;
            this.sbtSend.Size = new System.Drawing.Size(23, 22);
            this.sbtSend.Click += new System.EventHandler(this.sbtSend_ButtonClick);
            // 
            // textBoxMenu
            // 
            this.textBoxMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copyToolStripMenuItem,
            this.copyAllToolStripMenuItem,
            this.pasteToolStripMenuItem});
            this.textBoxMenu.Name = "textBoxMenu";
            this.textBoxMenu.Size = new System.Drawing.Size(125, 70);
            // 
            // copyToolStripMenuItem
            // 
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            this.copyToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.copyToolStripMenuItem.Text = "Copy";
            // 
            // copyAllToolStripMenuItem
            // 
            this.copyAllToolStripMenuItem.Name = "copyAllToolStripMenuItem";
            this.copyAllToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.copyAllToolStripMenuItem.Text = "Copy All";
            // 
            // pasteToolStripMenuItem
            // 
            this.pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
            this.pasteToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.pasteToolStripMenuItem.Text = "Paste";
            // 
            // outputMenu
            // 
            this.outputMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sendCurrentToolStripMenuItem,
            this.sendSelect1ToolStripMenuItem,
            this.sendBookmarks1ToolStripMenuItem,
            this.toolStripSeparator4,
            this.copy1ToolStripMenuItem,
            this.paste1ToolStripMenuItem,
            this.clear1ToolStripMenuItem,
            this.toolStripSeparator5,
            this.file1ToolStripMenuItem});
            this.outputMenu.Name = "outputMenu";
            this.outputMenu.Size = new System.Drawing.Size(177, 170);
            // 
            // sendCurrentToolStripMenuItem
            // 
            this.sendCurrentToolStripMenuItem.Name = "sendCurrentToolStripMenuItem";
            this.sendCurrentToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.sendCurrentToolStripMenuItem.Text = "Send Current";
            this.sendCurrentToolStripMenuItem.Click += new System.EventHandler(this.sendCurrentToolStripMenuItem_Click);
            // 
            // sendSelect1ToolStripMenuItem
            // 
            this.sendSelect1ToolStripMenuItem.Name = "sendSelect1ToolStripMenuItem";
            this.sendSelect1ToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.sendSelect1ToolStripMenuItem.Text = "Send Select";
            this.sendSelect1ToolStripMenuItem.Click += new System.EventHandler(this.sendSelectToolStripMenuItem_Click);
            // 
            // sendBookmarks1ToolStripMenuItem
            // 
            this.sendBookmarks1ToolStripMenuItem.Name = "sendBookmarks1ToolStripMenuItem";
            this.sendBookmarks1ToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.sendBookmarks1ToolStripMenuItem.Text = "Send Bookmarks";
            this.sendBookmarks1ToolStripMenuItem.Click += new System.EventHandler(this.sendBookmarksToolStripMenuItem_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(173, 6);
            // 
            // copy1ToolStripMenuItem
            // 
            this.copy1ToolStripMenuItem.Name = "copy1ToolStripMenuItem";
            this.copy1ToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.copy1ToolStripMenuItem.Text = "Copy";
            this.copy1ToolStripMenuItem.Click += new System.EventHandler(this.copyToolStripMenuItem_Click);
            // 
            // paste1ToolStripMenuItem
            // 
            this.paste1ToolStripMenuItem.Name = "paste1ToolStripMenuItem";
            this.paste1ToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.paste1ToolStripMenuItem.Text = "Paste";
            this.paste1ToolStripMenuItem.Click += new System.EventHandler(this.pasteToolStripMenuItem_Click);
            // 
            // clear1ToolStripMenuItem
            // 
            this.clear1ToolStripMenuItem.Name = "clear1ToolStripMenuItem";
            this.clear1ToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.clear1ToolStripMenuItem.Text = "Clear";
            this.clear1ToolStripMenuItem.Click += new System.EventHandler(this.clearToolStripMenuItem_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(173, 6);
            // 
            // file1ToolStripMenuItem
            // 
            this.file1ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.load1ToolStripMenuItem,
            this.save1ToolStripMenuItem});
            this.file1ToolStripMenuItem.Name = "file1ToolStripMenuItem";
            this.file1ToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.file1ToolStripMenuItem.Text = "File";
            // 
            // load1ToolStripMenuItem
            // 
            this.load1ToolStripMenuItem.Name = "load1ToolStripMenuItem";
            this.load1ToolStripMenuItem.Size = new System.Drawing.Size(105, 22);
            this.load1ToolStripMenuItem.Text = "Load";
            this.load1ToolStripMenuItem.Click += new System.EventHandler(this.loadToolStripMenuItem_Click);
            // 
            // save1ToolStripMenuItem
            // 
            this.save1ToolStripMenuItem.Name = "save1ToolStripMenuItem";
            this.save1ToolStripMenuItem.Size = new System.Drawing.Size(105, 22);
            this.save1ToolStripMenuItem.Text = "Save";
            this.save1ToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // highQualityImageList
            // 
            imageItem6.Image = global::ToolSuite.Properties.Resources.connection_error_alt_1;
            imageItem6.Text = "imageItem";
            imageItem7.Image = global::ToolSuite.Properties.Resources.connect_alt_1;
            imageItem7.Text = "imageItem";
            imageItem8.Image = global::ToolSuite.Properties.Resources.airport;
            imageItem8.Text = "imageItem";
            imageItem9.Image = global::ToolSuite.Properties.Resources.edit;
            imageItem9.Text = "imageItem";
            imageItem10.Image = global::ToolSuite.Properties.Resources.read_only;
            imageItem10.Text = "imageItem";
            this.highQualityImageList.ImageItems.Add(imageItem6);
            this.highQualityImageList.ImageItems.Add(imageItem7);
            this.highQualityImageList.ImageItems.Add(imageItem8);
            this.highQualityImageList.ImageItems.Add(imageItem9);
            this.highQualityImageList.ImageItems.Add(imageItem10);
            // 
            // mainFCTB
            // 
            this.mainFCTB.AutoCompleteBracketsList = new char[] {
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
            this.mainFCTB.AutoScrollMargin = new System.Drawing.Size(10, 0);
            this.mainFCTB.AutoScrollMinSize = new System.Drawing.Size(27, 14);
            this.mainFCTB.BackBrush = null;
            this.mainFCTB.BookmarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(226)))), ((int)(((byte)(108)))));
            this.mainFCTB.CharHeight = 14;
            this.mainFCTB.CharWidth = 8;
            this.mainFCTB.ContextMenuStrip = this.outputMenu;
            this.mainFCTB.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.mainFCTB.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.mainFCTB.Dock = System.Windows.Forms.DockStyle.Left;
            this.mainFCTB.FirstSearch = true;
            this.mainFCTB.Font = new System.Drawing.Font("Courier New", 9.75F);
            this.mainFCTB.ForeColor = System.Drawing.Color.Black;
            this.mainFCTB.IndentBackColor = System.Drawing.Color.White;
            this.mainFCTB.IsReplaceMode = false;
            this.mainFCTB.LineNumberColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.mainFCTB.Location = new System.Drawing.Point(0, 25);
            this.mainFCTB.Margin = new System.Windows.Forms.Padding(0);
            this.mainFCTB.MatchCase = false;
            this.mainFCTB.Name = "mainFCTB";
            this.mainFCTB.Paddings = new System.Windows.Forms.Padding(0);
            this.mainFCTB.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.mainFCTB.ServiceColors = ((FastColoredTextBoxNS.ServiceColors)(resources.GetObject("mainFCTB.ServiceColors")));
            this.mainFCTB.ServiceLinesColor = System.Drawing.Color.WhiteSmoke;
            this.mainFCTB.Size = new System.Drawing.Size(356, 254);
            this.mainFCTB.TabIndex = 0;
            this.mainFCTB.UseRegex = false;
            this.mainFCTB.WholeWord = false;
            this.mainFCTB.Zoom = 100;
            this.mainFCTB.Scroll += new System.Windows.Forms.ScrollEventHandler(this.fctbOutput_Scroll);
            this.mainFCTB.KeyDown += new System.Windows.Forms.KeyEventHandler(this.fctbOutput_KeyDown);
            this.mainFCTB.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.fctbOutput_MouseDoubleClick);
            // 
            // splitter
            // 
            this.splitter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            this.splitter.Location = new System.Drawing.Point(356, 25);
            this.splitter.MinExtra = 1;
            this.splitter.MinSize = 3;
            this.splitter.Name = "splitter";
            this.splitter.Size = new System.Drawing.Size(2, 254);
            this.splitter.TabIndex = 3;
            this.splitter.TabStop = false;
            // 
            // secondFCTB
            // 
            this.secondFCTB.AutoCompleteBracketsList = new char[] {
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
            this.secondFCTB.AutoScrollMargin = new System.Drawing.Size(10, 0);
            this.secondFCTB.AutoScrollMinSize = new System.Drawing.Size(27, 14);
            this.secondFCTB.BackBrush = null;
            this.secondFCTB.BookmarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(226)))), ((int)(((byte)(108)))));
            this.secondFCTB.CharHeight = 14;
            this.secondFCTB.CharWidth = 8;
            this.secondFCTB.ContextMenuStrip = this.outputMenu;
            this.secondFCTB.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.secondFCTB.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.secondFCTB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.secondFCTB.FirstSearch = true;
            this.secondFCTB.ForeColor = System.Drawing.Color.Black;
            this.secondFCTB.IndentBackColor = System.Drawing.Color.White;
            this.secondFCTB.IsReplaceMode = false;
            this.secondFCTB.LineNumberColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.secondFCTB.Location = new System.Drawing.Point(358, 25);
            this.secondFCTB.Margin = new System.Windows.Forms.Padding(0);
            this.secondFCTB.MatchCase = false;
            this.secondFCTB.Name = "secondFCTB";
            this.secondFCTB.Paddings = new System.Windows.Forms.Padding(0);
            this.secondFCTB.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.secondFCTB.ServiceColors = ((FastColoredTextBoxNS.ServiceColors)(resources.GetObject("secondFCTB.ServiceColors")));
            this.secondFCTB.ServiceLinesColor = System.Drawing.Color.WhiteSmoke;
            this.secondFCTB.Size = new System.Drawing.Size(184, 254);
            this.secondFCTB.TabIndex = 4;
            this.secondFCTB.UseRegex = false;
            this.secondFCTB.WholeWord = false;
            this.secondFCTB.Zoom = 100;
            this.secondFCTB.KeyDown += new System.Windows.Forms.KeyEventHandler(this.fctbOutput_KeyDown);
            // 
            // secondFctbMenu
            // 
            this.secondFctbMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.toolStripMenuItem2,
            this.toolStripMenuItem3,
            this.toolStripSeparator1,
            this.toolStripMenuItem4,
            this.toolStripMenuItem5,
            this.toolStripMenuItem6,
            this.toolStripSeparator2,
            this.toolStripMenuItem7});
            this.secondFctbMenu.Name = "outputMenu";
            this.secondFctbMenu.Size = new System.Drawing.Size(177, 170);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(176, 22);
            this.toolStripMenuItem1.Text = "Send Current";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(176, 22);
            this.toolStripMenuItem2.Text = "Send Select";
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(176, 22);
            this.toolStripMenuItem3.Text = "Send Bookmarks";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(173, 6);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(176, 22);
            this.toolStripMenuItem4.Text = "Copy";
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(176, 22);
            this.toolStripMenuItem5.Text = "Paste";
            // 
            // toolStripMenuItem6
            // 
            this.toolStripMenuItem6.Name = "toolStripMenuItem6";
            this.toolStripMenuItem6.Size = new System.Drawing.Size(176, 22);
            this.toolStripMenuItem6.Text = "Clear";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(173, 6);
            // 
            // toolStripMenuItem7
            // 
            this.toolStripMenuItem7.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem8,
            this.toolStripMenuItem9});
            this.toolStripMenuItem7.Name = "toolStripMenuItem7";
            this.toolStripMenuItem7.Size = new System.Drawing.Size(176, 22);
            this.toolStripMenuItem7.Text = "File";
            // 
            // toolStripMenuItem8
            // 
            this.toolStripMenuItem8.Name = "toolStripMenuItem8";
            this.toolStripMenuItem8.Size = new System.Drawing.Size(105, 22);
            this.toolStripMenuItem8.Text = "Load";
            // 
            // toolStripMenuItem9
            // 
            this.toolStripMenuItem9.Name = "toolStripMenuItem9";
            this.toolStripMenuItem9.Size = new System.Drawing.Size(105, 22);
            this.toolStripMenuItem9.Text = "Save";
            // 
            // DummyOutputWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(542, 279);
            this.CloseButtonVisible = false;
            this.Controls.Add(this.secondFCTB);
            this.Controls.Add(this.splitter);
            this.Controls.Add(this.mainFCTB);
            this.Controls.Add(this.toolStripMenu);
            this.DockAreas = ((WeifenLuo.WinFormsUI.Docking.DockAreas)((WeifenLuo.WinFormsUI.Docking.DockAreas.Float | WeifenLuo.WinFormsUI.Docking.DockAreas.DockBottom)));
            this.HideOnClose = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DummyOutputWindow";
            this.ShowHint = WeifenLuo.WinFormsUI.Docking.DockState.DockBottomAutoHide;
            this.TabText = "Output";
            this.Text = "Output";
            this.toolStripMenu.ResumeLayout(false);
            this.toolStripMenu.PerformLayout();
            this.textBoxMenu.ResumeLayout(false);
            this.outputMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mainFCTB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.secondFCTB)).EndInit();
            this.secondFctbMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        #endregion
        private System.Windows.Forms.ToolStrip toolStripMenu;
        private ControlsLibrary.ToolStripSpringTextBox outputTextBox;
        private System.Windows.Forms.ToolStripDropDownButton ddtbSelect;
        private System.Windows.Forms.ToolStripButton tsbtSendWinLock;
        private System.Windows.Forms.ToolStripButton tsbtEdit;
        private System.Windows.Forms.ContextMenuStrip outputMenu;
        private System.Windows.Forms.ToolStripMenuItem sendCurrentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sendSelect1ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sendBookmarks1ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem copy1ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem paste1ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clear1ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem file1ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem load1ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem save1ToolStripMenuItem;
        private ControlsLibrary.HighQualityImageList highQualityImageList;
        private System.Windows.Forms.ToolStripButton sbtSend;
        private System.Windows.Forms.ContextMenuStrip textBoxMenu;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pasteToolStripMenuItem;
        public FastColoredTextBoxNS.FastColoredTextBox mainFCTB;
        private System.Windows.Forms.Splitter splitter;
        public FastColoredTextBoxNS.FastColoredTextBox secondFCTB;
        private System.Windows.Forms.ContextMenuStrip secondFctbMenu;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem5;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem6;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem7;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem8;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem9;
    }
}