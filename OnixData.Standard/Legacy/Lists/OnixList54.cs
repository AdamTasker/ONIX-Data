using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace OnixData.Legacy.Lists
{
  public enum OnixList54
  {
    /// <summary>
    /// Publication abandoned after having been announced
    /// </summary>
    [XmlEnum("AB")] Cancelled,
    /// <summary>
    /// Apply direct to publisher, item not available to trade
    /// </summary>
    [XmlEnum("AD")] AvailabileDirectFromPublisherOnly,
    /// <summary>
    /// Check with customer service
    /// </summary>
    [XmlEnum("CS")] AvailabilityUncertain,
    /// <summary>
    /// Wholesaler or vendor only
    /// </summary>
    [XmlEnum("EX")] NoLongerStockedByUs,
    /// <summary>
    /// In-print and in stock
    /// </summary>
    [XmlEnum("IP")] Available,
    /// <summary>
    /// May be accompanied by an estimated average time to supply
    /// </summary>
    [XmlEnum("MD")] ManufacturedOnDemand,
    /// <summary>
    /// MUST be accompanied by an expected availability date
    /// </summary>
    [XmlEnum("NP")] NotYetPublished,
    /// <summary>
    /// Wholesaler or vendor only: MUST be accompanied by expected availability date
    /// </summary>
    [XmlEnum("NY")] NewlyCataloguedNotYetInStock,
    /// <summary>
    /// This format is out of print, but another format is available: should be accompanied by an identifier for the alternative product
    /// </summary>
    [XmlEnum("OF")] OtherFormatAvailable,
    /// <summary>
    /// No current plan to reprint
    /// </summary>
    [XmlEnum("OI")] OutOfStockIndefinitely,
    /// <summary>
    /// Discontinued, deleted from catalogue
    /// </summary>
    [XmlEnum("OP")] OutOfPrint,
    /// <summary>
    /// This edition is out of print, but a new edition has been or will soon be published: should be accompanied by an identifier for the new edition
    /// </summary>
    [XmlEnum("OR")] ReplacedByNewEdition,
    /// <summary>
    /// Publication has been announced, and subsequently postponed with no new date
    /// </summary>
    [XmlEnum("PP")] PublicationPostponedIndefinitely,
    /// <summary>
    /// Supply of this item has been transferred to another publisher or distributor: should be accompanied by an identifier for the new supplier
    /// </summary>
    [XmlEnum("RF")] ReferToAnotherSupplier,
    [XmlEnum("RM")] Remaindered,
    /// <summary>
    /// MUST be accompanied by an expected availability date
    /// </summary>
    [XmlEnum("RP")] Reprinting,
    /// <summary>
    /// Use instead of <see cref="Reprinting"/> as a last resort, only if it is really impossible to give an expected availability date
    /// </summary>
    [XmlEnum("RU")] ReprintingUndated,
    /// <summary>
    /// This item is not stocked but has to be specially ordered from a supplier (eg import item not stocked locally): may be accompanied by an estimated average time to supply
    /// </summary>
    [XmlEnum("TO")] SpecialOrder,
    /// <summary>
    /// Wholesaler or vendor only
    /// </summary>
    [XmlEnum("TP")] TemporarilyOutOfStockBecausePublisherCannotSupply,
    /// <summary>
    /// MUST be accompanied by an expected availability date
    /// </summary>
    [XmlEnum("TU")] TemporarilyUnavailable,
    /// <summary>
    /// The item is out of stock but will be reissued under the same ISBN: MUST be accompanied by an expected availability date and by the reissue date in the <Reissue> composite. See notes on the <Reissue> composite for details on treatment of availability status during reissue
    /// </summary>
    [XmlEnum("UR")] UnavailableAwaitingReissue,
    /// <summary>
    /// MUST be accompanied by the remainder date
    /// </summary>
    [XmlEnum("WR")] WillBeRemainderedAsOfDate,
    /// <summary>
    /// Typically, withdrawn indefinitely for legal reasons
    /// </summary>
    [XmlEnum("WS")] WithdrawnFromSale
  }
}
