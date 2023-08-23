using CommandLine;
using fplconv;

Parser.Default.ParseArguments<Options>(args)
    .WithParsed(RunOptions)
    .WithNotParsed(HandleParseError);

static void RunOptions(Options options)
{
  //handle options
}

static void HandleParseError(IEnumerable<Error> errors)
{
  //handle errors
}