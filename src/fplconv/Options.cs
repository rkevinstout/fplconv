using CommandLine;

namespace fplconv;

internal class Options
{  
    [Option('c', Default = "1710", HelpText ="AIRAC Cycle Identifier")]
    public string AiracCycle {get;set;}
    
    [Value(0, HelpText ="fpl file to be converted.  Defaults to stdin")]    
    public string InputFile { get; set;}

    [Option('o', HelpText ="Output file location")]
    public string OutputLocation { get; set; }

    [Option('n', HelpText = "Output file name.  Defaults to stdout")]
    public string OutputFile { get; set; }
}
