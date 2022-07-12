using System;
using System.Collections.Generic;
using System.Text;

namespace LoggingKata
{
    public class TacoBell : ITrackable
    {
        public string Name { get; set; }
        public Point Location { get; set; }

        public TacoBell(double latitude, double longitude, string name)
        {
            Location = new Point() { Latitude = latitude, Longitude = longitude };
            Name = name;
        }
    }
}
