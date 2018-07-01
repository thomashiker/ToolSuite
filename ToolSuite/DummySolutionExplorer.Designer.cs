namespace ToolSuite
{
    partial class DummySolutionExplorer
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            ControlsLibrary.ImageItem imageItem1 = new ControlsLibrary.ImageItem();
            ControlsLibrary.ImageItem imageItem2 = new ControlsLibrary.ImageItem();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DummySolutionExplorer));
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.tsbtEdit = new System.Windows.Forms.ToolStripButton();
            this.tsbtView = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbtAddRow = new System.Windows.Forms.ToolStripButton();
            this.tsbtRemoveRow = new System.Windows.Forms.ToolStripButton();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.repeatToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.uploadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reloadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.metroGrid = new MetroFramework.Controls.MetroGrid();
            this.ColumnCheck = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ColumnCmd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnDiscription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.listMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.checkAll1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.uncheck1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.sendAll1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sendSelectionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sendCheckedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listViewContextMenu = new MetroFramework.Controls.MetroContextMenu(this.components);
            this.highQualityImageList = new ControlsLibrary.HighQualityImageList();
            this.toolStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.metroGrid)).BeginInit();
            this.listMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip
            // 
            this.toolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbtEdit,
            this.tsbtView,
            this.toolStripSeparator1,
            this.tsbtAddRow,
            this.tsbtRemoveRow,
            this.toolStripDropDownButton1});
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Padding = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.toolStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip.Size = new System.Drawing.Size(245, 25);
            this.toolStrip.TabIndex = 0;
            this.toolStrip.Text = "toolStrip1";
            // 
            // tsbtEdit
            // 
            this.tsbtEdit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtEdit.Image = global::ToolSuite.Properties.Resources.read_only;
            this.tsbtEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtEdit.Name = "tsbtEdit";
            this.tsbtEdit.Size = new System.Drawing.Size(23, 22);
            this.tsbtEdit.Text = "Edit";
            this.tsbtEdit.Click += new System.EventHandler(this.tsbtEdit_Click);
            // 
            // tsbtView
            // 
            this.tsbtView.CheckOnClick = true;
            this.tsbtView.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtView.Image = global::ToolSuite.Properties.Resources.code_16px_1137823_easyicon_net;
            this.tsbtView.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtView.Name = "tsbtView";
            this.tsbtView.Size = new System.Drawing.Size(23, 22);
            this.tsbtView.Text = "detail enable";
            this.tsbtView.Click += new System.EventHandler(this.tsbtView_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbtAddRow
            // 
            this.tsbtAddRow.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtAddRow.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            this.tsbtAddRow.Image = global::ToolSuite.Properties.Resources.plus_16px_1137939_easyicon_net;
            this.tsbtAddRow.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtAddRow.Name = "tsbtAddRow";
            this.tsbtAddRow.Size = new System.Drawing.Size(23, 22);
            this.tsbtAddRow.Text = "add";
            this.tsbtAddRow.Click += new System.EventHandler(this.tsbtAddRow_Click);
            // 
            // tsbtRemoveRow
            // 
            this.tsbtRemoveRow.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtRemoveRow.Image = global::ToolSuite.Properties.Resources.minus_16px_1137913_easyicon_net;
            this.tsbtRemoveRow.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtRemoveRow.Name = "tsbtRemoveRow";
            this.tsbtRemoveRow.Size = new System.Drawing.Size(23, 22);
            this.tsbtRemoveRow.Text = "del";
            this.tsbtRemoveRow.Click += new System.EventHandler(this.tsbtRemoveRow_Click);
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.repeatToolStripMenuItem,
            this.toolStripSeparator4,
            this.uploadToolStripMenuItem,
            this.reloadToolStripMenuItem,
            this.clearToolStripMenuItem,
            this.saveToolStripMenuItem});
            this.toolStripDropDownButton1.Image = global::ToolSuite.Properties.Resources.cog_16px_1170420_easyicon_net;
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(29, 22);
            this.toolStripDropDownButton1.Text = "option";
            // 
            // repeatToolStripMenuItem
            // 
            this.repeatToolStripMenuItem.CheckOnClick = true;
            this.repeatToolStripMenuItem.Name = "repeatToolStripMenuItem";
            this.repeatToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
            this.repeatToolStripMenuItem.Text = "Repeat";
            this.repeatToolStripMenuItem.Click += new System.EventHandler(this.repeatToolStripMenuItem_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(116, 6);
            // 
            // uploadToolStripMenuItem
            // 
            this.uploadToolStripMenuItem.Image = global::ToolSuite.Properties.Resources.folder_open;
            this.uploadToolStripMenuItem.Name = "uploadToolStripMenuItem";
            this.uploadToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
            this.uploadToolStripMenuItem.Text = "Upload";
            this.uploadToolStripMenuItem.Click += new System.EventHandler(this.uploadToolStripMenuItem_Click);
            // 
            // reloadToolStripMenuItem
            // 
            this.reloadToolStripMenuItem.Name = "reloadToolStripMenuItem";
            this.reloadToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
            this.reloadToolStripMenuItem.Text = "Reload";
            this.reloadToolStripMenuItem.Click += new System.EventHandler(this.reloadToolStripMenuItem_Click);
            // 
            // clearToolStripMenuItem
            // 
            this.clearToolStripMenuItem.Name = "clearToolStripMenuItem";
            this.clearToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
            this.clearToolStripMenuItem.Text = "Clear";
            this.clearToolStripMenuItem.Click += new System.EventHandler(this.clearToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // metroGrid
            // 
            this.metroGrid.AllowUserToAddRows = false;
            this.metroGrid.AllowUserToDeleteRows = false;
            this.metroGrid.AllowUserToResizeColumns = false;
            this.metroGrid.AllowUserToResizeRows = false;
            this.metroGrid.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.metroGrid.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.metroGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.metroGrid.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.metroGrid.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            this.metroGrid.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.metroGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.metroGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.metroGrid.ColumnHeadersVisible = false;
            this.metroGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnCheck,
            this.ColumnCmd,
            this.ColumnDiscription});
            this.metroGrid.ContextMenuStrip = this.listMenu;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(136)))), ((int)(((byte)(136)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.metroGrid.DefaultCellStyle = dataGridViewCellStyle2;
            this.metroGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.metroGrid.EnableHeadersVisualStyles = false;
            this.metroGrid.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.metroGrid.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.metroGrid.Location = new System.Drawing.Point(0, 25);
            this.metroGrid.Name = "metroGrid";
            this.metroGrid.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.metroGrid.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.metroGrid.RowHeadersVisible = false;
            this.metroGrid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.metroGrid.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.metroGrid.RowTemplate.Height = 23;
            this.metroGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.metroGrid.Size = new System.Drawing.Size(245, 296);
            this.metroGrid.TabIndex = 2;
            this.metroGrid.UseCustomBackColor = true;
            this.metroGrid.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.metroGrid_CellDoubleClick);
            // 
            // ColumnCheck
            // 
            this.ColumnCheck.Frozen = true;
            this.ColumnCheck.HeaderText = "";
            this.ColumnCheck.MinimumWidth = 20;
            this.ColumnCheck.Name = "ColumnCheck";
            this.ColumnCheck.Width = 20;
            // 
            // ColumnCmd
            // 
            this.ColumnCmd.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnCmd.HeaderText = "cmd";
            this.ColumnCmd.Name = "ColumnCmd";
            this.ColumnCmd.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ColumnCmd.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ColumnDiscription
            // 
            this.ColumnDiscription.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnDiscription.HeaderText = "disc";
            this.ColumnDiscription.Name = "ColumnDiscription";
            this.ColumnDiscription.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ColumnDiscription.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // listMenu
            // 
            this.listMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.checkAll1ToolStripMenuItem,
            this.uncheck1ToolStripMenuItem,
            this.toolStripSeparator3,
            this.sendAll1ToolStripMenuItem,
            this.sendSelectionsToolStripMenuItem,
            this.sendCheckedToolStripMenuItem});
            this.listMenu.Name = "listMenu";
            this.listMenu.Size = new System.Drawing.Size(168, 120);
            // 
            // checkAll1ToolStripMenuItem
            // 
            this.checkAll1ToolStripMenuItem.Name = "checkAll1ToolStripMenuItem";
            this.checkAll1ToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.checkAll1ToolStripMenuItem.Text = "Check All";
            this.checkAll1ToolStripMenuItem.Click += new System.EventHandler(this.checkAllToolStripMenuItem_Click);
            // 
            // uncheck1ToolStripMenuItem
            // 
            this.uncheck1ToolStripMenuItem.Name = "uncheck1ToolStripMenuItem";
            this.uncheck1ToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.uncheck1ToolStripMenuItem.Text = "Uncheck";
            this.uncheck1ToolStripMenuItem.Click += new System.EventHandler(this.uncheckToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(164, 6);
            // 
            // sendAll1ToolStripMenuItem
            // 
            this.sendAll1ToolStripMenuItem.Name = "sendAll1ToolStripMenuItem";
            this.sendAll1ToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.sendAll1ToolStripMenuItem.Text = "Send All";
            this.sendAll1ToolStripMenuItem.Click += new System.EventHandler(this.sendAllToolStripMenuItem_Click);
            // 
            // sendSelectionsToolStripMenuItem
            // 
            this.sendSelectionsToolStripMenuItem.Name = "sendSelectionsToolStripMenuItem";
            this.sendSelectionsToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.sendSelectionsToolStripMenuItem.Text = "Send Selections";
            this.sendSelectionsToolStripMenuItem.Click += new System.EventHandler(this.sendSelectionsToolStripMenuItem_Click);
            // 
            // sendCheckedToolStripMenuItem
            // 
            this.sendCheckedToolStripMenuItem.Name = "sendCheckedToolStripMenuItem";
            this.sendCheckedToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.sendCheckedToolStripMenuItem.Text = "Send Checked";
            this.sendCheckedToolStripMenuItem.Click += new System.EventHandler(this.sendCheckedToolStripMenuItem_Click);
            // 
            // listViewContextMenu
            // 
            this.listViewContextMenu.Name = "listViewContextMenu";
            this.listViewContextMenu.Size = new System.Drawing.Size(61, 4);
            // 
            // highQualityImageList
            // 
            imageItem1.Image = global::ToolSuite.Properties.Resources.edit;
            imageItem1.Text = "imageItem";
            imageItem2.Image = global::ToolSuite.Properties.Resources.read_only;
            imageItem2.Text = "imageItem";
            this.highQualityImageList.ImageItems.Add(imageItem1);
            this.highQualityImageList.ImageItems.Add(imageItem2);
            // 
            // DummySolutionExplorer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(245, 322);
            this.Controls.Add(this.metroGrid);
            this.Controls.Add(this.toolStrip);
            this.DockAreas = ((WeifenLuo.WinFormsUI.Docking.DockAreas)(((WeifenLuo.WinFormsUI.Docking.DockAreas.DockLeft | WeifenLuo.WinFormsUI.Docking.DockAreas.DockRight) 
            | WeifenLuo.WinFormsUI.Docking.DockAreas.DockBottom)));
            this.HideOnClose = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DummySolutionExplorer";
            this.Padding = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.ShowHint = WeifenLuo.WinFormsUI.Docking.DockState.DockRight;
            this.TabText = "Solution";
            this.Text = "Solution";
            this.DockStateChanged += new System.EventHandler(this.DummySolutionExplorer_DockStateChanged);
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.metroGrid)).EndInit();
            this.listMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tsbtAddRow;
        private System.Windows.Forms.ToolStripButton tsbtRemoveRow;
        private MetroFramework.Controls.MetroContextMenu listViewContextMenu;
        private MetroFramework.Controls.MetroGrid metroGrid;
        private System.Windows.Forms.ToolStripButton tsbtEdit;
        private System.Windows.Forms.ToolStripButton tsbtView;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColumnCheck;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnCmd;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnDiscription;
        private System.Windows.Forms.ToolStripMenuItem clearToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem uploadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reloadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem repeatToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private ControlsLibrary.HighQualityImageList highQualityImageList;
        private System.Windows.Forms.ContextMenuStrip listMenu;
        private System.Windows.Forms.ToolStripMenuItem checkAll1ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem uncheck1ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem sendAll1ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sendSelectionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sendCheckedToolStripMenuItem;
    }
}