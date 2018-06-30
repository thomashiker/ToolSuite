﻿namespace ControlLibrary
{
    partial class MetroGrid
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
            this._horizontal = new ControlsLibrary.MetroScrollBar();
            this._vertical = new ControlsLibrary.MetroScrollBar();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // _horizontal
            // 
            this._horizontal.LargeChange = 10;
            this._horizontal.Location = new System.Drawing.Point(0, 0);
            this._horizontal.Maximum = 100;
            this._horizontal.Minimum = 0;
            this._horizontal.MouseWheelBarPartitions = 10;
            this._horizontal.Name = "_horizontal";
            this._horizontal.Orientation = ControlsLibrary.MetroScrollOrientation.Horizontal;
            this._horizontal.ScrollbarSize = 50;
            this._horizontal.Size = new System.Drawing.Size(200, 50);
            this._horizontal.TabIndex = 0;
            // 
            // _vertical
            // 
            this._vertical.LargeChange = 10;
            this._vertical.Location = new System.Drawing.Point(0, 0);
            this._vertical.Maximum = 100;
            this._vertical.Minimum = 0;
            this._vertical.MouseWheelBarPartitions = 10;
            this._vertical.Name = "_vertical";
            this._vertical.Orientation = ControlsLibrary.MetroScrollOrientation.Vertical;
            this._vertical.ScrollbarSize = 50;
            this._vertical.Size = new System.Drawing.Size(50, 200);
            this._vertical.TabIndex = 0;
            // 
            // MetroGrid
            // 
            this.RowTemplate.Height = 23;
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private ControlsLibrary.MetroScrollBar _horizontal;
        private ControlsLibrary.MetroScrollBar _vertical;
    }
}
