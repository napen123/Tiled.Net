using System.Xml.Serialization;

namespace Tiled
{
    /// <summary>
    /// The base class for objects (<see cref="TiledEllipse"/>, <see cref="TiledPolygon"/>, <see cref="TiledPolyline"/>, and <see cref="TiledText"/>).
    /// </summary>
    [XmlInclude(typeof(TiledEllipse))]
    [XmlInclude(typeof(TiledPolygon))]
    [XmlInclude(typeof(TiledPolyline))]
    [XmlInclude(typeof(TiledText))]
    public abstract class TiledBaseObject
    {
    }
}
