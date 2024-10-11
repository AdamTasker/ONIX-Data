using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace OnixData.Legacy.Lists
{
    public enum OnixList29
    {
        [XmlEnum("01")] OnixAudienceCodes = 1,
        [XmlEnum("02")] Proprietary = 2,
        [XmlEnum("03")] MpaaRating = 3,
        [XmlEnum("04")] BbfcRating = 4,
        [XmlEnum("05")] FskRating = 5,
        [XmlEnum("06")] BtlfAudienceCode = 6,
        [XmlEnum("07")] ElectreAudienceCode = 7,
        [XmlEnum("08")] AneleTipo = 8,
        [XmlEnum("09")] Avi = 9,
        [XmlEnum("10")] UskRating = 10,
        [XmlEnum("11")] Aws = 11,
        [XmlEnum("12")] Schulform = 12,
        [XmlEnum("13")] Bundesland = 13,
        [XmlEnum("14")] Ausbildungsberuf = 14,
        [XmlEnum("15")] SuomalainenKouluasteluokitus = 15,
        [XmlEnum("16")] CbgAgeGuidance = 16,
        [XmlEnum("17")] NielsenBookAudienceCode = 17,
        [XmlEnum("18")] AviRevised = 18,
        [XmlEnum("19")] LexileMeasure = 19,
        [XmlEnum("20")] FryReadabilityScore = 20,
        [XmlEnum("21")] JapaneseChildrensAudienceCode = 21,
        [XmlEnum("22")] OnixAdultAudienceRating = 22,
        [XmlEnum("23")] CommonEuropeanFrameworkForLanguageLearning = 23,
        [XmlEnum("24")] KoreanPublicationEthicsCommissionRating = 24,
        [XmlEnum("25")] IoEBookBand = 25,
        [XmlEnum("26")] FskLehrInfoprogramm = 26,
        [XmlEnum("27")] IntendedAudienceLanguage = 27,
        [XmlEnum("28")] PegiRating = 28,
        [XmlEnum("29")] Gymnasieprogram = 29
    }
}
