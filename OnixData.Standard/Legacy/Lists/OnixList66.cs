using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace OnixData.Legacy.Lists
{
  public enum OnixList66
  {
    [XmlEnum("N")] NoNotReturnable,
    [XmlEnum("Y")] YesReturnableFullCopiesOnly,
    [XmlEnum("S")] YesReturnableStrippedCover,
    /// <summary>
    /// Contact publisher for requirements and/or authorization
    /// </summary>
    [XmlEnum("C")] Conditional
  }
}
