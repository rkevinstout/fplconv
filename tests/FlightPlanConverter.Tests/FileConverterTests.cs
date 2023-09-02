namespace FlightPlanConverter.Tests;

public class FileConverterTests
{
    private static string ProcessFile(string input, Options options)
    {
        using var textWriter = new StringWriter();

        var converter = new FileConverter(
            (_) => TestData.CreateStream(input),
            (_, _) => textWriter
        );

        converter.Convert(options);

        return textWriter.ToString();
    }

    [Fact]
    public void CanConvertFile()
    {
        var options = new Options { AiracCycle = "2112" };

        var output = ProcessFile(TestData.KAUS_KIAH_Garmin, options);

        output.Should().NotBeNullOrEmpty();

        var lines = output.Split(Environment.NewLine);

        lines[0].Should().Be("I");
        lines[1].Should().Be("1100 Version");
        lines[2].Should().Be("CYCLE 2112");
        lines[3].Should().Be("ADEP KAUS");
        lines[4].Should().Be("ADES KIAH");
        lines[5].Should().Be("NUMENR 8");
        lines[6].Should().Be("1 KAUS ADEP 0 30.194528 -97.669875");

        lines[13].Should().Be("1 KIAH ADES 0 29.984436 -95.341442");
    }

    [Fact]
    public void RegressionTest()
    {
        var options = new Options { AiracCycle = "2302" };

        var output = ProcessFile(TestData.KDFW_KIAH_Garmin, options);

        var expected = TestData.KDFW_KIAH_XPlane.Replace("\r\n", "\n");

        output.Should().BeEquivalentTo(expected);
    }
}
