using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using OnixData.Legacy.Lists;
using OnixData.Legacy.Xml.Enums;

namespace OnixData.Legacy
{
    /// <remarks/>
    [XmlType(AnonymousType = true)]
    public partial class OnixLegacySalesRights
    {
        #region CONSTANTS

        private const char CONST_LIST_DELIM = ' ';

        #endregion

        #region Helpers

        private string RightsCountries => string.Join(CONST_LIST_DELIM.ToString(), RightsCountry ?? new string[0]);
        private string RightsTerritories => string.Join(CONST_LIST_DELIM.ToString(), RightsTerritory ?? new string[0]);

        [XmlIgnore]
        public List<string> RightsCountryList => RightsCountries.Split(new char[] { CONST_LIST_DELIM }, StringSplitOptions.RemoveEmptyEntries).Distinct().OrderBy(s => s).ToList();
        [XmlIgnore]
        public List<string> RightsTerritoryList => RightsTerritories.Split(new char[] { CONST_LIST_DELIM }, StringSplitOptions.RemoveEmptyEntries).Distinct().OrderBy(s => s).ToList();
        [XmlIgnore]
        public List<string> FullRightsCountryList => Array.Exists(RightsTerritory ?? new string[0], s => s.Contains("WORLD") || s.Contains("ROW")) ? new List<string>() { "WORLD" } : (RightsCountries + CONST_LIST_DELIM.ToString() + RightsTerritories.Replace("WORLD", "").Replace("ROW", "").Replace("ECZ", "AT BE CY EE FI FR DE ES GR IE IT LT LU LV MT NL PT SI SK AD MC SM VA ME")).Split(new char[] { CONST_LIST_DELIM }, StringSplitOptions.RemoveEmptyEntries).Distinct().OrderBy(s => s).ToList();

        #endregion

        #region Reference Tags

        /// <remarks/>
        [XmlChoiceIdentifier("XmlChoiceSalesRightsType")]
        [XmlElement("SalesRightsType")]
        [XmlElement("b089")]
        public OnixList46 SalesRightsType { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum SalesRightsTypeEnum { SalesRightsType, b089 }
        [XmlIgnore]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public SalesRightsTypeEnum XmlChoiceSalesRightsType
        {
            get { return SerializationSettings.UseShortTags ? SalesRightsTypeEnum.b089 : SalesRightsTypeEnum.SalesRightsType; }
            set { }
        }

        /// <remarks/>
        [XmlChoiceIdentifier("XmlChoiceRightsCountry")]
        [XmlElement("RightsCountry")]
        [XmlElement("b090")]
        public string[] RightsCountry { get; set; }
        [XmlIgnore]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public RightsCountryEnum[] XmlChoiceRightsCountry
        {
            get
            {
                if (RightsCountry == null) return null;
                return SerializationHelper.CreateEnumArray(RightsCountryEnum.b090, RightsCountryEnum.RightsCountry, RightsCountry.Length);
            }
            set { }
        }

        /// <remarks/>
        [XmlChoiceIdentifier("XmlChoiceRightsTerritory")]
        [XmlElement("RightsTerritory")]
        [XmlElement("b388")]
        public string[] RightsTerritory { get; set; }
        [XmlIgnore]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public RightsTerritoryEnum[] XmlChoiceRightsTerritory
        {
            get
            {
                if (RightsTerritory == null) return null;
                return SerializationHelper.CreateEnumArray(RightsTerritoryEnum.b388, RightsTerritoryEnum.RightsTerritory, RightsTerritory.Length);
            }
            set { }
        }

        #endregion
    }

    /// <remarks/>
    [XmlType(AnonymousType = true)]
    public partial class OnixLegacyNotForSale
    {
        #region CONSTANTS

        private const char CONST_LIST_DELIM = ' ';

        #endregion

        #region Helpers

        public List<string> RightsCountryList => RightsCountry?.Split(new char[] { CONST_LIST_DELIM }, StringSplitOptions.RemoveEmptyEntries).ToList() ?? new List<string>();
        public List<string> RightsTerritoryList => RightsTerritory?.Split(new char[] { CONST_LIST_DELIM }, StringSplitOptions.RemoveEmptyEntries).ToList() ?? new List<string>();

        #endregion

        #region Reference Tags

        /// <remarks/>
        [XmlChoiceIdentifier("XmlChoiceRightsCountry")]
        [XmlElement("RightsCountry")]
        [XmlElement("b090")]
        public string RightsCountry { get; set; }
        [XmlIgnore]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public RightsCountryEnum XmlChoiceRightsCountry
        {
            get { return SerializationSettings.UseShortTags ? RightsCountryEnum.b090 : RightsCountryEnum.RightsCountry; }
            set { }
        }

        /// <remarks/>
        [XmlChoiceIdentifier("XmlChoiceRightsTerritory")]
        [XmlElement("RightsTerritory")]
        [XmlElement("b388")]
        public string RightsTerritory { get; set; }
        [XmlIgnore]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public RightsTerritoryEnum XmlChoiceRightsTerritory
        {
            get { return SerializationSettings.UseShortTags ? RightsTerritoryEnum.b388 : RightsTerritoryEnum.RightsTerritory; }
            set { }
        }

        #endregion
    }
}
