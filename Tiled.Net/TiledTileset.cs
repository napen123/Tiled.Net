using System.Collections.Generic;
using System.Xml.Serialization;

namespace Tiled
{
    /// <summary>
    /// Represents a tileset.
    /// </summary>
    public class TiledTileset
    {
        /// <summary>
        /// The first global tile ID of this tileset. This maps to the first tile in this tileset.
        /// </summary>
        [XmlAttribute("firstgid")]
        public int FirstGlobalId;

        /// <summary>
        /// If this tileset is stored in an external TSX (Tile Set XML) file, this is the path to the file.
        /// </summary>
        [XmlAttribute("source")]
        public string Source;

        /// <summary>
        /// The name of this tileset.
        /// </summary>
        [XmlAttribute("name")]
        public string Name;

        /// <summary>
        /// The (maximum) width of the tiles in this tileset.
        /// </summary>
        [XmlAttribute("tilewidth")]
        public int TileWidth;

        /// <summary>
        /// The (maximum) height of the tiles in this tileset.
        /// </summary>
        [XmlAttribute("tileheight")]
        public int TileHeight;

        /// <summary>
        /// The spacing between the tiles in this tileset, in pixels.
        /// </summary>
        /// <remarks>Applies to the tileset image.</remarks>
        [XmlAttribute("spacing")]
        public int Spacing;

        /// <summary>
        /// The margin around the tiles in this tileset.
        /// </summary>
        /// <remarks>Applies to the tileset image.</remarks>
        [XmlAttribute("margin")]
        public int Margin;

        /// <summary>
        /// The number of tiles in this tileset.
        /// </summary>
        /// <remarks>Available since <see cref="TiledMap.Version"/> 0.13</remarks>
        [XmlAttribute("tilecount")]
        public int TileCount;

        /// <summary>
        /// The number of tile columns in the tileset.
        /// </summary>
        /// <remarks>
        /// For image collection tilesets it is editable and is used when displaying the tileset.
        /// <br />
        /// Available since <see cref="TiledMap.Version"/> 0.15
        /// </remarks>
        [XmlAttribute("columns")]
        public int Columns;

        /// <summary>
        /// Custom properties for the map. These are arbitrary and are meant for the user.
        /// </summary>
        /// <remarks>Available since <see cref="TiledMap.Version"/> 0.8</remarks>
        [XmlArray("properties")]
        [XmlArrayItem("property")]
        public List<TiledProperty> Properties;

        /// <summary>
        /// The offset to use when drawing a tile from this tileset.
        /// </summary>
        /// <remarks>
        /// When not present (<c>null</c>), no offset is applied.
        /// <br />
        /// Available since <see cref="TiledMap.Version"/> 0.8
        /// </remarks>
        [XmlElement("tileoffset")]
        public TiledTileOffset TileOffset;

        /// <summary>
        /// The tileset's image.
        /// </summary>
        [XmlElement("image")]
        public TiledImage Image;

        /// <summary>
        /// The types of terrain.
        /// </summary>
        /// <remarks>Available since <see cref="TiledMap.Version"/> 0.9</remarks>
        [XmlArray("terraintypes")]
        [XmlArrayItem("terrain")]
        public List<TiledTerrain> TerrainTypes;

        /// <summary>
        /// The tiles within this tileset.
        /// </summary>
        [XmlElement("tile")]
        public List<TiledTile> Tiles;

        /// <summary>
        /// Nothing to see here. Used for serialization.
        /// </summary>
        /// <returns></returns>
        public bool ShouldSerializeSource()
        {
            return !string.IsNullOrWhiteSpace(Source);
        }

        /// <summary>
        /// Nothing to see here. Used for serialization.
        /// </summary>
        /// <returns></returns>
        public bool ShouldSerializeSpacing()
        {
            return Spacing > 0;
        }

        /// <summary>
        /// Nothing to see here. Used for serialization.
        /// </summary>
        /// <returns></returns>
        public bool ShouldSerializeMargin()
        {
            return Margin > 0;
        }

        /// <summary>
        /// Nothing to see here. Used for serialization.
        /// </summary>
        /// <returns></returns>
        public bool ShouldSerializeColumns()
        {
            return Columns > 0;
        }

        /// <summary>
        /// Nothing to see here. Used for serialization.
        /// </summary>
        /// <returns></returns>
        public bool ShouldSerializeProperties()
        {
            return Properties != null && Properties.Count > 0;
        }

        /// <summary>
        /// Nothing to see here. Used for serialization.
        /// </summary>
        /// <returns></returns>
        public bool ShouldSerializeTileOffset()
        {
            return TileOffset != null;
        }

        /// <summary>
        /// Nothing to see here. Used for serialization.
        /// </summary>
        /// <returns></returns>
        public bool ShouldSerializeImage()
        {
            return Image != null;
        }

        /// <summary>
        /// Nothing to see here. Used for serialization.
        /// </summary>
        /// <returns></returns>
        public bool ShouldSerializeTerrainTypes()
        {
            return TerrainTypes != null && TerrainTypes.Count > 0;
        }

        /// <summary>
        /// Nothing to see here. Used for serialization.
        /// </summary>
        /// <returns></returns>
        public bool ShouldSerializeTiles()
        {
            return Tiles != null && Tiles.Count > 0;
        }
    }
}
