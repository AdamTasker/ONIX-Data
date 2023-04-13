using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace OnixData.Legacy.Lists
{
  public enum OnixList48
  {
    /// <summary>
    /// For a book, the overall spine height when standing on a shelf. For a folded map, the height when folded. In general, the height of a product in the form in which it is presented or packaged for retail sale
    /// </summary>
    [XmlEnum("01")] Height = 1,
    /// <summary>
    /// For a book, the overall horizontal dimension of the cover when standing upright. For a folded map, the width when folded. In general, the width of a product in the form in which it is presented or packaged for retail sale
    /// </summary>
    [XmlEnum("02")] Width = 2,
    /// <summary>
    /// For a book, the overall thickness of the spine. For a folded map, the thickness when folded. In general, the thickness or depth of a product in the form in which it is presented or packaged for retail sale
    /// </summary>
    [XmlEnum("03")] Thickness = 3,
    /// <summary>
    /// Not recommended for general use
    /// </summary>
    [XmlEnum("04")] PageTrimHeight = 4,
    /// <summary>
    /// Not recommended for general use
    /// </summary>
    [XmlEnum("05")] PageTrimWidth = 5,
    [XmlEnum("08")] UnitWeight = 8,
    /// <summary>
    /// Of a globe, for example
    /// </summary>
    [XmlEnum("09")] SphereDiameter = 9,
    /// <summary>
    /// The height of a folded or rolled sheet map, poster etc when unfolded
    /// </summary>
    [XmlEnum("10")] UnfoldedOrUnrolledSheetHeight = 10,
    /// <summary>
    /// The width of a folded or rolled sheet map, poster etc when unfolded
    /// </summary>
    [XmlEnum("11")] UnfoldedOrUnrolledSheetWidth = 11,
    /// <summary>
    /// The diameter of the cross-section of a tube or cylinder, usually carrying a rolled sheet product. Use 01 ‘Height’ for the height or length of the tube
    /// </summary>
    [XmlEnum("12")] TubeOrCylinderDiameter = 12,
    /// <summary>
    /// The length of a side of the cross-section of a long triangular or square package, usually carrying a rolled sheet product. Use 01 ‘Height’ for the height or length of the package
    /// </summary>
    [XmlEnum("13")] RolledSheetPackageSideMeasure = 13
  }
}
