using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace Cyotek.Windows.Forms
{
    public partial class CustomPalette : Component
    {
        private ColorCollection _colorCollection = new ColorCollection();
        private ColorGrid colorGrid;


        [Category("CustomPalette")]
        [Browsable(true)]
        public ColorGrid ColorGrid
        {
            get { return colorGrid; }
            set
            {
                colorGrid = value;
                PaletteUpload();
            }
        }

        [Category("CustomPalette")]
        [Browsable(true)]
        public ColorCollection ColorCollection
        {
            get { return _colorCollection; }
            set
            {
                _colorCollection = value;
            }
        }

        public CustomPalette()
        {
            InitializeComponent();

            ColorCollection.CollectionChanged += ColorCollectionChanged;
        }

        public CustomPalette(IContainer container)
        {
            container.Add(this);

            InitializeComponent();

            ColorCollection.CollectionChanged += ColorCollectionChanged;
        }

        private void ColorCollectionChanged(object sender, ColorCollectionEventArgs e)
        {
            PaletteUpload();
        }

        private void PaletteUpload()
        {
            // we can only display 96 colors in the color grid due to it's size, so if there's more, bin them
            /*while (CustomCollection.Count > 96)
            {
                CustomCollection.RemoveAt(CustomCollection.Count - 1);
            }*/
            while (ColorCollection.Count > 96)
            {
                ColorCollection.RemoveAt(ColorCollection.Count - 1);
            }

            // or if we have less, fill in the blanks
            /* while (CustomCollection.Count < 96)
             {
                 CustomCollection.Add(Color.White);
             }*/

            if (null != colorGrid)
            {
                colorGrid.Colors.Clear();
                colorGrid.Colors = new ColorCollection(ColorCollection);// new ColorCollection(CustomCollection);
            }
            
        }
    }
}
