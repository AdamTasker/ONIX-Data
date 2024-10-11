using System.ComponentModel;
using System.Xml.Serialization;
using OnixData.Version3.Lists;

namespace OnixData.Version3.Header
{
    /// <summary>
    /// A group of data elements which together constitute a message header.
    /// In ONIX 3.0, a number of redundant elements have been deleted, and the Sender and Addressee structures and the name and format of the <see cref="SentDateTime"/> element have been made consistent with other current ONIX formats.
    /// </summary>
    [XmlType(AnonymousType = true)]
    public partial class OnixHeader
    {

        #region Reference Tags

        /// <summary>
        /// A group of data elements which together specify the sender of an ONIX for Books message.
        /// Mandatory in any ONIX for Books message, and non-repeating.
        /// </summary>
        [XmlChoiceIdentifier("SenderChoice")]
        [XmlElement("Sender")]
        [XmlElement("sender")]
        public OnixHeaderSender Sender { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum SenderEnum { Sender, sender }
        [XmlIgnore, DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public SenderEnum SenderChoice {
            get { return SerializationSettings.UseShortTags ? SenderEnum.sender : SenderEnum.Sender; }
            set { }
        }

        /// <summary>
        /// A group of data elements which together specify the addressee of an ONIX for Books message.
        /// Optional, and repeatable if there are several addressees.
        /// </summary>
        [XmlChoiceIdentifier("AddresseeChoice")]
        [XmlElement("Addressee")]
        [XmlElement("addressee")]
        public OnixHeaderAddressee[] Addressee { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum AddresseeEnum { Addressee, addressee }
        [XmlIgnore, DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public AddresseeEnum[] AddresseeChoice
        {
            get
            {
                if (Addressee == null) return null;
                AddresseeEnum choice = SerializationSettings.UseShortTags ? AddresseeEnum.addressee : AddresseeEnum.Addressee;
                AddresseeEnum[] result = new AddresseeEnum[Addressee.Length];
                for (int i = 0; i < Addressee.Length; i++) result[i] = choice;
                return result;
            }
            set { }
        }

        /// <summary>
        /// A monotonic sequence number of the messages in a series sent between trading partners, to enable the receiver to check against gaps and duplicates.
        /// Optional and non-repeating.
        /// </summary>
        [XmlChoiceIdentifier("MessageNumberChoice")]
        [XmlElement("MessageNumber")]
        [XmlElement("m180")]
        public string MessageNumber { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum MessageNumberEnum { MessageNumber, m180 }
        [XmlIgnore, DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public MessageNumberEnum MessageNumberChoice
        {
            get { return SerializationSettings.UseShortTags ? MessageNumberEnum.m180 : MessageNumberEnum.MessageNumber; }
            set { }
        }

        /// <summary>
        /// A number which distinguishes any repeat transmissions of a message.
        /// If this element is used, the original is numbered 1 and repeats are numbered 2, 3 etc.
        /// Optional and non-repeating.
        /// </summary>
        [XmlChoiceIdentifier("MessageRepeatChoice")]
        [XmlElement("MessageRepeat")]
        [XmlElement("m181")]
        public string MessageRepeat { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum MessageRepeatEnum { MessageRepeat, m181 }
        [XmlIgnore, DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public MessageRepeatEnum MessageRepeatChoice
        {
            get { return SerializationSettings.UseShortTags ? MessageRepeatEnum.m181 : MessageRepeatEnum.MessageRepeat; }
            set { }
        }

        /// <summary>
        /// The date on which the message is sent.
        /// Optionally, the time may be added, using the 24-hour clock, with an explicit indication of the time zone if required, in a format based on ISO 8601.
        /// Mandatory and non-repeating.
        /// </summary>
        /// <remarks>
        /// The calendar date must use the Gregorian calendar, even if other dates within the message use a different calendar.
        /// For all practical purposes, UTC is the same as GMT.
        /// </remarks>
        [XmlChoiceIdentifier("SentDateTimeChoice")]
        [XmlElement("SentDateTime")]
        [XmlElement("x307")]
        public string SentDateTime { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum SentDateTimeEnum { SentDateTime, x307 }
        [XmlIgnore, DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public SentDateTimeEnum SentDateTimeChoice
        {
            get { return SerializationSettings.UseShortTags ? SentDateTimeEnum.x307 : SentDateTimeEnum.SentDateTime; }
            set { }
        }

        /// <summary>
        /// Free text giving additional information about the message.
        /// Optional, and repeatable in order to provide a note in multiple languages.
        /// The language attribute is optional for a single instance of <see cref="MessageNote"/>, but must be included in each instance if <see cref="MessageNote"/> is repeated.
        /// </summary>
        [XmlChoiceIdentifier("MessageNoteChoice")]
        [XmlElement("MessageNote")]
        [XmlElement("m183")]
        public string[] MessageNote { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum MessageNoteEnum { MessageNote, m183 }
        [XmlIgnore, DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public MessageNoteEnum[] MessageNoteChoice
        {
            get
            {
                if (MessageNote == null) return null;
                MessageNoteEnum choice = SerializationSettings.UseShortTags ? MessageNoteEnum.m183 : MessageNoteEnum.MessageNote;
                MessageNoteEnum[] result = new MessageNoteEnum[MessageNote.Length];
                for (int i = 0; i < MessageNote.Length; i++) result[i] = choice;
                return result;
            }
            set { }
        }

        /// <summary>
        /// An ISO standard code indicating the default language which is assumed for the text of products listed in the message, unless explicitly stated otherwise by sending a ‘language of text’ element in the product record.
        /// This default will be assumed for all product records which do not specify a language in <see cref="OnixDescriptiveDetail.Language"/>.
        /// Optional and non-repeating.
        /// </summary>
        /// <remarks>Onix List 74</remarks>
        [XmlChoiceIdentifier("DefaultLanguageOfTextChoice")]
        [XmlElement("DefaultLanguageOfText")]
        [XmlElement("m184")]
        public string DefaultLanguageOfText { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum DefaultLanguageOfTextEnum { DefaultLanguageOfText, m184 }
        [XmlIgnore, DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public DefaultLanguageOfTextEnum DefaultLanguageOfTextChoice
        {
            get { return SerializationSettings.UseShortTags ? DefaultLanguageOfTextEnum.m184 : DefaultLanguageOfTextEnum.DefaultLanguageOfText; }
            set { }
        }

        /// <summary>
        /// An ONIX code indicating the default price type which is assumed for prices listed in the message, unless explicitly stated otherwise in a <see cref="Supply.OnixSupplyDetail.Price"/> composite in the product record.
        /// Optional and non-repeating.
        /// </summary>
        /// <remarks>Onix List 58</remarks>
        [XmlChoiceIdentifier("DefaultPriceTypeChoice")]
        [XmlElement("DefaultPriceType")]
        [XmlElement("x310")]
        public OnixList58? DefaultPriceType { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum DefaultPriceTypeEnum { DefaultPriceType, x310 }
        [XmlIgnore, DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public DefaultPriceTypeEnum DefaultPriceTypeChoice
        {
            get { return SerializationSettings.UseShortTags ? DefaultPriceTypeEnum.x310 : DefaultPriceTypeEnum.DefaultPriceType; }
            set { }
        }

        /// <summary>
        /// An ISO standard code indicating the currency which is assumed for prices listed in the message, unless explicitly stated otherwise in a <see cref="Supply.OnixSupplyDetail.Price"/> composite in a product record.
        /// Optional and non-repeating.
        /// All ONIX messages must include an explicit statement of the currency used for any prices.
        /// To avoid any possible ambiguity, it is strongly recommended that the currency should be repeated in the <see cref="Price.OnixPrice"/> composite for each individual price.
        /// </summary>
        /// <remarks>Onix List 96</remarks>
        [XmlChoiceIdentifier("DefaultCurrencyCodeChoice")]
        [XmlElement("DefaultCurrencyCode")]
        [XmlElement("m186")]
        public string DefaultCurrencyCode { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum DefaultCurrencyCodeEnum { DefaultCurrencyCode, m186 }
        [XmlIgnore, DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public DefaultCurrencyCodeEnum DefaultCurrencyCodeChoice
        {
            get { return SerializationSettings.UseShortTags ? DefaultCurrencyCodeEnum.m186 : DefaultCurrencyCodeEnum.DefaultCurrencyCode; }
            set { }
        }

        #endregion
    }
}
