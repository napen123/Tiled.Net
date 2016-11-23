using System.Xml.Serialization;

namespace Tiled
{
    public class TiledTileData
    {
        [XmlAttribute("gid")]
        public int GlobalId;
    }
}
