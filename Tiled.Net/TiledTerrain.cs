using System.Collections.Generic;
using System.Xml.Serialization;

namespace Tiled
{
    public class TiledTerrain
    {
        [XmlAttribute("name")]
        public string Name;

        [XmlAttribute("tile")]
        public int Tile;

        [XmlArray("properties")]
        [XmlArrayItem("property")]
        public List<TiledProperty> Properties;

        public bool ShouldSerializeProperties()
        {
            return Properties != null && Properties.Count > 0;
        }
    }
}
