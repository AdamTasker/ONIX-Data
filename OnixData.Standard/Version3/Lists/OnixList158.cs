using System.Xml.Serialization;

namespace OnixData.Version3.Lists
{
    public enum OnixList158
    {
        /// <summary>
        /// 2D
        /// </summary>
        [XmlEnum("01")] FrontCover = 1,
        /// <summary>
        /// 2D
        /// </summary>
        [XmlEnum("02")] BackCover = 2,
        /// <summary>
        /// Not limited to front or back, including 3D perspective
        /// </summary>
        [XmlEnum("03")] CoverOrPack = 3,
        /// <summary>
        /// Photograph or portrait of contributor(s)
        /// </summary>
        [XmlEnum("04")] ContributorPicture = 4,
        [XmlEnum("05")] SeriesImageOrArtwork = 5,
        [XmlEnum("06")] SeriesLogo = 6,
        /// <summary>
        /// For example, an isolated image from the front cover (without text), image of a completed jigsaw
        /// </summary>
        [XmlEnum("07")] ProductImageOrArtwork = 7,
        [XmlEnum("08")] ProductLogo = 8,
        [XmlEnum("09")] PublisherLogo = 9,
        [XmlEnum("10")] ImprintLogo = 10,
        [XmlEnum("11")] ContributorInterview = 11,
        /// <summary>
        /// Contributor presentation and/or commentary
        /// </summary>
        [XmlEnum("12")] ContributorPresentation = 12,
        [XmlEnum("13")] ContributorReading = 13,
        /// <summary>
        /// Link to a schedule in iCalendar format
        /// </summary>
        [XmlEnum("14")] ContributorEventSchedule = 14,
        /// <summary>
        /// For example: a short excerpt, sample text or a complete sample chapter, page images, screenshots etc
        /// </summary>
        [XmlEnum("15")] SampleContent = 15,
        /// <summary>
        /// A ‘look inside’ feature presented as a small embeddable application
        /// </summary>
        [XmlEnum("16")] Widget = 16,
        /// <summary>
        /// Review text held in a separate downloadable file, not in the ONIX record.
        /// Equivalent of code 06 in List 153. Use the <see cref="Text.OnixCollateralDetail.TextContent" /> composite for review quotes carried in the ONIX record.
        /// Use the <see cref="Text.OnixCollateralDetail.CitedContent" /> composite for a third-party review which is referenced from the ONIX record.
        /// Use <see cref="Text.OnixSupportingResource" /> for review text offered as a separate file resource for reproduction as part of promotional material for the product
        /// </summary>
        [XmlEnum("17")] Review = 17,
        [XmlEnum("18")] OtherCommentaryOrDiscussion = 18,
        [XmlEnum("19")] ReadingGroupGuide = 19,
        /// <summary>
        /// Incuding associated teacher / instructor resources
        /// </summary>
        [XmlEnum("20")] TeachersGuide = 20,
        /// <summary>
        /// Feature article provided by publisher
        /// </summary>
        [XmlEnum("21")] FeatureArticle = 21,
        /// <summary>
        /// Fictional character ‘interview’
        /// </summary>
        [XmlEnum("22")] CharacterInterview = 22,
        [XmlEnum("23")] WallpaperOrScreensaver = 23,
        [XmlEnum("24")] PressRelease = 24,
        /// <summary>
        /// A table of contents held in a separate downloadable file, not in the ONIX record. Equivalent of code 04 in List 153.
        /// Use the <see cref="Text.OnixCollateralDetail.TextContent" /> composite for a table of contents carried in the ONIX record.
        /// Use <see cref="Text.OnixSupportingResource" /> for text offered as a separate file resource
        /// </summary>
        [XmlEnum("25")] TableOfContents = 25,
        /// <summary>
        /// A promotional video (or audio), similar to a movie trailer (sometimes referred to as a ‘book trailer’)
        /// </summary>
        [XmlEnum("26")] Trailer = 26,
        /// <summary>
        /// Intended ONLY for transitional use, where ONIX 2.1 records referencing existing thumbnail assets of unknown pixel size are being re-expressed in ONIX 3.0.
        /// Use code 01 for all new cover assets, and where the pixel size of older assets is known
        /// </summary>
        [XmlEnum("27")] CoverThumbnail = 27,
        /// <summary>
        /// The full content of the product (or the product itself), supplied for example to support full-text search or indexing
        /// </summary>
        [XmlEnum("28")] FullContent = 28,
        /// <summary>
        /// Includes cover, back cover, spine and – where appropriate – any flaps
        /// </summary>
        [XmlEnum("29")] FullCover = 29,
        [XmlEnum("30")] MasterBrandLogo = 30,
        /// <summary>
        /// Descriptive text in a separate downloadable file, not in the ONIX record. Equivalent of code 03 in List 153.
        /// Use the <see cref="Text.OnixCollateralDetail.TextContent" /> composite for descriptions carried in the ONIX record.
        /// Use <see cref="Text.OnixSupportingResource" /> for text offered as a separate file resource for reproduction as part of promotional material for the product
        /// </summary>
        [XmlEnum("31")] Description = 31,
        /// <summary>
        /// Index text held in a separate downloadable file, not in the ONIX record. Equivalent of code 15 in List 153.
        /// Use the <see cref="Text.OnixCollateralDetail.TextContent" /> composite for index text carried in the ONIX record.
        /// Use <see cref="Text.OnixSupportingResource" /> for an index offered as a separate file resource
        /// </summary>
        [XmlEnum("32")] Index = 32,
        /// <summary>
        /// Including associated student / learner resources
        /// </summary>
        [XmlEnum("33")] StudentsGuide = 33,
        /// <summary>
        /// For example a PDF or other digital representation of a publisher’s ‘new titles’ or range catalogue
        /// </summary>
        [XmlEnum("34")] PublishersCatalogue = 34,
        /// <summary>
        /// For example a banner ad for the product. Pixel dimensions should typically be included in <see cref="Text.OnixResourceVersionFeature" />
        /// </summary>
        [XmlEnum("35")] OnlineAdvertisementPanel = 35,
        /// <summary>
        /// German ‘Búhnenbild’
        /// </summary>
        [XmlEnum("36")] OnlineAdvertisementPage = 36,
        /// <summary>
        /// For example, posters, logos, banners, advertising templates for use in connection with a promotional event
        /// </summary>
        [XmlEnum("37")] PromotionalEventMaterial = 37,
        /// <summary>
        /// Availability of a digital review or digital proof copy, may be limited to authorised users or account holders
        /// </summary>
        [XmlEnum("38")] DigitalReviewCopy = 38,
        /// <summary>
        /// For example, video showing how to use the product
        /// </summary>
        [XmlEnum("39")] InstructionalMaterial = 39,
        [XmlEnum("40")] Errata = 40,
        /// <summary>
        /// Introduction, preface or other preliminary material in a separate resource file
        /// </summary>
        [XmlEnum("41")] Introduction = 41,
        /// <summary>
        /// Descriptive material in a separate resource file, not in the ONIX record. Equivalent of code 17 in List 153.
        /// Use the <see cref="Text.OnixCollateralDetail.TextContent" /> composite for collection descriptions carried in the ONIX record.
        /// Use <see cref="Text.OnixSupportingResource" /> for material (which need not be solely only) offered as a separate file resource for reproduction as part of promotional material for the product and collection
        /// </summary>
        [XmlEnum("42")] CollectionDescription = 42,
        /// <summary>
        /// Complete list of books by the author(s), supplied as a separate resource file
        /// </summary>
        [XmlEnum("43")] Bibliography = 43,
        /// <summary>
        /// Formal summary of content (normally used with academic and scholarly content only)
        /// </summary>
        [XmlEnum("44")] Abstract = 44,
        /// <summary>
        /// Image that may be used for promotional purposes in place of a front cover, ONLY where the front cover itself cannot be provided or used for any reason.
        /// Typically, holding images may comprise logos, artwork or an unfinished front cover image. Senders should ensure removal of the holding image from the record as soon as a cover image is available.
        /// Recipients must ensure replacement of the holding image with the cover image when it is supplied
        /// </summary>
        [XmlEnum("45")] CoverHoldingImage = 45,
        /// <summary>
        /// Eg for a game, kit
        /// </summary>
        [XmlEnum("46")] RulesOrInstructions = 46,
        /// <summary>
        /// Link to a license covering permitted usage of the product content. Deprecated in favor of <see cref="OnixDescriptiveDetail.EpubLicense" />.
        /// This was a temporary workaround in ONIX 3.0, and use of <see cref="OnixDescriptiveDetail.EpubLicense" /> is strongly preferred
        /// </summary>
        [XmlEnum("99")] License = 99
    }
}
