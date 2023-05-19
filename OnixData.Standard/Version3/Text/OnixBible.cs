using System.ComponentModel;
using System.Xml.Serialization;

namespace OnixData.Version3.Text
{
    /// <summary>
    /// A group of data elements which together describe features of an edition of the Bible or of a selected Biblical text.
    /// </summary>
    public partial class OnixBible
    {
        /// <summary>
        /// An ONIX code indicating the content of an edition of the Bible or selected Biblical text, for example ‘New Testament’, ‘Apocrypha’, ‘Pentateuch’.
        /// Mandatory in each occurrence of the <see cref="OnixBible"/> composite, and repeatable so that a list such as ‘Old Testament and Apocrypha’ can be expressed.
        /// </summary>
        /// <remarks>Onix List 82</remarks>
        [XmlChoiceIdentifier("BibleContentsChoice")]
        [XmlElement("BibleContents")]
        [XmlElement("b352")]
        public string[] BibleContents { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum BibleContentsEnum { BibleContents, b352 }
        [XmlIgnore, DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public BibleContentsEnum[] BibleContentsChoice
        {
            get
            {
                if (BibleContents == null) return null;
                BibleContentsEnum choice = SerializationSettings.UseShortTags ? BibleContentsEnum.b352 : BibleContentsEnum.BibleContents;
                BibleContentsEnum[] result = new BibleContentsEnum[BibleContents.Length];
                for (int i = 0; i < BibleContents.Length; i++) result[i] = choice;
                return result;
            }
            set { }
        }

        /// <summary>
        /// An ONIX code indicating the version of a Bible or selected Biblical text, for example ‘King James’, ‘Jerusalem’, ‘New American Standard’, ‘Reina Valera’.
        /// Mandatory in each occurrence of the <see cref="OnixBible"/> composite, and repeatable if a work includes text in two or more versions.
        /// </summary>
        /// <remarks>Onix List 83</remarks>
        [XmlChoiceIdentifier("BibleVersionChoice")]
        [XmlElement("BibleVersion")]
        [XmlElement("b353")]
        public string[] BibleVersion { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum BibleVersionEnum { BibleVersion, b353 }
        [XmlIgnore, DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public BibleVersionEnum[] BibleVersionChoice
        {
            get
            {
                if (BibleVersion == null) return null;
                BibleVersionEnum choice = SerializationSettings.UseShortTags ? BibleVersionEnum.b353 : BibleVersionEnum.BibleVersion;
                BibleVersionEnum[] result = new BibleVersionEnum[BibleVersion.Length];
                for (int i = 0; i < BibleVersion.Length; i++) result[i] = choice;
                return result;
            }
            set { }
        }

        /// <summary>
        /// An ONIX code identifying a particular study version of a Bible or selected Biblical text, for example ‘Life Application’.
        /// Optional and non-repeating.
        /// Some study Bibles are available in different editions based on different text versions.
        /// </summary>
        /// <remarks>Onix List 84</remarks>
        [XmlChoiceIdentifier("StudyBibleTypeChoice")]
        [XmlElement("StudyBibleType")]
        [XmlElement("b389")]
        public string StudyBibleType { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum StudyBibleTypeEnum { StudyBibleType, b389 }
        [XmlIgnore, DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public StudyBibleTypeEnum StudyBibleTypeChoice
        {
            get { return SerializationSettings.UseShortTags ? StudyBibleTypeEnum.b389 : StudyBibleTypeEnum.StudyBibleType; }
            set { }
        }

        /// <summary>
        /// An ONIX code indicating the purpose for which a Bible or selected Biblical text is intended, for example ‘Family’, ‘Lectern/pulpit’.
        /// Optional, and repeatable to list multiple purposes.
        /// </summary>
        /// <remarks>Onix List 85</remarks>
        [XmlChoiceIdentifier("BiblePurposeChoice")]
        [XmlElement("BiblePurpose")]
        [XmlElement("b354")]
        public string[] BiblePurpose { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum BiblePurposeEnum { BiblePurpose, b354 }
        [XmlIgnore, DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public BiblePurposeEnum[] BiblePurposeChoice
        {
            get
            {
                if (BiblePurpose == null) return null;
                BiblePurposeEnum choice = SerializationSettings.UseShortTags ? BiblePurposeEnum.b354 : BiblePurposeEnum.BiblePurpose;
                BiblePurposeEnum[] result = new BiblePurposeEnum[BiblePurpose.Length];
                for (int i = 0; i < BiblePurpose.Length; i++) result[i] = choice;
                return result;
            }
            set { }
        }

        /// <summary>
        /// An ONIX code indicating the way in which the content of a Bible or selected Biblical text is organized, for example ‘Chronological’, ‘Chain reference’.
        /// Optional and non-repeating.
        /// </summary>
        /// <remarks>Onix List 86</remarks>
        [XmlChoiceIdentifier("BibleTextOrganizationChoice")]
        [XmlElement("BibleTextOrganization")]
        [XmlElement("b355")]
        public string BibleTextOrganization { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum BibleTextOrganizationEnum { BibleTextOrganization, b355 }
        [XmlIgnore, DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public BibleTextOrganizationEnum BibleTextOrganizationChoice
        {
            get { return SerializationSettings.UseShortTags ? BibleTextOrganizationEnum.b355 : BibleTextOrganizationEnum.BibleTextOrganization; }
            set { }
        }

        /// <summary>
        /// An ONIX code indicating where references are located as part of the content of a Bible or selected Biblical text, for example ‘Center column’.
        /// Optional and non-repeating.
        /// </summary>
        /// <remarks>Onix List 87</remarks>
        [XmlChoiceIdentifier("BibleReferenceLocationChoice")]
        [XmlElement("BibleReferenceLocation")]
        [XmlElement("b356")]
        public string BibleReferenceLocation { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum BibleReferenceLocationEnum { BibleReferenceLocation, b356 }
        [XmlIgnore, DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public BibleReferenceLocationEnum BibleReferenceLocationChoice
        {
            get { return SerializationSettings.UseShortTags ? BibleReferenceLocationEnum.b356 : BibleReferenceLocationEnum.BibleReferenceLocation; }
            set { }
        }

        /// <summary>
        /// An ONIX code specifying a feature of a Bible text not covered elsewhere, eg red letter.
        /// Optional, and repeatable to specify multiple features.
        /// </summary>
        /// <remarks>Onix List 97</remarks>
        [XmlChoiceIdentifier("BibleTextFeatureChoice")]
        [XmlElement("BibleTextFeature")]
        [XmlElement("b357")]
        public string[] BibleTextFeature { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum BibleTextFeatureEnum { BibleTextFeature, b357 }
        [XmlIgnore, DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public BibleTextFeatureEnum[] BibleTextFeatureChoice
        {
            get
            {
                if (BibleTextFeature == null) return null;
                BibleTextFeatureEnum choice = SerializationSettings.UseShortTags ? BibleTextFeatureEnum.b357 : BibleTextFeatureEnum.BibleTextFeature;
                BibleTextFeatureEnum[] result = new BibleTextFeatureEnum[BibleTextFeature.Length];
                for (int i = 0; i < BibleTextFeature.Length; i++) result[i] = choice;
                return result;
            }
            set { }
        }
    }
}