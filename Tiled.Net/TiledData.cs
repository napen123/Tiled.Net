using System.Collections.Generic;
using System.Xml.Serialization;

namespace Tiled
{
    public class TiledData
    {
        public enum EncodingType
        {
            NoEncoding,
            Xml = 0,

            [XmlEnum("base64")]
            Base64,

            [XmlEnum("csv")]
            Csv
        }

        public enum CompressionType
        {
            NoCompression,

            [XmlEnum("gzip")]
            GZip,

            [XmlEnum("zlib")]
            ZLib
        }

        [XmlAttribute("encoding")]
        public EncodingType Encoding;

        [XmlAttribute("compression")]
        public CompressionType Compression;

        [XmlElement("tile")]
        public List<TiledTileData> Tiles;

        [XmlText]
        public string Data;

        public bool ShouldSerializeEncoding()
        {
            return Encoding != 0;
        }

        public bool ShouldSerializeCompression()
        {
            return Compression != CompressionType.NoCompression;
        }

        public bool ShouldSerializeTiles()
        {
            return Tiles != null && Tiles.Count > 0 && Encoding == 0;
        }

        public bool ShouldSerializeData()
        {
            return !string.IsNullOrWhiteSpace(Data) && Encoding != 0;
        }
    }
}
