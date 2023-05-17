using System.ComponentModel;
using System.Linq;
using System.Xml.Serialization;

namespace OnixData.Version3.Title
{
    /// <summary>
    /// A group of data elements which together represent an element of a collection title.
    /// An instance of the <TitleElement> composite must include at least one of: <PartNumber>; <YearOfAnnual>; <TitleText>, <NoPrefix/> together with <TitleWithoutPrefix>, or <TitlePrefix> together with <TitleWithoutPrefix>.
    /// In other words, it must carry either the text of a title element or a part or year designation, and it may carry both.
    ///
    /// A title element must be designated as belonging to product level, collection level, or subcollection level (the first of these may not occur in a title element representing a collective identity, and the last-named may only occur in the case of a multi-level collection).
    ///
    /// In the simplest case, title detail sent in a <Collection> composite will consist of a single title element, at collection level.
    /// However, the composite structure in ONIX 3.0 allows more complex combinations of titles and part designations in multi-level collections to be correctly represented.
    /// </summary>
    [XmlType(AnonymousType = true)]
    public partial class OnixTitleElement
    {
        #region CONSTANTS

        public const int CONST_TITLE_TYPE_PRODUCT = 1;
        public const int CONST_TITLE_TYPE_COLLECTION = 2;
        public const int CONST_TITLE_TYPE_SUB_COLL = 3;
        public const int CONST_TITLE_TYPE_SUB_ITEM = 4;
        public const int CONST_TITLE_TYPE_MASTER_BRAND = 5;
        public const int CONST_TITLE_TYPE_SUB_SUB_COLL = 6;

        public readonly int[] CONST_TITLE_TYPES_SERIES =
            new[] { CONST_TITLE_TYPE_COLLECTION, CONST_TITLE_TYPE_SUB_COLL, CONST_TITLE_TYPE_SUB_SUB_COLL };

        #endregion

        #region Helper Methods

        public int GetPartNum()
        {
            int nPartNum = -1;

            if (!string.IsNullOrEmpty(PartNumber))
                int.TryParse(PartNumber, out nPartNum);

            return nPartNum;
        }

        public bool IsElementLevelCollection()
        {
            return (TitleElementLevel == CONST_TITLE_TYPE_COLLECTION);
        }

        public bool IsElementLevelProduct()
        {
            return (TitleElementLevel == CONST_TITLE_TYPE_PRODUCT);
        }

        public bool IsMasterBrandType()
        {
            return (TitleElementLevel == CONST_TITLE_TYPE_MASTER_BRAND);
        }

        public bool IsQualifiedSeriesType()
        {
            return (CONST_TITLE_TYPES_SERIES.Contains(TitleElementLevel));
        }

        public string Title
        {
            get
            {
                string sTitle = "";

                if (!string.IsNullOrEmpty(TitleText))
                    sTitle = TitleText;
                else if (!string.IsNullOrEmpty(TitleWithoutPrefix))
                    sTitle = TitlePrefix + " " + TitleWithoutPrefix;

                sTitle = sTitle.Trim();

                return sTitle;
            }
        }

        #endregion

        #region Reference Tags

