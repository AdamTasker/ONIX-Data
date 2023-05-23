using System.ComponentModel;
using System.Xml.Serialization;
using OnixData.Version3.Xml.Enums;

namespace OnixData.Version3.Contributor
{
    public partial class OnixContributorPlace
    {

        /// <summary>
        /// An ONIX code identifying the relationship between a contributor and a geographical location.
        /// Mandatory in each occurrence of <see cref="OnixContributorPlace"/> and non-repeating.
        /// </summary>
        /// <remarks>Onix List 151</remarks>
        [XmlChoiceIdentifier("ContributorPlaceRelatorChoice")]
        [XmlElement("ContributorPlaceRelator")]
        [XmlElement("x418")]
        public string ContributorPlaceRelator { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum ContributorPlaceRelatorEnum  { ContributorPlaceRelator, x418 }
        [XmlIgnore, DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ContributorPlaceRelatorEnum ContributorPlaceRelatorChoice
        {
            get { return SerializationSettings.UseShortTags ? ContributorPlaceRelatorEnum.x418 : ContributorPlaceRelatorEnum.ContributorPlaceRelator; }
            set { }
        }

        /// <summary>
        /// A code identifying a country with which a contributor is particularly associated.
        /// Optional and non-repeatable.
        /// There must be an occurrence of either the <see cref="CountryCode"/> or the <see cref="RegionCode"/> elements in each occurrence of <see cref="OnixContributorPlace"/>.
        /// </summary>
        /// <remarks>Onix List 91</remarks>
        [XmlChoiceIdentifier("CountryCodeChoice")]
        [XmlElement("CountryCode")]
        [XmlElement("b251")]
        public string CountryCode { get; set; }
        [XmlIgnore, DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public CountryCodeEnum CountryCodeChoice
        {
            get { return SerializationSettings.UseShortTags ? CountryCodeEnum.b251 : CountryCodeEnum.CountryCode; }
            set { }
        }

        /// <summary>
        /// An ONIX code identifying a region with which a contributor is particularly associated.
        /// Optional and non-repeatable.
        /// There must be an occurrence of either the <see cref="CountryCode"/> or the <see cref="RegionCode"/> elements in each occurrence of <see cref="OnixContributorPlace"/>.
        /// A region is an area which is not a country, but which is precisely defined in geographical terms, eg Northern Ireland, Australian Capital Territory.
        /// If both country and region are specified, the region must be within the country.
        /// Note that US States have region codes, while US overseas territories have distinct ISO Country Codes.
        /// </summary>
        /// <remarks>Onix List 49 where possible and appropriate</remarks>
        [XmlChoiceIdentifier("RegionCodeChoice")]
        [XmlElement("RegionCode")]
        [XmlElement("b398")]
        public string RegionCode { get; set; }
        [XmlIgnore, DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public RegionCodeEnum RegionCodeChoice
        {
            get { return SerializationSettings.UseShortTags ? RegionCodeEnum.b398 : RegionCodeEnum.RegionCode; }
            set { }
        }

        /// <summary>
        /// The name of a city or town location within the specified country or region with which a contributor is particularly associated.
        /// Optional, and repeatable to provide parallel names for a single location in multiple languages (eg Baile Átha Cliath and Dublin, or Bruxelles and Brussel).
        /// The language attribute is optional for a single instance of <see cref="LocationName"/>, but must be included in each instance if <see cref="LocationName"/> is repeated.
        /// </summary>
        [XmlChoiceIdentifier("LocationNameChoice")]
        [XmlElement("LocationName")]
        [XmlElement("j349")]
        public string[] LocationName { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum LocationNameEnum { LocationName, j349 }
        [XmlIgnore, DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public LocationNameEnum[] LocationNameChoice
        {
            get
            {
                if (LocationName == null) return null;
                LocationNameEnum choice = SerializationSettings.UseShortTags ? LocationNameEnum.j349 : LocationNameEnum.LocationName;
                LocationNameEnum[] result = new LocationNameEnum[LocationName.Length];
                for (int i = 0; i < LocationName.Length; i++) result[i] = choice;
                return result;
            }
            set { }
        }
    }
}
