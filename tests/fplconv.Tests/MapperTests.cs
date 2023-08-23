using FluentAssertions;

namespace fplconv.Tests;

public class MapperTests
{
    [Fact]
    public void FlightPlansShouldMatch()
    {
        using var stream = TestData
            .CreateStream(TestData.KAUS_KIAH_Garmin);

        var garmin = Serializer.Deserialize(stream);

        var flightPlan = Mapper.Map(garmin);

        flightPlan.Route.Count().Should().Be(8 );
        flightPlan.Departure.Identifier.Should().Be("KAUS");
        flightPlan.Departure.IsAirport.Should().BeTrue();   
        flightPlan.Destination.Identifier.Should().Be("KIAH");
        flightPlan.Destination.IsAirport.Should().BeTrue();
    }
}