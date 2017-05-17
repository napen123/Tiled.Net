using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Tiled
{
    public class TiledImageLayer : TiledBaseLayer
    {
        [XmlAttribute("offsetx")]
        public int OffsetX;

        [XmlAttribute("offsety")]
        public int OffsetY;

        [Obsolete("Deprecated since 0.15")]
        [XmlAttribute("x")]
        public int X;

        [Obsolete("Deprecated since 0.15")]
        [XmlAttribute("y")]
        public int Y;

        [XmlIgnore]
        public int Width;

        [XmlIgnore]
        public int Height;

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
