using System.Collections.Generic;
using System.Xml.Serialization;

namespace Tiled
{
    public class TiledTileset
    {
        [XmlAttribute("firstgid")]
        public int FirstGlobalId;

        [XmlAttribute("source")]
        public string Source;

        [XmlAttribute("name")]
        public string Name;

        [XmlAttribute("tilewidth")]
        public int TileWidth;

        [XmlAttribute("tileheight")]
        public int TileHeight;

        [XmlAttribute("spacing")]
        public int Spacing;

        [XmlAttribute("margin")]
        public int Margin;

        [XmlAttribute("tilecount")]
        public int TileCount;

        [XmlAttribute("columns")]
        public int Columns;

        [XmlArray("properties")]
        [XmlArrayItem("property")]
        public List<TiledProperty> Properties;

        [XmlElement("tileoffset")]
        public TiledTileOffset TileOffset;

        [XmlElement("image")]
        public TiledImage Image;
        
        [XmlArray("terraintypes")]
        [XmlArrayItem("terrain")]
        public List<TiledTerrain> TerrainTypes;

        [XmlElement("tile")]
        public List<TiledTile> Tiles;

        public bool ShouldSerializeSource()
        {
            return !string.IsNullOrWhiteSpace(Source);
        }

        public bool ShouldSerializeSpacing()
        {
            return Spacing > 0;
        }

        public bool ShouldSerializeMargin()
        {
            return Margin > 0;
        }

        public bool ShouldSerializeColumns()
        {
            return Columns > 0;
        }

        public bool ShouldSerializeProperties()
        {
            return Properties != null && Properties.Count > 0;
        }

        public bool ShouldSerializeTileOffset()
        {
            return TileOffset != null;
        }

        public bool ShouldSerializeImage()
        {
            return Image != null;
        }

        public bool ShouldSerializeTerrainTypes()
        {
            return TerrainTypes != null && TerrainTypes.Count > 0;
        }

        public bool ShouldSerializeTiles()
        {
            return Tiles != null && Tiles.Count > 0;
        }
    }
}
