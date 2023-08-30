namespace FlightPlanConverter;
using CommandLine;

internal class Options
{
    [Value(0, HelpText = "input file to be converted.  Defaults to stdin")]
    public string? InputFile { get; set; }

    [Option('c', Default = "1710", HelpText = "AIRAC Cycle Identifier")]
    public string? AiracCycle { get; set; }

    [Option('o', HelpText = "Output file location")]
    public string? OutputLocation { get; set; }

    [Option('n', HelpText = "Output file name.  Defaults to stdout")]
    public string? OutputFile { get; set; }
}
