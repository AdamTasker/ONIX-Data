using System.Xml.Serialization;

namespace OnixData.Version3.Lists
{
    public enum OnixList156
    {
        /// <summary>
        /// The full text of a review in a third-party publication in any medium
        /// </summary>
        [XmlEnum("01")] Review = 1,
        [XmlEnum("02")] BestsellerList = 2,
        /// <summary>
        /// Other than a review
        /// </summary>
        [XmlEnum("03")] MediaMention = 3,
        /// <summary>
        /// (North America) Inclusion in a program such as ‘Chicago Reads’, ‘Seattle Reads’
        /// </summary>
        [XmlEnum("04")] OneLocalityOneBookProgram = 4,
        /// <summary>
        /// For example a ‘best books of the year’ or ‘25 books you should have read’ list, without regard to their bestseller status
        /// </summary>
        [XmlEnum("05")] CuratedList = 5
    }
}
