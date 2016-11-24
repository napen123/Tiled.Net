using System.Xml.Serialization;

namespace Tiled
{
    /// <summary>
    /// Represents a tile within a tile layer (<see cref="TiledTileLayer"/>).
    /// </summary>
    /// <remarks>Not to be confused with a tile within a tileset (<see cref="TiledTile"/>).</remarks>
    public class TiledTileData
    {
        /// <summary>
        /// The global tile ID.
        /// </summary>
        [XmlAttribute("gid")]
        public int GlobalId;
    }
}
