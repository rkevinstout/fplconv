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
    
    public void Validate()
    {
        if (string.IsNullOrEmpty(InputFile))
            throw new Exception("Input file not specified");

        if (!File.Exists(InputFile))
            throw new Exception($"Input file ({InputFile}) does not exist");

        if (!Directory.Exists(OutputLocation))
            throw new Exception($"Output directory ({OutputLocation}) does not exist");
    }

}
