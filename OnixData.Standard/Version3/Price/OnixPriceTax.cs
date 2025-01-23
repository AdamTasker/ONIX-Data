using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace OnixData.Version3.Price
{
    /// <remarks/>
    [XmlType(AnonymousType = true)]
    public partial class OnixPriceTax
    {
        #region Reference Tags

        [XmlChoiceIdentifier("TaxTypeChoice")]
        [XmlElement("TaxType")]
        [XmlElement("x470")]
        public int TaxType { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum TaxTypeEnum { TaxType, x470 }
        [XmlIgnore]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public TaxTypeEnum TaxTypeChoice
        {
            get { return SerializationSettings.UseShortTags ? TaxTypeEnum.x470 : TaxTypeEnum.TaxType; }
            set { }
        }

        [XmlChoiceIdentifier("TaxRateCodeChoice")]
        [XmlElement("TaxRateCode")]
        [XmlElement("x471")]
        public string TaxRateCode { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum TaxRateCodeEnum { TaxRateCode, x471 }
        [XmlIgnore]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public TaxRateCodeEnum TaxRateCodeChoice
        {
            get { return SerializationSettings.UseShortTags ? TaxRateCodeEnum.x471 : TaxRateCodeEnum.TaxRateCode; }
            set { }
        }

        [XmlChoiceIdentifier("TaxRatePercentChoice")]
        [XmlElement("TaxRatePercent")]
        [XmlElement("x472")]
        public decimal? TaxRatePercent { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum TaxRatePercentEnum { TaxRatePercent, x472 }
        [XmlIgnore]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public TaxRatePercentEnum TaxRatePercentChoice
        {
            get { return SerializationSettings.UseShortTags ? TaxRatePercentEnum.x472 : TaxRatePercentEnum.TaxRatePercent; }
            set { }
        }


        /// <summary>
        /// The amount of the unit price of the product, excluding tax, which is taxable at the rate specified in an occurrence of the <see cref="OnixPriceTax"/> composite.
        /// Optional and non-repeating; but required if tax is charged on part of the price.
        /// Omission of this element implies that tax is charged on the full amount of the price.
        /// </summary>
        [XmlChoiceIdentifier("TaxableAmountChoice")]
        [XmlElement("TaxableAmount")]
        [XmlElement("x473")]
        public decimal? TaxableAmount { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum TaxableAmountEnum { TaxableAmount, x473 }
        [XmlIgnore]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public TaxableAmountEnum TaxableAmountChoice
        {
            get { return SerializationSettings.UseShortTags ? TaxableAmountEnum.x473 : TaxableAmountEnum.TaxableAmount; }
            set { }
        }
        /// <summary>
        /// The amount of tax chargeable at the rate specified in an occurrence of the <see cref="OnixPriceTax"/> composite.
        /// Optional and non-repeating; but either <see cref="TaxRatePercent"/> or <see cref="TaxAmount"/> or both must be present in each occurrence of the <see cref="OnixPriceTax"/> composite.
        /// </summary>
        [XmlChoiceIdentifier("TaxAmountChoice")]
        [XmlElement("TaxAmount")]
        [XmlElement("x474")]
        public decimal? TaxAmount { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum TaxAmountEnum { TaxAmount, x474 }
        [XmlIgnore]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public TaxAmountEnum TaxAmountChoice
        {
            get { return SerializationSettings.UseShortTags ? TaxAmountEnum.x474 : TaxAmountEnum.TaxAmount; }
            set { }
        }

        #endregion
    }
}
