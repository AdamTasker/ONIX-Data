using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace OnixData.Legacy.Lists
{
    public enum OnixList10
    {
        [XmlEnum("000")] EpublicationContentPackage = 0,
        [XmlEnum("001")] HTML = 1,
        [XmlEnum("002")] PDF = 2,
        [XmlEnum("003")] PDFMerchant = 3,
        [XmlEnum("004")] AdobeEbookReader = 4,
        [XmlEnum("005")] MicrosoftReaderLevel1OrLevel3 = 5,
        [XmlEnum("006")] MicrosoftReaderLevel5 = 6,
        [XmlEnum("007")] NetLibrary = 7,
        [XmlEnum("008")] MetaText = 8,
        [XmlEnum("009")] MightyWords = 9,
        [XmlEnum("010")] eReaderAkaPalmReader = 10,
        [XmlEnum("011")] Softbooks = 11,
        [XmlEnum("012")] RocketBook = 12,
        [XmlEnum("013")] GemstarREB1100 = 13,
        [XmlEnum("014")] GemstarREB1200 = 14,
        [XmlEnum("015")] FranklinEbookman = 15,
        [XmlEnum("016")] Books24x7 = 16,
        [XmlEnum("017")] DigitalOwl = 17,
        [XmlEnum("018")] Handheldmed = 18,
        [XmlEnum("019")] WizeUp = 19,
        [XmlEnum("020")] TK3 = 20,
        [XmlEnum("021")] Litraweb = 21,
        [XmlEnum("022")] MobiPocket = 22,
        [XmlEnum("023")] OpenEbook = 23,
        [XmlEnum("024")] TownCompassDataViewer = 24,
        [XmlEnum("025")] TXT = 25,
        [XmlEnum("026")] ExeBook = 26,
        [XmlEnum("027")] SonyBBeB = 27,
        [XmlEnum("028")] VitalSourceBookshelf = 28,
        [XmlEnum("029")] EPUB = 29,
        [XmlEnum("030")] MyiLibrary = 30,
        [XmlEnum("031")] Kindle = 31,
        [XmlEnum("032")] GoogleEdition = 32,
        [XmlEnum("033")] Vook = 33,
        [XmlEnum("034")] DXReader = 34,
        [XmlEnum("035")] EBL = 35,
        [XmlEnum("036")] Ebrary = 36,
        [XmlEnum("037")] iSilo = 37,
        [XmlEnum("038")] Plucker = 38,
        [XmlEnum("039")] VitalBook = 39,
        [XmlEnum("040")] BookAppForIOS = 40,
        [XmlEnum("041")] AndroidApp = 41,
        [XmlEnum("042")] OtherApp = 42,
        [XmlEnum("043")] XPS = 43,
        [XmlEnum("044")] iBook = 44,
        [XmlEnum("045")] ePIB = 45,
        [XmlEnum("046")] SCORM = 46,
        [XmlEnum("047")] EBP = 47,
        [XmlEnum("048")] PagePerfect = 48,
        [XmlEnum("098")] MultipleFormats = 98,
        [XmlEnum("099")] Unspecified = 99
    }
}
