using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MetroFramework.Forms;
using MetroFramework.Controls;
using WeifenLuo.WinFormsUI.Docking;
using Cyotek.Windows.Forms;
using System.IO;

namespace ToolSuite
{
    public partial class PaletteDialog : MetroCForm
    {
        private ColorCollection colors = new ColorCollection();
        public Color SelectedColor
        {
            get { return colorEditorManager.Color; }
            set { colorEditorManager.Color = value; }
        }

        public PaletteDialog()
        {
            InitializeComponent();

            for (int i = 0; i < 32; i++)
            colors.Add(Color.Red);
            PaletteUpload();
        }

        private void PaletteUpload()
        {
            // we can only display 96 colors in the color grid due to it's size, so if there's more, bin them
            /*while (CustomCollection.Count > 96)
            {
                CustomCollection.RemoveAt(CustomCollection.Count - 1);
            }*/
            while (colors.Count > 96)
            {
                colors.RemoveAt(customPalette.ColorCollection.Count - 1);
            }

            // or if we have less, fill in the blanks
            /* while (CustomCollection.Count < 96)
             {
                 CustomCollection.Add(Color.White);
             }*/

            if (null != colorGrid)
            {
                colorGrid.Colors.Clear();
                //colorGrid.Colors.AddRange(customPalette.ColorCollection);
                colorGrid.Colors = colors;// new ColorCollection(CustomCollection);
            }

        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Hide();
            //this.Owner.Focus();
        }

        private void btOK_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            this.Hide();
        }
    }
}