        /// <summary>
        /// A number which specifies a single overall sequence of title elements, which is the preferred order for display of the various title elements when constructing a complete title.
        /// Optional and non-repeating. It is strongly recommended that each occurrence of the <see cref="OnixTitleElement"/> composite should carry a <see cref="SequenceNumber">.
        /// </summary>
        [XmlChoiceIdentifier("SequenceNumberChoice")]
        [XmlElement("SequenceNumber")]
        [XmlElement("b034")]
        public int SequenceNumber { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum SequenceNumberEnum { SequenceNumber, b034 }
        [XmlIgnore, DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public SequenceNumberEnum SequenceNumberChoice
        {
            get { return SerializationSettings.UseShortTags ? SequenceNumberEnum.b034 : SequenceNumberEnum.SequenceNumber; }
            set { }
        }

        /// <summary>
        /// An ONIX code indicating the level of a title element: collection level, subcollection level, or product level.
        /// Mandatory in each occurrence of the <see cref="OnixTitleElement"/> composite, and non-repeating.
        /// </summary>
        /// <remarks>Onix List 149</remarks>
        [XmlChoiceIdentifier("TitleElementLevelChoice")]
        [XmlElement("TitleElementLevel")]
        [XmlElement("x409")]
        public int TitleElementLevel { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum TitleElementLevelEnum { TitleElementLevel, x409 }
        [XmlIgnore, DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public TitleElementLevelEnum TitleElementLevelChoice
        {
            get { return SerializationSettings.UseShortTags ? TitleElementLevelEnum.x409 : TitleElementLevelEnum.TitleElementLevel; }
            set { }
        }

        /// <summary>
        /// When a title element includes a part designation within a larger whole (eg Part I, or Volume 3), this field should be used to carry the number and its ‘caption’ as text.
        /// Optional and non-repeating.
        /// </summary>
        [XmlChoiceIdentifier("PartNumberChoice")]
        [XmlElement("PartNumber")]
        [XmlElement("x410")]
        public string PartNumber { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum PartNumberEnum { PartNumber, x410 }
        [XmlIgnore, DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public PartNumberEnum PartNumberChoice
        {
            get { return SerializationSettings.UseShortTags ? PartNumberEnum.x410 : PartNumberEnum.PartNumber; }
            set { }
        }

        /// <summary>
        /// When the year of an annual is part of a title, this field should be used to carry the year (or, if required, a spread of years such as 2009–2010).
        /// Optional and non-repeating.
        /// </summary>
        [XmlChoiceIdentifier("YearOfAnnualChoice")]
        [XmlElement("YearOfAnnual")]
        [XmlElement("b020")]
        public string YearOfAnnual { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum YearOfAnnualEnum { YearOfAnnual, b020 }
        [XmlIgnore, DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public YearOfAnnualEnum YearOfAnnualChoice
        {
            get { return SerializationSettings.UseShortTags ? YearOfAnnualEnum.b020 : YearOfAnnualEnum.YearOfAnnual; }
            set { }
        }

        /// <summary>
        /// The text of a title element, excluding any subtitle.
        /// Optional and non-repeating, may only be used where <see cref="TitlePrefix"/>, <see cref="NoPrefix"/> and <see cref="TitleWithoutPrefix"/> are not used.
        /// <para/>
        /// This element is intended to be used only when the sending system cannot reliably provide prefixes that are ignored for sorting purposes in a separate data element.
        /// If the system can reliably separate prefixes, it should state whether a prefix is present (using <see cref="TitlePrefix"/> and <see cref="TitleWithoutPrefix"/>) or absent (using <see cref="NoPrefix"/> and <see cref="TitleWithoutPrefix"/>).
        /// </summary>
        [XmlChoiceIdentifier("TitleTextChoice")]
        [XmlElement("TitleText")]
        [XmlElement("b203")]
        public string TitleText { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum TitleTextEnum { TitleText, b203 }
        [XmlIgnore, DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public TitleTextEnum TitleTextChoice
        {
            get { return SerializationSettings.UseShortTags ? TitleTextEnum.b203 : TitleTextEnum.TitleText; }
            set { }
        }

        /// <summary>
        /// Text at the beginning of a title element which is to be ignored for alphabetical sorting.
        /// Optional and non-repeating; can only be used when <TitleText> is omitted, and if the <TitleWithoutPrefix> element is also present.
        /// These two elements may be used in combination in applications where it is necessary to distinguish an initial word or character string which is to be ignored for filing purposes, eg in library systems and in some bookshop databases.
        /// </summary>
        [XmlChoiceIdentifier("TitlePrefixChoice")]
        [XmlElement("TitlePrefix")]
        [XmlElement("b030")]
        public string TitlePrefix { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum TitlePrefixEnum { TitlePrefix, b030 }
        [XmlIgnore, DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public TitlePrefixEnum TitlePrefixChoice
        {
            get { return SerializationSettings.UseShortTags ? TitlePrefixEnum.b030 : TitlePrefixEnum.TitlePrefix; }
            set { }
        }

        /// <summary>
        /// An empty element that provides a positive indication that a title element does not include any prefix that is ignored for sorting purposes.
        /// Optional and non-repeating, and must only be used when <see cref="TitleWithoutPrefix"/> is used and no <see cref="TitlePrefix"/> element is present.
        /// </summary>
        [XmlChoiceIdentifier("NoPrefixChoice")]
        [XmlElement("NoPrefix")]
        [XmlElement("x501")]
        public string NoPrefix { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum NoPrefixEnum { NoPrefix, x501 }
        [XmlIgnore, DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public NoPrefixEnum NoPrefixChoice
        {
            get { return SerializationSettings.UseShortTags ? NoPrefixEnum.x501 : NoPrefixEnum.NoPrefix; }
            set { }
        }

        /// <summary>
        /// The text of a title element without the title prefix; and excluding any subtitle.
        /// Optional and non-repeating; can only be used if one of the <see cref="NoPrefix"/> or <see cref="TitlePrefix"/> elements is also present.
        /// </summary>
        [XmlChoiceIdentifier("TitleWithoutPrefixChoice")]
        [XmlElement("TitleWithoutPrefix")]
        [XmlElement("b031")]
        public string TitleWithoutPrefix { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum TitleWithoutPrefixEnum { TitleWithoutPrefix, b031 }
        [XmlIgnore, DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public TitleWithoutPrefixEnum TitleWithoutPrefixChoice
        {
            get { return SerializationSettings.UseShortTags ? TitleWithoutPrefixEnum.b031 : TitleWithoutPrefixEnum.TitleWithoutPrefix; }
            set { }
        }

        /// <summary>
        /// The text of a subtitle, if any.
        /// ‘Subtitle’ means any added words which appear with the title element given in an occurrence of the <see cref="TitleElement"/> composite, and which amplify and explain the title element, but which are not considered to be part of the title element itself.
        /// Optional and non-repeating.
        /// </summary>
        [XmlChoiceIdentifier("SubtitleChoice")]
        [XmlElement("Subtitle")]
        [XmlElement("b029")]
        public string Subtitle { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum SubtitleEnum { Subtitle, b029 }
        [XmlIgnore, DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public SubtitleEnum SubtitleChoice
        {
            get { return SerializationSettings.UseShortTags ? SubtitleEnum.b029 : SubtitleEnum.Subtitle; }
            set { }
        }

        #endregion
    }}
