using System;
using System.Windows.Forms;
using System.ComponentModel;
using System.Collections.Generic;

namespace WeifenLuo.WinFormsUI.Docking
{
    [ProvideProperty("EnableVSStyle", typeof(ToolStrip))]
    public partial class VS2015ToolStripExtender : VisualStudioToolStripExtender
    {
        private class ToolStripProperties
        {
            private VsVersion version = VsVersion.Unknown;
            private readonly ToolStrip strip;
            private readonly Dictionary<ToolStripItem, string> menuText = new Dictionary<ToolStripItem, string>();
            

            public ToolStripProperties(ToolStrip toolstrip)
            {
                if (toolstrip == null) throw new ArgumentNullException("toolstrip");
                strip = toolstrip;

                if (strip is MenuStrip)
                    SaveMenuStripText();
            }

            public VsVersion VsVersion 
            {
                get { return this.version; }
                set
                {
                    this.version = value;
                    UpdateMenuText(this.version == VsVersion.Vs2012 || this.version == VsVersion.Vs2013 || this.version == VsVersion.Vs2015);
                }
            }

            private void SaveMenuStripText()
            {
                foreach (ToolStripItem item in strip.Items)
                    menuText.Add(item, item.Text);
            }

            public void UpdateMenuText(bool caps)
            {
                foreach (ToolStripItem item in menuText.Keys)
                {
                    var text = menuText[item];
                    item.Text = caps ? text.ToUpper() : text;
                }
            }
        }

        private readonly Dictionary<ToolStrip, ToolStripProperties> strips = new Dictionary<ToolStrip, ToolStripProperties>();

        public VS2015ToolStripExtender()
        {
            InitializeComponent();

            //base.VsVersion = VsVersion.Vs2015;
        }

        public VS2015ToolStripExtender(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        public void SetStyle(ToolStrip strip, ThemeBase theme)//VsVersion version, 
        {
            ToolStripProperties properties = null;
            VsVersion version = VsVersion.Vs2015;
            VisualStudioToolStripRenderer vsRenderer = (VisualStudioToolStripRenderer)theme.ToolStripRenderer;

            vsRenderer.Refresh();

            if (!strips.ContainsKey(strip))
            {
                properties = new ToolStripProperties(strip) { VsVersion = version };
                strips.Add(strip, properties);
            }
            else
            {
                properties = strips[strip];
            }

            if (theme == null)
            {
                if (DefaultRenderer != null)
                    strip.Renderer = DefaultRenderer;
            }
            else
            {
                theme.ApplyTo(strip);
            }
            properties.VsVersion = version;
        }
    }
}
