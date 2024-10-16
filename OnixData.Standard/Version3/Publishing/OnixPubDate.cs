using System.ComponentModel;
using System.Xml.Serialization;
using OnixData.Version3.Lists;

namespace OnixData.Version3.Publishing
{
    /// <summary>
    /// A group of data elements which together specify a date associated with the publishing of the product.
    /// Optional, but where known, at least a date of publication must be specified either in <see cref="OnixPublishingDetail.PublishingDate"/> (as a ‘global’ pub date) or in <see cref="Market.OnixMarketPublishingDetail.MarketDate"/>.
    /// Other dates related to the publishing of a product can be sent in further repeats of the composite.
    /// </summary>
    public class OnixPubDate : OnixDate
    {

        #region Reference Tags


        /// <summary>
        /// An ONIX code indicating the significance of the date, eg publication date, announcement date, latest reprint date.
        /// Mandatory in each occurrence of the <see cref="OnixPubDate"/> composite, and non-repeating.
        /// </summary>
        /// <remarks>Onix List 163</remarks>
        [XmlChoiceIdentifier("PublishingDateRoleChoice")]
        [XmlElement("PublishingDateRole")]
        [XmlElement("x448")]
        public OnixList163 PublishingDateRole { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum PublishingDateRoleEnum { PublishingDateRole, x448 }
        [XmlIgnore, DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public PublishingDateRoleEnum PublishingDateRoleChoice
        {
            get { return SerializationSettings.UseShortTags ? PublishingDateRoleEnum.x448 : PublishingDateRoleEnum.PublishingDateRole; }
            set { }
        }

        #endregion
    }
}
