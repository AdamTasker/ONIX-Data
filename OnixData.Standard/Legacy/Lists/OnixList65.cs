using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace OnixData.Legacy.Lists
{
  public enum OnixList65
  {
    /// <summary>
    /// Cancelled: product was announced, and subsequently abandoned
    /// </summary>
    [XmlEnum("01")] Cancelled = 1,
    /// <summary>
    /// Not yet available (requires expected date, either as <ExpectedShipDate> (ONIX 2.1) or as <SupplyDate> with <SupplyDateRole> coded ‘08’ (ONIX 3.0), except in exceptional circumstances where no date is known)
    /// </summary>
    [XmlEnum("10")] NotYetAvailable = 10,
    /// <summary>
    /// Not yet available, but will be a stock item when available (requires expected date, either as <ExpectedShipDate> (ONIX 2.1) or as <SupplyDate> with <SupplyDateRole> coded ‘08’ (ONIX 3.0), except in exceptional circumstances where no date is known). Used particularly for imports which have been published in the country of origin but have not yet arrived in the importing country
    /// </summary>
    [XmlEnum("11")] AwaitingStock = 11,
    /// <summary>
    /// Not yet available, to be published as print-on-demand only (requires expected date, either as <ExpectedShipDate> (ONIX 2.1) or as <SupplyDate> with <SupplyDateRole> coded ‘08’ (ONIX 3.0), except in exceptional circumstances where no date is known). May apply either to a POD successor to an existing conventional edition, when the successor will be published under a different ISBN (normally because different trade terms apply); or to a title that is being published as a POD original
    /// </summary>
    [XmlEnum("12")] NotYetAvailableWillBePrintOnDemand = 12,
    /// <summary>
    /// Available from us (form of availability unspecified)
    /// </summary>
    [XmlEnum("20")] Available = 20,
    /// <summary>
    /// Available from us as a stock item
    /// </summary>
    [XmlEnum("21")] InStock = 21,
    /// <summary>
    /// Available from us as a non-stock item, by special order
    /// </summary>
    [XmlEnum("22")] ToOrder = 22,
    /// <summary>
    /// Available from us by print-on-demand
    /// </summary>
    [XmlEnum("23")] PrintOnDemand = 23,
    /// <summary>
    /// Temporarily unavailable: temporarily unavailable from us (reason unspecified) (requires expected date, either as <ExpectedShipDate> (ONIX 2.1) or as <SupplyDate> with <SupplyDateRole> coded ‘08’ (ONIX 3.0), except in exceptional circumstances where no date is known)
    /// </summary>
    [XmlEnum("30")] TemporarilyUnavailable = 30,
    /// <summary>
    /// Stock item, temporarily out of stock (requires expected date, either as <ExpectedShipDate> (ONIX 2.1) or as <SupplyDate> with <SupplyDateRole> coded ‘08’ (ONIX 3.0), except in exceptional circumstances where no date is known)
    /// </summary>
    [XmlEnum("31")] OutOfStock = 31,
    /// <summary>
    /// Temporarily unavailable, reprinting (requires expected date, either as <ExpectedShipDate> (ONIX 2.1) or as <SupplyDate> with <SupplyDateRole> coded ‘08’ (ONIX 3.0), except in exceptional circumstances where no date is known)
    /// </summary>
    [XmlEnum("32")] Reprinting = 32,
    /// <summary>
    /// Temporarily unavailable, awaiting reissue (requires expected date, either as <ExpectedShipDate> (ONIX 2.1) or as <SupplyDate> with <SupplyDateRole> coded ‘08’ (ONIX 3.0), except in exceptional circumstances where no date is known)
    /// </summary>
    [XmlEnum("33")] AwaitingReissue = 33,
    /// <summary>
    /// May be for quality or technical reasons. Requires expected availability date, either as <ExpectedShipDate> (ONIX 2.1) or as <SupplyDate> with <SupplyDateRole> coded ‘08’ (ONIX 3.0), except in exceptional circumstances where no date is known
    /// </summary>
    [XmlEnum("34")] TemporarilyWithdrawnFromSale = 34,
    /// <summary>
    /// Not available from us (for any reason)
    /// </summary>
    [XmlEnum("40")] NotAvailableReasonUnspecified = 40,
    /// <summary>
    /// This product is unavailable, but a successor product or edition is or will be available from us (identify successor in <RelatedProduct>)
    /// </summary>
    [XmlEnum("41")] NotAvailableReplacedByNewProduct = 41,
    /// <summary>
    /// This product is unavailable, but the same content is or will be available from us in an alternative format (identify other format product in <RelatedProduct>)
    /// </summary>
    [XmlEnum("42")] NotAvailableOtherFormatAvailable = 42,
    /// <summary>
    /// Identify new supplier in <NewSupplier> if possible
    /// </summary>
    [XmlEnum("43")] NoLongerSuppliedByUs = 43,
    /// <summary>
    /// Not available to trade, apply direct to publisher
    /// </summary>
    [XmlEnum("44")] ApplyDirect = 44,
    /// <summary>
    /// Must be bought as part of a set or trade pack (identify set or pack in <RelatedProduct>)
    /// </summary>
    [XmlEnum("45")] NotSoldSeparately = 45,
    /// <summary>
    /// May be for legal reasons or to avoid giving offence
    /// </summary>
    [XmlEnum("46")] WithdrawnFromSale = 46,
    /// <summary>
    /// Remaindered
    /// </summary>
    [XmlEnum("47")] Remaindered = 47,
    /// <summary>
    /// Out of print, but a print-on-demand edition is or will be available under a different ISBN. Use only when the POD successor has a different ISBN, normally because different trade terms apply
    /// </summary>
    [XmlEnum("48")] NotAvailableReplacedByPrintOnDemand = 48,
    /// <summary>
    /// Recalled for reasons of consumer safety
    /// </summary>
    [XmlEnum("49")] Recalled = 49,
    /// <summary>
    /// When a collection that is not sold as a set nevertheless has its own ONIX record
    /// </summary>
    [XmlEnum("50")] NotSoldAsSet = 50,
    /// <summary>
    /// This product is unavailable, no successor product or alternative format is available or planned. Use this code only when the publisher has indicated the product is out of print
    /// </summary>
    [XmlEnum("51")] NotAvailablePublisherIndicatesOutOfPrint = 51,
    /// <summary>
    /// This product is unavailable in this market, no successor product or alternative format is available or planned. Use this code when a publisher has indicated the product is permanently unavailable (in this market) while remaining available elsewhere
    /// </summary>
    [XmlEnum("52")] NotAvailablePublisherNoLongerSellsProductInThisMarket = 52,
    /// <summary>
    /// Sender has not received any recent update for this product from the publisher/supplier (for use when the sender is a data aggregator): the definition of ‘recent’ must be specified by the aggregator, or by agreement between parties to an exchange
    /// </summary>
    [XmlEnum("97")] NoRecentUpdateReceived = 97,
    /// <summary>
    ///  Sender is no longer receiving any updates from the publisher/supplier of this product (for use when the sender is a data aggregator)
    /// </summary>
    [XmlEnum("98")] NoLongerReceivingUpdates = 98,
    /// <summary>
    /// Availability not known to sender
    /// </summary>
    [XmlEnum("99")] ContactSupplier = 99
  }
}
