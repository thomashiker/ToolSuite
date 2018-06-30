namespace FastColoredTextBoxNS
{
    partial class FindForm
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
            this.btNext = new FastColoredTextBoxNS.MetroMenuButton();
            this.btPrevious = new FastColoredTextBoxNS.MetroMenuButton();
            this.cbMatchCase = new FastColoredTextBoxNS.MetroCheckBox();
            this.cbWholeWord = new FastColoredTextBoxNS.MetroCheckBox();
            this.cbRegex = new FastColoredTextBoxNS.MetroCheckBox();
            this.btClose = new FastColoredTextBoxNS.MetroMenuButton();
            this.tbFind = new FastColoredTextBoxNS.MetroTextBox();
            this.SuspendLayout();
            // 
            // btNext
            // 
            this.btNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btNext.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            this.btNext.ButtonFont = new System.Drawing.Font("Marlett", 9F);
            this.btNext.Checked = true;
            this.btNext.CheckedColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            this.btNext.CheckedEnable = true;
            this.btNext.DisabledForeColor = System.Drawing.Color.Black;
            this.btNext.HoverBackColor = System.Drawing.Color.Gray;
            this.btNext.HoverForeColor = System.Drawing.Color.Red;
            this.btNext.Image = null;
            this.btNext.Location = new System.Drawing.Point(209, 54);
            this.btNext.menu = null;
            this.btNext.Name = "btNext";
            this.btNext.NormalForeColor = System.Drawing.Color.DimGray;
            this.btNext.Padding = new System.Windows.Forms.Padding(1, 0, 0, 1);
            this.btNext.PressedForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            this.btNext.ShowBorder = true;
            this.btNext.Size = new System.Drawing.Size(15, 15);
            this.btNext.TabIndex = 6;
            this.btNext.Text = "4";
            this.btNext.CheckedHander += new System.EventHandler(this.btNext_CheckedHander);
            // 
            // btPrevious
            // 
            this.btPrevious.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btPrevious.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            this.btPrevious.ButtonFont = new System.Drawing.Font("Marlett", 9F);
            this.btPrevious.Checked = false;
            this.btPrevious.CheckedColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            this.btPrevious.CheckedEnable = true;
            this.btPrevious.DisabledForeColor = System.Drawing.Color.Black;
            this.btPrevious.HoverBackColor = System.Drawing.Color.Gray;
            this.btPrevious.HoverForeColor = System.Drawing.Color.Red;
            this.btPrevious.Image = null;
            this.btPrevious.Location = new System.Drawing.Point(195, 54);
            this.btPrevious.menu = null;
            this.btPrevious.Name = "btPrevious";
            this.btPrevious.NormalForeColor = System.Drawing.Color.DimGray;
            this.btPrevious.Padding = new System.Windows.Forms.Padding(1, 0, 0, 1);
            this.btPrevious.PressedForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            this.btPrevious.ShowBorder = true;
            this.btPrevious.Size = new System.Drawing.Size(15, 15);
            this.btPrevious.TabIndex = 9;
            this.btPrevious.Text = "3";
            this.btPrevious.CheckedHander += new System.EventHandler(this.btNext_CheckedHander);
            // 
            // cbMatchCase
            // 
            this.cbMatchCase.AutoSize = true;
            this.cbMatchCase.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            this.cbMatchCase.CheckBoxPadding = new System.Windows.Forms.Padding(0);
            this.cbMatchCase.CheckedColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            this.cbMatchCase.DisabledColor = System.Drawing.Color.DimGray;
            this.cbMatchCase.ForeColor = System.Drawing.Color.DimGray;
            this.cbMatchCase.HoveredBorderColor = System.Drawing.Color.Black;
            this.cbMatchCase.Location = new System.Drawing.Point(6, 53);
            this.cbMatchCase.Name = "cbMatchCase";
            this.cbMatchCase.PressedBorderColor = System.Drawing.Color.Black;
            this.cbMatchCase.Size = new System.Drawing.Size(36, 16);
            this.cbMatchCase.TabIndex = 10;
            this.cbMatchCase.Text = "Aa";
            // 
            // cbWholeWord
            // 
            this.cbWholeWord.AutoSize = true;
            this.cbWholeWord.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            this.cbWholeWord.CheckBoxPadding = new System.Windows.Forms.Padding(0);
            this.cbWholeWord.CheckedColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            this.cbWholeWord.DisabledColor = System.Drawing.Color.DimGray;
            this.cbWholeWord.ForeColor = System.Drawing.Color.DimGray;
            this.cbWholeWord.HoveredBorderColor = System.Drawing.Color.Black;
            this.cbWholeWord.Location = new System.Drawing.Point(43, 53);
            this.cbWholeWord.Name = "cbWholeWord";
            this.cbWholeWord.PressedBorderColor = System.Drawing.Color.Black;
            this.cbWholeWord.Size = new System.Drawing.Size(54, 16);
            this.cbWholeWord.TabIndex = 11;
            this.cbWholeWord.Text = "|abc|";
            // 
            // cbRegex
            // 
            this.cbRegex.AutoSize = true;
            this.cbRegex.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            this.cbRegex.CheckBoxPadding = new System.Windows.Forms.Padding(0);
            this.cbRegex.CheckedColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            this.cbRegex.DisabledColor = System.Drawing.Color.DimGray;
            this.cbRegex.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbRegex.ForeColor = System.Drawing.Color.DimGray;
            this.cbRegex.HoveredBorderColor = System.Drawing.Color.Black;
            this.cbRegex.Location = new System.Drawing.Point(98, 53);
            this.cbRegex.Name = "cbRegex";
            this.cbRegex.PressedBorderColor = System.Drawing.Color.Black;
            this.cbRegex.Size = new System.Drawing.Size(42, 16);
            this.cbRegex.TabIndex = 12;
            this.cbRegex.Text = "[*]";
            this.cbRegex.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
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
            this.btClose.HoverForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            this.btClose.Image = null;
            this.btClose.Location = new System.Drawing.Point(211, 2);
            this.btClose.menu = null;
            this.btClose.Name = "btClose";
            this.btClose.NormalForeColor = System.Drawing.Color.LightGray;
            this.btClose.Padding = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.btClose.PressedForeColor = System.Drawing.Color.Crimson;
            this.btClose.ShowBorder = false;
            this.btClose.Size = new System.Drawing.Size(17, 16);
            this.btClose.TabIndex = 13;
            this.btClose.Text = "r";
            this.btClose.Click += new System.EventHandler(this.btClose_Click);
            // 
            // tbFind
            // 
            this.tbFind.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tbFind.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            // 
            // 
            // 
            this.tbFind.CustomButton.ButtonFont = new System.Drawing.Font("SimSun", 9F);
            this.tbFind.CustomButton.HoveredBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(240)))));
            this.tbFind.CustomButton.HoveredForeColor = System.Drawing.Color.White;
            this.tbFind.CustomButton.Image = global::FastColoredTextBoxNS.Properties.Resources.zoom;
            this.tbFind.CustomButton.Location = new System.Drawing.Point(198, 1);
            this.tbFind.CustomButton.Name = "";
            this.tbFind.CustomButton.NormalBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(217)))));
            this.tbFind.CustomButton.PressedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(190)))), ((int)(((byte)(240)))));
            this.tbFind.CustomButton.PressedForeColor = System.Drawing.Color.White;
            this.tbFind.CustomButton.Size = new System.Drawing.Size(19, 19);
            this.tbFind.CustomButton.TabIndex = 1;
            this.tbFind.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbFind.Lines = new string[0];
            this.tbFind.Location = new System.Drawing.Point(6, 25);
            this.tbFind.MaxLength = 32767;
            this.tbFind.Name = "tbFind";
            this.tbFind.PasswordChar = '\0';
            this.tbFind.PromptText = "search...";
            this.tbFind.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.tbFind.SelectedText = "";
            this.tbFind.SelectionLength = 0;
            this.tbFind.SelectionStart = 0;
            this.tbFind.ShortcutsEnabled = true;
            this.tbFind.ShowButton = true;
            this.tbFind.ShowClearButton = true;
            this.tbFind.Size = new System.Drawing.Size(218, 21);
            this.tbFind.TabIndex = 14;
            this.tbFind.TextBoxSize = new System.Drawing.Size(218, 21);
            this.tbFind.TextFont = new System.Drawing.Font("SimSun", 10F);
            this.tbFind.WaterMark = "search...";
            this.tbFind.WaterMarkColor = System.Drawing.Color.LightGray;
            this.tbFind.ButtonClick += new FastColoredTextBoxNS.MetroTextBox.ButClick(this.FindTextBox_ButtonClick);
            this.tbFind.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbFind_KeyPress);
            // 
            // FindForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            this.ClientSize = new System.Drawing.Size(230, 80);
            this.Controls.Add(this.tbFind);
            this.Controls.Add(this.btClose);
            this.Controls.Add(this.cbRegex);
            this.Controls.Add(this.cbWholeWord);
            this.Controls.Add(this.cbMatchCase);
            this.Controls.Add(this.btPrevious);
            this.Controls.Add(this.btNext);
            this.HeaderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            this.LeftResizable = true;
            this.MaximumSize = new System.Drawing.Size(300, 80);
            this.MinimumSize = new System.Drawing.Size(180, 80);
            this.Movable = false;
            this.Name = "FindForm";
            this.Padding = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Find";
            this.Title = "Find";
            this.TitleColor = System.Drawing.Color.DimGray;
            this.TitleFont = new System.Drawing.Font("NSimSun", 9.75F, System.Drawing.FontStyle.Bold);
            this.TitlePadding = new System.Windows.Forms.Padding(4, 5, 0, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private MetroMenuButton btNext;
        private MetroMenuButton btPrevious;
        private MetroCheckBox cbMatchCase;
        private MetroCheckBox cbWholeWord;
        private MetroCheckBox cbRegex;
        private MetroMenuButton btClose;
        private MetroTextBox tbFind;
    }
}