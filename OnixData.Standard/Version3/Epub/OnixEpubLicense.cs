using System.ComponentModel;
using System.Xml.Serialization;

namespace OnixData.Version3.Epub
{
    /// <summary>
    /// A composite carrying the name or title of the license governing use of the product, and a link to the license terms in eye-readable or machine-readable form.
    /// </summary>
    public partial class OnixEpubLicense
    {
        /// <summary>
        /// The name or title of the license.
        /// Mandatory in any <see cref="OnixEpubLicense"/> composite, and repeatable to provide the license name in multiple languages.
        /// The language attribute is optional for a single instance of <see cref="EpubLicenseName"/>, but must be included in each instance if <see cref="EpubLicenseName"/> is repeated.
        /// </summary>
        [XmlChoiceIdentifier("EpubLicenseNameChoice")]
        [XmlElement("EpubLicenseName")]
        [XmlElement("x511")]
        public string[] EpubLicenseName { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum EpubLicenseNameEnum { EpubLicenseName, x511 }
        [XmlIgnore, DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public EpubLicenseNameEnum[] EpubLicenseNameChoice
        {
            get
            {
                if (EpubLicenseName == null) return null;
                EpubLicenseNameEnum choice = SerializationSettings.UseShortTags ? EpubLicenseNameEnum.x511 : EpubLicenseNameEnum.EpubLicenseName;
                EpubLicenseNameEnum[] result = new EpubLicenseNameEnum[EpubLicenseName.Length];
                for (int i = 0; i < EpubLicenseName.Length; i++) result[i] = choice;
                return result;
            }
            set { }
        }

        /// <summary>
        /// An optional composite that carries details of a link to an expression of the license terms, which may be in human-readable or machine-readable form.
        /// Repeatable when there is more than one expression of the license.
        /// </summary>
        [XmlChoiceIdentifier("EpubLicenseExpressionChoice")]
        [XmlElement("EpubLicenseExpression")]
        [XmlElement("epublicenseexpression")]
        public OnixEpubLicenseExpression[] EpubLicenseExpression { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum EpubLicenseExpressionEnum { EpubLicenseExpression, epublicenseexpression }
        [XmlIgnore, DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public EpubLicenseExpressionEnum[] EpubLicenseExpressionChoice
        {
            get
            {
                if (EpubLicenseExpression == null) return null;
                EpubLicenseExpressionEnum choice = SerializationSettings.UseShortTags ? EpubLicenseExpressionEnum.epublicenseexpression : EpubLicenseExpressionEnum.EpubLicenseExpression;
                EpubLicenseExpressionEnum[] result = new EpubLicenseExpressionEnum[EpubLicenseExpression.Length];
                for (int i = 0; i < EpubLicenseExpression.Length; i++) result[i] = choice;
                return result;
            }
            set { }
        }
    }
}
