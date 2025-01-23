using System;
using System.ComponentModel;
using System.Linq;
using System.Xml.Serialization;

namespace OnixData.Legacy
{
    /// <remarks/>
    [XmlType(AnonymousType = true)]
    public partial class OnixLegacyPrice
    {
        #region CONSTANTS

        public const int CONST_PUB_DISC_CD_TYPE_PTY   = 2;
        public const int CONST_PUB_DISC_CD_TYPE_PTY_2 = 5;

        public readonly Lists.OnixList58[] CONST_SOUGHT_RETAIL_PRICE_TYPES
            = {
                Lists.OnixList58.RrpExcludingTax, Lists.OnixList58.PrePublicationRrpExcludingTax,
                Lists.OnixList58.FreightPassThroughBillingPriceExcludingTax, Lists.OnixList58.PublishersRetailPriceExcludingTax
              };

        public readonly Lists.OnixList58[] CONST_SOUGHT_SUPP_COST_PRICE_TYPES
            = {
                Lists.OnixList58.SuppliersNetPriceExcludingTax
              };

        public readonly Lists.OnixList58[] CONST_SOUGHT_PRICE_TYPES 
            = {
                Lists.OnixList58.RrpExcludingTax, Lists.OnixList58.SuppliersNetPriceExcludingTax, Lists.OnixList58.PrePublicationRrpExcludingTax,
                Lists.OnixList58.FreightPassThroughRrpExcludingTax, Lists.OnixList58.FreightPassThroughBillingPriceExcludingTax,
                Lists.OnixList58.PublishersRetailPriceExcludingTax
              };

        #endregion

        #region ONIX helpers

        public bool HasSoughtRetailPriceType()
        {
            if (this.PriceTypeCode == null)
                return false;
            return CONST_SOUGHT_RETAIL_PRICE_TYPES.Contains(this.PriceTypeCode.Value);
        }

        public bool HasSoughtSupplyCostPriceType()
        {
            if (this.PriceTypeCode == null)
                return false;
            return CONST_SOUGHT_SUPP_COST_PRICE_TYPES.Contains(this.PriceTypeCode.Value);
        }

        public bool HasSoughtPriceTypeCode()
        {
            if (this.PriceTypeCode == null)
                return false;
            return CONST_SOUGHT_PRICE_TYPES.Contains(this.PriceTypeCode.Value);
        }

        public bool HasViablePubDiscountCode()
        {
            return (OnixFirstViableDiscountCoded != null);
        }

        public OnixLegacyDiscountCoded OnixFirstViableDiscountCoded
        {
            get
            {
                OnixLegacyDiscountCoded ViableDiscountCoded = null;

                if ((this.DiscountCoded != null) && (this.DiscountCoded.Length > 0))
                {
                    OnixLegacyDiscountCoded DiscountCodedCandidate =
                        DiscountCoded.Where(x => (x.DiscountCodeType == CONST_PUB_DISC_CD_TYPE_PTY) || (x.DiscountCodeType == CONST_PUB_DISC_CD_TYPE_PTY_2)).FirstOrDefault();

                    if ((DiscountCodedCandidate != null) && !String.IsNullOrEmpty(DiscountCodedCandidate.DiscountCode))
                        ViableDiscountCoded = DiscountCodedCandidate;
                }

                return ViableDiscountCoded;
            }
        }

        public decimal PriceExcludingTax
        {
            get
            {
                decimal TaxAmount = 0;
                if (TaxAmount1 != null)
                    TaxAmount += TaxAmount1.Value;
                else if (TaxableAmount1 != null && TaxRatePercent1 != null)
                    TaxAmount += Math.Round(TaxableAmount1.Value * (TaxRatePercent1.Value / 100), 2, MidpointRounding.AwayFromZero);

                if (TaxAmount2 != null)
                    TaxAmount += TaxAmount2.Value;
                else if (TaxableAmount2 != null && TaxRatePercent2 != null)
                    TaxAmount += Math.Round(TaxableAmount2.Value * (TaxRatePercent2.Value / 100), 2, MidpointRounding.AwayFromZero);
                
                return PriceAmount - TaxAmount;
            }
        }

        #endregion

        #region Reference Tags

