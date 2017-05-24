using System.Xml;
using System.Text;
using System.Linq;
using System.Xml.Serialization;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Tiled
{
    /// <summary>
    /// Represents a tiled map.
    /// </summary>
    [XmlRoot("map")]
    public class TiledMap
    {
        /// <summary>
        /// The types of map orientations.
        /// </summary>
        public enum OrientationType
        {
            [XmlEnum("orthogonal")]
            Orthogonal,

            [XmlEnum("isometric")]
            Isometric,

            [XmlEnum("staggered")]
            Staggered,

            [XmlEnum("hexagonal")]
            Hexagonal
        }

        /// <summary>
        /// The types of map render orders.
        /// </summary>
        /// <remarks>Available since <see cref="Version"/> 0.10</remarks>
        public enum RenderOrderType
        {
            [XmlEnum("right-down")]
            RightDown,

            [XmlEnum("right-up")]
            RightUp,

            [XmlEnum("left-down")]
            LeftDown,

            [XmlEnum("left-up")]
            LeftUp
        }

        /// <summary>
        /// The types of map stagger axises for <see cref="OrientationType.Staggered"/> and <see cref="OrientationType.Hexagonal"/> maps.
        /// </summary>
        /// <remarks>Available since <see cref="Version"/> 0.11</remarks>
        public enum StaggerAxisType
        {
            [XmlEnum("x")]
            X,

            [XmlEnum("y")]
            Y
        }

        /// <summary>
        /// The types of map stagger indexes for <see cref="OrientationType.Staggered"/> and <see cref="OrientationType.Hexagonal"/> maps.
        /// </summary>
        /// <remarks>Available since <see cref="Version"/> 0.11</remarks>
        public enum StaggerIndexType
        {
            [XmlEnum("even")]
            Even,

            [XmlEnum("odd")]
            Odd
        }

        /// <summary>
        /// The TMX format version.
        /// </summary>
        [XmlAttribute("version")]
        public float Version = 1;

        /// <summary>
        /// The map orientation.
        /// </summary>
        [XmlAttribute("orientation")]
        public OrientationType Orientation = OrientationType.Orthogonal;

        /// <summary>
        /// The order in which tile layers render their tiles.
        /// Only <see cref="OrientationType.Orthogonal"/> maps are supported.
        /// </summary>
        /// <see cref="TiledTileLayer"/>
        [XmlAttribute("renderorder")]
        public RenderOrderType RenderOrder = RenderOrderType.RightDown;

        /// <summary>
        /// The width of the map in tiles.
        /// </summary>
        [XmlAttribute("width")]
        public int Width;

        /// <summary>
        /// The height of the map in tiles.
        /// </summary>
        [XmlAttribute("height")]
        public int Height;

        /// <summary>
        /// The width of a tile in pixels.
        /// </summary>
        [XmlAttribute("tilewidth")]
        public int TileWidth;

        /// <summary>
        /// The height of a tile in pixels.
        /// </summary>
        [XmlAttribute("tileheight")]
        public int TileHeight;

        /// <summary>
        /// The width or height (depending on the <see cref="StaggerAxis"/>) of the tile's edge, in pixels.
        /// Only for <see cref="OrientationType.Hexagonal"/> maps.
        /// </summary>
        [XmlAttribute("hexsidelength")]
        public int HexSideLength;

        /// <summary>
        /// Determines which axis (<see cref="StaggerAxisType.X"/> or <see cref="StaggerAxisType.Y"/>) is staggered.
        /// Only for <see cref="OrientationType.Staggered"/> and <see cref="OrientationType.Hexagonal"/> maps.
        /// </summary>
        [XmlAttribute("staggeraxis")]
        public StaggerAxisType StaggerAxis;

        /// <summary>
        /// Determines whether the <see cref="StaggerIndexType.Even"/> or <see cref="StaggerIndexType.Odd"/> indexes along the <see cref="StaggerAxis"/> are shifted.
        /// Only for <see cref="OrientationType.Staggered"/> and <see cref="OrientationType.Hexagonal"/> maps.
        /// </summary>
        [XmlAttribute("staggerindex")]
        public StaggerIndexType StaggerIndex;

        /// <summary>
        /// The map's background color.
        /// </summary>
        [XmlIgnore]
        public TiledColor BackgroundColor = new TiledColor(255, 128, 128, 128);

        /// <summary>
        /// The map's background color in hex format (<c>#AARRGGBB</c>).
        /// Setting the color in either <c>#RRGGBB</c> or <c>#AARRGGBB</c> is allowed,
        /// but getting will always return in <c>#AARRGGBB</c>-form. For a traditional object, use <see cref="BackgroundColor"/>.
        /// </summary>
        /// <returns>The map's background color in hex format.</returns>
        [XmlAttribute("backgroundcolor")]
        public string BackgroundColorHex
        {
            get => BackgroundColor.ToHex();
            set => BackgroundColor = TiledColor.FromHex(value);
        }

        /// <summary>
        /// The next available ID for new objects.
        /// </summary>
        [XmlAttribute("nextobjectid")]
        public int NextObjectId = 1;

        /// <summary>
        /// Custom properties for the map. These are arbitrary and are meant for the user.
        /// </summary>
        [XmlArray("properties")]
        [XmlArrayItem("property")]
        public List<TiledProperty> Properties;

        /// <summary>
        /// The map's tilesets.
        /// </summary>
        [XmlElement("tileset")]
        public List<TiledTileset> Tilesets;

        /// <summary>
        /// The map's layers. May contain three types of layers: <see cref="TiledTileLayer"/>, <see cref="TiledObjectGroup"/>, and <see cref="TiledImageLayer"/>.
        /// </summary>
        /// <remarks>The order in which these appear is the order in which they are rendered in Tiled.</remarks>
        [XmlElement("layer", typeof(TiledTileLayer))]
        [XmlElement("objectgroup", typeof(TiledObjectGroup))]
        [XmlElement("imagelayer", typeof(TiledImageLayer))]
        public List<TiledBaseLayer> Layers;
        
        private readonly XmlSerializer _serializer = new XmlSerializer(typeof(TiledMap));

        /// <summary>
        /// Default constructor.
        /// </summary>
        public TiledMap()
        {
        }

        /// <summary>
        /// Constructor used for opening an already-existing map.
        /// </summary>
        /// <param name="file">The path to the map.</param>
        public TiledMap(string file)
        {
            using (var reader = new XmlTextReader(file))
            {
                if(!_serializer.CanDeserialize(reader))
                    throw new SerializationException("Unable to read tiled map.");

                var map = _serializer.Deserialize(reader) as TiledMap;

                if(map == null)
                    throw new SerializationException("Unexpected error while reading map.");
                
                Version = map.Version;
                Orientation = map.Orientation;
                RenderOrder = map.RenderOrder;
                Width = map.Width;
                Height = map.Height;
                TileWidth = map.TileWidth;
                TileHeight = map.TileHeight;
                HexSideLength = map.HexSideLength;
                StaggerAxis = map.StaggerAxis;
                StaggerIndex = map.StaggerIndex;
                BackgroundColor = map.BackgroundColor;
                NextObjectId = map.NextObjectId;

                Properties = map.Properties;
                Tilesets = map.Tilesets;
                Layers = map.Layers;
            }
        }

        /// <summary>
        /// Save the map in a human-readable format, to <paramref name="file"/>.
        /// </summary>
        /// <remarks>For saving a compact, non-human-readable file, use <see cref="SaveCompact"/>.</remarks>
        /// <param name="file">The path to save to.</param>
        /// <param name="indentationLevel">How much to indentate, in spaces.</param>
        public void Save(string file, int indentationLevel = 4)
        {
            using (
                var writer = new XmlTextWriter(file, Encoding.UTF8)
                {
                    Formatting = Formatting.Indented,
                    Indentation = indentationLevel
                })
            {
                _serializer.Serialize(
                    writer, this,
                    new XmlSerializerNamespaces(new[]
                    {
                        new XmlQualifiedName("", "")
                    }));
            }
        }

        /// <summary>
        /// Save the map in a compact, non-human-readable format, to <paramref name="file"/>.
        /// </summary>
        /// <param name="file">The path to save to.</param>
        public void SaveCompact(string file)
        {
            using (var writer = new XmlTextWriter(file, Encoding.UTF8))
            {
                _serializer.Serialize(
                    writer, this,
                    new XmlSerializerNamespaces(new[]
                    {
                        new XmlQualifiedName("", "")
                    }));
            }
        }

        /// <summary>
        /// Gets the layer that has the given <paramref name="name"/>, if it exists; otherwise, return <c>null</c>.
        /// <br />
        /// Sets the layer that has the given <paramref name="name"/>, if it exists; otherwise, create a new layer with that <paramref name="name"/>.
        /// </summary>
        /// <param name="name">The name of the layer.</param>
        /// <returns>Returns a layer that has the given <paramref name="name"/>, if it exists; otherwise, return <c>null</c>.</returns>
        public TiledBaseLayer this[string name]
        {
            get { return Layers.FirstOrDefault(layer => layer.Name == name); }
            set
            {
                var i = Layers.FindIndex(layer => layer.Name == name);

                if (i == -1)
                    Layers.Add(value);
                else
                    Layers[i] = value;
            }
        }

        /// <summary>
        /// Nothing to see here. Used for serialization.
        /// </summary>
        /// <returns></returns>
        public bool ShouldSerializeRenderOrder()
        {
            return Orientation == OrientationType.Orthogonal;
        }

        /// <summary>
        /// Nothing to see here. Used for serialization.
        /// </summary>
        /// <returns></returns>
        public bool ShouldSerializeHexSideLength()
        {
            return Orientation == OrientationType.Hexagonal;
        }

        /// <summary>
        /// Nothing to see here. Used for serialization.
        /// </summary>
        /// <returns></returns>
        public bool ShouldSerializeStaggerAxis()
        {
            return Orientation == OrientationType.Staggered || Orientation == OrientationType.Hexagonal;
        }

        /// <summary>
        /// Nothing to see here. Used for serialization.
        /// </summary>
        /// <returns></returns>
        public bool ShouldSerializeStaggerIndex()
        {
            return Orientation == OrientationType.Staggered || Orientation == OrientationType.Hexagonal;
        }

        /// <summary>
        /// Nothing to see here. Used for serialization.
        /// </summary>
        /// <returns></returns>
        public bool ShouldSerializeBackgroundColorHex()
        {
            return BackgroundColorHex != "#ff808080";
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
        public bool ShouldSerializeTilesets()
        {
            return Tilesets != null && Tilesets.Count > 0;
        }

        /// <summary>
        /// Nothing to see here. Used for serialization.
        /// </summary>
        /// <returns></returns>
        public bool ShouldSerializeLayers()
        {
            return Layers != null && Layers.Count > 0;
        }
    }
}
