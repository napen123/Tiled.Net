using System.Xml.Serialization;

namespace Tiled
{
    /// <summary>
    /// Represents a text object (<see cref="TiledObject"/>).
    /// </summary>
    public class TiledText : TiledBaseObject
    {
        public enum HorizontalAlign
        {
            [XmlEnum("left")]
            Left,

            [XmlEnum("center")]
            Center,

            [XmlEnum("right")]
            Right
        }

        public enum VerticalAlign
        {
            [XmlEnum("top")]
            Top,

            [XmlEnum("center")]
            Center,

            [XmlEnum("bottom")]
            Bottom
        }

        /// <summary>
        /// The font family used.
        /// </summary>
        /// <remarks>
        /// Defaults to "sand-serif".
        /// </remarks>
        [XmlAttribute("fontfamily")]
        public string FontFamily = "sand-serif";

        /// <summary>
        /// The size of the font in pixels.
        /// </summary>
        /// <remarks>
        /// Defaults to 16.
        /// </remarks>
        [XmlAttribute("pixelsize")]
        public int PixelSize = 16;

        /// <summary>
        /// Whether word wrapping is enabled (1) or disabled (0).
        /// </summary>
        /// <remarks>
        /// Defaults to 0.
        /// </remarks>
        [XmlAttribute("wrap")]
        public int Wrap;

        /// <summary>
        /// Color of the text in #AARRGGBB or #RRGGBB format.
        /// </summary>
        /// <remarks>
        /// Defaults to #000000.
        /// </remarks>
        [XmlIgnore]
        public TiledColor Color = new TiledColor(0, 0, 0);

        /// <summary>
        /// Color of the text in #AARRGGBB or #RRGGBB format.
        /// </summary>
        /// <remarks>
        /// Defaults to #000000.
        /// </remarks>
        [XmlAttribute("color")]
        public string ColorHex
        {
            get => Color.ToHex();
            set => Color = TiledColor.FromHex(value);
        }

        /// <summary>
        /// Whether the font is bold (1) or not (0).
        /// </summary>
        /// <remarks>
        /// Defaults to 0.
        /// </remarks>
        [XmlAttribute("bold")]
        public int Bold;

        /// <summary>
        /// Whether the font is italic (1) or not (0).
        /// </summary>
        /// <remarks>
        /// Defaults to 0.
        /// </remarks>
        [XmlAttribute("italic")]
        public int Italic;

        /// <summary>
        /// Whether a line should be drawn below the text (1) or not (0).
        /// </summary>
        /// <remarks>
        /// Defaults to 0.
        /// </remarks>
        [XmlAttribute("underline")]
        public int Underline;

        /// <summary>
        /// Whether a line should be drawn through the text (1) or not (0).
        /// </summary>
        /// <remarks>
        /// Defaults to 0.
        /// </remarks>
        [XmlAttribute("strikeout")]
        public int Strikeout;

        /// <summary>
        /// Whether kerning should be used while rendering the text (1) or not (0).
        /// </summary>
        /// <remarks>
        /// Default to 1.
        /// </remarks>
        [XmlAttribute("kerning")]
        public int Kerning = 1;

        /// <summary>
        /// Horizontal alignment of the text within the object.
        /// </summary>
        /// <remarks>
        /// Defaults to <see cref="HorizontalAlign.Left"/>.
        /// </remarks>
        [XmlAttribute("halign")]
        public HorizontalAlign HorizontalAlignment = HorizontalAlign.Left;

        /// <summary>
        /// Vertical alignment of the text within the object.
        /// </summary>
        /// <remarks>
        /// Defaults to <see cref="VerticalAlign.Top"/>.
        /// </remarks>
        [XmlAttribute("valign")]
        public VerticalAlign VerticalAlignment = VerticalAlign.Top;

        [XmlText]
        public string Text;

        public bool ShouldSerializeFontFamily()
        {
            return FontFamily != null && FontFamily != "sand-serif";
        }

        public bool ShouldSerializePixelSize()
        {
            return PixelSize != 16;
        }

        public bool ShouldSerializeWrap()
        {
            return Wrap != 0;
        }

        public bool ShouldSerializeColorHex()
        {
            return ColorHex != "#000000";
        }
        
        public bool ShouldSerializeBold()
        {
            return Bold != 0;
        }

        public bool ShouldSerializeItalic()
        {
            return Italic != 0;
        }

        public bool ShouldSerializeUnderline()
        {
            return Underline != 0;
        }

        public bool ShouldSerializeStrikeout()
        {
            return Strikeout != 0;
        }

        public bool ShouldSerializeKerning()
        {
            return Kerning != 1;
        }

        public bool ShouldSerializeHorizontalAlignment()
        {
            return HorizontalAlignment != HorizontalAlign.Left;
        }

        public bool ShouldSerializeVerticalAlignment()
        {
            return VerticalAlignment != VerticalAlign.Top;
        }
    }
}
