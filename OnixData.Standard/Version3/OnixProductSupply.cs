using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Xml.Serialization;

using OnixData.Version3.Market;
using OnixData.Version3.Supply;

namespace OnixData.Version3
{
    /// <remarks/>
    [XmlType(AnonymousType = true)]
    public partial class OnixProductSupply
    {
        #region Helper Methods

        public OnixSupplyDetail GetSupplyDetailWithUSDPrice(bool pbCheckHasReturnCodeTypeBisac = false)
        {
            OnixSupplyDetail USDSupplyDetail = new OnixSupplyDetail();

            foreach (OnixSupplyDetail TmpSupplyDetail in SupplyDetail)
            {
                if (pbCheckHasReturnCodeTypeBisac)
                {
                    if (TmpSupplyDetail.HasUSDPrice() && TmpSupplyDetail.HasReturnCodeTypeBisac())
                    {
                        USDSupplyDetail = TmpSupplyDetail;
                        break;
                    }
                }
                else if (TmpSupplyDetail.HasUSDPrice())
                {
                    USDSupplyDetail = TmpSupplyDetail;
                    break;
                }
            }

            return USDSupplyDetail;
        }

        #endregion

        #region Reference Tags

        /// <remarks/>
        [XmlChoiceIdentifier("XmlChoiceMarket")]
        [XmlElement("Market")]
        [XmlElement("market")]
        public OnixMarket[] Market { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum MarketEnum { Market, market }
        [XmlIgnore]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public MarketEnum[] XmlChoiceMarket
        {
            get
            {
                if (Market == null) return null;
                return SerializationHelper.CreateEnumArray(MarketEnum.market, MarketEnum.Market, Market.Length);
            }
            set { }
        }

        /// <remarks/>
        [XmlChoiceIdentifier("XmlChoiceMarketPublishingDetail")]
        [XmlElement("MarketPublishingDetail")]
        [XmlElement("marketpublishingdetail")]
        public OnixMarketPublishingDetail MarketPublishingDetail { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum MarketPublishingDetailEnum { MarketPublishingDetail, marketpublishingdetail }
        [XmlIgnore]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public MarketPublishingDetailEnum XmlChoiceMarketPublishingDetail
        {
            get { return SerializationSettings.UseShortTags ? MarketPublishingDetailEnum.marketpublishingdetail : MarketPublishingDetailEnum.MarketPublishingDetail; }
            set { }
        }

        /// <remarks/>
        [XmlChoiceIdentifier("XmlChoiceSupplyDetail")]
        [XmlElement("SupplyDetail")]
        [XmlElement("supplydetail")]
        public OnixSupplyDetail[] SupplyDetail { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum SupplyDetailEnum { SupplyDetail, supplydetail }
        [XmlIgnore]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public SupplyDetailEnum[] XmlChoiceSupplyDetail
        {
            get
            {
                if (SupplyDetail == null) return null;
                return SerializationHelper.CreateEnumArray(SupplyDetailEnum.supplydetail, SupplyDetailEnum.SupplyDetail, SupplyDetail.Length);
            }
            set { }
        }

        #endregion
    }
}
