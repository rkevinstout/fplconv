using System.Text;

namespace fplconv.XPlane;

using static FlightPlan.Waypoint;

internal static class Formatter
{
    /// <summary>
    /// Generates the content of an x-plane .fms file
    /// </summary>
    /// <param name="flightPlan"></param>
    /// <param name="options"></param>
    /// <returns></returns>
    /// <see cref="https://developer.x-plane.com/article/flightplan-files-v11-fms-file-format/"/>
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

    private static object[] ToArray(this FlightPlan.Waypoint waypoint) => new object[]
        {
            waypoint.Type.ToString("D"),
            waypoint.Identifier,
            waypoint.FormatLegType(),
            waypoint.Altitude,
            waypoint.Latitude,
            waypoint.Longitude
        };

    private static string FormatLegType(this FlightPlan.Waypoint input)
    {
        // Per XPlane docs ->
        // The third column is the via/special column. 
        // It can have the following values: ADEP/ADES for departure or d
        // destination airport of the flightplan, DRCT for a direct or 
        // random route leg to the waypoint, or the name of an airway or 
        // ATS route to the waypoint.
        
        if (input.Via == LegType.Airway && input.Airway is not null)        
            return input.Airway;

        return input.Via switch
        {
            LegType.DepartureAirport => "ADEP",
            LegType.DestinationAirport => "ADES",
            LegType.Direct => "DRCT",
            _ => "DRCT",
        };
    }
}
