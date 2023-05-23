using System.ComponentModel;
using System.Xml.Serialization;

namespace OnixData.Version3.Audience
{
    /// <remarks/>
    [XmlType(AnonymousType = true)]
    public class OnixAudience
    {
        #region CONSTANTS

        public const int CONST_AUD_TYPE_ONIX = 1;
        public const int CONST_AUD_TYPE_PROP = 2;
        public const int CONST_AUD_TYPE_MPAA = 3;
        public const int CONST_AUD_TYPE_BBFC = 4;

        #endregion

        #region Reference Tags

        /// <summary>
        /// An ONIX code which identifies the scheme from which the code in <see cref="AudienceCodeValue"/> is taken.
        /// Mandatory in each occurrence of the <see cref="OnixAudience"/> composite, and non-repeating.
        /// </summary>
        /// <remarks>List 29</remarks>
        [XmlChoiceIdentifier("AudienceCodeTypeChoice")]
        [XmlElement("AudienceCodeType")]
        [XmlElement("b204")]
        public int AudienceCodeType { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum AudienceCodeTypeEnum { AudienceCodeType, b204 }
        [XmlIgnore, DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public AudienceCodeTypeEnum AudienceCodeTypeChoice
        {
            get { return SerializationSettings.UseShortTags ? AudienceCodeTypeEnum.b204 : AudienceCodeTypeEnum.AudienceCodeType; }
            set { }
        }

        /// <summary>
        /// A name which identifies a proprietary audience code when the code in <see cref="AudienceCodeType"/> indicates a proprietary scheme, eg a vendor’s own code.
        /// Optional and non-repeating.
        /// </summary>
        [XmlChoiceIdentifier("AudienceCodeTypeNameChoice")]
        [XmlElement("AudienceCodeTypeName")]
        [XmlElement("b205")]
        public string AudienceCodeTypeName { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum AudienceCodeTypeNameEnum { AudienceCodeTypeName, b205 }
        [XmlIgnore, DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public AudienceCodeTypeNameEnum AudienceCodeTypeNameChoice
        {
            get { return SerializationSettings.UseShortTags ? AudienceCodeTypeNameEnum.b205 : AudienceCodeTypeNameEnum.AudienceCodeTypeName; }
            set { }
        }

        /// <summary>
        /// A code value taken from the scheme specified in <see cref="AudienceCodeType"/>.
        /// Mandatory in each occurrence of the <see cref="OnixAudience"/> composite, and non-repeating.
        /// </summary>
        [XmlChoiceIdentifier("AudienceCodeValueChoice")]
        [XmlElement("AudienceCodeValue")]
        [XmlElement("b206")]
        public string AudienceCodeValue { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum AudienceCodeValueEnum { AudienceCodeValue, b206 }
        [XmlIgnore, DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public AudienceCodeValueEnum AudienceCodeValueChoice
        {
            get { return SerializationSettings.UseShortTags ? AudienceCodeValueEnum.b206 : AudienceCodeValueEnum.AudienceCodeValue; }
            set { }
        }

        #endregion

    }
}
