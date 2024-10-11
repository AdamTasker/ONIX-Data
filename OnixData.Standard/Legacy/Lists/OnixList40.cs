using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace OnixData.Legacy.Lists
{
  public enum OnixList40
  {
    [XmlEnum("01")] URL = 1,
    [XmlEnum("02")] DOI = 2,
    [XmlEnum("03")] PURL = 3,
    [XmlEnum("04")] URN = 4,
    [XmlEnum("05")] FTPAddress = 5,
    [XmlEnum("06")] Filename = 6
  }
}
