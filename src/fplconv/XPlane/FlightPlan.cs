namespace fplconv.XPlane;

/// <summary>
/// Represents the components of a flight plan as described
/// in the x-plane documentation
/// </summary>
/// <see cref="https://developer.x-plane.com/article/flightplan-files-v11-fms-file-format/"/> 
public class FlightPlan
{   
    public FlightPlan(string name, Waypoint[] waypoints)
    {
        Name = name;
        Route = waypoints;        
    }
    
    public string? Name { get; }

    public Waypoint[] Route { get; }

    public DepartureBlock Departure => new(this);

    public DestinationBlock Destination => new(this);

    public class DepartureBlock : TerminalBlock
    {
        public Waypoint Waypoint => _parent.Route.First();

        public bool IsAirport => Waypoint.IsAirport;

        public Procedure Procedure => new();

        public DepartureBlock(FlightPlan parent): base(parent)
        { }
    }

    public class DestinationBlock : TerminalBlock
    {
        public Waypoint Waypoint => _parent.Route.Last();

        public bool IsAirport => Waypoint.IsAirport;

        public Procedure Arrival { get; set; } = new();    

        public Procedure Approach { get; set; } = new();

        public DestinationBlock(FlightPlan parent) : base(parent)
        { }
    }

    public abstract class TerminalBlock
    {
        protected readonly FlightPlan _parent;      
        
        public string? Runway { get; set; }

        protected TerminalBlock(FlightPlan parent)
        {
            _parent = parent;
        }
    }

    public class Procedure
    {
        public string? Name { get; set;}

        public string? Transition { get; set; }
    }

    public class Waypoint
    {
        public Waypoint(
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

        public LegType Via { get; set; } = LegType.Direct;

        public string? Airway { get; set; }

        public decimal Altitude { get; set; }

        public decimal Latitude { get; set; }

        public decimal Longitude { get; set; }

        public bool IsAirport => Type == WaypointType.Airport;
    }
}
