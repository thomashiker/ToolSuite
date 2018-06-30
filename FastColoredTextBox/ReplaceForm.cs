using System;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;



namespace FastColoredTextBoxNS
{
    public partial class ReplaceForm : MetroForm
    {
        private FastColoredTextBox tb;
        private bool firstSearch = true;
        private Place startPlace;
        private bool replaceShow = true;

        public ReplaceForm(FastColoredTextBox tb)
        {
            InitializeComponent();
            this.tb = tb;

            ReplaceShow = false;
            this.btShowReplace.Anchor = AnchorStyles.Top | AnchorStyles.Left;
        }

        private bool ReplaceShow
        {
            get { return replaceShow; }
            set
            {
                replaceShow = value;
                UpdateReplaceShow();
            }
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            //Close();
            Hide();
        }

        private void ShowFindInfo(int total, int line)
        {
            labelInfo.Text = line.ToString() + "/" + total.ToString();
        }

        private void ShowReplaceInfo(int total)
        {
            labelInfo.Text = total.ToString() + " replaced";
        }

        private void ShowReplaceAllInfo(int total)
        {
            labelInfo.Text = total.ToString() + " replaced";
        }

        private void btFindNext_Click(object sender, EventArgs e)
        {
            try
            {
                /*if (!Find(tbFind.Text))
                    MessageBox.Show("Not found");*/
                //Find(tbFind.Text);
                tb.FindNext(tbFind.Text);
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }
        }

        private void btFindPrevious_Click(object sender, EventArgs e)
        {
            try
            {
                /*if (!Find(tbFind.Text))
                    MessageBox.Show("Not found");*/
                FindPrevious(tbFind.Text);
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }
        }

        public List<Range> FindAll(string pattern)
        {
            var opt = cbMatchCase.Checked ? RegexOptions.None : RegexOptions.IgnoreCase;
            if (!cbRegex.Checked)
                pattern = Regex.Escape(pattern);
            if (cbWholeWord.Checked)
                pattern = "\\b" + pattern + "\\b";
            //
            var range = tb.Selection.IsEmpty ? tb.Range.Clone() : tb.Selection.Clone();
            //
            var list = new List<Range>();
            foreach (var r in range.GetRangesByLines(pattern, opt))
                list.Add(r);

            return list;
        }

        public bool Find(string pattern)
        {
            try
            {
                RegexOptions opt = cbMatchCase.Checked ? RegexOptions.None : RegexOptions.IgnoreCase;
                if (!cbRegex.Checked)
                    pattern = Regex.Escape(pattern);
                if (cbWholeWord.Checked)
                    pattern = "\\b" + pattern + "\\b";
                //
                Range range = tb.Selection.Clone();
                range.Normalize();

                //get count
                Range rangetmp = range.Clone();
                rangetmp.Start = new Place(0, 0);
                rangetmp.End = new Place(tb.GetLineLength(tb.LinesCount - 1), tb.LinesCount - 1);
                int total = rangetmp.GetRangesByLines(pattern, opt).Count();

                //
                if (firstSearch)
                {
                    startPlace = range.Start;
                    firstSearch = false;
                }
                //
                range.Start = range.End;
                if (range.Start >= startPlace)
                    range.End = new Place(tb.GetLineLength(tb.LinesCount - 1), tb.LinesCount - 1);
                else
                    range.End = startPlace;
                //
                IEnumerable<Range> ranges = range.GetRangesByLines(pattern, opt);
                ShowFindInfo(total, total - ranges.Count());
                foreach (var r in ranges)
                {
                    tb.Selection = r;
                    tb.DoSelectionVisible();
                    tb.Invalidate();
                    return true;
                }
                //
                if (range.Start >= startPlace && startPlace > Place.Empty)
                {
                    tb.Selection.Start = new Place(0, 0);
                    Find(pattern);
                    return true;
                }
                tb.Selection.Start = new Place(0, 0);
                //this.Title = "Not found";
            }
            catch (Exception ex)
            {
                //this.Title = ex.Message;
            }

            return true;
        }

