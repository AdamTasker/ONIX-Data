using System;
using System.Collections.Generic;
using System.Text;

namespace OnixData.Version3
{
    /// <summary>
    /// An optional group of data elements which together describe an aspect of product form that is too specific to be covered in the <see cref="OnixProduct.ProductForm"/> and <see cref="OnixProduct.ProductFormDetail"/> elements.
    /// </summary>
    public partial class OnixProductFormFeature
    {
        /// <summary>
        /// An ONIX code which specifies the feature described by an instance of the <see cref="OnixProductFormFeature"/> composite, eg binding color.
        /// Mandatory in each occurrence of the composite, and non-repeating.
        /// </summary>
        public string ProductFormFeatureType { get; set; }

        /// <summary>
        /// A controlled value that describes a product form feature.
        /// Presence or absence of this element depends on the <see cref="ProductFormFeatureType"/>, since some product form features (eg thumb index) do not require an accompanying value, while others (eg text font) require free text in <see cref="ProductFormFeatureDescription"/>; and others may have both code and free text.
        /// Non-repeating.
        /// </summary>
        /// <remarks>
        /// Dependent on the scheme specified in <see cref="ProductFormFeatureType"/>
        /// <para>For cover binding color, see Onix List 98</para>
        /// <para>For page edge color, see Onix List 98</para>
        /// <para>For special cover material, see Onix List 99</para>
        /// <para>For text font, use free text in <see cref="ProductFormFeatureDescription"/>, which may include font name and/or size</para>
        /// <para>For DVD region codes, see Onix List 76</para>
        /// <para>For CPSIA choking hazard warning, see Onix List 143</para>
        /// <para>For EU Toy Safety hazard warnings, see Onix List 184</para>
        /// <para>For various paper certification schemes (FSC, PEFC etc), see Onix List 79. <see cref="ProductFormFeatureType"/> identifies the certification scheme, and <see cref="ProductFormFeatureValue"/> may carry a Chain of Custody(COC) number. For certified recycled paper, a separate repeat of the <see cref="OnixProductFormFeature"/> composite may carry the percent post-consumer waste used in a product</para>
        /// <para>For specific versions of common e-publication file formats, (eg the IDPF’s EPUB 2.0.1), use <see cref="ProductFormFeatureType"/> code 15 and a value from Onix List 220. For e-publication formats not covered in Onix List 220, use <see cref="ProductFormFeatureType"/> code 10 and a period-separated list of numbers (eg ‘7’, ‘1.5’ or ‘3.10.7’) in <see cref="ProductFormFeatureValue"/></para>
        /// <para>For required operating system for a digital product, see Onix List 176. You should in addition include operating system version information (major and minor version numbers as necessary, eg ‘10.6.4 or later’ for Mac OS 10.6.4, ‘7 SP1 or later’ for Windows 7 Service Pack 1) in <see cref="ProductFormFeatureDescription"/>. For other system requirements for a digital product (eg specific memory, storage or other hardware requirements), use free text in <see cref="ProductFormFeatureDescription"/> within a separate repeat of the <see cref="OnixProductFormFeature"/> composite</para>
        /// <para>For e-publication accessibility features for print-impaired readers, see Onix List 196</para>
        /// <para>Further features with corresponding code lists may be added from time to time without a re-issue of this document – see the latest release of Onix List 79</para>
        /// </remarks>
        public string ProductFormFeatureValue { get; set; }

        /// <summary>
        /// If the <see cref="ProductFormFeatureType"/> requires free text rather than a code value, or if the code in <see cref="ProductFormFeatureValue"/> does not adequately describe the feature, a short text description may be added.
        /// Optional, and repeatable to provide parallel descriptive text in multiple languages.
        /// The language attribute is optional for a single instance of <see cref="ProductFormFeatureDescription"/>, but must be included in each instance if <see cref="ProductFormFeatureDescription"/> is repeated.
        /// </summary>
        public string[] ProductFormFeatureDescription { get; set; }
    }
}
