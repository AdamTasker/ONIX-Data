using System;
using System.ComponentModel;
using System.Xml.Serialization;
using OnixData.Version3.Xml.Enums;

namespace OnixData.Version3.Text
{
    public partial class OnixCollateralDetail
    {

        #region Reference Tags

        /// <remarks/>
        [XmlChoiceIdentifier("TextContentChoice")]
        [XmlElement("TextContent")]
        [XmlElement("textcontent")]
        public OnixTextContent[] TextContent { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum TextContentEnum { TextContent, textcontent }
        [XmlIgnore]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public TextContentEnum[] TextContentChoice
        {
            get
            {
                if (TextContent == null) return null;
                TextContentEnum choice = SerializationSettings.UseShortTags ? TextContentEnum.textcontent : TextContentEnum.TextContent;
                TextContentEnum[] result = new TextContentEnum[TextContent.Length];
                for (int i = 0; i < TextContent.Length; i++) result[i] = choice;
                return result;
            }
            set { }
        }

        [XmlChoiceIdentifier("CitedContentChoice")]
        [XmlElement("CitedContent")]
        [XmlElement("citedcontent")]
        public OnixCitedContent[] CitedContent { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum CitedContentEnum { CitedContent, citedcontent }
        [XmlIgnore]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public CitedContentEnum[] CitedContentChoice
        {
            get
            {
                if (CitedContent == null) return null;
                CitedContentEnum choice = SerializationSettings.UseShortTags ? CitedContentEnum.citedcontent : CitedContentEnum.CitedContent;
                CitedContentEnum[] result = new CitedContentEnum[CitedContent.Length];
                for (int i = 0; i < CitedContent.Length; i++) result[i] = choice;
                return result;
            }
            set { }
        }

        /// <remarks/>
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

        /// <remarks/>
        [XmlChoiceIdentifier("SupportingResourceChoice")]
        [XmlElement("SupportingResource")]
        [XmlElement("supportingresource")]
        public OnixSupportingResource[] SupportingResource { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum SupportingResourceEnum { SupportingResource, supportingresource }
        [XmlIgnore]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public SupportingResourceEnum[] SupportingResourceChoice
        {
            get
            {
                if (SupportingResource == null) return null;
                SupportingResourceEnum choice = SerializationSettings.UseShortTags ? SupportingResourceEnum.supportingresource : SupportingResourceEnum.SupportingResource;
                SupportingResourceEnum[] result = new SupportingResourceEnum[SupportingResource.Length];
                for (int i = 0; i < SupportingResource.Length; i++) result[i] = choice;
                return result;
            }
            set { }
        }

        #endregion
    }

}
