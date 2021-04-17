using System.Text;

namespace fplconv.XPlane
{
    internal static class Formatter
    {
        // https://developer.x-plane.com/article/flightplan-files-v11-fms-file-format/

        internal static string Format(this FlightPlan flightPlan, Settings settings = null)
        {
            var config = settings ?? new Settings();
            var buffer = new StringBuilder();

            buffer.AppendLine("I");
            buffer.AppendLine(config.Version);
            buffer.AppendLine(config.Cycle);

            if (flightPlan.Departure.IsAirport)
                buffer.Append("A");

            buffer.AppendLine($"DEP {flightPlan.Departure.Waypoint}");

            if (flightPlan.Destination.IsAirport)
                buffer.Append("A");

            buffer.AppendLine($"DES {flightPlan.Destination.Waypoint}");

            buffer.AppendLine($"NUMENR {flightPlan.Route.Count}");

            foreach (var waypoint in flightPlan.Route)
            {
                var s = $"{(int)waypoint.Type} {waypoint.Identifier} {waypoint.Via.FormatLegType()} {waypoint.Altitude} {waypoint.Latitude} {waypoint.Longitude}";

                buffer.AppendLine(s);
            }

            return buffer.ToString();
        }

        static string FormatLegType(this FlightPlan.Waypoint.LegType input)
        {
            switch (input)
            {
                case FlightPlan.Waypoint.LegType.DepartureAirport:
                    return "ADEP";
                case FlightPlan.Waypoint.LegType.DestinationAirport:
                    return "ADES";
                case FlightPlan.Waypoint.LegType.Direct:
                    return "DRCT";
                case FlightPlan.Waypoint.LegType.Airway:
                    return "DRCT";
                default:
                    return "DRCT";
            }
        }
    }
}
