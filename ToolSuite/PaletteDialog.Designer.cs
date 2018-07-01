namespace ToolSuite
{
    partial class PaletteDialog
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
            this.btCancel = new MetroFramework.Controls.MetroMenuButton();
            this.metroDivider1 = new MetroFramework.Controls.MetroDivider();
            this.btMenu = new System.Windows.Forms.Button();
            this.btOK = new MetroFramework.Controls.MetroMenuButton();
            this.colorGrid = new Cyotek.Windows.Forms.ColorGrid();
            this.colorEditorSimple = new Cyotek.Windows.Forms.ColorEditorSimple();
            this.screenColorPicker = new Cyotek.Windows.Forms.ScreenColorPicker();
            this.colorEditorManager = new Cyotek.Windows.Forms.ColorEditorManager();
            this.customPalette = new Cyotek.Windows.Forms.CustomPalette(this.components);
            this.SuspendLayout();
            // 
            // btCancel
            // 
            this.btCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btCancel.BorderColor = System.Drawing.Color.Black;
            this.btCancel.CheckedColor = System.Drawing.Color.Black;
            this.btCancel.DisabledForeColor = System.Drawing.Color.Transparent;
            this.btCancel.HoverBackColor = System.Drawing.Color.Red;
            this.btCancel.HoverForeColor = System.Drawing.Color.White;
            this.btCancel.Image = null;
            this.btCancel.Location = new System.Drawing.Point(330, 5);
            this.btCancel.menu = null;
            this.btCancel.Name = "btCancel";
            this.btCancel.NormalForeColor = System.Drawing.Color.Black;
            this.btCancel.PressedForeColor = System.Drawing.Color.Black;
            this.btCancel.ShowBorder = true;
            this.btCancel.Size = new System.Drawing.Size(21, 19);
            this.btCancel.TabIndex = 5;
            this.btCancel.Text = "r";
            this.btCancel.UseCustomStyle = true;
            this.btCancel.UseSelectable = true;
            this.btCancel.Click += new System.EventHandler(this.btCancel_Click);
            // 
            // metroDivider1
            // 
            this.metroDivider1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.metroDivider1.Dock = System.Windows.Forms.DockStyle.Top;
            this.metroDivider1.Location = new System.Drawing.Point(2, 30);
            this.metroDivider1.Name = "metroDivider1";
            this.metroDivider1.Size = new System.Drawing.Size(354, 1);
            this.metroDivider1.TabIndex = 20;
            this.metroDivider1.UseCustomBackColor = true;
            // 
            // btMenu
            // 
            this.btMenu.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btMenu.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btMenu.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btMenu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btMenu.Location = new System.Drawing.Point(4, 35);
            this.btMenu.Name = "btMenu";
            this.btMenu.Size = new System.Drawing.Size(348, 23);
            this.btMenu.TabIndex = 23;
            this.btMenu.Text = "click to select";
            this.btMenu.UseVisualStyleBackColor = true;
            // 
            // btOK
            // 
            this.btOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btOK.BorderColor = System.Drawing.Color.Black;
            this.btOK.CheckedColor = System.Drawing.Color.Black;
            this.btOK.DisabledForeColor = System.Drawing.Color.Transparent;
            this.btOK.HoverBackColor = System.Drawing.Color.Lime;
            this.btOK.HoverForeColor = System.Drawing.Color.White;
            this.btOK.Image = null;
            this.btOK.Location = new System.Drawing.Point(303, 5);
            this.btOK.menu = null;
            this.btOK.Name = "btOK";
            this.btOK.NormalForeColor = System.Drawing.Color.Black;
            this.btOK.PressedForeColor = System.Drawing.Color.Black;
            this.btOK.ShowBorder = true;
            this.btOK.Size = new System.Drawing.Size(21, 19);
            this.btOK.TabIndex = 27;
            this.btOK.Text = "b";
            this.btOK.UseCustomStyle = true;
            this.btOK.UseSelectable = true;
            this.btOK.Click += new System.EventHandler(this.btOK_Click);
            // 
            // colorGrid
            // 
            this.colorGrid.CellBorderStyle = Cyotek.Windows.Forms.ColorCellBorderStyle.None;
            this.colorGrid.CellSize = new System.Drawing.Size(16, 16);
            this.colorGrid.Columns = 8;
            this.colorGrid.Location = new System.Drawing.Point(4, 64);
            this.colorGrid.Name = "colorGrid";
            this.colorGrid.Padding = new System.Windows.Forms.Padding(2);
            this.colorGrid.Palette = Cyotek.Windows.Forms.ColorPalette.None;
            this.colorGrid.ShowCustomColors = false;
            this.colorGrid.Size = new System.Drawing.Size(146, 20);
            this.colorGrid.Spacing = new System.Drawing.Size(2, 2);
            this.colorGrid.TabIndex = 20;
            // 
            // colorEditorSimple
            // 
            this.colorEditorSimple.Location = new System.Drawing.Point(156, 64);
            this.colorEditorSimple.Name = "colorEditorSimple";
            this.colorEditorSimple.Size = new System.Drawing.Size(196, 87);
            this.colorEditorSimple.TabIndex = 26;
            // 
            // screenColorPicker
            // 
            this.screenColorPicker.Color = System.Drawing.Color.Empty;
            this.screenColorPicker.Image = global::ToolSuite.Properties.Resources.color_picker;
            this.screenColorPicker.Location = new System.Drawing.Point(156, 157);
            this.screenColorPicker.Name = "screenColorPicker";
            this.screenColorPicker.Size = new System.Drawing.Size(196, 53);
            // 
            // colorEditorManager
            // 
            this.colorEditorManager.ColorEditorSimple = this.colorEditorSimple;
            this.colorEditorManager.ColorGrid = this.colorGrid;
            this.colorEditorManager.ScreenColorPicker = this.screenColorPicker;
            // 
            // customPalette
            // 
            this.customPalette.ColorGrid = this.colorGrid;
            // 
            // PaletteDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            this.ClientSize = new System.Drawing.Size(358, 229);
            this.ControlBox = false;
            this.Controls.Add(this.btOK);
            this.Controls.Add(this.colorGrid);
            this.Controls.Add(this.colorEditorSimple);
            this.Controls.Add(this.screenColorPicker);
            this.Controls.Add(this.btMenu);
            this.Controls.Add(this.metroDivider1);
            this.Controls.Add(this.btCancel);
            this.HeaderColor = System.Drawing.Color.White;
            this.HeaderImage = global::ToolSuite.Properties.Resources.color_swatch;
            this.HeaderImagePadding = new System.Windows.Forms.Padding(4, 5, 0, 5);
            this.Name = "PaletteDialog";
            this.Resizable = false;
            this.ShadowType = MetroFramework.Forms.MetroFormShadowType.None;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Title = "";
            this.TitlePadding = new System.Windows.Forms.Padding(4, 6, 0, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private MetroFramework.Controls.MetroMenuButton btCancel;
        private MetroFramework.Controls.MetroDivider metroDivider1;
        private System.Windows.Forms.Button btMenu;
        private Cyotek.Windows.Forms.ScreenColorPicker screenColorPicker;
        private Cyotek.Windows.Forms.ColorEditorSimple colorEditorSimple;
        private Cyotek.Windows.Forms.ColorGrid colorGrid;
        private Cyotek.Windows.Forms.ColorEditorManager colorEditorManager;
        private MetroFramework.Controls.MetroMenuButton btOK;
        private Cyotek.Windows.Forms.CustomPalette customPalette;
    }
}