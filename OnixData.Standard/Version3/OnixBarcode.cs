using System.ComponentModel;
using System.Xml.Serialization;

namespace OnixData.Version3
{
    /// <summary>
    /// A group of data elements which together specify a barcode type and its position on a product.
    /// </summary>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class OnixBarcode
    {

        #region Helper Methods

        public string BarcodeTypeAndPos
        {
            get
            {
                string sCombo = BarcodeType;

                if (!string.IsNullOrEmpty(PositionOnProduct))
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
        [XmlChoiceIdentifier("BarcodeTypeChoice")]
        [XmlElement("BarcodeType")]
        [XmlElement("x312")]
        public string BarcodeType { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum BarcodeTypeEnum { BarcodeType, x312}
        [XmlIgnore, DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public BarcodeTypeEnum BarcodeTypeChoice
        {
            get { return SerializationSettings.UseShortTags ? BarcodeTypeEnum.x312 : BarcodeTypeEnum.BarcodeType; }
            set { }
        }

        /// <summary>
        /// An ONIX code indicating a position on a product; in this case, the position in which a barcode appears.
        /// Required if the <see cref="BarcodeType"/> element indicates that the barcode appears on the product, even if the position is ‘unknown’.
        /// Omitted if the <see cref="BarcodeType"/> element specifies that the product does not carry a barcode.
        /// Non-repeating.
        /// </summary>
        /// <remarks>Onix List 142</remarks>
        [XmlChoiceIdentifier("PositionOnProductChoice")]
        [XmlElement("PositionOnProduct")]
        [XmlElement("x313")]
        public string PositionOnProduct { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum PositionOnProductEnum { PositionOnProduct, x313 }
        [XmlIgnore, DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public PositionOnProductEnum PositionOnProductChoice
        {
            get { return SerializationSettings.UseShortTags ? PositionOnProductEnum.x313 : PositionOnProductEnum.PositionOnProduct; }
            set { }
        }

        #endregion

    }
}

