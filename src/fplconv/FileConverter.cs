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
    
    public void Convert(Options options)
    {
        var input = ReadInput(options);

        var output = input.Map();

        WriteOutput(output, options);
    }

    private FlightPlan_t ReadInput(Options options)
    {
        using var stream = GetStream(options);

        return Serializer.Deserialize(stream);
    }

    private void WriteOutput(FlightPlan flightPlan, Options options)
    {
        using TextWriter textWriter = CreateTextWriter(flightPlan, options);

        var text = flightPlan.Format(options);

        textWriter.Write(text);
        textWriter.Flush();
    }

    private TextWriter CreateTextWriter(FlightPlan flightPlan, Options options) 
        => _textWriterFactory.Invoke(flightPlan, options);

    private Stream GetStream(Options options) 
        => _inputStreamFactory.Invoke(options);
}
