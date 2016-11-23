using System.Collections.Generic;
using System.Xml.Serialization;

namespace Tiled
{
    public class TiledImageLayer : TiledBaseLayer
    {
        [XmlAttribute("name")]
        public string Name;

        [XmlAttribute("offsetx")]
        public int OffsetX;

        [XmlAttribute("offsety")]
        public int OffsetY;

        [XmlAttribute("x")]
        public int X;

        [XmlAttribute("y")]
        public int Y;

        [XmlAttribute("opacity")]
        public float Opacity = 1;

        [XmlAttribute("visible")]
        public int Visible = 1;

        [XmlElement("image")]
        public TiledImage Image;
        
        [XmlArray("properties")]
        [XmlArrayItem("property")]
        public List<TiledProperty> Properties;

        public bool ShouldSerializeOpacity()
        {
            return Opacity < 1;
        }

        public bool ShouldSerializeVisible()
        {
            return Visible == 0;
        }

        public bool ShouldSerializeImage()
        {
            return Image != null;
        }

        public bool ShouldSerializeProperties()
        {
            return Properties != null && Properties.Count > 0;
        }
    }
}
