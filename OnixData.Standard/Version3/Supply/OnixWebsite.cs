using System.ComponentModel;
using System.Xml.Serialization;

namespace OnixData.Version3.Supply
{
    /// <summary>
    /// A group of data elements which together identify and provide a pointer to a website
    /// </summary>
    [XmlType(AnonymousType = true)]
    public class OnixWebsite
    {

        #region Reference Tags

        /// <summary>
        /// An ONIX code which identifies the role or purpose of the website which is linked through the <see cref="WebsiteLink"/> element.
        /// Optional and non-repeating.
        /// </summary>
        /// <remarks>Onix List 73</remarks>
        [XmlChoiceIdentifier("WebsiteRoleChoice")]
        [XmlElement("WebsiteRole")]
        [XmlElement("b367")]
        public string WebsiteRole { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum WebsiteRoleEnum { WebsiteRole, b367 }
        [XmlIgnore, DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public WebsiteRoleEnum WebsiteRoleChoice
        {
            get { return SerializationSettings.UseShortTags ? WebsiteRoleEnum.b367 : WebsiteRoleEnum.WebsiteRole; }
            set { }
        }

        /// <summary>
        /// Free text describing the nature of the website which is linked through the <see cref="WebsiteLink"/> element.
        /// Optional, and repeatable to provide parallel descriptive text in multiple languages.
        /// The language attribute is optional for a single instance of <see cref="WebsiteDescription"/>, but must be included in each instance if <see cref="WebsiteDescription"/> is repeated.
        /// </summary>
        [XmlChoiceIdentifier("WebsiteDescriptionChoice")]
        [XmlElement("WebsiteDescription")]
        [XmlElement("b294")]
        public string[] WebsiteDescription { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum WebsiteDescriptionEnum { WebsiteDescription, b294 }
        [XmlIgnore, DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public WebsiteDescriptionEnum[] WebsiteDescriptionChoice
        {
            get
            {
                if (WebsiteDescription != null) return null;
                WebsiteDescriptionEnum choice = SerializationSettings.UseShortTags ? WebsiteDescriptionEnum.b294 : WebsiteDescriptionEnum.WebsiteDescription;
                WebsiteDescriptionEnum[] result = new WebsiteDescriptionEnum[WebsiteDescription.Length];
                for (int i = 0; i < WebsiteDescription.Length; i++) result[i] = choice;
                return result;
            }
            set { }
        }

        /// <summary>
        /// The URL for the website.
        /// Mandatory in each occurrence of the <see cref="OnixWebsite"/> composite, and repeatable to provide multiple URLs where the website content is available in multiple languages.
        /// The language attribute is optional for a single instance of <see cref="WebsiteLink"/>, but must be included in each instance if <see cref="WebsiteLink"/> is repeated.
        /// </summary>
        [XmlChoiceIdentifier("WebsiteLinkChoice")]
        [XmlElement("WebsiteLink")]
        [XmlElement("b295")]
        public string[] WebsiteLink { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum WebsiteLinkEnum { WebsiteLink, b295 }
        [XmlIgnore, DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public WebsiteLinkEnum[] WebsiteLinkChoice
        {
            get
            {
                if (WebsiteLink != null) return null;
                WebsiteLinkEnum choice = SerializationSettings.UseShortTags ? WebsiteLinkEnum.b295 : WebsiteLinkEnum.WebsiteLink;
                WebsiteLinkEnum[] result = new WebsiteLinkEnum[WebsiteLink.Length];
                for(int i = 0; i < WebsiteLink.Length; i++) result[i] = choice;
                return result;
            }
            set { }
        }

        #endregion
    }
}