using System.Xml.Serialization;

namespace Tiled
{
    /// <summary>
    /// Represents an image.
    /// </summary>
    public class TiledImage
    {
        /// <summary>
        /// The format used for embedded image, in combination with <see cref="Data"/>.
        /// Valid values include extensions such as png, gif, jpg, bmp, etc.
        /// </summary>
        [XmlAttribute("format")]
        public string Format;

        /// <summary>
        /// The path to the image file.
        /// </summary>
        /// <remarks>Tiled supported the most common image formats.</remarks>
        [XmlAttribute("source")]
        public string Source;

        /// <summary>
        /// A specific color that is treated as transparent.
        /// </summary>
        [XmlIgnore]
        public TiledColor TransparentColor;

        /// <summary>
        /// A specific color that is treated as transparent, in hex format (<c>#RRGGBB</c>).
        /// </summary>
        [XmlAttribute("trans")]
        public string TransparentColorHex
        {
            get => TransparentColor.ToHex();
            set => TransparentColor = TiledColor.FromHex(value);
        }

        /// <summary>
        /// The image's width in pixels.
        /// </summary>
        /// <remarks>Optional. Used for tile index correction when the image changes.</remarks>
        [XmlAttribute("width")]
        public int Width;

        /// <summary>
        /// The image's height in pixels.
        /// </summary>
        /// <remarks>Optional. Used for tile index correction when the image changes.</remarks>
        [XmlAttribute("height")]
        public int Height;

        /// <summary>
        /// The data used for embedded images.
        /// </summary>
        [XmlElement("data")]
        public TiledData Data;

        /// <summary>
        /// Nothing to see here. Used for serialization.
        /// </summary>
        /// <returns></returns>
        public bool ShouldSerializeTransparentColorHex()
        {
            return TransparentColor != null;
        }

        /// <summary>
        /// Nothing to see here. Used for serialization.
        /// </summary>
        /// <returns></returns>
        public bool ShouldSerializeWidth()
        {
            return Width > 0;
        }

        /// <summary>
        /// Nothing to see here. Used for serialization.
        /// </summary>
        /// <returns></returns>
        public bool ShouldSerializeHeight()
        {
            return Height > 0;
        }

        /// <summary>
        /// Nothing to see here. Used for serialization.
        /// </summary>
        /// <returns></returns>
        public bool ShouldSerializeData()
        {
            return Data != null;
        }
    }
}
