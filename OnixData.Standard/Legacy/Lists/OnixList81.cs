using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace OnixData.Legacy.Lists
{
    public enum OnixList81
    {
        [XmlEnum("10")] TextEyeReadable = 10,
        [XmlEnum("15")] ExtensiveLinksBetweenInternalContent = 15,
        [XmlEnum("14")] ExtensiveLinksToExternalContent = 14,
        [XmlEnum("16")] AdditionalEyeReadableTextNotPartOfMainWork = 16,
        [XmlEnum("17")] PromotionalTextForOtherBookProduct = 17,
        [XmlEnum("11")] MusicalNotation = 11,
        [XmlEnum("07")] StillImagesOrGraphics = 7,
        [XmlEnum("18")] Photographs = 18,
        [XmlEnum("19")] FiguresDiagramsChartsGraphs = 19,
        [XmlEnum("20")] AdditionalImagesOrGraphicsNotPartOfMainWork = 20,
        [XmlEnum("12")] MapsAndOrOtherCartographicContent = 12,
        [XmlEnum("01")] Audiobook = 1,
        [XmlEnum("02")] PerformanceSpokenWord = 2,
        [XmlEnum("13")] OtherSpeechContent = 13,
        [XmlEnum("03")] MusicRecording = 3,
        [XmlEnum("04")] OtherAudio = 4,
        [XmlEnum("21")] PartialPerformanceSpokenWord = 21,
        [XmlEnum("22")] AdditionalAudioContentNotPartOfMainWork = 22,
        [XmlEnum("23")] PromotionalAudioForOtherBookProduct = 23,
        [XmlEnum("06")] Video = 6,
        [XmlEnum("26")] VideoRecordingOfAReading = 26,
        [XmlEnum("27")] PerformanceVisual = 27,
        [XmlEnum("24")] AnimatedOrInteractiveIllustrations = 24,
        [XmlEnum("25")] NarrativeAnimation = 25,
        [XmlEnum("28")] OtherVideo = 28,
        [XmlEnum("29")] PartialPerformanceVideo = 29,
        [XmlEnum("30")] AdditionalVideoContentNotPartOfMainWork = 30,
        [XmlEnum("31")] PromotionalVideoForOtherBookProduct = 31,
        [XmlEnum("05")] GameOrPuzzle = 5,
        [XmlEnum("32")] Contest = 32,
        [XmlEnum("08")] Software = 8,
        [XmlEnum("09")] Data = 9,
        [XmlEnum("33")] DataSetPlusSoftware = 33,
        [XmlEnum("34")] BlankPages = 34,
        [XmlEnum("35")] AdvertisingContent = 35,
        [XmlEnum("37")] AdvertisingFirstParty = 37,
        [XmlEnum("36")] AdvertisingCoupons = 36,
        [XmlEnum("38")] AdvertisingThirdPartyDisplay = 38,
        [XmlEnum("39")] AdvertisingThirdPartyTextual = 39
    }
}
