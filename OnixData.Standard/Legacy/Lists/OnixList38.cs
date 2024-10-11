using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace OnixData.Legacy.Lists
{
  public enum OnixList38
  {
    [XmlEnum("01")] WholeProduct = 1,
    [XmlEnum("02")] ApplicationSoftwareDemo = 2,
    [XmlEnum("03")] ImageWholeCover = 3,
    [XmlEnum("04")] ImageFrontCover = 4,
    [XmlEnum("05")] ImageWholeCoverHighQuality = 5,
    [XmlEnum("06")] ImageFrontCoverHighQuality = 6,
    [XmlEnum("07")] ImageFrontCoverThumbnail = 7,
    [XmlEnum("08")] ImageContributors = 8,
    [XmlEnum("10")] ImageForSeries = 10,
    [XmlEnum("11")] ImageSeriesLogo = 11,
    [XmlEnum("12")] ImageProductLogo = 12,
    [XmlEnum("16")] ImageMasterBrandLogo = 16,
    [XmlEnum("17")] ImagePublisherLogo = 17,
    [XmlEnum("18")] ImageImprintLogo = 18,
    [XmlEnum("22")] ImageTableOfContents = 22,
    [XmlEnum("23")] ImageSampleContent = 23,
    [XmlEnum("24")] ImageBackCover = 24,
    [XmlEnum("25")] ImageBackCoverHighQuality = 25,
    [XmlEnum("26")] ImageBackCoverThumbnail = 26,
    [XmlEnum("27")] ImageCoverMaterial = 27,
    [XmlEnum("28")] ImagePromotionalMaterial = 28,
    [XmlEnum("29")] VideoSegmentUnspecified = 29,
    [XmlEnum("30")] AudioSegmentUnspecified = 30,
    [XmlEnum("31")] VideoAuthorPresentationOrCommentary = 31,
    [XmlEnum("32")] VideoAuthorInterview = 32,
    [XmlEnum("33")] VideoAuthorReading = 33,
    [XmlEnum("34")] VideoCoverMaterial = 34,
    [XmlEnum("35")] VideoSampleContent = 35,
    [XmlEnum("36")] VideoPromotionalMaterial = 36,
    [XmlEnum("37")] VideoReview = 37,
    [XmlEnum("38")] VideoOtherCommentaryOrDiscussion = 38,
    [XmlEnum("41")] AudioAuthorPresentationOrCommentary = 41,
    [XmlEnum("42")] AudioAuthorInterview = 42,
    [XmlEnum("43")] AudioAuthorReading = 43,
    [XmlEnum("44")] AudioSampleContent = 44,
    [XmlEnum("45")] AudioPromotionalMaterial = 45,
    [XmlEnum("46")] AudioReview = 46,
    [XmlEnum("47")] AudioOtherCommentaryOrDiscussion = 47,
    [XmlEnum("51")] ApplicationSampleContent = 51,
    [XmlEnum("52")] ApplicationPromotionalMaterial = 52
  }
}
