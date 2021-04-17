using fplconv.XPlane;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace fplconv
{
    class Program
    {
        static void Main(string[] args)
        {
            var settings = Settings.Read(args);

            settings.Validate();

            var input = ReadInput(settings.InputFile);

            var result = input.Convert();

            WriteOutput(result, settings);
        }

        static FlightPlan_t ReadInput(string fileName)
        {
            using (var fs = new FileStream(fileName, FileMode.Open))
            {
                var serializer = new XmlSerializer(typeof(FlightPlan_t));

                var obj = serializer.Deserialize(fs);

                return (FlightPlan_t)obj;
            }
        }

        static void WriteOutput(FlightPlan flightPlan, Settings settings)
        {
            var path = $"{settings.OutputDirectory}\\{flightPlan.Name}.fms";

            var text = flightPlan.Format(settings);

            File.WriteAllText(path, text, Encoding.UTF8);
        }
    }
}
