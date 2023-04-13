using System.Xml.Serialization;

namespace OnixData.Legacy.Lists
{
  public enum OnixList5
  {
    /// <summary>
    /// For example, a publisher’s or wholesaler’s product number. Note that <IDTypeName> is required with proprietary identifiers
    /// </summary>
    [XmlEnum("01")] Proprietary = 1,
    /// <summary>
    /// International Standard Book Number, pre-2007, unhyphenated (10 characters) – now DEPRECATED in ONIX for Books, except where providing historical information for compatibility with legacy systems. It should only be used in relation to products published before 2007 – when ISBN-13 superseded it – and should never be used as the ONLY identifier (it should always be accompanied by the correct GTIN-13 / ISBN-13)
    /// </summary>
    [XmlEnum("02")] ISBN10 = 2,
    /// <summary>
    /// GS1 Global Trade Item Number, formerly known as EAN article number (13 digits)
    /// </summary>
    [XmlEnum("03")] GTIN13 = 3,
    /// <summary>
    /// UPC product number (12 digits)
    /// </summary>
    [XmlEnum("04")] UPC = 4,
    /// <summary>
    /// International Standard Music Number (M plus nine digits). Pre-2008 – now DEPRECATED in ONIX for Books, except where providing historical information for compatibility with legacy systems. It should only be used in relation to products published before 2008 – when ISMN-13 superseded it – and should never be used as the ONLY identifier (it should always be accompanied by the correct ISMN-13)
    /// </summary>
    [XmlEnum("05")] ISMN10 = 5,
    /// <summary>
    /// Digital Object Identifier (variable length and character set)
    /// </summary>
    [XmlEnum("06")] DOI = 6,
    /// <summary>
    /// Library of Congress Control Number (12 characters, alphanumeric)
    /// </summary>
    [XmlEnum("13")] LCCN = 13,
    /// <summary>
    /// GS1 Global Trade Item Number (14 digits)
    /// </summary>
    [XmlEnum("14")] GTIN14 = 14,
    /// <summary>
    /// International Standard Book Number, from 2007, unhyphenated (13 digits starting 978 or 9791–9799)
    /// </summary>
    [XmlEnum("15")] ISBN13 = 15,
    /// <summary>
    /// The number assigned to a publication as part of a national legal deposit process
    /// </summary>
    [XmlEnum("17")] LegalDepositNumber = 17,
    /// <summary>
    /// Uniform Resource Name: note that in trade applications an ISBN must be sent as a GTIN-13 and, where required, as an ISBN-13 – it should not be sent as a URN
    /// </summary>
    [XmlEnum("22")] URN = 22,
    /// <summary>
    /// A unique number assigned to a bibliographic item by OCLC
    /// </summary>
    [XmlEnum("23")] OCLCNumber = 23,
    /// <summary>
    /// An ISBN-13 assigned by a co-publisher. The ‘main’ ISBN sent with ID type <see cref="GTIN13"/> and/or <see cref="ISBN13"/> should always be the ISBN that is used for ordering from the supplier identified in Supply Detail. However, ISBN rules allow a co-published title to carry more than one ISBN. The co-publisher should be identified in an instance of the <Publisher> composite, with the applicable <PublishingRole> code
    /// </summary>
    [XmlEnum("24")] CoPublishersISBN13 = 24,
    /// <summary>
    /// International Standard Music Number, from 2008 (13-digit number starting 9790)
    /// </summary>
    [XmlEnum("25")] ISMN13 = 25,
    /// <summary>
    /// Actionable ISBN, in fact a special DOI incorporating the ISBN-13 within the DOI syntax. Begins ‘10.978.’ or ‘10.979.’ and includes a / character between the registrant element (publisher prefix) and publication element of the ISBN, eg 10.978.000/1234567. Note the ISBN-A should always be accompanied by the ISBN itself, using <see cref="GTIN13"/> and/or <see cref="ISBN13"/>
    /// </summary>
    [XmlEnum("26")] ISBNA = 26,
    /// <summary>
    /// E-publication identifier controlled by JPOIID’s Committee for Research and Management of Electronic Publishing Codes
    /// </summary>
    [XmlEnum("27")] JPEcode = 27,
    /// <summary>
    /// Unique number assigned by the Chinese Online Library Cataloging Center (see http://olcc.nlc.gov.cn)
    /// </summary>
    [XmlEnum("28")] OLCCNumber = 28,
    /// <summary>
    /// Japanese magazine identifier, similar in scope to ISSN but identifying a specific issue of a serial publication. Five digits to identify the periodical, plus a hyphen and two digits to identify the issue
    /// </summary>
    [XmlEnum("29")] JPMagazineID = 29,
    /// <summary>
    /// Used only with comic books and other products which use the UPC extension to identify individual issues or products. Do not use where the UPC12 itself identifies the specific product, irrespective of any 5-digit extension – use <see cref="UPC"/> instead
    /// </summary>
    [XmlEnum("30")] UPC125 = 30,
    /// <summary>
    /// Numéro de la notice bibliographique BNF
    /// </summary>
    [XmlEnum("31")] BNFControlNumber = 31,
    /// <summary>
    /// Archival Resource Key, as a URL (including the address of the ARK resolver provided by eg a national library)
    /// </summary>
    [XmlEnum("35")] ARK = 35
  }
}
