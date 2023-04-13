using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace OnixData.Legacy.Lists
{
  public enum OnixList53
  {
    /// <summary>
    /// As specified in <ReturnsCodeTypeName> (ONIX 3.0 only)
    /// </summary>
    [XmlEnum("00")] Proprietary = 0,
    /// <summary>
    /// Maintained by CLIL (Commission Interprofessionnel du Livre). Returns conditions values in <ReturnsCode> should be taken from the CLIL list
    /// </summary>
    [XmlEnum("01")] FrenchBookTradeReturnsConditionsCode = 1,
    /// <summary>
    /// Maintained by BISAC: Returns conditions values in <ReturnsCode> should be taken from List 66
    /// </summary>
    [XmlEnum("02")] BisacReturnableIndicatorCode = 2,
    /// <summary>
    /// NOT CURRENTLY USED – BIC has decided that it will not maintain a code list for this purpose, since returns conditions are usually at least partly based on the trading relationship
    /// </summary>
    [XmlEnum("03")] UkBookTradeReturnsConditionsCode = 3,
    /// <summary>
    /// Returns conditions values in <ReturnsCode> should be taken from List 204
    /// </summary>
    [XmlEnum("04")] OnixReturnsConditionsCode = 4
  }
}
