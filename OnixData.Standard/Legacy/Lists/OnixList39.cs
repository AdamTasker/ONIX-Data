using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace OnixData.Legacy.Lists
{
  public enum OnixList39
  {
    [XmlEnum("02")] GIF = 2,
    [XmlEnum("03")] JPEG = 3,
    [XmlEnum("04")] PDF = 4,
    [XmlEnum("05")] TIF = 5,
    [XmlEnum("06")] RealAudio = 6,
    [XmlEnum("07")] MP3 = 7,
    [XmlEnum("08")] MPEG4 = 8,
    [XmlEnum("09")] PNG = 9,
    [XmlEnum("10")] WMA = 10,
    [XmlEnum("11")] AAC = 11,
    [XmlEnum("12")] WAV = 12,
    [XmlEnum("13")] AIFF = 13,
    [XmlEnum("14")] WMV = 14,
    [XmlEnum("15")] OGG = 15,
    [XmlEnum("16")] AVI = 16,
    [XmlEnum("17")] MOV = 17,
    [XmlEnum("18")] Flash = 18,
    [XmlEnum("19")] ThreeGP = 19,
    [XmlEnum("20")] WebM = 20
  }
}
