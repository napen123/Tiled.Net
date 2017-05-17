using System.Xml.Serialization;

namespace Tiled
{
    /// <summary>
    /// Represents a property. These are arbitrary and are meant for the user.
    /// </summary>
    public class TiledProperty
    {
        /// <summary>
        /// The type of properties.
        /// </summary>
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

        /// <summary>
        /// The property's name.
        /// </summary>
        [XmlAttribute("name")]
        public string Name;

        /// <summary>
        /// The property's type.
        /// </summary>
        [XmlAttribute("type")]
        public PropertyType Type = PropertyType.String;

        /// <summary>
        /// The property's value.
        /// </summary>
        [XmlAttribute("value")]
        public string Value;

        /// <summary>
        /// Nothing to see here. Used for serialization.
        /// </summary>
        /// <returns></returns>
        public bool ShouldSerializeType()
        {
            return Type != PropertyType.String;
        }
    }
}