        public virtual void FindPrevious(string pattern)
        {
            List<Range> ranges = null;
            Place end;
            try
            {
                RegexOptions opt = cbMatchCase.Checked ? RegexOptions.None : RegexOptions.IgnoreCase;/*match case*/

                if (cbWholeWord.Checked)
                    pattern = "\\b" + pattern + "\\b";/*match all*/
                //
                Range range = tb.Selection.Clone();
                range.Normalize();

                //get count
                Range rangetmp = range.Clone();
                rangetmp.Start = new Place(0, 0);
                rangetmp.End = new Place(tb.GetLineLength(tb.LinesCount - 1), tb.LinesCount - 1);
                int total = rangetmp.GetRangesByLines(pattern, opt).Count();

                //
                end = range.Start;
                range.Start = new Place(0, 0);
                range.End = end;
                //
                ranges = new List<Range>(range.GetRangesByLines(pattern, opt));
                ShowFindInfo(total, total - ranges.Count());

                ranges.Reverse();
                foreach (Range r in ranges)
                {
                    tb.Selection = r;
                    tb.DoSelectionVisible();
                    tb.Invalidate();
                    return;
                }
                //
                range.Start = range.End;
                range.End = new Place(tb.GetLineLength(tb.LinesCount - 1), tb.LinesCount - 1);
                //
                ranges = new List<Range>(range.GetRangesByLines(pattern, opt));
                ShowFindInfo(total, total - ranges.Count());

                ranges.Reverse();
                foreach (Range r in ranges)
                {
                    tb.Selection = r;
                    tb.DoSelectionVisible();
                    tb.Invalidate();
                    return;
                }
                //this.Title = "Not found";
            }
            catch (Exception ex)
            {
                //this.Title = ex.Message;
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                this.Close();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void ReplaceForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                Hide();
            }
            this.tb.Focus();
        }

        private void btReplace_Click(object sender, EventArgs e)
        {
            try
            {
                if (tb.SelectionLength != 0)
                    if (!tb.Selection.ReadOnly)
                        tb.InsertText(tbReplace.Text);
                btFindNext_Click(sender, null);
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }
        }

        private void btReplaceAll_Click(object sender, EventArgs e)
        {
            try
            {
                tb.Selection.BeginUpdate();

                //search
                var ranges = FindAll(tbFind.Text);
                //check readonly
                var ro = false;
                foreach (var r in ranges)
                    if (r.ReadOnly)
                    {
                        ro = true;
                        break;
                    }
                //replace
                if (!ro)
                    if (ranges.Count > 0)
                    {
                        tb.TextSource.Manager.ExecuteCommand(new ReplaceTextCommand(tb.TextSource, ranges, tbReplace.Text));
                        tb.Selection.Start = new Place(0, 0);
                    }
                //
                tb.Invalidate();
                ShowReplaceAllInfo(ranges.Count);
            }
            catch (Exception ex)
            {
               // MessageBox.Show(ex.Message);
            }
            tb.Selection.EndUpdate();
        }

        protected override void OnActivated(EventArgs e)
        {
            tbFind.Focus();
            ResetSearch();
        }

        void ResetSearch()
        {
            firstSearch = true;
        }

        private void cbMatchCase_CheckedChanged(object sender, EventArgs e)
        {
            ResetSearch();
        }

        private void UpdateReplaceShow()
        {
            if (replaceShow)
            {
                Height = this.MaximumSize.Height;
                btShowReplace.Text = "5";
            }
            else
            {
                Height = this.MinimumSize.Height;
                btShowReplace.Text = "6";
            }
            tbReplace.Visible = replaceShow;
            btReplace.Visible = replaceShow;
            btReplaceAll.Visible = replaceShow;
        }

        private void btShowReplace_Click(object sender, EventArgs e)
        {
            ReplaceShow = !ReplaceShow;
        }

        private void UpdateLocation()
        {
            if (null != tb)
            {
                int x = tb.Width - this.Width - 20;
                this.Location = tb.PointToScreen(new Point(x, 0));
            }
        }

        public virtual void OnLocationChanged()
        {
            UpdateLocation();
        }

        public void LocationChanged(object sender, EventArgs e)
        {
            UpdateLocation();
        }

        private bool LocationChangedInitialed = false;

        public void ShowAtTop(Form owner)
        {
            UpdateLocation();
            if (Visible)
                Visible = false;

            if (tb.ReadOnly)
            {
                ReplaceShow = false;
                btShowReplace.Enabled = false;
            }
            else
            {
                btShowReplace.Enabled = true;
            }

            if (!LocationChangedInitialed)
            {
                if (null != owner.ParentForm)
                {
                    owner.ParentForm.LocationChanged += LocationChanged;
                }
                else
                {
                    owner.LocationChanged += LocationChanged;
                }
                LocationChangedInitialed = true;
            }

            base.Show(owner);
        }
    }
}
