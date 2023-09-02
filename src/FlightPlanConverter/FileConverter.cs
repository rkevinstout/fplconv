namespace FlightPlanConverter;

using XPlane;

internal sealed class FileConverter
{
    private readonly Func<Options, Stream> _inputStreamFactory;
    private readonly Func<FlightPlan, Options, TextWriter> _textWriterFactory;

    internal FileConverter(
        Func<Options, Stream> inputStreamFactory,
        Func<FlightPlan, Options, TextWriter> textWriterFactory
        )
    {
        _inputStreamFactory = inputStreamFactory;
        _textWriterFactory = textWriterFactory;
    }

    internal void Convert(Options options)
    {
        var input = ReadInput(options);

        var output = input.Map();

        WriteOutput(output, options);
    }

    private FlightPlan_t ReadInput(Options options)
    {
        using var stream = GetStream(options);

        var flightPlan = Serializer.Deserialize(stream);

        return flightPlan ?? throw new InvalidOperationException("input could not be deserialized");
    }

    private void WriteOutput(FlightPlan flightPlan, Options options)
    {
        using var textWriter = CreateTextWriter(flightPlan, options);

        var text = flightPlan.Format(options);

        textWriter.Write(text);
        textWriter.Flush();
    }

    private TextWriter CreateTextWriter(FlightPlan flightPlan, Options options)
        => _textWriterFactory.Invoke(flightPlan, options);

    private Stream GetStream(Options options)
        => _inputStreamFactory.Invoke(options);
}
