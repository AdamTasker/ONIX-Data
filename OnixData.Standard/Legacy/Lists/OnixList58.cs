using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace OnixData.Legacy.Lists
{
  public enum OnixList58
  {
    /// <summary>
    /// RRP excluding any sales tax or value-added tax
    /// </summary>
    [XmlEnum("01")] RrpExcludingTax = 1,
    /// <summary>
    /// RRP including sales or value-added tax if applicable
    /// </summary>
    [XmlEnum("02")] RrpIncludingTax = 2,
    /// <summary>
    /// In countries where retail price maintenance applies by law to certain products: not used in USA
    /// </summary>
    [XmlEnum("03")] FixedRetailPriceExcludingTax = 3,
    /// <summary>
    /// In countries where retail price maintenance applies by law to certain products: not used in USA
    /// </summary>
    [XmlEnum("04")] FixedRetailPriceIncludingTax = 4,
    /// <summary>
    /// Unit price charged by supplier to reseller excluding any sales tax or value-added tax: goods for retail sale
    /// </summary>
    [XmlEnum("05")] SuppliersNetPriceExcludingTax = 5,
    /// <summary>
    /// Unit price charged by supplier to reseller / rental outlet, excluding any sales tax or value-added tax: goods for rental (used for video and DVD)
    /// </summary>
    [XmlEnum("06")] SuppliersNetPriceExcludingTaxRentalGoods = 6,
    /// <summary>
    /// Unit price charged by supplier to reseller including any sales tax or value-added tax if applicable: goods for retail sale
    /// </summary>
    [XmlEnum("07")] SuppliersNetPriceIncludingTax = 7,
    /// <summary>
    /// Unit price charged by supplier to a specified class of reseller excluding any sales tax or value-added tax: goods for retail sale (this value is for use only in countries, eg Finland, where trade practice requires two different net prices to be listed for different classes of resellers, and where national guidelines specify how the code should be used)
    /// </summary>
    [XmlEnum("08")] SuppliersAlternativeNetPriceExcludingTax = 8,
    /// <summary>
    /// Unit price charged by supplier to a specified class of reseller including any sales tax or value-added tax: goods for retail sale (this value is for use only in countries, eg Finland, where trade practice requires two different net prices to be listed for different classes of resellers, and where national guidelines specify how the code should be used)
    /// </summary>
    [XmlEnum("09")] SuppliersAlternativeNetPriceIncludingTax = 9,
    /// <summary>
    /// Special sale RRP excluding any sales tax or value-added tax. Note ‘special sales’ are sales where terms and conditions are different from normal trade sales, when for example products that are normally sold on a sale-or-return basis are sold on firm-sale terms, where a particular product is tailored for a specific retail outlet (often termed a ‘premium’ product), or where other specific conditions or qualiifications apply. Further details of the modified terms and conditions should be given in <PriceTypeDescription>
    /// </summary>
    [XmlEnum("11")] SpecialSaleRrpExcludingTax = 11,
    /// <summary>
    /// Special sale RRP including sales or value-added tax if applicable
    /// </summary>
    [XmlEnum("12")] SpecialSaleRrpIncludingTax = 12,
    /// <summary>
    /// In countries where retail price maintenance applies by law to certain products: not used in USA
    /// </summary>
    [XmlEnum("13")] SpecialSaleFixedRetailPriceExcludingTax = 13,
    /// <summary>
    /// In countries where retail price maintenance applies by law to certain products: not used in USA
    /// </summary>
    [XmlEnum("14")] SpecialSaleFixedRetailPriceIncludingTax = 14,
    /// <summary>
    /// Unit price charged by supplier to reseller for special sale excluding any sales tax or value-added tax
    /// </summary>
    [XmlEnum("15")] SuppliersNetPriceForSpecialSaleExcludingTax = 15,
    /// <summary>
    /// Unit price charged by supplier to reseller for special sale including any sales tax or value-added tax
    /// </summary>
    [XmlEnum("17")] SuppliersNetPriceForSpecialSaleIncludingTax = 17,
    /// <summary>
    /// Pre-publication RRP excluding any sales tax or value-added tax. Use where RRP for pre-orders is different from post-publication RRP
    /// </summary>
    [XmlEnum("21")] PrePublicationRrpExcludingTax = 21,
    /// <summary>
    /// Pre-publication RRP including sales or value-added tax if applicable. Use where RRP for pre-orders is different from post-publication RRP
    /// </summary>
    [XmlEnum("22")] PrePublicationRrpIncludingTax = 22,
    /// <summary>
    /// In countries where retail price maintenance applies by law to certain products: not used in USA
    /// </summary>
    [XmlEnum("23")] PrePublicationFixedRetailPriceExcludingTax = 23,
    /// <summary>
    /// In countries where retail price maintenance applies by law to certain products: not used in USA
    /// </summary>
    [XmlEnum("24")] PrePublicationFixedRetailPriceIncludingTax = 24,
    /// <summary>
    /// Unit price charged by supplier to reseller pre-publication excluding any sales tax or value-added tax
    /// </summary>
    [XmlEnum("25")] SuppliersPrePublicationNetPriceExcludingTax = 25,
    /// <summary>
    /// Unit price charged by supplier to reseller pre-publication including any sales tax or value-added tax
    /// </summary>
    [XmlEnum("27")] SuppliersPrePublicationNetPriceIncludingTax = 27,
    /// <summary>
    /// In the US, books are sometimes supplied on ‘freight-pass-through’ terms, where a price that is different from the RRP is used as the basis for calculating the supplier’s charge to a reseller. To make it clear when such terms are being invoked, <see cref="FreightPassThroughRrpExcludingTax"/> is used instead of <see cref="RrpExcludingTax"/> to indicate the RRP. <see cref="FreightPassThroughBillingPriceExcludingTax"/> is used for the ‘billing price’
    /// </summary>
    [XmlEnum("31")] FreightPassThroughRrpExcludingTax = 31,
    /// <summary>
    /// When freight-pass-through terms apply, the price on which the supplier’s charge to a reseller is calculated, ie the price to which trade discount terms are applied. See also <see cref="FreightPassThroughRrpExcludingTax"/>
    /// </summary>
    [XmlEnum("32")] FreightPassThroughBillingPriceExcludingTax = 32,
    /// <summary>
    /// In countries where retail price maintenance applies by law to certain products, but the price is set by the importer or local sales agent, not the foreign publisher. In France, ‘prix catalogue éditeur étranger’
    /// </summary>
    [XmlEnum("33")] ImportersFixedRetailPriceExcludingTax = 33,
    /// <summary>
    /// In countries where retail price maintenance applies by law to certain products, but the price is set by the importer or local sales agent, not the foreign publisher. In France, ‘prix catalogue éditeur étranger’
    /// </summary>
    [XmlEnum("34")] ImportersFixedRetailPriceIndlucingTax = 34,
    /// <summary>
    /// For a product supplied on agency terms, the retail price set by the publisher, excluding any sales tax or value-added tax
    /// </summary>
    [XmlEnum("41")] PublishersRetailPriceExcludingTax = 41,
    /// <summary>
    /// For a product supplied on agency terms, the retail price set by the publisher, including sales or value-added tax if applicable
    /// </summary>
    [XmlEnum("42")] PublishersRetailPriceIncludingTax = 42
      
  }
}
