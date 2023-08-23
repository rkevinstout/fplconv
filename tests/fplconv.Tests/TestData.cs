using System.Text;

namespace fplconv.Tests;

public static class TestData
{
  public static Stream CreateStream(string input)
    {
        byte[] bytes = Encoding.UTF8.GetBytes(input);
        var ms = new MemoryStream(bytes);

        return ms;
  }
  
  
    public static string KAUS_KIAH_Garmin => $@"<?xml version=""1.0"" encoding=""utf-8""?>
<flight-plan xmlns=""http://www8.garmin.com/xmlschemas/FlightPlan/v1"">
  <created>2023-08-23T10:49:34Z</created>
  <waypoint-table>
    <waypoint>
      <identifier>KAUS</identifier>
      <type>AIRPORT</type>
      <country-code>K4</country-code>
      <lat>30.194528</lat>
      <lon>-97.669875</lon>
      <comment />
    </waypoint>
    <waypoint>
      <identifier>HOOKK</identifier>
      <type>INT</type>
      <country-code>K4</country-code>
      <lat>30.360000</lat>
      <lon>-97.203022</lon>
      <comment />
    </waypoint>
    <waypoint>
      <identifier>ILEXY</identifier>
      <type>INT</type>
      <country-code>K4</country-code>
      <lat>30.352778</lat>
      <lon>-97.079294</lon>
      <comment />
    </waypoint>
    <waypoint>
      <identifier>BEANE</identifier>
      <type>INT</type>
      <country-code>K4</country-code>
      <lat>30.605144</lat>
      <lon>-96.420769</lon>
      <comment />
    </waypoint>
    <waypoint>
      <identifier>JJACK</identifier>
      <type>INT</type>
      <country-code>K4</country-code>
      <lat>30.509017</lat>
      <lon>-96.268639</lon>
      <comment />
    </waypoint>
    <waypoint>
      <identifier>SUUNR</identifier>
      <type>INT</type>
      <country-code>K4</country-code>
      <lat>30.360908</lat>
      <lon>-96.035372</lon>
      <comment />
    </waypoint>
    <waypoint>
      <identifier>TTORO</identifier>
      <type>INT</type>
      <country-code>K4</country-code>
      <lat>30.138083</lat>
      <lon>-95.953386</lon>
      <comment />
    </waypoint>
    <waypoint>
      <identifier>KIAH</identifier>
      <type>AIRPORT</type>
      <country-code>K4</country-code>
      <lat>29.984436</lat>
      <lon>-95.341442</lon>
      <comment />
    </waypoint>
  </waypoint-table>
  <route>
    <route-name>KAUS KIAH</route-name>
    <flight-plan-index>1</flight-plan-index>
    <route-point>
      <waypoint-identifier>KAUS</waypoint-identifier>
      <waypoint-type>AIRPORT</waypoint-type>
      <waypoint-country-code>K4</waypoint-country-code>
    </route-point>
    <route-point>
      <waypoint-identifier>HOOKK</waypoint-identifier>
      <waypoint-type>INT</waypoint-type>
      <waypoint-country-code>K4</waypoint-country-code>
    </route-point>
    <route-point>
      <waypoint-identifier>ILEXY</waypoint-identifier>
      <waypoint-type>INT</waypoint-type>
      <waypoint-country-code>K4</waypoint-country-code>
    </route-point>
    <route-point>
      <waypoint-identifier>BEANE</waypoint-identifier>
      <waypoint-type>INT</waypoint-type>
      <waypoint-country-code>K4</waypoint-country-code>
    </route-point>
    <route-point>
      <waypoint-identifier>JJACK</waypoint-identifier>
      <waypoint-type>INT</waypoint-type>
      <waypoint-country-code>K4</waypoint-country-code>
    </route-point>
    <route-point>
      <waypoint-identifier>SUUNR</waypoint-identifier>
      <waypoint-type>INT</waypoint-type>
      <waypoint-country-code>K4</waypoint-country-code>
    </route-point>
    <route-point>
      <waypoint-identifier>TTORO</waypoint-identifier>
      <waypoint-type>INT</waypoint-type>
      <waypoint-country-code>K4</waypoint-country-code>
    </route-point>
    <route-point>
      <waypoint-identifier>KIAH</waypoint-identifier>
      <waypoint-type>AIRPORT</waypoint-type>
      <waypoint-country-code>K4</waypoint-country-code>
    </route-point>
  </route>
</flight-plan>
";

}
