using System;
using System.Windows.Forms;
using System.Drawing;


namespace FastColoredTextBoxNS
{
    public partial class GoToForm : MetroForm
    {
        public int SelectedLineNumber { get; set; }
        public int TotalLineCount { get; set; }

        public GoToForm()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            this.tbLineNum.Text = this.SelectedLineNumber.ToString();

            this.Title = String.Format("1 / {0}", this.TotalLineCount);
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            this.tbLineNum.Focus();
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        public void UpdateLocation(Control owner)
        {
            if (null != owner)
            {
                int x = owner.Width - this.Width - 20;
                this.Location = owner.PointToScreen(new Point(x, 0));
            }
        }

        private void tbLineNum_ButtonClick(object sender, EventArgs e)
        {
            int enteredLine;
            if (int.TryParse(this.tbLineNum.Text, out enteredLine))
            {
                enteredLine = Math.Min(enteredLine, this.TotalLineCount);
                enteredLine = Math.Max(1, enteredLine);

                this.SelectedLineNumber = enteredLine;
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void tbLineNum_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                tbLineNum.CustomButton.PerformClick();
                e.Handled = true;
                return;
            }

            if (!((e.KeyChar >= 48 && e.KeyChar <= 57) || e.KeyChar == 8))
            {
                e.Handled = true;
            }
        }
    }
}
