namespace FastColoredTextBoxNS
{
    partial class GoToForm
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
            this.tbLineNum = new FastColoredTextBoxNS.MetroTextBox();
            this.SuspendLayout();
            // 
            // btClose
            // 
            this.btClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btClose.BorderColor = System.Drawing.Color.Black;
            this.btClose.ButtonFont = new System.Drawing.Font("Marlett", 10F);
            this.btClose.Checked = false;
            this.btClose.CheckedColor = System.Drawing.Color.Black;
            this.btClose.CheckedEnable = false;
            this.btClose.DisabledForeColor = System.Drawing.Color.Transparent;
            this.btClose.HoverBackColor = System.Drawing.Color.DimGray;
            this.btClose.HoverForeColor = System.Drawing.Color.White;
            this.btClose.Image = null;
            this.btClose.Location = new System.Drawing.Point(162, 2);
            this.btClose.menu = null;
            this.btClose.Name = "btClose";
            this.btClose.NormalForeColor = System.Drawing.Color.LightGray;
            this.btClose.Padding = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.btClose.PressedForeColor = System.Drawing.Color.Black;
            this.btClose.ShowBorder = false;
            this.btClose.Size = new System.Drawing.Size(17, 16);
            this.btClose.TabIndex = 8;
            this.btClose.Text = "r";
            this.btClose.Click += new System.EventHandler(this.btClose_Click);
            // 
            // tbLineNum
            // 
            this.tbLineNum.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tbLineNum.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            // 
            // 
            // 
            this.tbLineNum.CustomButton.ButtonFont = new System.Drawing.Font("SimSun", 9F);
            this.tbLineNum.CustomButton.HoveredBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(240)))));
            this.tbLineNum.CustomButton.HoveredForeColor = System.Drawing.Color.White;
            this.tbLineNum.CustomButton.Image = global::FastColoredTextBoxNS.Properties.Resources.enter;
            this.tbLineNum.CustomButton.Location = new System.Drawing.Point(156, 1);
            this.tbLineNum.CustomButton.Name = "";
            this.tbLineNum.CustomButton.NormalBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(217)))));
            this.tbLineNum.CustomButton.PressedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(190)))), ((int)(((byte)(240)))));
            this.tbLineNum.CustomButton.PressedForeColor = System.Drawing.Color.White;
            this.tbLineNum.CustomButton.Size = new System.Drawing.Size(17, 17);
            this.tbLineNum.CustomButton.TabIndex = 1;
            this.tbLineNum.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbLineNum.Lines = new string[0];
            this.tbLineNum.Location = new System.Drawing.Point(3, 21);
            this.tbLineNum.MaxLength = 32767;
            this.tbLineNum.Name = "tbLineNum";
            this.tbLineNum.PasswordChar = '\0';
            this.tbLineNum.PromptText = "goto...";
            this.tbLineNum.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.tbLineNum.SelectedText = "";
            this.tbLineNum.SelectionLength = 0;
            this.tbLineNum.SelectionStart = 0;
            this.tbLineNum.ShortcutsEnabled = true;
            this.tbLineNum.ShowButton = true;
            this.tbLineNum.ShowClearButton = true;
            this.tbLineNum.Size = new System.Drawing.Size(174, 19);
            this.tbLineNum.TabIndex = 15;
            this.tbLineNum.TextFont = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbLineNum.WaterMark = "goto...";
            this.tbLineNum.WaterMarkColor = System.Drawing.Color.LightGray;
            this.tbLineNum.ButtonClick += new FastColoredTextBoxNS.MetroTextBox.ButClick(this.tbLineNum_ButtonClick);
            this.tbLineNum.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbLineNum_KeyPress);
            // 
            // GoToForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            this.ClientSize = new System.Drawing.Size(180, 50);
            this.Controls.Add(this.tbLineNum);
            this.Controls.Add(this.btClose);
            this.HeaderColor = System.Drawing.Color.White;
            this.LeftResizable = true;
            this.MaximumSize = new System.Drawing.Size(300, 50);
            this.MinimumSize = new System.Drawing.Size(180, 50);
            this.Name = "GoToForm";
            this.Padding = new System.Windows.Forms.Padding(2, 16, 2, 2);
            this.Resizable = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.TitleColor = System.Drawing.Color.DimGray;
            this.TitleFont = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.TitlePadding = new System.Windows.Forms.Padding(5, 3, 0, 0);
            this.ResumeLayout(false);

        }

        #endregion
        private MetroMenuButton btClose;
        private MetroTextBox tbLineNum;
    }
}