        [XmlChoiceIdentifier("PriceTypeCodeChoice")]
        [XmlElement("PriceTypeCode")]
        [XmlElement("j148")]
        public Lists.OnixList58? PriceTypeCode { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum PriceTypeCodeEnum { PriceTypeCode, j148 };
        [XmlIgnore]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public PriceTypeCodeEnum PriceTypeCodeChoice
        {
            get { return SerializationSettings.UseShortTags ? PriceTypeCodeEnum.j148 : PriceTypeCodeEnum.PriceTypeCode; }
            set { }
        }

        [XmlChoiceIdentifier("PriceQualifierChoice")]
        [XmlElement("PriceQualifier")]
        [XmlElement("j261")]
        public Lists.OnixList59? PriceQualifier { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum PriceQualifierEnum { PriceQualifier, j261 };
        [XmlIgnore]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public PriceQualifierEnum PriceQualifierChoice
        {
            get { return SerializationSettings.UseShortTags ? PriceQualifierEnum.j261 : PriceQualifierEnum.PriceQualifier; }
            set { }
        }

        [XmlChoiceIdentifier("PriceTypeDescriptionChoice")]
        [XmlElement("PriceTypeDescription")]
        [XmlElement("j262")]
        public string PriceTypeDescription { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum PriceTypeDescriptionEnum { PriceTypeDescription, j262 };
        [XmlIgnore]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public PriceTypeDescriptionEnum PriceTypeDescriptionChoice
        {
            get { return SerializationSettings.UseShortTags ? PriceTypeDescriptionEnum.j262 : PriceTypeDescriptionEnum.PriceTypeDescription; }
            set { }
        }

        [XmlChoiceIdentifier("PricePerChoice")]
        [XmlElement("PricePer")]
        [XmlElement("j239")]
        public Lists.OnixList60? PricePer { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum PricePerEnum { PricePer, j239 };
        [XmlIgnore]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public PricePerEnum PricePerChoice
        {
            get { return SerializationSettings.UseShortTags ? PricePerEnum.j239 : PricePerEnum.PricePer; }
            set { }
        }

        [XmlChoiceIdentifier("MinimumOrderQuantityChoice")]
        [XmlElement("MinimumOrderQuantity")]
        [XmlElement("j263")]
        public int? MinimumOrderQuantity { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum MinimumOrderQuantityEnum { MinimumOrderQuantity, j263 };
        [XmlIgnore]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public MinimumOrderQuantityEnum MinimumOrderQuantityChoice
        {
            get { return SerializationSettings.UseShortTags ? MinimumOrderQuantityEnum.j263 : MinimumOrderQuantityEnum.MinimumOrderQuantity; }
            set { }
        }

        [XmlChoiceIdentifier("BatchBonusChoice")]
        [XmlElement("BatchBonus")]
        [XmlElement("batchbonus")]
        public OnixLegacyBatchBonus[] BatchBonus { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum BatchBonusEnum { BatchBonus, batchbonus };
        [XmlIgnore]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public BatchBonusEnum[] BatchBonusChoice
        {
            get
            {
              if (BatchBonus == null) return null;
              BatchBonusEnum choice = SerializationSettings.UseShortTags ? BatchBonusEnum.batchbonus : BatchBonusEnum.BatchBonus;
              BatchBonusEnum[] result = new BatchBonusEnum[BatchBonus.Length];
              for (int i = 0; i < BatchBonus.Length; i++) result[i] = choice;
              return result;
            }
            set { }
        }

        [XmlChoiceIdentifier("ClassOfTradeChoice")]
        [XmlElement("ClassOfTrade")]
        [XmlElement("j149")]
        public string ClassOfTrade { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum ClassOfTradeEnum { ClassOfTrade, j149 };
        [XmlIgnore]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ClassOfTradeEnum ClassOfTradeChoice
        {
            get { return SerializationSettings.UseShortTags ? ClassOfTradeEnum.j149 : ClassOfTradeEnum.ClassOfTrade; }
            set { }
        }

        [XmlChoiceIdentifier("BICDiscountGroupCodeChoice")]
        [XmlElement("BICDiscountGroupCode")]
        [XmlElement("j150")]
        public string BICDiscountGroupCode { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum BICDiscountGroupCodeEnum { BICDiscountGroupCode, j150 };
        [XmlIgnore]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public BICDiscountGroupCodeEnum BICDiscountGroupCodeChoice
        {
            get { return SerializationSettings.UseShortTags ? BICDiscountGroupCodeEnum.j150 : BICDiscountGroupCodeEnum.BICDiscountGroupCode; }
            set { }
        }

        [XmlChoiceIdentifier("DiscountCodedChoice")]
        [XmlElement("DiscountCoded")]
        [XmlElement("discountcoded")]
        public OnixLegacyDiscountCoded[] DiscountCoded { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum DiscountCodedEnum { DiscountCoded, discountcoded };
        [XmlIgnore]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public DiscountCodedEnum[] DiscountCodedChoice
        {
            get
            {
                if (DiscountCoded == null) return null;
                DiscountCodedEnum choice = SerializationSettings.UseShortTags ? DiscountCodedEnum.discountcoded : DiscountCodedEnum.DiscountCoded;
                DiscountCodedEnum[] result = new DiscountCodedEnum[DiscountCoded.Length];
                for (int i = 0; i < DiscountCoded.Length; i++) result[i] = choice;
                return result;
            }
            set { }
        }

        [XmlChoiceIdentifier("DiscountPercentChoice")]
        [XmlElement("DiscountPercent")]
        [XmlElement("j267")]
        public float? DiscountPercent { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum DiscountPercentEnum { DiscountPercent, j267 };
        [XmlIgnore]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public DiscountPercentEnum DiscountPercentChoice
        {
            get { return SerializationSettings.UseShortTags ? DiscountPercentEnum.j267 : DiscountPercentEnum.DiscountPercent; }
            set { }
        }

        [XmlChoiceIdentifier("PriceStatusChoice")]
        [XmlElement("PriceStatus")]
        [XmlElement("j266")]
        public Lists.OnixList61? PriceStatus { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum PriceStatusEnum { PriceStatus, j266 };
        [XmlIgnore]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public PriceStatusEnum PriceStatusChoice
        {
            get { return SerializationSettings.UseShortTags ? PriceStatusEnum.j266 : PriceStatusEnum.PriceStatus; }
            set { }
        }

        [XmlChoiceIdentifier("PriceAmountChoice")]
        [XmlElement("PriceAmount")]
        [XmlElement("j151")]
        public decimal PriceAmount { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum PriceAmountEnum { PriceAmount, j151 };
        [XmlIgnore]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public PriceAmountEnum PriceAmountChoice
        {
            get { return SerializationSettings.UseShortTags ? PriceAmountEnum.j151 : PriceAmountEnum.PriceAmount; }
            set { }
        }

        [XmlChoiceIdentifier("CurrencyCodeChoice")]
        [XmlElement("CurrencyCode")]
        [XmlElement("j152")]
        public string CurrencyCode { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum CurrencyCodeEnum { CurrencyCode, j152 };
        [XmlIgnore]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public CurrencyCodeEnum CurrencyCodeChoice
        {
            get { return SerializationSettings.UseShortTags ? CurrencyCodeEnum.j152 : CurrencyCodeEnum.CurrencyCode; }
            set { }
        }

        [XmlChoiceIdentifier("CountryCodeChoice")]
        [XmlElement("CountryCode")]
        [XmlElement("b251")]
        public string CountryCode { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum CountryCodeEnum { CountryCode, b251 };
        [XmlIgnore]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public CountryCodeEnum CountryCodeChoice
        {
            get { return SerializationSettings.UseShortTags ? CountryCodeEnum.b251 : CountryCodeEnum.CountryCode; }
            set { }
        }

        [XmlChoiceIdentifier("TerritoryChoice")]
        [XmlElement("Territory")]
        [XmlElement("j303")]
        public string Territory { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum TerritoryEnum { Territory, j303 };
        [XmlIgnore]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public TerritoryEnum TerritoryChoice
        {
            get { return SerializationSettings.UseShortTags ? TerritoryEnum.j303 : TerritoryEnum.Territory; }
            set { }
        }

        [XmlChoiceIdentifier("CountryExcludedChoice")]
        [XmlElement("CountryExcluded")]
        [XmlElement("j304")]
        public string CountryExcluded { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum CountryExcludedEnum { CountryExcluded, j304 };
        [XmlIgnore]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public CountryExcludedEnum CountryExcludedChoice
        {
            get { return SerializationSettings.UseShortTags ? CountryExcludedEnum.j304 : CountryExcludedEnum.CountryExcluded; }
            set { }
        }

        [XmlChoiceIdentifier("TerritoryExcludedChoice")]
        [XmlElement("TerritoryExcluded")]
        [XmlElement("j308")]
        public string TerritoryExcluded { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum TerritoryExcludedEnum { TerritoryExcluded, j308 };
        [XmlIgnore]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public TerritoryExcludedEnum TerritoryExcludedChoice
        {
            get { return SerializationSettings.UseShortTags ? TerritoryExcludedEnum.j308 : TerritoryExcludedEnum.TerritoryExcluded; }
            set { }
        }

        [XmlChoiceIdentifier("TaxRateCode1Choice")]
        [XmlElement("TaxRateCode1")]
        [XmlElement("j153")]
        public Lists.OnixList62? TaxRateCode1 { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum TaxRateCode1Enum { TaxRateCode1, j153 };
        [XmlIgnore]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public TaxRateCode1Enum TaxRateCode1Choice
        {
            get { return SerializationSettings.UseShortTags ? TaxRateCode1Enum.j153 : TaxRateCode1Enum.TaxRateCode1; }
            set { }
        }

        [XmlChoiceIdentifier("TaxRatePercent1Choice")]
        [XmlElement("TaxRatePercent1")]
        [XmlElement("j154")]
        public decimal? TaxRatePercent1 { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum TaxRatePercent1Enum { TaxRatePercent1, j154 };
        [XmlIgnore]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public TaxRatePercent1Enum TaxRatePercent1Choice
        {
            get { return SerializationSettings.UseShortTags ? TaxRatePercent1Enum.j154 : TaxRatePercent1Enum.TaxRatePercent1; }
            set { }
        }

        [XmlChoiceIdentifier("TaxableAmount1Choice")]
        [XmlElement("TaxableAmount1")]
        [XmlElement("j155")]
        public decimal? TaxableAmount1 { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum TaxableAmount1Enum { TaxableAmount1, j155 };
        [XmlIgnore]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public TaxableAmount1Enum TaxableAmount1Choice
        {
            get { return SerializationSettings.UseShortTags ? TaxableAmount1Enum.j155 : TaxableAmount1Enum.TaxableAmount1; }
            set { }
        }

        [XmlChoiceIdentifier("TaxAmount1Choice")]
        [XmlElement("TaxAmount1")]
        [XmlElement("j156")]
        public decimal? TaxAmount1 { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum TaxAmount1Enum { TaxAmount1, j156 };
        [XmlIgnore]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public TaxAmount1Enum TaxAmount1Choice
        {
            get { return SerializationSettings.UseShortTags ? TaxAmount1Enum.j156 : TaxAmount1Enum.TaxAmount1; }
            set { }
        }

        [XmlChoiceIdentifier("TaxRateCode2Choice")]
        [XmlElement("TaxRateCode2")]
        [XmlElement("j157")]
        public Lists.OnixList62? TaxRateCode2 { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum TaxRateCode2Enum { TaxRateCode2, j157 };
        [XmlIgnore]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public TaxRateCode2Enum TaxRateCode2Choice
        {
            get { return SerializationSettings.UseShortTags ? TaxRateCode2Enum.j157 : TaxRateCode2Enum.TaxRateCode2; }
            set { }
        }

        [XmlChoiceIdentifier("TaxRatePercent2Choice")]
        [XmlElement("TaxRatePercent2")]
        [XmlElement("j158")]
        public decimal? TaxRatePercent2 { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum TaxRatePercent2Enum { TaxRatePercent2, j158 };
        [XmlIgnore]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public TaxRatePercent2Enum TaxRatePercent2Choice
        {
            get { return SerializationSettings.UseShortTags ? TaxRatePercent2Enum.j158 : TaxRatePercent2Enum.TaxRatePercent2; }
            set { }
        }

        [XmlChoiceIdentifier("TaxableAmount2Choice")]
        [XmlElement("TaxableAmount2")]
        [XmlElement("j159")]
        public decimal? TaxableAmount2 { get; set; }

        [XmlType(IncludeInSchema = false)]
        public enum TaxableAmount2Enum { TaxableAmount2, j159 };
        [XmlIgnore]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public TaxableAmount2Enum TaxableAmount2Choice
        {
            get { return SerializationSettings.UseShortTags ? TaxableAmount2Enum.j159 : TaxableAmount2Enum.TaxableAmount2; }
            set { }
        }

        [XmlChoiceIdentifier("TaxAmount2Choice")]
        [XmlElement("TaxAmount2")]
        [XmlElement("j160")]
        public decimal? TaxAmount2 { get; set; }

        [XmlType(IncludeInSchema = false)]
        public enum TaxAmount2Enum { TaxAmount2, j160 };
        [XmlIgnore]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public TaxAmount2Enum TaxAmount2Choice
        {
            get { return SerializationSettings.UseShortTags ? TaxAmount2Enum.j160 : TaxAmount2Enum.TaxAmount2; }
            set { }
        }

        [XmlChoiceIdentifier("PriceEffectiveFromChoice")]
        [XmlElement("PriceEffectiveFrom")]
        [XmlElement("j161")]
        public string PriceEffectiveFrom { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum PriceEffectiveFromEnum { PriceEffectiveFrom, j161 };
        [XmlIgnore]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public PriceEffectiveFromEnum PriceEffectiveFromChoice
        {
            get { return SerializationSettings.UseShortTags ? PriceEffectiveFromEnum.j161 : PriceEffectiveFromEnum.PriceEffectiveFrom; }
            set { }
        }

        [XmlChoiceIdentifier("PriceEffectiveUntilChoice")]
        [XmlElement("PriceEffectiveUntil")]
        [XmlElement("j162")]
        public string PriceEffectiveUntil { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum PriceEffectiveUntilEnum { PriceEffectiveUntil, j162 };
        [XmlIgnore]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public PriceEffectiveUntilEnum PriceEffectiveUntilChoice
        {
            get { return SerializationSettings.UseShortTags ? PriceEffectiveUntilEnum.j162 : PriceEffectiveUntilEnum.PriceEffectiveUntil; }
            set { }
        }

        #endregion

    }
}
