using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Tiled
{
    public class TiledTile
    {
        public enum TerrainType
        {
            NoTerrain,

            [XmlEnum("top-left")]
            TopLeft,

            [XmlEnum("top-right")]
            TopRight,

            [XmlEnum("bottom-left")]
            BottomLeft,

            [XmlEnum("bottom-right")]
            BottomRight
        }

        [XmlAttribute("id")]
        public int Id;

        [XmlAttribute("terrain")]
        public TerrainType Terrain;

        [XmlAttribute("probability")]
        public float Probability = 1;

        [XmlArray("properties")]
        [XmlArrayItem("property")]
        public List<TiledProperty> Properties;
        
        public bool ShouldSerializeTerrain()
        {
            return Terrain != TerrainType.NoTerrain;
        }

        public bool ShouldSerializeProbability()
        {
            return Math.Abs(Probability - 1.0f) > float.Epsilon;
        }

        public bool ShouldSerializeProperties()
        {
            return Properties != null && Properties.Count > 0;
        }
    }
}
