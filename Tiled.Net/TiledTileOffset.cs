using System.Xml.Serialization;

namespace Tiled
{
    /// <summary>
    /// Represents an offset to be applied when drawing a tile from the related tileset.
    /// </summary>
    /// <remarks>When not present, no offset is applied.</remarks>
    public class TiledTileOffset
    {
        /// <summary>
        /// The horizontal offset in pixels.
        /// </summary>
        [XmlAttribute("x")]
        public int X;

        /// <summary>
        /// The vertical offset in pixels (positive is down).
        /// </summary>
        [XmlAttribute("y")]
        public int Y;
    }
}
