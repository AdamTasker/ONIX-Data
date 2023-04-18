using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace OnixData.Legacy
{
    /// <summary>
    /// An optional and repeatable group of data elements which together describe an audience or readership range for which a product is intended.
    /// The composite can carry a single value from, to, or exact, or a pair of values with an explicit from and to.
    /// </summary>
    [XmlType(AnonymousType = true)]
    public partial class OnixLegacyAudRange
    {
        #region CONSTANTS

        public const int CONST_AUD_RANGE_TYPE_US_GRADES    = 11;
        public const int CONST_AUD_RANGE_TYPE_UK_GRADES    = 12;
        public const int CONST_AUD_RANGE_TYPE_INTEREST_AGE = 17;
        public const int CONST_AUD_RANGE_TYPE_READING_AGE  = 18;
        public const int CONST_AUD_RANGE_TYPE_SP_GRADES    = 19;
        public const int CONST_AUD_RANGE_TYPE_NW_GRADES    = 20;

        public const int CONST_AUD_RANGE_PRCN_EXACT = 1;
        public const int CONST_AUD_RANGE_PRCN_FROM  = 3;
        public const int CONST_AUD_RANGE_PRCN_TO    = 4;

        public const string CONST_AUD_GRADE_PRESCHOOL_CD  = "P";
        public const string CONST_AUD_GRADE_PRESCHOOL_TXT = "PRE-SCHOOL";
        public const string CONST_AUD_GRADE_KNDGRTN_CD    = "K";
        public const string CONST_AUD_GRADE_KNDGRTN_TXT   = "KINDERGARTEN";

        #endregion

        public OnixLegacyAudRange()
        {
            AudienceRangeQualifier = -1;

            AudienceRangePrecision = new int[0];
            AudienceRangeValue     = new string[0];
        }

        #region ONIX Helper Methods

        public string USAgeFrom
        {
            get
            {
                string FoundAgeFrom = FindAudRangeValue(CONST_AUD_RANGE_TYPE_INTEREST_AGE, CONST_AUD_RANGE_PRCN_FROM);
                if (string.IsNullOrEmpty(FoundAgeFrom))
                {
                    FoundAgeFrom = FindAudRangeValue(CONST_AUD_RANGE_TYPE_READING_AGE, CONST_AUD_RANGE_PRCN_FROM);
                    if (string.IsNullOrEmpty(FoundAgeFrom))
                    {
                        FoundAgeFrom = FindAudRangeValue(CONST_AUD_RANGE_TYPE_INTEREST_AGE, CONST_AUD_RANGE_PRCN_EXACT);
                        if (string.IsNullOrEmpty(FoundAgeFrom))
                            FoundAgeFrom = FindAudRangeValue(CONST_AUD_RANGE_TYPE_READING_AGE, CONST_AUD_RANGE_PRCN_EXACT);
                    }
                }

                return FoundAgeFrom;
            }
        }

        public string USAgeTo
        {
            get
            {
                string FoundAgeTo = FindAudRangeValue(CONST_AUD_RANGE_TYPE_INTEREST_AGE, CONST_AUD_RANGE_PRCN_TO);
                if (string.IsNullOrEmpty(FoundAgeTo))
                {
                    FoundAgeTo = FindAudRangeValue(CONST_AUD_RANGE_TYPE_READING_AGE, CONST_AUD_RANGE_PRCN_TO);
                    if (string.IsNullOrEmpty(FoundAgeTo))
                    {
                        FoundAgeTo = FindAudRangeValue(CONST_AUD_RANGE_TYPE_INTEREST_AGE, CONST_AUD_RANGE_PRCN_EXACT);
                        if (string.IsNullOrEmpty(FoundAgeTo))
                            FoundAgeTo = FindAudRangeValue(CONST_AUD_RANGE_TYPE_READING_AGE, CONST_AUD_RANGE_PRCN_EXACT);
                    }
                }

                return FoundAgeTo;
            }
        }

        public string USGradeExact
        {
            get
            {
                return FindAudRangeValue(CONST_AUD_RANGE_TYPE_US_GRADES, CONST_AUD_RANGE_PRCN_EXACT);
            }
        }

        public string USGradeFrom
        {
            get
            {
                return FindAudRangeValue(CONST_AUD_RANGE_TYPE_US_GRADES, CONST_AUD_RANGE_PRCN_FROM);
            }
        }

        public string USGradeTo
        {
            get
            {
                return FindAudRangeValue(CONST_AUD_RANGE_TYPE_US_GRADES, CONST_AUD_RANGE_PRCN_TO);
            }
        }

        #endregion

        #region Reference Tags

        /// <summary>
        /// An ONIX code specifying the attribute (age, school grade etc) which is measured by the value in the <see cref="AudienceRangeValue"/> element.
        /// Mandatory in each occurrence of the <see cref="OnixLegacyAudRange"/> composite, and non-repeating.
        /// </summary>
        [XmlChoiceIdentifier("AudienceRangeQualifierChoice")]
        [XmlElement("AudienceRangeQualifier")]
        [XmlElement("b074")]
        public int AudienceRangeQualifier { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum AudienceRangeTypeEnum { AudienceRangeQualifier, b074 }
        [XmlIgnore]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public AudienceRangeTypeEnum AudienceRangeQualifierChoice;

        /// <summary>
        /// An ONIX code specifying the “precision” of the value in the <see cref="AudienceRangeValue"/> element which follows (From, To, Exact).
        /// Mandatory in each occurrence of the <see cref="OnixLegacyAudRange"/> composite, and non-repeating.
        /// A second occurrence of the two elements <see cref="AudienceRangePrecision"/> and <see cref="AudienceRangeValue"/> is required only when a “From … to …” range is specified.
        /// </summary>
        [XmlChoiceIdentifier("AudienceRangePrecisionChoice")]
        [XmlElement("AudienceRangePrecision")]
        [XmlElement("b075")]
        public int[] AudienceRangePrecision { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum AudienceRangePrecisionEnum { AudienceRangePrecision, b075 }
        [XmlIgnore]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public AudienceRangePrecisionEnum[] AudienceRangePrecisionChoice;

        /// <summary>
        /// A value indicating an exact position within a range, or the upper or lower end of a range.
        /// </summary>
        [XmlChoiceIdentifier("AudienceRangeValueChoice")]
        [XmlElement("AudienceRangeValue")]
        [XmlElement("b076")]
        public string[] AudienceRangeValue { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum AudienceRangeValueEnum { AudienceRangeValue, b076 }
        [XmlIgnore]
        [DesignerSerializationVisibility (DesignerSerializationVisibility.Hidden)]
        public AudienceRangeValueEnum[] AudienceRangeValueChoice;

        #endregion

        #region Support Methods

        private string FindAudRangeValue(int pnRangeType, int pnPrecisionType)
        {
            string FoundRangeValue = "";

            if ((AudienceRangeQualifier == pnRangeType) && (AudienceRangePrecision != null))
            {
                int nFoundIndex = Array.IndexOf(AudienceRangePrecision, pnPrecisionType);

                if ((nFoundIndex >= 0) && (AudienceRangeValue != null) && (AudienceRangeValue.Length >= nFoundIndex))
                    FoundRangeValue = AudienceRangeValue[nFoundIndex];
            }

            return FoundRangeValue;
        }

        #endregion
    }
}
