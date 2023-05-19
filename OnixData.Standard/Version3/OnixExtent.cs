using System.ComponentModel;
using System.Linq;
using System.Xml.Serialization;

namespace OnixData.Version3
{
    /// <remarks/>
    [XmlType(AnonymousType = true)]
    public partial class OnixExtent
    {
        #region CONSTANTS

        public const int CONST_EXT_TYPE_MAIN_PPG_CNT = 0;
        public const int CONST_EXT_TYPE_WORD_NUM     = 2;
        public const int CONST_EXT_TYPE_FT_PG_CNT    = 3;
        public const int CONST_EXT_TYPE_BK_PG_CT     = 4;
        public const int CONST_EXT_TYPE_TOTAL_PG_CT  = 5;
        public const int CONST_EXT_TYPE_PROD_PG_CT   = 6;
        public const int CONST_EXT_TYPE_ABS_PG_CT    = 7;
        public const int CONST_EXT_TYPE_PT_CRT_PG_CT = 8;
        public const int CONST_EXT_TYPE_DUR_TIME     = 9;
        public const int CONST_EXT_TYPE_PG_CT_DG_PRD = 10;
        public const int CONST_EXT_TYPE_CNT_PG_CT    = 11;
        public const int CONST_EXT_TYPE_FILESIZE     = 22;

        public const int CONST_UNIT_TYPE_WORDS   = 2;
        public const int CONST_UNIT_TYPE_PAGES   = 3;
        public const int CONST_UNIT_TYPE_HOURS   = 4;
        public const int CONST_UNIT_TYPE_MINUTES = 5;
        public const int CONST_UNIT_TYPE_SECONDS = 6;
        public const int CONST_UNIT_TYPE_BYTES   = 17;
        public const int CONST_UNIT_TYPE_KBYTES  = 18;
        public const int CONST_UNIT_TYPE_MBYTES  = 19;

        public readonly int[] CONST_SOUGHT_PAGE_COUNT_TYPES
            = {
                CONST_EXT_TYPE_MAIN_PPG_CNT, CONST_EXT_TYPE_TOTAL_PG_CT, CONST_EXT_TYPE_PROD_PG_CT,
                CONST_EXT_TYPE_ABS_PG_CT, CONST_EXT_TYPE_PT_CRT_PG_CT, CONST_EXT_TYPE_PG_CT_DG_PRD,
                CONST_EXT_TYPE_CNT_PG_CT
              };

        public readonly int[] CONST_SOUGHT_EXTENT_TYPES
            = {
                CONST_EXT_TYPE_WORD_NUM, CONST_EXT_TYPE_DUR_TIME,
                CONST_EXT_TYPE_FILESIZE
              };

        #endregion

        #region Helper Methods

        public bool HasSoughtPageCountType()
        {
            return CONST_SOUGHT_PAGE_COUNT_TYPES.Contains(this.ExtentType);
        }

        public bool HasSoughtExtentTypeCode()
        {
            return CONST_SOUGHT_EXTENT_TYPES.Contains(this.ExtentType);
        }

        public int ExtentValueNum
        {
            get
            {
                int nExtValue = -1;

                int.TryParse(ExtentValue.ToString(), out nExtValue);

                return nExtValue;
            }
        }

        #endregion

        #region Reference Tags

        /// <summary>
        /// An ONIX code which identifies the type of extent carried in the composite, eg running time for an audio or video product.
        /// Mandatory in each occurrence of the <see cref="OnixExtent"/> composite, and non-repeating.
        /// </summary>
        /// <remarks>Onix List 23</remarks>
        [XmlChoiceIdentifier("ExtentTypeChoice")]
        [XmlElement("ExtentType")]
        [XmlElement("b218")]
        public int ExtentType { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum ExtentTypeEnum { ExtentType, b218 }
        [XmlIgnore, DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ExtentTypeEnum ExtentTypeChoice
        {
            get { return SerializationSettings.UseShortTags ? ExtentTypeEnum.b218 : ExtentTypeEnum.ExtentType; }
            set { }
        }

        /// <summary>
        /// The numeric value of the extent specified in <see cref="ExtentType"/>.
        /// Optional, and non-repeating.
        /// However, either <see cref="ExtentValue"/> or <see cref="ExtentValueRoman"/>, or both, must be present in each occurrence of the <see cref="OnixExtent"/> composite;
        /// and it is very strongly recommended that <see cref="ExtentValue"/> should always be included, even when the original product uses Roman numerals.
        /// </summary>
        [XmlChoiceIdentifier("ExtentValueChoice")]
        [XmlElement("ExtentValue")]
        [XmlElement("b219")]
        public decimal ExtentValue { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum ExtentValueEnum { ExtentValue, b219 }
        [XmlIgnore, DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ExtentValueEnum ExtentValueChoice
        {
            get { return SerializationSettings.UseShortTags ? ExtentValueEnum.b219 : ExtentValueEnum.ExtentValue; }
            set { }
        }

        /// <summary>
        /// The value of the extent expressed in Roman numerals.
        /// Optional, and non-repeating.
        /// Used only for page runs which are numbered in Roman.
        /// </summary>
        [XmlChoiceIdentifier("ExtentValueRomanChoice")]
        [XmlElement("ExtentValueRoman")]
        [XmlElement("x421")]
        public string ExtentValueRoman { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum ExtentValueRomanEnum { ExtentValueRoman, x421 }
        [XmlIgnore, DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ExtentValueRomanEnum ExtentValueRomanChoice
        {
            get { return SerializationSettings.UseShortTags ? ExtentValueRomanEnum.x421 : ExtentValueRomanEnum.ExtentValueRoman; }
            set { }
        }

        /// <summary>
        /// An ONIX code indicating the unit used for the <see cref="ExtentValue"/> and the format in which the value is presented.
        /// Mandatory in each occurrence of the <see cref="OnixExtent"/> composite, and non-repeating.
        /// </summary>
        /// <remarks>Onix List 24</remarks>
        [XmlChoiceIdentifier("ExtentUnitChoice")]
        [XmlElement("ExtentUnit")]
        [XmlElement("b220")]
        public int ExtentUnit { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum ExtentUnitEnum {  ExtentUnit, b220 }
        [XmlIgnore, DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ExtentUnitEnum ExtentUnitChoice
        {
            get { return SerializationSettings.UseShortTags ? ExtentUnitEnum.b220 : ExtentUnitEnum.ExtentUnit; }
            set { }
        }

        #endregion
    }
}
