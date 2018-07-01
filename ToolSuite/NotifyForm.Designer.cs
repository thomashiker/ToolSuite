namespace ToolSuite
{
    partial class NotifyForm
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
            this.btClose = new ControlsLibrary.MetroMenuButton();
            this.labelNotify = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btClose
            // 
            this.btClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btClose.BorderColor = System.Drawing.Color.Black;
            this.btClose.ButtonFont = new System.Drawing.Font("Marlett", 10F);
            this.btClose.Checked = false;
            this.btClose.CheckedColor = System.Drawing.Color.Black;
            this.btClose.DisabledForeColor = System.Drawing.Color.Transparent;
            this.btClose.HoverBackColor = System.Drawing.Color.Transparent;
            this.btClose.HoverForeColor = System.Drawing.Color.Red;
            this.btClose.Image = null;
            this.btClose.Location = new System.Drawing.Point(181, 2);
            this.btClose.menu = null;
            this.btClose.Name = "btClose";
            this.btClose.NormalForeColor = System.Drawing.Color.Silver;
            this.btClose.Padding = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.btClose.PressedForeColor = System.Drawing.Color.DarkRed;
            this.btClose.ShowBorder = false;
            this.btClose.Size = new System.Drawing.Size(16, 16);
            this.btClose.TabIndex = 0;
            this.btClose.Text = "r";
            // 
            // labelNotify
            // 
            this.labelNotify.AutoSize = true;
            this.labelNotify.Location = new System.Drawing.Point(31, 26);
            this.labelNotify.Name = "labelNotify";
            this.labelNotify.Size = new System.Drawing.Size(41, 12);
            this.labelNotify.TabIndex = 1;
            this.labelNotify.Text = "notify";
            // 
            // NotifyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            this.ClientSize = new System.Drawing.Size(200, 45);
            this.ControlBox = false;
            this.Controls.Add(this.labelNotify);
            this.Controls.Add(this.btClose);
            this.HeaderColor = System.Drawing.Color.White;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(200, 45);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(200, 45);
            this.Name = "NotifyForm";
            this.Padding = new System.Windows.Forms.Padding(2, 20, 2, 2);
            this.Resizable = false;
            this.ShadowType = MetroFramework.Forms.MetroFormShadowType.None;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Title = "Notify";
            this.TitleColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            this.TitleFont = new System.Drawing.Font("STLiti", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.TitlePadding = new System.Windows.Forms.Padding(2, 4, 0, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ControlsLibrary.MetroMenuButton btClose;
        private System.Windows.Forms.Label labelNotify;
    }
}