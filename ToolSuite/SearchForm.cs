using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;

using MetroFramework;
using MetroFramework.Forms;

using FastColoredTextBoxNS;

namespace ToolSuite
{
    public partial class SearchForm : MetroCForm
    {
        private bool firstSearch = true;
        private Place startPlace;
        private Form ParentForm;

        private int Parent_X;
        private int Parent_Y;


        public FastColoredTextBox FCTB { get; set; }
        public string FindText
        {
            get { return tbFind.Text; }
            set { tbFind.Text = value; }
        }


        /*public SearchForm()
        {
            InitializeComponent();
        }*/

        public SearchForm(Form parent)
        {
            InitializeComponent();

            ParentForm = parent;
            Parent_X = ParentForm.Location.X;
            Parent_Y = ParentForm.Location.Y;

            parent.LocationChanged += LocationChanged;
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            Hide();
        }


        private void Find()
        {
            if (cbNext.Checked)
            {
                FCTB.FindNext(FindText);
            }
            else
            {
                FCTB.FindPrevious(FindText);
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

        private void SearchForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                Hide();
            }
            FCTB?.Focus();
        }

        private void tbFind_KeyDown(object sender, KeyEventArgs e)
        {
            if (Keys.Enter == e.KeyCode)
            {
                Find();
                e.Handled = true;
            }
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

        private void UpdateLocation()
        {
            if (null != ParentForm)
            {
                int X = ParentForm.Location.X - Parent_X;
                int y = ParentForm.Location.Y - Parent_Y;

                Parent_X = ParentForm.Location.X;
                Parent_Y = ParentForm.Location.Y;
                this.Location = new Point(Location.X + X, Location.Y + y);// tb.PointToScreen(new Point(x, 0));
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

        public void ShowFind()
        {
            try
            {
                if (!FCTB.Selection.IsEmpty && FCTB.Selection.Start.iLine == FCTB.Selection.End.iLine)
                {
                    FindText = FCTB.Selection.Text;
                }

                base.Show(ParentForm);
            }
            catch
            {

            }
        }

        private void cbNext_CheckedHander(object sender, EventArgs e)
        {
            if (cbNext == sender)
            {
                cbPrevious.Checked = !cbNext.Checked;
            }
            else
            {
                cbNext.Checked = !cbPrevious.Checked;
            }
            tbFind.CustomButton.Image = cbNext.Checked ? cbNext.Image : cbPrevious.Image;
        }

        private void tbFind_ButtonClick(object sender, EventArgs e)
        {
            Find();
        }

        private void btFindAll_Click(object sender, EventArgs e)
        {
            FCTB.FindAll(FindText);

            Range range;
            //range.
        }
    }
}
