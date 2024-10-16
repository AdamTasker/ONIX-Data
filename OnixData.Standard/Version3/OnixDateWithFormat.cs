using System;
using System.Xml.Serialization;
using OnixData.Version3.Lists;

namespace OnixData.Version3
{
    public class OnixDateWithFormat
    {
        public string ReadableDate
        {
            get
            {
                switch (DateFormat)
                {
                    case OnixList55.RangeYearMonthDay:
                        return ParseDate(Value.Substring(0, 8)) + " - " + ParseDate(Value.Substring(8, 8));
                    case OnixList55.RangeYearMonth:
                    case OnixList55.RangeYearWeek:
                        return ParseDate(Value.Substring(0, 6)) + " - " + ParseDate(Value.Substring(6, 6));
                    case OnixList55.RangeYearQuarter:
                    case OnixList55.RangeYearSeason:
                        return ParseDate(Value.Substring(0, 5)) + " - " + ParseDate(Value.Substring(5, 5));
                    case OnixList55.RangeYear:
                        return ParseDate(Value.Substring(0, 4)) + " - " + ParseDate(Value.Substring(4, 4));
                    default:
                        return ParseDate(Value);
                }
            }
        }

        private string ParseDate(string value)
        {
            switch (DateFormat)
            {
                case OnixList55.TextString:
                case OnixList55.Year:
                case OnixList55.RangeYear:
                    return value;
                case OnixList55.YearMonthDay:
                case OnixList55.RangeYearMonthDay:
                case OnixList55.ExactTimeHourMinute:
                case OnixList55.ExactTimeHourMinuteSecond:
                    return DateTime.ParseExact(value, "yyyyMMdd", null).ToString("d MMM yyyy");
                case OnixList55.YearMonth:
                case OnixList55.RangeYearMonth:
                    return DateTime.ParseExact(value, "yyyyMM", null).ToString("MMM yyyy");
                case OnixList55.YearWeek:
                case OnixList55.RangeYearWeek:
                    return "Week " + value.Substring(4, 2) + " " + value.Substring(0, 4);
                case OnixList55.YearQuarter:
                case OnixList55.RangeYearQuarter:
                    return "Q" + value.Substring(4, 1) + " " + value.Substring(0, 4);
                case OnixList55.YearSeason:
                case OnixList55.RangeYearSeason:
                    string season;
                    switch (value.Substring(4, 1))
                    {
                        case "1":
                            season = "Spring";
                            break;
                        case "2":
                            season = "Summer";
                            break;
                        case "3":
                            season = "Fall";
                            break;
                        case "4":
                            season = "Winter";
                            break;
                        default:
                            throw new Exception("Unknown season: " + value.Substring(4, 1));
                    }

                    return season + " " + value.Substring(0, 4);

                case OnixList55.HijriYearMonthDay:
                    return $"{value.Substring(6, 2)}/{value.Substring(4, 2)}/{value.Substring(0, 4)} (Hijri)";
                case OnixList55.HijriYearMonth:
                    return $"{value.Substring(4, 2)}/{value.Substring(0, 4)} (Hijri)";
                case OnixList55.HijriTextString:
                case OnixList55.HijriYear:
                    return value + " (Hijri)";
                default:
                    throw new Exception("Unknown date format: " + DateFormat);
            }
        }

        [XmlAttribute("dateformat")]
        public OnixList55 DateFormat { get; set; } = OnixList55.YearMonthDay;

        [XmlText]
        public string Value { get; set; }
    }
}
