using System.Xml.Serialization;

namespace Tiled
{
    /// <summary>
    /// Represents a frame within a tile's animation (<see cref="TiledTile"/>).
    /// </summary>
    public class TiledAnimationFrame
    {
        /// <summary>
        /// The local tile ID of a tile within its parent tileset.
        /// </summary>
        [XmlAttribute("tileid")]
        public int TileId;

        /// <summary>
        /// How long (in milliseconds) this frame should be displayed
        /// before advancing to the next.
        /// </summary>
        [XmlAttribute("duration")]
        public int Duration;
    }
}
