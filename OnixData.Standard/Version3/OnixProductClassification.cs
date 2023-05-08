using System.ComponentModel;
using System.Xml.Serialization;

namespace OnixData.Version3
{
  [XmlType(AnonymousType = true)]
  [XmlRoot(Namespace = "", IsNullable = false)]
  public partial class OnixProductClassification
  {
    [XmlChoiceIdentifier("ProductClassificationTypeChoice")]
    [XmlElement("ProductClassificationType")]
    [XmlElement("b274")]
    public string ProductClassificationType { get; set; }
    [XmlType(IncludeInSchema = false)]
    internal enum ProductClassificationTypeEnum { ProductClassificationType, b274 }
    [XmlIgnore]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    internal ProductClassificationTypeEnum ProductClassificationTypeChoice;

    [XmlChoiceIdentifier("ProductClassificationTypeNameChoice")]
    [XmlElement("ProductClassificationTypeName")]
    [XmlElement("x555")]
    public string ProductClassificationTypeName { get; set; }
    [XmlType(IncludeInSchema = false)]
    internal enum ProductClassificationTypeNameEnum { ProductClassificationTypeName, x555 }
    [XmlIgnore]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    internal ProductClassificationTypeNameEnum ProductClassificationTypeNameChoice;

    [XmlChoiceIdentifier("ProductClassificationCodeChoice")]
    [XmlElement("ProductClassificationCode")]
    [XmlElement("b275")]
    public string ProductClassificationCode { get; set; }
    [XmlType(IncludeInSchema = false)]
    internal enum ProductClassificationCodeEnum { ProductClassificationCode, b275 }
    [XmlIgnore]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    internal ProductClassificationCodeEnum ProductClassificationCodeChoice;

    [XmlChoiceIdentifier("PercentChocie")]
    [XmlElement("Percent")]
    [XmlElement("b337")]
    public string Percent { get; set; }
    [XmlType(IncludeInSchema = false)]
    internal enum PercentEnum { Percent, b337 }
    [XmlIgnore]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    internal PercentEnum PercentChoice;
  }
}
