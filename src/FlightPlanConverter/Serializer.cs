namespace FlightPlanConverter;

using System.Xml;
using System.Xml.Serialization;

internal static class Serializer
{
    internal static FlightPlan_t Deserialize(Stream stream)
    {
        var serializer = new XmlSerializer(typeof(FlightPlan_t));

        using var reader = new XmlTextReader(stream);

        var obj = serializer.Deserialize(reader);

        var flightPlan = obj as FlightPlan_t;

        return flightPlan ?? throw new InvalidOperationException("input could not be deserialized");
    }
}
