using System.Xml.Serialization;

namespace OnixData.Version3.Lists
{
    public enum OnixList162
    {
        /// <summary>
        /// Resource Version Feature Value carries a code from List 178
        /// </summary>
        [XmlEnum("01")] FileFormat = 1,
        /// <summary>
        /// Resource Version Feature Value carries an integer
        /// </summary>
        [XmlEnum("02")] ImageHeightInPixels = 2,
        /// <summary>
        /// Resource Version Feature Value carries an integer
        /// </summary>
        [XmlEnum("03")] ImageWidthInPixels = 3,
        /// <summary>
        /// Resource Version Feature Value carries the filename of the supporting resource, necessary only when it is different from the last part of the path provided in <see cref="Text.OnixResourceVersionFeature.ResourceLink" />
        /// </summary>
        [XmlEnum("04")] Filename = 4,
        /// <summary>
        /// Resource Version Feature Value carries a decimal number only, suggested no more than 2 or 3 significant digits (eg 1.7, not 1.7462 or 1.75MB)
        /// </summary>
        [XmlEnum("05")] ApproximateDownloadFileSizeInMegabytes = 5,
        /// <summary>
        /// MD5 hash value of the resource file. <see cref="Text.OnixResourceVersionFeature.FeatureValue" /> should contain the 128-bit digest value (as 32 hexadecimal digits).
        /// Can be used as a cryptographic check on the integrity of a resource after it has been retrieved
        /// </summary>
        [XmlEnum("06")] Md5HashValue = 6,
        /// <summary>
        /// Resource Version Feature Value carries a integer number only (eg 1831023)
        /// </summary>
        [XmlEnum("07")] ExactDownloadFileSizeInBytes = 7,
        /// <summary>
        /// SHA-256 hash value of the resource file. <see cref="Text.OnixResourceVersionFeature.FeatureValue" /> should contain the 256-bit digest value (as 64 hexadecimal digits).
        /// Can be used as a cryptographic check on the integrity of a resource after it has been retrieved
        /// </summary>
        [XmlEnum("08")] Sha256HashValue = 8,
        /// <summary>
        /// International Standard Content Code, a ‘similarity hash’ derived algorithmically from the resource content itself (see https://iscc.codes).
        /// &lt;IDValue&gt; is the 55-character case-sensitive string (including three hyphens) forming the ISCC of the resource file
        /// </summary>
        [XmlEnum("09")] ISCC = 9
    }
}
