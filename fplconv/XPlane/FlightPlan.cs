using System;
using System.Collections.Generic;
using System.Text;

namespace fplconv.XPlane
{
    class FlightPlan
    {
        public FlightPlan()
        {
            Departure = new EndPoint();
            Destination = new EndPoint();
            Route = new List<Waypoint>();
        }
        
        public string Name { get; set; }

        public EndPoint Departure { get; set; }

        public EndPoint Destination { get; set; }

        public List<Waypoint> Route { get; set; }

        public class EndPoint
        {
            public string Waypoint { get; set; }
            public bool IsAirport { get; set; }
        }

        public class Waypoint
        {
            public Waypoint()
            {
                Via = LegType.Direct;
            }

            public enum WaypointType
            {
                Airport = 1,
                NDB = 2,
                VOR = 3,
                NamedFix = 11,
                UserFix = 28
            }

            public enum LegType
            {
                DepartureAirport,
                DestinationAirport,
                Direct,
                Airway
            }

            public WaypointType Type { get; set; }

            public string Identifier { get; set; }

            public LegType Via { get; set; }

            public string Airway { get; set; }

            public decimal Altitude { get; set; }

            public decimal Latitude { get; set; }

            public decimal Longitude { get; set; }
        }
    }
}
