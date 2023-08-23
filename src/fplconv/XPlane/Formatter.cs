using System.Linq;
using System.Text;

namespace fplconv.XPlane;

internal static class Formatter
{
    // https://developer.x-plane.com/article/flightplan-files-v11-fms-file-format/

    internal static string Format(this FlightPlan flightPlan, Options options = null)
    {
        options ??= new Options();
        var buffer = new StringBuilder();

        buffer.AppendLine("I");
        buffer.AppendLine(options.Version);
        buffer.AppendLine($"CYCLE {options.Cycle}");

        if (flightPlan.Departure.IsAirport)
            buffer.Append('A');

        buffer.AppendLine($"DEP {flightPlan.Departure.Identifier}");

        if (flightPlan.Destination.IsAirport)
            buffer.Append('A');

        buffer.AppendLine($"DES {flightPlan.Destination.Identifier}");

        buffer.AppendLine($"NUMENR {flightPlan.Route.ToArray().Length}");

        foreach (var waypoint in flightPlan.Route)
        {
            var s = $"{(int)waypoint.Type} {waypoint.Identifier} {waypoint.Via.FormatLegType()} {waypoint.Altitude} {waypoint.Latitude} {waypoint.Longitude}";

            buffer.AppendLine(s);
        }

        return buffer.ToString();
    }

    static string FormatLegType(this FlightPlan.Waypoint.LegType input) => input switch
    {
        FlightPlan.Waypoint.LegType.DepartureAirport => "ADEP",
        FlightPlan.Waypoint.LegType.DestinationAirport => "ADES",
        FlightPlan.Waypoint.LegType.Direct => "DRCT",
        FlightPlan.Waypoint.LegType.Airway => "DRCT",
        _ => "DRCT",
    };
}
