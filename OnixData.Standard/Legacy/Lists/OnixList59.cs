using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace OnixData.Legacy.Lists
{
  public enum OnixList59
  {
    /// <summary>
    /// Price applies to all customers that do not fall within any other group with a specified group-specific qualified price
    /// </summary>
    [XmlEnum("00")] UnqualifiedPrice = 0,
    /// <summary>
    /// Price applies to a designated group membership
    /// </summary>
    [XmlEnum("01")] MemberOrSubscriberPrice = 1,
    /// <summary>
    /// Price applies to sales outside the territory in which the supplier is located
    /// </summary>
    [XmlEnum("02")] ExportPrice = 2,
    /// <summary>
    /// Use in cases where there is no combined price, but a lower price is offered for each part if the whole set / series / collection is purchased (either at one time, as part of a continuing commitment, or in a single purchase)
    /// </summary>
    [XmlEnum("03")] ReducedPriceApplicableWhenPurchasedAsPartOfASet = 3,
    /// <summary>
    /// In the Netherlands (or any other market where similar arrangements exist): a reduced fixed price available for a limited time on presentation of a voucher or coupon published in a specified medium, eg a newspaper. Should be accompanied by Price Type <see cref="OnixList58.SpecialSaleFixedRetailPriceExcludingTax"/> and additional detail in <PriceTypeDescription>, and by validity dates in <PriceEffectiveFrom> and <PriceEffectiveUntil> (ONIX 2.1) or in the <PriceDate> composite (ONIX 3.0)
    /// </summary>
    [XmlEnum("04")] VoucherPrice = 4,
    /// <summary>
    /// Price for individual consumer sale only
    /// </summary>
    [XmlEnum("05")] ConsumerPrice = 5,
    /// <summary>
    /// Price for sale to libraries or other corporate or institutional customers
    /// </summary>
    [XmlEnum("06")] CorporateOrLibraryOrEducationPrice = 6,
    /// <summary>
    /// Price valid for a specified period prior to publication. Orders placed prior to the end of the period are guaranteed to be delivered to the retailer before the nominal publication date. The price may or may not be different from the ‘normal’ price, which carries no such delivery guarantee. Must be accompanied by a <PriceEffectiveUntil> date (or equivalent <PriceDate> composite in ONIX 3), and should also be accompanied by a ‘normal’ price
    /// </summary>
    [XmlEnum("07")] ReservationOrderPrice = 7,
    /// <summary>
    /// Temporary ‘Special offer’ price. Must be accompanied by <PriceEffectiveFrom> and <PriceEffectiveUntil> dates (or equivalent <PriceDate> composites in ONIX 3), and may also be accompanied by a ‘normal’ price
    /// </summary>
    [XmlEnum("08")] PromotionalOfferPrice = 8,
    /// <summary>
    /// Price requires purchase with, or proof of ownership of another product. Further details of purchase or ownership requirements must be given in <PriceTypeDescription>
    /// </summary>
    [XmlEnum("09")] LinkedPrice = 9,
    /// <summary>
    /// Price for sale only to libraries (including public, school and academic libraries)
    /// </summary>
    [XmlEnum("10")] LibraryPrice = 10,
    /// <summary>
    /// Price for sale only to educational institutions (including school and academic libraries), educational buying consortia, government and local government bodies purchasing for use in education
    /// </summary>
    [XmlEnum("11")] EducationPrice = 11,
    /// <summary>
    /// Price for sale to corporate customers only
    /// </summary>
    [XmlEnum("12")] CorporatePrice = 12,
    /// <summary>
    /// Price for sale to organisations or services offering consumers subscription access to a library of books
    /// </summary>
    [XmlEnum("13")] SubscriptionServicePrice = 13,
    /// <summary>
    /// Price for primary and secondary education
    /// </summary>
    [XmlEnum("14")] SchoolLibraryPrice = 14,
    /// <summary>
    /// Price for higher education and scholarly institutions
    /// </summary>
    [XmlEnum("15")] AcademicLibraryPrice = 15,
    [XmlEnum("16")] PublicLibraryPrice = 16
  }
}
