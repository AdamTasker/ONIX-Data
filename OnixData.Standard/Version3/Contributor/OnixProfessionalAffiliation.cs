using System.ComponentModel;
using System.Xml.Serialization;

namespace OnixData.Version3.Contributor
{
    /// <summary>
    /// A group of data elements which together identify a contributor’s professional position and/or affiliation
    /// </summary>
    public partial class OnixProfessionalAffiliation
    {
        /// <summary>
        /// A professional position held by a contributor to the product at the time of its creation.
        /// Optional, and repeatable to provide parallel text in multiple languages.
        /// The language attribute is optional for a single instance of <see cref="ProfessionalPosition"/>, but must be included in each instance if <see cref="ProfessionalPosition"/> is repeated.
        /// </summary>
        [XmlChoiceIdentifier("ProfessionalPositionChoice")]
        [XmlElement("ProfessionalPosition")]
        [XmlElement("b045")]
        public string[] ProfessionalPosition { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum ProfessionalPositionEnum { ProfessionalPosition, b045 }
        [XmlIgnore, DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ProfessionalPositionEnum[] ProfessionalPositionChoice
        {
            get
            {
                if (ProfessionalPosition == null) return null;
                ProfessionalPositionEnum choice = SerializationSettings.UseShortTags ? ProfessionalPositionEnum.b045 : ProfessionalPositionEnum.ProfessionalPosition;
                ProfessionalPositionEnum[] result = new ProfessionalPositionEnum[ProfessionalPosition.Length];
                for (int i = 0; i < ProfessionalPosition.Length; i++) result[i] = choice;
                return result;
            }
            set { }
        }

        /// <summary>
        /// An organization to which a contributor to the product was affiliated at the time of its creation, and – if the <see cref="ProfessionalPosition"/> element is also present – where they held that position.
        /// Optional and non-repeating.
        /// </summary>
        [XmlChoiceIdentifier("AffiliationChoice")]
        [XmlElement("Affiliation")]
        [XmlElement("b046")]
        public string Affiliation { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum AffiliationEnum { Affiliation, b046 }
        [XmlIgnore, DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public AffiliationEnum AffiliationChoice
        {
            get { return SerializationSettings.UseShortTags ? AffiliationEnum.b046 : AffiliationEnum.Affiliation; }
            set { }
        }
    }
}
