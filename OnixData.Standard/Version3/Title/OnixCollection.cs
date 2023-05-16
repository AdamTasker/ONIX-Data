using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnixData.Version3.Title
{
    /// <summary>
    /// A group of data elements which carry attributes of a collection of which the product is part.
    /// </summary>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
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

        public OnixCollection()
        {
            collTypeField    = "";
            collSeqField     = shortCollSeqField     = new OnixCollectionSequence[0];
            titleDetailField = shortTitleDetailField = new OnixTitleDetail[0];
        }

        private string collTypeField;

        private OnixCollectionSequence[] collSeqField;
        private OnixCollectionSequence[] shortCollSeqField;

        private OnixTitleDetail[] titleDetailField;
        private OnixTitleDetail[] shortTitleDetailField;

        #region ONIX Lists

        public OnixCollectionSequence[] OnixCollectionSequenceList
        {
            get
            {
                OnixCollectionSequence[] CollSeqList = null;

                if (this.collSeqField != null)
                    CollSeqList = this.collSeqField;
                else if (this.shortCollSeqField != null)
                    CollSeqList = this.shortCollSeqField;
                else
                    CollSeqList = new OnixCollectionSequence[0];

                return CollSeqList;
            }
        }

        public OnixTitleDetail[] OnixTitleDetailList
        {
            get
            {
                OnixTitleDetail[] TitleDetailList = null;

                if (this.titleDetailField != null)
                    TitleDetailList = this.titleDetailField;
                else if (this.shortTitleDetailField != null)
                    TitleDetailList = this.shortTitleDetailField;
                else
                    TitleDetailList = new OnixTitleDetail[0];

                return TitleDetailList;
            }
        }

        #endregion

        #region Helper Methods

        public int CollectionTypeNum
        {
            get
            {
                int nCollTypeNum = -1;

                if (!String.IsNullOrEmpty(CollectionType))
                    Int32.TryParse(CollectionType, out nCollTypeNum);

                return nCollTypeNum;
            }
        }

        public string CollectionName
        {
            get
            {
                string sCollName = "";

                var TitleDetailList = this.OnixTitleDetailList;

                if ((TitleDetailList != null) && (TitleDetailList.Length > 0))
                {
                    string sFullName          = "";
                    string sPrefixName        = "";
                    string sWithoutPrefixName = "";

                    OnixTitleDetail FullNameTitleDetail =
                        TitleDetailList.Where(x => x.IsCollectionName() && x.HasQualifiedTitle() && !String.IsNullOrEmpty(x.FullName)).LastOrDefault();

                    OnixTitleDetail PrefixTitleDetail =
                        TitleDetailList.Where(x => x.IsCollectionName() && x.HasQualifiedTitle() && !String.IsNullOrEmpty(x.Prefix)).LastOrDefault();

                    OnixTitleDetail WithoutPrefixTitleDetail =
                        TitleDetailList.Where(x => x.IsCollectionName() && x.HasQualifiedTitle() && !String.IsNullOrEmpty(x.TitleWithoutPrefix)).LastOrDefault();

                    if (FullNameTitleDetail != null)
                        sFullName = FullNameTitleDetail.FullName;

                    if (PrefixTitleDetail != null)
                        sPrefixName = PrefixTitleDetail.Prefix;

                    if (WithoutPrefixTitleDetail != null)
                        sWithoutPrefixName = WithoutPrefixTitleDetail.TitleWithoutPrefix;

                    if (!String.IsNullOrEmpty(sFullName))
                        sCollName = sFullName;
                    else if (!String.IsNullOrEmpty(sWithoutPrefixName))
                    {
                        if (!String.IsNullOrEmpty(sPrefixName))
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

                if ((this.OnixCollectionSequenceList != null) && (this.OnixCollectionSequenceList.Length > 0))
                {
                    OnixCollectionSequence SeriesSeq =
                        this.OnixCollectionSequenceList
                            .Where(x => x.IsSeriesSeq()).OrderBy(x => x.CollectionSequenceTypeNum).FirstOrDefault();

                    if ((SeriesSeq == null) || (SeriesSeq.CollectionSequenceTypeNum < 0))
                    {
                        SeriesSeq =
                            this.OnixCollectionSequenceList
                                .Where(x => x.CollectionSequenceTypeNum == OnixCollectionSequence.CONST_COLL_SEQ_TYPE_PROP)
                                .FirstOrDefault();
                    }

                    if ((SeriesSeq != null) && (SeriesSeq.CollectionSequenceNum > 0))
                        sSeqNum = Convert.ToString(SeriesSeq.CollectionSequenceNum);
                }

                return sSeqNum;
            }
        }

        public string TitleSequence
        {
            get
            {
                string sSeqNum = "";

                if ((this.OnixCollectionSequenceList != null) && (this.OnixCollectionSequenceList.Length > 0))
                {
                    OnixCollectionSequence TitleCollSeq =
                        this.OnixCollectionSequenceList.Where(x => x.IsTitleSeq()).LastOrDefault();

                    if ((TitleCollSeq != null) && (TitleCollSeq.CollectionSequenceNum > 0))
                        sSeqNum = Convert.ToString(TitleCollSeq.CollectionSequenceNum);
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
        public string CollectionType
        {
            get { return this.collTypeField; }
            set { this.collTypeField = value; }
        }

        /// <summary>
        /// If the <see cref="CollectionType"/> code indicates an ascribed collection (ie a collection which has been identified and described by a supply chain organization other than the publisher), this element may be used to carry the name of the organization responsible.
        /// Optional and non-repeating.
        /// </summary>
        public string SourceName { get; set; }

        /// <summary>
        /// A repeatable group of data elements which together specify an identifier of a bibliographic collection.
        /// The composite is optional, and may only repeat if two or more identifiers of different types are sent for the same collection.
        /// It is not permissible to have two identifiers of the same type.
        /// </summary>
        public OnixCollectionIdentifier[] CollectionIdentifier { get; set; }

        /// <summary>
        /// An optional and repeatable group of data elements which indicates some ordinal position of a product within a collection.
        /// Different ordinal positions may be specified using separate repeats of the composite – for example, a product may be published first while also being third in narrative order within a collection.
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute("CollectionSequence")]
        public OnixCollectionSequence[] CollectionSequence
        {
            get { return this.collSeqField; }
            set { this.collSeqField = value; }
        }

        /// <summary>
        /// A group of data elements which together give the text of a collection title and specify its type.
        /// Optional, but the composite is required unless the only collection title is carried in full, and word-for-word, as an integral part of the product title in <see cref="OnixDescriptiveDetail.TitleDetail"/>, in which case it should not be repeated in <see cref="OnixCollection"/>.
        /// The composite is repeatable with different title types.
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute("TitleDetail")]
        public OnixTitleDetail[] TitleDetail
        {
            get { return this.titleDetailField; }
            set { this.titleDetailField = value; }
        }

        /// <summary>
        /// A group of data elements which together describe a personal or corporate contributor to a collection.
        /// Optional, and repeatable to describe multiple contributors.
        /// The <see cref="Contributor"/> composite is included here for use only by those ONIX communities whose national practice requires contributors to be identified at collection level.
        /// In many countries, including the UK, USA, Canada and Spain, the required practice is to identify all contributors at product level in <see cref="OnixDescriptiveDetail.Contributor"/>.
        /// </summary>
        public OnixContributor[] Contributor { get; set; }

        #endregion

        #region Short Tags

        /// <remarks/>
        public string x329
        {
            get { return CollectionType; }
            set { CollectionType = value; }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("collectionsequence")]
        public OnixCollectionSequence[] collectionsequence
        {
            get { return this.shortCollSeqField; }
            set { this.shortCollSeqField = value; }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("titledetail")]
        public OnixTitleDetail[] titledetail
        {
            get { return this.shortTitleDetailField; }
            set { this.shortTitleDetailField = value; }
        }

        #endregion
    }
}
