using FluentAssertions;

namespace fplconv.Tests;

public class MapperTests
{
    [Fact]
    public void FlightPlansShouldMatch()
    {
        using var stream = TestData.CreateStream(TestData.KAUS_KIAH_Garmin);

        var garmin = Serializer.Deserialize(stream);

        var flightPlan = Mapper.Map(garmin);

        flightPlan.Route.Count().Should().Be(8 );
        flightPlan.Departure.Identifier.Should().Be("KAUS");
        flightPlan.Departure.IsAirport.Should().BeTrue();   
        flightPlan.Destination.Identifier.Should().Be("KIAH");
        flightPlan.Destination.IsAirport.Should().BeTrue();
    }

    [Fact]
    public void WaypointAndRoutePointProduceIdenticalKeys()
    {
        var waypointKey = new Waypoint_t
        {
            identifier = "KFOO",
            type = WaypointType_t.NDB,
            countrycode = "K9"
        }.ToWaypointTableKey();

        var routePointKey = new RoutePoint_t
        {
            waypointidentifier = "KFOO",
            waypointtype = WaypointType_t.NDB,
            waypointcountrycode = "K9"
        }.ToWaypointTableKey();

        var result = waypointKey.Equals(routePointKey);

        result.Should().BeTrue();
    }

    [Fact]
    public void DifferentPointsProduceDiferentKeys()
    {
        var waypointKey = new Waypoint_t
        {
            identifier = "KFOO",
            type = WaypointType_t.NDB,
            countrycode = "K9"
        }.ToWaypointTableKey();

        var routePointKey = new RoutePoint_t
        {
            waypointidentifier = "KFOO",
            waypointtype = WaypointType_t.NDB,
            waypointcountrycode = "K8"  // <- 
        }.ToWaypointTableKey();

        var result = waypointKey.Equals(routePointKey);

        result.Should().BeFalse();
    }
}