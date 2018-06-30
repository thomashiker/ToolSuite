using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Drawing;

namespace ControlsLibrary
{
    public partial class IconImage : Component
    {
        private Icon icon;

        public Icon Icon
        {
            get { return icon; }
            set { icon = value; }
        }

        public IconImage()
        {
            InitializeComponent();
        }

        public IconImage(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
    }
}
