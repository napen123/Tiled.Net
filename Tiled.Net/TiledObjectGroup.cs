using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Xml.Serialization;

namespace Tiled
{
    /// <summary>
    /// Represents a layer that hold objects (<see cref="TiledEllipse"/>, <see cref="TiledPolygon"/>, and <see cref="TiledPolyline"/>).
    /// </summary>
    public class TiledObjectGroup : TiledBaseLayer
    {
        /// <summary>
        /// The types of layer draw orders.
        /// </summary>
        public enum DrawOrderType
        {
            [XmlEnum("topdown")]
            TopDown,

            [XmlEnum("index")]
            Index
        }

        /// <summary>
        /// The color used to display the objects in this group.
        /// </summary>
        [XmlIgnore]
        public TiledColor Color = new TiledColor(160, 160, 164);

        /// <summary>
        /// The color used to display the objects in this group, in hex format (<c>#RRGGBB</c>).
        /// Setting the color in either <c>#RRGGBB</c> or <c>#AARRGGBB</c> is allowed,
        /// but getting will always return in <c>#RRGGBB</c>-form. For a traditional object, use <see cref="Color"/>.
        /// </summary>
        [XmlAttribute("color")]
        public string ColorHex
        {
            get { return Color.ToHex(false); }
            set { Color = TiledColor.FromHex(value); }
        }

        /// <summary>
        /// The opacity of the layer from 0-1.
        /// </summary>
        /// <remarks>Defaults to 1.</remarks>
        [DefaultValue(1)]
        [XmlAttribute("opacity")]
        public int Opacity = 1;

        /// <summary>
        /// Whether the layer is shown (1) or hidden (0).
        /// </summary>
        /// <remarks>Defaults to 1.</remarks>
        [DefaultValue(1)]
        [XmlAttribute("visible")]
        public int Visible = 1;

        /// <summary>
        /// The rendering x-offset for this object in pixels.
        /// </summary>
        /// <remarks>
        /// Defaults to 0
        /// <br />
        /// Available since <see cref="TiledMap.Version"/> 0.14
        /// </remarks>
        [XmlAttribute("offsetx")]
        public int OffsetX;

        /// <summary>
        /// The rendering y-offset for this object in pixels.
        /// </summary>
        /// <remarks>
        /// Defaults to 0
        /// <br />
        /// Available since <see cref="TiledMap.Version"/> 0.14
        /// </remarks>
        [XmlAttribute("offsety")]
        public int OffsetY;

        /// <summary>
        /// Whether the objects are drawn according to the order of appearance (<see cref="DrawOrderType.Index"/>)
        /// or sorted by their y-coordinate (<see cref="DrawOrderType.TopDown"/>).
        /// </summary>
        /// <remarks>Defaults to <see cref="DrawOrderType.TopDown"/>.</remarks>
        [XmlAttribute("draworder")]
        public DrawOrderType DrawOrder = DrawOrderType.TopDown;

        /// <summary>
        /// Custom properties for the layer. These are arbitrary and are meant for the user.
        /// </summary>
        [XmlArray("properties")]
        [XmlArrayItem("property")]
        public List<TiledProperty> Properties;

        /// <summary>
        /// The objects in this layer.
        /// </summary>
        [XmlElement("object")]
        public List<TiledObject> Objects;

        /// <summary>
        /// Gets the object that has the given <paramref name="id"/>, if it exists; otherwise, return <c>null</c>.
        /// <br />
        /// Sets the object that has the given <paramref name="id"/>, if it exists; otherwise, create a new object with that <paramref name="id"/>.
        /// </summary>
        /// <param name="id">The id of the object.</param>
        /// <returns>Returns an object that has the given <paramref name="id"/>, if it exists; otherwise, return <c>null</c>.</returns>
        public TiledObject this[int id]
        {
            get { return Objects.FirstOrDefault(o => o.Id == id); }
            set
            {
                var i = Objects.FindIndex(o => o.Id == id);

                if (i == -1)
                    Objects.Add(value);
                else
                    Objects[i] = value;
            }
        }

        /// <summary>
        /// Gets the object that has the given <paramref name="name"/>, if it exists; otherwise, return <c>null</c>.
        /// <br />
        /// Sets the object that has the given <paramref name="name"/>, if it exists; otherwise, create a new object with that <paramref name="name"/>.
        /// </summary>
        /// <param name="name">The name of the object.</param>
        /// <returns>Returns an object that has the given <paramref name="name"/>, if it exists; otherwise, return <c>null</c>.</returns>
        public TiledObject this[string name]
        {
            get { return Objects.FirstOrDefault(o => o.Name == name); }
            set
            {
                var i = Objects.FindIndex(o => o.Name == name);

                if (i == -1)
                    Objects.Add(value);
                else
                    Objects[i] = value;
            }
        }

        /// <summary>
        /// Nothing to see here. Used for serialization.
        /// </summary>
        /// <returns></returns>
        public bool ShouldSerializeColorHex()
        {
            return ColorHex != "#a0a0a4";
        }

        /// <summary>
        /// Nothing to see here. Used for serialization.
        /// </summary>
        /// <returns></returns>
        public bool ShouldSerializeOpacity()
        {
            return Opacity == 0;
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
        public bool ShouldSerializeOffsetX()
        {
            return OffsetX != 0;
        }

        /// <summary>
        /// Nothing to see here. Used for serialization.
        /// </summary>
        /// <returns></returns>
        public bool ShouldSerializeOffsetY()
        {
            return OffsetY != 0;
        }

        /// <summary>
        /// Nothing to see here. Used for serialization.
        /// </summary>
        /// <returns></returns>
        public bool ShouldSerializeDrawOrder()
        {
            return DrawOrder == DrawOrderType.Index;
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
        public bool ShouldSerializeObjects()
        {
            return Objects != null && Objects.Count > 0;
        }
    }
}
