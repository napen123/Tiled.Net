using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Tiled
{
    public class TiledGroup
    {
        /// <summary>
        /// The name of the group layer.
        /// </summary>
        [XmlAttribute("name")]
        public string Name;

        /// <summary>
        /// Rendering offset of the group layer in pixels.
        /// </summary>
        /// <remarks>
        /// Defaults to 0.
        /// </remarks>
        [XmlAttribute("offsetx")]
        public int XOffset;

        /// <summary>
        /// Rendering offset of the group layer in pixels.
        /// </summary>
        /// <remarks>
        /// Defaults to 0.
        /// </remarks>
        [XmlAttribute("offsety")]
        public int YOffset;

        /// <summary>
        /// The x position of the group layer in pixels.
        /// </summary>
        [XmlAttribute("x")]
        [Obsolete("Deprecated since 0.15")]
        public int X;

        /// <summary>
        /// The y position of the group layer in pixels.
        /// </summary>
        [XmlAttribute("y")]
        [Obsolete("Deprecated since 0.15")]
        public int Y;

        /// <summary>
        /// The opacity of the layer as a value from 0 to 1.
        /// </summary>
        /// <remarks>
        /// Defaults to 1.
        /// </remarks>
        [XmlAttribute("opacity")]
        public float Opacity = 1;

        /// <summary>
        /// Whether the layer is shown (1) or hidden (0).
        /// </summary>
        /// <remarks>
        /// Defaults to 1.
        /// </remarks>
        [XmlAttribute("visible")]
        public int Visible = 1;

        /// <summary>
        /// The group's sub-groups. Groups are used to organize the layers of the map in a hierarchy.
        /// </summary>
        [XmlElement("group", typeof(TiledGroup))]
        public List<TiledGroup> Groups;

        /// <summary>
        /// The group's sub-layers. May contain three types of layers: <see cref="TiledTileLayer"/>, <see cref="TiledObjectGroup"/>, and <see cref="TiledImageLayer"/>.
        /// </summary>
        /// <remarks>The order in which these appear is the order in which they are rendered in Tiled.</remarks>
        [XmlElement("layer", typeof(TiledTileLayer))]
        [XmlElement("objectgroup", typeof(TiledObjectGroup))]
        [XmlElement("imagelayer", typeof(TiledImageLayer))]
        public List<TiledBaseLayer> Layers;

        /// <summary>
        /// Custom properties for the map. These are arbitrary and are meant for the user.
        /// </summary>
        [XmlArray("properties")]
        [XmlArrayItem("property")]
        public List<TiledProperty> Properties;

        public bool ShouldSerializeName()
        {
            return Name != null;
        }

        public bool ShouldSerializeXOffset()
        {
            return XOffset != 0;
        }

        public bool ShouldSerializeYOffset()
        {
            return YOffset != 0;
        }

        public bool ShouldSerializeX()
        {
            return X != 0;
        }

        public bool ShouldSerializeY()
        {
            return Y != 0;
        }

        public bool ShouldSerializeOpacity()
        {
            return Opacity != 1;
        }

        public bool ShouldSerializeVisible()
        {
            return Visible != 1;
        }

        public bool ShouldSerializeGroups()
        {
            return Groups != null && Groups.Count > 0;
        }

        public bool ShouldSerializeLayers()
        {
            return Layers != null && Layers.Count > 0;
        }

        public bool ShouldSerializeProperties()
        {
            return Properties != null && Properties.Count > 0;
        }
    }
}
