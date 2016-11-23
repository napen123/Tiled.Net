using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Tiled
{
    public class TiledTileLayer : TiledBaseLayer
    {
        [XmlAttribute("name")]
        public string Name;

        [XmlAttribute("x")]
        public int X;

        [XmlAttribute("y")]
        public int Y;

        [XmlAttribute("opacity")]
        public float Opacity = 1;

        [XmlAttribute("visible")]
        public int Visible = 1;

        [XmlAttribute("offsetx")]
        public int OffsetX;

        [XmlAttribute("offsety")]
        public int OffsetY;

        [XmlArray("properties")]
        [XmlArrayItem("property")]
        public List<TiledProperty> Properties;

        [XmlElement("data")]
        public TiledData Data;

        public bool ShouldSerializeX()
        {
            return X != 0;
        }

        public bool ShouldSerializeY()
        {
            return Y != 0;
        }

        public bool ShouldSerializeOpacity()
        {
            return Math.Abs(Opacity - 1f) > float.Epsilon;
        }

        public bool ShouldSerializeVisible()
        {
            return Visible == 0;
        }

        public bool ShouldSerializeOffsetX()
        {
            return OffsetX > 0;
        }

        public bool ShouldSerializeOffsetY()
        {
            return OffsetY > 0;
        }

        public bool ShouldSerializeProperties()
        {
            return Properties != null && Properties.Count > 0;
        }

        public bool ShouldSerializeData()
        {
            return Data != null;
        }
    }
}
