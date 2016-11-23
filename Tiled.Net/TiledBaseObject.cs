using System.Xml.Serialization;

namespace Tiled
{
    [XmlInclude(typeof(TiledEllipse))]
    [XmlInclude(typeof(TiledPolygon))]
    [XmlInclude(typeof(TiledPolyline))]
    public abstract class TiledBaseObject
    {
    }
}
