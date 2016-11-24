using System;

namespace Tiled
{
    /// <summary>
    /// Represents a color that can be converted to and from <c>#AARRGGBB</c>.
    /// </summary>
    public class TiledColor
    {
        /// <summary>
        /// The alpha.
        /// </summary>
        public byte Alpha;

        /// <summary>
        /// The red.
        /// </summary>
        public byte Red;
        
        /// <summary>
        /// The green.
        /// </summary>
        public byte Green;

        /// <summary>
        /// The blue.
        /// </summary>
        public byte Blue;

        /// <summary>
        /// Create a color from a red, green, and blue. <see cref="Alpha"/> is set to 255.
        /// </summary>
        /// <param name="red">The red.</param>
        /// <param name="green">The green.</param>
        /// <param name="blue">The blue.</param>
        public TiledColor(byte red, byte green, byte blue)
            : this(255, red, green, blue)
        {
        }

        /// <summary>
        /// Create a color from an alpha, red, green, and blue.
        /// </summary>
        /// <param name="alpha">The alpha.</param>
        /// <param name="red">The red.</param>
        /// <param name="green">The green.</param>
        /// <param name="blue">The blue.</param>
        public TiledColor(byte alpha, byte red, byte green, byte blue)
        {
            Alpha = alpha;
            Red = red;
            Green = green;
            Blue = blue;
        }

        /// <summary>
        /// Convert the color to a hex string (<c>#AARRGGBB</c>, if <paramref name="withAlpha"/>; <c>#RRGGBB</c>, otherwise.
        /// </summary>
        /// <param name="withAlpha">Whether or not to include <see cref="Alpha"/>.</param>
        /// <returns>The color in hex format (<c>#AARRGGBB</c>, if <paramref name="withAlpha"/>; <c>#RRGGBB</c>, otherwise.</returns>
        public string ToHex(bool withAlpha = true)
        {
            if (withAlpha)
            {
                return "#" +
                       Alpha.ToString("x2") +
                       Red.ToString("x2") +
                       Green.ToString("x2") +
                       Blue.ToString("x2");
            }

            return "#" +
                   Red.ToString("x2") +
                   Green.ToString("x2") +
                   Blue.ToString("x2");
        }

        /// <summary>
        /// Convert the color to a hex string (<c>RRGGBB</c>).
        /// </summary>
        /// <returns>The color in hex format (<c>RRGGBB</c>).</returns>
        public string ToTrans()
        {
            return Red.ToString("x2") +
                   Green.ToString("x2") +
                   Blue.ToString("x2");
        }

        /// <summary>
        /// Create a color from a hex string (either <c>#AARRGGBB</c> or <c>#RRGGBB</c>).
        /// </summary>
        /// <param name="hex">The hex string.</param>
        /// <returns>A color based on the given <paramref name="hex"/> string.</returns>
        public static TiledColor FromHex(string hex)
        {
            hex = hex.Substring(1);

            if (hex.Length == 8)
                return new TiledColor(Convert.ToByte(hex.Substring(0, 2)), Convert.ToByte(hex.Substring(2, 4)),
                    Convert.ToByte(hex.Substring(4, 6), Convert.ToByte(hex.Substring(6, 8))));

            return new TiledColor(Convert.ToByte(hex.Substring(0, 2)), Convert.ToByte(hex.Substring(2, 4)),
                Convert.ToByte(hex.Substring(4, 6)));
        }

        /// <summary>
        /// Create a color from a hex string (<c>RRGGBB</c>).
        /// </summary>
        /// <param name="hex">The hex string.</param>
        /// <returns>A color based on the given <paramref name="hex"/> string.</returns>
        public static TiledColor FromTrans(string hex)
        {
            return new TiledColor(Convert.ToByte(hex.Substring(0, 2)), Convert.ToByte(hex.Substring(2, 4)),
                Convert.ToByte(hex.Substring(4, 6)));
        }
    }
}
