using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using OnixData.Legacy.Lists;

namespace OnixData.Legacy
{
    /// <remarks/>
    [XmlType(AnonymousType = true)]
    public partial class OnixLegacyMediaFile
    {
        #region Constants

        private readonly OnixList38[] IMAGES =
        {
            OnixList38.ImageBackCover,
            OnixList38.ImageBackCoverHighQuality,
            OnixList38.ImageBackCoverThumbnail,
            OnixList38.ImageContributors,
            OnixList38.ImageCoverMaterial,
            OnixList38.ImageForSeries,
            OnixList38.ImageFrontCover,
            OnixList38.ImageFrontCoverHighQuality,
            OnixList38.ImageFrontCoverThumbnail,
            OnixList38.ImageImprintLogo,
            OnixList38.ImageMasterBrandLogo,
            OnixList38.ImageProductLogo,
            OnixList38.ImagePromotionalMaterial,
            OnixList38.ImagePublisherLogo,
            OnixList38.ImageSampleContent,
            OnixList38.ImageSeriesLogo,
            OnixList38.ImageTableOfContents,
            OnixList38.ImageWholeCover,
            OnixList38.ImageWholeCoverHighQuality
        };

        private readonly OnixList38[] THUMBNAILS =
        {
            OnixList38.ImageBackCoverThumbnail,
            OnixList38.ImageFrontCoverThumbnail
        };

        private readonly OnixList38[] HIGHQUALITY =
        {
            OnixList38.ImageBackCoverHighQuality,
            OnixList38.ImageFrontCoverHighQuality,
            OnixList38.ImageWholeCoverHighQuality
        };

        #endregion


        #region Helpers

        public bool IsAnImage => IMAGES.Contains(MediaFileTypeCode);
        public bool IsThumbnail => THUMBNAILS.Contains(MediaFileTypeCode);
        public bool IsHighQuality => HIGHQUALITY.Contains(MediaFileTypeCode);
        public string Identifier
        {
            get
            {
                switch (MediaFileTypeCode)
                {
                    case OnixList38.ImageBackCover:
                    case OnixList38.ImageBackCoverHighQuality:
                    case OnixList38.ImageBackCoverThumbnail:
                        return ".back";
                    case OnixList38.ImageFrontCover:
                    case OnixList38.ImageFrontCoverHighQuality:
                    case OnixList38.ImageFrontCoverThumbnail:
                        return "";
                    case OnixList38.ImageWholeCover:
                    case OnixList38.ImageWholeCoverHighQuality:
                        return ".whole";
                    case OnixList38.ImageTableOfContents:
                        return ".toc";
                    case OnixList38.ImageSampleContent:
                        return ".in";
                    default:
                        return null;
                }
            }
        }
        #endregion


        #region Reference Tags

        [XmlChoiceIdentifier("MediaFileTypeCodeChoice")]
        [XmlElement("MediaFileTypeCode")]
        [XmlElement("f114")]
        public OnixList38 MediaFileTypeCode { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum MediaFileTypeCodeEnum { MediaFileTypeCode, f114 }
        [XmlIgnore]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public MediaFileTypeCodeEnum MediaFileTypeCodeChoice
        {
          get { return SerializationSettings.UseShortTags ? MediaFileTypeCodeEnum.f114 : MediaFileTypeCodeEnum.MediaFileTypeCode; }
          set { }
        }


        [XmlChoiceIdentifier("MediaFileFormatCodeChoice")]
        [XmlElement("MediaFileFormatCode")]
        [XmlElement("f115")]
        public OnixList39 MediaFileFormatCode { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum MediaFileFormatCodeEnum { MediaFileFormatCode, f115 }
        [XmlIgnore]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public MediaFileFormatCodeEnum MediaFileFormatCodeChoice
        {
          get { return SerializationSettings.UseShortTags ? MediaFileFormatCodeEnum.f115 : MediaFileFormatCodeEnum.MediaFileFormatCode; }
          set { }
        }

        [XmlChoiceIdentifier("MediaFileLinkTypeCodeChoice")]
        [XmlElement("MediaFileLinkTypeCode")]
        [XmlElement("f116")]
        public OnixList40 MediaFileLinkTypeCode { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum MediaFileLinkTypeCodeEnum { MediaFileLinkTypeCode, f116 }
        [XmlIgnore]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public MediaFileLinkTypeCodeEnum MediaFileLinkTypeCodeChoice
        {
          get { return SerializationSettings.UseShortTags ? MediaFileLinkTypeCodeEnum.f116 : MediaFileLinkTypeCodeEnum.MediaFileLinkTypeCode; }
          set { }
        }

        [XmlChoiceIdentifier("MediaFileLinkChoice")]
        [XmlElement("MediaFileLink")]
        [XmlElement("f117")]
        public string MediaFileLink { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum MediaFileLinkEnum {  MediaFileLink, f117 }
        [XmlIgnore]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public MediaFileLinkEnum MediaFileLinkChoice
        {
          get { return SerializationSettings.UseShortTags ? MediaFileLinkEnum.f117 : MediaFileLinkEnum.MediaFileLink; }
          set { }
        }

        #endregion
    }
}
