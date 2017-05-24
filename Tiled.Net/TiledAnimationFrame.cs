using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Tiled
{
    /// <summary>
    /// Represents an animation for a tile (<see cref="TiledTile"/>).
    /// </summary>
    public class TiledAnimationFrame
    {
        /// <summary>
        /// The local tile ID within its tileset.
        /// </summary>
        [XmlAttribute("tileid")]
        public int Tile;

        /// <summary>
        /// The local tile ID within its tileset.
        /// </summary>
        [XmlAttribute("duration")]
        public int Duration;
    }
}
