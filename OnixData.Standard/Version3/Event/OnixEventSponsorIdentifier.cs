using System.ComponentModel;
using System.Xml.Serialization;

namespace OnixData.Version3.Event
{
    public partial class OnixEventSponsorIdentifier : OnixIdentifier
    {
        /// <summary>
        /// An ONIX code which identifies the scheme from which the value in the IDValue element is taken.
        /// Mandatory in each occurrence of the <see cref="OnixEventSponsorIdentifier"/> composite, and non-repeating.
        /// </summary>
        /// <remarks>Onix List 44</remarks>
        [XmlChoiceIdentifier("EventSponsorIDTypeChoice")]
        [XmlElement("EventSponsorIDType")]
        [XmlElement("x522")]
        public string EventSponsorIDType { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum EventSponsorIDTypeEnum { EventSponsorIDType, x522 }
        [XmlIgnore, DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public EventSponsorIDTypeEnum EventSponsorIDTypeChoice
        {
            get { return SerializationSettings.UseShortTags ? EventSponsorIDTypeEnum.x522 : EventSponsorIDTypeEnum.EventSponsorIDType; }
            set { }
        }
    }
}
