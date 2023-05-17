using System.ComponentModel;
using System.Xml.Serialization;

namespace OnixData.Version3.Title
{
    /// <summary>
    /// A group of data elements which together specify an identifier of a bibliographic collection.
    /// </summary>
    public partial class OnixCollectionIdentifier : OnixIdentifier
    {

        /// <summary>
        /// An ONIX code identifying a scheme from which an identifier in the <see cref="IDValue"/> element is taken.
        /// Mandatory in each occurrence of the <see cref="OnixCollectionIdentifier"/> composite, and non-repeating.
        /// </summary>
        /// <remarks>Onix List 13</remarks>
        [XmlChoiceIdentifier("CollectionIDTypeChoice")]
        [XmlElement("CollectionIDType")]
        [XmlElement("x344")]
        public string CollectionIDType { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum CollectionIDTypeEnum { CollectionIDType, x344 }
        [XmlIgnore, DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public CollectionIDTypeEnum CollectionIDTypeChoice
        {
            get { return SerializationSettings.UseShortTags ? CollectionIDTypeEnum.x344 : CollectionIDTypeEnum.CollectionIDType; }
            set { }
        }
    }
}
