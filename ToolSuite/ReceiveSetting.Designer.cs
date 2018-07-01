namespace ToolSuite
{
    partial class ReceiveSetting
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btClose = new FastColoredTextBoxNS.MetroMenuButton();
            this.metroTabControl1 = new MetroFramework.Controls.MetroTabControl();
            this.syntaxHighLight = new MetroFramework.Controls.MetroTabPage();
            this.btUpload = new ControlsLibrary.MetroMenuButton();
            this.cbStrikeout = new ControlsLibrary.MetroCheckBox();
            this.cbUnderline = new ControlsLibrary.MetroCheckBox();
            this.cbItalic = new ControlsLibrary.MetroCheckBox();
            this.cbBold = new ControlsLibrary.MetroCheckBox();
            this.btBackColor = new ControlsLibrary.MetroMenuButton();
            this.syntaxSample = new System.Windows.Forms.Label();
            this.btModify = new ControlsLibrary.MetroMenuButton();
            this.btDel = new ControlsLibrary.MetroMenuButton();
            this.btAdd = new ControlsLibrary.MetroMenuButton();
            this.syntaxTextBox = new MetroFramework.Controls.MetroTextBox();
            this.btFontColor = new ControlsLibrary.MetroMenuButton();
            this.HighLightList = new MetroFramework.Controls.MetroGrid();
            this.Select = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Collection = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Sample = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btOK = new FastColoredTextBoxNS.MetroMenuButton();
            this.metroTabControl1.SuspendLayout();
            this.syntaxHighLight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.HighLightList)).BeginInit();
            this.SuspendLayout();
            // 
            // btClose
            // 
            this.btClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btClose.BorderColor = System.Drawing.Color.Black;
            this.btClose.ButtonFont = new System.Drawing.Font("Marlett", 12F);
            this.btClose.Checked = false;
            this.btClose.CheckedColor = System.Drawing.Color.Black;
            this.btClose.CheckedEnable = false;
            this.btClose.DisabledForeColor = System.Drawing.Color.Black;
            this.btClose.HoverBackColor = System.Drawing.Color.Transparent;
            this.btClose.HoverForeColor = System.Drawing.Color.Crimson;
            this.btClose.Image = null;
            this.btClose.Location = new System.Drawing.Point(408, 2);
            this.btClose.menu = null;
            this.btClose.Name = "btClose";
            this.btClose.NormalForeColor = System.Drawing.Color.DarkGray;
            this.btClose.Padding = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.btClose.PressedForeColor = System.Drawing.Color.DarkRed;
            this.btClose.ShowBorder = false;
            this.btClose.Size = new System.Drawing.Size(27, 20);
            this.btClose.TabIndex = 4;
            this.btClose.Text = "r";
            this.btClose.Click += new System.EventHandler(this.btClose_Click);
            // 
            // metroTabControl1
            // 
            this.metroTabControl1.Controls.Add(this.syntaxHighLight);
            this.metroTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.metroTabControl1.ItemSize = new System.Drawing.Size(102, 20);
            this.metroTabControl1.Location = new System.Drawing.Point(2, 22);
            this.metroTabControl1.Name = "metroTabControl1";
            this.metroTabControl1.SelectedIndex = 0;
            this.metroTabControl1.Size = new System.Drawing.Size(433, 334);
            this.metroTabControl1.Speed = 20;
            this.metroTabControl1.TabIndex = 7;
            this.metroTabControl1.TabSelectedColor = System.Drawing.Color.Black;
            this.metroTabControl1.UseAnimation = true;
            this.metroTabControl1.UseCustomTabSelectedColor = false;
            this.metroTabControl1.UseSelectable = true;
            // 
            // syntaxHighLight
            // 
            this.syntaxHighLight.Controls.Add(this.btUpload);
            this.syntaxHighLight.Controls.Add(this.cbStrikeout);
            this.syntaxHighLight.Controls.Add(this.cbUnderline);
            this.syntaxHighLight.Controls.Add(this.cbItalic);
            this.syntaxHighLight.Controls.Add(this.cbBold);
            this.syntaxHighLight.Controls.Add(this.btBackColor);
            this.syntaxHighLight.Controls.Add(this.syntaxSample);
            this.syntaxHighLight.Controls.Add(this.btModify);
            this.syntaxHighLight.Controls.Add(this.btDel);
            this.syntaxHighLight.Controls.Add(this.btAdd);
            this.syntaxHighLight.Controls.Add(this.syntaxTextBox);
            this.syntaxHighLight.Controls.Add(this.btFontColor);
            this.syntaxHighLight.Controls.Add(this.HighLightList);
            this.syntaxHighLight.HorizontalScrollbarBarColor = true;
            this.syntaxHighLight.HorizontalScrollbarHighlightOnWheel = false;
            this.syntaxHighLight.HorizontalScrollbarSize = 10;
            this.syntaxHighLight.Location = new System.Drawing.Point(4, 24);
            this.syntaxHighLight.Name = "syntaxHighLight";
            this.syntaxHighLight.Size = new System.Drawing.Size(425, 306);
            this.syntaxHighLight.TabIndex = 0;
            this.syntaxHighLight.Text = "HighLight";
            this.syntaxHighLight.VerticalScrollbarBarColor = true;
            this.syntaxHighLight.VerticalScrollbarHighlightOnWheel = false;
            this.syntaxHighLight.VerticalScrollbarSize = 10;
            // 
            // btUpload
            // 
            this.btUpload.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btUpload.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            this.btUpload.ButtonFont = new System.Drawing.Font("SimSun", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btUpload.Checked = false;
            this.btUpload.CheckedColor = System.Drawing.Color.Black;
            this.btUpload.CheckedEnable = false;
            this.btUpload.DisabledForeColor = System.Drawing.Color.Transparent;
            this.btUpload.HoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(150)))), ((int)(((byte)(200)))));
            this.btUpload.HoverForeColor = System.Drawing.Color.White;
            this.btUpload.Image = null;
            this.btUpload.Location = new System.Drawing.Point(350, 162);
            this.btUpload.menu = null;
            this.btUpload.Name = "btUpload";
            this.btUpload.NormalBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            this.btUpload.NormalForeColor = System.Drawing.Color.DimGray;
            this.btUpload.PressedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.btUpload.PressedForeColor = System.Drawing.Color.White;
            this.btUpload.ShowBorder = false;
            this.btUpload.ShowImage = true;
            this.btUpload.Size = new System.Drawing.Size(70, 20);
            this.btUpload.TabIndex = 29;
            this.btUpload.Text = "Upload";
            this.btUpload.Click += new System.EventHandler(this.btUpload_Click);
            // 
            // cbStrikeout
            // 
            this.cbStrikeout.AutoSize = true;
            this.cbStrikeout.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            this.cbStrikeout.CheckBoxPadding = new System.Windows.Forms.Padding(0);
            this.cbStrikeout.CheckedColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            this.cbStrikeout.DisabledColor = System.Drawing.Color.Gray;
            this.cbStrikeout.ForeColor = System.Drawing.Color.DimGray;
            this.cbStrikeout.HoveredBorderColor = System.Drawing.Color.Black;
            this.cbStrikeout.Location = new System.Drawing.Point(209, 265);
            this.cbStrikeout.Name = "cbStrikeout";
            this.cbStrikeout.PressedBorderColor = System.Drawing.Color.Black;
            this.cbStrikeout.Size = new System.Drawing.Size(78, 16);
            this.cbStrikeout.TabIndex = 28;
            this.cbStrikeout.Text = "Strikeout";
            this.cbStrikeout.CheckedChanged += new System.EventHandler(this.FontStyle_CheckedChanged);
            // 
            // cbUnderline
            // 
            this.cbUnderline.AutoSize = true;
            this.cbUnderline.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            this.cbUnderline.CheckBoxPadding = new System.Windows.Forms.Padding(0);
            this.cbUnderline.CheckedColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            this.cbUnderline.DisabledColor = System.Drawing.Color.Gray;
            this.cbUnderline.ForeColor = System.Drawing.Color.DimGray;
            this.cbUnderline.HoveredBorderColor = System.Drawing.Color.Black;
            this.cbUnderline.Location = new System.Drawing.Point(125, 265);
            this.cbUnderline.Name = "cbUnderline";
            this.cbUnderline.PressedBorderColor = System.Drawing.Color.Black;
            this.cbUnderline.Size = new System.Drawing.Size(78, 16);
            this.cbUnderline.TabIndex = 27;
            this.cbUnderline.Text = "Underline";
            this.cbUnderline.CheckedChanged += new System.EventHandler(this.FontStyle_CheckedChanged);
            // 
            // cbItalic
            // 
            this.cbItalic.AutoSize = true;
            this.cbItalic.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            this.cbItalic.CheckBoxPadding = new System.Windows.Forms.Padding(0);
            this.cbItalic.CheckedColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            this.cbItalic.DisabledColor = System.Drawing.Color.Gray;
            this.cbItalic.ForeColor = System.Drawing.Color.DimGray;
            this.cbItalic.HoveredBorderColor = System.Drawing.Color.Black;
            this.cbItalic.Location = new System.Drawing.Point(59, 265);
            this.cbItalic.Name = "cbItalic";
            this.cbItalic.PressedBorderColor = System.Drawing.Color.Black;
            this.cbItalic.Size = new System.Drawing.Size(60, 16);
            this.cbItalic.TabIndex = 26;
            this.cbItalic.Text = "Italic";
            this.cbItalic.CheckedChanged += new System.EventHandler(this.FontStyle_CheckedChanged);
            // 
            // cbBold
            // 
            this.cbBold.AutoSize = true;
            this.cbBold.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            this.cbBold.CheckBoxPadding = new System.Windows.Forms.Padding(0);
            this.cbBold.CheckedColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            this.cbBold.DisabledColor = System.Drawing.Color.Gray;
            this.cbBold.ForeColor = System.Drawing.Color.DimGray;
            this.cbBold.HoveredBorderColor = System.Drawing.Color.Black;
            this.cbBold.Location = new System.Drawing.Point(5, 265);
            this.cbBold.Name = "cbBold";
            this.cbBold.PressedBorderColor = System.Drawing.Color.Black;
            this.cbBold.Size = new System.Drawing.Size(48, 16);
            this.cbBold.TabIndex = 25;
            this.cbBold.Text = "Bold";
            this.cbBold.CheckedChanged += new System.EventHandler(this.FontStyle_CheckedChanged);
            // 
            // btBackColor
            // 
            this.btBackColor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btBackColor.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            this.btBackColor.ButtonFont = new System.Drawing.Font("SimSun", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btBackColor.Checked = false;
            this.btBackColor.CheckedColor = System.Drawing.Color.Black;
            this.btBackColor.CheckedEnable = false;
            this.btBackColor.DisabledForeColor = System.Drawing.Color.Transparent;
            this.btBackColor.HoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(150)))), ((int)(((byte)(200)))));
            this.btBackColor.HoverForeColor = System.Drawing.Color.White;
            this.btBackColor.Image = null;
            this.btBackColor.Location = new System.Drawing.Point(341, 236);
            this.btBackColor.menu = null;
            this.btBackColor.Name = "btBackColor";
            this.btBackColor.NormalBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            this.btBackColor.NormalForeColor = System.Drawing.Color.DimGray;
            this.btBackColor.PressedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.btBackColor.PressedForeColor = System.Drawing.Color.White;
            this.btBackColor.ShowBorder = false;
            this.btBackColor.ShowImage = true;
            this.btBackColor.Size = new System.Drawing.Size(81, 20);
            this.btBackColor.TabIndex = 23;
            this.btBackColor.Text = "Back Color";
            this.btBackColor.Click += new System.EventHandler(this.btColor_Click);
            // 
            // syntaxSample
            // 
            this.syntaxSample.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            this.syntaxSample.Font = new System.Drawing.Font("SimSun", 10F);
            this.syntaxSample.ForeColor = System.Drawing.Color.White;
            this.syntaxSample.Location = new System.Drawing.Point(5, 240);
            this.syntaxSample.Name = "syntaxSample";
            this.syntaxSample.Size = new System.Drawing.Size(60, 16);
            this.syntaxSample.TabIndex = 22;
            this.syntaxSample.Text = "Sample";
            this.syntaxSample.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btModify
            // 
            this.btModify.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btModify.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            this.btModify.ButtonFont = new System.Drawing.Font("SimSun", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btModify.Checked = false;
            this.btModify.CheckedColor = System.Drawing.Color.Black;
            this.btModify.CheckedEnable = false;
            this.btModify.DisabledForeColor = System.Drawing.Color.Transparent;
            this.btModify.HoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(150)))), ((int)(((byte)(200)))));
            this.btModify.HoverForeColor = System.Drawing.Color.White;
            this.btModify.Image = null;
            this.btModify.Location = new System.Drawing.Point(275, 162);
            this.btModify.menu = null;
            this.btModify.Name = "btModify";
            this.btModify.NormalBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            this.btModify.NormalForeColor = System.Drawing.Color.DimGray;
            this.btModify.PressedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.btModify.PressedForeColor = System.Drawing.Color.White;
            this.btModify.ShowBorder = false;
            this.btModify.ShowImage = true;
            this.btModify.Size = new System.Drawing.Size(70, 20);
            this.btModify.TabIndex = 21;
            this.btModify.Text = "Modify";
            this.btModify.Click += new System.EventHandler(this.btModify_Click);
            // 
            // btDel
            // 
            this.btDel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btDel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            this.btDel.ButtonFont = new System.Drawing.Font("SimSun", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btDel.Checked = false;
            this.btDel.CheckedColor = System.Drawing.Color.Black;
            this.btDel.CheckedEnable = false;
            this.btDel.DisabledForeColor = System.Drawing.Color.Transparent;
            this.btDel.HoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(150)))), ((int)(((byte)(200)))));
            this.btDel.HoverForeColor = System.Drawing.Color.White;
            this.btDel.Image = null;
            this.btDel.Location = new System.Drawing.Point(200, 162);
            this.btDel.menu = null;
            this.btDel.Name = "btDel";
            this.btDel.NormalBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            this.btDel.NormalForeColor = System.Drawing.Color.DimGray;
            this.btDel.PressedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.btDel.PressedForeColor = System.Drawing.Color.White;
            this.btDel.ShowBorder = false;
            this.btDel.ShowImage = true;
            this.btDel.Size = new System.Drawing.Size(70, 20);
            this.btDel.TabIndex = 20;
            this.btDel.Text = "Del";
            this.btDel.Click += new System.EventHandler(this.btDel_Click);
            // 
            // btAdd
            // 
            this.btAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btAdd.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            this.btAdd.ButtonFont = new System.Drawing.Font("SimSun", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btAdd.Checked = false;
            this.btAdd.CheckedColor = System.Drawing.Color.Black;
            this.btAdd.CheckedEnable = false;
            this.btAdd.DisabledForeColor = System.Drawing.Color.Transparent;
            this.btAdd.HoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(150)))), ((int)(((byte)(200)))));
            this.btAdd.HoverForeColor = System.Drawing.Color.White;
            this.btAdd.Image = null;
            this.btAdd.Location = new System.Drawing.Point(125, 162);
            this.btAdd.menu = null;
            this.btAdd.Name = "btAdd";
            this.btAdd.NormalBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            this.btAdd.NormalForeColor = System.Drawing.Color.DimGray;
            this.btAdd.PressedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.btAdd.PressedForeColor = System.Drawing.Color.White;
            this.btAdd.ShowBorder = false;
            this.btAdd.ShowImage = true;
            this.btAdd.Size = new System.Drawing.Size(70, 20);
            this.btAdd.TabIndex = 19;
            this.btAdd.Text = "Add";
            this.btAdd.Click += new System.EventHandler(this.btAdd_Click);
            // 
            // syntaxTextBox
            // 
            this.syntaxTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.syntaxTextBox.CustomButton.Image = null;
            this.syntaxTextBox.CustomButton.Location = new System.Drawing.Point(396, 1);
            this.syntaxTextBox.CustomButton.Name = "";
            this.syntaxTextBox.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.syntaxTextBox.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.syntaxTextBox.CustomButton.TabIndex = 1;
            this.syntaxTextBox.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.syntaxTextBox.CustomButton.UseSelectable = true;
            this.syntaxTextBox.CustomButton.Visible = false;
            this.syntaxTextBox.Lines = new string[0];
            this.syntaxTextBox.Location = new System.Drawing.Point(4, 207);
            this.syntaxTextBox.MaxLength = 32767;
            this.syntaxTextBox.Name = "syntaxTextBox";
            this.syntaxTextBox.PasswordChar = '\0';
            this.syntaxTextBox.PromptText = "syntax...";
            this.syntaxTextBox.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.syntaxTextBox.SelectedText = "";
            this.syntaxTextBox.SelectionLength = 0;
            this.syntaxTextBox.SelectionStart = 0;
            this.syntaxTextBox.ShortcutsEnabled = true;
            this.syntaxTextBox.Size = new System.Drawing.Size(418, 23);
            this.syntaxTextBox.TabIndex = 18;
            this.syntaxTextBox.UseSelectable = true;
            this.syntaxTextBox.WaterMark = "syntax...";
            this.syntaxTextBox.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.syntaxTextBox.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // btFontColor
            // 
            this.btFontColor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btFontColor.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            this.btFontColor.ButtonFont = new System.Drawing.Font("SimSun", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btFontColor.Checked = false;
            this.btFontColor.CheckedColor = System.Drawing.Color.Black;
            this.btFontColor.CheckedEnable = false;
            this.btFontColor.DisabledForeColor = System.Drawing.Color.Transparent;
            this.btFontColor.HoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(150)))), ((int)(((byte)(200)))));
            this.btFontColor.HoverForeColor = System.Drawing.Color.White;
            this.btFontColor.Image = null;
            this.btFontColor.Location = new System.Drawing.Point(254, 236);
            this.btFontColor.menu = null;
            this.btFontColor.Name = "btFontColor";
            this.btFontColor.NormalBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            this.btFontColor.NormalForeColor = System.Drawing.Color.DimGray;
            this.btFontColor.PressedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.btFontColor.PressedForeColor = System.Drawing.Color.White;
            this.btFontColor.ShowBorder = false;
            this.btFontColor.ShowImage = true;
            this.btFontColor.Size = new System.Drawing.Size(81, 20);
            this.btFontColor.TabIndex = 17;
            this.btFontColor.Text = "Font Color";
            this.btFontColor.Click += new System.EventHandler(this.btColor_Click);
            // 
            // HighLightList
            // 
            this.HighLightList.AllowUserToAddRows = false;
            this.HighLightList.AllowUserToDeleteRows = false;
            this.HighLightList.AllowUserToOrderColumns = true;
            this.HighLightList.AllowUserToResizeRows = false;
            this.HighLightList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.HighLightList.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.HighLightList.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            this.HighLightList.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.HighLightList.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            this.HighLightList.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.HighLightList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.HighLightList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.HighLightList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Select,
            this.Collection,
            this.Sample});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(136)))), ((int)(((byte)(136)))));
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.HighLightList.DefaultCellStyle = dataGridViewCellStyle4;
            this.HighLightList.EnableHeadersVisualStyles = false;
            this.HighLightList.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.HighLightList.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.HighLightList.Location = new System.Drawing.Point(3, 3);
            this.HighLightList.MultiSelect = false;
            this.HighLightList.Name = "HighLightList";
            this.HighLightList.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.HighLightList.RowHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.HighLightList.RowHeadersVisible = false;
            this.HighLightList.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.HighLightList.RowTemplate.Height = 23;
            this.HighLightList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.HighLightList.Size = new System.Drawing.Size(419, 153);
            this.HighLightList.TabIndex = 11;
            this.HighLightList.SelectionChanged += new System.EventHandler(this.HighLightList_SelectionChanged);
            // 
            // Select
            // 
            this.Select.DividerWidth = 1;
            this.Select.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Select.Frozen = true;
            this.Select.HeaderText = "";
            this.Select.MinimumWidth = 30;
            this.Select.Name = "Select";
            this.Select.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Select.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Select.Width = 30;
            // 
            // Collection
            // 
            this.Collection.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.Collection.DefaultCellStyle = dataGridViewCellStyle2;
            this.Collection.DividerWidth = 1;
            this.Collection.FillWeight = 123.5669F;
            this.Collection.HeaderText = "Syntax";
            this.Collection.Name = "Collection";
            this.Collection.ReadOnly = true;
            this.Collection.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // Sample
            // 
            this.Sample.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Sample.DefaultCellStyle = dataGridViewCellStyle3;
            this.Sample.HeaderText = "Preview";
            this.Sample.MinimumWidth = 50;
            this.Sample.Name = "Sample";
            this.Sample.ReadOnly = true;
            this.Sample.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Sample.Width = 69;
            // 
            // btOK
            // 
            this.btOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btOK.BorderColor = System.Drawing.Color.Black;
            this.btOK.ButtonFont = new System.Drawing.Font("Marlett", 12F);
            this.btOK.Checked = false;
            this.btOK.CheckedColor = System.Drawing.Color.Black;
            this.btOK.CheckedEnable = false;
            this.btOK.DisabledForeColor = System.Drawing.Color.Black;
            this.btOK.HoverBackColor = System.Drawing.Color.Transparent;
            this.btOK.HoverForeColor = System.Drawing.Color.Crimson;
            this.btOK.Image = null;
            this.btOK.Location = new System.Drawing.Point(375, 2);
            this.btOK.menu = null;
            this.btOK.Name = "btOK";
            this.btOK.NormalForeColor = System.Drawing.Color.DarkGray;
            this.btOK.Padding = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.btOK.PressedForeColor = System.Drawing.Color.DarkRed;
            this.btOK.ShowBorder = false;
            this.btOK.Size = new System.Drawing.Size(27, 20);
            this.btOK.TabIndex = 10;
            this.btOK.Text = "b";
            this.btOK.Click += new System.EventHandler(this.btOK_Click);
            // 
            // ReceiveSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            this.ClientSize = new System.Drawing.Size(437, 358);
            this.Controls.Add(this.btOK);
            this.Controls.Add(this.metroTabControl1);
            this.Controls.Add(this.btClose);
            this.HeaderColor = System.Drawing.Color.White;
            this.Name = "ReceiveSetting";
            this.Padding = new System.Windows.Forms.Padding(2, 22, 2, 2);
            this.Resizable = false;
            this.ShadowType = MetroFramework.Forms.MetroFormShadowType.None;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "ReceiveSetting";
            this.Load += new System.EventHandler(this.ReceiveSettingForm_Load);
            this.metroTabControl1.ResumeLayout(false);
            this.syntaxHighLight.ResumeLayout(false);
            this.syntaxHighLight.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.HighLightList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private FastColoredTextBoxNS.MetroMenuButton btClose;
        private MetroFramework.Controls.MetroTabControl metroTabControl1;
        private MetroFramework.Controls.MetroTabPage syntaxHighLight;
        private MetroFramework.Controls.MetroGrid HighLightList;
        private FastColoredTextBoxNS.MetroMenuButton btOK;
        private ControlsLibrary.MetroMenuButton btFontColor;
        private ControlsLibrary.MetroMenuButton btModify;
        private ControlsLibrary.MetroMenuButton btDel;
        private ControlsLibrary.MetroMenuButton btAdd;
        private MetroFramework.Controls.MetroTextBox syntaxTextBox;
        private System.Windows.Forms.Label syntaxSample;
        private ControlsLibrary.MetroMenuButton btBackColor;
        private ControlsLibrary.MetroCheckBox cbStrikeout;
        private ControlsLibrary.MetroCheckBox cbUnderline;
        private ControlsLibrary.MetroCheckBox cbItalic;
        private ControlsLibrary.MetroCheckBox cbBold;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Select;
        private System.Windows.Forms.DataGridViewTextBoxColumn Collection;
        private System.Windows.Forms.DataGridViewTextBoxColumn Sample;
        private ControlsLibrary.MetroMenuButton btUpload;
    }
}