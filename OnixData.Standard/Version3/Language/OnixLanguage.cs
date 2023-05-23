using System.ComponentModel;
using System.Xml.Serialization;
using OnixData.Version3.Xml.Enums;

namespace OnixData.Version3.Language
{
    /// <remarks/>
    [XmlType(AnonymousType = true)]
    public partial class OnixLanguage
    {
        #region CONSTANTS

        public const int CONST_ROLE_LANG_OF_TEXT = 1;

        #endregion

        #region Helper Methods

        public int GetLanguageRoleNum()
        {
            int nLangRole = -1;

            if (!string.IsNullOrEmpty(this.LanguageRole))
            {
                int.TryParse(this.LanguageRole, out nLangRole);
            }

            return nLangRole;
        }

        public bool IsLanguageOfText()
        {
            return (GetLanguageRoleNum() == CONST_ROLE_LANG_OF_TEXT);
        }

        #endregion

        #region Reference Tags

        /// <summary>
        /// An ONIX code indicating the ‘role’ of a language in the context of the ONIX record.
        /// Mandatory in each occurrence of the <see cref="OnixLanguage"/> composite, and non-repeating.
        /// </summary>
        /// <remarks>Onix List 22</remarks>
        [XmlChoiceIdentifier("LanguageRoleChoice")]
        [XmlElement("LanguageRole")]
        [XmlElement("b253")]
        public string LanguageRole { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum LanguageRoleEnum { LanguageRole, b253 }
        [XmlIgnore, DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public LanguageRoleEnum LanguageRoleChoice
        {
            get { return SerializationSettings.UseShortTags ? LanguageRoleEnum.b253 : LanguageRoleEnum.LanguageRole; }
            set { }
        }

        /// <summary>
        /// An ISO code indicating a language.
        /// Mandatory in each occurrence of the <see cref="OnixLanguage"/> composite, and non-repeating.
        /// </summary>
        /// <remarks>Onix List 74</remarks>
        [XmlChoiceIdentifier("LanguageCodeChoice")]
        [XmlElement("LanguageCode")]
        [XmlElement("b252")]
        public string LanguageCode { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum LanguageCodeEnum { LanguageCode, b252 }
        [XmlIgnore, DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public LanguageCodeEnum LanguageCodeChoice
        {
            get { return SerializationSettings.UseShortTags ? LanguageCodeEnum.b252 : LanguageCodeEnum.LanguageCode; }
            set { }
        }

        /// <summary>
        /// A code identifying the country when this specifies a variant of the language, eg US English.
        /// Optional and non-repeating.
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
        /// An ONIX code identifying the region when this specifies a variant of the language eg Flemish – Dutch as used in the Flemish region of Belgium.
        /// Optional and non-repeatable.
        /// A region is an area which is not a country (in the sense that it does not have a distinct country code), but which is precisely defined in geographical terms, eg Quebec, Scotland.
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
        /// A code identifying the script in which the language is represented.
        /// Optional and non-repeating.
        /// </summary>
        /// <remarks>Onix List 121</remarks>
        [XmlChoiceIdentifier("ScriptCodeChoice")]
        [XmlElement("ScriptCode")]
        [XmlElement("x420")]
        public string ScriptCode { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum ScriptCodeEnum { ScriptCode, x420 }
        [XmlIgnore, DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ScriptCodeEnum ScriptCodeChoice
        {
            get { return SerializationSettings.UseShortTags ? ScriptCodeEnum.x420 : ScriptCodeEnum.ScriptCode; }
            set { }
        }

    #endregion
}
}
