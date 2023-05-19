using System.ComponentModel;
using System.Xml.Serialization;

namespace OnixData.Version3.Contributor
{
    /// <summary>
    /// A group of data elements which together specify a date associated with the person or organization, eg birth or death
    /// </summary>
    public partial class OnixContributorDate : OnixDate
    {
        /// <summary>
        /// An ONIX code indicating the significance of the date in relation to the contributor name.
        /// Mandatory in each occurrence of the <see cref="OnixContributorDate"/> composite, and non-repeating.
        /// </summary>
        /// <remarks>Onix List 177</remarks>
        [XmlChoiceIdentifier("ContributorDateRoleChoice")]
        [XmlElement("ContributorDateRole")]
        [XmlElement("x417")]
        public string ContributorDateRole { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum ContributorDateRoleEnum { ContributorDateRole, x417 }
        [XmlIgnore, DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ContributorDateRoleEnum ContributorDateRoleChoice
        {
            get { return SerializationSettings.UseShortTags ? ContributorDateRoleEnum.x417 : ContributorDateRoleEnum.ContributorDateRole; }
            set { }
        }
    }
}
