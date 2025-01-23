using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Xml.Serialization;
using OnixData.Version3.Lists;
using OnixData.Version3.Xml.Enums;

using OnixData.Version3.Publishing;

namespace OnixData.Version3.Price
{
    /// <remarks/>
    [XmlType(AnonymousType = true)]
    public partial class OnixPrice
    {
        #region CONSTANTS

        public const int CONST_PRICE_TYPE_RRP_EXCL = 1;
        public const int CONST_PRICE_TYPE_RRP_INCL = 2;
        public const int CONST_PRICE_TYPE_FRP_EXCL = 3;
        public const int CONST_PRICE_TYPE_FRP_INCL = 4;
        public const int CONST_PRICE_TYPE_SUPP_COST = 5;
        public const int CONST_PRICE_TYPE_RRP_PREP = 21;
        public const int CONST_PRICE_TYPE_FPT_RRP_EXCL_TAX = 31;
        public const int CONST_PRICE_TYPE_FPT_BIL_EXCL_TAX = 32;
        public const int CONST_PRICE_TYPE_PROP_MISC_1 = 41;
        public const int CONST_PRICE_TYPE_PROP_MISC_2 = 99;

        public readonly int[] CONST_SOUGHT_RETAIL_PRICE_TYPES
            = {
                CONST_PRICE_TYPE_RRP_EXCL, CONST_PRICE_TYPE_RRP_PREP,
                CONST_PRICE_TYPE_FPT_BIL_EXCL_TAX, CONST_PRICE_TYPE_PROP_MISC_1
              };

        public readonly int[] CONST_SOUGHT_SUPP_COST_PRICE_TYPES
            = {
                CONST_PRICE_TYPE_SUPP_COST
              };

        public readonly int[] CONST_SOUGHT_PRICE_TYPES
            = {
                CONST_PRICE_TYPE_RRP_EXCL, CONST_PRICE_TYPE_SUPP_COST, CONST_PRICE_TYPE_RRP_PREP,
                CONST_PRICE_TYPE_FPT_RRP_EXCL_TAX, CONST_PRICE_TYPE_FPT_BIL_EXCL_TAX,
                CONST_PRICE_TYPE_PROP_MISC_1, CONST_PRICE_TYPE_PROP_MISC_2
              };

        #endregion

        #region Helper Methods

        public string DiscountAmount
        {
            get
            {
                string DiscAmt = "";

                if ((this.Discount != null) && (this.Discount.Length > 0))
                {
                    OnixDiscount FoundDiscount =
                        Discount.Where(x => !string.IsNullOrEmpty(x.DiscountAmount)).FirstOrDefault();

                    if ((FoundDiscount != null) && !string.IsNullOrEmpty(FoundDiscount.DiscountAmount))
                        DiscAmt = FoundDiscount.DiscountAmount;
                }

                return DiscAmt;
            }
        }

        public string DiscountPercent
        {
            get
            {
                string DiscPct = "";

                if ((this.Discount != null) && (this.Discount.Length > 0))
                {
                    OnixDiscount FoundDiscount =
                        Discount.Where(x => !string.IsNullOrEmpty(x.DiscountPercent)).FirstOrDefault();

                    if ((FoundDiscount != null) && !string.IsNullOrEmpty(FoundDiscount.DiscountPercent))
                        DiscPct = FoundDiscount.DiscountPercent;
                }

                return DiscPct;
            }
        }

        public bool HasSoughtRetailPriceType()
        {
            return CONST_SOUGHT_RETAIL_PRICE_TYPES.Contains((int)this.PriceType);
        }

        public bool HasSoughtSupplyCostPriceType()
        {
            return CONST_SOUGHT_SUPP_COST_PRICE_TYPES.Contains((int)this.PriceType);
        }

        public bool HasSoughtPriceTypeCode()
        {
            return CONST_SOUGHT_PRICE_TYPES.Contains((int)this.PriceType);
        }

        public bool HasViablePubDiscountCode()
        {
            return (OnixFirstViableDiscountCoded != null);
        }

