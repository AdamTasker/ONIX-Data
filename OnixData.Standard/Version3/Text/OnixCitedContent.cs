using OnixData.Version3.Lists;
using OnixData.Version3.Publishing;
using OnixData.Version3.Xml.Enums;
using System.ComponentModel;
using System.Xml.Serialization;

namespace OnixData.Version3.Text
{
    public partial class OnixCitedContent
    {
        [XmlChoiceIdentifier("CitedContentTypeChoice")]
        [XmlElement("CitedContentType")]
        [XmlElement("x430")]
        public OnixList156 CitedContentType { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum CitedContentTypeEnum { CitedContentType, x430 }
        [XmlIgnore]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public CitedContentTypeEnum CitedContentTypeChoice
        {
            get { return SerializationSettings.UseShortTags ? CitedContentTypeEnum.x430 : CitedContentTypeEnum.CitedContentType; }
            set { }
        }

        [XmlChoiceIdentifier("ContentAudienceChoice")]
        [XmlElement("ContentAudience")]
        [XmlElement("x427")]
        public OnixList154[] ContentAudience { get; set; }
        [XmlIgnore]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ContentAudienceEnum[] ContentAudienceChoice
        {
            get
            {
                if (ContentAudience == null) return null;
                ContentAudienceEnum choice = SerializationSettings.UseShortTags ? ContentAudienceEnum.x427 : ContentAudienceEnum.ContentAudience;
                ContentAudienceEnum[] result = new ContentAudienceEnum[ContentAudience.Length];
                for (int i = 0; i < ContentAudience.Length; i++) result[i] = choice;
                return result;
            }
            set { }
        }

        [XmlChoiceIdentifier("TerritoryChoice")]
        [XmlElement("Territory")]
        [XmlElement("territory")]
        public OnixTerritory Territory { get; set; }
        [XmlIgnore]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public TerritoryEnum TerritoryChoice
        {
            get { return SerializationSettings.UseShortTags ? TerritoryEnum.territory : TerritoryEnum.Territory; }
            set { }
        }

        [XmlChoiceIdentifier("SourceTypeChoice")]
        [XmlElement("SourceType")]
        [XmlElement("x431")]
        public OnixList157 SourceType { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum SourceTypeEnum { SourceType, x431 }
        [XmlIgnore]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public SourceTypeEnum SourceTypeChoice
        {
            get { return SerializationSettings.UseShortTags ? SourceTypeEnum.x431 : SourceTypeEnum.SourceType; }
            set { }
        }

        [XmlChoiceIdentifier("ReviewRatingChoice")]
        [XmlElement("ReviewRating")]
        [XmlElement("reviewrating")]
        public OnixReviewRating ReviewRating { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum ReviewRatingEnum { ReviewRating, reviewrating }
        [XmlIgnore]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ReviewRatingEnum ReviewRatingChoice
        {
            get { return SerializationSettings.UseShortTags ? ReviewRatingEnum.reviewrating : ReviewRatingEnum.ReviewRating; }
            set { }
        }

        [XmlChoiceIdentifier("SourceTitleChoice")]
        [XmlElement("SourceTitle")]
        [XmlElement("x428")]
        public string[] SourceTitle { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum SourceTitleEnum { SourceTitle, x428 }
        [XmlIgnore]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public SourceTitleEnum[] SourceTitleChoice
        {
            get
            {
                if (SourceTitle == null) return null;
                SourceTitleEnum choice = SerializationSettings.UseShortTags ? SourceTitleEnum.x428 : SourceTitleEnum.SourceTitle;
                SourceTitleEnum[] result = new SourceTitleEnum[SourceTitle.Length];
                for (int i = 0; i < SourceTitle.Length; i++) result[i] = choice;
                return result;
            }
            set { }
        }

        [XmlChoiceIdentifier("ListNameChoice")]
        [XmlElement("ListName")]
        [XmlElement("x432")]
        public string[] ListName { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum ListNameEnum { ListName, x432 }
        [XmlIgnore]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ListNameEnum[] ListNameChoice
        {
            get
            {
                if (ListName == null) return null;
                ListNameEnum choice = SerializationSettings.UseShortTags ? ListNameEnum.x432 : ListNameEnum.ListName;
                ListNameEnum[] result = new ListNameEnum[ListName.Length];
                for (int i = 0; i < ListName.Length; i++) result[i] = choice;
                return result;
            }
            set { }
        }

        [XmlChoiceIdentifier("PositionOnListChoice")]
        [XmlElement("PositionOnList")]
        [XmlElement("x433")]
        public int PositionOnList { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum PositionOnListEnum { PositionOnList, x433 }
        [XmlIgnore]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public PositionOnListEnum PositionOnListChoice
        {
            get { return SerializationSettings.UseShortTags ? PositionOnListEnum.x433 : PositionOnListEnum.PositionOnList; }
            set { }
        }

        [XmlChoiceIdentifier("CitationNoteChoice")]
        [XmlElement("CitationNote")]
        [XmlElement("x434")]
        public string[] CitationNote { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum CitationNoteEnum { CitationNote, x434 }
        [XmlIgnore]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public CitationNoteEnum[] CitationNoteChoice
        {
            get
            {
                if (CitationNote == null) return null;
                CitationNoteEnum choice = SerializationSettings.UseShortTags ? CitationNoteEnum.x434 : CitationNoteEnum.CitationNote;
                CitationNoteEnum[] result = new CitationNoteEnum[CitationNote.Length];
                for (int i = 0; i < CitationNote.Length; i++) result[i] = choice;
                return result;
            }
            set { }
        }

        [XmlChoiceIdentifier("ResourceLinkChoice")]
        [XmlElement("ResourceLink")]
        [XmlElement("x435")]
        public string[] ResourceLink { get; set; }
        [XmlIgnore]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ResourceLinkEnum[] ResourceLinkChoice
        {
            get
            {
                if (ResourceLink == null) return null;
                ResourceLinkEnum choice = SerializationSettings.UseShortTags ? ResourceLinkEnum.x435 : ResourceLinkEnum.ResourceLink;
                ResourceLinkEnum[] result = new ResourceLinkEnum[ResourceLink.Length];
                for (int i = 0; i < ResourceLink.Length; i++) result[i] = choice;
                return result;
            }
            set { }
        }

        [XmlChoiceIdentifier("ContentDateChoice")]
        [XmlElement("ContentDate")]
        [XmlElement("contentdate")]
        public OnixContentDate[] ContentDate { get; set; }
        [XmlIgnore]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ContentDateEnum[] ContentDateChoice
        {
            get
            {
                if (ContentDate == null) return null;
                ContentDateEnum choice = SerializationSettings.UseShortTags ? ContentDateEnum.contentdate : ContentDateEnum.ContentDate;
                ContentDateEnum[] result = new ContentDateEnum[ContentDate.Length];
                for (int i = 0; i < ContentDate.Length; i++) result[i] = choice;
                return result;
            }
            set { }
        }
    }
}
