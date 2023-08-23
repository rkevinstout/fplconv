using System.Xml.Serialization;
using fplconv.XPlane;

namespace fplconv;

class FileConverter
{
    public static void Convert(Options options)
    {
        var input = ReadInput(options);

        var output = input.Map();

        WriteOutput(output, options);
    }
    
    static FlightPlan_t ReadInput(Options options)
    {   
        var serializer = new XmlSerializer(typeof(FlightPlan_t));

        using var stream = CreateInputStream(options);

        var obj = serializer.Deserialize(stream);

        return (FlightPlan_t)obj;
    }

    static void WriteOutput(FlightPlan flightPlan, Options options)
    {
        using var textWriter = CreateTextWriter(flightPlan, options);

        var text = flightPlan.Format(options);

        textWriter.Write(text);
        textWriter.Flush();
    }

    static TextWriter CreateTextWriter(FlightPlan flightPlan, Options options)
    {
        if (string.IsNullOrEmpty(options.OutputLocation))
        {
            return Console.Out;
        }

        var fileName = options.OutputFile ?? flightPlan.Name;
        
        var path = Path.Combine(
            options.OutputLocation,  
            $"{fileName}.fms"
        );
        
        return new StreamWriter(path);
    }

    static Stream CreateInputStream(Options options)
    {
        if (!string.IsNullOrEmpty(options.InputFile))
        {
            return new FileStream(options.InputFile, FileMode.Open);
        }

        if (!Console.IsInputRedirected)
        {
            throw new Exception("stdin has not been redirected");
        }

        return Console.OpenStandardInput();
    }
}
