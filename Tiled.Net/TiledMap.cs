using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace Tiled
{
    [XmlRoot("map")]
    public class TiledMap
    {
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

        public enum StaggerAxisType
        {
            [XmlEnum("x")]
            X,

            [XmlEnum("y")]
            Y
        }

        public enum StaggerIndexType
        {
            [XmlEnum("even")]
            Even,

            [XmlEnum("odd")]
            Odd
        }

        [XmlAttribute("version")]
        public float Version = 1;

        [XmlAttribute("orientation")]
        public OrientationType Orientation = OrientationType.Orthogonal;

        [XmlAttribute("renderorder")]
        public RenderOrderType RenderOrder = RenderOrderType.RightDown;

        [XmlAttribute("width")]
        public int Width;

        [XmlAttribute("height")]
        public int Height;

        [XmlAttribute("tilewidth")]
        public int TileWidth;

        [XmlAttribute("tileheight")]
        public int TileHeight;

        [XmlAttribute("hexsidelength")]
        public int HexSideLength;

        [XmlAttribute("staggeraxis")]
        public StaggerAxisType StaggerAxis;

        [XmlAttribute("staggerindex")]
        public StaggerIndexType StaggerIndex;

        [XmlIgnore]
        public TiledColor BackgroundColor = new TiledColor(255, 128, 128, 128);

        [XmlAttribute("backgroundcolor")]
        public string BackgroundColorHex
        {
            get { return BackgroundColor.ToHex(); }
            set { BackgroundColor = TiledColor.FromHex(value); }
        }

        [XmlAttribute("nextobjectid")]
        public int NextObjectId = 1;

        [XmlArray("properties")]
        [XmlArrayItem("property")]
        public List<TiledProperty> Properties;

        [XmlElement("tileset")]
        public List<TiledTileset> Tilesets;
        
        [XmlElement("layer", typeof(TiledTileLayer))]
        [XmlElement("objectgroup", typeof(TiledObjectGroup))]
        [XmlElement("imagelayer", typeof(TiledImageLayer))]
        public List<TiledBaseLayer> Layers;
        
        private readonly XmlSerializer _serializer = new XmlSerializer(typeof(TiledMap));

        public TiledMap()
        {
        }

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

        public void Save(string file)
        {
            using (
                var writer = new XmlTextWriter(file, Encoding.UTF8) {Formatting = Formatting.Indented, Indentation = 4})
            {
                _serializer.Serialize(
                    writer, this,
                    new XmlSerializerNamespaces(new[]
                    {
                        new XmlQualifiedName("", "")
                    }));
            }
        }

        public void SaveCompact(string file)
        {
            using (
                var writer = new XmlTextWriter(file, Encoding.UTF8))
            {
                _serializer.Serialize(
                    writer, this,
                    new XmlSerializerNamespaces(new[]
                    {
                        new XmlQualifiedName("", "")
                    }));
            }
        }

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

        public bool ShouldSerializeRenderOrder()
        {
            return Orientation == OrientationType.Orthogonal;
        }

        public bool ShouldSerializeHexSideLength()
        {
            return Orientation == OrientationType.Hexagonal;
        }

        public bool ShouldSerializeStaggerAxis()
        {
            return Orientation == OrientationType.Staggered || Orientation == OrientationType.Hexagonal;
        }

        public bool ShouldSerializeStaggerIndex()
        {
            return Orientation == OrientationType.Staggered || Orientation == OrientationType.Hexagonal;
        }

        public bool ShouldSerializeBackgroundColorHex()
        {
            return BackgroundColorHex != "#ff808080";
        }

        public bool ShouldSerializeProperties()
        {
            return Properties != null && Properties.Count > 0;
        }

        public bool ShouldSerializeTilesets()
        {
            return Tilesets != null && Tilesets.Count > 0;
        }

        public bool ShouldSerializeLayers()
        {
            return Layers != null && Layers.Count > 0;
        }
    }
}
