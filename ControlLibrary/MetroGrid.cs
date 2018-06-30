using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;


namespace ControlLibrary
{
    public partial class MetroGrid : DataGridView
    {
        #region Interface
        [Category("Metro Color")]
        public Color ColumnHeadersDefaultCellStyleBackColor
        {
            get
            {
                return this.ColumnHeadersDefaultCellStyle.BackColor;
            }
            set
            {
                this.ColumnHeadersDefaultCellStyle.BackColor = value;
            }
        }

        [Category("Metro Color")]
        public Color ColumnHeadersDefaultCellStyleForeColor
        {
            get
            {
                return this.ColumnHeadersDefaultCellStyle.ForeColor;
            }
            set
            {
                this.ColumnHeadersDefaultCellStyle.ForeColor = value;
            }
        }

        [Category("Metro Color")]
        public Color RowHeadersDefaultCellStyleBackColor
        {
            get
            {
                return this.RowHeadersDefaultCellStyle.BackColor;
            }
            set
            {
                this.RowHeadersDefaultCellStyle.BackColor = value;
            }
        }

        [Category("Metro Color")]
        public Color RowHeadersDefaultCellStyleForeColor
        {
            get
            {
                return this.RowHeadersDefaultCellStyle.ForeColor;
            }
            set
            {
                this.RowHeadersDefaultCellStyle.ForeColor = value;
            }
        }



        [Category("Metro Color")]
        public Color DefaultCellSelectionBackColor
        {
            get
            {
                return this.DefaultCellStyle.SelectionBackColor;
            }
            set
            {
                this.DefaultCellStyle.SelectionBackColor = value;
            }
        }

        [Category("Metro Color")]
        public Color DefaultCellSelectionForeColor
        {
            get
            {
                return this.DefaultCellStyle.SelectionForeColor;
            }
            set
            {
                this.DefaultCellStyle.SelectionForeColor = value;
            }
        }

        [Category("Metro Color")]
        public Color RowHeadersSelectionBackColor
        {
            get
            {
                return this.RowHeadersDefaultCellStyle.SelectionBackColor;
            }
            set
            {
                this.RowHeadersDefaultCellStyle.SelectionBackColor = value;
            }
        }

        [Category("Metro Color")]
        public Color RowHeadersSelectionForeColor
        {
            get
            {
                return this.RowHeadersDefaultCellStyle.SelectionForeColor;
            }
            set
            {
                this.RowHeadersDefaultCellStyle.SelectionForeColor = value;
            }
        }

        [Category("Metro Color")]
        public Color ColumnHeadersDefaultCellStyleSelectionBackColor
        {
            get
            {
                return this.ColumnHeadersDefaultCellStyle.SelectionBackColor;
            }
            set
            {
                this.ColumnHeadersDefaultCellStyle.SelectionBackColor = value;
            }
        }

        [Category("Metro Color")]
        public Color ColumnHeadersDefaultCellStyleSelectionForeColor
        {
            get
            {
                return this.ColumnHeadersDefaultCellStyle.SelectionForeColor;
            }
            set
            {
                this.ColumnHeadersDefaultCellStyle.SelectionForeColor = value;
            }
        }


        [Browsable(false)]
        [Category("Metro Behaviour")]
        [DefaultValue(true)]
        public bool UseSelectable
        {
            get { return GetStyle(ControlStyles.Selectable); }
            set { SetStyle(ControlStyles.Selectable, value); }
        }
        #endregion

        #region Properties
        float _offset = 0.2F;
        [DefaultValue(0.2F)]
        public float HighLightPercentage { get { return _offset; } set { _offset = value; } }

        public Color BorderColor { get; set; } = Color.Gainsboro;
        #endregion

        MetroDataGridHelper scrollhelper = null;
        MetroDataGridHelper scrollhelperH = null;


        public MetroGrid()
        {
            InitializeComponent();

            StyleGrid();

            this.Controls.Add(_vertical);
            this.Controls.Add(_horizontal);

            this.Controls.SetChildIndex(_vertical, 0);
            this.Controls.SetChildIndex(_horizontal, 1);

            _horizontal.BackColor = Color.FromArgb(0, 174, 219);
            _horizontal.Visible = false;
            _vertical.Visible = false;

            scrollhelper = new MetroDataGridHelper(_vertical, this);
            scrollhelperH = new MetroDataGridHelper(_horizontal, this, false);

            this.DoubleBuffered = true;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            if (BorderStyle == BorderStyle.FixedSingle)
            {
                using (Pen p = new Pen(BorderColor))
                {
                    Rectangle rect = new Rectangle(0, 0, Width - 1, Height - 1);
                    e.Graphics.DrawRectangle(p, rect);
                }
            }
        }

