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
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class OnixPriceTax
    {
        public OnixPriceTax()
        {
            TaxType     = -1;
            TaxRateCode = TaxRatePercent = String.Empty;
        }            

        private int    taxTypeField;
        private string taxRateCodeField;
        private string taxRatePercentField;
        
        #region Helper Methods

        public decimal TaxRatePercentNum
        {
            get
            {
                decimal nPercent = 0;

                if (!String.IsNullOrEmpty(TaxRatePercent))
                    Decimal.TryParse(TaxRatePercent, out nPercent);

                return nPercent;
            }
        }

        #endregion

        #region Reference Tags

        /// <remarks/>
        public int TaxType
        {
            get
            {
                return this.taxTypeField;
            }
            set
            {
                this.taxTypeField = value;
            }
        }

        /// <remarks/>
        public string TaxRateCode
        {
            get
            {
                return this.taxRateCodeField;
            }
            set
            {
                this.taxRateCodeField = value;
            }
        }
        
        public string TaxRatePercent
        {
            get
            {
                return this.taxRatePercentField;
            }
            set
            {
                this.taxRatePercentField = value;
            }
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
        [XmlIgnore, DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
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
        [XmlIgnore, DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public TaxAmountEnum TaxAmountChoice
        {
          get { return SerializationSettings.UseShortTags ? TaxAmountEnum.x474 : TaxAmountEnum.TaxAmount; }
          set { }
        }

        /// <remarks/>
        public string x472
        {
            get { return TaxRatePercent; }
            set { TaxRatePercent = value; }
        }

        #endregion

        #region Short Tags

        /// <remarks/>
        public int x470
        {
            get { return TaxType; }
            set { TaxType = value; }
        }

        /// <remarks/>
        public string x471
        {
            get { return TaxRateCode; }
            set { TaxRateCode = value; }
        }

        #endregion
    }
}
