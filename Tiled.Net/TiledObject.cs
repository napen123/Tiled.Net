using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Tiled
{
    public class TiledObject
    {
        [XmlAttribute("id")]
        public int Id;

        [XmlAttribute("name")]
        public string Name;

        [XmlAttribute("type")]
        public string Type;

        [XmlAttribute("x")]
        public float X;

        [XmlAttribute("y")]
        public float Y;

        [XmlAttribute("width")]
        public float Width;

        [XmlAttribute("height")]
        public float Height;

        [XmlAttribute("rotation")]
        public float Rotation;

        [XmlIgnore] // TODO
        [XmlAttribute("gid")]
        public int GlobalId;

        [XmlAttribute("visible")]
        public int Visible = 1;

        [XmlArray("properties")]
        [XmlArrayItem("property")]
        public List<TiledProperty> Properties;

        [XmlElement("ellipse", typeof(TiledEllipse))]
        [XmlElement("polygon", typeof(TiledPolygon))]
        [XmlElement("polyline", typeof(TiledPolyline))]
        public TiledBaseObject Base;

        public bool ShouldSerializeName()
        {
            return !string.IsNullOrWhiteSpace(Name);
        }

        public bool ShouldSerializeType()
        {
            return !string.IsNullOrWhiteSpace(Type);
        }

        public bool ShouldSerializeRotation()
        {
            return Math.Abs(Rotation) > float.Epsilon;
        }
        
        public bool ShouldSerializeVisible()
        {
            return Visible == 0;
        }

        public bool ShouldSerializeProperties()
        {
            return Properties != null && Properties.Count > 0;
        }

        public bool ShouldSerializeBase()
        {
            return Base != null;
        }
    }
}
