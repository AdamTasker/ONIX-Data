using System.ComponentModel;
using System.Xml.Serialization;

namespace OnixData.Version3.Header
{
    /// <summary>
    /// A group of data elements which together define an identifier of the sender.
    /// </summary>
    [XmlType(AnonymousType = true)]
    public partial class OnixHeaderSenderIdentifier : OnixIdentifier
    {
        #region Reference Tags

        /// <summary>
        /// An ONIX code identifying a scheme from which an identifier in the <see cref="IDValue"/> element is taken.
        /// Mandatory in each occurrence of the <see cref="OnixHeaderSenderIdentifier"/> composite, and non-repeating.
        /// </summary>
        /// <remarks>Onix List 44</remarks>
        [XmlChoiceIdentifier("SenderIDTypeChoice")]
        [XmlElement("SenderIDType")]
        [XmlElement("m379")]
        public string SenderIDType { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum SenderIDTypeEnum { SenderIDType, m379 }
        [XmlIgnore]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public SenderIDTypeEnum SenderIDTypeChoice
        {
            get { return SerializationSettings.UseShortTags ? SenderIDTypeEnum.m379 : SenderIDTypeEnum.SenderIDType; }
            set { }
        }

        #endregion
    }
}

