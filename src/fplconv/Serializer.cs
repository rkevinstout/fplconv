using System.Xml.Serialization;

namespace fplconv;

internal static class Serializer
{
    internal static FlightPlan_t Deserialize(Stream stream)
    {
        var serializer = new XmlSerializer(typeof(FlightPlan_t));

        var obj = serializer.Deserialize(stream);

        return obj as FlightPlan_t;
    }
}
