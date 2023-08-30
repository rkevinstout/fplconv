namespace FlightPlanConverter;

using System.Text;
using FlightPlanConverter.XPlane;

internal static class TextWriterFactory
{
    internal static TextWriter Create(FlightPlan flightPlan, Options options)
    {
        if (string.IsNullOrEmpty(options.OutputLocation))
        {
            return Console.Out;
        }

        if (!Directory.Exists(options.OutputLocation))
        {
            throw new FileNotFoundException($"Directory {options.OutputLocation} could not be found");
        }

        var fileName = options.OutputFile ?? flightPlan.Name;

        var path = Path.Combine(
            options.OutputLocation,
            $"{fileName}.fms"
        );

        return new StreamWriter(path, false, Encoding.UTF8);
    }
}
