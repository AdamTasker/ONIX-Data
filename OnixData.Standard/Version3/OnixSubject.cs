using System.ComponentModel;
using System.Xml.Serialization;

namespace OnixData.Version3
{
    /// <remarks/>
    [XmlType(AnonymousType = true)]
    public partial class OnixSubject
    {
        #region CONSTANTS

        public const string CONST_MAIN_SUBJ_INDICATOR = "MAIN";

        public const int CONST_SUBJ_SCHEME_BISAC_CAT_ID = 10;
        public const int CONST_SUBJ_SCHEME_REGION_ID = 11;

        #endregion


        #region Helper Methods

        public bool IsMainSubject()
        {
            return (!string.IsNullOrEmpty(MainSubject) && (MainSubject == CONST_MAIN_SUBJ_INDICATOR));
        }

        public int SubjectSchemeIdentifierNum
        {
            get
            {
                int nSubjSchemeIdNum = 0;

                if (!string.IsNullOrEmpty(SubjectSchemeIdentifier))
                    int.TryParse(SubjectSchemeIdentifier, out nSubjSchemeIdNum);

                return nSubjSchemeIdNum;
            }
        }

        #endregion

        #region Reference Tags

        /// <summary>
        /// An empty element that identifies an instance of the <see cref="OnixSubject"/> composite as representing the main subject category for the product.
        /// The main category may be expressed in more than one subject scheme, ie there may be two or more instances of the <see cref="OnixSubject"/> composite, using different schemes, each carrying the <see cref="MainSubject"/> flag, so long as there is only one main category per scheme.
        /// Optional and non-repeating in each occurrence of the <see cref="OnixSubject"/> composite.
        /// </summary>
        [XmlChoiceIdentifier("MainSubjectChoice")]
        [XmlElement("MainSubject")]
        [XmlElement("x425")]
        public string MainSubject { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum MainSubjectEnum { MainSubject, x425 }
        [XmlIgnore, DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public MainSubjectEnum MainSubjectChoice
        {
            get { return SerializationSettings.UseShortTags ? MainSubjectEnum.x425 : MainSubjectEnum.MainSubject; }
            set { }
        }

        /// <summary>
        /// <para>An ONIX code which identifies the category scheme which is used in an occurrence of the <see cref="OnixSubject"/> composite.
        /// Mandatory in each occurrence of the composite, and non-repeating.</para>
        ///
        /// <para>For category schemes that use code values, use the associated <see cref="SubjectCode"/> element to carry the value (if so required, the <see cref="SubjectHeadingText"/> element can be used simultaneously to carry the text equivalent of the code).
        /// For schemes that use text headings, use the <see cref="SubjectHeadingText"/> element to carry the text of the category heading.</para>
        /// </summary>
        /// <remarks>Onix List 27</remarks>
        [XmlChoiceIdentifier("SubjectSchemeIdentifierChoice")]
        [XmlElement("SubjectSchemeIdentifier")]
        [XmlElement("b067")]
        public string SubjectSchemeIdentifier { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum SubjectSchemeIdentifierEnum { SubjectSchemeIdentifier, b067 }
        [XmlIgnore, DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public SubjectSchemeIdentifierEnum SubjectSchemeIdentifierChoice
        {
            get { return SerializationSettings.UseShortTags ? SubjectSchemeIdentifierEnum.b067 : SubjectSchemeIdentifierEnum.SubjectSchemeIdentifier; }
            set { }
        }

        /// <summary>
        /// A name identifying a proprietary subject scheme (ie a scheme which is not a standard and for which there is no individual identifier code) when <see cref="SubjectSchemeIdentifier"/> is coded ‘24’.
        /// Optional and non-repeating.
        /// </summary>
        [XmlChoiceIdentifier("SubjectSchemeNameChoice")]
        [XmlElement("SubjectSchemeName")]
        [XmlElement("b171")]
        public string SubjectSchemeName { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum SubjectSchemeNameEnum { SubjectSchemeName, b171 }
        [XmlIgnore, DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public SubjectSchemeNameEnum SubjectSchemeNameChoice
        {
            get { return SerializationSettings.UseShortTags ? SubjectSchemeNameEnum.b171 : SubjectSchemeNameEnum.SubjectSchemeName; }
            set { }
        }

        /// <summary>
        /// A number which identifies a version or edition of the subject scheme specified in the associated <see cref="SubjectSchemeIdentifier"/> element.
        /// Optional and non-repeating.
        /// </summary>
        [XmlChoiceIdentifier("SubjectSchemeVersionChoice")]
        [XmlElement("SubjectSchemeVersion")]
        [XmlElement("b068")]
        public string SubjectSchemeVersion { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum SubjectSchemeVersionEnum { SubjectSchemeVersion, b068 }
        [XmlIgnore, DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public SubjectSchemeVersionEnum SubjectSchemeVersionChoice
        {
            get { return SerializationSettings.UseShortTags ? SubjectSchemeVersionEnum.b068 : SubjectSchemeVersionEnum.SubjectSchemeVersion; }
            set { }
        }

        /// <summary>
        /// A subject class or category code from the scheme specified in the <see cref="SubjectSchemeIdentifier"/> element.
        /// Either <see cref="SubjectCode"/> or <see cref="SubjectHeadingText"/> or both must be present in each occurrence of the <see cref="OnixSubject"/> composite.
        /// Non-repeating.
        /// </summary>
        [XmlChoiceIdentifier("SubjectCodeChoice")]
        [XmlElement("SubjectCode")]
        [XmlElement("b069")]
        public string SubjectCode { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum SubjectCodeEnum { SubjectCode, b069 }
        [XmlIgnore, DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public SubjectCodeEnum SubjectCodeChoice
        {
            get { return SerializationSettings.UseShortTags ? SubjectCodeEnum.b069 : SubjectCodeEnum.SubjectCode; }
            set { }
        }

        /// <summary>
        /// <para>The text of a subject heading taken from the scheme specified in the <see cref="SubjectSchemeIdentifier"/> element, or of free language keywords if the scheme is specified as ‘keywords’; or the text equivalent to the <see cref="SubjectCode"/> value, if both code and text are sent.
        /// Either <see cref="SubjectCode"/> or <see cref="SubjectHeadingText"/> or both must be present in each occurrence of the <see cref="OnixSubject"/> composite.</para>
        /// 
        /// <para>Optional, and repeatable if the text is sent in multiple languages.
        /// The language attribute is optional for a single instance of <see cref="SubjectHeadingText"/>, but must be included in each instance if <see cref="SubjectHeadingText"/> is repeated.</para>
        /// </summary>
        [XmlChoiceIdentifier("SubjectHeadingTextChoice")]
        [XmlElement("SubjectHeadingText")]
        [XmlElement("b070")]
        public string[] SubjectHeadingText { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum SubjectHeadingTextEnum { SubjectHeadingText, b070 }
        [XmlIgnore, DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public SubjectHeadingTextEnum[] SubjectHeadingTextChoice
        {
            get
            {
                if (SubjectHeadingText == null) return null;
                SubjectHeadingTextEnum choice = SerializationSettings.UseShortTags ? SubjectHeadingTextEnum.b070 : SubjectHeadingTextEnum.SubjectHeadingText;
                SubjectHeadingTextEnum[] result = new SubjectHeadingTextEnum[SubjectHeadingText.Length];
                for (int i = 0; i < SubjectHeadingText.Length; i++) result[i] = choice;
                return result;
            }
            set { }
        }

        #endregion
    }
}
