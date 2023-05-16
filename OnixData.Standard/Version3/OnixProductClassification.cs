using System.ComponentModel;
using System.Xml.Serialization;

namespace OnixData.Version3
{
    /// <summary>
    /// A group of data elements which together define a product classification (not to be confused with a subject classification).
    /// The intended use is to enable national or international trade classifications (also known as commodity codes) to be carried in an ONIX record.
    /// </summary>
    [XmlType(AnonymousType = true)]
    [XmlRoot(Namespace = "", IsNullable = false)]
    public partial class OnixProductClassification
    {
        /// <summary>
        /// An ONIX code identifying the scheme from which the identifier in <see cref="ProductClassificationCode"/> is taken.
        /// Mandatory in each occurrence of the <see cref="OnixProductClassification"/> composite, and non-repeating.
        /// </summary>
        /// <remarks>Onix List 9</remarks>
        [XmlChoiceIdentifier("ProductClassificationTypeChoice")]
        [XmlElement("ProductClassificationType")]
        [XmlElement("b274")]
        public string ProductClassificationType { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum ProductClassificationTypeEnum { ProductClassificationType, b274 }
        [XmlIgnore]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ProductClassificationTypeEnum ProductClassificationTypeChoice
        {
            get { return SerializationSettings.UseShortTags ? ProductClassificationTypeEnum.b274 : ProductClassificationTypeEnum.ProductClassificationType; }
            set { }
        }

        /// <summary>
        /// A name which identifies a proprietary classification scheme (ie a scheme which is not a standard and for which there is no individual scheme type code).
        /// Should be included when, and only when, the code in the <see cref="ProductClassificationType"/> element indicates a proprietary scheme, ie the sender’s own category scheme.
        /// Optional and non-repeating.
        /// </summary>
        [XmlChoiceIdentifier("ProductClassificationTypeNameChoice")]
        [XmlElement("ProductClassificationTypeName")]
        [XmlElement("x555")]
        public string ProductClassificationTypeName { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum ProductClassificationTypeNameEnum { ProductClassificationTypeName, x555 }
        [XmlIgnore]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ProductClassificationTypeNameEnum ProductClassificationTypeNameChoice
        {
            get { return SerializationSettings.UseShortTags ? ProductClassificationTypeNameEnum.x555 : ProductClassificationTypeNameEnum.ProductClassificationTypeName; }
            set { }
        }

        /// <summary>
        /// A classification code from the scheme specified in <see cref="ProductClassificationType"/>.
        /// Mandatory in each occurrence of the <see cref="OnixProductClassification"/> composite, and non-repeating.
        /// </summary>
        [XmlChoiceIdentifier("ProductClassificationCodeChoice")]
        [XmlElement("ProductClassificationCode")]
        [XmlElement("b275")]
        public string ProductClassificationCode { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum ProductClassificationCodeEnum { ProductClassificationCode, b275 }
        [XmlIgnore]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ProductClassificationCodeEnum ProductClassificationCodeChoice
        {
            get { return SerializationSettings.UseShortTags ? ProductClassificationCodeEnum.b275 : ProductClassificationCodeEnum.ProductClassificationCode; }
            set { }
        }

        /// <summary>
        /// The percentage of the unit value of the product that is assignable to a designated product classification.
        /// Optional and non-repeating.
        /// Used when a mixed product (eg book and CD) belongs partly to two or more product classes within a particular scheme.
        /// If omitted, the product classification code applies to 100% of the product.
        /// </summary>
        [XmlChoiceIdentifier("PercentChoice")]
        [XmlElement("Percent")]
        [XmlElement("b337")]
        public decimal Percent { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum PercentEnum { Percent, b337 }
        [XmlIgnore]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public PercentEnum PercentChoice
        {
            get { return SerializationSettings.UseShortTags ? PercentEnum.b337 : PercentEnum.Percent; }
            set { }
        }
    }
}
