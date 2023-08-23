using CommandLine;
using fplconv;

Parser.Default.ParseArguments<Options>(args)
    .WithParsed(RunOptions)
    .WithNotParsed(HandleParseError);

static void RunOptions(Options options)
{
    FileConverter.Convert(options);
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
