namespace FastColoredTextBoxNS
{
    partial class ReplaceForm
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
            this.btClose = new FastColoredTextBoxNS.MetroMenuButton();
            this.tbFind = new FastColoredTextBoxNS.MetroTextBox();
            this.tbReplace = new FastColoredTextBoxNS.MetroTextBox();
            this.btShowReplace = new FastColoredTextBoxNS.MetroMenuButton();
            this.cbWholeWord = new FastColoredTextBoxNS.MetroCheckBox();
            this.cbRegex = new FastColoredTextBoxNS.MetroCheckBox();
            this.cbMatchCase = new FastColoredTextBoxNS.MetroCheckBox();
            this.btReplaceAll = new FastColoredTextBoxNS.MetroMenuButton();
            this.btReplace = new FastColoredTextBoxNS.MetroMenuButton();
            this.btFindPrevious = new FastColoredTextBoxNS.MetroMenuButton();
            this.btFindNext = new FastColoredTextBoxNS.MetroMenuButton();
            this.labelInfo = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btClose
            // 
            this.btClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btClose.BorderColor = System.Drawing.Color.Black;
            this.btClose.ButtonFont = new System.Drawing.Font("Marlett", 10F);
            this.btClose.Checked = false;
            this.btClose.CheckedColor = System.Drawing.Color.Maroon;
            this.btClose.CheckedEnable = false;
            this.btClose.DisabledForeColor = System.Drawing.Color.Transparent;
            this.btClose.HoverBackColor = System.Drawing.Color.Transparent;
            this.btClose.HoverForeColor = System.Drawing.Color.Red;
            this.btClose.Image = null;
            this.btClose.Location = new System.Drawing.Point(203, 6);
            this.btClose.menu = null;
            this.btClose.Name = "btClose";
            this.btClose.NormalForeColor = System.Drawing.Color.LightGray;
            this.btClose.PressedForeColor = System.Drawing.Color.DarkRed;
            this.btClose.ShowBorder = false;
            this.btClose.Size = new System.Drawing.Size(19, 19);
            this.btClose.TabIndex = 21;
            this.btClose.Text = "r";
            this.btClose.Click += new System.EventHandler(this.btClose_Click);
            // 
            // tbFind
            // 
            this.tbFind.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbFind.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            // 
            // 
            // 
            this.tbFind.CustomButton.ButtonFont = new System.Drawing.Font("Marlett", 8F);
            this.tbFind.CustomButton.HoveredBackColor = System.Drawing.Color.Transparent;
            this.tbFind.CustomButton.HoveredForeColor = System.Drawing.Color.Silver;
            this.tbFind.CustomButton.Image = null;
            this.tbFind.CustomButton.Location = new System.Drawing.Point(132, 1);
            this.tbFind.CustomButton.Name = "";
            this.tbFind.CustomButton.NormalBackColor = System.Drawing.Color.White;
            this.tbFind.CustomButton.PressedBackColor = System.Drawing.Color.Transparent;
            this.tbFind.CustomButton.PressedForeColor = System.Drawing.Color.DimGray;
            this.tbFind.CustomButton.Size = new System.Drawing.Size(17, 17);
            this.tbFind.CustomButton.TabIndex = 1;
            this.tbFind.CustomButton.Text = "r";
            this.tbFind.CustomButton.Visible = false;
            this.tbFind.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbFind.Lines = new string[0];
            this.tbFind.Location = new System.Drawing.Point(13, 6);
            this.tbFind.MaxLength = 32767;
            this.tbFind.Name = "tbFind";
            this.tbFind.PasswordChar = '\0';
            this.tbFind.PromptText = "search...";
            this.tbFind.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.tbFind.SelectedText = "";
            this.tbFind.SelectionLength = 0;
            this.tbFind.SelectionStart = 0;
            this.tbFind.ShortcutsEnabled = true;
            this.tbFind.ShowClearButton = true;
            this.tbFind.Size = new System.Drawing.Size(150, 19);
            this.tbFind.TabIndex = 25;
            this.tbFind.TextFont = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbFind.WaterMark = "search...";
            this.tbFind.WaterMarkColor = System.Drawing.Color.LightGray;
            this.tbFind.ButtonClick += new FastColoredTextBoxNS.MetroTextBox.ButClick(this.btFindNext_Click);
            // 
            // tbReplace
            // 
            this.tbReplace.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbReplace.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            // 
            // 
            // 
            this.tbReplace.CustomButton.ButtonFont = new System.Drawing.Font("SimSun", 9F);
            this.tbReplace.CustomButton.HoveredBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(240)))));
            this.tbReplace.CustomButton.HoveredForeColor = System.Drawing.Color.White;
            this.tbReplace.CustomButton.Image = global::FastColoredTextBoxNS.Properties.Resources.zoom;
            this.tbReplace.CustomButton.Location = new System.Drawing.Point(132, 1);
            this.tbReplace.CustomButton.Name = "";
            this.tbReplace.CustomButton.NormalBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(217)))));
            this.tbReplace.CustomButton.PressedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(190)))), ((int)(((byte)(240)))));
            this.tbReplace.CustomButton.PressedForeColor = System.Drawing.Color.White;
            this.tbReplace.CustomButton.Size = new System.Drawing.Size(17, 17);
            this.tbReplace.CustomButton.TabIndex = 1;
            this.tbReplace.CustomButton.Visible = false;
            this.tbReplace.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbReplace.Lines = new string[0];
            this.tbReplace.Location = new System.Drawing.Point(13, 28);
            this.tbReplace.MaxLength = 32767;
            this.tbReplace.Name = "tbReplace";
            this.tbReplace.PasswordChar = '\0';
            this.tbReplace.PromptText = "replace...";
            this.tbReplace.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.tbReplace.SelectedText = "";
            this.tbReplace.SelectionLength = 0;
            this.tbReplace.SelectionStart = 0;
            this.tbReplace.ShortcutsEnabled = true;
            this.tbReplace.ShowClearButton = true;
            this.tbReplace.Size = new System.Drawing.Size(150, 19);
            this.tbReplace.TabIndex = 26;
            this.tbReplace.TextFont = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbReplace.WaterMark = "replace...";
            this.tbReplace.WaterMarkColor = System.Drawing.Color.LightGray;
            this.tbReplace.ButtonClick += new FastColoredTextBoxNS.MetroTextBox.ButClick(this.btReplace_Click);
            // 
            // btShowReplace
            // 
            this.btShowReplace.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btShowReplace.BorderColor = System.Drawing.Color.Black;
            this.btShowReplace.ButtonFont = new System.Drawing.Font("Marlett", 10F);
            this.btShowReplace.Checked = false;
            this.btShowReplace.CheckedColor = System.Drawing.Color.Maroon;
            this.btShowReplace.CheckedEnable = false;
            this.btShowReplace.DisabledForeColor = System.Drawing.Color.Transparent;
            this.btShowReplace.HoverBackColor = System.Drawing.Color.Transparent;
            this.btShowReplace.HoverForeColor = System.Drawing.Color.Black;
            this.btShowReplace.Image = null;
            this.btShowReplace.Location = new System.Drawing.Point(3, 7);
            this.btShowReplace.menu = null;
            this.btShowReplace.Name = "btShowReplace";
            this.btShowReplace.NormalForeColor = System.Drawing.Color.DimGray;
            this.btShowReplace.Padding = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.btShowReplace.PressedForeColor = System.Drawing.Color.DarkGray;
            this.btShowReplace.ShowBorder = false;
            this.btShowReplace.Size = new System.Drawing.Size(8, 16);
            this.btShowReplace.TabIndex = 27;
            this.btShowReplace.Text = "6";
            this.btShowReplace.Click += new System.EventHandler(this.btShowReplace_Click);
            // 
            // cbWholeWord
            // 
            this.cbWholeWord.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cbWholeWord.AutoSize = true;
            this.cbWholeWord.BorderColor = System.Drawing.Color.DimGray;
            this.cbWholeWord.CheckBoxPadding = new System.Windows.Forms.Padding(0);
            this.cbWholeWord.CheckedColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            this.cbWholeWord.DisabledColor = System.Drawing.Color.Gray;
            this.cbWholeWord.ForeColor = System.Drawing.Color.DimGray;
            this.cbWholeWord.HoveredBorderColor = System.Drawing.Color.Black;
            this.cbWholeWord.Location = new System.Drawing.Point(98, 50);
            this.cbWholeWord.Name = "cbWholeWord";
            this.cbWholeWord.PressedBorderColor = System.Drawing.Color.Black;
            this.cbWholeWord.Size = new System.Drawing.Size(48, 16);
            this.cbWholeWord.TabIndex = 35;
            this.cbWholeWord.Text = "|Aa|";
            // 
            // cbRegex
            // 
            this.cbRegex.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cbRegex.AutoSize = true;
            this.cbRegex.BorderColor = System.Drawing.Color.DimGray;
            this.cbRegex.CheckBoxPadding = new System.Windows.Forms.Padding(0);
            this.cbRegex.CheckedColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            this.cbRegex.DisabledColor = System.Drawing.Color.Gray;
            this.cbRegex.ForeColor = System.Drawing.Color.DimGray;
            this.cbRegex.HoveredBorderColor = System.Drawing.Color.Black;
            this.cbRegex.Location = new System.Drawing.Point(53, 50);
            this.cbRegex.Name = "cbRegex";
            this.cbRegex.PressedBorderColor = System.Drawing.Color.Black;
            this.cbRegex.Size = new System.Drawing.Size(42, 16);
            this.cbRegex.TabIndex = 36;
            this.cbRegex.Text = "[*]";
            // 
            // cbMatchCase
            // 
            this.cbMatchCase.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cbMatchCase.AutoSize = true;
            this.cbMatchCase.BorderColor = System.Drawing.Color.DimGray;
            this.cbMatchCase.CheckBoxPadding = new System.Windows.Forms.Padding(0);
            this.cbMatchCase.CheckedColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            this.cbMatchCase.DisabledColor = System.Drawing.Color.Gray;
            this.cbMatchCase.ForeColor = System.Drawing.Color.DimGray;
            this.cbMatchCase.HoveredBorderColor = System.Drawing.Color.Black;
            this.cbMatchCase.Location = new System.Drawing.Point(14, 50);
            this.cbMatchCase.Name = "cbMatchCase";
            this.cbMatchCase.PressedBorderColor = System.Drawing.Color.Black;
            this.cbMatchCase.Size = new System.Drawing.Size(36, 16);
            this.cbMatchCase.TabIndex = 37;
            this.cbMatchCase.Text = "Aa";
            this.cbMatchCase.CheckedChanged += new System.EventHandler(this.cbMatchCase_CheckedChanged);
            // 
            // btReplaceAll
            // 
            this.btReplaceAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btReplaceAll.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            this.btReplaceAll.ButtonFont = new System.Drawing.Font("Marlett", 12F);
            this.btReplaceAll.Checked = false;
            this.btReplaceAll.CheckedColor = System.Drawing.Color.Black;
            this.btReplaceAll.CheckedEnable = false;
            this.btReplaceAll.DisabledForeColor = System.Drawing.Color.Transparent;
            this.btReplaceAll.HoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            this.btReplaceAll.HoverForeColor = System.Drawing.Color.White;
            this.btReplaceAll.Image = global::FastColoredTextBoxNS.Properties.Resources.edit_family_16px;
            this.btReplaceAll.Location = new System.Drawing.Point(182, 28);
            this.btReplaceAll.menu = null;
            this.btReplaceAll.Name = "btReplaceAll";
            this.btReplaceAll.NormalForeColor = System.Drawing.Color.Black;
            this.btReplaceAll.Padding = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.btReplaceAll.PressedForeColor = System.Drawing.Color.Black;
            this.btReplaceAll.ShowBorder = true;
            this.btReplaceAll.Size = new System.Drawing.Size(19, 19);
            this.btReplaceAll.TabIndex = 34;
            this.btReplaceAll.Text = null;
            this.btReplaceAll.Click += new System.EventHandler(this.btReplaceAll_Click);
            // 
            // btReplace
            // 
            this.btReplace.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btReplace.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            this.btReplace.ButtonFont = new System.Drawing.Font("Marlett", 12F);
            this.btReplace.Checked = false;
            this.btReplace.CheckedColor = System.Drawing.Color.Black;
            this.btReplace.CheckedEnable = false;
            this.btReplace.DisabledForeColor = System.Drawing.Color.Transparent;
            this.btReplace.HoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            this.btReplace.HoverForeColor = System.Drawing.Color.White;
            this.btReplace.Image = global::FastColoredTextBoxNS.Properties.Resources.edit_replace_16px;
            this.btReplace.Location = new System.Drawing.Point(164, 28);
            this.btReplace.menu = null;
            this.btReplace.Name = "btReplace";
            this.btReplace.NormalForeColor = System.Drawing.Color.Black;
            this.btReplace.Padding = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.btReplace.PressedForeColor = System.Drawing.Color.Black;
            this.btReplace.ShowBorder = true;
            this.btReplace.Size = new System.Drawing.Size(19, 19);
            this.btReplace.TabIndex = 33;
            this.btReplace.Text = null;
            this.btReplace.Click += new System.EventHandler(this.btReplace_Click);
            // 
            // btFindPrevious
            // 
            this.btFindPrevious.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btFindPrevious.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            this.btFindPrevious.ButtonFont = new System.Drawing.Font("Marlett", 12F);
            this.btFindPrevious.Checked = false;
            this.btFindPrevious.CheckedColor = System.Drawing.Color.Black;
            this.btFindPrevious.CheckedEnable = false;
            this.btFindPrevious.DisabledForeColor = System.Drawing.Color.Transparent;
            this.btFindPrevious.HoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            this.btFindPrevious.HoverForeColor = System.Drawing.Color.White;
            this.btFindPrevious.Image = null;
            this.btFindPrevious.Location = new System.Drawing.Point(164, 6);
            this.btFindPrevious.menu = null;
            this.btFindPrevious.Name = "btFindPrevious";
            this.btFindPrevious.NormalForeColor = System.Drawing.Color.DimGray;
            this.btFindPrevious.Padding = new System.Windows.Forms.Padding(1, 0, 0, 1);
            this.btFindPrevious.PressedForeColor = System.Drawing.Color.Black;
            this.btFindPrevious.ShowBorder = true;
            this.btFindPrevious.Size = new System.Drawing.Size(19, 19);
            this.btFindPrevious.TabIndex = 38;
            this.btFindPrevious.Text = "3";
            this.btFindPrevious.Click += new System.EventHandler(this.btFindPrevious_Click);
            // 
            // btFindNext
            // 
            this.btFindNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btFindNext.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            this.btFindNext.ButtonFont = new System.Drawing.Font("Marlett", 12F);
            this.btFindNext.Checked = false;
            this.btFindNext.CheckedColor = System.Drawing.Color.Black;
            this.btFindNext.CheckedEnable = false;
            this.btFindNext.DisabledForeColor = System.Drawing.Color.Transparent;
            this.btFindNext.HoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            this.btFindNext.HoverForeColor = System.Drawing.Color.White;
            this.btFindNext.Image = null;
            this.btFindNext.Location = new System.Drawing.Point(182, 6);
            this.btFindNext.menu = null;
            this.btFindNext.Name = "btFindNext";
            this.btFindNext.NormalForeColor = System.Drawing.Color.DimGray;
            this.btFindNext.Padding = new System.Windows.Forms.Padding(1, 0, 0, 1);
            this.btFindNext.PressedForeColor = System.Drawing.Color.Black;
            this.btFindNext.ShowBorder = true;
            this.btFindNext.Size = new System.Drawing.Size(19, 19);
            this.btFindNext.TabIndex = 39;
            this.btFindNext.Text = "4";
            this.btFindNext.Click += new System.EventHandler(this.btFindNext_Click);
            // 
            // labelInfo
            // 
            this.labelInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.labelInfo.ForeColor = System.Drawing.Color.DimGray;
            this.labelInfo.Location = new System.Drawing.Point(151, 54);
            this.labelInfo.Name = "labelInfo";
            this.labelInfo.Size = new System.Drawing.Size(70, 12);
            this.labelInfo.TabIndex = 40;
            this.labelInfo.Text = "0/0";
            // 
            // ReplaceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            this.ClientSize = new System.Drawing.Size(224, 71);
            this.ControlBox = false;
            this.Controls.Add(this.labelInfo);
            this.Controls.Add(this.btFindNext);
            this.Controls.Add(this.btFindPrevious);
            this.Controls.Add(this.cbMatchCase);
            this.Controls.Add(this.cbRegex);
            this.Controls.Add(this.cbWholeWord);
            this.Controls.Add(this.btReplaceAll);
            this.Controls.Add(this.btReplace);
            this.Controls.Add(this.btShowReplace);
            this.Controls.Add(this.tbReplace);
            this.Controls.Add(this.btClose);
            this.Controls.Add(this.tbFind);
            this.LeftResizable = true;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(270, 71);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(224, 49);
            this.Movable = false;
            this.Name = "ReplaceForm";
            this.Padding = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private MetroMenuButton btClose;
        public MetroTextBox tbFind;
        public MetroTextBox tbReplace;
        private MetroMenuButton btShowReplace;
        private MetroMenuButton btReplace;
        private MetroMenuButton btReplaceAll;
        private MetroCheckBox cbWholeWord;
        private MetroCheckBox cbRegex;
        private MetroCheckBox cbMatchCase;
        private MetroMenuButton btFindPrevious;
        private MetroMenuButton btFindNext;
        private System.Windows.Forms.Label labelInfo;
    }
}