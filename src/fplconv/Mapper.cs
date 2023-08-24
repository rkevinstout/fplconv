namespace fplconv;

using XPlane;
using Waypoint = XPlane.FlightPlan.Waypoint;
using WaypointType = XPlane.FlightPlan.Waypoint.WaypointType;

internal static class Mapper
{
    /// <summary>
    /// Maps a flight plan from Garmin's format to XPlane
    /// </summary>
    /// <param name="input">a serialized Garmin flight plan</param>
    /// <returns>an XPlane.FlightPlan</returns>
    /// <seealso cref="https://www8.garmin.com/xmlschemas/FlightPlanv1.xsd"/>
    /// <seealso cref="https://developer.x-plane.com/article/flightplan-files-v11-fms-file-format/"/>
    public static FlightPlan Map(this FlightPlan_t input)
    {
        var fms = new FlightPlan
        {
            Name = input.route.routename
        };

        fms.Route = MapRoute(input.waypointtable, input.route.routepoint);

        fms.Departure = fms.Route.First();

        if (fms.Departure.IsAirport)
        {
            fms.Departure.Via = Waypoint.LegType.DepartureAirport;
        }

        fms.Destination = fms.Route.Last();

        if (fms.Destination.IsAirport)
        {
            fms.Destination.Via = Waypoint.LegType.DestinationAirport;
        }

        return fms;
    }

    public static IEnumerable<Waypoint> MapRoute(
        Waypoint_t[] waypoints, 
        RoutePoint_t[] routePoints
        )
    {
        var dictionary = waypoints.ToDictionary();

        foreach (var routePoint in routePoints)
        {
            var key = routePoint.ToWaypointTableKey();

            // we need the copy from the waypomt table
            // to get the lat/lon coordinates
            yield return dictionary[key].ToWaypoint();
        }
    }

    /// <summary>
    /// Maps a Garmin waypoint to its XPlane counterpart
    /// </summary>
    /// <param name="input"></param>
    /// <returns>the waypoint</returns>
    private static Waypoint ToWaypoint(this Waypoint_t input) => new()
    {
        Identifier = input.identifier,
        Latitude = input.lat,
        Longitude = input.lon,
        Type = input.type.ToWaypointType()
    };

    private static WaypointType ToWaypointType(this WaypointType_t input) => input switch
    {
        WaypointType_t.USERWAYPOINT => WaypointType.UserFix,
        WaypointType_t.AIRPORT => WaypointType.Airport,
        WaypointType_t.NDB => WaypointType.NDB,
        WaypointType_t.VOR => WaypointType.VOR,
        WaypointType_t.INT => WaypointType.NamedFix,
        WaypointType_t.INTVRP => WaypointType.NamedFix,
        _ => WaypointType.NamedFix,
    };


    /// <summary>
    /// Creates a dictionary for looking up <paramref name="waypoints"/>
    /// in the waypoint table
    /// </summary>
    /// <remarks>
    /// The XSD defines a unique key for the table however xsd.exe does not surface
    /// this.  Enforcement of this constraint is a function of schema validation which
    /// can not be presupposed.  This dictionary simulates the function of that constraint
    /// </remarks>
    /// <param name="waypoints">an unordered list of unique 
    /// waypoints referenced by a flight plan</param>
    /// <returns>a map of WaypointTableKey->Waypoint</returns>
    /// <seealso cref="https://www8.garmin.com/xmlschemas/FlightPlanv1.xsd"/>
    private static IDictionary<WaypointTableKey, Waypoint_t> ToDictionary(this Waypoint_t[] waypoints)
    {
        var dictionary = new Dictionary<WaypointTableKey, Waypoint_t>();

        foreach (var waypoint in waypoints)
        {
            var key = waypoint.ToWaypointTableKey();

            // the xsd:key has a unique constraint however compliance is 
            // voluntary so we ignore duplicates
            if (!dictionary.TryGetValue(key, out _))
            {
                dictionary.Add(key, waypoint);
            }
        }
        return dictionary;    }
    
    /// <summary>
    /// Constructs a key from data in a <paramref name="wayPoint"/>
    /// </summary>
    /// <param name="wayPoint"></param>
    /// <returns></returns>
    internal static WaypointTableKey ToWaypointTableKey(this Waypoint_t wayPoint)
    {
        return new WaypointTableKey(
            wayPoint.identifier,
            wayPoint.type,
            wayPoint.countrycode            
            );    }

    /// <summary>
    /// Constructs a key from data in a <paramref name="routePoint"/>
    /// </summary>
    /// <param name="routePoint">An abbreviated representation of a 
    /// Waypoint for denoting its position in a route
    /// </param>
    /// <returns></returns>
    internal static WaypointTableKey ToWaypointTableKey(this RoutePoint_t routePoint)
    {
        return new WaypointTableKey(
            routePoint.waypointidentifier,
            routePoint.waypointtype,
            routePoint.waypointcountrycode            
            );
    }

    /// <summary>
    /// Composite key for selecting a Waypoint from the Waypoint table
    /// </summary>
    /// <remarks>This is an analog of WaypointIdKey which the schema states
    /// "requires that the identifier, type, and country-codes 
    /// values be unique in the waypoint table."
    /// </remarks>
    /// <param name="Identifier">3-5 character identifier of the waypoint </param>
    /// <param name="WaypointType">Type of the waypoint (NDB, VOR, Airport, etc)</param>
    /// <param name="CountryCode">2 character ICAO Nationality Code</param>
    internal record WaypointTableKey(
        string Identifier, 
        WaypointType_t WaypointType, 
        string CountryCode
        )     
    { }
}
