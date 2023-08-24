using FluentAssertions;

namespace fplconv.Tests;

public class FileConverterTests
{   
    [Fact]
    public void CanConvert_File()
    {
        var options = new Options { AiracCycle = "2112" };

        using var textWriter = new StringWriter();

        var converter = new FileConverter(
            (options) => TestData.CreateStream(TestData.KAUS_KIAH_Garmin),
            (fp, options) => textWriter
        );

        converter.Convert(options);

        var output = textWriter.ToString(); 

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
}
