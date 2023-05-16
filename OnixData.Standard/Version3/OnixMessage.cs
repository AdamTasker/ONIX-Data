using System.ComponentModel;
using System.Xml.Serialization;

using OnixData.Version3.Header;

namespace OnixData.Version3
{
    /// <remarks/>
    [XmlType(AnonymousType = true)]
    // [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class OnixMessage
    {
        #region Reference Tags

        /// <summary>
        /// A group of data elements which together constitute a message header.
        /// Mandatory in any ONIX for Books message, and non-repeating.
        /// In ONIX 3.0, a number of redundant elements have been deleted, and the Sender and Addressee structures and the name and format of the <see cref="OnixHeader.SentDateTime"/> element have been made consistent with other current ONIX formats.
        /// </summary>
        [XmlChoiceIdentifier("HeaderChoice")]
        [XmlElement("Header")]
        [XmlElement("header")]
        public OnixHeader Header { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum OnixHeaderEnum { Header, header }
        [XmlIgnore]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public OnixHeaderEnum HeaderChoice
        {
            get { return SerializationSettings.UseShortTags ? OnixHeaderEnum.header : OnixHeaderEnum.Header; }
            set { }
        }

        /// <summary>
        /// A product is described by a group of data elements beginning with an XML label &lt;Product&gt; and ending with an XML label &lt;/Product&gt;.
        /// The entire group of data elements which is enclosed between these two labels constitutes an ONIX product record.
        /// The product record is the fundamental unit within an ONIX Product Information message.
        /// In almost every case, each product record describes an individually tradable item; and in all circumstances, each tradable item identified by a recognized product identifier should be described by one, and only one, ONIX product record.
        /// In ONIX 3.0, a &lt;Product&gt; record has a mandatory ‘preamble’ comprising data Groups P.1 and P.2, and carrying data that identifies the record and the product to which it refers.
        /// This is followed by up to seven ‘blocks’, each optional, some of which are repeatable.
        /// </summary>
        [XmlChoiceIdentifier("ProductChoice")]
        [XmlElement("Product")]
        [XmlElement("product")]
        public OnixProduct[] Product { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum ProductEnum { Product, product }
        [XmlIgnore, DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
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
