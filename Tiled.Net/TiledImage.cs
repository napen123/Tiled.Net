using System.Xml.Serialization;

namespace Tiled
{
    public class TiledImage
    {
        [XmlAttribute("format")]
        public string Format;

        [XmlAttribute("source")]
        public string Source;

        [XmlIgnore]
        public TiledColor TransparentColor;

        [XmlAttribute("trans")]
        public string TransparentColorHex
        {
            get { return TransparentColor.ToTrans(); }
            set { TransparentColor = TiledColor.FromTrans(value); }
        }

        [XmlAttribute("width")]
        public int Width;

        [XmlAttribute("height")]
        public int Height;

        [XmlElement("data")]
        public TiledData Data;

        public bool ShouldSerializeTransparentColorHex()
        {
            return TransparentColor != null;
        }

        public bool ShouldSerializeWidth()
        {
            return Width > 0;
        }

        public bool ShouldSerializeHeight()
        {
            return Height > 0;
        }

        public bool ShouldSerializeData()
        {
            return Data != null;
        }
    }
}
