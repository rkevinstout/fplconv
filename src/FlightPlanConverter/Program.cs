using CommandLine;
using FlightPlanConverter;

var result = Parser.Default.ParseArguments<Options>(args);

var exitCode = result.MapResult(Run, _ => 1);

return exitCode;

static int Run(Options options)
{
    try
    {
        var converter = new FileConverter(
            InputStreamFactory.Create,
            TextWriterFactory.Create
            );

        converter.Convert(options);
    }
    catch (Exception ex)
    {
        Console.WriteLine($@"Error: {ex.Message}");
        return 1;
    }
    return 0;
}
