namespace FlightPlanConverter.Tests;

using static XPlane.FlightPlan.Waypoint;

public class MapperTests
{
    [Fact]
    public void FlightPlansShouldMatch()
    {
        var garmin = TestData.CreateGarminFlightPlan();

        var flightPlan = Mapper.Map(garmin);

        flightPlan.Route.Length.Should().Be(4);

        flightPlan.Departure.Identifier.Should().Be("KCUB");
        flightPlan.Departure.IsAirport.Should().BeTrue();
        flightPlan.Route.First().Via.Should().Be(LegType.DepartureAirport);

        flightPlan.Destination.Identifier.Should().Be("KRDU");
        flightPlan.Destination.IsAirport.Should().BeTrue();
        flightPlan.Route.Last().Via.Should().Be(LegType.DestinationAirport);
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
    public void DifferentPointsProduceDifferentKeys()
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
