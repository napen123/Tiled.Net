using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;

namespace Tiled
{
    public class TiledObjectGroup : TiledBaseLayer
    {
        public enum DrawOrderType
        {
            [XmlEnum("index")]
            Index,

            [XmlEnum("topdown")]
            TopDown
        }

        [XmlIgnore]
        public TiledColor Color = new TiledColor(160, 160, 164);

        [XmlAttribute("color")]
        public string ColorHex
        {
            get { return Color.ToHex(false); }
            set { Color = TiledColor.FromHex(value); }
        }

        [XmlAttribute("opacity")]
        public int Opacity = 1;

        [XmlAttribute("visible")]
        public int Visible = 1;

        [XmlAttribute("offsetx")]
        public int OffsetX;

        [XmlAttribute("offsety")]
        public int OffsetY;

        [XmlAttribute("draworder")]
        public DrawOrderType DrawOrder = DrawOrderType.TopDown;

        [XmlArray("properties")]
        [XmlArrayItem("property")]
        public List<TiledProperty> Properties;

        [XmlElement("object")]
        public List<TiledObject> Objects;

        public TiledObject this[int id]
        {
            get { return Objects.FirstOrDefault(o => o.Id == id); }
            set
            {
                var i = Objects.FindIndex(o => o.Id == id);

                if (i == -1)
                    Objects.Add(value);
                else
                    Objects[i] = value;
            }
        }

        public TiledObject this[string name]
        {
            get { return Objects.FirstOrDefault(o => o.Name == name); }
            set
            {
                var i = Objects.FindIndex(o => o.Name == name);

                if (i == -1)
                    Objects.Add(value);
                else
                    Objects[i] = value;
            }
        }

        public bool ShouldSerializeColorHex()
        {
            return ColorHex != "#a0a0a4";
        }

        public bool ShouldSerializeOpacity()
        {
            return Opacity == 0;
        }

        public bool ShouldSerializeVisible()
        {
            return Visible == 0;
        }

        public bool ShouldSerializeOffsetX()
        {
            return OffsetX != 0;
        }

        public bool ShouldSerializeOffsetY()
        {
            return OffsetY != 0;
        }

        public bool ShouldSerializeDrawOrder()
        {
            return DrawOrder == DrawOrderType.Index;
        }

        public bool ShouldSerializeProperties()
        {
            return Properties != null && Properties.Count > 0;
        }

        public bool ShouldSerializeObjects()
        {
            return Objects != null && Objects.Count > 0;
        }
    }
}
