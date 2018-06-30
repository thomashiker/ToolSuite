/**
* MetroSet UI - MetroSet UI Framewrok
*
* The MIT License (MIT)
* Copyright (c) 2017 Narwin, https://github.com/N-a-r-w-i-n
*
* Permission is hereby granted, free of charge, to any person obtaining a copy of
* this software and associated documentation files (the "Software"), to deal in the
* Software without restriction, including without limitation the rights to use, copy,
* modify, merge, publish, distribute, sublicense, and/or sell copies of the Software,
* and to permit persons to whom the Software is furnished to do so, subject to the
* following conditions:
*
* The above copyright notice and this permission notice shall be included in
* all copies or substantial portions of the Software.
*
* THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED,
* INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A
* PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT
* HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF
* CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE
* OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
*/

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;


using MetroFramework.Components;
using MetroFramework.Interfaces;
using MetroFramework.Drawing;
using MetroFramework.Native;


namespace MetroFramework.Controls
{
    public class MetroItemCollection : Collection<object>
    {

        /// <summary>
        /// An event for to determine whether and item or items added or removed.
        /// </summary>
        public event EventHandler ItemUpdated;
        public delegate void EventHandler(object sender, EventArgs e);

        /// <summary>
        /// Adds an array of items to the list of items for a MetroSetListBox.
        /// </summary>
        /// <param name="items">An IEnumerable of objects to add to the list.</param>
        public void AddRange(IEnumerable<object> items)
        {
            foreach (object item in items)
            {
                Add(item);
            }
        }

        /// <summary>
        /// Adds an item to the list of items for a MetroSetListBox.
        /// </summary>
        /// <param name="item">An object representing the item to add to the collection.</param>
        protected new void Add(object item)
        {
            base.Add(item);
            ItemUpdated(this, null);
        }

        /// <summary>
        /// Inserts an item into the list box at the specified index.
        /// </summary>
        /// <param name="index">The zero-based index location where the item is inserted.</param>
        /// <param name="item">An object representing the item to insert.</param>
        protected override void InsertItem(int index, object item)
        {
            base.InsertItem(index, item);
            ItemUpdated(this, null);
        }

        /// <summary>
        /// Removes the specified object from the collection.
        /// </summary>
        /// <param name="value">An object representing the item to remove from the collection.</param>
        protected override void RemoveItem(int value)
        {
            base.RemoveItem(value);
            ItemUpdated(this, null);
        }

        /// <summary>
        /// Removes all items from the collection.
        /// </summary>
        protected new void Clear()
        {
            base.Clear();
            ItemUpdated(this, null);
        }

        /// <summary>
        /// Removes all items from the collection.
        /// </summary>
        protected override void ClearItems()
        {
            base.ClearItems();
            ItemUpdated(this, null);
        }
    }

    public enum ScrollOrientate
    {
        /// <summary>
        /// Sets the scrollbar on horizontal orientation.
        /// </summary>
        Horizontal,

        /// <summary>
        /// Sets the scrollbar on vertical orientation.
        /// </summary>
        Vertical
    }

    [ToolboxItem(true)] 
    [ToolboxBitmap(typeof(MetroListBox), "Bitmaps.ListBox.bmp")]
    //[Designer(typeof(MetroListBoxDesigner))]
    [DefaultProperty("Items")]
    [DefaultEvent("SelectedIndexChanged")]
    [ComVisible(true)]
    [ClassInterface(ClassInterfaceType.AutoDispatch)]
    public class MetroListBox : Control, IMetroControl
    {

        #region Interface

        [Category(MetroDefaults.PropertyCategory.Appearance)]
        public event EventHandler<MetroPaintEventArgs> CustomPaintBackground;
        protected virtual void OnCustomPaintBackground(MetroPaintEventArgs e)
        {
            if (GetStyle(ControlStyles.UserPaint) && CustomPaintBackground != null)
            {
                CustomPaintBackground(this, e);
            }
        }

