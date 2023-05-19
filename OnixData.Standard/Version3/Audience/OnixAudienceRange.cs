using System;
using System.ComponentModel;
using System.Xml.Serialization;

namespace OnixData.Version3.Audience
{
    /// <remarks/>
    [XmlType(AnonymousType = true)]
    public partial class OnixAudienceRange
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

        #region ONIX Helper Methods

        public string USAgeFrom
        {
            get
            {
                string FoundAgeFrom = FindAudRangeValue(CONST_AUD_RANGE_TYPE_INTEREST_AGE, CONST_AUD_RANGE_PRCN_FROM);
                if (string.IsNullOrEmpty(FoundAgeFrom))
                    FoundAgeFrom = FindAudRangeValue(CONST_AUD_RANGE_TYPE_READING_AGE, CONST_AUD_RANGE_PRCN_FROM);

                return FoundAgeFrom;
            }
        }

        public string USAgeTo
        {
            get
            {
                string FoundAgeTo = FindAudRangeValue(CONST_AUD_RANGE_TYPE_INTEREST_AGE, CONST_AUD_RANGE_PRCN_TO);
                if (string.IsNullOrEmpty(FoundAgeTo))
                    FoundAgeTo = FindAudRangeValue(CONST_AUD_RANGE_TYPE_READING_AGE, CONST_AUD_RANGE_PRCN_TO);

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
        /// Mandatory in each occurrence of the <see cref="OnixAudienceRange"/> composite, and non-repeating.
        /// </summary>
        /// <remarks>Onix List 30</remarks>
        [XmlChoiceIdentifier("AudienceRangeQualifierChoice")]
        [XmlElement("AudienceRangeQualifier")]
        [XmlElement("b074")]
        public int AudienceRangeQualifier { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum AudienceRangeQualifierEnum { AudienceRangeQualifier, b074 }
        [XmlIgnore, DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public AudienceRangeQualifierEnum AudienceRangeQualifierChoice
        {
            get { return SerializationSettings.UseShortTags ? AudienceRangeQualifierEnum.b074 : AudienceRangeQualifierEnum.AudienceRangeQualifier; }
            set { }
        }

        /// <summary>
        /// An ONIX code specifying the ‘precision’ of the value in the <see cref="AudienceRangeValue"/> element which follows (from, to, exact).
        /// Mandatory in each occurrence of the <see cref="OnixAudienceRange"/> composite, and repeated when a 'from ... to '...' range is specified.
        /// </summary>
        /// <remarks>Onix List 31</remarks>
        [XmlChoiceIdentifier("AudienceRangePrecisionChoice")]
        [XmlElement("AudienceRangePrecision")]
        [XmlElement("b075")]
        public int[] AudienceRangePrecision { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum AudienceRangePrecisionEnum { AudienceRangePrecision, b075 }
        [XmlIgnore, DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public AudienceRangePrecisionEnum[] AudienceRangePrecisionChoice
        {
            get
            {
                if (AudienceRangePrecision == null) return null;
                AudienceRangePrecisionEnum choice = SerializationSettings.UseShortTags ? AudienceRangePrecisionEnum.b075 : AudienceRangePrecisionEnum.AudienceRangePrecision;
                AudienceRangePrecisionEnum[] result = new AudienceRangePrecisionEnum[AudienceRangePrecision.Length];
                for (int i = 0; i < AudienceRangePrecision.Length; i++) result[i] = choice;
                return result;
            }
            set { }
        }

        /// <summary>
        /// A value indicating an exact position within a range, or the upper or lower end of a range.
        /// </summary>
        [XmlChoiceIdentifier("AudienceRangeValueChoice")]
        [XmlElement("AudienceRangeValue")]
        [XmlElement("b076")]
        public string[] AudienceRangeValue { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum AudienceRangeValueEnum { AudienceRangeValue, b076 }
        [XmlIgnore, DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public AudienceRangeValueEnum[] AudienceRangeValueChoice
        {
            get
            {
                if (AudienceRangeValue == null) return null;
                AudienceRangeValueEnum choice = SerializationSettings.UseShortTags ? AudienceRangeValueEnum.b076 : AudienceRangeValueEnum.AudienceRangeValue;
                AudienceRangeValueEnum[] result = new AudienceRangeValueEnum[AudienceRangeValue.Length];
                for (int i = 0; i < AudienceRangeValue.Length; i++) result[i] = choice;
                return result;

            }
            set { }
        }

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
