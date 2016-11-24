using System.Collections.Generic;
using System.Xml.Serialization;

namespace Tiled
{
    /// <summary>
    /// Represents a type of terrain.
    /// </summary>
    public class TiledTerrain
    {
        /// <summary>
        /// The name of the terrain type.
        /// </summary>
        [XmlAttribute("name")]
        public string Name;

        /// <summary>
        /// The local tile-id of the tile that represents the terrain visually.
        /// </summary>
        [XmlAttribute("tile")]
        public int Tile;

        /// <summary>
        /// Custom properties for the terrain type. These are arbitrary and are meant for the user.
        /// </summary>
        [XmlArray("properties")]
        [XmlArrayItem("property")]
        public List<TiledProperty> Properties;

        /// <summary>
        /// Nothing to see here. Used for serialization.
        /// </summary>
        /// <returns></returns>
        public bool ShouldSerializeProperties()
        {
            return Properties != null && Properties.Count > 0;
        }
    }
}
