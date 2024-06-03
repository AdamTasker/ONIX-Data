using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace OnixData.Legacy.Lists
{
  public enum OnixList62
  {
    [XmlEnum("H")] HigherRate = 0,
    [XmlEnum("P")] TaxPaidAtSource = 1,
    [XmlEnum("R")] LowerRate = 2,
    [XmlEnum("S")] StandardRate = 3,
    [XmlEnum("Z")] ZeroRated = 4
  }
}
