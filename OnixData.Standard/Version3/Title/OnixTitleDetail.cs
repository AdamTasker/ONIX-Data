using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace OnixData.Version3.Title
{
    /// <remarks/>
    [XmlType(AnonymousType = true)]
    public partial class OnixTitleDetail
    {
        #region CONSTANTS

        public const int CONST_TITLE_TYPE_UN_TITLE   = 0;
        public const int CONST_TITLE_TYPE_DIST_TITLE = 1;

        #endregion

        #region Helper Methods

        public string AssembledSeriesName
        {
            get
            {
                StringBuilder SeriesNameBuilder = new StringBuilder();

                var SeriesNameParts =
                    this.TitleElement.Where(x => x.IsQualifiedSeriesType()).OrderBy(x => x.TitleElementLevel);

                if (SeriesNameParts != null)
                {
                    foreach (var TitleElement in SeriesNameParts)
                    {
                        if (SeriesNameBuilder.Length > 0)
                            SeriesNameBuilder.Append(": ");

                        SeriesNameBuilder.Append(TitleElement.Title);
                    }
                }

                if (SeriesNameBuilder.Length <= 0)
                {
                    var MasterBrandTitle =
                        this.TitleElement.Where(x => x.IsMasterBrandType()).FirstOrDefault();

                    if ((MasterBrandTitle != null) && !string.IsNullOrEmpty(MasterBrandTitle.Title))
                    {
                        SeriesNameBuilder.Append(MasterBrandTitle.Title);
                    }
                }

                return SeriesNameBuilder.ToString();
            }
        }

        public OnixTitleElement FirstCollectionTitleElement
        {
            get
            {
                OnixTitleElement CollTitleElement = null;

                if ((TitleElement != null) && (TitleElement.Length > 0))
                {
                    var FoundElement =
                        TitleElement.Where(x => x.IsElementLevelCollection()).FirstOrDefault();

                    if (FoundElement != null)
                        CollTitleElement = FoundElement;
                }

                return CollTitleElement;
            }
        }

        public OnixTitleElement FirstProductTitleElement
        {
            get
            {
                OnixTitleElement PrdTitleElement = null;

                if ((TitleElement != null) && (TitleElement.Length > 0))
                {
                    var FoundElement =
                        TitleElement.Where(x => x.IsElementLevelProduct()).FirstOrDefault();

                    if (FoundElement != null)
                        PrdTitleElement = FoundElement;
                }

                return PrdTitleElement;
            }
        }

        public OnixTitleElement FirstTitleElement
        {
            get
            {
                OnixTitleElement FirstElement = null;

                if ((TitleElement != null) && (TitleElement.Length > 0))
                    FirstElement = TitleElement[0];

                return FirstElement;
            }
        }

        public string FullName
        {
            get
            {
                string sFullName = "";

                if ((FirstTitleElement != null) && !string.IsNullOrEmpty(FirstTitleElement.Title))
                    sFullName = FirstTitleElement.Title;

                return sFullName;
            }
        }

        public bool HasDistinctiveTitle()
        {
            bool bHasQualifiedTitle = false;

            if (TitleTypeNum > 0)
            {
                if (TitleTypeNum == CONST_TITLE_TYPE_DIST_TITLE)
                    bHasQualifiedTitle = true;
            }

            return bHasQualifiedTitle;
        }

        public bool HasQualifiedTitle()
        {
            bool bHasQualifiedTitle = false;

            if (TitleTypeNum > 0)
            {
                if ((TitleTypeNum == CONST_TITLE_TYPE_UN_TITLE) || (TitleTypeNum == CONST_TITLE_TYPE_DIST_TITLE))
                    bHasQualifiedTitle = true;
            }

            return bHasQualifiedTitle;
        }

        public bool IsCollectionName()
        {
            bool bIsCollName = false;

            if (FirstTitleElement != null)
                bIsCollName = (FirstTitleElement.TitleElementLevel == OnixTitleElement.CONST_TITLE_TYPE_COLLECTION);

            return bIsCollName;
        }

        public bool IsProductName()
        {
            bool bIsProdName = false;

            if (FirstTitleElement != null)
                bIsProdName = (FirstTitleElement.TitleElementLevel == OnixTitleElement.CONST_TITLE_TYPE_PRODUCT);

            return bIsProdName;
        }

        public bool IsSubCollectionName()
        {
            bool bIsSubCollName = false;

            if (FirstTitleElement != null)
                bIsSubCollName = (FirstTitleElement.TitleElementLevel == OnixTitleElement.CONST_TITLE_TYPE_SUB_COLL);

            return bIsSubCollName;
        }

        public bool IsSubItemName()
        {
            bool bIsSubItemName = false;

            if (FirstTitleElement != null)
                bIsSubItemName = (FirstTitleElement.TitleElementLevel == OnixTitleElement.CONST_TITLE_TYPE_SUB_ITEM);

            return bIsSubItemName;
        }

        public string Prefix
        {
            get
            {
                string sPrefix = "";

                if ((FirstTitleElement != null) && !string.IsNullOrEmpty(FirstTitleElement.TitlePrefix))
                    sPrefix = FirstTitleElement.TitlePrefix;

                return sPrefix;
            }
        }

        public string TitleWithoutPrefix
        {
            get
            {
                string sTitleWithoutPrefix = "";

                if ((FirstTitleElement != null) && !string.IsNullOrEmpty(FirstTitleElement.TitleWithoutPrefix))
                    sTitleWithoutPrefix = FirstTitleElement.TitleWithoutPrefix;

                return sTitleWithoutPrefix;
            }
        }

        public int TitleTypeNum
        {
            get
            {
                int nTypeNum = -1;

                if (!string.IsNullOrEmpty(TitleType))
                    int.TryParse(TitleType, out nTypeNum);

                return nTypeNum;
            }
        }

        #endregion

        #region Reference Tags

        /// <summary>
        /// An ONIX code indicating the type of a title.
        /// Mandatory in each occurrence of the <see cref="OnixTitleDetail"/> composite, and non-repeating.
        /// </summary>
        /// <remarks>Onix List 15</remarks>
        [XmlChoiceIdentifier("TitleTypeChoice")]
        [XmlElement("TitleType")]
        [XmlElement("b202")]
        public string TitleType { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum TitleTypeEnum { TitleType, b202 }
        [XmlIgnore, DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public TitleTypeEnum TitleTypeChoice
        {
            get { return SerializationSettings.UseShortTags ? TitleTypeEnum.b202 : TitleTypeEnum.TitleType; }
            set { }
        }

        /// <summary>
        /// A group of data elements which together represent an element of a collection title.
        /// At least one title element is mandatory in each occurrence of the <see cref="OnixTitleDetail"/> composite.
        /// The composite is repeatable with different sequence numbers and/or title element levels.
        /// </summary>
        [XmlChoiceIdentifier("TitleElementChoice")]
        [XmlElement("TitleElement")]
        [XmlElement("titleelement")]
        public OnixTitleElement[] TitleElement { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum TitleElementEnum { TitleElement, titleelement }
        [XmlIgnore, DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public TitleElementEnum[] TitleElementChoice
        {
            get
            {
                if (TitleElement == null) return null;
                TitleElementEnum choice = SerializationSettings.UseShortTags ? TitleElementEnum.titleelement : TitleElementEnum.TitleElement;
                TitleElementEnum[] result = new TitleElementEnum[TitleElement.Length];
                for (int i = 0; i < TitleElement.Length; i++) result[i] = choice;
                return result;
            }
            set { }
        }

        /// <summary>
        /// Free text showing how the collection title should be presented in any display, particularly when a standard concatenation of individual title elements from <see cref="OnixCollection"/> (in the order specified by the <see cref="OnixTitleElement.SequenceNumber"/> data elements) would not give a satisfactory result.
        /// Optional and non-repeating.
        /// When this field is sent, the recipient should use it to replace all collection title detail sent in <see cref="OnixCollection"/> for display purposes only.
        /// The individual collection title element detail must also be sent, for indexing and retrieval purposes.
        /// </summary>
        [XmlChoiceIdentifier("TitleStatementChoice")]
        [XmlElement("TitleStatement")]
        [XmlElement("x478")]
        public string TitleStatement { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum TitleStatementEnum { TitleStatement, x478 }
        [XmlIgnore, DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public TitleStatementEnum TitleStatementChoice
        {
            get { return SerializationSettings.UseShortTags ? TitleStatementEnum.x478 : TitleStatementEnum.TitleStatement; }
            set { }
        }

        #endregion
    }
}