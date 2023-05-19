using System.ComponentModel;
using System.Xml.Serialization;

namespace OnixData.Version3.Subject
{
    public partial class OnixSubjectDate : OnixDate
    {
        /// <summary>
        /// An ONIX code indicating the significance of the date in relation to the subject name.
        /// Mandatory in each occurrence of the <see cref="OnixSubjectDate"/> composite, and non-repeating.
        /// </summary>
        /// <remarks>Onix List 177</remarks>
        [XmlChoiceIdentifier("SubjectDateRoleChoice")]
        [XmlElement("SubjectDateRole")]
        [XmlElement("x534")]
        public string SubjectDateRole { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum SubjectDateRoleEnum { SubjectDateRole, x534 }
        [XmlIgnore, DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public SubjectDateRoleEnum SubjectDateRoleChoice
        {
            get { return SerializationSettings.UseShortTags ? SubjectDateRoleEnum.x534 : SubjectDateRoleEnum.SubjectDateRole; }
            set { }
        }
    }
}
