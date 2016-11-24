using System.Xml.Serialization;

namespace Tiled
{
    [XmlInclude(typeof(TiledTileLayer))]
    [XmlInclude(typeof(TiledObjectGroup))]
    [XmlInclude(typeof(TiledImageLayer))]
    public abstract class TiledBaseLayer
    {
        [XmlAttribute("name")]
        public string Name;
    }
}
