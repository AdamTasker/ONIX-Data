using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

using OnixData.Version3.Lists;
using OnixData.Version3.Price;
using OnixData.Version3.Xml.Enums;

namespace OnixData.Version3.Supply
{
    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class OnixSupplyDetail
    {

        #region Helper Methods
        private OnixList58[] retailPriceTypes = { OnixList58.RrpIncludingTax, OnixList58.RrpExcludingTax };

        public bool HasRetailPrice
        {
            get
            {
                if (Price == null) return false;
                return
                    Array.Exists(
                        Price,
                        p =>
                            p.PriceQualifier == 5 ||
                            p.PriceType != null && retailPriceTypes.Contains(p.PriceType.Value) ||
                            p.PriceTypeDescription != null && p.PriceTypeDescription.Contains("Retail Price")
                    );
            }
        }

        public OnixPrice RetailPrice
        {
            get
            {
                return
                    Price.Where(
                        p =>
                            p.PriceQualifier == 5 ||
                            p.PriceType != null && retailPriceTypes.Contains(p.PriceType.Value) ||
                            p.PriceTypeDescription != null && p.PriceTypeDescription.Contains("Retail Price")
                    ).FirstOrDefault();
            }
        }

        public bool HasUSDPrice()
        {
            bool bHasUSDPrice = false;

            if ((Price != null) && (Price.Length > 0))
            {
                bHasUSDPrice =
                    Array.Exists(Price, x => (x.PriceType == null || (int)x.PriceType == OnixPrice.CONST_PRICE_TYPE_RRP_EXCL) && (x.CurrencyCode == "USD"));
            }

            return bHasUSDPrice;
        }

        public bool HasReturnCodeTypeBisac()
        {
            bool bHasRetCodeBisac = false;

            if ((ReturnsConditions != null) && (ReturnsConditions.Length > 0))
            {
                bHasRetCodeBisac =
                    Array.Exists(ReturnsConditions, x => (x.ReturnsCodeTypeNum == OnixReturnsConditions.CONST_RET_CODE_TYPE_BISAC));
            }

            return bHasRetCodeBisac;
        }

        public string ReturnCodeBisac
        {
            get
            {
                string sRetCodeBisac = "";

                if ((ReturnsConditions != null) && (ReturnsConditions.Length > 0))
                {
                    var RetConditions =
                        ReturnsConditions.Where(x => (x.ReturnsCodeTypeNum == OnixReturnsConditions.CONST_RET_CODE_TYPE_BISAC))
                                         .FirstOrDefault();

                    if (RetConditions != null)
                        sRetCodeBisac = RetConditions.ReturnsCode;
                }

                return sRetCodeBisac;
            }
        }

        #endregion

        #region Reference Tags

        /// <remarks/>
        [XmlChoiceIdentifier("XmlChoiceProductAvailability")]
        [XmlElement("ProductAvailability")]
        [XmlElement("j396")]
        public string ProductAvailability { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum ProductAvailabilityEnum { ProductAvailability, j396 }
        [XmlIgnore]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ProductAvailabilityEnum XmlChoiceProductAvailability
        {
            get { return SerializationSettings.UseShortTags ? ProductAvailabilityEnum.j396 : ProductAvailabilityEnum.ProductAvailability; }
            set { }
        }

        /// <remarks/>
        [XmlChoiceIdentifier("XmlChoicePackQuantity")]
        [XmlElement("PackQuantity")]
        [XmlElement("j145")]
        public int PackQuantity { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum PackQuantityEnum { PackQuantity, j145 }
        [XmlIgnore]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public PackQuantityEnum XmlChoicePackQuantity
        {
            get { return SerializationSettings.UseShortTags ? PackQuantityEnum.j145 : PackQuantityEnum.PackQuantity; }
            set { }
        }

        /// <remarks/>
        [XmlChoiceIdentifier("XmlChoicePrice")]
        [XmlElement("Price")]
        [XmlElement("price")]
        public OnixPrice[] Price { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum PriceEnum { Price, price }
        [XmlIgnore]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public PriceEnum[] XmlChoicePrice
        {
            get
            {
                if (Price == null) return null;
                return SerializationHelper.CreateEnumArray(PriceEnum.price, PriceEnum.Price, Price.Length);
            }
            set { }
        }

        /// <remarks/>
        [XmlChoiceIdentifier("XmlChoiceReturnsConditions")]
        [XmlElement("ReturnsConditions")]
        [XmlElement("returnsconditions")]
        public OnixReturnsConditions[] ReturnsConditions { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum ReturnsConditionsEnum { ReturnsConditions, returnsconditions }
        [XmlIgnore]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ReturnsConditionsEnum[] XmlChoiceReturnsConditions
        {
            get
            {
                if (ReturnsConditions == null) return null;
                return SerializationHelper.CreateEnumArray(ReturnsConditionsEnum.returnsconditions, ReturnsConditionsEnum.ReturnsConditions, ReturnsConditions.Length);
            }
            set { }
        }

        /// <remarks/>
        [XmlChoiceIdentifier("XmlChoiceSupplier")]
        [XmlElement("Supplier")]
        [XmlElement("supplier")]
        public OnixSupplier[] Supplier { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum SupplierEnum { Supplier, supplier }
        [XmlIgnore]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public SupplierEnum[] XmlChoiceSupplier
        {
            get
            {
                if (Supplier == null) return null;
                return SerializationHelper.CreateEnumArray(SupplierEnum.supplier, SupplierEnum.Supplier, Supplier.Length);
            }
            set { }
        }

        /// <remarks/>
        [XmlChoiceIdentifier("XmlChoiceSupplyDate")]
        [XmlElement("SupplyDate")]
        [XmlElement("supplydate")]
        public OnixSupplyDate[] SupplyDate { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum SupplyDateEnum { SupplyDate, supplydate }
        [XmlIgnore]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public SupplyDateEnum[] XmlChoiceSupplyDate
        {
            get
            {
                if (SupplyDate == null) return null;
                return SerializationHelper.CreateEnumArray(SupplyDateEnum.supplydate, SupplyDateEnum.SupplyDate, SupplyDate.Length);
            }
            set { }
        }

        /// <remarks/>
        [XmlChoiceIdentifier("XmlChoiceUnpricedItemType")]
        [XmlElement("UnpricedItemType")]
        [XmlElement("j192")]
        public OnixList57 UnpricedItemType { get; set; }
        [XmlIgnore]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public UnpricedItemTypeEnum XmlChoiceUnpricedItemType
        {
            get { return SerializationSettings.UseShortTags ? UnpricedItemTypeEnum.j192 : UnpricedItemTypeEnum.UnpricedItemType; }
            set { }
        }

        #endregion
    }
}
