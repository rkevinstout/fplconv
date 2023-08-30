namespace FlightPlanConverter.XPlane;

/// <summary>
/// Represents the components of a flight plan as described
/// in the x-plane documentation
/// </summary>
/// <see cref="https://developer.x-plane.com/article/flightplan-files-v11-fms-file-format/"/>
internal sealed class FlightPlan
{
    internal FlightPlan(string name, Waypoint[] waypoints)
    {
        Name = name;
        Route = waypoints;
    }

    public string Name { get; }

    public Waypoint[] Route { get; }

    public DepartureBlock Departure => new(Route.First());

    public DestinationBlock Destination => new(Route.Last());

    internal sealed class DepartureBlock : TerminalBlock
    {
        public Procedure Procedure { get; set; } = new();

        internal DepartureBlock(Waypoint waypoint) : base(waypoint)
        { }
    }

    internal sealed class DestinationBlock : TerminalBlock
    {
        public Procedure Arrival { get; set; } = new();

        public Procedure Approach { get; set; } = new();

        internal DestinationBlock(Waypoint waypoint) : base(waypoint)
        { }
    }

    internal abstract class TerminalBlock
    {
        private Waypoint Waypoint { get; }

        public string Identifier => Waypoint.Identifier;

        public bool IsAirport => Waypoint.Type == Waypoint.WaypointType.Airport;

        public string? Runway { get; set; }

        protected TerminalBlock(Waypoint waypoint) => Waypoint = waypoint;
    }

    internal sealed class Procedure
    {
        public string? Name { get; set; }

        public string? Transition { get; set; }
    }

    internal sealed class Waypoint
    {
        internal Waypoint(
            string identifier,
            WaypointType type,
            decimal latitude,
            decimal longitude
            )
        {
            Identifier = identifier;
            Type = type;
            Latitude = latitude;
            Longitude = longitude;
        }

        internal enum WaypointType
        {
            Airport = 1,
            NDB = 2,
            VOR = 3,
            NamedFix = 11,
            UserFix = 28
        }

        internal enum LegType
        {
            DepartureAirport,
            DestinationAirport,
            Direct,
            Airway
        }

        public WaypointType Type { get; set; }

        public string Identifier { get; set; }

        public LegType Via { get; set; } = LegType.Direct;

        public string? Airway { get; set; }

        public decimal Altitude { get; set; }

        public decimal Latitude { get; set; }

        public decimal Longitude { get; set; }
    }
}
