using System.ComponentModel;
using System.Xml.Serialization;

namespace OnixData.Version3.Content
{
    public partial class OnixAncillaryContent
    {
        /// <summary>
        /// An ONIX code which identifies the type of illustration or other content to which an occurrence of the composite refers.
        /// Mandatory in each occurrence of the <see cref="OnixAncillaryContent"/> composite, and non-repeating.
        /// </summary>
        /// <remarks>Onix List 25</remarks>
        [XmlChoiceIdentifier("AncillaryContentTypeChoice")]
        [XmlElement("AncillaryContentType")]
        [XmlElement("x423")]
        public string AncillaryContentType { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum AncillaryContentTypeEnum { AncillaryContentType, x423 }
        [XmlIgnore, DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public AncillaryContentTypeEnum AncillaryContentTypeChoice
        {
            get { return SerializationSettings.UseShortTags ? AncillaryContentTypeEnum.x423 : AncillaryContentTypeEnum.AncillaryContentType; }
            set { }
        }

        /// <summary>
        /// Text describing the type of illustration or other content to which an occurrence of the composite refers, when a code is insufficient.
        /// Optional, and repeatable if parallel descriptive text is provided in multiple languages.
        /// Required when <see cref="AncillaryContentType"/> carries the value 00.
        /// The language attribute is optional for a single instance of <see cref="AncillaryContentDescription"/>, but must be included in each instance if <see cref="AncillaryContentDescription"/> is repeated.
        /// </summary>
        [XmlChoiceIdentifier("AncillaryContentDescriptionChoice")]
        [XmlElement("AncillaryContentDescription")]
        [XmlElement("x424")]
        public string[] AncillaryContentDescription { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum AncillaryContentDescriptionEnum { AncillaryContentDescription, x424 }
        [XmlIgnore, DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public AncillaryContentDescriptionEnum[] AncillaryContentDescriptionChoice
        {
            get
            {
                if (AncillaryContentDescription == null) return null;
                AncillaryContentDescriptionEnum choice = SerializationSettings.UseShortTags ? AncillaryContentDescriptionEnum.x424 : AncillaryContentDescriptionEnum.AncillaryContentDescription;
                AncillaryContentDescriptionEnum[] result = new AncillaryContentDescriptionEnum[AncillaryContentDescription.Length];
                for (int i = 0; i < AncillaryContentDescription.Length; i++) result[i] = choice;
                return result;
            }
            set { }
        }

        /// <summary>
        /// The number of illustrations or other content items of the type specified in <see cref="AncillaryContentType"/>.
        /// Optional and non-repeating.
        /// </summary>
        [XmlChoiceIdentifier("NumberChoice")]
        [XmlElement("Number")]
        [XmlElement("b257")]
        public int Number { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum NumberEnum { Number, b257 }
        [XmlIgnore, DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public NumberEnum NumberChoice
        {
            get { return SerializationSettings.UseShortTags ? NumberEnum.b257 : NumberEnum.Number; }
            set { }
        }
    }
}
