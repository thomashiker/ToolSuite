using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using FastColoredTextBoxNS;

namespace FastColoredTextBoxNS
{
    public partial class FindForm : MetroForm
    {
        private FastColoredTextBox tb;
        private bool firstSearch = true;
        private Place startPlace;

        public string FindText
        {
            get { return tbFind.Text; }
            set { tbFind.Text = value; }
        }


        public FindForm(FastColoredTextBox tb)
        {
            InitializeComponent();
            this.tb = tb;
        }

        public void SelectAll()
        {
            tbFind.SelectAll();
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            Hide();
            this.tb.Focus();
        }

        private void btNext_CheckedHander(object sender, EventArgs e)
        {
            if (btNext == sender)
            {
                btPrevious.Checked = !btNext.Checked;
            }
            else
            {
                btNext.Checked = !btPrevious.Checked;
            }
        }

        private void ShowFindInfo(int total, int line)
        {
            this.Title = line.ToString() + "/" + total.ToString();
        }

        #region find function

        private void Find()
        {
            if (btNext.Checked)
            {
                tb.FindNext(tbFind.Text);
            }
            else
            {
                tb.FindPrevious(tbFind.Text);
            }
        }

        public virtual void FindNext(string pattern)
        {
            tb.FindNext(pattern);
        }

        private void tbFind_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                tbFind.CustomButton.PerformClick();
                e.Handled = true;
                return;
            }
            if (e.KeyChar == '\x1b')
            {
                Hide();
                e.Handled = true;
                return;
            }
        }

        private void FindForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                Hide();
            }
            this.tb.Focus();
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

        protected override void OnActivated(EventArgs e)
        {
            try
            {
                tbFind.Focus();
                ResetSearch();
            }
            catch
            {
            }
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

        #endregion

        private void FindTextBox_ButtonClick(object sender, EventArgs e)
        {
            try
            {
                Find();
            }
            catch
            {
            }
        }
    }
}