        [Category(MetroDefaults.PropertyCategory.Appearance)]
        public event EventHandler<MetroPaintEventArgs> CustomPaint;
        protected virtual void OnCustomPaint(MetroPaintEventArgs e)
        {
            if (GetStyle(ControlStyles.UserPaint) && CustomPaint != null)
            {
                CustomPaint(this, e);
            }
        }

        [Category(MetroDefaults.PropertyCategory.Appearance)]
        public event EventHandler<MetroPaintEventArgs> CustomPaintForeground;
        protected virtual void OnCustomPaintForeground(MetroPaintEventArgs e)
        {
            if (GetStyle(ControlStyles.UserPaint) && CustomPaintForeground != null)
            {
                CustomPaintForeground(this, e);
            }
        }

        private MetroColorStyle metroStyle = MetroColorStyle.Default;
        [Category(MetroDefaults.PropertyCategory.Appearance)]
        [DefaultValue(MetroColorStyle.Default)]
        public MetroColorStyle Style
        {
            get
            {
                if (DesignMode || metroStyle != MetroColorStyle.Default)
                {
                    return metroStyle;
                }

                if (StyleManager != null && metroStyle == MetroColorStyle.Default)
                {
                    return StyleManager.Style;
                }
                if (StyleManager == null && metroStyle == MetroColorStyle.Default)
                {
                    return MetroDefaults.Style;
                }

                return metroStyle;
            }
            set { metroStyle = value; }
        }

        private MetroThemeStyle metroTheme = MetroThemeStyle.Default;
        [Category(MetroDefaults.PropertyCategory.Appearance)]
        [DefaultValue(MetroThemeStyle.Default)]
        public MetroThemeStyle Theme
        {
            get
            {
                if (DesignMode || metroTheme != MetroThemeStyle.Default)
                {
                    return metroTheme;
                }

                if (StyleManager != null && metroTheme == MetroThemeStyle.Default)
                {
                    return StyleManager.Theme;
                }
                if (StyleManager == null && metroTheme == MetroThemeStyle.Default)
                {
                    return MetroDefaults.Theme;
                }

                return metroTheme;
            }
            set { metroTheme = value; }
        }

        private MetroStyleManager metroStyleManager = null;
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public MetroStyleManager StyleManager
        {
            get { return metroStyleManager; }
            set { metroStyleManager = value; }
        }

        private bool useCustomBackColor = false;
        [DefaultValue(false)]
        [Category(MetroDefaults.PropertyCategory.Appearance)]
        public bool UseCustomBackColor
        {
            get { return useCustomBackColor; }
            set { useCustomBackColor = value; }
        }

        private bool _useCustomForeColor = false;
        [DefaultValue(false)]
        [Category(MetroDefaults.PropertyCategory.Appearance)]
        public bool UseCustomForeColor
        {
            get { return _useCustomForeColor; }
            set { _useCustomForeColor = value; }
        }

        private bool useStyleColors = false;
        [DefaultValue(false)]
        [Category(MetroDefaults.PropertyCategory.Appearance)]
        public bool UseStyleColors
        {
            get { return useStyleColors; }
            set { useStyleColors = value; }
        }

        [Browsable(false)]
        [Category(MetroDefaults.PropertyCategory.Behaviour)]
        [DefaultValue(false)]
        public bool UseSelectable
        {
            get { return GetStyle(ControlStyles.Selectable); }
            set { SetStyle(ControlStyles.Selectable, value); }
        }

        #endregion

        #region Internal Vars

        public MetroItemCollection _Items;
        private List<object> _SelectedItems;
        private List<object> _Indicates;
        private bool _MultiSelect;
        private int _SelectedIndex;
        private string _SelectedItem;
        private bool _ShowScrollBar;
        private bool _MultiKeyDown;
        private int _HoveredItem;

        public MetroScrollBar SVS;

        #endregion Internal Vars

        #region Constructors

