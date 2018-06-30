namespace Cyotek.Windows.Forms
{
  partial class ColorEditorSimple
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
            this.rLabel = new System.Windows.Forms.Label();
            this.gLabel = new System.Windows.Forms.Label();
            this.bLabel = new System.Windows.Forms.Label();
            this.rValueLabel = new System.Windows.Forms.Label();
            this.gValueLabel = new System.Windows.Forms.Label();
            this.bValueLabel = new System.Windows.Forms.Label();
            this.bColorBar = new Cyotek.Windows.Forms.RgbaColorSlider();
            this.gColorBar = new Cyotek.Windows.Forms.RgbaColorSlider();
            this.rColorBar = new Cyotek.Windows.Forms.RgbaColorSlider();
            this.SuspendLayout();
            // 
            // rLabel
            // 
            this.rLabel.AutoSize = true;
            this.rLabel.Location = new System.Drawing.Point(3, 10);
            this.rLabel.Name = "rLabel";
            this.rLabel.Size = new System.Drawing.Size(11, 12);
            this.rLabel.TabIndex = 1;
            this.rLabel.Text = "R";
            // 
            // gLabel
            // 
            this.gLabel.AutoSize = true;
            this.gLabel.Location = new System.Drawing.Point(3, 34);
            this.gLabel.Name = "gLabel";
            this.gLabel.Size = new System.Drawing.Size(11, 12);
            this.gLabel.TabIndex = 4;
            this.gLabel.Text = "G";
            // 
            // bLabel
            // 
            this.bLabel.AutoSize = true;
            this.bLabel.Location = new System.Drawing.Point(3, 58);
            this.bLabel.Name = "bLabel";
            this.bLabel.Size = new System.Drawing.Size(11, 12);
            this.bLabel.TabIndex = 7;
            this.bLabel.Text = "B";
            // 
            // rValueLabel
            // 
            this.rValueLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rValueLabel.AutoSize = true;
            this.rValueLabel.Location = new System.Drawing.Point(150, 10);
            this.rValueLabel.Name = "rValueLabel";
            this.rValueLabel.Size = new System.Drawing.Size(23, 12);
            this.rValueLabel.TabIndex = 10;
            this.rValueLabel.Text = "255";
            // 
            // gValueLabel
            // 
            this.gValueLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.gValueLabel.AutoSize = true;
            this.gValueLabel.Location = new System.Drawing.Point(150, 34);
            this.gValueLabel.Name = "gValueLabel";
            this.gValueLabel.Size = new System.Drawing.Size(23, 12);
            this.gValueLabel.TabIndex = 11;
            this.gValueLabel.Text = "255";
            // 
            // bValueLabel
            // 
            this.bValueLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bValueLabel.AutoSize = true;
            this.bValueLabel.Location = new System.Drawing.Point(150, 58);
            this.bValueLabel.Name = "bValueLabel";
            this.bValueLabel.Size = new System.Drawing.Size(23, 12);
            this.bValueLabel.TabIndex = 12;
            this.bValueLabel.Text = "255";
            // 
            // bColorBar
            // 
            this.bColorBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.bColorBar.Channel = Cyotek.Windows.Forms.RgbaChannel.Blue;
            this.bColorBar.Location = new System.Drawing.Point(18, 60);
            this.bColorBar.Name = "bColorBar";
            this.bColorBar.Size = new System.Drawing.Size(130, 18);
            this.bColorBar.TabIndex = 9;
            this.bColorBar.Value = 255F;
            this.bColorBar.ValueChanged += new System.EventHandler(this.ValueChangedHandler);
            // 
            // gColorBar
            // 
            this.gColorBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gColorBar.Channel = Cyotek.Windows.Forms.RgbaChannel.Green;
            this.gColorBar.Location = new System.Drawing.Point(18, 36);
            this.gColorBar.Name = "gColorBar";
            this.gColorBar.Size = new System.Drawing.Size(130, 18);
            this.gColorBar.TabIndex = 6;
            this.gColorBar.Value = 255F;
            this.gColorBar.ValueChanged += new System.EventHandler(this.ValueChangedHandler);
            // 
            // rColorBar
            // 
            this.rColorBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rColorBar.Location = new System.Drawing.Point(18, 12);
            this.rColorBar.Name = "rColorBar";
            this.rColorBar.Size = new System.Drawing.Size(130, 18);
            this.rColorBar.TabIndex = 3;
            this.rColorBar.Value = 255F;
            this.rColorBar.ValueChanged += new System.EventHandler(this.ValueChangedHandler);
            // 
            // ColorEditorSimple
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.bValueLabel);
            this.Controls.Add(this.gValueLabel);
            this.Controls.Add(this.rValueLabel);
            this.Controls.Add(this.bColorBar);
            this.Controls.Add(this.bLabel);
            this.Controls.Add(this.gColorBar);
            this.Controls.Add(this.gLabel);
            this.Controls.Add(this.rColorBar);
            this.Controls.Add(this.rLabel);
            this.Name = "ColorEditorSimple";
            this.Size = new System.Drawing.Size(173, 91);
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    #endregion
    private System.Windows.Forms.Label rLabel;
    private RgbaColorSlider rColorBar;
    private System.Windows.Forms.Label gLabel;
    private RgbaColorSlider gColorBar;
    private System.Windows.Forms.Label bLabel;
    private RgbaColorSlider bColorBar;
        private System.Windows.Forms.Label rValueLabel;
        private System.Windows.Forms.Label gValueLabel;
        private System.Windows.Forms.Label bValueLabel;
    }
}
