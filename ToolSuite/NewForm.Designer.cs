namespace ToolSuite
{
    partial class NewForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NewForm));
            this.toolSettingTabControl = new MetroFramework.Controls.MetroTabControl();
            this.SerialPortTabPage = new MetroFramework.Controls.MetroTabPage();
            this.synaxHighLightGrid = new ControlLibrary.MetroGrid();
            this.staticToolTip = new ControlLibrary.MetroTip();
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.reloadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripParity = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel5 = new System.Windows.Forms.ToolStripLabel();
            this.tsDropDownButtonParity = new System.Windows.Forms.ToolStripDropDownButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.toolStripStopBits = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel4 = new System.Windows.Forms.ToolStripLabel();
            this.tsDropDownButtonStopBits = new System.Windows.Forms.ToolStripDropDownButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripDataBits = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel3 = new System.Windows.Forms.ToolStripLabel();
            this.tsDropDownButtonDataBits = new System.Windows.Forms.ToolStripDropDownButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripBaudRate = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.tsDropDownButtonBaudRate = new System.Windows.Forms.ToolStripDropDownButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsButtonBaudRateCustom = new System.Windows.Forms.ToolStripButton();
            this.toolStripPortName = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.tsDropDownButtonPort = new System.Windows.Forms.ToolStripDropDownButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsButtonPortRefresh = new System.Windows.Forms.ToolStripButton();
            this.AboutTabPage = new MetroFramework.Controls.MetroTabPage();
            this.btNew = new ControlsLibrary.MetroMenuButton();
            this.btClose = new ControlsLibrary.MetroMenuButton();
            this.metroToolTip = new ControlLibrary.MetroToolTip();
            this.ColumnCheck = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ColumnText = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolSettingTabControl.SuspendLayout();
            this.SerialPortTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.synaxHighLightGrid)).BeginInit();
            this.contextMenuStrip.SuspendLayout();
            this.toolStripParity.SuspendLayout();
            this.toolStripStopBits.SuspendLayout();
            this.toolStripDataBits.SuspendLayout();
            this.toolStripBaudRate.SuspendLayout();
            this.toolStripPortName.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolSettingTabControl
            // 
            this.toolSettingTabControl.Controls.Add(this.SerialPortTabPage);
            this.toolSettingTabControl.Controls.Add(this.AboutTabPage);
            this.toolSettingTabControl.Cursor = System.Windows.Forms.Cursors.Hand;
            this.toolSettingTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolSettingTabControl.ItemSize = new System.Drawing.Size(80, 20);
            this.toolSettingTabControl.Location = new System.Drawing.Point(2, 25);
            this.toolSettingTabControl.Name = "toolSettingTabControl";
            this.toolSettingTabControl.SelectedIndex = 0;
            this.toolSettingTabControl.Size = new System.Drawing.Size(405, 317);
            this.toolSettingTabControl.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.toolSettingTabControl.Speed = 5;
            this.toolSettingTabControl.TabIndex = 0;
            this.toolSettingTabControl.TabSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            this.toolSettingTabControl.UseAnimation = true;
            this.toolSettingTabControl.UseCustomBackColor = true;
            this.toolSettingTabControl.UseCustomForeColor = true;
            this.toolSettingTabControl.UseCustomTabSelectedColor = true;
            this.toolSettingTabControl.UseSelectable = true;
            // 
            // SerialPortTabPage
            // 
            this.SerialPortTabPage.BackColor = System.Drawing.Color.White;
            this.SerialPortTabPage.Controls.Add(this.synaxHighLightGrid);
            this.SerialPortTabPage.Controls.Add(this.staticToolTip);
            this.SerialPortTabPage.Controls.Add(this.toolStripParity);
            this.SerialPortTabPage.Controls.Add(this.toolStripStopBits);
            this.SerialPortTabPage.Controls.Add(this.toolStripDataBits);
            this.SerialPortTabPage.Controls.Add(this.toolStripBaudRate);
            this.SerialPortTabPage.Controls.Add(this.toolStripPortName);
            this.SerialPortTabPage.HorizontalScrollbarBarColor = true;
            this.SerialPortTabPage.HorizontalScrollbarHighlightOnWheel = false;
            this.SerialPortTabPage.HorizontalScrollbarSize = 10;
            this.SerialPortTabPage.Location = new System.Drawing.Point(4, 24);
            this.SerialPortTabPage.Name = "SerialPortTabPage";
            this.SerialPortTabPage.Size = new System.Drawing.Size(397, 289);
            this.SerialPortTabPage.TabIndex = 0;
            this.SerialPortTabPage.Text = " serial port";
            this.SerialPortTabPage.UseCustomBackColor = true;
            this.SerialPortTabPage.UseCustomForeColor = true;
            this.SerialPortTabPage.VerticalScrollbarBarColor = true;
            this.SerialPortTabPage.VerticalScrollbarHighlightOnWheel = false;
            this.SerialPortTabPage.VerticalScrollbarSize = 10;
            // 
            // synaxHighLightGrid
            // 
            this.synaxHighLightGrid.AllowUserToAddRows = false;
            this.synaxHighLightGrid.AllowUserToDeleteRows = false;
            this.synaxHighLightGrid.AllowUserToResizeColumns = false;
            this.synaxHighLightGrid.AllowUserToResizeRows = false;
            this.synaxHighLightGrid.BackgroundColor = System.Drawing.Color.White;
            this.synaxHighLightGrid.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            this.synaxHighLightGrid.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.synaxHighLightGrid.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.synaxHighLightGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.synaxHighLightGrid.ColumnHeadersDefaultCellStyleBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            this.synaxHighLightGrid.ColumnHeadersDefaultCellStyleForeColor = System.Drawing.Color.White;
            this.synaxHighLightGrid.ColumnHeadersDefaultCellStyleSelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            this.synaxHighLightGrid.ColumnHeadersDefaultCellStyleSelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.synaxHighLightGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.synaxHighLightGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnCheck,
            this.ColumnText});
            this.synaxHighLightGrid.ContextMenuStrip = this.contextMenuStrip;
            this.synaxHighLightGrid.DefaultCellSelectionBackColor = System.Drawing.Color.White;
            this.synaxHighLightGrid.DefaultCellSelectionForeColor = System.Drawing.Color.DimGray;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.DimGray;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.synaxHighLightGrid.DefaultCellStyle = dataGridViewCellStyle2;
            this.synaxHighLightGrid.EnableHeadersVisualStyles = false;
            this.synaxHighLightGrid.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.synaxHighLightGrid.GridColor = System.Drawing.Color.Gray;
            this.synaxHighLightGrid.HighLightPercentage = 0.5F;
            this.synaxHighLightGrid.Location = new System.Drawing.Point(0, 139);
            this.synaxHighLightGrid.MultiSelect = false;
            this.synaxHighLightGrid.Name = "synaxHighLightGrid";
            this.synaxHighLightGrid.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.synaxHighLightGrid.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.synaxHighLightGrid.RowHeadersDefaultCellStyleBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            this.synaxHighLightGrid.RowHeadersDefaultCellStyleForeColor = System.Drawing.Color.White;
            this.synaxHighLightGrid.RowHeadersSelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            this.synaxHighLightGrid.RowHeadersSelectionForeColor = System.Drawing.Color.White;
            this.synaxHighLightGrid.RowHeadersVisible = false;
            this.synaxHighLightGrid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.synaxHighLightGrid.RowTemplate.Height = 23;
            this.synaxHighLightGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.synaxHighLightGrid.Size = new System.Drawing.Size(397, 150);
            this.synaxHighLightGrid.TabIndex = 31;
            // 
            // staticToolTip
            // 
            this.staticToolTip.BorderColor = System.Drawing.Color.WhiteSmoke;
            this.staticToolTip.Font = new System.Drawing.Font("SimSun", 10F);
            this.staticToolTip.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            this.staticToolTip.Lines = new string[] {
        "tips:",
        "1. Modify highlight.xml to add customize highlight text."};
            this.staticToolTip.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            this.staticToolTip.LinkFont = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.staticToolTip.LinkPadding = new System.Windows.Forms.Padding(0, 0, 3, 3);
            this.staticToolTip.Location = new System.Drawing.Point(219, 7);
            this.staticToolTip.Name = "staticToolTip";
            this.staticToolTip.ShowBorder = true;
            this.staticToolTip.Size = new System.Drawing.Size(178, 125);
            this.staticToolTip.TabIndex = 30;
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.reloadToolStripMenuItem});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(153, 48);
            // 
            // reloadToolStripMenuItem
            // 
            this.reloadToolStripMenuItem.Name = "reloadToolStripMenuItem";
            this.reloadToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.reloadToolStripMenuItem.Text = "&Reload";
            this.reloadToolStripMenuItem.Click += new System.EventHandler(this.reloadToolStripMenuItem_Click);
            // 
            // toolStripParity
            // 
            this.toolStripParity.BackColor = System.Drawing.Color.White;
            this.toolStripParity.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStripParity.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStripParity.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel5,
            this.tsDropDownButtonParity,
            this.toolStripSeparator5,
            this.toolStripButton3});
            this.toolStripParity.Location = new System.Drawing.Point(4, 107);
            this.toolStripParity.Name = "toolStripParity";
            this.toolStripParity.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStripParity.Size = new System.Drawing.Size(212, 25);
            this.toolStripParity.TabIndex = 27;
            this.toolStripParity.Text = "toolStrip5";
            // 
            // toolStripLabel5
            // 
            this.toolStripLabel5.AutoSize = false;
            this.toolStripLabel5.Name = "toolStripLabel5";
            this.toolStripLabel5.Size = new System.Drawing.Size(80, 22);
            this.toolStripLabel5.Text = "Parity";
            this.toolStripLabel5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tsDropDownButtonParity
            // 
            this.tsDropDownButtonParity.AutoSize = false;
            this.tsDropDownButtonParity.AutoToolTip = false;
            this.tsDropDownButtonParity.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsDropDownButtonParity.Image = ((System.Drawing.Image)(resources.GetObject("tsDropDownButtonParity.Image")));
            this.tsDropDownButtonParity.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsDropDownButtonParity.Name = "tsDropDownButtonParity";
            this.tsDropDownButtonParity.Size = new System.Drawing.Size(100, 22);
            this.tsDropDownButtonParity.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.None;
            this.toolStripButton3.Enabled = false;
            this.toolStripButton3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton3.Image")));
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton3.Text = "toolStripButton3";
            // 
            // toolStripStopBits
            // 
            this.toolStripStopBits.BackColor = System.Drawing.Color.White;
            this.toolStripStopBits.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStripStopBits.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStripStopBits.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel4,
            this.tsDropDownButtonStopBits,
            this.toolStripSeparator4,
            this.toolStripButton2});
            this.toolStripStopBits.Location = new System.Drawing.Point(4, 82);
            this.toolStripStopBits.Name = "toolStripStopBits";
            this.toolStripStopBits.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStripStopBits.Size = new System.Drawing.Size(212, 25);
            this.toolStripStopBits.TabIndex = 26;
            this.toolStripStopBits.Text = "toolStrip4";
            // 
            // toolStripLabel4
            // 
            this.toolStripLabel4.AutoSize = false;
            this.toolStripLabel4.Name = "toolStripLabel4";
            this.toolStripLabel4.Size = new System.Drawing.Size(80, 22);
            this.toolStripLabel4.Text = "Stop bits";
            this.toolStripLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tsDropDownButtonStopBits
            // 
            this.tsDropDownButtonStopBits.AutoSize = false;
            this.tsDropDownButtonStopBits.AutoToolTip = false;
            this.tsDropDownButtonStopBits.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsDropDownButtonStopBits.Image = ((System.Drawing.Image)(resources.GetObject("tsDropDownButtonStopBits.Image")));
            this.tsDropDownButtonStopBits.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsDropDownButtonStopBits.Name = "tsDropDownButtonStopBits";
            this.tsDropDownButtonStopBits.Size = new System.Drawing.Size(100, 22);
            this.tsDropDownButtonStopBits.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.None;
            this.toolStripButton2.Enabled = false;
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton2.Text = "toolStripButton2";
            // 
            // toolStripDataBits
            // 
            this.toolStripDataBits.BackColor = System.Drawing.Color.White;
            this.toolStripDataBits.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStripDataBits.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStripDataBits.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel3,
            this.tsDropDownButtonDataBits,
            this.toolStripSeparator3,
            this.toolStripButton1});
            this.toolStripDataBits.Location = new System.Drawing.Point(4, 57);
            this.toolStripDataBits.Name = "toolStripDataBits";
            this.toolStripDataBits.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStripDataBits.Size = new System.Drawing.Size(212, 25);
            this.toolStripDataBits.TabIndex = 25;
            this.toolStripDataBits.Text = "toolStrip3";
            // 
            // toolStripLabel3
            // 
            this.toolStripLabel3.AutoSize = false;
            this.toolStripLabel3.Name = "toolStripLabel3";
            this.toolStripLabel3.Size = new System.Drawing.Size(80, 22);
            this.toolStripLabel3.Text = "Data bits";
            this.toolStripLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tsDropDownButtonDataBits
            // 
            this.tsDropDownButtonDataBits.AutoSize = false;
            this.tsDropDownButtonDataBits.AutoToolTip = false;
            this.tsDropDownButtonDataBits.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsDropDownButtonDataBits.Image = ((System.Drawing.Image)(resources.GetObject("tsDropDownButtonDataBits.Image")));
            this.tsDropDownButtonDataBits.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsDropDownButtonDataBits.Name = "tsDropDownButtonDataBits";
            this.tsDropDownButtonDataBits.Size = new System.Drawing.Size(100, 22);
            this.tsDropDownButtonDataBits.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.None;
            this.toolStripButton1.Enabled = false;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton1.Text = "toolStripButton1";
            // 
            // toolStripBaudRate
            // 
            this.toolStripBaudRate.BackColor = System.Drawing.Color.White;
            this.toolStripBaudRate.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStripBaudRate.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStripBaudRate.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel2,
            this.tsDropDownButtonBaudRate,
            this.toolStripSeparator2,
            this.tsButtonBaudRateCustom});
            this.toolStripBaudRate.Location = new System.Drawing.Point(4, 32);
            this.toolStripBaudRate.Name = "toolStripBaudRate";
            this.toolStripBaudRate.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStripBaudRate.Size = new System.Drawing.Size(212, 25);
            this.toolStripBaudRate.TabIndex = 24;
            this.toolStripBaudRate.Text = "toolStrip2";
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.AutoSize = false;
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(80, 22);
            this.toolStripLabel2.Text = "Baud rate";
            this.toolStripLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tsDropDownButtonBaudRate
            // 
            this.tsDropDownButtonBaudRate.AutoSize = false;
            this.tsDropDownButtonBaudRate.AutoToolTip = false;
            this.tsDropDownButtonBaudRate.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsDropDownButtonBaudRate.Image = ((System.Drawing.Image)(resources.GetObject("tsDropDownButtonBaudRate.Image")));
            this.tsDropDownButtonBaudRate.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsDropDownButtonBaudRate.Name = "tsDropDownButtonBaudRate";
            this.tsDropDownButtonBaudRate.Size = new System.Drawing.Size(100, 22);
            this.tsDropDownButtonBaudRate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // tsButtonBaudRateCustom
            // 
            this.tsButtonBaudRateCustom.CheckOnClick = true;
            this.tsButtonBaudRateCustom.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsButtonBaudRateCustom.Image = global::ToolSuite.Properties.Resources.user_alt_1;
            this.tsButtonBaudRateCustom.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsButtonBaudRateCustom.Name = "tsButtonBaudRateCustom";
            this.tsButtonBaudRateCustom.Size = new System.Drawing.Size(23, 22);
            this.tsButtonBaudRateCustom.ToolTipText = "customize";
            this.tsButtonBaudRateCustom.Click += new System.EventHandler(this.tsButtonBaudRateCustom_Click);
            // 
            // toolStripPortName
            // 
            this.toolStripPortName.BackColor = System.Drawing.Color.White;
            this.toolStripPortName.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStripPortName.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStripPortName.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.tsDropDownButtonPort,
            this.toolStripSeparator1,
            this.tsButtonPortRefresh});
            this.toolStripPortName.Location = new System.Drawing.Point(4, 7);
            this.toolStripPortName.Name = "toolStripPortName";
            this.toolStripPortName.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStripPortName.Size = new System.Drawing.Size(212, 25);
            this.toolStripPortName.TabIndex = 23;
            this.toolStripPortName.Text = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.AutoSize = false;
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(80, 22);
            this.toolStripLabel1.Text = "Port";
            this.toolStripLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tsDropDownButtonPort
            // 
            this.tsDropDownButtonPort.AutoSize = false;
            this.tsDropDownButtonPort.AutoToolTip = false;
            this.tsDropDownButtonPort.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsDropDownButtonPort.Image = ((System.Drawing.Image)(resources.GetObject("tsDropDownButtonPort.Image")));
            this.tsDropDownButtonPort.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsDropDownButtonPort.Name = "tsDropDownButtonPort";
            this.tsDropDownButtonPort.Size = new System.Drawing.Size(100, 22);
            this.tsDropDownButtonPort.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tsDropDownButtonPort.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.tsDropDownButtonPort_DropDownItemClicked);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // tsButtonPortRefresh
            // 
            this.tsButtonPortRefresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsButtonPortRefresh.Image = global::ToolSuite.Properties.Resources.MD_reload;
            this.tsButtonPortRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsButtonPortRefresh.Name = "tsButtonPortRefresh";
            this.tsButtonPortRefresh.Size = new System.Drawing.Size(23, 22);
            this.tsButtonPortRefresh.ToolTipText = "refresh";
            this.tsButtonPortRefresh.Click += new System.EventHandler(this.tsButtonPortRefresh_Click);
            // 
            // AboutTabPage
            // 
            this.AboutTabPage.HorizontalScrollbarBarColor = true;
            this.AboutTabPage.HorizontalScrollbarHighlightOnWheel = false;
            this.AboutTabPage.HorizontalScrollbarSize = 10;
            this.AboutTabPage.Location = new System.Drawing.Point(4, 24);
            this.AboutTabPage.Name = "AboutTabPage";
            this.AboutTabPage.Size = new System.Drawing.Size(397, 354);
            this.AboutTabPage.TabIndex = 1;
            this.AboutTabPage.Text = "About";
            this.AboutTabPage.UseCustomBackColor = true;
            this.AboutTabPage.UseCustomForeColor = true;
            this.AboutTabPage.VerticalScrollbarBarColor = true;
            this.AboutTabPage.VerticalScrollbarHighlightOnWheel = false;
            this.AboutTabPage.VerticalScrollbarSize = 10;
            // 
            // btNew
            // 
            this.btNew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btNew.BorderColor = System.Drawing.Color.Black;
            this.btNew.ButtonFont = new System.Drawing.Font("Webdings", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.btNew.Checked = false;
            this.btNew.CheckedColor = System.Drawing.Color.Black;
            this.btNew.CheckedEnable = false;
            this.btNew.DisabledForeColor = System.Drawing.Color.Transparent;
            this.btNew.HoverBackColor = System.Drawing.Color.DimGray;
            this.btNew.HoverForeColor = System.Drawing.Color.White;
            this.btNew.Image = null;
            this.btNew.Location = new System.Drawing.Point(352, 2);
            this.btNew.menu = null;
            this.btNew.Name = "btNew";
            this.btNew.NormalBackColor = System.Drawing.Color.Transparent;
            this.btNew.NormalForeColor = System.Drawing.Color.DimGray;
            this.btNew.Padding = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.btNew.PressedBackColor = System.Drawing.Color.DimGray;
            this.btNew.PressedForeColor = System.Drawing.Color.Black;
            this.btNew.ShowBorder = false;
            this.btNew.ShowImage = false;
            this.btNew.Size = new System.Drawing.Size(26, 20);
            this.btNew.TabIndex = 2;
            this.btNew.Text = "~";
            this.metroToolTip.SetToolTip(this.btNew, "new");
            this.btNew.Click += new System.EventHandler(this.btNew_Click);
            // 
            // btClose
            // 
            this.btClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btClose.BorderColor = System.Drawing.Color.Black;
            this.btClose.ButtonFont = new System.Drawing.Font("Marlett", 11F);
            this.btClose.Checked = false;
            this.btClose.CheckedColor = System.Drawing.Color.Black;
            this.btClose.CheckedEnable = false;
            this.btClose.DisabledForeColor = System.Drawing.Color.Transparent;
            this.btClose.HoverBackColor = System.Drawing.Color.Red;
            this.btClose.HoverForeColor = System.Drawing.Color.White;
            this.btClose.Image = null;
            this.btClose.Location = new System.Drawing.Point(381, 2);
            this.btClose.Margin = new System.Windows.Forms.Padding(0);
            this.btClose.menu = null;
            this.btClose.Name = "btClose";
            this.btClose.NormalBackColor = System.Drawing.Color.Transparent;
            this.btClose.NormalForeColor = System.Drawing.Color.DimGray;
            this.btClose.PressedBackColor = System.Drawing.Color.Red;
            this.btClose.PressedForeColor = System.Drawing.Color.Black;
            this.btClose.ShowBorder = false;
            this.btClose.ShowImage = false;
            this.btClose.Size = new System.Drawing.Size(26, 20);
            this.btClose.TabIndex = 6;
            this.btClose.Text = "r";
            this.metroToolTip.SetToolTip(this.btClose, "close");
            this.btClose.Click += new System.EventHandler(this.btClose_Click);
            // 
            // metroToolTip
            // 
            this.metroToolTip.BackColor = System.Drawing.Color.White;
            this.metroToolTip.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            this.metroToolTip.Font = new System.Drawing.Font("SimSun", 10F);
            this.metroToolTip.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            this.metroToolTip.OwnerDraw = true;
            this.metroToolTip.ShowAlways = true;
            // 
            // ColumnCheck
            // 
            this.ColumnCheck.DividerWidth = 1;
            this.ColumnCheck.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ColumnCheck.HeaderText = "";
            this.ColumnCheck.MinimumWidth = 30;
            this.ColumnCheck.Name = "ColumnCheck";
            this.ColumnCheck.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ColumnCheck.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ColumnCheck.Width = 30;
            // 
            // ColumnText
            // 
            this.ColumnText.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnText.HeaderText = "Text";
            this.ColumnText.Name = "ColumnText";
            this.ColumnText.ReadOnly = true;
            this.ColumnText.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ColumnText.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // NewForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            this.ClientSize = new System.Drawing.Size(409, 344);
            this.Controls.Add(this.btClose);
            this.Controls.Add(this.btNew);
            this.Controls.Add(this.toolSettingTabControl);
            this.HeaderColor = System.Drawing.Color.White;
            this.HeaderImagePadding = new System.Windows.Forms.Padding(5, 3, 0, 5);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "NewForm";
            this.Padding = new System.Windows.Forms.Padding(2, 25, 2, 2);
            this.Resizable = false;
            this.ShadowType = MetroFramework.Forms.MetroFormShadowType.None;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Title = "New";
            this.TitleColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            this.TitleFont = new System.Drawing.Font("STLiti", 11F, System.Drawing.FontStyle.Bold);
            this.TitlePadding = new System.Windows.Forms.Padding(4, 4, 0, 0);
            this.Load += new System.EventHandler(this.NewForm_Load);
            this.toolSettingTabControl.ResumeLayout(false);
            this.SerialPortTabPage.ResumeLayout(false);
            this.SerialPortTabPage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.synaxHighLightGrid)).EndInit();
            this.contextMenuStrip.ResumeLayout(false);
            this.toolStripParity.ResumeLayout(false);
            this.toolStripParity.PerformLayout();
            this.toolStripStopBits.ResumeLayout(false);
            this.toolStripStopBits.PerformLayout();
            this.toolStripDataBits.ResumeLayout(false);
            this.toolStripDataBits.PerformLayout();
            this.toolStripBaudRate.ResumeLayout(false);
            this.toolStripBaudRate.PerformLayout();
            this.toolStripPortName.ResumeLayout(false);
            this.toolStripPortName.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroTabControl toolSettingTabControl;
        private MetroFramework.Controls.MetroTabPage SerialPortTabPage;
        private MetroFramework.Controls.MetroTabPage AboutTabPage;
        private System.Windows.Forms.ToolStrip toolStripPortName;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripDropDownButton tsDropDownButtonPort;
        private System.Windows.Forms.ToolStrip toolStripParity;
        private System.Windows.Forms.ToolStripLabel toolStripLabel5;
        private System.Windows.Forms.ToolStripDropDownButton tsDropDownButtonParity;
        private System.Windows.Forms.ToolStrip toolStripStopBits;
        private System.Windows.Forms.ToolStripLabel toolStripLabel4;
        private System.Windows.Forms.ToolStripDropDownButton tsDropDownButtonStopBits;
        private System.Windows.Forms.ToolStrip toolStripDataBits;
        private System.Windows.Forms.ToolStripLabel toolStripLabel3;
        private System.Windows.Forms.ToolStripDropDownButton tsDropDownButtonDataBits;
        private System.Windows.Forms.ToolStrip toolStripBaudRate;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripDropDownButton tsDropDownButtonBaudRate;
        private System.Windows.Forms.ToolStripButton tsButtonPortRefresh;
        private System.Windows.Forms.ToolStripButton tsButtonBaudRateCustom;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private ControlsLibrary.MetroMenuButton btNew;
        private ControlsLibrary.MetroMenuButton btClose;
        private ControlLibrary.MetroToolTip metroToolTip;
        private ControlLibrary.MetroTip staticToolTip;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem reloadToolStripMenuItem;
        private ControlLibrary.MetroGrid synaxHighLightGrid;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColumnCheck;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnText;
    }
}