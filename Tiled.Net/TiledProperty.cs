using System.Xml.Serialization;

namespace Tiled
{
    public class TiledProperty
    {
        public enum PropertyType
        {
            [XmlEnum("string")]
            String,

            [XmlEnum("int")]
            Int,

            [XmlEnum("float")]
            Float,

            [XmlEnum("bool")]
            Bool,

            [XmlEnum("color")]
            Color,

            [XmlEnum("file")]
            File
        }

        [XmlAttribute("name")]
        public string Name;

        [XmlAttribute("type")]
        public PropertyType Type = PropertyType.String;

        [XmlAttribute("value")]
        public string Value;

        public bool ShouldSerializeType()
        {
            return Type != PropertyType.String;
        }
    }
}
