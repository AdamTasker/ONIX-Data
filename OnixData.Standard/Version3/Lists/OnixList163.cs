using System.Xml.Serialization;

namespace OnixData.Version3.Lists
{
    public enum OnixList163
    {
        /// <summary>
        /// Nominal date of publication.
        /// This date is primarily used for planning, promotion and other business process purposes, and is not necessarily the first date for retail sales or fulfillment of pre-orders.
        /// In the absence of a sales embargo date, retail sales and pre-order fulfillment may begin as soon as stock is available to the retailer
        /// </summary>
        [XmlEnum("01")] PublicationDate = 1,
        /// <summary>
        /// If there is an embargo on retail sales (in the market) before a certain date, the date from which the embargo is lifted and retail sales and fulfillment of pre-orders are permitted.
        /// In the absence of an embargo date, retail sales and pre-order fulfillment may begin as soon as stock is available to the retailer
        /// </summary>
        [XmlEnum("02")] SalesEmbargoDate = 2,
        /// <summary>
        /// Date when a new product may be announced to the general public.
        /// Prior to the announcement date, the product data is intended for internal use by the recipient and supply chain partners only.
        /// After the announcement date, or in the absence of an announcement date, the planned product may be announced to the public as soon as metadata is available
        /// </summary>
        [XmlEnum("09")] PublicAnnouncementDate = 9,
        /// <summary>
        /// Date when a new product may be announced to the book trade only.
        /// Prior to the announcement date, the product information is intended for internal use by the recipient only.
        /// After the announcement date, or in the absence of a trade announcement date, the planned product may be announced to supply chain partners
        /// (but not necessarily made public – see <see cref="PublicAnnouncementDate"/>) as soon as metadata is available
        /// </summary>
        [XmlEnum("10")] TradeAnnouncementDate = 10,
        /// <summary>
        /// Date when the work incorporated in a product was first published.
        /// For works in translation, see also <see cref="DateOfFirstPublicationInOriginalLanguage"/>
        /// </summary>
        [XmlEnum("11")] DateOfFirstPublication = 11,
        /// <summary>
        /// Date when a product was last reprinted
        /// </summary>
        [XmlEnum("12")] LastReprintDate = 12,
        /// <summary>
        /// Date when a product was (or will be) declared out-of-print or deleted
        /// </summary>
        [XmlEnum("13")] OutOfPrintOrDeletionDate = 13,
        /// <summary>
        /// Date when a product was last reissued
        /// </summary>
        [XmlEnum("16")] LastReissueDate = 16,
        /// <summary>
        /// Date of publication of a printed book which is the direct print counterpart to a digital product.
        /// The counterpart product may be included in <see cref="Related.OnixRelatedProduct"/> using code 13
        /// </summary>
        [XmlEnum("19")] PublicationDateOfPrintCounterpart = 19,
        /// <summary>
        /// Date when the original language version of work incorporated in a product was first published
        /// (note, use only on works in translation – see <see cref="DateOFFirstPublication"/> for first publication date in the translated language)
        /// </summary>
        [XmlEnum("20")] DateOfFirstPublicationInOriginalLanguage = 20,
        /// <summary>
        /// Date when a product will be reissued
        /// </summary>
        [XmlEnum("21")] ForthcomingReissueDate = 21,
        /// <summary>
        /// Date when a product that has been temporary withdrawn from sale or recalled for any reason is expected to become available again, eg after correction of quality or technical issues
        /// </summary>
        [XmlEnum("22")] ExpectedAvailabilityDateAfterTemporaryWithdrawal = 22,
        /// <summary>
        /// Date from which reviews of a product may be published eg in newspapers and magazines or online.
        /// Provided to the book trade for information only: newspapers and magazines are not expected to be recipients of ONIX metadata
        /// </summary>
        [XmlEnum("23")] ReviewEmbargoDate = 23,
        /// <summary>
        /// Latest date on which an order may be placed with the publisher for guaranteed delivery prior to the publication date.
        /// May or may not be linked to a special reservation or pre-publication price
        /// </summary>
        [XmlEnum("25")] PublishersReservationOrderDeadline = 25,
        /// <summary>
        /// Date when a product will be reprinted
        /// </summary>
        [XmlEnum("26")] ForthcomingReprintDate = 26,
        /// <summary>
        /// Earliest date a retail ‘preorder’ can be placed (in the market), where this is distinct from the public announcement date.
        /// In the absence of a preorder embargo, advance orders can be placed as soon as metadata is available to the consumer
        /// (this would be the public announcement date, or in the absence of a public announcement date, the earliest date metadata is available to the retailer)
        /// </summary>
        [XmlEnum("27")] PreorderEmbargoDate = 27,
        /// <summary>
        /// Date of acquisition of product by new publisher (use with publishing roles 09 and 13)
        /// </summary>
        [XmlEnum("28")] TransferDate = 28,
        /// <summary>
        /// For an audiovisual work (eg on DVD)
        /// </summary>
        [XmlEnum("29")] DateOfProduction = 29,
        /// <summary>
        /// For digital products that are available to end customers both as a download and streamed, the earliest date the product can be made available on a stream, where the streamed version becomes available later than the download.
        /// For the download, see <see cref="SalesEmbargoDate"/> if it is embargoed or <see cref="PublicationDate"/> if there is no embargo
        /// </summary>
        [XmlEnum("30")] StreamingEmbargoDate = 30,
        /// <summary>
        /// For digital products that are available to end customers both as purchases and as part of a subscription package, the earliest date the product can be made available by subscription, where the product may not be included in a subscription package until shome while after publication.
        /// For ordinary sales, see <see cref="SalesEmbargoDate"/> if there is a sales embargo or <see cref="PublicationDate"/> if there is no embargo
        /// </summary>
        [XmlEnum("31")] SubscriptionEmbargoDate = 31
    }
}
