using System.ComponentModel;
using System.Xml.Serialization;

namespace OnixData.Version3.Text
{
    public partial class OnixComplexity
    {
        /// <summary>
        /// An ONIX code specifying the scheme from which the value in <see cref="ComplexityCode"/> is taken.
        /// Mandatory in each occurrence of the <see cref="OnixComplexity"/> composite, and non-repeating.
        /// </summary>
        /// <remarks>Onix List 32</remarks>
        [XmlChoiceIdentifier("ComplexitySchemeIdentifierChoice")]
        [XmlElement("ComplexitySchemeIdentifier")]
        [XmlElement("b077")]
        public string ComplexitySchemeIdentifier { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum ComplexitySchemeIdentifierEnum { ComplexitySchemeIdentifier, b077 }
        [XmlIgnore, DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ComplexitySchemeIdentifierEnum ComplexitySchemeIdentifierChoice
        {
            get { return SerializationSettings.UseShortTags ? ComplexitySchemeIdentifierEnum.b077 : ComplexitySchemeIdentifierEnum.ComplexitySchemeIdentifier; }
            set { }
        }

        /// <summary>
        /// A code specifying the level of complexity of a text.
        /// Mandatory in each occurrence of the <see cref="OnixComplexity"/> composite, and non-repeating.
        /// </summary>
        [XmlChoiceIdentifier("ComplexityCodeChoice")]
        [XmlElement("ComplexityCode")]
        [XmlElement("b078")]
        public string ComplexityCode { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum ComplexityCodeEnum { ComplexityCode, b078 }
        [XmlIgnore, DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ComplexityCodeEnum ComplexityCodeChoice
        {
            get { return SerializationSettings.UseShortTags ? ComplexityCodeEnum.b078 : ComplexityCodeEnum.ComplexityCode; }
            set { }
        }
    }
}
