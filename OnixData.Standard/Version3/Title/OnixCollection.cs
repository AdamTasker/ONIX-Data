using System.ComponentModel;
using System.Linq;
using System.Xml.Serialization;

namespace OnixData.Version3.Title
{
    /// <summary>
    /// A group of data elements which carry attributes of a collection of which the product is part.
    /// </summary>
    [XmlType(AnonymousType = true)]
    public partial class OnixCollection
    {
        #region CONSTANTS

        public const int CONST_COLL_TYPE_MISC     = 0;
        public const int CONST_COLL_TYPE_SERIES_1 = 10;
        public const int CONST_COLL_TYPE_SERIES_2 = 11;
        public const int CONST_COLL_TYPE_AGGR     = 20;

        public readonly int[] CONST_COLL_TYPES_SERIES =
            new int[] { CONST_COLL_TYPE_SERIES_1, CONST_COLL_TYPE_SERIES_2, CONST_COLL_TYPE_AGGR };

        #endregion

        #region Helper Methods

        public int CollectionTypeNum
        {
            get
            {
                int nCollTypeNum = -1;

                if (!string.IsNullOrEmpty(CollectionType))
                    int.TryParse(CollectionType, out nCollTypeNum);

                return nCollTypeNum;
            }
        }

        public string CollectionName
        {
            get
            {
                string sCollName = "";

                var TitleDetailList = this.TitleDetail;

                if ((TitleDetailList != null) && (TitleDetailList.Length > 0))
                {
                    string sFullName          = "";
                    string sPrefixName        = "";
                    string sWithoutPrefixName = "";

                    OnixTitleDetail FullNameTitleDetail =
                        TitleDetailList.Where(x => x.IsCollectionName() && x.HasQualifiedTitle() && !string.IsNullOrEmpty(x.FullName)).LastOrDefault();

                    OnixTitleDetail PrefixTitleDetail =
                        TitleDetailList.Where(x => x.IsCollectionName() && x.HasQualifiedTitle() && !string.IsNullOrEmpty(x.Prefix)).LastOrDefault();

                    OnixTitleDetail WithoutPrefixTitleDetail =
                        TitleDetailList.Where(x => x.IsCollectionName() && x.HasQualifiedTitle() && !string.IsNullOrEmpty(x.TitleWithoutPrefix)).LastOrDefault();

                    if (FullNameTitleDetail != null)
                        sFullName = FullNameTitleDetail.FullName;

                    if (PrefixTitleDetail != null)
                        sPrefixName = PrefixTitleDetail.Prefix;

                    if (WithoutPrefixTitleDetail != null)
                        sWithoutPrefixName = WithoutPrefixTitleDetail.TitleWithoutPrefix;

                    if (!string.IsNullOrEmpty(sFullName))
                        sCollName = sFullName;
                    else if (!string.IsNullOrEmpty(sWithoutPrefixName))
                    {
                        if (!string.IsNullOrEmpty(sPrefixName))
                            sCollName = sPrefixName + " : ";

                        sCollName += sWithoutPrefixName;
                    }
                }

                return sCollName;
            }
        }

        public bool IsSeriesType()
        {
            return (CONST_COLL_TYPES_SERIES.Contains(CollectionTypeNum));
        }

        public bool IsGeneralType()
        {
            return (CollectionTypeNum == CONST_COLL_TYPE_MISC);
        }

        public string SeriesSequence
        {
            get
            {
                string sSeqNum = "";

                if ((this.CollectionSequence != null) && (this.CollectionSequence.Length > 0))
                {
                    OnixCollectionSequence SeriesSeq =
                        this.CollectionSequence
                            .Where(x => x.IsSeriesSeq()).OrderBy(x => x.CollectionSequenceTypeNum).FirstOrDefault();

                    if ((SeriesSeq == null) || (SeriesSeq.CollectionSequenceTypeNum < 0))
                    {
                        SeriesSeq =
                            this.CollectionSequence
                                .Where(x => x.CollectionSequenceTypeNum == OnixCollectionSequence.CONST_COLL_SEQ_TYPE_PROP)
                                .FirstOrDefault();
                    }

                    if ((SeriesSeq != null) && (SeriesSeq.CollectionSequenceNum > 0))
                        sSeqNum = SeriesSeq.CollectionSequenceNum.ToString();
                }

                return sSeqNum;
            }
        }

        public string TitleSequence
        {
            get
            {
                string sSeqNum = "";

                if ((this.CollectionSequence != null) && (this.CollectionSequence.Length > 0))
                {
                    OnixCollectionSequence TitleCollSeq =
                        this.CollectionSequence.Where(x => x.IsTitleSeq()).LastOrDefault();

                    if ((TitleCollSeq != null) && (TitleCollSeq.CollectionSequenceNum > 0))
                        sSeqNum = TitleCollSeq.CollectionSequenceNum.ToString();
                }

                return sSeqNum;
            }
        }

        #endregion

        #region Reference Tags

