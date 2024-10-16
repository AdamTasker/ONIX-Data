using System.Xml.Serialization;

namespace OnixData.Version3.Lists
{
    public enum OnixList55
    {
        /// <summary>
        /// Common Era year, month and day (default for most dates)
        /// </summary>
        [XmlEnum("00")] YearMonthDay = 0,
        /// <summary>
        /// Year and month
        /// </summary>
        [XmlEnum("01")] YearMonth = 1,
        /// <summary>
        /// Year and week number
        /// </summary>
        [XmlEnum("02")] YearWeek = 2,
        /// <summary>
        /// Year and quarter (Q = 1, 2, 3, 4, with 1 = Jan to Mar)
        /// </summary>
        [XmlEnum("03")] YearQuarter = 3,
        /// <summary>
        /// Year and season (S = 1, 2, 3, 4, with 1 = ‘Spring’)
        /// </summary>
        [XmlEnum("04")] YearSeason = 4,
        /// <summary>
        /// Year (default for some dates)
        /// </summary>
        [XmlEnum("05")] Year = 5,
        /// <summary>
        /// Spread of exact dates
        /// </summary>
        [XmlEnum("06")] RangeYearMonthDay = 6,
        /// <summary>
        /// Spread of months
        /// </summary>
        [XmlEnum("07")] RangeYearMonth = 7,
        /// <summary>
        /// Spread of week numbers
        /// </summary>
        [XmlEnum("08")] RangeYearWeek = 8,
        /// <summary>
        /// Spread of quarters
        /// </summary>
        [XmlEnum("09")] RangeYearQuarter = 9,
        /// <summary>
        /// Spread of seasons
        /// </summary>
        [XmlEnum("10")] RangeYearSeason = 10,
        /// <summary>
        /// Spread of years
        /// </summary>
        [XmlEnum("11")] RangeYear = 11,
        /// <summary>
        /// For complex, approximate or uncertain dates, or dates BCE
        /// </summary>
        [XmlEnum("12")] TextString = 12,
        /// <summary>
        /// Exact time.
        /// Use ONLY when exact times with hour/minute precision are relevant.
        /// By default, time is local.
        /// Alternatively, the time may be suffixed with an optional ‘Z’ for UTC times, or with ‘+’ or ‘-’ and an hhmm timezone offset from UTC.
        /// Times without a timezone are ‘rolling’ local times, times qualified with a timezone (using Z, + or -) specify a particular instant in time
        /// </summary>
        [XmlEnum("13")] ExactTimeHourMinute = 13,
        /// <summary>
        /// Exact time.
        /// Use ONLY when exact times with second precision are relevant.
        /// By default, time is local.
        /// Alternatively, the time may be suffixed with an optional ‘Z’ for UTC times, or with ‘+’ or ‘-’ and an hhmm timezone offset from UTC.
        /// Times without a timezone are ‘rolling’ local times, times qualified with a timezone (using Z, + or -) specify a particular instant in time
        /// </summary>
        [XmlEnum("14")] ExactTimeHourMinuteSecond = 14,
        /// <summary>
        /// Year month day (Hijri calendar)
        /// </summary>
        [XmlEnum("20")] HijriYearMonthDay = 20,
        /// <summary>
        /// Year and month (Hijri calendar)
        /// </summary>
        [XmlEnum("21")] HijriYearMonth = 21,
        /// <summary>
        /// Year (Hijri calendar)
        /// </summary>
        [XmlEnum("25")] HijriYear = 25,
        /// <summary>
        /// For complex, approximate or uncertain dates (Hijri calendar), text would usually be in Arabic script
        /// </summary>
        [XmlEnum("32")] HijriTextString = 32
    }
}
