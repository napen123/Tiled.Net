using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Tiled
{
    /// <summary>
    /// Represents an object (<see cref="TiledEllipse"/>, <see cref="TiledPolygon"/>, and <see cref="TiledPolyline"/>).
    /// </summary>
    public class TiledObject
    {
        /// <summary>
        /// The object's unique id.
        /// </summary>
        [XmlAttribute("id")]
        public int Id;

        /// <summary>
        /// The object's name.
        /// </summary>
        [XmlAttribute("name")]
        public string Name;

        /// <summary>
        /// The object's type. This is arbitrary and is meant for the user.
        /// </summary>
        [XmlAttribute("type")]
        public string Type;

        /// <summary>
        /// The x-coordinate of the object.
        /// </summary>
        [XmlAttribute("x")]
        public float X;

        /// <summary>
        /// The y-coordinate of the object.
        /// </summary>
        [XmlAttribute("y")]
        public float Y;

        /// <summary>
        /// The width of the object.
        /// </summary>
        [XmlAttribute("width")]
        public float Width;

        /// <summary>
        /// The height of the object.
        /// </summary>
        [XmlAttribute("height")]
        public float Height;

        /// <summary>
        /// The rotation of the object in degrees clockwise.
        /// </summary>
        [XmlAttribute("rotation")]
        public float Rotation;

        /// <summary>
        /// A reference to a tile (optional). Note: Currently does not get saved.
        /// </summary>
        [XmlIgnore]
        [XmlAttribute("gid")]
        public int GlobalId;

        /// <summary>
        /// Whether the object is shown (1) or hidden (0).
        /// </summary>
        [XmlAttribute("visible")]
        public int Visible = 1;

        /// <summary>
        /// Custom properties for the object. These are arbitrary and are meant for the user.
        /// </summary>
        [XmlArray("properties")]
        [XmlArrayItem("property")]
        public List<TiledProperty> Properties;

        /// <summary>
        /// The base of the object; the type of object (<see cref="TiledEllipse"/>, <see cref="TiledPolygon"/>, <see cref="TiledPolyline"/>, and <see cref="TiledText"/>).
        /// </summary>
        [XmlElement("ellipse", typeof(TiledEllipse))]
        [XmlElement("polygon", typeof(TiledPolygon))]
        [XmlElement("polyline", typeof(TiledPolyline))]
        [XmlElement("text", typeof(TiledText))]
        public TiledBaseObject Object;

        /// <summary>
        /// Nothing to see here. Used for serialization.
        /// </summary>
        /// <returns></returns>
        public bool ShouldSerializeName()
        {
            return !string.IsNullOrWhiteSpace(Name);
        }

        /// <summary>
        /// Nothing to see here. Used for serialization.
        /// </summary>
        /// <returns></returns>
        public bool ShouldSerializeType()
        {
            return !string.IsNullOrWhiteSpace(Type);
        }

        /// <summary>
        /// Nothing to see here. Used for serialization.
        /// </summary>
        /// <returns></returns>
        public bool ShouldSerializeRotation()
        {
            return Math.Abs(Rotation) > float.Epsilon;
        }

        /// <summary>
        /// Nothing to see here. Used for serialization.
        /// </summary>
        /// <returns></returns>
        public bool ShouldSerializeVisible()
        {
            return Visible == 0;
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
        public bool ShouldSerializeObject()
        {
            return Object != null;
        }
    }
}
