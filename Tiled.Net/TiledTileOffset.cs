using System.Xml.Serialization;

namespace Tiled
{
    public class TiledTileOffset
    {
        [XmlAttribute("x")]
        public int X;
        
        [XmlAttribute("y")]
        public int Y;
    }
}
