using System;
using System.Collections.Generic;

namespace turplanlegger.Models
{
    public class Tur : BaseResponse
    {
        public string Lisens { get; set; }
        public string Status { get; set; }
        public GeoJson GeoJson { get; set; }
    }
}