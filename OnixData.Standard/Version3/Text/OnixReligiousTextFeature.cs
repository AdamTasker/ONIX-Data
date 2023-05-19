using System.ComponentModel;
using System.Xml.Serialization;

namespace OnixData.Version3.Text
{
    public partial class OnixReligiousTextFeature
    {
        /// <summary>
        /// An ONIX code specifying a feature described in the associated <see cref="ReligiousTextFeatureCode"/> element.
        /// Mandatory in each occurrence of the <see cref="OnixReligiousTextFeature"/> composite, and non-repeating.
        /// </summary>
        /// <remarks>Onix List 89</remarks>
        [XmlChoiceIdentifier("ReligiousTextFeatureTypeChoice")]
        [XmlElement("ReligiousTextFeatureType")]
        [XmlElement("b358")]
        public string ReligiousTextFeatureType { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum ReligiousTextFeatureTypeEnum { ReligiousTextFeatureType, b358 }
        [XmlIgnore, DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ReligiousTextFeatureTypeEnum ReligiousTextFeatureTypeChoice
        {
            get { return SerializationSettings.UseShortTags ? ReligiousTextFeatureTypeEnum.b358 : ReligiousTextFeatureTypeEnum.ReligiousTextFeatureType; }
            set { }
        }

        /// <summary>
        /// An ONIX code describing a feature specified in the associated <see cref="ReligiousTextFeatureType"/> element.
        /// Mandatory in each occurrence of the <see cref="OnixReligiousTextFeature"/> composite, and non-repeating.
        /// </summary>
        /// <remarks>Onix List 90</remarks>
        [XmlChoiceIdentifier("ReligiousTextFeatureCodeChoice")]
        [XmlElement("ReligiousTextFeatureCode")]
        [XmlElement("b359")]
        public string ReligiousTextFeatureCode { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum ReligiousTextFeatureCodeEnum { ReligiousTextFeatureCode, b359 }
        [XmlIgnore, DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ReligiousTextFeatureCodeEnum ReligiousTextFeatureCodeChoice
        {
            get { return SerializationSettings.UseShortTags ? ReligiousTextFeatureCodeEnum.b359 : ReligiousTextFeatureCodeEnum.ReligiousTextFeatureCode; }
            set { }
        }

        /// <summary>
        /// Free text describing a feature that is not adequately defined by code values alone.
        /// Optional, and repeatable if parallel descriptive text is provided in multiple languages.
        /// The language attribute is optional for a single instance of <see cref="ReligiousTextFeatureDescription"/>, but must be included in each instance if <see cref="ReligiousTextFeatureDescription"/> is repeated.
        /// </summary>
        [XmlChoiceIdentifier("ReligiousTextFeatureDescriptionChoice")]
        [XmlElement("ReligiousTextFeatureDescription")]
        [XmlElement("b360")]
        public string[] ReligiousCodeFeatureDescription { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum ReligiousCodeFeatureDescriptionEnum { ReligiousCodeFeatureDescription, b360 }
        [XmlIgnore, DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ReligiousCodeFeatureDescriptionEnum[] ReligiousCodeFeatureDescriptionChoice
        {
            get
            {
                if (ReligiousCodeFeatureDescription == null) return null;
                ReligiousCodeFeatureDescriptionEnum choice = SerializationSettings.UseShortTags ? ReligiousCodeFeatureDescriptionEnum.b360 : ReligiousCodeFeatureDescriptionEnum.ReligiousCodeFeatureDescription;
                ReligiousCodeFeatureDescriptionEnum[] result = new ReligiousCodeFeatureDescriptionEnum[ReligiousCodeFeatureDescription.Length];
                for (int i = 0; i < ReligiousCodeFeatureDescription.Length; i++) result[i] = choice;
                return result;
            }
            set { }
        }
    }
}
