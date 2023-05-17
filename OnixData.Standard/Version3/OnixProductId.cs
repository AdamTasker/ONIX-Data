using System.ComponentModel;
using System.Xml.Serialization;

namespace OnixData.Version3
{
    /// <summary>
    /// A group of data elements which together specify an identifier of a product in accordance with a particular scheme.
    /// </summary>
    [XmlType(AnonymousType = true)]
    public partial class OnixProductId : OnixIdentifier
    {
        #region CONSTANTS

        public const int CONST_PRODUCT_TYPE_PROP   = 1;
        public const int CONST_PRODUCT_TYPE_ISBN   = 2;
        public const int CONST_PRODUCT_TYPE_EAN    = 3;
        public const int CONST_PRODUCT_TYPE_UPC    = 4;
        public const int CONST_PRODUCT_TYPE_ISMN   = 5;
        public const int CONST_PRODUCT_TYPE_DOI    = 6;
        public const int CONST_PRODUCT_TYPE_LCCN   = 13;
        public const int CONST_PRODUCT_TYPE_GTIN   = 14;
        public const int CONST_PRODUCT_TYPE_ISBN13 = 15;

        #endregion

        #region Reference Tags

        /// <summary>
        /// An ONIX code identifying the scheme from which the identifier in the <see cref="IDValue"/> element is taken.
        /// <para>Mandatory in each occurrence of the <see cref="OnixProductId"/> composite, and non-repeating.</para>
        /// </summary>
        /// <remarks>Onix List 5</remarks>
        [XmlChoiceIdentifier("ProductIDTypeChoice")]
        [XmlElement("ProductIDType")]
        [XmlElement("b221")]
        public int ProductIDType { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum ProductIDTypeEnum { ProductIDType, b221 }
        [XmlIgnore, DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ProductIDTypeEnum ProductIDTypeChoice
        {
            get { return SerializationSettings.UseShortTags ? ProductIDTypeEnum.b221 : ProductIDTypeEnum.ProductIDType; }
            set { }
        }

        #endregion

    }
}
