using System.Xml.Serialization;

namespace OnixData.Version3.Lists
{
    public enum OnixList159
    {
        /// <summary>
        /// An executable together with data on which it operates
        /// </summary>
        [XmlEnum("01")] Application = 1,
        /// <summary>
        /// A sound recording
        /// </summary>
        [XmlEnum("02")] Audio = 2,
        /// <summary>
        /// A still image
        /// </summary>
        [XmlEnum("03")] Image = 3,
        /// <summary>
        /// Readable text, with or without associated images etc
        /// </summary>
        [XmlEnum("04")] Text = 4,
        /// <summary>
        /// Moving images, with or without accompanying sound
        /// </summary>
        [XmlEnum("05")] Video = 5,
        /// <summary>
        /// A website or other supporting resource delivering content in a variety of modes
        /// </summary>
        [XmlEnum("06")] MultiMode = 6
    }
}
