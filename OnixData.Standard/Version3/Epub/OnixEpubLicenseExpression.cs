using System.ComponentModel;
using System.Xml.Serialization;

namespace OnixData.Version3.Epub
{
    /// <summary>
    /// A composite that carries details of a link to an expression of the license terms, which may be in human-readable or machine-readable form.
    /// </summary>
    public partial class OnixEpubLicenseExpression
    {

        /// <summary>
        /// An ONIX code identifying the nature or format of the license expression specified in the <see cref="EpubLicenseExpressionLink"/> element.
        /// Mandatory within the <see cref="OnixEpubLicenseExpression"/> composite, and non-repeating.
        /// </summary>
        /// <remarks>Onix List 218</remarks>
        [XmlChoiceIdentifier("EpubLicenseExpressionTypeChoice")]
        [XmlElement("EpubLicenseExpressionType")]
        [XmlElement("x508")]
        public string EpubLicenseExpressionType { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum EpubLicenseExpressionTypeEnum { EpubLicenseExpressionType, x508 }
        [XmlIgnore, DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public EpubLicenseExpressionTypeEnum EpubLicenseExpressionTypeChoice
        {
            get { return SerializationSettings.UseShortTags ? EpubLicenseExpressionTypeEnum.x508 : EpubLicenseExpressionTypeEnum.EpubLicenseExpressionType; }
            set { }
        }

        /// <summary>
        /// A short free-text name for a license expression type, when the code in <see cref="EpubLicenseExpressionType"/> provides insufficient detail – for example when a machine-readable license is expressed using a particular proprietary encoding scheme.
        /// Optional and non-repeating, and must be included when (and only when) the <see cref="EpubLicenseExpressionType"/> element indicates the expression is encoded in a proprietary way.
        /// </summary>
        [XmlChoiceIdentifier("EpubLicenseExpressionTypeNameChoice")]
        [XmlElement("EpubLicenseExpressionTypeName")]
        [XmlElement("x509")]
        public string EpubLicenseExpressionTypeName { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum EpubLicenseExpressionTypeNameEnum { EpubLicenseExpressionTypeName, x509 }
        [XmlIgnore, DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public EpubLicenseExpressionTypeNameEnum EpubLicenseExpressionTypeNameChoice
        {
            get { return SerializationSettings.UseShortTags ? EpubLicenseExpressionTypeNameEnum.x509 : EpubLicenseExpressionTypeNameEnum.EpubLicenseExpressionTypeName; }
            set { }
        }

        /// <summary>
        /// The URI for the license expression.
        /// Mandatory in each instance of the <see cref="OnixEpubLicenseExpression"/> composite, and non-repeating.
        /// </summary>
        [XmlChoiceIdentifier("EpubLicenseExpressionLinkChoice")]
        [XmlElement("EpubLicenseExpressionLink")]
        [XmlElement("x510")]
        public string EpubLicenseExpressionLink { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum EpubExpressionLinkEnum { EpubLicenseExpressionLink, x510 }
        [XmlIgnore, DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public EpubExpressionLinkEnum EpubLicenseExpressionLinkChoice
        {
            get { return SerializationSettings.UseShortTags ? EpubExpressionLinkEnum.x510 : EpubExpressionLinkEnum.EpubLicenseExpressionLink; }
            set { }
        }
    }
}
