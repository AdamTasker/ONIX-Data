using System.ComponentModel;
using System.Xml.Serialization;
using OnixData.Version3.Lists;
using OnixData.Version3.Xml.Enums;

namespace OnixData.Version3.Text
{
    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public class OnixResourceFeature
    {

        #region Reference Tags

        /// <remarks/>
        [XmlChoiceIdentifier("ResourceFeatureTypeChoice")]
        [XmlElement("ResourceFeatureType")]
        [XmlElement("x438")]
        public OnixList160 ResourceFeatureType { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum ResourceFeatureTypeEnum { ResourceFeatureType, x438 }
        [XmlIgnore]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ResourceFeatureTypeEnum ResourceFeatureTypeChoice
        {
            get { return SerializationSettings.UseShortTags ? ResourceFeatureTypeEnum.x438 : ResourceFeatureTypeEnum.ResourceFeatureType; }
            set { }
        }

        /// <remarks/>
        [XmlChoiceIdentifier("FeatureValueChoice")]
        [XmlElement("FeatureValue")]
        [XmlElement("x439")]
        public string FeatureValue { get; set; }
        [XmlIgnore]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public FeatureValueEnum FeatureValueChoice
        {
            get { return SerializationSettings.UseShortTags ? FeatureValueEnum.x439 : FeatureValueEnum.FeatureValue; }
            set { }
        }

        /// <remarks/>
        [XmlChoiceIdentifier("FeatureNoteChoice")]
        [XmlElement("FeatureNote")]
        [XmlElement("x440")]
        public string[] FeatureNote { get; set; }
        [XmlIgnore]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public FeatureNoteEnum[] FeatureNoteChoice
        {
            get
            {
                if (FeatureNote == null) return null;
                FeatureNoteEnum choice = SerializationSettings.UseShortTags ? FeatureNoteEnum.x440 : FeatureNoteEnum.FeatureNote;
                FeatureNoteEnum[] result = new FeatureNoteEnum[FeatureNote.Length];
                for (int i = 0; i < FeatureNote.Length; i++) result[i] = choice;
                return result;
            }
            set { }
        }

        #endregion
    }
}