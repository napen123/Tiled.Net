using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Tiled
{
    public class TiledPolygon : TiledBaseObject
    {
        [XmlIgnore] public List<Tuple<int, int>> Points;

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
