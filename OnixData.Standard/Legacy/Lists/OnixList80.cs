using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace OnixData.Legacy.Lists
{
  public enum OnixList80
  {
    /// <summary>
    /// No packaging, or all smaller items enclosed inside largest item
    /// </summary>
    [XmlEnum("00")] NoOuterPackaging = 0,
    /// <summary>
    /// Thin card or soft plastic sleeve, much less rigid than a slip case
    /// </summary>
    [XmlEnum("01")] SlipSleeve = 1,
    /// <summary>
    /// Packaging consisting of formed plastic sealed around each side of the product. Not to be confused with single-sided Blister pack
    /// </summary>
    [XmlEnum("02")] Clamshell = 2,
    /// <summary>
    /// Typical DVD-style packaging, sometimes known as an ‘Amaray’ case
    /// </summary>
    [XmlEnum("03")]	KeepCase = 3,
    /// <summary>
    /// Typical CD-style packaging
    /// </summary>
    [XmlEnum("05")] JewelCase = 5,
    /// <summary>
    /// Common CD-style packaging, a card folder with one or more panels incorporating a tray, hub or pocket to hold the disc(s)
    /// </summary>
    [XmlEnum("06")] Digipak = 6,
    /// <summary>
    /// Individual item, items or set in card box with separate or hinged lid: not to be confused with the commonly-used ‘boxed set’
    /// </summary>
    [XmlEnum("09")] InBox = 9,
    /// <summary>
    /// Slip-case for single item only: German ‘Schuber’
    /// </summary>
    [XmlEnum("10")] SlipCased = 10,
    /// <summary>
    /// Slip-case for multi-volume set: German ‘Kassette’; also commonly referred to as ‘boxed set’
    /// </summary>
    [XmlEnum("11")] SlipCasedSet = 11,
    /// <summary>
    /// Rolled in tube or cylinder: eg sheet map or poster
    /// </summary>
    [XmlEnum("12")] Tube = 12,
    /// <summary>
    /// Use for miscellaneous items such as slides, microfiche, when presented in a binder
    /// </summary>
    [XmlEnum("13")] Binder = 13,
    /// <summary>
    /// Use for miscellaneous items such as slides, microfiche, when presented in a wallet or folder
    /// </summary>
    [XmlEnum("14")] InWalletOrFolder= 14,
    /// <summary>
    /// Long package with triangular cross-section used for rolled sheet maps, posters etc
    /// </summary>
    [XmlEnum("15")] LongTriangularPackage = 15,
    /// <summary>
    /// Long package with square cross-section used for rolled sheet maps, posters, etc
    /// </summary>
    [XmlEnum("16")] LongSquarePackage = 16,
    [XmlEnum("17")] SoftboxForDVD = 17,
    /// <summary>
    /// In pouch, eg teaching materials in a plastic bag or pouch
    /// </summary>
    [XmlEnum("18")] Pouch = 18,
    /// <summary>
    /// In duroplastic or other rigid plastic case, eg for a class set
    /// </summary>
    [XmlEnum("19")] RigidPlasticCase = 19,
    /// <summary>
    /// In cardboard case, eg for a class set
    /// </summary>
    [XmlEnum("20")] CardboardCase = 20,
    /// <summary>
    /// Use for products or product bundles supplied for retail sale in shrink-wrapped packaging.For shrink-wrapped packs of multiple products for trade supply only, see code XL in List 7
    /// </summary>
    [XmlEnum("21")] ShrinkWrapped = 21,
    /// <summary>
    /// A pack comprising a pre-formed plastic blister and a printed card with a heat-seal coating
    /// </summary>
    [XmlEnum("22")] BlisterPack = 22,
    /// <summary>
    /// A case with carrying handle, typically for a set of educational books and/or learning materials
    /// </summary>
    [XmlEnum("23")] CarryCase = 23,
    /// <summary>
    /// Individual item, items or set in metal box or can with separate or hinged lid
    /// </summary>
    [XmlEnum("24")] InTin = 24
  }
}
