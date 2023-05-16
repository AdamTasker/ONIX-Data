using System.ComponentModel;
using System.Xml.Serialization;

namespace OnixData.Version3.Header
{
    /// <summary>
    /// A group of data elements which together specify the sender of an ONIX for Books message.
    /// </summary>
    [XmlType(AnonymousType = true)]
    public partial class OnixHeaderSender : OnixContact
    {
        #region Reference Tags

        /// <summary>
        /// A group of data elements which together define an identifier of the sender.
        /// The composite is optional, and repeatable if more than one identifier of different types is sent; but either a <see cref="SenderName"/> or a <see cref="SenderIdentifier"/> must be included.
        /// </summary>
        [XmlChoiceIdentifier("SenderIdentifierChoice")]
        [XmlElement("SenderIdentifier")]
        [XmlElement("senderidentifier")]
        public OnixHeaderSenderIdentifier[] SenderIdentifier { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum SenderIdentifierEnum { SenderIdentifier, senderidentifier }
        [XmlIgnore, DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public SenderIdentifierEnum[] SenderIdentifierChoice
        {
            get
            {
                if (SenderIdentifier == null) return null;
                SenderIdentifierEnum choice = SerializationSettings.UseShortTags ? SenderIdentifierEnum.senderidentifier : SenderIdentifierEnum.SenderIdentifier;
                SenderIdentifierEnum[] result = new SenderIdentifierEnum[SenderIdentifier.Length];
                for (int i = 0; i < SenderIdentifier.Length; i++) result[i] = choice;
                return result;
            }
            set { }
        }

        /// <summary>
        /// The name of the sender organization, which should always be stated in a standard form agreed with the addressee.
        /// Optional and non-repeating; but either a <see cref="SenderName"/> element or a <see cref="SenderIdentifier"/> composite must be included.
        /// </summary>
        [XmlChoiceIdentifier("SenderNameChoice")]
        [XmlElement("SenderName")]
        [XmlElement("x298")]
        public string SenderName { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum SenderNameEnum { SenderName, x298 }
        [XmlIgnore, DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public SenderNameEnum SenderNameChoice
        {
            get { return SerializationSettings.UseShortTags ? SenderNameEnum.x298 : SenderNameEnum.SenderName; }
            set { }
        }

        #endregion
    }
}
