using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace OnixData.Legacy.Lists
{
    public enum OnixList12
    {
        [XmlEnum("01")] UkOpenMarketEdition = 1,
        [XmlEnum("02")] AirportEdition = 2,
        [XmlEnum("03")] Sonderausgabe = 3,
        [XmlEnum("04")] PocketPaperback = 4,
        [XmlEnum("05")] InternationalEditionUS = 5,
        [XmlEnum("06")] LibraryAudioEdition = 6,
        [XmlEnum("07")] UsOpenMarketEdition = 7,
        [XmlEnum("08")] LivreScolaireDeclareParLediteur = 8,
        [XmlEnum("09")] LivreScolaireNonSpecifie = 9,
        [XmlEnum("10")] SupplementToNewspaper = 10,
        [XmlEnum("11")] PrecioLibreTextbook = 11,
        [XmlEnum("12")] NewsOutletEdition = 12,
        [XmlEnum("13")] UsTextbook = 13,
        [XmlEnum("14")] EbookShort = 14
    }
}
