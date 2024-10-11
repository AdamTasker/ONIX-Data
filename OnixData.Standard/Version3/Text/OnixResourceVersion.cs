using System;
using System.ComponentModel;
using System.Xml.Serialization;
using OnixData.Version3.Lists;
using OnixData.Version3.Xml.Enums;

namespace OnixData.Version3.Text
{
    public class OnixResourceVersion
    {

        #region Reference Tags

        /// <remarks/>
        [XmlChoiceIdentifier("ResourceFormChoice")]
        [XmlElement("ResourceForm")]
        [XmlElement("x441")]
        public OnixList161 ResourceForm { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum ResourceFormEnum { ResourceForm, x441 }
        [XmlIgnore]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ResourceFormEnum ResourceFormChoice
        {
            get { return SerializationSettings.UseShortTags ? ResourceFormEnum.x441 : ResourceFormEnum.ResourceForm; }
            set { }
        }

        /// <remarks/>
        [XmlChoiceIdentifier("ResourceVersionFeatureChoice")]
        [XmlElement("ResourceVersionFeature")]
        [XmlElement("resourceversionfeature")]
        public OnixResourceVersionFeature[] ResourceVersionFeature { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum ResourceVersionFeatureEnum { ResourceVersionFeature, resourceversionfeature }
        [XmlIgnore]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ResourceVersionFeatureEnum[] ResourceVersionFeatureChoice
        {
            get
            {
                if (ResourceVersionFeature == null) return null;
                ResourceVersionFeatureEnum choice = SerializationSettings.UseShortTags ? ResourceVersionFeatureEnum.resourceversionfeature : ResourceVersionFeatureEnum.ResourceVersionFeature;
                ResourceVersionFeatureEnum[] result = new ResourceVersionFeatureEnum[ResourceVersionFeature.Length];
                for (int i = 0; i < ResourceVersionFeature.Length; i++) result[i] = choice;
                return result;
            }
            set { }
        }

        /// <remarks/>
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

        #endregion
    }
}