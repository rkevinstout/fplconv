using System.Xml.Serialization;

namespace fplconv;

internal static class Serializer
{
    internal static FlightPlan_t Deserialize(Stream stream)
    {
        var serializer = new XmlSerializer(typeof(FlightPlan_t));

        var obj = serializer.Deserialize(stream);

        var flightPlan =  obj as FlightPlan_t;

        return flightPlan ?? throw new InvalidOperationException("input could not be deserialized");
    }
}
