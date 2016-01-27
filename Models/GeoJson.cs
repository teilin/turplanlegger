using System;
using System.Collections.Generic;

namespace turplanlegger.Models
{
    public class GeoJson
    {
        public string Type { get; set; }
        public IList<Coordinate> Coordinates { get; set;}
    }
}