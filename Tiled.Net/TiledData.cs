using System.Xml.Serialization;
using System.Collections.Generic;

namespace Tiled
{
    /// <summary>
    /// Represents a tile layer's (<see cref="TiledTileLayer"/>) tile data.
    /// </summary>
    public class TiledData
    {
        /// <summary>
        /// The types of encoding.
        /// </summary>
        public enum EncodingType
        {
            NoEncoding,
            Xml = 0,

            [XmlEnum("base64")]
            Base64,

            [XmlEnum("csv")]
            Csv
        }

        /// <summary>
        /// The types of compression.
        /// </summary>
        public enum CompressionType
        {
            NoCompression,

            [XmlEnum("gzip")]
            GZip,

            [XmlEnum("zlib")]
            ZLib
        }

        /// <summary>
        /// The type of encoding to use on the data.
        /// </summary>
        [XmlAttribute("encoding")]
        public EncodingType Encoding;

        /// <summary>
        /// The type of compression to use on the data.
        /// </summary>
        [XmlAttribute("compression")]
        public CompressionType Compression;

        /// <summary>
        /// If the encoding is <see cref="EncodingType.NoEncoding"/> or <see cref="EncodingType.Xml"/>,
        /// this is used to store all of the tiles individually.
        /// </summary>
        [XmlElement("tile")]
        public List<TiledTileData> Tiles;

        /// <summary>
        /// If the encoding is not <see cref="EncodingType.NoEncoding"/> nor <see cref="EncodingType.Xml"/>,
        /// this is used to store the data.
        /// </summary>
        [XmlText]
        public string Data;

        /// <summary>
        /// Nothing to see here. Used for serialization.
        /// </summary>
        /// <returns></returns>
        public bool ShouldSerializeEncoding()
        {
            return Encoding != 0;
        }

        /// <summary>
        /// Nothing to see here. Used for serialization.
        /// </summary>
        /// <returns></returns>
        public bool ShouldSerializeCompression()
        {
            return Compression != CompressionType.NoCompression;
        }

        /// <summary>
        /// Nothing to see here. Used for serialization.
        /// </summary>
        /// <returns></returns>
        public bool ShouldSerializeTiles()
        {
            return Tiles != null && Tiles.Count > 0 && Encoding == 0;
        }

        /// <summary>
        /// Nothing to see here. Used for serialization.
        /// </summary>
        /// <returns></returns>
        public bool ShouldSerializeData()
        {
            return !string.IsNullOrWhiteSpace(Data) && Encoding != 0;
        }
    }
}
