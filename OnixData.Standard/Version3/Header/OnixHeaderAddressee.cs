using System.ComponentModel;
using System.Xml.Serialization;

namespace OnixData.Version3.Header
{
    /// <summary>
    /// A group of data elements which together specify the addressee of an ONIX for Books message.
    /// </summary>
    [XmlType(AnonymousType = true)]
    public partial class OnixHeaderAddressee : OnixContact
    {

        #region Reference Tags

        /// <summary>
        /// A group of data elements which together define an identifier of the addressee.
        /// The composite is optional, and repeatable if more than one identifier of different types for the same addressee is sent; but either an <see cref="AddresseeName"/> or an <see cref="AddresseeIdentifier"/> must be included.
        /// </summary>
        [XmlChoiceIdentifier("AddresseeIdentifierChoice")]
        [XmlElement("AddresseeIdentifier")]
        [XmlElement("addresseeidentifier")]
        public OnixHeaderAddresseeIdentifier[] AddresseeIdentifier { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum AddresseeIdentifierEnum { AddresseeIdentifier, addresseeidentifier }
        [XmlIgnore, DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public AddresseeIdentifierEnum[] AddresseeIdentifierChoice
        {
            get
            {
                if (AddresseeIdentifier == null) return null;
                AddresseeIdentifierEnum choice = SerializationSettings.UseShortTags ? AddresseeIdentifierEnum.addresseeidentifier : AddresseeIdentifierEnum.AddresseeIdentifier;
                AddresseeIdentifierEnum[] result = new AddresseeIdentifierEnum[AddresseeIdentifier.Length];
                for (int i = 0; i < AddresseeIdentifier.Length; i++) result[i] = choice;
                return result;
            }
            set { }
        }

        /// <summary>
        /// The name of the addressee organization, which should always be stated in a standard form agreed with the addressee.
        /// Optional and non-repeating; but either a <see cref="AddresseeName"/> element or a <see cref="AddresseeIdentifier"/> composite must be included.
        /// </summary>
        [XmlChoiceIdentifier("AddresseeNameChoice")]
        [XmlElement("AddresseeName")]
        [XmlElement("x300")]
        public string AddresseeName { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum AddresseeNameEnum { AddresseeName, x300 }
        [XmlIgnore, DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public AddresseeNameEnum AddresseeNameChoice
        {
            get { return SerializationSettings.UseShortTags ? AddresseeNameEnum.x300 : AddresseeNameEnum.AddresseeName; }
            set { }
        }

        #endregion
    }
}