        public MetroListBox()
        {
            SetStyle(
                ControlStyles.UserPaint |
                ControlStyles.AllPaintingInWmPaint |
                ControlStyles.Selectable |
                ControlStyles.ResizeRedraw |
                ControlStyles.OptimizedDoubleBuffer |
                ControlStyles.SupportsTransparentBackColor, true);
            DoubleBuffered = true;
            UpdateStyles();
            BackColor = Color.Transparent;
            Font = new Font("SimSun", 9);

            ApplyTheme(0);
            SetDefaults();
        }

        private void SetDefaults()
        {
            SelectedIndex = -1;
            _HoveredItem = -1;
            _ShowScrollBar = false;
            _Items = new MetroItemCollection();
            _Items.ItemUpdated += InvalidateScroll;
            _SelectedItems = new List<object>();
            _Indicates = new List<object>();
            ItemHeight = 30;
            _MultiKeyDown = false;
            SVS = new MetroScrollBar()
            {
                Orientation = MetroScrollOrientation.Vertical,
                Size = new Size(12, Height),
                Maximum = _Items.Count * ItemHeight,
                SmallChange = 1,
                LargeChange = 5
            };
            SVS.Scroll += HandleScroll;
            SVS.MouseDown += VS_MouseDown;
            SVS.BackColor = Color.Transparent;
            SVS.StyleManager = StyleManager;
            if (!Controls.Contains(SVS))
            {
                Controls.Add(SVS);
            }
        }

        #endregion Constructors

        #region ApplyTheme

        /// <summary>
        /// Gets or sets the style provided by the user.
        /// </summary>
        /// <param name="style">The Style.</param>
        internal void ApplyTheme(int style)// = Style.Light
        {
            switch (style)
            {
                case 0://Style.Light
                    ForeColor = Color.Black;
                    BackColor = Color.White;
                    SelectedItemBackColor = Color.FromArgb(65, 177, 225);
                    SelectedItemColor = Color.White;
                    HoveredItemColor = Color.DimGray;
                    HoveredItemBackColor = Color.LightGray;
                    DisabledBackColor = Color.FromArgb(204, 204, 204);
                    DisabledForeColor = Color.FromArgb(136, 136, 136);
                    BorderColor = Color.LightGray;
                    UpdateProperties();
                    break;

                case 1://Style.Dark
                    ForeColor = Color.FromArgb(170, 170, 170);
                    BackColor = Color.FromArgb(30, 30, 30);
                    SelectedItemBackColor = Color.FromArgb(65, 177, 225);
                    SelectedItemColor = Color.White;
                    HoveredItemColor = Color.DimGray;
                    HoveredItemBackColor = Color.LightGray;
                    DisabledBackColor = Color.FromArgb(80, 80, 80);
                    DisabledForeColor = Color.FromArgb(109, 109, 109);
                    BorderColor = Color.FromArgb(64, 64, 64);
                    UpdateProperties();
                    break;

                /*case 2://Style.Custom
                    if (StyleManager != null)
                        foreach (var varkey in StyleManager.ListBoxDictionary)
                        {
                            switch (varkey.Key)
                            {

                                case "ForeColor":
                                    ForeColor = utl.HexColor((string)varkey.Value);
                                    break;

                                case "BackColor":
                                    BackColor = utl.HexColor((string)varkey.Value);
                                    break;

                                case "DisabledBackColor":
                                    DisabledBackColor = utl.HexColor((string)varkey.Value);
                                    break;

                                case "DisabledForeColor":
                                    DisabledForeColor = utl.HexColor((string)varkey.Value);
                                    break;

                                case "HoveredItemBackColor":
                                    HoveredItemBackColor = utl.HexColor((string)varkey.Value);
                                    break;

                                case "HoveredItemColor":
                                    HoveredItemColor = utl.HexColor((string)varkey.Value);
                                    break;

                                case "SelectedItemBackColor":
                                    SelectedItemBackColor = utl.HexColor((string)varkey.Value);
                                    break;

                                case "SelectedItemColor":
                                    SelectedItemColor = utl.HexColor((string)varkey.Value);
                                    break;

                                case "BorderColor":
                                    BorderColor = utl.HexColor((string)varkey.Value);
                                    break;

                                default:
                                    return;
                            }
                        }
                    UpdateProperties();
                    break;*/
            }
        }

