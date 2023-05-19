using System.ComponentModel;
using System.Xml.Serialization;

using OnixData.Version3.Supply;

namespace OnixData.Version3.Event
{
    public partial class OnixEvent
    {
        /// <summary>
        /// An ONIX code which indicates the relationship between the product and an event to which it is related, eg Proceedings of conference / Selected papers from conference / Programme for sporting event / Guide for art exhibition.
        /// Mandatory and non-repeating.
        /// </summary>
        /// <remarks>Onix List 20</remarks>
        [XmlChoiceIdentifier("EventRoleChoice")]
        [XmlElement("EventRole")]
        [XmlElement("x515")]
        public string EventRole { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum EventRoleEnum { EventRole, x515 }
        [XmlIgnore, DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public EventRoleEnum EventRoleChoice
        {
            get { return SerializationSettings.UseShortTags ? EventRoleEnum.x515 : EventRoleEnum.EventRole; }
            set { }
        }

        /// <summary>
        /// The name of an event or series of events to which the product is related.
        /// This element is mandatory in each occurrence of the <see cref="OnixEvent"/> composite, and repeatable to provide parallel names for a single event in multiple languages (eg ‘United Nations Climate Change Conference’ and « Conférences des Nations unies sur les changements climatiques »).
        /// The language attribute is optional for a single instance of <see cref="EventName"/>, but must be included in each instance if <see cref="EventName"/> is repeated.
        /// </summary>
        [XmlChoiceIdentifier("EventNameChoice")]
        [XmlElement("EventName")]
        [XmlElement("x516")]
        public string[] EventName { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum EventNameEnum { EventName, x516 }
        [XmlIgnore, DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public EventNameEnum[] EventNameChoice
        {
            get
            {
                if (EventName == null) return null;
                EventNameEnum choice = SerializationSettings.UseShortTags ? EventNameEnum.x516 : EventNameEnum.EventName;
                EventNameEnum[] result = new EventNameEnum[EventName.Length];
                for (int i = 0; i < EventName.Length; i++) result[i] = choice;
                return result;
            }
            set { }
        }

        /// <summary>
        /// An acronym used as a short form of the name of an event or series of events given in the <see cref="EventName"/> element.
        /// Optional, and repeatable to provide parallel acronyms for a single event in multiple languages.
        /// The language attribute is optional for a single instance of <see cref="EventAcronym"/>, but must be included in each instance if <see cref="EventAcronym"/> is repeated.
        /// </summary>
        [XmlChoiceIdentifier("EventAcronymChoice")]
        [XmlElement("EventAcronym")]
        [XmlElement("x517")]
        public string[] EventAcronym { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum EventAcronymEnum { EventAcronym, x517 }
        [XmlIgnore, DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public EventAcronymEnum[] EventAcronymChoice
        {
            get
            {
                if (EventAcronym == null) return null;
                EventAcronymEnum choice = SerializationSettings.UseShortTags ? EventAcronymEnum.x517 : EventAcronymEnum.EventAcronym;
                EventAcronymEnum[] result = new EventAcronymEnum[EventAcronym.Length];
                for (int i = 0; i < EventAcronym.Length; i++) result[i] = choice;
                return result;
            }
            set { }
        }

        /// <summary>
        /// The number of an event to which the product is related, within a series of events.
        /// Optional and non-repeating.
        /// </summary>
        [XmlChoiceIdentifier("EventNumberChoice")]
        [XmlElement("EventNumber")]
        [XmlElement("x518")]
        public int EventNumber { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum EventNumberEnum { EventNumber, x518 }
        [XmlIgnore, DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public EventNumberEnum EventNumberChoice 
        {
            get { return SerializationSettings.UseShortTags ? EventNumberEnum.x518 : EventNumberEnum.EventNumber; }
            set { }
        }

        /// <summary>
        /// The thematic title of an individual event in a series that has an event series name in the <EventName> element.
        /// Optional, and repeatable to provide parallel thematic titles for a single event in multiple languages.
        /// The language attribute is optional for a single instance of <EventTheme>, but must be included in each instance if <EventTheme> is repeated.
        /// </summary>
        [XmlChoiceIdentifier("EventThemeChoice")]
        [XmlElement("EventTheme")]
        [XmlElement("x519")]
        public string[] EventTheme { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum EventThemeEnum { EventTheme, x519 }
        [XmlIgnore, DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public EventThemeEnum[] EventThemeChoice
        {
            get
            {
                if (EventTheme == null) return null;
                EventThemeEnum choice = SerializationSettings.UseShortTags ? EventThemeEnum.x519 : EventThemeEnum.EventTheme;
                EventThemeEnum[] result = new EventThemeEnum[EventTheme.Length];
                for (int i = 0; i < EventTheme.Length; i++) result[i] = choice;
                return result;
            }
            set { }
        }

        /// <summary>
        /// The date of an event to which the product is related.
        /// Optional and non-repeating.
        /// </summary>
        [XmlChoiceIdentifier("EventDateChoice")]
        [XmlElement("EventDate")]
        [XmlElement("x520")]
        public string EventDate { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum EventDateEnum { EventDate, x520 }
        [XmlIgnore, DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public EventDateEnum EventDateChoice
        {
            get { return SerializationSettings.UseShortTags ? EventDateEnum.x520 : EventDateEnum.EventDate; }
            set { }
        }

        /// <summary>
        /// The place of an event to which the product is related.
        /// Optional, and repeatable to provide parallel placenames for a single location in multiple languages.
        /// The language attribute is optional for a single instance of <see cref="EventPlace"/>, but must be included in each instance if <see cref="EventPlace"/> is repeated.
        /// </summary>
        [XmlChoiceIdentifier("EventPlaceChoice")]
        [XmlElement("EventPlace")]
        [XmlElement("x521")]
        public string[] EventPlace { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum EventPlaceEnum { EventPlace, x521 }
        [XmlIgnore, DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public EventPlaceEnum[] EventPlaceChoice
        {
            get
            {
                if (EventPlace == null) return null;
                EventPlaceEnum choice = SerializationSettings.UseShortTags ? EventPlaceEnum.x521 : EventPlaceEnum.EventPlace;
                EventPlaceEnum[] result = new EventPlaceEnum[EventPlace.Length];
                for (int i = 0; i < EventPlace.Length; i++) result[i] = choice;
                return result;
            }
            set { }
        }

        /// <summary>
        /// An optional group of data elements which together identify an organizer or sponsor of an event.
        /// The composite is repeatable in order to specify multiple organizers and sponsors.
        /// </summary>
        [XmlChoiceIdentifier("EventSponsorChoice")]
        [XmlElement("EventSponsor")]
        [XmlElement("eventsponsor")]
        public OnixEventSponsor[] EventSponsor { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum EventSponsorEnum { EventSponsor, eventsponsor }
        [XmlIgnore, DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public EventSponsorEnum[] EventSponsorChoice
        {
            get
            {
                if (EventSponsor == null) return null;
                EventSponsorEnum choice = SerializationSettings.UseShortTags ? EventSponsorEnum.eventsponsor : EventSponsorEnum.EventSponsor;
                EventSponsorEnum[] result = new EventSponsorEnum[EventSponsor.Length];
                for (int i = 0; (i < EventSponsor.Length); i++) result[i] = choice;
                return result;
            }
            set { }
        }

        /// <summary>
        /// An optional group of data elements which together identify and provide a pointer to a website which is related to the event identified in an occurrence of the <see cref="OnixEvent"/> composite.
        /// Repeatable in order to provide links to multiple websites.
        /// </summary>
        [XmlChoiceIdentifier("WebsiteChoice")]
        [XmlElement("Website")]
        [XmlElement("website")]
        public OnixWebsite[] Website { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum WebsiteEnum { Website, website }
        [XmlIgnore, DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public WebsiteEnum[] WebsiteChoice
        {
            get
            {
                if (Website == null) return null;
                WebsiteEnum choice = SerializationSettings.UseShortTags ? WebsiteEnum.website : WebsiteEnum.Website;
                WebsiteEnum[] result = new WebsiteEnum[Website.Length];
                for (int i = 0; i < Website.Length; i++) result[i] = choice;
                return result;
            }
            set { }
        }
    }
}
