using System.Xml.Serialization;

namespace Tiled
{
    /// <summary>
    /// The base class for objects (<see cref="TiledEllipse"/>, <see cref="TiledPolygon"/>, and <see cref="TiledPolyline"/>).
    /// </summary>
    [XmlInclude(typeof(TiledEllipse))]
    [XmlInclude(typeof(TiledPolygon))]
    [XmlInclude(typeof(TiledPolyline))]
    public abstract class TiledBaseObject
    {
    }
}
