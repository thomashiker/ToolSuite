namespace ToolSuite
{
    partial class SplashScreen
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
            this.hyperLinkLabel = new System.Windows.Forms.Label();
            this.metroStyleManager = new MetroFramework.Components.MetroStyleManager(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.metroStyleManager)).BeginInit();
            this.SuspendLayout();
            // 
            // hyperLinkLabel
            // 
            this.hyperLinkLabel.AutoSize = true;
            this.hyperLinkLabel.Location = new System.Drawing.Point(67, 189);
            this.hyperLinkLabel.Name = "hyperLinkLabel";
            this.hyperLinkLabel.Size = new System.Drawing.Size(245, 12);
            this.hyperLinkLabel.TabIndex = 0;
            this.hyperLinkLabel.Text = "https://github.com/thomashiker/ToolSuite";
            // 
            // metroStyleManager
            // 
            this.metroStyleManager.Owner = this;
            // 
            // SplashScreen
            // 
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(386, 214);
            this.ControlBox = false;
            this.Controls.Add(this.hyperLinkLabel);
            this.HeaderColor = System.Drawing.Color.White;
            this.HeaderImage = global::ToolSuite.Properties.Resources._3D_Cube2;
            this.HeaderImagePadding = new System.Windows.Forms.Padding(20, 5, 0, 0);
            this.Name = "SplashScreen";
            this.Opacity = 0.9D;
            this.Padding = new System.Windows.Forms.Padding(2, 128, 2, 2);
            this.Resizable = false;
            this.ShadowType = MetroFramework.Forms.MetroFormShadowType.None;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "SplashScreen";
            this.Title = "ToolSuite";
            this.TitleFont = new System.Drawing.Font("KaiTi", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.TitlePadding = new System.Windows.Forms.Padding(-80, 128, 0, 0);
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.metroStyleManager)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label hyperLinkLabel;
        private MetroFramework.Components.MetroStyleManager metroStyleManager;
    }
}