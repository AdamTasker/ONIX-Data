using System.ComponentModel;
using System.Xml.Serialization;

namespace OnixData.Version3.Text
{
    public class OnixReviewRating
    {
        [XmlChoiceIdentifier("RatingChoice")]
        [XmlElement("Rating")]
        [XmlElement("x525")]
        public string Rating { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum RatingEnum { Rating, x525 }
        [XmlIgnore]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public RatingEnum RatingChoice
        {
            get { return SerializationSettings.UseShortTags ? RatingEnum.x525 : RatingEnum.Rating; }
            set { }
        }

        [XmlChoiceIdentifier("RatingLimitChoice")]
        [XmlElement("RatingLimit")]
        [XmlElement("x526")]
        public string RatingLimit { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum RatingLimitEnum { RatingLimit, x526 }
        [XmlIgnore]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public RatingLimitEnum RatingLimitChoice
        {
            get { return SerializationSettings.UseShortTags ? RatingLimitEnum.x526 : RatingLimitEnum.RatingLimit; }
            set { }
        }

        [XmlChoiceIdentifier("RatingUnitChoice")]
        [XmlElement("RatingUnit")]
        [XmlElement("x527")]
        public string[] RatingUnit { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum RatingUnitEnum { RatingUnit, x527 }
        [XmlIgnore]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public RatingUnitEnum[] RatingUnitChoice
        {
            get
            {
                if (RatingUnit == null) return null;
                RatingUnitEnum choice = SerializationSettings.UseShortTags ? RatingUnitEnum.x527 : RatingUnitEnum.RatingUnit;
                RatingUnitEnum[] result = new RatingUnitEnum[RatingUnit.Length];
                for (int i = 0; i < RatingUnit.Length; i++) result[i] = choice;
                return result;
            }
            set { }
        }
    }
}
