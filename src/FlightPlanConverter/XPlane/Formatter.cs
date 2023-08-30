namespace FlightPlanConverter.XPlane;
using System.Text;

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
#pragma warning disable CA1305
        var buffer = new StringBuilder();

        _ = buffer.AppendLine("I")
            .AppendLine("1100 Version")
            .AppendLine($"CYCLE {options.AiracCycle}");

        if (flightPlan.Departure.IsAirport)
            _ = buffer.Append('A');

        _ = buffer.AppendLine($"DEP {flightPlan.Departure.Identifier}");

        if (flightPlan.Departure.Runway is not null)
            _ = buffer.AppendLine($"DEPRWY {flightPlan.Departure.Runway}");

        if (flightPlan.Departure.Procedure.Name is not null)
            _ = buffer.AppendLine($"SID {flightPlan.Departure.Procedure}");

        if (flightPlan.Departure.Procedure.Transition is not null)
            _ = buffer.AppendLine($"SIDTRANS {flightPlan.Departure.Procedure.Transition}");

        if (flightPlan.Destination.IsAirport)
            _ = buffer.Append('A');

        _ = buffer.AppendLine($"DES {flightPlan.Destination.Identifier}");

        if (flightPlan.Destination.Runway is not null)
            _ = buffer.AppendLine($"DESRWY {flightPlan.Destination.Runway}");

        if (flightPlan.Destination.Arrival.Name is not null)
            _ = buffer.AppendLine($"STAR {flightPlan.Destination.Arrival.Name}");

        if (flightPlan.Destination.Arrival.Transition is not null)
            _ = buffer.AppendLine($"STARTRANS {flightPlan.Destination.Arrival.Transition}");

        if (flightPlan.Destination.Approach.Name is not null)
            _ = buffer.AppendLine($"APP {flightPlan.Destination.Approach.Name}");

        if (flightPlan.Destination.Approach.Transition is not null)
            _ = buffer.AppendLine($"APPTRANS {flightPlan.Destination.Approach.Transition}");

        _ = buffer.AppendLine($"NUMENR {flightPlan.Route.Length}");

        foreach (var waypoint in flightPlan.Route)
        {
            _ = buffer.AppendJoin(' ', waypoint.ToArray());
            _ = buffer.AppendLine();
        }

        return buffer.ToString();
#pragma warning restore CA1305
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
        {
            return input.Airway;
        }

        return input.Via switch
        {
            LegType.DepartureAirport => "ADEP",
            LegType.DestinationAirport => "ADES",
            LegType.Direct => "DRCT",
            LegType.Airway => "DRCT",
            _ => "DRCT",
        };
    }
}
