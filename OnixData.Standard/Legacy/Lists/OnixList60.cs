using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace OnixData.Legacy.Lists
{
  public enum OnixList60
  {
    [XmlEnum("00")] PerCopyOfWholeProduct = 0,
    [XmlEnum("01")] PerPageForPrintedLooseLeafContentOnly = 1
  }
}
