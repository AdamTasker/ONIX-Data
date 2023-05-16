using System.ComponentModel;
using System.Xml.Serialization;

namespace OnixData.Version3
{
    /// <summary>
    /// A group of data elements which together define an identifier of the addressee.
    /// </summary>
    [XmlType(AnonymousType = true)]
    public partial class OnixIdentifier
    {
        #region Reference Tags

        /// <summary>
        /// A name which identifies a proprietary identifier scheme (ie a scheme which is not a standard and for which there is no individual ID type code).
        /// Must be included when, and only when, the code in the IDType element indicates a proprietary scheme.
        /// Optional and non-repeating.
        /// </summary>
        [XmlChoiceIdentifier("IDTypeNameChoice")]
        [XmlElement("IDTypeName")]
        [XmlElement("b233")]
        public string IDTypeName { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum IDTypeNameEnum { IDTypeName, b233 }
        [XmlIgnore, DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public IDTypeNameEnum IDTypeNameChoice
        {
            get { return SerializationSettings.UseShortTags ? IDTypeNameEnum.b233 : IDTypeNameEnum.IDTypeName; }
            set { }
        }

        /// <summary>
        /// An identifier of the type specified in the IDType element.
        /// Mandatory and non-repeating.
        /// </summary>
        [XmlChoiceIdentifier("IDValueChoice")]
        [XmlElement("IDValue")]
        [XmlElement("b244")]
        public string IDValue { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum IDValueEnum { IDValue, b244 }
        [XmlIgnore, DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public IDValueEnum IDValueChoice
        {
            get { return SerializationSettings.UseShortTags ? IDValueEnum.b244 : IDValueEnum.IDValue; }
            set { }
        }

        #endregion
    }
}
