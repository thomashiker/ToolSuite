namespace ToolSuite
{
    partial class SearchForm
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
            this.btClose = new MetroFramework.Controls.MetroMenuButton();
            this.metroContextMenu1 = new MetroFramework.Controls.MetroContextMenu(this.components);
            this.nextToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.previousToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.allToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cbRegex = new ControlsLibrary.MetroCheckBox();
            this.cbWholeWord = new ControlsLibrary.MetroCheckBox();
            this.cbMatchCase = new ControlsLibrary.MetroCheckBox();
            this.tbFind = new ControlLibrary.MetroTextBox();
            this.cbNext = new ControlsLibrary.MetroMenuButton();
            this.cbPrevious = new ControlsLibrary.MetroMenuButton();
            this.btFindAll = new ControlsLibrary.MetroMenuButton();
            this.metroContextMenu1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btClose
            // 
            this.btClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btClose.BorderColor = System.Drawing.Color.Black;
            this.btClose.CheckedColor = System.Drawing.Color.Black;
            this.btClose.DisabledForeColor = System.Drawing.Color.Transparent;
            this.btClose.HoverBackColor = System.Drawing.Color.Transparent;
            this.btClose.HoverForeColor = System.Drawing.Color.Crimson;
            this.btClose.Image = null;
            this.btClose.Location = new System.Drawing.Point(212, 2);
            this.btClose.menu = null;
            this.btClose.Name = "btClose";
            this.btClose.NormalForeColor = System.Drawing.Color.DimGray;
            this.btClose.PressedForeColor = System.Drawing.Color.DimGray;
            this.btClose.ShowBorder = false;
            this.btClose.Size = new System.Drawing.Size(27, 20);
            this.btClose.TabIndex = 5;
            this.btClose.Text = "r";
            this.btClose.UseCustomStyle = true;
            this.btClose.UseSelectable = true;
            this.btClose.Click += new System.EventHandler(this.btClose_Click);
            // 
            // metroContextMenu1
            // 
            this.metroContextMenu1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nextToolStripMenuItem,
            this.previousToolStripMenuItem,
            this.allToolStripMenuItem});
            this.metroContextMenu1.Name = "metroContextMenu1";
            this.metroContextMenu1.Size = new System.Drawing.Size(126, 70);
            // 
            // nextToolStripMenuItem
            // 
            this.nextToolStripMenuItem.Name = "nextToolStripMenuItem";
            this.nextToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
            this.nextToolStripMenuItem.Text = "&Next";
            // 
            // previousToolStripMenuItem
            // 
            this.previousToolStripMenuItem.Name = "previousToolStripMenuItem";
            this.previousToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
            this.previousToolStripMenuItem.Text = "&Previous";
            // 
            // allToolStripMenuItem
            // 
            this.allToolStripMenuItem.Name = "allToolStripMenuItem";
            this.allToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
            this.allToolStripMenuItem.Text = "&All";
            // 
            // cbRegex
            // 
            this.cbRegex.AutoSize = true;
            this.cbRegex.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            this.cbRegex.CheckBoxPadding = new System.Windows.Forms.Padding(0);
            this.cbRegex.CheckedColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            this.cbRegex.DisabledColor = System.Drawing.Color.Gray;
            this.cbRegex.ForeColor = System.Drawing.Color.DimGray;
            this.cbRegex.HoveredBorderColor = System.Drawing.Color.Gray;
            this.cbRegex.Location = new System.Drawing.Point(99, 58);
            this.cbRegex.Name = "cbRegex";
            this.cbRegex.PressedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            this.cbRegex.Size = new System.Drawing.Size(42, 16);
            this.cbRegex.TabIndex = 13;
            this.cbRegex.Text = "[*]";
            // 
            // cbWholeWord
            // 
            this.cbWholeWord.AutoSize = true;
            this.cbWholeWord.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            this.cbWholeWord.CheckBoxPadding = new System.Windows.Forms.Padding(0);
            this.cbWholeWord.CheckedColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            this.cbWholeWord.DisabledColor = System.Drawing.Color.Gray;
            this.cbWholeWord.ForeColor = System.Drawing.Color.DimGray;
            this.cbWholeWord.HoveredBorderColor = System.Drawing.Color.Gray;
            this.cbWholeWord.Location = new System.Drawing.Point(44, 58);
            this.cbWholeWord.Name = "cbWholeWord";
            this.cbWholeWord.PressedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            this.cbWholeWord.Size = new System.Drawing.Size(54, 16);
            this.cbWholeWord.TabIndex = 12;
            this.cbWholeWord.Text = "|abc|";
            // 
            // cbMatchCase
            // 
            this.cbMatchCase.AutoSize = true;
            this.cbMatchCase.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            this.cbMatchCase.CheckBoxPadding = new System.Windows.Forms.Padding(0);
            this.cbMatchCase.CheckedColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            this.cbMatchCase.DisabledColor = System.Drawing.Color.Gray;
            this.cbMatchCase.ForeColor = System.Drawing.Color.DimGray;
            this.cbMatchCase.HoveredBorderColor = System.Drawing.Color.Gray;
            this.cbMatchCase.Location = new System.Drawing.Point(7, 58);
            this.cbMatchCase.Name = "cbMatchCase";
            this.cbMatchCase.PressedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            this.cbMatchCase.Size = new System.Drawing.Size(36, 16);
            this.cbMatchCase.TabIndex = 11;
            this.cbMatchCase.Text = "Aa";
            // 
            // tbFind
            // 
            this.tbFind.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            // 
            // 
            // 
            this.tbFind.CustomButton.ButtonFont = new System.Drawing.Font("Marlett", 10F);
            this.tbFind.CustomButton.HoveredBackColor = System.Drawing.Color.White;
            this.tbFind.CustomButton.HoveredForeColor = System.Drawing.Color.DimGray;
            this.tbFind.CustomButton.Image = global::ToolSuite.Properties.Resources.zoom_in;
            this.tbFind.CustomButton.Location = new System.Drawing.Point(186, 1);
            this.tbFind.CustomButton.Name = "";
            this.tbFind.CustomButton.NormalBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            this.tbFind.CustomButton.PressedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            this.tbFind.CustomButton.PressedForeColor = System.Drawing.Color.Black;
            this.tbFind.CustomButton.Size = new System.Drawing.Size(19, 19);
            this.tbFind.CustomButton.TabIndex = 1;
            this.tbFind.Lines = new string[0];
            this.tbFind.Location = new System.Drawing.Point(6, 29);
            this.tbFind.MaxLength = 32767;
            this.tbFind.Name = "tbFind";
            this.tbFind.PasswordChar = '\0';
            this.tbFind.PromptText = "search ...";
            this.tbFind.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.tbFind.SelectedText = "";
            this.tbFind.SelectionLength = 0;
            this.tbFind.SelectionStart = 0;
            this.tbFind.ShortcutsEnabled = true;
            this.tbFind.ShowButton = true;
            this.tbFind.ShowClearButton = true;
            this.tbFind.Size = new System.Drawing.Size(206, 21);
            this.tbFind.TabIndex = 8;
            this.tbFind.TextBoxSize = new System.Drawing.Size(206, 21);
            this.tbFind.TextFont = new System.Drawing.Font("SimSun", 10F);
            this.tbFind.WaterMark = "search ...";
            this.tbFind.WaterMarkColor = System.Drawing.Color.DimGray;
            this.tbFind.ButtonClick += new ControlLibrary.MetroTextBox.ButClick(this.tbFind_ButtonClick);
            // 
            // cbNext
            // 
            this.cbNext.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cbNext.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            this.cbNext.ButtonFont = new System.Drawing.Font("Marlett", 9F);
            this.cbNext.Checked = true;
            this.cbNext.CheckedColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            this.cbNext.CheckedEnable = true;
            this.cbNext.DisabledForeColor = System.Drawing.Color.Transparent;
            this.cbNext.HoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            this.cbNext.HoverForeColor = System.Drawing.Color.White;
            this.cbNext.Image = global::ToolSuite.Properties.Resources.zoom_in;
            this.cbNext.Location = new System.Drawing.Point(197, 59);
            this.cbNext.menu = null;
            this.cbNext.Name = "cbNext";
            this.cbNext.NormalBackColor = System.Drawing.Color.White;
            this.cbNext.NormalForeColor = System.Drawing.Color.DimGray;
            this.cbNext.Padding = new System.Windows.Forms.Padding(1, 0, 0, 1);
            this.cbNext.PressedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            this.cbNext.PressedForeColor = System.Drawing.Color.Black;
            this.cbNext.ShowBorder = true;
            this.cbNext.ShowImage = false;
            this.cbNext.Size = new System.Drawing.Size(15, 15);
            this.cbNext.TabIndex = 15;
            this.cbNext.Text = "4";
            this.cbNext.CheckedHander += new System.EventHandler(this.cbNext_CheckedHander);
            // 
            // cbPrevious
            // 
            this.cbPrevious.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cbPrevious.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            this.cbPrevious.ButtonFont = new System.Drawing.Font("Marlett", 9F);
            this.cbPrevious.Checked = false;
            this.cbPrevious.CheckedColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            this.cbPrevious.CheckedEnable = true;
            this.cbPrevious.DisabledForeColor = System.Drawing.Color.Transparent;
            this.cbPrevious.HoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            this.cbPrevious.HoverForeColor = System.Drawing.Color.White;
            this.cbPrevious.Image = global::ToolSuite.Properties.Resources.zoom_out;
            this.cbPrevious.Location = new System.Drawing.Point(183, 59);
            this.cbPrevious.menu = null;
            this.cbPrevious.Name = "cbPrevious";
            this.cbPrevious.NormalBackColor = System.Drawing.Color.White;
            this.cbPrevious.NormalForeColor = System.Drawing.Color.DimGray;
            this.cbPrevious.Padding = new System.Windows.Forms.Padding(1, 0, 0, 1);
            this.cbPrevious.PressedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            this.cbPrevious.PressedForeColor = System.Drawing.Color.Black;
            this.cbPrevious.ShowBorder = true;
            this.cbPrevious.ShowImage = false;
            this.cbPrevious.Size = new System.Drawing.Size(15, 15);
            this.cbPrevious.TabIndex = 14;
            this.cbPrevious.Text = "3";
            this.cbPrevious.CheckedHander += new System.EventHandler(this.cbNext_CheckedHander);
            // 
            // btFindAll
            // 
            this.btFindAll.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btFindAll.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            this.btFindAll.ButtonFont = new System.Drawing.Font("Marlett", 12F);
            this.btFindAll.Checked = false;
            this.btFindAll.CheckedColor = System.Drawing.Color.Black;
            this.btFindAll.CheckedEnable = false;
            this.btFindAll.DisabledForeColor = System.Drawing.Color.Transparent;
            this.btFindAll.HoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            this.btFindAll.HoverForeColor = System.Drawing.Color.White;
            this.btFindAll.Image = global::ToolSuite.Properties.Resources.search_advanced;
            this.btFindAll.Location = new System.Drawing.Point(213, 29);
            this.btFindAll.menu = null;
            this.btFindAll.Name = "btFindAll";
            this.btFindAll.NormalBackColor = System.Drawing.Color.White;
            this.btFindAll.NormalForeColor = System.Drawing.Color.DimGray;
            this.btFindAll.Padding = new System.Windows.Forms.Padding(1, 0, 0, 0);
            this.btFindAll.PressedBackColor = System.Drawing.Color.White;
            this.btFindAll.PressedForeColor = System.Drawing.Color.Black;
            this.btFindAll.ShowBorder = true;
            this.btFindAll.ShowImage = true;
            this.btFindAll.Size = new System.Drawing.Size(21, 21);
            this.btFindAll.TabIndex = 7;
            this.btFindAll.Text = null;
            this.btFindAll.Click += new System.EventHandler(this.btFindAll_Click);
            // 
            // SearchForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            this.ClientSize = new System.Drawing.Size(240, 84);
            this.ControlBox = false;
            this.Controls.Add(this.cbNext);
            this.Controls.Add(this.cbPrevious);
            this.Controls.Add(this.cbRegex);
            this.Controls.Add(this.cbWholeWord);
            this.Controls.Add(this.cbMatchCase);
            this.Controls.Add(this.tbFind);
            this.Controls.Add(this.btFindAll);
            this.Controls.Add(this.btClose);
            this.HeaderColor = System.Drawing.Color.White;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SearchForm";
            this.Padding = new System.Windows.Forms.Padding(2, 20, 2, 2);
            this.Resizable = false;
            this.ShadowType = MetroFramework.Forms.MetroFormShadowType.None;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Title = "Find";
            this.TitleAppendText = "";
            this.TitleColor = System.Drawing.Color.DimGray;
            this.TitleFont = new System.Drawing.Font("NSimSun", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.TitlePadding = new System.Windows.Forms.Padding(2, 4, 0, 0);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SearchForm_FormClosing);
            this.metroContextMenu1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private MetroFramework.Controls.MetroMenuButton btClose;
        private ControlsLibrary.MetroMenuButton btFindAll;
        private ControlLibrary.MetroTextBox tbFind;
        private MetroFramework.Controls.MetroContextMenu metroContextMenu1;
        private System.Windows.Forms.ToolStripMenuItem nextToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem previousToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem allToolStripMenuItem;
        private ControlsLibrary.MetroCheckBox cbMatchCase;
        private ControlsLibrary.MetroCheckBox cbWholeWord;
        private ControlsLibrary.MetroCheckBox cbRegex;
        private ControlsLibrary.MetroMenuButton cbNext;
        private ControlsLibrary.MetroMenuButton cbPrevious;
    }
}