        /// <summary>
        /// An ONIX code indicating the type of a collection: publisher collection, ascribed collection, or unspecified.
        /// Mandatory in each occurrence of the <see cref="OnixCollection"/> composite, and non-repeating.
        /// </summary>
        /// <remarks>Onix List 148</remarks>
        [XmlChoiceIdentifier("CollectionTypeChoice")]
        [XmlElement("CollectionType")]
        [XmlElement("x329")]
        public string CollectionType { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum CollectionTypeEnum { CollectionType, x329 }
        [XmlIgnore, DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public CollectionTypeEnum CollectionTypeChoice
        {
            get { return SerializationSettings.UseShortTags ? CollectionTypeEnum.x329 : CollectionTypeEnum.CollectionType; }
            set { }
        }

        /// <summary>
        /// If the <see cref="CollectionType"/> code indicates an ascribed collection (ie a collection which has been identified and described by a supply chain organization other than the publisher), this element may be used to carry the name of the organization responsible.
        /// Optional and non-repeating.
        /// </summary>
        [XmlChoiceIdentifier("SourceNameChoice")]
        [XmlElement("SourceName")]
        [XmlElement("x330")]
        public string SourceName { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum SourceNameEnum { SourceName, x330 }
        [XmlIgnore, DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public SourceNameEnum SourceNameChoice
        {
            get { return SerializationSettings.UseShortTags ? SourceNameEnum.x330 : SourceNameEnum.SourceName; }
            set { }
        }

        /// <summary>
        /// A repeatable group of data elements which together specify an identifier of a bibliographic collection.
        /// The composite is optional, and may only repeat if two or more identifiers of different types are sent for the same collection.
        /// It is not permissible to have two identifiers of the same type.
        /// </summary>
        [XmlChoiceIdentifier("CollectionIdentifierChoice")]
        [XmlElement("CollectionIdentifier")]
        [XmlElement("collectionidentifier")]
        public OnixCollectionIdentifier[] CollectionIdentifier { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum CollectionIdentifierEnum { CollectionIdentifier, collectionidentifier }
        [XmlIgnore, DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public CollectionIdentifierEnum[] CollectionIdentifierChoice
        {
            get
            {
                if (CollectionIdentifier == null) return null;
                CollectionIdentifierEnum choice = SerializationSettings.UseShortTags ? CollectionIdentifierEnum.collectionidentifier : CollectionIdentifierEnum.CollectionIdentifier;
                CollectionIdentifierEnum[] result = new CollectionIdentifierEnum[CollectionIdentifier.Length];
                for (int i = 0; i < CollectionIdentifier.Length; i++) result[i] = choice;
                return result;
            }
            set { }
        }

        /// <summary>
        /// An optional and repeatable group of data elements which indicates some ordinal position of a product within a collection.
        /// Different ordinal positions may be specified using separate repeats of the composite – for example, a product may be published first while also being third in narrative order within a collection.
        /// </summary>
        [XmlChoiceIdentifier("CollectionSequenceChoice")]
        [XmlElement("CollectionSequence")]
        [XmlElement("collectionsequence")]
        public OnixCollectionSequence[] CollectionSequence { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum CollectionSequenceEnum { CollectionSequence, collectionsequence }
        [XmlIgnore, DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public CollectionSequenceEnum[] CollectionSequenceChoice
        {
            get
            {
                if (CollectionSequence == null) return null;
                CollectionSequenceEnum choice = SerializationSettings.UseShortTags ? CollectionSequenceEnum.collectionsequence : CollectionSequenceEnum.CollectionSequence;
                CollectionSequenceEnum[] result = new CollectionSequenceEnum[CollectionSequence.Length];
                for (int i = 0; i < CollectionSequence.Length; i++) result[i] = choice;
                return result;
            }
            set { }
        }

        /// <summary>
        /// A group of data elements which together give the text of a collection title and specify its type.
        /// Optional, but the composite is required unless the only collection title is carried in full, and word-for-word, as an integral part of the product title in <see cref="OnixDescriptiveDetail.TitleDetail"/>, in which case it should not be repeated in <see cref="OnixCollection"/>.
        /// The composite is repeatable with different title types.
        /// </summary>
        [XmlChoiceIdentifier("TitleDetailChoice")]
        [XmlElement("TitleDetail")]
        [XmlElement("titledetail")]
        public OnixTitleDetail[] TitleDetail { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum TitleDetailEnum { TitleDetail, titledetail }
        [XmlIgnore, DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public TitleDetailEnum[] TitleDetailChoice
        {
            get
            {
                if (TitleDetail == null) return null;
                TitleDetailEnum choice = SerializationSettings.UseShortTags ? TitleDetailEnum.titledetail : TitleDetailEnum.TitleDetail;
                TitleDetailEnum[] result = new TitleDetailEnum[TitleDetail.Length];
                for (int i = 0; i < TitleDetail.Length; i++) result[i] = result[i] = choice;
                return result;
            }
            set { }
        }

        /// <summary>
        /// A group of data elements which together describe a personal or corporate contributor to a collection.
        /// Optional, and repeatable to describe multiple contributors.
        /// The <see cref="Contributor"/> composite is included here for use only by those ONIX communities whose national practice requires contributors to be identified at collection level.
        /// In many countries, including the UK, USA, Canada and Spain, the required practice is to identify all contributors at product level in <see cref="OnixDescriptiveDetail.Contributor"/>.
        /// </summary>
        [XmlChoiceIdentifier("ContributorChoice")]
        [XmlElement("Contributor")]
        [XmlElement("contributor")]
        public OnixContributor[] Contributor { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum ContributorEnum { Contributor, contributor }
        [XmlIgnore, DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ContributorEnum[] ContributorChoice
        {
            get
            {
                if (Contributor == null) return null;
                ContributorEnum choice = SerializationSettings.UseShortTags ? ContributorEnum.contributor : ContributorEnum.Contributor;
                ContributorEnum[] result = new ContributorEnum[Contributor.Length];
                for (int i = 0; i < Contributor.Length; i++) result[i] = choice;
                return result;
            }
            set { }
        }

        #endregion
    }
}
