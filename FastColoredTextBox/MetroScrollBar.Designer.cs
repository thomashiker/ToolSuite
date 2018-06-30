﻿using System.Collections;
using System.ComponentModel;
using System.Windows.Forms.Design;

namespace FastColoredTextBoxNS
{
    [Designer(typeof(MetroScrollBarDesigner), typeof(ParentControlDesigner))]
    internal class MetroScrollBarDesigner : ControlDesigner
    {
        public override SelectionRules SelectionRules
        {
            get
            {
                PropertyDescriptor propDescriptor = TypeDescriptor.GetProperties(Component)["Orientation"];

                if (propDescriptor != null)
                {
                    MetroScrollOrientation orientation = (MetroScrollOrientation)propDescriptor.GetValue(Component);

                    if (orientation == MetroScrollOrientation.Vertical)
                    {
                        return SelectionRules.Visible | SelectionRules.Moveable | SelectionRules.BottomSizeable | SelectionRules.TopSizeable;
                    }

                    return SelectionRules.Visible | SelectionRules.Moveable | SelectionRules.LeftSizeable | SelectionRules.RightSizeable;
                }

                return base.SelectionRules;
            }
        }

        protected override void PreFilterProperties(IDictionary properties)
        {
            properties.Remove("Text");
            properties.Remove("BackgroundImage");
            properties.Remove("ForeColor");
            properties.Remove("ImeMode");
            properties.Remove("Padding");
            properties.Remove("BackgroundImageLayout");
            properties.Remove("BackColor");
            properties.Remove("Font");
            properties.Remove("RightToLeft");

            base.PreFilterProperties(properties);
        }
    }
}
