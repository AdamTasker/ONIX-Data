using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnixData.Version3
{
    /// <summary>
    /// A group of data elements which together specify a barcode type and its position on a product.
    /// </summary>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class OnixBarcode
    {
        public OnixBarcode()
        {
            BarcodeType = PositionOnProduct = "";
        }

        private string barcodeTypeField;
        private string posOnProdField;

        #region Helper Methods

        public string BarcodeTypeAndPos
        {
            get
            {
                string sCombo = BarcodeType;

                if (!String.IsNullOrEmpty(PositionOnProduct))
                    sCombo += PositionOnProduct;

                return sCombo;
            }
        }

        #endregion

        #region Reference Tags

        /// <summary>
        /// An ONIX code indicating whether, and in what form, a barcode is carried on a product.
        /// <para>Mandatory in any instance of the <see cref="OnixBarcode"/> composite, and non-repeating.</para>
        /// </summary>
        /// <remarks>Onix List 141</remarks>
        public string BarcodeType
        {
            get
            {
                return this.barcodeTypeField;
            }
            set
            {
                this.barcodeTypeField = value;
            }
        }

        /// <summary>
        /// An ONIX code indicating a position on a product; in this case, the position in which a barcode appears.
        /// Required if the <see cref="BarcodeType"/> element indicates that the barcode appears on the product, even if the position is ‘unknown’.
        /// Omitted if the <see cref="BarcodeType"/> element specifies that the product does not carry a barcode.
        /// Non-repeating.
        /// </summary>
        /// <remarks>Onix List 142</remarks>
        public string PositionOnProduct
        {
            get
            {
                return this.posOnProdField;
            }
            set
            {
                this.posOnProdField = value;
            }
        }

        #endregion

        #region Short Tags

        /// <remarks/>
        public string x312
        {
            get { return BarcodeType; }
            set { BarcodeType = value; }
        }

        /// <remarks/>
        public string x313
        {
            get { return PositionOnProduct; }
            set { PositionOnProduct = value; }
        }

        #endregion
    }
}

