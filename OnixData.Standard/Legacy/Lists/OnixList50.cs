using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace OnixData.Legacy.Lists
{
  public enum OnixList50
  {
    /// <summary>
    /// Millimeters are the preferred metric unit of length
    /// </summary>
    [XmlEnum("cm")] Centimeters,
    [XmlEnum("gr")] Grams,
    [XmlEnum("in")] Inches,
    /// <summary>
    /// Grams are the preferred metric unit of weight
    /// </summary>
    [XmlEnum("kg")] Kilograms,
    [XmlEnum("lb")] Pounds,
    [XmlEnum("mm")] Millimeters,
    [XmlEnum("oz")] Ounces,
    [XmlEnum("px")] Pixels
  }
}
