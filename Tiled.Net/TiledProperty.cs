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
        /// <remarks>
        /// <see cref="File"/> is available since <see cref="TiledMap.Version"/> 0.17
        /// <br />
        /// <see cref="Color"/> is available since <see cref="TiledMap.Version"/> 0.16
        /// </remarks>
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
        /// <remarks>
        /// Boolean properties have a value of either <c>true</c> or <c>false</c>.
        /// <br />
        /// Color properties are stored in the format <c>#AARRGGBB</c>.
        /// <br />
        /// <see cref="File"/> is available since <see cref="TiledMap.Version"/> 0.17
        /// <br />
        /// <see cref="Color"/> is available since <see cref="TiledMap.Version"/> 0.16
        /// </remarks>
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
