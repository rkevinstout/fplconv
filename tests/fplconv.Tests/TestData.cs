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

  public static string KDFW_KIAH_XPlane => $@"I
1100 Version
CYCLE 2302
ADEP KDFW
ADES KIAH
NUMENR 15
1 KDFW ADEP 0 32.897233 -97.037694
3 TTT DRCT 0 32.869161 -97.040503
11 DARTZ DRCT 0 32.285756 -96.811050
11 BRDEN DRCT 0 31.886517 -96.655822
11 TORNN DRCT 0 31.520386 -96.514711
11 REFYN DRCT 0 31.267181 -96.359789
11 OILLL DRCT 0 31.003078 -96.199206
11 DPLAN DRCT 0 30.857528 -96.105428
11 SSTAX DRCT 0 30.711422 -96.011625
11 MPORT DRCT 0 30.492133 -95.871450
11 DRLLR DRCT 0 30.357342 -95.738658
11 PTROL DRCT 0 30.230011 -95.615733
11 DOMNO DRCT 0 30.092578 -95.483786
11 ZOEEE DRCT 0 30.092378 -95.290322
1 KIAH ADES 0 29.984436 -95.341442
";

  public static string KDFW_KIAH_Garmin => $@"<?xml version=""1.0"" encoding=""utf-8""?>
<flight-plan xmlns=""http://www8.garmin.com/xmlschemas/FlightPlan/v1"">
  <created>2023-08-24T15:25:12Z</created>
  <waypoint-table>
    <waypoint>
      <identifier>KDFW</identifier>
      <type>AIRPORT</type>
      <country-code>K4</country-code>
      <lat>32.897233</lat>
      <lon>-97.037694</lon>
      <comment />
    </waypoint>
    <waypoint>
      <identifier>TTT</identifier>
      <type>VOR</type>
      <country-code>K4</country-code>
      <lat>32.869161</lat>
      <lon>-97.040503</lon>
      <comment />
    </waypoint>
    <waypoint>
      <identifier>DARTZ</identifier>
      <type>INT</type>
      <country-code>K4</country-code>
      <lat>32.285756</lat>
      <lon>-96.811050</lon>
      <comment />
    </waypoint>
    <waypoint>
      <identifier>BRDEN</identifier>
      <type>INT</type>
      <country-code>K4</country-code>
      <lat>31.886517</lat>
      <lon>-96.655822</lon>
      <comment />
    </waypoint>
    <waypoint>
      <identifier>TORNN</identifier>
      <type>INT</type>
      <country-code>K4</country-code>
      <lat>31.520386</lat>
      <lon>-96.514711</lon>
      <comment />
    </waypoint>
    <waypoint>
      <identifier>REFYN</identifier>
      <type>INT</type>
      <country-code>K4</country-code>
      <lat>31.267181</lat>
      <lon>-96.359789</lon>
      <comment />
    </waypoint>
    <waypoint>
      <identifier>OILLL</identifier>
      <type>INT</type>
      <country-code>K4</country-code>
      <lat>31.003078</lat>
      <lon>-96.199206</lon>
      <comment />
    </waypoint>
    <waypoint>
      <identifier>DPLAN</identifier>
      <type>INT</type>
      <country-code>K4</country-code>
      <lat>30.857528</lat>
      <lon>-96.105428</lon>
      <comment />
    </waypoint>
    <waypoint>
      <identifier>SSTAX</identifier>
      <type>INT</type>
      <country-code>K4</country-code>
      <lat>30.711422</lat>
      <lon>-96.011625</lon>
      <comment />
    </waypoint>
    <waypoint>
      <identifier>MPORT</identifier>
      <type>INT</type>
      <country-code>K4</country-code>
      <lat>30.492133</lat>
      <lon>-95.871450</lon>
      <comment />
    </waypoint>
    <waypoint>
      <identifier>DRLLR</identifier>
      <type>INT</type>
      <country-code>K4</country-code>
      <lat>30.357342</lat>
      <lon>-95.738658</lon>
      <comment />
    </waypoint>
    <waypoint>
      <identifier>PTROL</identifier>
      <type>INT</type>
      <country-code>K4</country-code>
      <lat>30.230011</lat>
      <lon>-95.615733</lon>
      <comment />
    </waypoint>
    <waypoint>
      <identifier>DOMNO</identifier>
      <type>INT</type>
      <country-code>K4</country-code>
      <lat>30.092578</lat>
      <lon>-95.483786</lon>
      <comment />
    </waypoint>
    <waypoint>
      <identifier>ZOEEE</identifier>
      <type>INT</type>
      <country-code>K4</country-code>
      <lat>30.092378</lat>
      <lon>-95.290322</lon>
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
    <route-name>KDFW KIAH</route-name>
    <flight-plan-index>1</flight-plan-index>
    <route-point>
      <waypoint-identifier>KDFW</waypoint-identifier>
      <waypoint-type>AIRPORT</waypoint-type>
      <waypoint-country-code>K4</waypoint-country-code>
    </route-point>
    <route-point>
      <waypoint-identifier>TTT</waypoint-identifier>
      <waypoint-type>VOR</waypoint-type>
      <waypoint-country-code>K4</waypoint-country-code>
    </route-point>
    <route-point>
      <waypoint-identifier>DARTZ</waypoint-identifier>
      <waypoint-type>INT</waypoint-type>
      <waypoint-country-code>K4</waypoint-country-code>
    </route-point>
    <route-point>
      <waypoint-identifier>BRDEN</waypoint-identifier>
      <waypoint-type>INT</waypoint-type>
      <waypoint-country-code>K4</waypoint-country-code>
    </route-point>
    <route-point>
      <waypoint-identifier>TORNN</waypoint-identifier>
      <waypoint-type>INT</waypoint-type>
      <waypoint-country-code>K4</waypoint-country-code>
    </route-point>
    <route-point>
      <waypoint-identifier>REFYN</waypoint-identifier>
      <waypoint-type>INT</waypoint-type>
      <waypoint-country-code>K4</waypoint-country-code>
    </route-point>
    <route-point>
      <waypoint-identifier>OILLL</waypoint-identifier>
      <waypoint-type>INT</waypoint-type>
      <waypoint-country-code>K4</waypoint-country-code>
    </route-point>
    <route-point>
      <waypoint-identifier>DPLAN</waypoint-identifier>
      <waypoint-type>INT</waypoint-type>
      <waypoint-country-code>K4</waypoint-country-code>
    </route-point>
    <route-point>
      <waypoint-identifier>SSTAX</waypoint-identifier>
      <waypoint-type>INT</waypoint-type>
      <waypoint-country-code>K4</waypoint-country-code>
    </route-point>
    <route-point>
      <waypoint-identifier>MPORT</waypoint-identifier>
      <waypoint-type>INT</waypoint-type>
      <waypoint-country-code>K4</waypoint-country-code>
    </route-point>
    <route-point>
      <waypoint-identifier>DRLLR</waypoint-identifier>
      <waypoint-type>INT</waypoint-type>
      <waypoint-country-code>K4</waypoint-country-code>
    </route-point>
    <route-point>
      <waypoint-identifier>PTROL</waypoint-identifier>
      <waypoint-type>INT</waypoint-type>
      <waypoint-country-code>K4</waypoint-country-code>
    </route-point>
    <route-point>
      <waypoint-identifier>DOMNO</waypoint-identifier>
      <waypoint-type>INT</waypoint-type>
      <waypoint-country-code>K4</waypoint-country-code>
    </route-point>
    <route-point>
      <waypoint-identifier>ZOEEE</waypoint-identifier>
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
