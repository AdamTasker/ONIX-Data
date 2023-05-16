using System.ComponentModel;
using System.Xml.Serialization;

namespace OnixData.Version3
{
    /// <summary>
    /// A group of data elements which together specify the sender of an ONIX for Books message.
    /// </summary>
    [XmlType(AnonymousType = true)]
    public partial class OnixContact
    {
        #region Reference Tags

        /// <summary>
        /// Free text giving the name, department, phone number, etc for a contact person in the sender organization who is responsible for the content of the message.
        /// Optional and non-repeating.
        /// </summary>
        [XmlChoiceIdentifier("ContactNameChoice")]
        [XmlElement("ContactName")]
        [XmlElement("x299")]
        public string ContactName { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum ContactNameEnum { ContactName, x299 }
        [XmlIgnore, DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ContactNameEnum ContactNameChoice
        {
            get { return SerializationSettings.UseShortTags ? ContactNameEnum.x299 : ContactNameEnum.ContactName; }
            set { }
        }

        /// <summary>
        /// A text field giving the e-mail address for a contact person in the sender organization who is responsible for the content of the message.
        /// Optional and non-repeating.
        /// </summary>
        [XmlChoiceIdentifier("EmailAddressChoice")]
        [XmlElement("EmailAddress")]
        [XmlElement("j272")]
        public string EmailAddress { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum EmailAddressEnum { EmailAddress, j272 }
        [XmlIgnore, DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public EmailAddressEnum EmailAddressChoice
        {
            get { return SerializationSettings.UseShortTags ? EmailAddressEnum.j272 : EmailAddressEnum.EmailAddress; }
            set { }
        }

        #endregion
    }
}
