using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Xml.Serialization;
using OnixData.Version3.Lists;
using OnixData.Version3.Xml.Enums;

namespace OnixData.Version3.Publishing
{
    /// <remarks/>
    [XmlType(AnonymousType = true)]
    public class OnixSalesRights
    {
        #region CONSTANTS

        [XmlIgnore]
        public const char CONST_LIST_DELIM = ' ';

        [XmlIgnore]
        public static readonly OnixList46[] SALES_WITH_RIGHTS_COLL = {
            OnixList46.ForSaleWithExclusiveRights,
            OnixList46.ForSaleWithNonExclusiveRights,
            OnixList46.ForSaleWithExclusiveRightsRistrictionApplies,
            OnixList46.ForSaleWithNonExclusiveRightsRistrictionApplies
        };

        [XmlIgnore]
        public static readonly OnixList46[] NO_SALES_RIGHTS_COLL = {
            OnixList46.NotForSale,
            OnixList46.NotForSalePublisherHoldsExclusiveRights,
            OnixList46.NotForSalePublisherHoldsNonExclusiveRights,
            OnixList46.NotForSalePublisherDoesNotHoldRights
        };

        #endregion

        #region Helper Methods

        [XmlIgnore]
        public bool HasSalesRights => SALES_WITH_RIGHTS_COLL.Contains(SalesRightsType);
        [XmlIgnore]
        public bool HasNotForSalesRights => NO_SALES_RIGHTS_COLL.Contains(SalesRightsType);

        [XmlIgnore]
        public List<string> RightsExcludedCountryList => Territory.CountriesExcluded?.Split(CONST_LIST_DELIM).ToList() ?? new List<string>();
        [XmlIgnore]
        public List<string> RightsExcludedRegionList => Territory.RegionsExcluded?.Split(CONST_LIST_DELIM).ToList() ?? new List<string>();
        [XmlIgnore]
        public List<string> RightsIncludedCountryList => Territory.CountriesIncluded?.Split(CONST_LIST_DELIM).ToList() ?? new List<string>();
        [XmlIgnore]
        public List<string> RightsIncludedRegionList => Territory.RegionsIncluded?.Split(CONST_LIST_DELIM).ToList() ?? new List<string>();
        [XmlIgnore]
        public List<string> FullRightsCountryList => (Territory.RegionsIncluded ?? "").Contains("WORLD") ? new List<string>(){ "WORLD" } : ((Territory.CountriesIncluded ?? "") + CONST_LIST_DELIM.ToString() + (Territory.RegionsIncluded ?? "").Replace("ECZ", "AT BE CY EE FI FR DE ES GR IE IT LT LU LV MT NL PT SI SK AD MC SM VA ME")).Split(new char[] { CONST_LIST_DELIM }, System.StringSplitOptions.RemoveEmptyEntries).Select(s => s.Substring(0, 2)).Distinct().OrderBy(s => s).ToList();

        #endregion

        #region Reference Tags

        [XmlChoiceIdentifier("SalesRightsTypeChoice")]
        [XmlElement("SalesRightsType")]
        [XmlElement("b089")]
        public OnixList46 SalesRightsType { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum SalesRightsTypeEnum { SalesRightsType, b089 }
        [XmlIgnore]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public SalesRightsTypeEnum SalesRightsTypeChoice
        {
            get { return SerializationSettings.UseShortTags ? SalesRightsTypeEnum.b089 : SalesRightsTypeEnum.SalesRightsType; }
            set { }
        }

        [XmlChoiceIdentifier("TerritoryChoice")]
        [XmlElement("Territory")]
        [XmlElement("territory")]
        public OnixTerritory Territory { get; set; }
        [XmlIgnore]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public TerritoryEnum TerritoryChoice
        {
            get { return SerializationSettings.UseShortTags ? TerritoryEnum.territory : TerritoryEnum.Territory; }
            set { }
        }

        #endregion
    }
}
