using System.ComponentModel;
using System.Xml.Serialization;

namespace OnixData.Version3.Epub
{
    /// <summary>
    /// An group of data elements which together describe a usage constraint on a digital product (or the absence of such a constraint), whether enforced by DRM technical protection, inherent in the platform used, or specified by license agreement.
    /// </summary>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public class OnixEpubUsageConstraint
    {
        #region CONSTANTS

        public const int CONST_CONSTRAINT_TYPE_PREVIEW = 1;
        public const int CONST_CONSTRAINT_TYPE_PRINT   = 2;
        public const int CONST_CONSTRAINT_TYPE_COPY    = 3;
        public const int CONST_CONSTRAINT_TYPE_SHARE   = 4;
        public const int CONST_CONSTRAINT_TYPE_TTS     = 5;
        public const int CONST_CONSTRAINT_TYPE_LEND    = 6;
        public const int CONST_CONSTRAINT_TYPE_TIME    = 7;
        public const int CONST_CONSTRAINT_TYPE_RENEW   = 8;
        public const int CONST_CONSTRAINT_TYPE_MU      = 9;
        public const int CONST_CONSTRAINT_TYPE_PVW_LCL = 10;

        public const int CONST_CONSTRAINT_STS_UNLIMITED  = 1;
        public const int CONST_CONSTRAINT_STS_LIMITED    = 2;
        public const int CONST_CONSTRAINT_STS_PROHIBITED = 3;

        #endregion

        #region Reference Tags

        /// <summary>
        /// An ONIX code specifying a usage of a digital product.
        /// Mandatory in each occurrence of the <see cref="OnixEpubUsageConstraint"/> composite, and non-repeating.
        /// </summary>
        /// <remarks>Onix List 145</remarks>
        [XmlChoiceIdentifier("EpubUsageTypeChoice")]
        [XmlElement("EpubUsageType")]
        [XmlElement("x318")]
        public string EpubUsageType { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum EpubUsageTypeEnum { EpubUsageType, x318 }
        [XmlIgnore, DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public EpubUsageTypeEnum EpubUsageTypeChoice
        {
            get { return SerializationSettings.UseShortTags ? EpubUsageTypeEnum.x318 : EpubUsageTypeEnum.EpubUsageType; }
            set { }
        }

        /// <summary>
        /// An ONIX code specifying the status of a usage of a digital product, eg permitted without limit, permitted with limit, prohibited.
        /// Mandatory in each occurrence of the <see cref="OnixEpubUsageConstraint"/> composite, and non-repeating.
        /// </summary>
        /// <remarks>Onix List 146</remarks>
        [XmlChoiceIdentifier("EpubUsageStatusChoice")]
        [XmlElement("EpubUsageStatus")]
        [XmlElement("x319")]
        public string EpubUsageStatus { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum EpubUsageStatusEnum { EpubUsageStatus, x319 }
        [XmlIgnore, DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public EpubUsageStatusEnum EpubUsageStatusChoice
        {
            get { return SerializationSettings.UseShortTags ? EpubUsageStatusEnum.x319 : EpubUsageStatusEnum.EpubUsageStatus; }
            set { }
        }

        /// <summary>
        /// An optional group of data elements which together specify a quantitative limit on a particular type of usage of a digital product.
        /// Repeatable in order to specify two or more limits on the usage type.
        /// </summary>
        [XmlChoiceIdentifier("EpubUsageLimitChoice")]
        [XmlElement("EpubUsageLimit")]
        [XmlElement("epubusagelimit")]
        public OnixEpubUsageLimit[] EpubUsageLimit { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum EpubUsageLimitEnum { EpubUsageLimit, epubusagelimit }
        [XmlIgnore, DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public EpubUsageLimitEnum[] EpubUsageLimitChoice
        {
            get
            {
                if (EpubUsageLimit == null) return null;
                EpubUsageLimitEnum choice = SerializationSettings.UseShortTags ? EpubUsageLimitEnum.epubusagelimit : EpubUsageLimitEnum.EpubUsageLimit;
                EpubUsageLimitEnum[] result = new EpubUsageLimitEnum[EpubUsageLimit.Length];
                for (int i = 0; i < EpubUsageLimit.Length; i++) result[i] = choice;
                return result;
            }
            set { }
        }
        #endregion
    }
}