        protected override void OnColumnStateChanged(DataGridViewColumnStateChangedEventArgs e)
        {
            base.OnColumnStateChanged(e);
            if (e.StateChanged == DataGridViewElementStates.Visible)
            {
                scrollhelper.UpdateScrollbar();
                scrollhelperH.UpdateScrollbar();
            }
        }

        protected override void OnMouseWheel(MouseEventArgs e)
        {
            base.OnMouseWheel(e);
            if (this.RowCount > 1)
            {
                if (e.Delta > 0 && this.FirstDisplayedScrollingRowIndex > 0)
                {
                    this.FirstDisplayedScrollingRowIndex--;
                }
                else if (e.Delta < 0)
                {
                    this.FirstDisplayedScrollingRowIndex++;
                }
            }       
        }

        private void StyleGrid()
        {
            //this.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.CellBorderStyle = DataGridViewCellBorderStyle.None;
            this.EnableHeadersVisualStyles = false;
            this.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.BackColor = Color.White;
            this.BackgroundColor = Color.White;
            this.GridColor = Color.Gray;
            this.ForeColor = Color.Black;
            this.Font = new Font("SimSun", 10f, FontStyle.Regular, GraphicsUnit.Pixel);

            this.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.AllowUserToResizeRows = false;

            this.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            this.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(0, 174, 219);
            this.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

            this.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            this.RowHeadersDefaultCellStyle.BackColor = Color.FromArgb(0, 174, 219);
            this.RowHeadersDefaultCellStyle.ForeColor = Color.White;

            this.DefaultCellStyle.BackColor = Color.White;

            this.DefaultCellStyle.SelectionBackColor = Color.FromArgb(0, 174, 219);
            this.DefaultCellStyle.SelectionForeColor = Color.FromArgb(17, 17, 17);

            this.RowHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(0, 174, 219);
            this.RowHeadersDefaultCellStyle.SelectionForeColor = Color.White;

            this.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(0, 174, 219);
            this.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.FromArgb(17, 17, 17);
        }
    }

    public class MetroDataGridHelper
    {
        /// <summary>
        /// The associated scrollbar or scrollbar collector
        /// </summary>
        private ControlsLibrary.MetroScrollBar _scrollbar;

        /// <summary>
        /// Associated Grid
        /// </summary>
        private DataGridView _grid;

        /// <summary>
        /// if greater zero, scrollbar changes are ignored
        /// </summary>
        private int _ignoreScrollbarChange = 0;

        /// <summary>
        /// 
        /// </summary>
        private bool _ishorizontal = false;
        private HScrollBar hScrollbar = null;
        private VScrollBar vScrollbar = null;

        public MetroDataGridHelper(ControlsLibrary.MetroScrollBar scrollbar, DataGridView grid)
        {
            new MetroDataGridHelper(scrollbar, grid,true);
        }

        public MetroDataGridHelper(ControlsLibrary.MetroScrollBar scrollbar, DataGridView grid, bool vertical)
        {
            _scrollbar = scrollbar;
            _scrollbar.UseBarColor = true;
            _grid = grid;
            _ishorizontal = !vertical;

            foreach (var item in _grid.Controls)
            {
                if (item.GetType() == typeof(VScrollBar))
                {
                    vScrollbar = (VScrollBar)item;
                }

                if (item.GetType() == typeof(HScrollBar))
                {
                    hScrollbar = (HScrollBar)item;
                }
            }

            _grid.RowsAdded += new DataGridViewRowsAddedEventHandler(_grid_RowsAdded);
            _grid.UserDeletedRow += new DataGridViewRowEventHandler(_grid_UserDeletedRow);
            _grid.Scroll += new ScrollEventHandler(_grid_Scroll);
            _grid.Resize += new EventHandler(_grid_Resize);
            _grid.RowsRemoved += new DataGridViewRowsRemovedEventHandler(_grid_RowsRemoved);
            _scrollbar.Scroll += _scrollbar_Scroll;
            _scrollbar.ScrollbarSize = 17;

            UpdateScrollbar();
        }

        void _grid_Scroll(object sender, ScrollEventArgs e)
        {
            UpdateScrollbar();
        }

        void _grid_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            UpdateScrollbar();
        }

