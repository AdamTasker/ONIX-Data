using System.ComponentModel;
using System.Xml.Serialization;
using OnixData.Legacy.Lists;

namespace OnixData.Legacy
{
    /// <summary>
    /// A group of data elements which together constitute a message header.
    /// The elements may alternatively be sent without being grouped into a composite, but the composite approach is recommended since it makes it easier to maintain a standard header “package” to drop into any new ONIX Product Information Message.
    ///
    /// Note that the Sender and Addressee Identifier composites can only be used within the Header composite, and future extensions to the Header will be defined only within the composite.
    /// </summary>
    [XmlType(AnonymousType = true)]
    public partial class OnixLegacyHeader
    {
        public OnixLegacyHeader()
        {
            FromCompany = "";
            FromPerson  = "";
            FromEmail   = "";
            SentDate    = "";
            MessageNote = "";

            DefaultLanguageOfText = DefaultCurrencyCode = "";
            DefaultClassOfTrade   = "";
        }

        #region Reference tags

        /// <summary>
        /// The name of the sender organization, which should always be stated in a standard form agreed with the addressee.
        /// Optional and non-repeating; but either the &lt;FromCompany&gt; element or a sender identifier using one or more elements from &lt;FromEANNumber&gt;, &lt;FromSAN&gt;, or &lt;SenderIdentifier&gt; must be included.
        ///
        /// The text is not limited to ASCII characters.
        /// </summary>
        [XmlChoiceIdentifier("FromCompanyChoice")]
        [XmlElement("FromCompany")]
        [XmlElement("m174")]
        public string FromCompany { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum FromCompanyEnum { FromCompany, m174 };
        [XmlIgnore]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public FromCompanyEnum FromCompanyChoice;

        /// <summary>
        /// Free text giving the name, department, phone number, etc for a contact person in the sender organization who is responsible for the content of the message.
        /// Optional and non-repeating.
        ///
        /// The text is not limited to ASCII characters.
        /// </summary>
        [XmlChoiceIdentifier("FromPersonChoice")]
        [XmlElement("FromPerson")]
        [XmlElement("m175")]
        public string FromPerson { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum FromPersonEnum { FromPerson, m175 };
        [XmlIgnore]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public FromPersonEnum FromPersonChoice;

        /// <summary>
        /// A text field giving the email address for a contact person in the sender organization who is responsible for the content of the message.
        /// Optional and non-repeating.
        ///
        /// The text is not limited to ASCII characters.
        /// </summary>
        [XmlChoiceIdentifier("FromEmailChoice")]
        [XmlElement("FromEmail")]
        [XmlElement("m283")]
        public string FromEmail { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum FromEmailEnum { FromEmail, m283 };
        [XmlIgnore]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public FromEmailEnum FromEmailChoice;

        /// <summary>
        /// The date on which the message is sent. Optionally, the time may be added, using the 24-hour clock.
        /// Mandatory and non-repeating.
        /// </summary>
        [XmlChoiceIdentifier("SentDateChoice")]
        [XmlElement("SentDate")]
        [XmlElement("m182")]
        public string SentDate { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum SentDateEnum { SentDate, m182 };
        [XmlIgnore]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public SentDateEnum SentDateChoice;

        /// <summary>
        /// Free text giving additional information about the message.
        /// Optional and non-repeating.
        ///
        /// The text is not limited to ASCII characters.
        /// </summary>
        [XmlChoiceIdentifier("MessageNoteChoice")]
        [XmlElement("MessageNote")]
        [XmlElement("m183")]
        public string MessageNote { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum MessageNoteEnum { MessageNote, m183 };
        [XmlIgnore]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public MessageNoteEnum MessageNoteChoice;

        /// <summary>
        /// An ISO standard code indicating the default language which is assumed for the text of products listed in the message, unless explicitly stated otherwise by sending a “language of text” element in the product record.
        /// This default will be assumed for all product records which do not specify a language in <see cref="OnixLegacyProduct.Language"/>.
        /// Optional and non-repeating.
        /// </summary>
        [XmlChoiceIdentifier("DefaultLanguageOfTextChoice")]
        [XmlElement("DefaultLanguageOfText")]
        [XmlElement("m184")]
        public string DefaultLanguageOfText { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum DefaultLanguageOfTextEnum { DefaultLanguageOfText, m184 };
        [XmlIgnore]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public DefaultLanguageOfTextEnum DefaultLanguageOfTextChoice;

        /// <summary>
        /// An ONIX code indicating the default price type which is assumed for prices listed in the message, unless explicitly stated otherwise in a <see cref="OnixLegacySupplyDetail.Price"/> composite in the product record.
        /// Optional and non-repeating.
        /// </summary>
        [XmlChoiceIdentifier("DefaultPriceTypeCodeChoice")]
        [XmlElement("DefaultPriceTypeCode")]
        [XmlElement("m185")]
        public OnixList58 DefaultPriceTypeCode { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum DefaultPriceTypeCodeEnum { DefaultPriceTypeCode, m185 };
        [XmlIgnore]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public DefaultPriceTypeCodeEnum DefaultPriceTypeCodeChoice;

        /// <summary>
        /// An ISO standard code indicating the currency which is assumed for prices listed in the message, unless explicitly stated otherwise in a <see cref="OnixLegacySupplyDetail.Price"/> composite in the product record.
        /// Optional and non-repeating.
        /// </summary>
        [XmlChoiceIdentifier("DefaultCurrencyCodeChoice")]
        [XmlElement("DefaultCurrencyCode")]
        [XmlElement("m186")]
        public string DefaultCurrencyCode { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum DefaultCurrencyCodeEnum { DefaultCurrencyCode, m186 };
        [XmlIgnore]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public DefaultCurrencyCodeEnum DefaultCurrencyCodeChoice;

        /// <summary>
        /// A code indicating the default unit which is assumed for linear measurements listed in the message, unless otherwise specified in the product record.
        /// This element is deprecated. For most implementations, explicit coding of measure units with each occurrence of a measurement is to be preferred.
        /// Optional and non-repeating.
        /// </summary>
        [XmlChoiceIdentifier("DefaultLinearUnitChoice")]
        [XmlElement("DefaultLinearUnit")]
        [XmlElement("m187")]
        public OnixList50? DefaultLinearUnit { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum DefaultLinearUnitEnum { DefaultLinearUnit, m187 };
        [XmlIgnore]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public DefaultLinearUnitEnum DefaultLinearUnitChoice;

        /// <summary>
        /// A code indicating the default unit which is assumed for weights listed in the message, unless otherwise specified in the product record.
        /// This element is deprecated. For most implementations, explicit coding of units with each occurrence of a weight is to be preferred.
        /// Optional and non-repeating.
        /// </summary>
        [XmlChoiceIdentifier("DefaultWeightUnitChoice")]
        [XmlElement("DefaultWeightUnit")]
        [XmlElement("m188")]
        public OnixList50? DefaultWeightUnit { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum DefaultWeightUnitEnum { DefaultWeightUnit, m188 };
        [XmlIgnore]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public DefaultWeightUnitEnum DefaultWeightUnitChoice;

        /// <summary>
        /// Free text indicating the class of trade which is assumed for prices given in the message, unless explicitly stated otherwise specified in <see cref="OnixLegacyPrice.ClassOfTrade"/>.
        /// For example: Institutional, General trade, Wholesale distributor, which may be represented by a suitable code or abbreviation agreed between trading partners.
        /// Otherwise specified in the product record.
        /// Optional and non-repeating.
        /// The text is not limited to ASCII characters.
        /// </summary>
        [XmlChoiceIdentifier("DefaultClassOfTradeChoice")]
        [XmlElement("DefaultClassOfTrade")]
        [XmlElement("m193")]
        public string DefaultClassOfTrade { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum DefaultClassOfTradeEnum { DefaultClassOfTrade, m193 };
        [XmlIgnore]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public DefaultClassOfTradeEnum DefaultClassOfTradeChoice;

        #endregion
    }
}



