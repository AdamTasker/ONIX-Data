using System.Xml.Serialization;

namespace OnixData.Version3.Lists
{
    public enum OnixList154
    {
        [XmlEnum("00")] Unrestricted = 0,
        [XmlEnum("01")] Restricted = 1,
        [XmlEnum("02")] Booktrade = 2,
        [XmlEnum("03")] EndCustomers = 3,
        [XmlEnum("04")] Librarians = 4,
        [XmlEnum("05")] Teachers = 5,
        [XmlEnum("06")] Students = 6,
        [XmlEnum("07")] Press = 7,
        [XmlEnum("08")] ShoppingComparisonService = 8,
        [XmlEnum("09")] SearchEngineIndex = 9,
        [XmlEnum("10")] Bloggers = 10
    }
}
