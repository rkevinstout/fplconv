using System.Text;

namespace fplconv.XPlane;

internal static class Formatter
{
    // https://developer.x-plane.com/article/flightplan-files-v11-fms-file-format/

    internal static string Format(this FlightPlan flightPlan, Options options)
    {
        var buffer = new StringBuilder();

        buffer.AppendLine("I");
        buffer.AppendLine("1100 Version");
        buffer.AppendLine($"CYCLE {options.AiracCycle}");

        if (flightPlan.Departure.IsAirport)
            buffer.Append('A');

        buffer.AppendLine($"DEP {flightPlan.Departure.Identifier}");

        if (flightPlan.Destination.IsAirport)
            buffer.Append('A');

        buffer.AppendLine($"DES {flightPlan.Destination.Identifier}");

        buffer.AppendLine($"NUMENR {flightPlan.Route.Length}");

        foreach (var waypoint in flightPlan.Route)
        {
           buffer.AppendJoin(' ', waypoint.ToArray());
           buffer.AppendLine(); 
        }

        return buffer.ToString();
    }

    static object[] ToArray(this FlightPlan.Waypoint waypoint) => new object[]
        {
            waypoint.Type.ToString("D"),
            waypoint.Identifier ?? string.Empty,
            waypoint.Via.FormatLegType(),
            waypoint.Altitude,
            waypoint.Latitude,
            waypoint.Longitude
        };

    static string FormatLegType(this FlightPlan.Waypoint.LegType input) => input switch
    {
        FlightPlan.Waypoint.LegType.DepartureAirport => "ADEP",
        FlightPlan.Waypoint.LegType.DestinationAirport => "ADES",
        FlightPlan.Waypoint.LegType.Direct => "DRCT",
        FlightPlan.Waypoint.LegType.Airway => "DRCT",
        _ => "DRCT",
    };
}
