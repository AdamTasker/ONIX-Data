using System.Xml.Serialization;

namespace OnixData.Legacy.Lists
{
    public enum OnixList46
    {
        /// <summary>
        /// For sale with exclusive rights in the specified countries or territories
        /// </summary>
        [XmlEnum("01")] ForSaleWithExclusiveRights = 1,
        /// <summary>
        /// For sale with non-exclusive rights in the specified countries or territories
        /// </summary>
        [XmlEnum("02")] ForSaleWithNonExclusiveRights = 2,
        /// <summary>
        /// Not for sale in the specified countries or territories (reason unspecified)
        /// </summary>
        [XmlEnum("03")] NotForSale = 3,
        /// <summary>
        /// Not for sale in the specified countries (but publisher holds exclusive rights in those countries or territories)
        /// </summary>
        [XmlEnum("04")] NotForSalePublisherHoldsExclusiveRights = 4,
        /// <summary>
        /// Not for sale in the specified countries (publisher holds non-exclusive rights in those countries or territories)
        /// </summary>
        [XmlEnum("05")] NotForSalePublisherHoldsNonExclusiveRights = 5,
        /// <summary>
        /// Not for sale in the specified countries (because publisher does not hold rights in those countries or territories)
        /// </summary>
        [XmlEnum("06")] NotForSalePublisherDoesNotHoldRights = 6
    }
}
