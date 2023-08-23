using fplconv.XPlane;

namespace fplconv;

class FileConverter
{
    private Func<Options, Stream> _inputStreamFactory;
    private Func<FlightPlan, Options, TextWriter> _textWriterFactory;

    public FileConverter(
        Func<Options, Stream> inputStreamFactory,
        Func<FlightPlan, Options, TextWriter> textWriterFactory
        )
    {
        _inputStreamFactory = inputStreamFactory;
        _textWriterFactory = textWriterFactory;        
    }
    
    public async Task Convert(Options options)
    {
        var input = ReadInput(options);

        var output = input.Map();

        await WriteOutput(output, options);
    }

    private FlightPlan_t ReadInput(Options options)
    {   
        using var stream = _inputStreamFactory.Invoke(options);

        return Serializer.Deserialize(stream);
    }

    private async Task WriteOutput(FlightPlan flightPlan, Options options)
    {
        using var textWriter = _textWriterFactory.Invoke(flightPlan, options);

        var text = flightPlan.Format(options);

        await textWriter.WriteAsync(text);
        await textWriter.FlushAsync();
    }
}
