namespace fplconv.XPlane;

public class FlightPlan
{    
    public string Name { get; set; }

    public Waypoint Departure { get; set; }

    public Waypoint Destination { get; set; }

    public IEnumerable<Waypoint> Route { get; set; }

    public class Waypoint
    {
        public Waypoint() => Via = LegType.Direct;

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

        public bool IsAirport => Type == WaypointType.Airport;
    }
}
