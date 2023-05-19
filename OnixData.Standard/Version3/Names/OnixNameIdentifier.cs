using System.ComponentModel;
using System.Xml.Serialization;

namespace OnixData.Version3.Names
{
    [XmlType(AnonymousType = true)]
    public partial class OnixNameIdentifier : OnixIdentifier
    {
        #region CONSTANTS

        public const int CONST_NAME_TYPE_ID_PROP     = 1;
        public const int CONST_NAME_TYPE_DEP         = 2;
        public const int CONST_NAME_TYPE_DNB         = 3;
        public const int CONST_NAME_TYPE_BV          = 4;
        public const int CONST_NAME_TYPE_GERMAN_ISBN = 5;
        public const int CONST_NAME_TYPE_GLN_GS1     = 6;
        public const int CONST_NAME_TYPE_SAN         = 7;
        public const int CONST_NAME_TYPE_MARC        = 8;
        public const int CONST_NAME_TYPE_CBR_ID      = 10;
        public const int CONST_NAME_TYPE_FB_ID       = 13;
        public const int CONST_NAME_TYPE_YT_BIC_ID   = 15;
        public const int CONST_NAME_TYPE_ISNI        = 16;
        public const int CONST_NAME_TYPE_PND         = 17;
        public const int CONST_NAME_TYPE_LCCN        = 18;
        public const int CONST_NAME_TYPE_JAPAN_PID   = 19;
        public const int CONST_NAME_TYPE_GKD         = 20;
        public const int CONST_NAME_TYPE_ORCID       = 21;
        public const int CONST_NAME_TYPE_GAPP_ID     = 22;
        public const int CONST_NAME_TYPE_VAT_ID      = 23;
        public const int CONST_NAME_TYPE_JP_DST_ID   = 24;
        public const int CONST_NAME_TYPE_GND         = 25;
        public const int CONST_NAME_TYPE_DUNS_ID     = 26;
        public const int CONST_NAME_TYPE_RINGGOLD_ID = 27;
        public const int CONST_NAME_TYPE_FRE_ELE_ID  = 28;
        public const int CONST_NAME_TYPE_EIDR_ID     = 29;
        public const int CONST_NAME_TYPE_IMEF_ID     = 30;
        public const int CONST_NAME_TYPE_VIAF_ID     = 31;
        public const int CONST_NAME_TYPE_FR_DOI      = 32;
        public const int CONST_NAME_TYPE_BNE_CN_ID   = 33;
        public const int CONST_NAME_TYPE_BNF_CN_ID   = 34;
        public const int CONST_NAME_TYPE_ARK_ID      = 35;
        public const int CONST_NAME_TYPE_NA_ID       = 36;
        public const int CONST_NAME_TYPE_GRID        = 37;

        #endregion

        #region ONIX Helpers

        public int NameIDTypeNum
        {
            get
            {
                int nNameIdTypeNum = 0;

                if (!string.IsNullOrEmpty(NameIDType))
                    int.TryParse(NameIDType, out nNameIdTypeNum);

                return nNameIdTypeNum;
            }
        }

        #endregion

        #region Reference Tags

        /// <summary>
        /// An ONIX code which identifies the scheme from which the value in the <see cref="IDValue"/> element is taken.
        /// Mandatory in each occurrence of the <see cref="OnixNameIdentifier"/> composite, and non-repeating.
        /// </summary>
        /// <remarks>Onix List 44</remarks>
        [XmlChoiceIdentifier("NameIDTypeChoice")]
        [XmlElement("NameIDType")]
        [XmlElement("x415")]
        public string NameIDType { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum NameIDTypeEnum { NameIDType, x415 }
        [XmlIgnore, DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public NameIDTypeEnum NameIDTypeChoice
        {
            get { return SerializationSettings.UseShortTags ? NameIDTypeEnum.x415 : NameIDTypeEnum.NameIDType; }
            set { }
        }

        #endregion

    }
}