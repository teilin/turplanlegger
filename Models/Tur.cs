using System;
using System.Collections.Generic;

namespace turplanlegger.Models
{
    public class Tur
    {
        public string Lisens { get; set; }
        public string Navn { get; set; }
        public string Status { get; set; }
        public GeoJson GeoJson { get; set; }
    }
}