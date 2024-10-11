using System.Xml.Serialization;

namespace OnixData.Version3.Lists
{
    public enum OnixList157
    {
        [XmlEnum("01")] PrintedMedia = 1,
        [XmlEnum("02")] Website = 2,
        [XmlEnum("03")] Radio = 3,
        [XmlEnum("04")] TV = 4
    }
}
