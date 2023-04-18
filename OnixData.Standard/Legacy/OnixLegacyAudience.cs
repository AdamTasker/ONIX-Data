using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace OnixData.Legacy
{
    /// <summary>
    /// Covers a range of methods of indicating the intended audience for a product. None is defined as mandatory in the XML DTD.
    /// Note that UK educational levels are covered in the BIC educational purpose qualifier, part of the BIC Subject Categories scheme (see the <see cref="OnixLegacySubject"/> composite).
    /// </summary>
    [XmlType(AnonymousType = true)]
    public class OnixLegacyAudience
    {
        #region CONSTANTS

        public const int CONST_AUD_TYPE_ONIX = 1;
        public const int CONST_AUD_TYPE_PROP = 2;
        public const int CONST_AUD_TYPE_MPAA = 3;
        public const int CONST_AUD_TYPE_BBFC = 4;

        #endregion

        public OnixLegacyAudience()
        {
            AudienceCodeTypeName = AudienceCodeValue = "";
        }

        #region Reference Tags

        /// <summary>
        /// An ONIX code which identifies the scheme from which the code in <see cref="AudienceCodeValue"/> is taken.
        /// Mandatory in each occurrence of the <see cref="OnixLegacyAudience"/> composite, and non-repeating.
        /// </summary>
        [XmlChoiceIdentifier("AudienceCodeTypeChoice")]
        [XmlElement("AudienceCodeType")]
        [XmlElement("b204")]
        public int AudienceCodeType { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum AudienceCodeTypeEnum { AudienceCodeType, b204 }
        [XmlIgnore]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public AudienceCodeTypeEnum AudienceCodeTypeChoice;

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
        [XmlIgnore]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public AudienceCodeTypeNameEnum AudienceCodeTypeNameChoice;

        /// <summary>
        /// A code value taken from the scheme specified in <see cref="AudienceCodeType"/>.
        /// Mandatory in each occurrence of the <see cref="OnixLegacyAudience"/> composite, and non-repeating.
        /// </summary>
        [XmlChoiceIdentifier("AudienceCodeValueChoice")]
        [XmlElement("AudienceCodeValue")]
        [XmlElement("b206")]
        public string AudienceCodeValue { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum AudienceCodeValueEnum { AudienceCodeValue, b206 }
        [XmlIgnore]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public AudienceCodeValueEnum AudienceCodeValueChoice;

        #endregion

    }
}
