using System.ComponentModel;
using System.Xml.Serialization;

namespace OnixData.Version3.Publishing
{
    /// <remarks/>
    [XmlType(AnonymousType = true)]
    public class OnixTerritory
    {

        #region Reference Tags

        [XmlChoiceIdentifier("XmlChoiceCountriesIncluded")]
        [XmlElement("CountriesIncluded")]
        [XmlElement("x449")]
        public string CountriesIncluded { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum CountriesIncludedEnum { CountriesIncluded, x449 }
        [XmlIgnore, DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public CountriesIncludedEnum XmlChoiceCountriesIncluded
        {
            get { return SerializationSettings.UseShortTags ? CountriesIncludedEnum.x449 : CountriesIncludedEnum.CountriesIncluded; }
            set { }
        }

        [XmlChoiceIdentifier("XmlChoiceRegionsIncluded")]
        [XmlElement("RegionsIncluded")]
        [XmlElement("x450")]
        public string RegionsIncluded { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum RegionsIncludedEnum { RegionsIncluded, x450 }
        [XmlIgnore, DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public RegionsIncludedEnum XmlChoiceRegionsIncluded
        {
            get { return SerializationSettings.UseShortTags ? RegionsIncludedEnum.x450 : RegionsIncludedEnum.RegionsIncluded; }
            set { }
        }

        [XmlChoiceIdentifier("XmlChoiceCountriesExcluded")]
        [XmlElement("CountriesExcluded")]
        [XmlElement("x451")]
        public string CountriesExcluded { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum CountriesExcludedEnum { CountriesExcluded, x451 }
        [XmlIgnore, DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public CountriesExcludedEnum XmlChoiceCountriesExcluded
        {
            get { return SerializationSettings.UseShortTags ? CountriesExcludedEnum.x451 : CountriesExcludedEnum.CountriesExcluded; }
            set { }
        }

        [XmlChoiceIdentifier("XmlChoiceRegionsExcluded")]
        [XmlElement("RegionsExcluded")]
        [XmlElement("x452")]
        public string RegionsExcluded { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum RegionsExcludedEnum { RegionsExcluded, x452 }
        [XmlIgnore, DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public RegionsExcludedEnum XmlChoiceRegionsExcluded
        {
            get { return SerializationSettings.UseShortTags ? RegionsExcludedEnum.x452 : RegionsExcludedEnum.RegionsExcluded; }
            set { }
        }

        #endregion
    }
}
