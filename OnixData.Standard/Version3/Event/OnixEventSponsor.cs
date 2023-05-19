using System.ComponentModel;
using System.Xml.Serialization;

namespace OnixData.Version3.Event
{
    public partial class OnixEventSponsor
    {
        /// <summary>
        /// An optional and repeatable group of data elements which together carry a coded identifier for an organizer or sponsor of an event.
        /// </summary>
        [XmlChoiceIdentifier("EventSponsorIdentifierChoice")]
        [XmlElement("EventSponsorIdentifier")]
        [XmlElement("eventsponsoridentifier")]
        public OnixEventSponsorIdentifier[] EventSponsorIdentifier { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum EventSponsorIdentifierEnum { EventSponsorIdentifier, eventsponsoridentifier }
        [XmlIgnore, DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public EventSponsorIdentifierEnum[] EventSponsorIdentifierChoice
        {
            get
            {
                if (EventSponsorIdentifier == null) return null;
                EventSponsorIdentifierEnum choice = SerializationSettings.UseShortTags ? EventSponsorIdentifierEnum.eventsponsoridentifier : EventSponsorIdentifierEnum.EventSponsorIdentifier;
                EventSponsorIdentifierEnum[] result = new EventSponsorIdentifierEnum[EventSponsorIdentifier.Length];
                for (int i = 0; i < EventSponsorIdentifier.Length; i++) result[i] = choice;
                return result;
            }
            set { }
        }

        /// <summary>
        /// The name of a person, used here for a personal organizer or sponsor of an event.
        /// Optional and non-repeating.
        /// Only one of <see cref="PersonName"/> or <see cref="CorporateName"/> can be sent in each occurrence of the <see cref="OnixEventSponsor"/> composite.
        /// </summary>
        [XmlChoiceIdentifier("PersonNameChoice")]
        [XmlElement("PersonName")]
        [XmlElement("b036")]
        public string PersonName { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum PersonNameEnum { PersonName, b036 }
        [XmlIgnore, DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public PersonNameEnum PersonNameChoice
        {
            get { return SerializationSettings.UseShortTags ? PersonNameEnum.b036 : PersonNameEnum.PersonName; }
            set { }
        }

        /// <summary>
        /// The name of a corporate body, used here for a corporate organizer or sponsor of an event. Optional and non-repeating.
        /// Only one of <see cref="PersonName"/> or <see cref="CorporateName"/> can be sent in each occurrence of the <see cref="OnixEventSponsor"/> composite.
        /// </summary>
        [XmlChoiceIdentifier("CorporateNameChoice")]
        [XmlElement("CorporateName")]
        [XmlElement("b047")]
        public string CorporateName { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum CorporateNameEnum { CorporateName, b047 }
        [XmlIgnore, DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public CorporateNameEnum CorporateNameChoice
        {
            get { return SerializationSettings.UseShortTags ? CorporateNameEnum.b047 : CorporateNameEnum.CorporateName; }
            set { }
        }
    }
}
