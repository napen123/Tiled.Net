using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        /// <remarks>
        /// Cannot be changed in Tiled Qt.
        /// <br />
        /// Available since <see cref="TiledMap.Version"/> 0.11
        /// </remarks>
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
        /// The x-coordinate of the object in pixels.
        /// </summary>
        [XmlAttribute("x")]
        public float X;

        /// <summary>
        /// The y-coordinate of the object in pixels.
        /// </summary>
        [XmlAttribute("y")]
        public float Y;

        /// <summary>
        /// The width of the object in pixels.
        /// </summary>
        /// <remarks>Defaults to 0.</remarks>
        [XmlAttribute("width")]
        public float Width;

        /// <summary>
        /// The height of the object in pixels.
        /// </summary>
        /// <remarks>Defaults to 0.</remarks>
        [XmlAttribute("height")]
        public float Height;

        /// <summary>
        /// The rotation of the object in degrees clockwise.
        /// </summary>
        /// <remarks>
        /// Defaults to 0
        /// <br />
        /// Available since <see cref="TiledMap.Version"/> 0.10
        /// </remarks>
        [XmlAttribute("rotation")]
        public float Rotation;

        /// <summary>
        /// A reference to a tile (optional).
        /// </summary>
        /// <remarks>This currently does not get saved.</remarks>
        [XmlIgnore] // TODO
        [XmlAttribute("gid")]
        public int GlobalId;

        /// <summary>
        /// Whether the object is shown (1) or hidden (0).
        /// </summary>
        /// <remarks>
        /// Defaults to 1
        /// <br />
        /// Available since <see cref="TiledMap.Version"/> 0.9
        /// </remarks>
        [DefaultValue(1)]
        [XmlAttribute("visible")]
        public int Visible = 1;

        /// <summary>
        /// Custom properties for the object. These are arbitrary and are meant for the user.
        /// </summary>
        [XmlArray("properties")]
        [XmlArrayItem("property")]
        public List<TiledProperty> Properties;

        /// <summary>
        /// The base of the object; the type of object (<see cref="TiledEllipse"/>, <see cref="TiledPolygon"/>, and <see cref="TiledPolyline"/>).
        /// </summary>
        [XmlElement("ellipse", typeof(TiledEllipse))]
        [XmlElement("polygon", typeof(TiledPolygon))]
        [XmlElement("polyline", typeof(TiledPolyline))]
        public TiledBaseObject Base;

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
        public bool ShouldSerializeBase()
        {
            return Base != null;
        }
    }
}
