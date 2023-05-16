using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnixData.Version3.ProductPart
{
    /// <summary>
    /// <para>A group of data elements which together describe an item which is part of or contained within a multiple-component or multiple-item product or a trade pack.
    /// The composite must be used with all multi-component or multi-item products and packs to specify (for example) the item(s) and item quantities included in a combined book plus audiobook product, a multi-volume set, a filled dumpbin, or a classroom pack.
    /// In other cases, where parts are not individually identified, it is used to state the product form(s) and the quantity or quantities of each form contained within the product.</para>
    /// 
    /// <para>Each instance of the <see cref="OnixProductPart"/> composite must carry a <see cref="ProductForm"/> code and a quantity, even if the quantity is ‘1’.
    /// If the composite refers to a number of copies of a single item, the quantity must be sent as <see cref="NumberOfCopies"/>, normally accompanied by a <see cref="ProductIdentifier"/>.
    /// If the composite refers to a number of different items of the same form, without identifying them individually, the quantity must be sent as <see cref="NumberOfItemsOfThisForm"/>.</para>
    /// </summary>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class OnixProductPart
    {
        #region CONSTANTS

        public const string CONST_MAIN_PRD_PART_INDICATOR = "MAIN";

        #endregion

        public OnixProductPart()
        {
            PrimaryPart = ProductForm = NumberOfItemsOfThisForm = "";
        }

        private string primaryPartField;
        private string productFormField;
        private string numOfItemsOfThisFormField;

        #region Reference Tags

        /// <summary>
        /// An empty element that allows a sender to identify a product part as the ‘primary’ part of a multiple-item product.
        /// For example, in a ‘book and toy’ or ‘book and DVD’ product, the book may be regarded as the primary part.
        /// Optional and non-repeating.
        /// </summary>
        public string PrimaryPart
        {
            get { return this.primaryPartField; }

            set
            {
                if (String.IsNullOrEmpty(value))
                    value = CONST_MAIN_PRD_PART_INDICATOR;
                else
                    this.primaryPartField = value;
            }
        }

        /// <summary>
        /// A group of data elements which together define an identifier of a product in accordance with a specified scheme, used here to carry the product identifier of a product part.
        /// Optional, but required when an occurrence of <see cref="OnixProductPart"/> specifies an individual item with its own identifier, and repeatable with different identifiers for the same item.
        /// </summary>
        public OnixProductId[] ProductIdentifier { get; set; }

        /// <summary>
        /// An ONIX code which indicates the primary form of a product part.
        /// Mandatory in each occurrence of <see cref="OnixProductPart"/>, and non-repeating.
        /// </summary>
        /// <remarks>Onix List 150</remarks>
        public string ProductForm
        {
            get { return this.productFormField; }
            set { this.productFormField = value; }
        }

        /// <summary>
        /// An ONIX code which provides added detail of the medium and/or format of a product part.
        /// Optional, and repeatable in order to provide multiple additional details.
        /// </summary>
        /// <remarks>Onix List 175</remarks>
        public string[] ProductFormDetail { get; set; }

        /// <summary>
        /// An optional group of data elements which together describe an aspect of product form that is too specific to be covered in the <ProductForm> and <ProductFormDetail> elements.
        /// Repeatable in order to describe different aspects of the form of the product part.
        /// The composite is included here so that it can for example be used to carry consumer protection data related to a product part.
        /// </summary>
        public OnixProductFormFeature[] ProductFormFeature { get; set; }

        /// <summary>
        /// An ONIX code which indicates the type of packaging used for the product part.
        /// Optional, and not repeatable.
        /// </summary>
        /// <remarks>Onix List 80</remarks>
        public string ProductPackaging { get; set; }

        /// <summary>
        /// If product form codes do not adequately describe the contained item, a short text description may be added.
        /// Optional and repeatable.
        /// The language attribute is optional for a single instance of <see cref="ProductFormDescription"/>, but must be included in each instance if <see cref="ProductFormDescription"/> is repeated.
        /// </summary>
        public string[] ProductFormDescription { get; set; }

        /// <summary>
        /// An ONIX code which indicates certain types of content which are closely related to but not strictly an attribute of product form, eg audiobook. Optional and repeatable.
        /// </summary>
        /// <remarks>Onix List 81</remarks>
        public string[] ProductContentType { get; set; }

        /// <summary>
        /// An optional group of data elements which together identify a measurement and the units in which it is expressed; used to specify the overall dimensions of a physical product part including its inner packaging (if any).
        /// Repeatable to provide multiple combinations of dimension and unit.
        /// </summary>
        public OnixMeasure[] Measure { get; set; }

        /// <summary>
        /// When product parts are listed as a specified number of different items in a specified form, without identifying the individual items, <see cref="NumberOfItemsOfThisForm"/> must be used to carry the quantity, even if the number is ‘1’.
        /// Consequently the element is mandatory and non-repeating in an occurrence of the <see cref="OnixProductPart"/> composite if <see cref="NumberOfCopies"/> is not present; and it must not be used if <see cref="ProductIdentifier"/> is present.
        /// </summary>
        public string NumberOfItemsOfThisForm
        {
            get { return this.numOfItemsOfThisFormField; }
            set { this.numOfItemsOfThisFormField = value; }
        }

        /// <summary>
        /// When product parts are listed as a specified number of copies of a single item, usually identified by a <see cref="ProductIdentifier"/>, <see cref="NumberOfCopies"/> must be used to specify the quantity, even if the number is ‘1’.
        /// It must be used when a multiple-item product or pack contains (a) a quantity of a single item; or (b) one of each of several different items (as in a multi-volume set); or (c) one or more of each of several different items (as in a dumpbin carrying copies of two different books, or a classroom pack containing a teacher’s text and twenty student texts).
        /// Consequently the element is mandatory, and non-repeating, in an occurrence of the <see cref="OnixProductPart"/> composite if <see cref="NumberOfItemsOfThisForm"/> is not present.
        /// It is normally accompanied by a <see cref="ProductIdentifier"/>; but in exceptional circumstances, if the sender’s system is unable to provide an identifier at this level, it may be sent with product form coding and without an ID.
        /// </summary>
        public int NumberOfCopies { get; set; }

        /// <summary>
        /// A code identifying the country in which a product part was manufactured, if different product parts were manufactured in different countries.
        /// This information is needed in some countries to meet regulatory requirements.
        /// Optional and non-repeating.
        /// </summary>
        /// <remarks>Onix List 91</remarks>
        public string CountryOfManufacture { get; set; }


        #endregion

        #region Short Tags

        /// <remarks/>
        public string x457
        {
            get { return PrimaryPart; }
            set { PrimaryPart = value; }
        }

        /// <remarks/>
        public string b012
        {
            get { return ProductForm; }
            set { ProductForm = value; }
        }

        /// <remarks/>
        public string x322
        {
            get { return NumberOfItemsOfThisForm; }
            set { NumberOfItemsOfThisForm = value; }
        }

        #endregion
    }
}

