using System.Xml.Serialization;

namespace OnixData.Version3.Lists
{
    public enum OnixList58
    {
        [XmlEnum("01")] RrpExcludingTax = 1,
        [XmlEnum("02")] RrpIncludingTax = 2,
        [XmlEnum("03")] FrpExcludingTax = 3,
        [XmlEnum("04")] FrpIncludingTax = 4,
        [XmlEnum("05")] SuppliersNetPriceExcludingTax = 5,
        [XmlEnum("06")] SuppliersNetPriceExcludingTaxRentalGoods = 6,
        [XmlEnum("07")] SuppliersNetPriceIncludingTax = 7,
        [XmlEnum("08")] SuppliersAlternativeNetPriceExcludingTax = 8,
        [XmlEnum("09")] SuppliersAlternativeNetPriceIncludingTax = 9,
        [XmlEnum("11")] SpecialSaleRrpExcludingTax = 11,
        [XmlEnum("12")] SpecialSaleRrpIncludingTax = 12,
        [XmlEnum("13")] SpecialSaleFrpExcludingTax = 13,
        [XmlEnum("14")] SpecialSaleFrpIncludingTax = 14,
        [XmlEnum("15")] SuppliersNetPriceForSpecialSaleExcludingTax = 15,
        [XmlEnum("17")] SuppliersNetPriceForSpecialSaleIncludingTax = 17,
        [XmlEnum("21")] PrePublicationRrpExcludingTax = 21,
        [XmlEnum("22")] PrePublicationRrpIncludingTax = 22,
        [XmlEnum("23")] PrePublicationFrpExcludingTax = 23,
        [XmlEnum("24")] PrePublicationFrpIncludingTax = 24,
        [XmlEnum("25")] SuppliersPrePublicationNetPriceExcludingTax = 25,
        [XmlEnum("27")] SuppliersPrePublicationNetPriceIncludingTax = 27,
        [XmlEnum("31")] FreightPassThroughRrpExcludingTax = 31,
        [XmlEnum("32")] FreightPassThroughBillingPriceExcludingTax = 32,
        [XmlEnum("33")] ImportersFrpExcludingTax = 33,
        [XmlEnum("34")] ImportersFrpIncludingTax = 34,
        [XmlEnum("41")] PublishersRetailPriceExcludingTax = 41,
        [XmlEnum("42")] PublishersRetailPriceIncludingTax = 42
    }
}