        void _grid_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            UpdateScrollbar();
        }

        private void _grid_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            UpdateScrollbar();
        }

        void _scrollbar_Scroll(object sender, System.Windows.Forms.ScrollEventArgs e)
        {
            if (_ignoreScrollbarChange > 0) return;

            if (_ishorizontal)
            {
                try
                {
                    hScrollbar.Value = _scrollbar.Value;
                    _grid.HorizontalScrollingOffset = _scrollbar.Value;
                }
                catch { }
            }
            else
            {
                if (_scrollbar.Value >= 0 && _scrollbar.Value < _grid.Rows.Count)
                {
                    _grid.FirstDisplayedScrollingRowIndex = _scrollbar.Value + (_scrollbar.Value == 1 ? -1 : 1) >= _grid.Rows.Count ? _grid.Rows.Count - 1 : _scrollbar.Value + (_scrollbar.Value == 1 ? -1 : 1);
                }
                else
                {
                    if (_scrollbar.Value >= _grid.Rows.Count)
                        _scrollbar.Value = _grid.Rows.Count;

                    if (_grid.Rows.Count > 0)
                    _grid.FirstDisplayedScrollingRowIndex = _scrollbar.Value -1;
                }
            }

            _grid.Invalidate();
        }

        private void BeginIgnoreScrollbarChangeEvents()
        {
            _ignoreScrollbarChange++;
        }

        private void EndIgnoreScrollbarChangeEvents()
        {
            if (_ignoreScrollbarChange > 0)
                _ignoreScrollbarChange--;
        }

        /// <summary>
        /// Updates the scrollbar values
        /// </summary>
        public void UpdateScrollbar()
        {
            if (_grid == null) return;
            try
            {
                BeginIgnoreScrollbarChangeEvents();

                if (_ishorizontal)
                {
                    int visibleCols = VisibleFlexGridCols();
                    _scrollbar.Maximum = hScrollbar.Maximum;
                    _scrollbar.Minimum = hScrollbar.Minimum;
                    _scrollbar.SmallChange = hScrollbar.SmallChange;
                    _scrollbar.LargeChange = hScrollbar.LargeChange;
                    _scrollbar.Location = new Point(0, _grid.Height - _scrollbar.ScrollbarSize);
                    _scrollbar.Width = _grid.Width - (vScrollbar.Visible ? _scrollbar.ScrollbarSize : 0);
                    _scrollbar.BringToFront();
                    _scrollbar.Visible = hScrollbar.Visible;
                    _scrollbar.Value = hScrollbar.Value == 0 ? 1 : hScrollbar.Value;
                }
                else
                {
                    int visibleRows = VisibleFlexGridRows();
                    _scrollbar.Maximum = _grid.RowCount;
                    _scrollbar.Minimum = 1;
                    _scrollbar.SmallChange = 1;
                    _scrollbar.LargeChange = Math.Max(1, visibleRows - 1);
                    _scrollbar.Value = _grid.FirstDisplayedScrollingRowIndex;
                    if (_grid.RowCount > 0 && _grid.Rows[_grid.RowCount - 1].Cells[0].Displayed)
                    {
                        _scrollbar.Value =  _grid.RowCount;
                    }
                    _scrollbar.Location = new Point(_grid.Width - _scrollbar.ScrollbarSize, 0);
                    _scrollbar.Height = _grid.Height - (hScrollbar.Visible ? _scrollbar.ScrollbarSize : 0);
                    _scrollbar.BringToFront();
                    _scrollbar.Visible = vScrollbar.Visible;
                }
            }
            finally
            {
                EndIgnoreScrollbarChangeEvents();
            }
        }

        /// <summary>
        /// Determine the current count of visible rows
        /// </summary>
        /// <returns></returns>
        private int VisibleFlexGridRows()
        {
            return _grid.DisplayedRowCount(true);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private int VisibleFlexGridCols()
        {
            return _grid.DisplayedColumnCount(true);
        }

        public bool VisibleVerticalScroll()
        {
            bool _return = false;

            if (_grid.DisplayedRowCount(true) < _grid.RowCount + (_grid.RowHeadersVisible ? 1 : 0))
            {
                _return = true;
            }

            return _return;
        }

        public bool VisibleHorizontalScroll()
        {
            bool _return = false;

            if (_grid.DisplayedColumnCount(true) < _grid.ColumnCount + (_grid.ColumnHeadersVisible ? 1 : 0))
            {
                _return = true;
            }

            return _return;
        }

        #region Events of interest

        void _grid_Resize(object sender, EventArgs e)
        {
            UpdateScrollbar();
        }

        void _grid_AfterDataRefresh(object sender, System.ComponentModel.ListChangedEventArgs e)
        {
            UpdateScrollbar();
        }
        #endregion
    }
}
