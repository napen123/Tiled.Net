using System;

namespace Tiled
{
    public class TiledColor
    {
        public byte Alpha;
        public byte Red;
        public byte Green;
        public byte Blue;

        public TiledColor(byte red, byte green, byte blue)
            : this(255, red, green, blue)
        {
        }

        public TiledColor(byte alpha, byte red, byte green, byte blue)
        {
            Alpha = alpha;
            Red = red;
            Green = green;
            Blue = blue;
        }

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

        public string ToTrans()
        {
            return Red.ToString("x2") +
                   Green.ToString("x2") +
                   Blue.ToString("x2");
        }

        public static TiledColor FromHex(string hex)
        {
            hex = hex.Substring(1);

            if (hex.Length == 8)
                return new TiledColor(Convert.ToByte(hex.Substring(0, 2)), Convert.ToByte(hex.Substring(2, 4)),
                    Convert.ToByte(hex.Substring(4, 6), Convert.ToByte(hex.Substring(6, 8))));

            return new TiledColor(Convert.ToByte(hex.Substring(0, 2)), Convert.ToByte(hex.Substring(2, 4)),
                Convert.ToByte(hex.Substring(4, 6)));
        }

        public static TiledColor FromTrans(string hex)
        {
            return new TiledColor(Convert.ToByte(hex.Substring(0, 2)), Convert.ToByte(hex.Substring(2, 4)),
                Convert.ToByte(hex.Substring(4, 6)));
        }
    }
}
