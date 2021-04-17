using fplconv.XPlane;
using System.Linq;

namespace fplconv
{
    static class Converter
    {
        public static FlightPlan Convert(this FlightPlan_t input)
        {
            var fms = new FlightPlan();

            fms.Name = input.route.routename;

            var first = input.route.routepoint.First();

            fms.Departure.Waypoint = first.waypointidentifier;
            fms.Departure.IsAirport = first.waypointtype == WaypointType_t.AIRPORT;

            var last = input.route.routepoint.Last();

            fms.Destination.Waypoint = last.waypointidentifier;
            fms.Destination.IsAirport = last.waypointtype == WaypointType_t.AIRPORT;

            foreach (var routePoint in input.route.routepoint)
            {
                var waypoint = Convert(routePoint, input.waypointtable);

                if (routePoint == first && routePoint.waypointtype == WaypointType_t.AIRPORT)
                    waypoint.Via = FlightPlan.Waypoint.LegType.DepartureAirport;

                if (routePoint == last && routePoint.waypointtype == WaypointType_t.AIRPORT)
                    waypoint.Via = FlightPlan.Waypoint.LegType.DestinationAirport;

                fms.Route.Add(waypoint);
            }

            return fms;
        }

        private static FlightPlan.Waypoint Convert(RoutePoint_t routePoint, Waypoint_t[] waypoints)
        {
            var output = new FlightPlan.Waypoint();

            var input = waypoints.Single(x => x.identifier == routePoint.waypointidentifier);

            output.Identifier = input.identifier;
            output.Latitude = input.lat;
            output.Longitude = input.lon;
            output.Type = Convert(input.type);  
            
            return output;
        }

        private static FlightPlan.Waypoint.WaypointType Convert(WaypointType_t input)
        {
            switch (input)
            {
                case WaypointType_t.USERWAYPOINT:
                    return FlightPlan.Waypoint.WaypointType.UserFix;
                case WaypointType_t.AIRPORT:
                    return FlightPlan.Waypoint.WaypointType.Airport;
                case WaypointType_t.NDB:
                    return FlightPlan.Waypoint.WaypointType.NDB;
                case WaypointType_t.VOR:
                    return FlightPlan.Waypoint.WaypointType.VOR;
                case WaypointType_t.INT:
                    return FlightPlan.Waypoint.WaypointType.NamedFix;
                case WaypointType_t.INTVRP:
                    return FlightPlan.Waypoint.WaypointType.NamedFix;
                default:
                    return FlightPlan.Waypoint.WaypointType.NamedFix;
            }
        }
    }
}
