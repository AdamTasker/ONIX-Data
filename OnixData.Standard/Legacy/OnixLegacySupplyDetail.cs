using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace OnixData.Legacy
{
    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class OnixLegacySupplyDetail
    {
        #region CONSTANTS

        public const int CONST_RET_CODE_TYPE_BISAC = 2;

        #endregion

        #region ONIX Helpers

        public bool HasUSDPrice()
        {
            bool bHasUSDPrice = false;

            if ((this.Price != null) && (this.Price.Length > 0))
            {
                OnixLegacyPrice[] Prices = this.Price;

                OnixLegacyPrice USDPrice =
                    Prices.Where(x => x.HasSoughtRetailPriceType() && (x.CurrencyCode == "USD")).FirstOrDefault();

                bHasUSDPrice = (USDPrice != null) && (USDPrice.PriceAmount >= 0);
            }

            return bHasUSDPrice;
        }

        public OnixLegacyPrice MainPrice
        {
            get
            {
                if (Price == null) return null;

                OnixLegacyPrice mainPrice;

                // Get the price we will be using for the product
                if (Price.Length == 1)
                {
                    mainPrice = Price[0];
                }
                else
                {
                    var prices = Price.Where(
                        p =>
                            p.MinimumOrderQuantity == null &&
                            (p.PriceTypeCode == null || p.HasSoughtRetailPriceType())
                    );

                    if (prices.Any())
                    {
                        mainPrice = prices.First();
                    }
                    else
                    {
                        mainPrice = Price.Where(p => p.MinimumOrderQuantity == null).First();
                    }
                }

                return mainPrice;
            }
        }

        #endregion

        #region Reference Tags

        [XmlChoiceIdentifier("SupplierNameChoice")]
        [XmlElement("SupplierName")]
        [XmlElement("j137")]
        public string SupplierName { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum SupplierNameEnum { SupplierName, j137 }
        [XmlIgnore]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public SupplierNameEnum SupplierNameChoice
        {
            get { return SerializationSettings.UseShortTags ? SupplierNameEnum.j137 : SupplierNameEnum.SupplierName; }
            set { }
        }

        [XmlChoiceIdentifier("ReturnsCodeTypeChoice")]
        [XmlElement("ReturnsCodeType")]
        [XmlElement("j268")]
        public int ReturnsCodeType { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum ReturnsCodeTypeEnum { ReturnsCodeType, j268 }
        [XmlIgnore]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ReturnsCodeTypeEnum ReturnsCodeTypeChoice
        {
            get { return SerializationSettings.UseShortTags ? ReturnsCodeTypeEnum.j268 : ReturnsCodeTypeEnum.ReturnsCodeType; }
            set { }
        }

        [XmlChoiceIdentifier("ReturnsCodeChoice")]
        [XmlElement("ReturnsCode")]
        [XmlElement("j269")]
        public string ReturnsCode { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum ReturnsCodeEnum { ReturnsCode, j269 }
        [XmlIgnore]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ReturnsCodeEnum ReturnsCodeChoice
        {
            get { return SerializationSettings.UseShortTags ? ReturnsCodeEnum.j269 : ReturnsCodeEnum.ReturnsCode; }
            set { }
        }

        [XmlChoiceIdentifier("LastDateForReturnsChoice")]
        [XmlElement("LastDateForReturns")]
        [XmlElement("j387")]
        public string LastDateForReturns { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum LastDateForReturnsEnum { LastDateForReturns, j387 }
        [XmlIgnore]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public LastDateForReturnsEnum LastDateForReturnsChoice
        {
            get { return SerializationSettings.UseShortTags ? LastDateForReturnsEnum.j387 : LastDateForReturnsEnum.LastDateForReturns; }
            set { }
        }

        [XmlChoiceIdentifier("AvailabilityCodeChoice")]
        [XmlElement("AvailabilityCode")]
        [XmlElement("j141")]
        public Lists.OnixList54 AvailabilityCode { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum AvailabilityCodeEnum { AvailabilityCode, j141 }
        [XmlIgnore]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public AvailabilityCodeEnum AvailabilityCodeChoice
        {
            get { return SerializationSettings.UseShortTags ? AvailabilityCodeEnum.j141 : AvailabilityCodeEnum.AvailabilityCode; }
            set { }
        }


        [XmlChoiceIdentifier("ProductAvailabilityChoice")]
        [XmlElement("ProductAvailability")]
        [XmlElement("j396")]
        public Lists.OnixList65 ProductAvailability { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum ProductAvailabilityEnum { ProductAvailability, j396 }
        [XmlIgnore]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ProductAvailabilityEnum ProductAvailabilityChoice
        {
            get { return SerializationSettings.UseShortTags ? ProductAvailabilityEnum.j396 : ProductAvailabilityEnum.ProductAvailability; }
            set { }
        }


        [XmlChoiceIdentifier("ExpectedShipDateChoice")]
        [XmlElement("ExpectedShipDate")]
        [XmlElement("j142")]
        public string ExpectedShipDate { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum ExpectedShipDateEnum { ExpectedShipDate, j142 }
        [XmlIgnore]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ExpectedShipDateEnum ExpectedShipDateChoice
        {
            get { return SerializationSettings.UseShortTags ? ExpectedShipDateEnum.j142 : ExpectedShipDateEnum.ExpectedShipDate; }
            set { }
        }


        [XmlChoiceIdentifier("OnSaleDateChoice")]
        [XmlElement("OnSaleDate")]
        [XmlElement("j143")]
        public string OnSaleDate { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum OnSaleDateEnum { OnSaleDate, j143 }
        [XmlIgnore]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public OnSaleDateEnum OnSaleDateChoice
        {
            get { return SerializationSettings.UseShortTags ? OnSaleDateEnum.j143 : OnSaleDateEnum.OnSaleDate; }
            set { }
        }

        [XmlChoiceIdentifier("PackQuantityChoice")]
        [XmlElement("PackQuantity")]
        [XmlElement("j145")]
        public int PackQuantity { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum PackQuantityEnum { PackQuantity, j145 }
        [XmlIgnore]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public PackQuantityEnum PackQuantityChoice
        {
            get { return SerializationSettings.UseShortTags ? PackQuantityEnum.j145 : PackQuantityEnum.PackQuantity; }
            set { }
        }

        [XmlChoiceIdentifier("UnpricedItemTypeChoice")]
        [XmlElement("UnpricedItemType")]
        [XmlElement("j192")]
        public string UnpricedItemType { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum UnpricedItemTypeEnum { UnpricedItemType, j192 }
        [XmlIgnore]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public UnpricedItemTypeEnum UnpricedItemTypeChoice
        {
            get { return SerializationSettings.UseShortTags ? UnpricedItemTypeEnum.j192 : UnpricedItemTypeEnum.UnpricedItemType; }
            set { }
        }

        [XmlChoiceIdentifier("SupplierIdentifierChoice")]
        [XmlElement("SupplierIdentifier")]
        [XmlElement("supplieridentifier")]
        public OnixLegacySupplierId[] SupplierIdentifier { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum SupplierIdentifierEnum { SupplierIdentifier, supplieridentifier }
        [XmlIgnore]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public SupplierIdentifierEnum[] SupplierIdentifierChoice
        {
            get
            {
                if (SupplierIdentifier == null) return null;
                SupplierIdentifierEnum choice = SerializationSettings.UseShortTags ? SupplierIdentifierEnum.supplieridentifier : SupplierIdentifierEnum.SupplierIdentifier;
                SupplierIdentifierEnum[] result = new SupplierIdentifierEnum[SupplierIdentifier.Length];
                for (int i = 0; i < SupplierIdentifier.Length; i++) result[i] = choice;
                return result;
            }
            set { }
        }

        [XmlChoiceIdentifier("PriceChoice")]
        [XmlElement("Price")]
        [XmlElement("price")]
        public OnixLegacyPrice[] Price { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum PriceEnum { Price, price }
        [XmlIgnore]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public PriceEnum[] PriceChoice
        {
            get
            {
                if (Price == null) return null;
                PriceEnum choice = SerializationSettings.UseShortTags ? PriceEnum.price : PriceEnum.Price;
                PriceEnum[] result = new PriceEnum[Price.Length];
                for (int i = 0; i < Price.Length; i++) result[i] = choice;
                return result;
            }
            set { }
        }


        #endregion
    }
}
