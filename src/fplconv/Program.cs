using CommandLine;
using fplconv;

Parser.Default.ParseArguments<Options>(args)
    .WithParsed(RunOptions)
    .WithNotParsed(HandleParseError);

static void RunOptions(Options options)
{
    var converter = new FileConverter(
        InputStreamFactory.Create,
        TextWriterFactory.Create
        );
    try 
    {
        converter.Convert(options);
    }
    catch (Exception ex)    
    {
        Console.WriteLine($"Error: {ex.Message}");
    }
}

static void HandleParseError(IEnumerable<Error> errors)
{
    if (errors.IsVersion())
    {
        Console.WriteLine("Version Request");
        return;
    }

    if (errors.IsHelp())
    {
        Console.WriteLine("Help Request");
        return;
    }
}