        public OnixDiscountCoded OnixFirstViableDiscountCoded
        {
            get
            {
                OnixDiscountCoded ViableDiscountCoded = null;

                if ((this.DiscountCoded != null) && (this.DiscountCoded.Length > 0))
                {
                    OnixDiscountCoded DiscountCodedCandidate =
                        DiscountCoded.Where(x => x.IsProprietaryType()).FirstOrDefault();

                    if ((DiscountCodedCandidate != null) && !string.IsNullOrEmpty(DiscountCodedCandidate.DiscountCode))
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

                if (Tax != null && Array.Exists(Tax, t => t.TaxType == 1))
                {
                    foreach (OnixPriceTax PriceTax in Tax.Where(t => t.TaxType == 1))
                    {
                        if (PriceTax.TaxAmount != null)
                            TaxAmount += PriceTax.TaxAmount.Value;
                        else if (PriceTax.TaxableAmount != null && PriceTax.TaxRatePercent != null)
                            TaxAmount += Math.Round(PriceTax.TaxableAmount.Value * (PriceTax.TaxRatePercent.Value / 100), 2, MidpointRounding.AwayFromZero);
                    }
                }

                return PriceAmount - TaxAmount;
            }
        }

        #endregion

        #region Reference Tags

        [XmlChoiceIdentifier("PriceTypeChoice")]
        [XmlElement("PriceType")]
        [XmlElement("x462")]
        public OnixList58? PriceType { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum PriceTypeEnum { PriceType, x462 }
        [XmlIgnore]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public PriceTypeEnum PriceTypeChoice
        {
            get { return SerializationSettings.UseShortTags ? PriceTypeEnum.x462 : PriceTypeEnum.PriceType; }
            set { }
        }


        /// <summary>
        /// An ONIX code which further specifies the type of price, eg member price, reduced price when purchased as part of a set.
        /// Optional and non-repeating.
        /// </summary>
        [XmlChoiceIdentifier("PriceQualifierChoice")]
        [XmlElement("PriceQualifier")]
        [XmlElement("j261")]
        public int PriceQualifier { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum PriceQualifierEnum { PriceQualifier, j261 }
        [XmlIgnore, DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public PriceQualifierEnum PriceQualifierChoice
        {
            get { return SerializationSettings.UseShortTags ? PriceQualifierEnum.j261 : PriceQualifierEnum.PriceQualifier; }
            set { }
        }

        [XmlChoiceIdentifier("PriceAmountChoice")]
        [XmlElement("PriceAmount")]
        [XmlElement("j151")]
        public decimal PriceAmount { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum PriceAmountEnum { PriceAmount, j151 }
        [XmlIgnore]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public PriceAmountEnum PriceAmountChoice
        {
            get { return SerializationSettings.UseShortTags ? PriceAmountEnum.j151 : PriceAmountEnum.PriceAmount; }
            set { }
        }

        [XmlChoiceIdentifier("TaxChoice")]
        [XmlElement("Tax")]
        [XmlElement("tax")]
        public OnixPriceTax[] Tax { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum TaxEnum { Tax, tax }
        [XmlIgnore]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public TaxEnum[] TaxChoice
        {
            get
            {
                if (Tax == null) return null;
                TaxEnum choice = SerializationSettings.UseShortTags ? TaxEnum.tax : TaxEnum.Tax;
                TaxEnum[] result = new TaxEnum[Tax.Length];
                for (int i = 0; i < Tax.Length; i++) result[i] = choice;
                return result;
            }
            set { }
        }

        [XmlChoiceIdentifier("CurrencyCodeChoice")]
        [XmlElement("CurrencyCode")]
        [XmlElement("j152")]
        public string CurrencyCode { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum CurrencyCodeEnum { CurrencyCode, j152 }
        [XmlIgnore]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public CurrencyCodeEnum CurrencyCodeChoice
        {
            get { return SerializationSettings.UseShortTags ? CurrencyCodeEnum.j152 : CurrencyCodeEnum.CurrencyCode; }
            set { }
        }

        [XmlChoiceIdentifier("DiscountChoice")]
        [XmlElement("Discount")]
        [XmlElement("discount")]
        public OnixDiscount[] Discount { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum DiscountEnum { Discount, discount }
        [XmlIgnore]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public DiscountEnum[] DiscountChoice
        {
            get
            {
                if (Discount == null) return null;
                DiscountEnum choice = SerializationSettings.UseShortTags ? DiscountEnum.discount : DiscountEnum.Discount;
                DiscountEnum[] result = new DiscountEnum[Discount.Length];
                for (int i = 0; i < Discount.Length; i++) result[i] = choice;
                return result;
            }
            set { }
        }

        [XmlChoiceIdentifier("DiscountCodedChoice")]
        [XmlElement("DiscountCoded")]
        [XmlElement("discountcoded")]
        public OnixDiscountCoded[] DiscountCoded { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum DiscountCodedEnum { DiscountCoded, discountcoded }
        [XmlIgnore]
        [EditorBrowsable(EditorBrowsableState.Never)]
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

        [XmlChoiceIdentifier("UnpricedItemTypeChoice")]
        [XmlElement("UnpricedItemType")]
        [XmlElement("j192")]
        public OnixList57 UnpricedItemType { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum UnpricedItemTypeEnum { UnpricedItemType, j192 }
        [XmlIgnore]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public UnpricedItemTypeEnum UnpricedItemTypeChoice
        {
            get { return SerializationSettings.UseShortTags ? UnpricedItemTypeEnum.j192 : UnpricedItemTypeEnum.UnpricedItemType; }
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
