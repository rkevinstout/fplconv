namespace fplconv;
internal static class InputStreamFactory
{
    internal static Stream Create(Options options)        
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
