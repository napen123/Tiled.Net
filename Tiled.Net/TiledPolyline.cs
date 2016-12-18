using System;
using System.Linq;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Tiled
{
    /// <summary>
    /// Represents a polyline object (<see cref="TiledObject"/>).
    /// </summary>
    public class TiledPolyline : TiledBaseObject
    {
        /// <summary>
        /// A list of x,y coordinates in pixels.
        /// </summary>
        [XmlIgnore]
        public List<Tuple<int, int>> Points;

        /// <summary>
        /// The points in string format (<c>0,0 12,5 5,7 ...</c>).
        /// Gets and sets the points in string format (<c>0,0 12,5 5,7 ...</c>).
        /// For a traditional object, use <see cref="Points"/>.
        /// </summary>
        [XmlAttribute("points")]
        public string PointsString
        {
            get
            {
                return Points.Aggregate("", (s, tuple) => s.Length == 0
                    ? tuple.Item1 + "," + tuple.Item2
                    : s + " " + tuple.Item1 + "," + tuple.Item2);
            }
            set
            {
                Points = new List<Tuple<int, int>>();

                var points = value.Split(' ');

                foreach (var point in points)
                {
                    var comma = point.Split(',');

                    Points.Add(new Tuple<int, int>(int.Parse(comma[0]), int.Parse(comma[1])));
                }
            }
        }
    }
}
