using System.ComponentModel;
using System.Xml.Serialization;

namespace OnixData.Version3.Header
{
    /// <summary>
    /// A group of data elements which together define an identifier of the addressee.
    /// </summary>
    [XmlType(AnonymousType = true)]
    public partial class OnixHeaderAddresseeIdentifier : OnixIdentifier
    {
        #region Reference Tags

        /// <summary>
        /// An ONIX code identifying a scheme from which an identifier in the <see cref="IDValue"/> element is taken.
        /// Mandatory in each occurrence of the <see cref="OnixHeaderAddresseeIdentifier"/> composite, and non-repeating.
        /// </summary>
        /// <remarks>Onix List 44</remarks>
        [XmlChoiceIdentifier("AddresseeIDTypeChoice")]
        [XmlElement("AddresseeIDType")]
        [XmlElement("m380")]
        public string AddresseeIDType { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum AddresseeIDTypeEnum { AddresseeIDType, m380 }
        [XmlIgnore, DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public AddresseeIDTypeEnum AddresseeIDTypeChoice
        {
            get { return SerializationSettings.UseShortTags ? AddresseeIDTypeEnum.m380 : AddresseeIDTypeEnum.AddresseeIDType; }
            set { }
        }

        #endregion
    }
}
