using System.Xml.Serialization;

namespace Tiled
{
    /// <summary>
    /// The base class for layers (<see cref="TiledTileLayer"/>, <see cref="TiledObjectGroup"/>, and <see cref="TiledImageLayer"/>).
    /// </summary>
    [XmlInclude(typeof(TiledTileLayer))]
    [XmlInclude(typeof(TiledObjectGroup))]
    [XmlInclude(typeof(TiledImageLayer))]
    public abstract class TiledBaseLayer
    {
        /// <summary>
        /// The layer's name.
        /// </summary>
        [XmlAttribute("name")]
        public string Name;
    }
}
