using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnixData.Version3.Title
{
    /// <summary>
    /// A group of data elements which indicates some ordinal position of a product within a collection. Different ordinal positions may be specified using separate repeats of the composite – for example, a product may be published first while also being third in narrative order within a collection.
    /// </summary>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class OnixCollectionSequence
    {
        #region CONSTANTS

        public const int CONST_COLL_SEQ_TYPE_PROP       = 1;
        public const int CONST_COLL_SEQ_TYPE_TTL_ORDER  = 2;
        public const int CONST_COLL_SEQ_TYPE_PUB_ORDER  = 3;
        public const int CONST_COLL_SEQ_TYPE_NAR_ORDER  = 4;
        public const int CONST_COLL_SEQ_TYPE_ORIG_ORDER = 5;
        public const int CONST_COLL_SEQ_TYPE_SGR_ORDER  = 6;
        public const int CONST_COLL_SEQ_TYPE_SGD_ORDER  = 7;

        public readonly int[] CONST_COLL_SEQ_TYPES_PRIMARY =
            new int[] { CONST_COLL_SEQ_TYPE_TTL_ORDER , CONST_COLL_SEQ_TYPE_PUB_ORDER, CONST_COLL_SEQ_TYPE_NAR_ORDER,
                        CONST_COLL_SEQ_TYPE_ORIG_ORDER, CONST_COLL_SEQ_TYPE_SGR_ORDER, CONST_COLL_SEQ_TYPE_SGD_ORDER };

        #endregion

        public OnixCollectionSequence()
        {
            CollectionSequenceType = CollectionSequenceTypeName = CollectionSequenceNumber = "";
        }
      
        private string collSeqTypeField;
        private string collSeqTypeNameField;
        private string collSeqField;

        #region Helper Methods

        public int CollectionSequenceTypeNum
        {
            get
            {
                int nCollSeqType = -1;

                if (!String.IsNullOrEmpty(CollectionSequenceType))
                    Int32.TryParse(CollectionSequenceType, out nCollSeqType);

                return nCollSeqType;
            }
        }

        public int CollectionSequenceNum
        {
            get
            {
                int nCollSeq = -1;

                if (!String.IsNullOrEmpty(CollectionSequenceNumber))
                    Int32.TryParse(CollectionSequenceNumber, out nCollSeq);

                return nCollSeq;
            }
        }

        public bool IsTitleSeq()
        {
            return ((CollectionSequenceTypeNum == CONST_COLL_SEQ_TYPE_PROP) || (CollectionSequenceTypeNum == CONST_COLL_SEQ_TYPE_TTL_ORDER));
        }

        public bool IsSeriesSeq()
        {
            return CONST_COLL_SEQ_TYPES_PRIMARY.Contains(CollectionSequenceTypeNum);
        }

        #endregion

        #region Reference Tags

        /// <summary>
        /// An ONIX code identifying the type of ordering used for the product’s sequence number within the collection.
        /// Mandatory and non-repeating within the <see cref="OnixCollectionSequence"/> composite.
        /// </summary>
        /// <remarks>Onix List 197</remarks>
        public string CollectionSequenceType
        {
            get
            {
                return this.collSeqTypeField;
            }
            set
            {
                this.collSeqTypeField = value;
            }
        }

        /// <summary>
        /// A name which describes a proprietary order used for the product’s sequence number within the collection.
        /// Must be included when, and only when, the code in the <see cref="CollectionSequenceType"/> field indicates a proprietary scheme.
        /// Optional and non-repeating.
        /// </summary>
        public string CollectionSequenceTypeName
        {
            get
            {
                return this.collSeqTypeNameField;
            }
            set
            {
                this.collSeqTypeNameField = value;
            }
        }

        /// <summary>
        /// <para>A number which specifies the ordinal position of the product in a collection.
        /// The ordinal position may be a simple number (1st, 2nd, 3rd etc) or may be multi-level (eg 3.2) if the collection has a multi-level structure (ie there are both collection and sub-collection title elements).
        /// Mandatory and non-repeating within the <see cref="OnixCollectionSequence"/> composite.</para>
        ///
        /// <para>A hyphen may be used in place of an integer within a multi-level number, where a particular level of the hierarchy is unnumbered, for example -.3 where a product is the third in a sub-collection, and the sub-collection is unnumbered within the collection.</para>
        /// </summary>
        public string CollectionSequenceNumber
        {
            get
            {
                return this.collSeqField;
            }
            set
            {
                this.collSeqField = value;
            }
        }

        #endregion

        #region Short Tags

        /// <remarks/>
        public string x479
        {
            get
            {
                return CollectionSequenceType;
            }
            set
            {
                CollectionSequenceType = value;
            }
        }

        /// <remarks/>
        public string x480
        {
            get
            {
                return CollectionSequenceTypeName;
            }
            set
            {
                CollectionSequenceTypeName = value;
            }
        }

        /// <remarks/>
        public string x481
        {
            get
            {
                return CollectionSequenceNumber;
            }
            set
            {
                CollectionSequenceNumber = value;
            }
        }

        #endregion
    }}
