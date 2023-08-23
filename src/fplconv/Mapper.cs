namespace fplconv;

using XPlane;
using Waypoint = XPlane.FlightPlan.Waypoint;
using WaypointType = XPlane.FlightPlan.Waypoint.WaypointType;

internal static class Mapper
{
    public static FlightPlan Map(this FlightPlan_t input)
    {
        var fms = new FlightPlan
        {
            Name = input.route.routename,
            Route = input.waypointtable
                .Select(ToWaypoint)
        };

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
}
