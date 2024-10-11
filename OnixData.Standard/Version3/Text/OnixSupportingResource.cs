using System;
using System.ComponentModel;
using System.Xml.Serialization;
using OnixData.Version3.Lists;
using OnixData.Version3.Publishing;
using OnixData.Version3.Xml.Enums;

namespace OnixData.Version3.Text
{
    /// <remarks/>
    [XmlType(AnonymousType = true)]
    public class OnixSupportingResource
    {

        #region Helpers

        public bool IsAnImage => ResourceMode == OnixList159.Image;
        public string Identifier
        {
            get
            {
                switch (ResourceContentType)
                {
                    case OnixList158.BackCover:
                        return ".back";
                    case OnixList158.FrontCover:
                    case OnixList158.CoverThumbnail:
                        return "";
                    case OnixList158.CoverOrPack:
                    case OnixList158.FullCover:
                        return ".whole";
                    case OnixList158.TableOfContents:
                        return ".toc";
                    case OnixList158.SampleContent:
                        return ".in";
                    default:
                        return null;
                }
            }
        }
        #endregion

        #region Reference Tags

        /// <remarks/>
        [XmlChoiceIdentifier("ResourceContentTypeChoice")]
        [XmlElement("ResourceContentType")]
        [XmlElement("x436")]
        public OnixList158 ResourceContentType { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum ResourceContentTypeEnum { ResourceContentType, x436 }
        [XmlIgnore]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ResourceContentTypeEnum ResourceContentTypeChoice
        {
            get { return SerializationSettings.UseShortTags ? ResourceContentTypeEnum.x436 : ResourceContentTypeEnum.ResourceContentType; }
            set { }
        }

        /// <remarks/>
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

        /// <remarks/>
        [XmlChoiceIdentifier("ResourceModeChoice")]
        [XmlElement("ResourceMode")]
        [XmlElement("x437")]
        public OnixList159 ResourceMode { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum ResourceModeEnum { ResourceMode, x437 }
        [XmlIgnore]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ResourceModeEnum ResourceModeChoice
        {
            get { return SerializationSettings.UseShortTags ? ResourceModeEnum.x437 : ResourceModeEnum.ResourceMode; }
            set { }
        }

        /// <remarks/>
        [XmlChoiceIdentifier("ResourceFeatureChoice")]
        [XmlElement("ResourceFeature")]
        [XmlElement("resourcefeature")]
        public OnixResourceFeature[] ResourceFeature { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum ResourceFeatureEnum { ResourceFeature, resourcefeature }
        [XmlIgnore]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ResourceFeatureEnum[] ResourceFeatureChoice
        {
            get
            {
                if (ResourceFeature == null) return null;
                ResourceFeatureEnum choice = SerializationSettings.UseShortTags ? ResourceFeatureEnum.resourcefeature : ResourceFeatureEnum.ResourceFeature;
                ResourceFeatureEnum[] result = new ResourceFeatureEnum[ResourceFeature.Length];
                for (int i = 0; i < ResourceFeature.Length; i++) result[i] = choice;
                return result;
            }
            set { }
        }

        /// <remarks/>
        [XmlChoiceIdentifier("ResourceVersionChoice")]
        [XmlElement("ResourceVersion")]
        [XmlElement("resourceversion")]
        public OnixResourceVersion[] ResourceVersion { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum ResourceVersionEnum { ResourceVersion, resourceversion }
        [XmlIgnore]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ResourceVersionEnum[] ResourceVersionChoice
        {
            get
            {
                if (ResourceVersion == null) return null;
                ResourceVersionEnum choice = SerializationSettings.UseShortTags ? ResourceVersionEnum.resourceversion : ResourceVersionEnum.ResourceVersion;
                ResourceVersionEnum[] result = new ResourceVersionEnum[ResourceVersion.Length];
                for (int i = 0; i < ResourceVersion.Length; i++) result[i] = choice;
                return result;
            }
            set { }
        }

        #endregion
    }
}