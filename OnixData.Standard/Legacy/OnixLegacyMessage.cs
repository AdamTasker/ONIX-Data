using System.ComponentModel;
using System.Xml.Serialization;

namespace OnixData.Legacy
{
    /// <summary>
    /// 
    /// This class will serve as the serialization envelope for ONIX files that are written 
    /// using the legacy standard (i.e., Version 2.1).
    /// 
    /// </summary>
    [XmlType(AnonymousType = true)]
    // [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    [XmlRoot(IsNullable = false)]
    public partial class OnixLegacyMessage
    {

        #region Reference Tags

        /// <summary>
        /// A group of data elements which together constitute a message header.
        /// The elements may alternatively be sent without being grouped into a composite, but the composite approach is recommended since it makes it easier to maintain a standard header “package” to drop into any new ONIX Product Information Message.
        ///
        /// Note that the Sender and Addressee Identifier composites can only be used within the Header composite, and future extensions to the Header will be defined only within the composite.
        /// </summary>
        [XmlChoiceIdentifier("HeaderChoice")]
        [XmlElement("Header")]
        [XmlElement("header")]
        public OnixLegacyHeader Header { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum HeaderEnum { Header, header };
        [XmlIgnore]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public HeaderEnum HeaderChoice
        {
            get { return SerializationSettings.UseShortTags ? HeaderEnum.header : HeaderEnum.Header; }
            set { }
        }

        /// <summary>
        /// A product is described by a group of data elements beginning with an XML label <Product> and ending with an XML label </Product>.
        /// The entire group of data elements which is enclosed between these two labels constitutes an ONIX product record.
        /// The product record is the fundamental unit within an ONIX Product Information message.
        /// In almost every case, each product record describes an individually tradable item.
        /// </summary>
        [XmlChoiceIdentifier("ProductChoice")]
        [XmlElement("Product")]
        [XmlElement("product")]
        public OnixLegacyProduct[] Product { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum ProductEnum { Product, product };
        [XmlIgnore]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ProductEnum[] ProductChoice
        {
            get
            {
                if (Product == null) return null;
                ProductEnum choice = SerializationSettings.UseShortTags ? ProductEnum.product : ProductEnum.Product;
                ProductEnum[] result = new ProductEnum[Product.Length];
                for (int i = 0; i < Product.Length; i++) result[i] = choice;
                return result;
            }
            set { }
        }

        #endregion
    }
}
