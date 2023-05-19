using System.ComponentModel;
using System.Xml.Serialization;

namespace OnixData.Version3.Text
{
    /// <summary>
    /// A group of data elements which together describe features of the content of an edition of a religious text, and intended to meet the special needs of religious publishers and booksellers.
    /// The <see cref="OnixReligiousText"/> composite may carry either a <see cref="Bible"/> composite or a <see cref="ReligiousTextIdentifier"/> element accompanied by multiple repeats of the <see cref="ReligiousTextFeature"/> composite.
    /// This approach is adopted to enable other devotional texts to be included if need arises without requiring a new ONIX release.
    /// </summary>
    public partial class OnixReligiousText
    {
        /// <summary>
        /// A group of data elements which together describe features of an edition of the Bible or of a selected Biblical text.
        /// Mandatory in each occurrence of the <see cref="OnixReligiousText"/> composite that does not include a <see cref="ReligiousTextIdentifier"/> element, and non-repeating.
        /// </summary>
        [XmlChoiceIdentifier("BibleChoice")]
        [XmlElement("Bible")]
        [XmlElement("bible")]
        public OnixBible Bible { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum BibleEnum { Bible, bible }
        [XmlIgnore, DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public BibleEnum BibleChoice
        {
            get { return SerializationSettings.UseShortTags ? BibleEnum.bible : BibleEnum.Bible; }
            set { }
        }

        /// <summary>
        /// An ONIX code indicating a religious text other than the Bible.
        /// Mandatory in each occurrence of the <see cref="OnixReligiousText"/> composite that does not include a <see cref="Bible"/> composite, and non-repeating.
        /// </summary>
        /// <remarks>Onix List 88</remarks>
        [XmlChoiceIdentifier("ReligiousTextIdentifierChoice")]
        [XmlElement("ReligiousTextIdentifier")]
        [XmlElement("b376")]
        public string ReligiousTextIdentifier { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum ReligiousTextIdentifierEnum { ReligiousTextIdentifier, b376 }
        [XmlIgnore, DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ReligiousTextIdentifierEnum ReligiousTextIdentifierChoice
        {
            get { return SerializationSettings.UseShortTags ? ReligiousTextIdentifierEnum.b376 : ReligiousTextIdentifierEnum.ReligiousTextIdentifier; }
            set { }
        }

        /// <summary>
        /// A repeatable group of data elements which together specify and describe a feature of a religious text.
        /// Mandatory if and only if <see cref="ReligiousTextIdentifier"/> is present.
        /// </summary>
        [XmlChoiceIdentifier("ReligiousTextFeatureChoice")]
        [XmlElement("ReligiousTextFeature")]
        [XmlElement("religioustextfeature")]
        public OnixReligiousTextFeature[] ReligiousTextFeature { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum ReligiousTextFeatureEnum { ReligiousTextFeature, religioustextfeature }
        [XmlIgnore, DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ReligiousTextFeatureEnum[] ReligiousTextFeatureChoice
        {
            get
            {
                if (ReligiousTextFeature == null) return null;
                ReligiousTextFeatureEnum choice = SerializationSettings.UseShortTags ? ReligiousTextFeatureEnum.religioustextfeature : ReligiousTextFeatureEnum.ReligiousTextFeature;
                ReligiousTextFeatureEnum[] result = new ReligiousTextFeatureEnum[ReligiousTextFeature.Length];
                for (int i = 0; i < ReligiousTextFeature.Length; i++) result[i] = choice;
                return result;
            }
            set { }
        }
    }
}
