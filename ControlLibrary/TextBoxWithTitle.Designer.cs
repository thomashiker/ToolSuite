namespace ControlLibrary
{
    partial class TextBoxWithTitle
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.divider = new System.Windows.Forms.Panel();
            this.contentTextBox = new MetroSet_UI.Controls.MetroSetRichTextBox();
            this.titleTextBox = new MetroSet_UI.Controls.MetroSetTextBox();
            this.SuspendLayout();
            // 
            // divider
            // 
            this.divider.BackColor = System.Drawing.Color.Lime;
            this.divider.Dock = System.Windows.Forms.DockStyle.Top;
            this.divider.Location = new System.Drawing.Point(0, 22);
            this.divider.Name = "divider";
            this.divider.Size = new System.Drawing.Size(255, 1);
            this.divider.TabIndex = 2;
            // 
            // contentTextBox
            // 
            this.contentTextBox.AutoWordSelection = false;
            this.contentTextBox.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(155)))), ((int)(((byte)(155)))));
            this.contentTextBox.DisabledBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.contentTextBox.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(155)))), ((int)(((byte)(155)))));
            this.contentTextBox.DisabledForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(136)))), ((int)(((byte)(136)))));
            this.contentTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.contentTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.contentTextBox.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.contentTextBox.Lines = null;
            this.contentTextBox.Location = new System.Drawing.Point(0, 23);
            this.contentTextBox.MaxLength = 32767;
            this.contentTextBox.Name = "contentTextBox";
            this.contentTextBox.ReadOnly = false;
            this.contentTextBox.Size = new System.Drawing.Size(255, 292);
            this.contentTextBox.Style = MetroSet_UI.Design.Style.Light;
            this.contentTextBox.StyleManager = null;
            this.contentTextBox.TabIndex = 1;
            this.contentTextBox.ThemeAuthor = "Narwin";
            this.contentTextBox.ThemeName = "MetroLite";
            this.contentTextBox.WordWrap = true;
            // 
            // titleTextBox
            // 
            this.titleTextBox.AutoCompleteCustomSource = null;
            this.titleTextBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.titleTextBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.titleTextBox.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(155)))), ((int)(((byte)(155)))));
            this.titleTextBox.DisabledBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.titleTextBox.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(155)))), ((int)(((byte)(155)))));
            this.titleTextBox.DisabledForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(136)))), ((int)(((byte)(136)))));
            this.titleTextBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.titleTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.titleTextBox.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.titleTextBox.Image = null;
            this.titleTextBox.Lines = null;
            this.titleTextBox.Location = new System.Drawing.Point(0, 0);
            this.titleTextBox.MaxLength = 32767;
            this.titleTextBox.Multiline = false;
            this.titleTextBox.Name = "titleTextBox";
            this.titleTextBox.ReadOnly = false;
            this.titleTextBox.Size = new System.Drawing.Size(255, 22);
            this.titleTextBox.Style = MetroSet_UI.Design.Style.Light;
            this.titleTextBox.StyleManager = null;
            this.titleTextBox.TabIndex = 0;
            this.titleTextBox.Text = "title";
            this.titleTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.titleTextBox.ThemeAuthor = "Narwin";
            this.titleTextBox.ThemeName = "MetroLite";
            this.titleTextBox.UseSystemPasswordChar = false;
            this.titleTextBox.WatermarkText = "title";
            // 
            // TextBoxWithTitle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.contentTextBox);
            this.Controls.Add(this.divider);
            this.Controls.Add(this.titleTextBox);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "TextBoxWithTitle";
            this.Size = new System.Drawing.Size(255, 315);
            this.ResumeLayout(false);

        }

        #endregion

        private MetroSet_UI.Controls.MetroSetTextBox titleTextBox;
        private MetroSet_UI.Controls.MetroSetRichTextBox contentTextBox;
        private System.Windows.Forms.Panel divider;
    }
}
