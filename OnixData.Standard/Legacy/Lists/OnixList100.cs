using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace OnixData.Legacy.Lists
{
  public enum OnixList100
  {
    /// <summary>
    /// UK publisher’s or distributor’s discount group code in a format specified by BIC to ensure uniqueness
    /// </summary>
    [XmlEnum("01")] BicDiscountGroupCode = 1,
    /// <summary>
    /// A publisher’s or supplier’s own code which identifies a trade discount category, as specified in <DiscountCodeTypeName>. The actual discount for each code is set by trading partner agreement (applies to goods supplied on standard trade discounting terms)
    /// </summary>
    [XmlEnum("02")] ProprietaryDiscountCode = 2,
    /// <summary>
    /// Terms code used in the Netherlands book trade
    /// </summary>
    [XmlEnum("03")] Boeksoort,
    /// <summary>
    /// Terms code used in German ONIX applications
    /// </summary>
    [XmlEnum("04")] GermanTermsCode,
    /// <summary>
    /// A publisher’s or supplier’s own code which identifies a commission rate category, as specified in <DiscountCodeTypeName>. The actual commission rate for each code is set by trading partner agreement (applies to goods supplied on agency terms)
    /// </summary>
    [XmlEnum("05")] ProprietaryCommissionCode,
    /// <summary>
    /// UK publisher’s or distributor’s commission group code in format specified by BIC to ensure uniqueness. Format is identical to BIC discount group code, but indicates a commission rather than a discount (applies to goods supplied on agency terms)
    /// </summary>
    [XmlEnum("06")] BicCommissionGroupCode
  }
}
