using System.Xml.Serialization;

namespace OnixData.Version3.Lists
{
    public enum OnixList160
    {
        /// <summary>
        /// Credit that must be displayed when a resource is used (eg ‘Photo Jerry Bauer’ or ‘© Magnum Photo’).
        /// Credit text should be carried in <see cref="Text.OnixResourceFeature.FeatureNote" />
        /// </summary>
        [XmlEnum("01")] RequiredCredit = 1,
        /// <summary>
        /// Explanatory caption that may accompany a resource (eg use to identify an author in a photograph).
        /// Caption text should be carried in <see cref="Text.OnixResourceFeature.FeatureNote" />
        /// </summary>
        [XmlEnum("02")] Caption = 2,
        /// <summary>
        /// Copyright holder of resource (indicative only, as the resource can be used without consultation).
        /// Copyright text should be carried in <see cref="Text.OnixResourceFeature.FeatureNote" />
        /// </summary>
        [XmlEnum("03")] CopyrightHolder = 3,
        /// <summary>
        /// Approximate length in minutes of an audio or video resource.
        /// <see cref="Text.OnixResourceFeature.FeatureValue" /> should contain the length of time as an integer number of minutes
        /// </summary>
        [XmlEnum("04")] LengthInMinutes = 4,
        /// <summary>
        /// Use to link resource to a contributor unambiguously, for example with Resource Content types 04, 11–14 from List 158, particularly where the product has more than a single contributor.
        /// <see cref="Text.OnixResourceFeature.FeatureValue" /> contains the 16-digit ISNI, which must match an ISNI given in an instance of <see cref="OnixContributor" />
        /// </summary>
        [XmlEnum("05")] IsniOfResourceContributor = 5,
        /// <summary>
        /// Use to link resource to a contributor unambiguously, for example with Resource Content types 04, 11–14 from List 158, particularly where the product has more than a single contributor.
        /// <see cref="Text.OnixResourceFeature.FeatureValue" /> contains the proprietary ID, which must match a proprietary ID given in an instance of <see cref="OnixContributor" />
        /// </summary>
        [XmlEnum("06")] ProprietaryIdOfResourceContributor = 6
    }
}