        public void UpdateProperties()
        {
            Invalidate();
        }

        #endregion ApplyTheme

        #region Draw Control

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics G = e.Graphics;
            G.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            Rectangle mainRect = new Rectangle(0, 0, Width - (ShowBorder ? 1 : 0), Height - (ShowBorder ? 1 : 0));

            using (SolidBrush BG = new SolidBrush(Enabled ? BackColor : DisabledBackColor))
            {
                using (SolidBrush USIC = new SolidBrush(Enabled ? ForeColor : DisabledForeColor))
                {
                    using (SolidBrush SIC = new SolidBrush(SelectedItemColor))
                    {
                        Color itemBackColor = (null == StyleManager) ? SelectedItemBackColor : MetroPaint.GetStyleColor(StyleManager.Style);
                        using (SolidBrush SIBC = new SolidBrush(itemBackColor))
                        {
                            using (SolidBrush HIC = new SolidBrush(HoveredItemColor))
                            {
                                using (SolidBrush HIBC = new SolidBrush(HoveredItemBackColor))
                                {
                                    using (StringFormat SF = new StringFormat { Alignment = StringAlignment.Near, LineAlignment = StringAlignment.Center })
                                    {
                                        int FirstItem = (SVS.Value / ItemHeight) < 0 ? 0 : (SVS.Value / ItemHeight);
                                        int LastItem = (SVS.Value / ItemHeight) + (Height / ItemHeight) + 1 > Items.Count ? Items.Count : (SVS.Value / ItemHeight) + (Height / ItemHeight) + 1;

                                        G.FillRectangle(BG, mainRect);

                                        for (int i = FirstItem; i < LastItem; i++)
                                        {
                                            string itemText = (string)Items[i];

                                            Rectangle rect = new Rectangle(5, ((i - FirstItem) * ItemHeight), Width - 1, ItemHeight);
                                            G.DrawString(itemText, Font, USIC, rect, SF);
                                            if (MultiSelect && _Indicates.Count != 0)
                                            {
                                                if (i == _HoveredItem && !_Indicates.Contains(i))
                                                {
                                                    G.FillRectangle(HIBC, rect);
                                                    G.DrawString(itemText, Font, HIC, rect, SF);
                                                }
                                                else if (_Indicates.Contains(i))
                                                {
                                                    G.FillRectangle(SIBC, rect);
                                                    G.DrawString(itemText, Font, SIC, rect, SF);
                                                }
                                            }
                                            else
                                            {
                                                if (i == _HoveredItem && i != SelectedIndex)
                                                {
                                                    G.FillRectangle(HIBC, rect);
                                                    G.DrawString(itemText, Font, HIC, rect, SF);
                                                }
                                                else if (i == SelectedIndex)
                                                {
                                                    G.FillRectangle(SIBC, rect);
                                                    G.DrawString(itemText, Font, SIC, rect, SF);
                                                }
                                            }

                                        }
                                        if(ShowBorder)
                                        G.DrawRectangle(Pens.LightGray, mainRect);
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        #endregion Draw Control

        #region Properties

        /// <summary>
        /// Gets the items of the ListBox.
        /// </summary>
        [TypeConverter(typeof(CollectionConverter))]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [Editor("System.Windows.Forms.Design.StringCollectionEditor, System.Design", "System.Drawing.Design.UITypeEditor, System.Drawing")]
        [Category("MetroSet Framework"), Description("Gets the items of the ListBox.")]
        public MetroItemCollection Items
        {
            get { return _Items; }
        }

        /// <summary>
        /// Gets a collection containing the currently selected items in the ListBox.
        /// </summary>
        [Browsable(false)]
        [Category("MetroSet Framework"), Description("Gets a collection containing the currently selected items in the ListBox.")]
        public List<object> SelectedItems
        {
            get { return _SelectedItems; }
        }

        /// <summary>
        /// Gets or sets the height of an item in the ListBox.
        /// </summary>
        [Category("MetroSet Framework"), Description("Gets or sets the height of an item in the ListBox.")]
        public int ItemHeight { get; set; }

        /// <summary>
        /// Gets or sets the currently selected item in the ListBox.
        /// </summary>
        [Browsable(false), Category("MetroSet Framework"), Description("Gets or sets the currently selected item in the ListBox.")]
        public string SelectedItem
        {
            get { return _SelectedItem; }
            set
            {
                _SelectedItem = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the zero-based index of the currently selected item in a ListBox.
        /// </summary>
        [Browsable(false), Category("MetroSet Framework"), Description("Gets or sets the zero-based index of the currently selected item in a ListBox.")]
        public int SelectedIndex
        {
            get { return _SelectedIndex; }
            set
            {
                _SelectedIndex = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the ListBox supports multiple rows.
        /// </summary>
        [Category("MetroSet Framework"), Description("Gets or sets a value indicating whether the ListBox supports multiple rows.")]
        public bool MultiSelect
        {
            get { return _MultiSelect; }
            set
            {
                _MultiSelect = value;

                if (_SelectedItems.Count > 1)
                    _SelectedItems.RemoveRange(1, _SelectedItems.Count - 1);

                Invalidate();
            }
        }

        /// <summary>
        /// Gets the the number of items stored in items collection.
        /// </summary>
        [Browsable(false)]
        public int Count
        {
            get { return _Items.Count; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the vertical scroll bar is shown or not.
        /// </summary>
        [Category("MetroSet Framework"), Description("Gets or sets a value indicating whether the vertical scroll bar be shown or not.")]
        public bool ShowScrollBar
        {
            get { return _ShowScrollBar; }
            set
            {
                _ShowScrollBar = value;
                SVS.Visible = value ? true : false;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the border shown or not.
        /// </summary>
        [Category("MetroSet Framework"), Description("Gets or sets a value indicating whether the border shown or not.")]
        public bool ShowBorder { get; set; } = false;

        /// <summary>
        /// Gets or sets backcolor used by the control
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [Category("MetroSet Framework"), Description("Gets or sets backcolor used by the control.")]
        public override Color BackColor { get; set; }

        /// <summary>
        /// Gets or sets forecolor used by the control
        /// </summary>
        [Category("MetroSet Framework"), Description("Gets or sets forecolor used by the control.")]
        public override Color ForeColor { get; set; }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override string Text { get { return base.Text; } set { base.Text = value; } }

        /// <summary>
        /// Gets or sets selected item used by the control
        /// </summary>
        [Category("MetroSet Framework"), Description("Gets or sets selected item used by the control.")]
        public Color SelectedItemColor { get; set; }

        /// <summary>
        /// Gets or sets selected item backcolor used by the control
        /// </summary>
        [Category("MetroSet Framework"), Description("Gets or sets selected item backcolor used by the control.")]
        public Color SelectedItemBackColor { get; set; }

        /// <summary>
        /// Gets or sets hovered item used by the control
        /// </summary>
        [Category("MetroSet Framework"), Description("Gets or sets hovered item used by the control.")]
        public Color HoveredItemColor { get; set; }

        /// <summary>
        /// Gets or sets hovered item backcolor used by the control
        /// </summary>
        [Category("MetroSet Framework"), Description("Gets or sets hovered item backcolor used by the control.")]
        public Color HoveredItemBackColor { get; set; }

        /// <summary>
        /// Gets or sets disabled forecolor used by the control
        /// </summary>
        [Category("MetroSet Framework"), Description("Gets or sets disabled forecolor used by the control.")]
        public Color DisabledForeColor { get; set; }

        /// <summary>
        /// Gets or sets disabled backcolor used by the control
        /// </summary>
        [Category("MetroSet Framework"), Description("Gets or sets disabled backcolor used by the control.")]
        public Color DisabledBackColor { get; set; }

        /// <summary>
        /// Gets or sets border color used by the control
        /// </summary>
        [Category("MetroSet Framework"), Description("Gets or sets border color used by the control.")]
        public Color BorderColor { get; set; }

        #endregion Properties

        #region Methods

        /// <summary>
        /// Adds an item to collection.
        /// </summary>
        /// <param name="newItem">The Item to be added into the collection.</param>
        public void AddItem(string newItem)
        {
            _Items.Add(newItem);
            InvalidateScroll(this, null);
        }

        /// <summary>
        /// Adds the multiply items to collection.
        /// </summary>
        /// <param name="newItems">Items to be added into the collection.</param>
        public void AddItems(string[] newItems)
        {
            foreach (var str in newItems)
            {
                AddItem(str);
            }
            InvalidateScroll(this, null);
        }

        /// <summary>
        /// Removes the element at the specified index of the collection.
        /// </summary>
        /// <param name="index">The Index as the start point of removing.</param>
        public void RemoveItemAt(int index)
        {
            _Items.RemoveAt(index);
            InvalidateScroll(this, null);
        }

        /// <summary>
        /// Removes an item from collection.
        /// </summary>
        /// <param name="item">The Item to remove in collection.</param>
        public void RemoveItem(string item)
        {
            _Items.Remove(item);
            InvalidateScroll(this, null);
        }

        /// <summary>
        /// Gets the index of the item.
        /// </summary>
        /// <param name="value">The Item.</param>
        /// <returns>index of the item.</returns>
        public int IndexOf(string value)
        {
            return _Items.IndexOf(value);
        }

        /// <summary>
        /// Gets whether the collection cotnain a specific item.
        /// </summary>
        /// <param name="item">The Item to check whether exist in collection.</param>
        /// <returns>Whether the collection cotnain a specific item.</returns>
        public bool Contains(object item)
        {
            return _Items.Contains(item.ToString());
        }

        /// <summary>
        /// Removes multiply items in collection.
        /// </summary>
        /// <param name="itemsToRemove">Items to be removed in collection.</param>
        public void RemoveItems(string[] itemsToRemove)
        {
            foreach (string item in itemsToRemove)
            {
                _Items.Remove(item);
            }
            InvalidateScroll(this, null);
        }

        /// <summary>
        /// Clears the collection.
        /// </summary>
        public void Clear()
        {
            for (int i = _Items.Count - 1; i >= 0; i += -1)
            {
                _Items.RemoveAt(i);
            }
            InvalidateScroll(this, null);
        }

        #endregion Methods
                
        #region Events

        public event SelectedIndexChangedEventHandler SelectedIndexChanged;

        public delegate void SelectedIndexChangedEventHandler(object sender);

        /// <summary>
        /// Here we update the scrollbar and it's properties while user resizes the ListBox.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnSizeChanged(EventArgs e)
        {
            InvalidateScroll(this, e);
            InvalidateLayout();
            base.OnSizeChanged(e);
        }

        /// <summary>
        /// Here we will handle the selction item(s).
        /// </summary>
        /// <param name="e">MouseEventArgs</param>
        protected override void OnMouseDown(MouseEventArgs e)
        {
            Focus();
            if (e.Button == MouseButtons.Left)
            {
                int index = (SVS.Value / ItemHeight) + (e.Location.Y / ItemHeight);

                if (index >= 0 && index < _Items.Count)
                {
                    if (MultiSelect && _MultiKeyDown)
                    {
                        _Indicates.Add(index);
                        _SelectedItems.Add(Items[index]);
                    }
                    else
                    {
                        _Indicates.Clear();
                        _SelectedItems.Clear();
                        SelectedIndex = index;
                        SelectedIndexChanged?.Invoke(this);
                    }
                }
                Invalidate();
            }
            base.OnMouseDown(e);
        }

        /// <summary>
        /// The Method to update the scrollbar.
        /// </summary>
        /// <param name="sender">object</param>
        //private void HandleScroll(object sender)
        private void HandleScroll(object sender, ScrollEventArgs e)
        {
            Invalidate();
        }

        /// <summary>
        /// The Method to update the Scrollbar maximum property.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">EventArgs</param>
        public void InvalidateScroll(object sender, EventArgs e)
        {
            SVS.Maximum = (_Items.Count * ItemHeight);
            Invalidate();
        }

        /// <summary>
        /// Here here we put scrollbar on focus while mouse clicked.
        /// </summary>
        /// <param name="sender">object</param>
        /// <param name="e">MouseEventArgs</param>
        private void VS_MouseDown(object sender, MouseEventArgs e)
        {
            Focus();
        }

        /// <summary>
        /// The Method to update the size and locaion of the scrollbar.
        /// </summary>
        private void InvalidateLayout()
        {
            SVS.Size = new Size(12, Height - (ShowBorder ? 2 : 0));
            SVS.Location = new Point(Width - (SVS.Width + (ShowBorder ? 2 : 0)), (ShowBorder ? 1 : 0));
            Invalidate();
        }
        
        /// <summary>
        /// Here we handle the mouse wheel.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnMouseWheel(MouseEventArgs e)
        {
            SVS.Value -= (e.Delta / 4);
            base.OnMouseWheel(e);
        }
        
        /// <summary>
        /// Gets the Key that has been pressed by the user.
        /// </summary>
        /// <param name="keyData"></param>
        /// <returns>The Key that has been pressed.</returns>
        protected override bool IsInputKey(Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Down:
                    try
                    {
                        _SelectedItems.Remove(_Items[SelectedIndex]);
                        SelectedIndex += 1;
                        _SelectedItems.Add(_Items[SelectedIndex]);
                    }
                    catch { }
                    break;

                case Keys.Up:
                    try
                    {
                        _SelectedItems.Remove(_Items[SelectedIndex]);
                        SelectedIndex -= 1;
                        _SelectedItems.Add(_Items[SelectedIndex]);
                    }
                    catch { }
                    break;
            }
            Invalidate();
            return base.IsInputKey(keyData);
        }

        /// <summary>
        /// Here we set the handle the hovering.
        /// </summary>
        /// <param name="e">MouseEventArgs</param>
        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            Cursor = Cursors.Hand;
            int index = (SVS.Value / ItemHeight) + (e.Location.Y / ItemHeight);

            if (index >= Items.Count)
                index = -1;

            if (index >= 0 && index < Items.Count)
            {
                _HoveredItem = index;
            }
            Invalidate();
        }

        /// <summary>
        /// Here we release the mouse state and hovering item to avoid filckering.
        /// </summary>
        /// <param name="e">EventArgs</param>
        protected override void OnMouseLeave(EventArgs e)
        {
            _HoveredItem = -1;
            Cursor = Cursors.Default;
            Invalidate();
            base.OnMouseLeave(e);
        }

        /// <summary>
        /// Here we put the scrollbar on right of the list box and also update the the thumb size of the scrollbar.
        /// </summary>
        /// <param name="e">Events</param>
        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            SVS.Location = new Point(Width - (SVS.Width + (ShowBorder ? 2 : 0)), (ShowBorder ? 1 : 0));
            InvalidateScroll(this, e);            
        }

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessage(IntPtr hWnd, int Msg, int wParam, string lParam);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern IntPtr LoadCursor(IntPtr hInstance, int lpCursorName);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr SetCursor(IntPtr hCursor);

        public const int WM_SETCURSOR = 0x0020;
        public const int IDC_HAND = 32649;
        /// <summary>
        /// Here we set the smooth mouse hand.
        /// </summary>
        /// <param name="m"></param>
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WM_SETCURSOR)
            {
                SetCursor(LoadCursor(IntPtr.Zero, IDC_HAND));
                m.Result = IntPtr.Zero;
                return;
            }

            base.WndProc(ref m);
        }

        #endregion Events

    }
}