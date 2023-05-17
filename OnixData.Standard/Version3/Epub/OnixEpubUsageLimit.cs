using System.ComponentModel;
using System.Xml.Serialization;

namespace OnixData.Version3.Epub
{
    /// <summary>
    /// An group of data elements which together specify a quantitative limit on a particular type of usage of a digital product.
    /// </summary>
    [XmlType(AnonymousType = true)]
    public class OnixEpubUsageLimit
    {

        #region Reference Tags

        /// <summary>
        /// A numeric value representing the maximum permitted quantity of a particular type of usage.
        /// Mandatory in each occurrence of the <see cref="OnixEpubUsageLimit"/> composite, and non-repeating.
        /// </summary>
        [XmlChoiceIdentifier("QuantityChoice")]
        [XmlElement("Quantity")]
        [XmlElement("x320")]
        public string Quantity { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum QuantityEnum { Quantity, x320 }
        [XmlIgnore, DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public QuantityEnum QuantityChoice
        {
            get { return SerializationSettings.UseShortTags ? QuantityEnum.x320 : QuantityEnum.Quantity; }
            set { }
        }

        /// <summary>
        /// An ONIX code for a unit in which a permitted usage quantity is stated.
        /// Mandatory in each occurrence of the <see cref="OnixEpubUsageLimit"/> composite, and non-repeating.
        /// </summary>
        /// <remarks>Onix List 147</remarks>
        [XmlChoiceIdentifier("EpubUsageUnitChoice")]
        [XmlElement("EpubUsageUnit")]
        [XmlElement("x321")]
        public string EpubUsageUnit { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum EpubUsageUnitEnum { EpubUsageUnit, x321 }
        [XmlIgnore, DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public EpubUsageUnitEnum EpubUsageUnitChoice
        {
            get { return SerializationSettings.UseShortTags ? EpubUsageUnitEnum.x321 : EpubUsageUnitEnum.EpubUsageUnit; }
            set { }
        }

        #endregion
    }
}