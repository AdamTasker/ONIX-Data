using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace OnixData.Legacy.Xml.Enums
{
    [XmlType(IncludeInSchema = false)] public enum DistinctiveTitleEnum { DistinctiveTitle, b028 }
    [XmlType(IncludeInSchema = false)] public enum SubtitleEnum { Subtitle, b029 }
    [XmlType(IncludeInSchema = false)] public enum TitlePrefixEnum { TitlePrefix, b030 }
    [XmlType(IncludeInSchema = false)] public enum TitleWithoutPrefixEnum { TitleWithoutPrefix, b031 }
}
