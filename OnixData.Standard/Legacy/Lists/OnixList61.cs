using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace OnixData.Legacy.Lists
{
  public enum OnixList61
  {
    [XmlEnum("00")] Unspecified = 0,
    [XmlEnum("01")] Provisional = 1,
    [XmlEnum("02")] Firm = 2
  }
}
