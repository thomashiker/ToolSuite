namespace ToolSuite
{
    partial class AppearanceSetting
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
            this.btHide = new MetroFramework.Controls.MetroMenuButton();
            this.metroDivider1 = new MetroFramework.Controls.MetroDivider();
            this.selectMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.themeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.styleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.textToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.textToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.caretToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.indentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.selectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.backgroundToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bookmarkToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lineNumberToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.serviceLineToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btMenu = new System.Windows.Forms.Button();
            this.colorGrid = new Cyotek.Windows.Forms.ColorGrid();
            this.colorEditorSimple = new Cyotek.Windows.Forms.ColorEditorSimple();
            this.screenColorPicker = new Cyotek.Windows.Forms.ScreenColorPicker();
            this.colorEditorManager = new Cyotek.Windows.Forms.ColorEditorManager();
            this.selectMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // btHide
            // 
            this.btHide.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btHide.DisabledForeColor = System.Drawing.Color.Transparent;
            this.btHide.HoverBackColor = System.Drawing.Color.Red;
            this.btHide.HoverForeColor = System.Drawing.Color.White;
            this.btHide.Image = null;
            this.btHide.Location = new System.Drawing.Point(242, 5);
            this.btHide.menu = null;
            this.btHide.Name = "btHide";
            this.btHide.NormalForeColor = System.Drawing.Color.Black;
            this.btHide.Size = new System.Drawing.Size(21, 19);
            this.btHide.TabIndex = 5;
            this.btHide.Text = "r";
            this.btHide.UseCustomStyle = true;
            this.btHide.UseSelectable = true;
            this.btHide.Click += new System.EventHandler(this.btHide_Click);
            // 
            // metroDivider1
            // 
            this.metroDivider1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.metroDivider1.Dock = System.Windows.Forms.DockStyle.Top;
            this.metroDivider1.Location = new System.Drawing.Point(2, 30);
            this.metroDivider1.Name = "metroDivider1";
            this.metroDivider1.Size = new System.Drawing.Size(266, 1);
            this.metroDivider1.TabIndex = 20;
            this.metroDivider1.UseCustomBackColor = true;
            // 
            // selectMenu
            // 
            this.selectMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.themeToolStripMenuItem,
            this.styleToolStripMenuItem,
            this.textToolStripMenuItem});
            this.selectMenu.Name = "selectMenu";
            this.selectMenu.Size = new System.Drawing.Size(113, 70);
            this.selectMenu.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.selectMenu_ItemClicked);
            // 
            // themeToolStripMenuItem
            // 
            this.themeToolStripMenuItem.Name = "themeToolStripMenuItem";
            this.themeToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.themeToolStripMenuItem.Text = "theme";
            // 
            // styleToolStripMenuItem
            // 
            this.styleToolStripMenuItem.Name = "styleToolStripMenuItem";
            this.styleToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.styleToolStripMenuItem.Text = "style";
            // 
            // textToolStripMenuItem
            // 
            this.textToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.textToolStripMenuItem2,
            this.caretToolStripMenuItem,
            this.indentToolStripMenuItem,
            this.selectionToolStripMenuItem,
            this.backgroundToolStripMenuItem,
            this.bookmarkToolStripMenuItem,
            this.lineNumberToolStripMenuItem,
            this.serviceLineToolStripMenuItem});
            this.textToolStripMenuItem.Name = "textToolStripMenuItem";
            this.textToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.textToolStripMenuItem.Text = "Text";
            this.textToolStripMenuItem.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.textToolStripMenuItem_DropDownItemClicked);
            // 
            // textToolStripMenuItem2
            // 
            this.textToolStripMenuItem2.Name = "textToolStripMenuItem2";
            this.textToolStripMenuItem2.Size = new System.Drawing.Size(151, 22);
            this.textToolStripMenuItem2.Text = "Text";
            // 
            // caretToolStripMenuItem
            // 
            this.caretToolStripMenuItem.Name = "caretToolStripMenuItem";
            this.caretToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.caretToolStripMenuItem.Text = "Caret";
            // 
            // indentToolStripMenuItem
            // 
            this.indentToolStripMenuItem.Name = "indentToolStripMenuItem";
            this.indentToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.indentToolStripMenuItem.Text = "Indent";
            // 
            // selectionToolStripMenuItem
            // 
            this.selectionToolStripMenuItem.Name = "selectionToolStripMenuItem";
            this.selectionToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.selectionToolStripMenuItem.Text = "Selection";
            // 
            // backgroundToolStripMenuItem
            // 
            this.backgroundToolStripMenuItem.Name = "backgroundToolStripMenuItem";
            this.backgroundToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.backgroundToolStripMenuItem.Text = "Background";
            // 
            // bookmarkToolStripMenuItem
            // 
            this.bookmarkToolStripMenuItem.Name = "bookmarkToolStripMenuItem";
            this.bookmarkToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.bookmarkToolStripMenuItem.Text = "Bookmark";
            // 
            // lineNumberToolStripMenuItem
            // 
            this.lineNumberToolStripMenuItem.Name = "lineNumberToolStripMenuItem";
            this.lineNumberToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.lineNumberToolStripMenuItem.Text = "Line Number";
            // 
            // serviceLineToolStripMenuItem
            // 
            this.serviceLineToolStripMenuItem.Name = "serviceLineToolStripMenuItem";
            this.serviceLineToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.serviceLineToolStripMenuItem.Text = "Service Line";
            // 
            // btMenu
            // 
            this.btMenu.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btMenu.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btMenu.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btMenu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btMenu.Location = new System.Drawing.Point(5, 37);
            this.btMenu.Name = "btMenu";
            this.btMenu.Size = new System.Drawing.Size(260, 23);
            this.btMenu.TabIndex = 23;
            this.btMenu.Text = "click to select";
            this.btMenu.UseVisualStyleBackColor = true;
            this.btMenu.Click += new System.EventHandler(this.btMenu_Click);
            // 
            // colorGrid
            // 
            this.colorGrid.CellBorderStyle = Cyotek.Windows.Forms.ColorCellBorderStyle.None;
            this.colorGrid.CellSize = new System.Drawing.Size(24, 24);
            this.colorGrid.Columns = 10;
            this.colorGrid.Location = new System.Drawing.Point(4, 64);
            this.colorGrid.Name = "colorGrid";
            this.colorGrid.Padding = new System.Windows.Forms.Padding(2);
            this.colorGrid.Palette = Cyotek.Windows.Forms.ColorPalette.Custom;
            this.colorGrid.ShowCustomColors = false;
            this.colorGrid.Size = new System.Drawing.Size(262, 210);
            this.colorGrid.Spacing = new System.Drawing.Size(2, 2);
            this.colorGrid.TabIndex = 27;
            // 
            // colorEditorSimple
            // 
            this.colorEditorSimple.Location = new System.Drawing.Point(6, 282);
            this.colorEditorSimple.Name = "colorEditorSimple";
            this.colorEditorSimple.Size = new System.Drawing.Size(258, 84);
            this.colorEditorSimple.TabIndex = 26;
            // 
            // screenColorPicker
            // 
            this.screenColorPicker.Color = System.Drawing.Color.Empty;
            this.screenColorPicker.Image = global::ToolSuite.Properties.Resources.color_picker;
            this.screenColorPicker.Location = new System.Drawing.Point(5, 371);
            this.screenColorPicker.Name = "screenColorPicker";
            this.screenColorPicker.Size = new System.Drawing.Size(260, 105);
            // 
            // colorEditorManager
            // 
            this.colorEditorManager.ColorEditorSimple = this.colorEditorSimple;
            this.colorEditorManager.ColorGrid = this.colorGrid;
            this.colorEditorManager.ScreenColorPicker = this.screenColorPicker;
            this.colorEditorManager.ColorChanged += new System.EventHandler(this.colorEditorManager_ColorChanged);
            // 
            // AppearanceSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            this.ClientSize = new System.Drawing.Size(270, 482);
            this.ControlBox = false;
            this.Controls.Add(this.colorGrid);
            this.Controls.Add(this.colorEditorSimple);
            this.Controls.Add(this.screenColorPicker);
            this.Controls.Add(this.btMenu);
            this.Controls.Add(this.metroDivider1);
            this.Controls.Add(this.btHide);
            this.HeaderColor = System.Drawing.Color.White;
            this.HeaderImage = global::ToolSuite.Properties.Resources.color_swatch;
            this.HeaderImagePadding = new System.Windows.Forms.Padding(4, 5, 0, 5);
            this.Name = "AppearanceSetting";
            this.Resizable = false;
            this.ShadowType = MetroFramework.Forms.MetroFormShadowType.None;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Title = "";
            this.TitlePadding = new System.Windows.Forms.Padding(4, 6, 0, 0);
            this.selectMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private MetroFramework.Controls.MetroMenuButton btHide;
        private MetroFramework.Controls.MetroDivider metroDivider1;
        private System.Windows.Forms.ContextMenuStrip selectMenu;
        private System.Windows.Forms.ToolStripMenuItem themeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem styleToolStripMenuItem;
        private System.Windows.Forms.Button btMenu;
        private System.Windows.Forms.ToolStripMenuItem textToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem backgroundToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem indentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem caretToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bookmarkToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem selectionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lineNumberToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem textToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem serviceLineToolStripMenuItem;
        private Cyotek.Windows.Forms.ScreenColorPicker screenColorPicker;
        private Cyotek.Windows.Forms.ColorEditorSimple colorEditorSimple;
        private Cyotek.Windows.Forms.ColorGrid colorGrid;
        private Cyotek.Windows.Forms.ColorEditorManager colorEditorManager;
    }
}