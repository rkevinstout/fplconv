using CommandLine;
using fplconv;

var result = Parser.Default.ParseArguments<Options>(args);

await result.WithParsedAsync(Run);
await result.WithNotParsedAsync(HandleParseError);

static async Task<int> Run(Options options)
{
    var converter = new FileConverter(
        InputStreamFactory.Create,
        TextWriterFactory.Create
        );
    try 
    {
        await converter.Convert(options);  
    }
    catch (Exception ex)    
    {
        Console.WriteLine($"Error: {ex.Message}");
        return 1;
    }  
    return 0;   
} 

static Task<int> HandleParseError(IEnumerable<Error> errors)
{
    if (errors.IsVersion())
    {
        Console.WriteLine("Version Request");
    }

    if (errors.IsHelp())
    {
        Console.WriteLine("Help Request");
    }

    return Task.FromResult(0);
}
