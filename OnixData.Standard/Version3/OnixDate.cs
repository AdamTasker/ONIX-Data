using System.ComponentModel;
using System.Xml.Serialization;

namespace OnixData.Version3
{
    public partial class OnixDate
    {
        /// <summary>
        /// An ONIX code indicating the format in which the date is given in <see cref="Date"/>.
        /// Optional and not repeatable. Deprecated – where possible, use the dateformat attribute instead.
        /// </summary>
        /// <remarks>Onix List 55</remarks>
        [XmlChoiceIdentifier("DateFormatChoice")]
        [XmlElement("DateFormat")]
        [XmlElement("j260")]
        public string DateFormat { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum DateFormatEnum { DateFormat, j260 }
        [XmlIgnore, DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public DateFormatEnum DateFormatChoice
        {
            get { return SerializationSettings.UseShortTags ? DateFormatEnum.j260 : DateFormatEnum.DateFormat; }
            set { }
        }

        /// <summary>
        /// The date specified in the relevant DateRole field.
        /// Mandatory and non-repeating.
        /// May carry a dateformat attribute: if the attribute is missing, then <see cref="DateFormat"/> indicates the format of the date; if both dateformat attribute and <see cref="DateFormat"/> element are missing, the default format is YYYYMMDD.
        /// </summary>
        [XmlChoiceIdentifier("DateChoice")]
        [XmlElement("Date")]
        [XmlElement("b306")]
        public string Date { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum DateEnum { Date, b306 }
        [XmlIgnore, DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public DateEnum DateChoice
        {
            get { return SerializationSettings.UseShortTags ? DateEnum.b306 : DateEnum.Date; }
            set { }
        }
    }
}
