using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ControlsLibrary
{
    public partial class ImageItem
    {
        private Image item;
        private string text;

        public ImageItem()
        {
            text = "imageItem";
        }

        public ImageItem(Image image, string name)
        {
            Image = image;
            Text = name;
        }

        #region 属性
        [Localizable(true)]
        public Image Image
        {
            get { return item; }
            set { item = value; }
        }

        [Localizable(true)]
        public string Text
        {
            get { return text; }
            set { text = value; }
        }
        #endregion

        public override string ToString()
        {
            return Text;
        }
    }

    public partial class HighQualityImageList : Component
    {
        private List<ImageItem> ImageCollection = null;

        public HighQualityImageList()
        {
            ImageCollection = new List<ImageItem>();
        }

        public HighQualityImageList(List<ImageItem> collection)
        {
            ImageCollection = collection;
        }

        #region 属性
        public Image this[int index]
        {
            get { return ImageCollection[index].Image; }
            set { ImageCollection[index].Image = value; }
        }

        [Localizable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public new List<ImageItem> ImageItems
        {
            get { return ImageCollection; }
        }

        [Localizable(true)]
        public int Count
        {
            get { return ImageCollection.Count; }
        }
        #endregion

        public void Add(ImageItem item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }
            ImageCollection.Add(item);
        }

        public void Clear()
        {
            ImageCollection.Clear();
        }

        public void Remove(ImageItem item)
        {
            ImageCollection.Remove(item);
        }
    }
}
