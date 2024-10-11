using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace OnixData.Version3.Lists
{
    public enum OnixList57
    {
        [XmlEnum("01")] FreeOfCharge = 1,
        [XmlEnum("02")] PriceToBeAnnounced = 2,
        [XmlEnum("03")] NotSoldSeparately = 3,
        /// <summary>
        /// May be used for books that do not carry a recommended retail price;
        /// when goods can only be ordered ‘in person’ from a sales representative;
        /// when an ONIX file is ‘broadcast’ rather than sent one-to-one to a single trading partner;
        /// or for digital products offered on subscription or with pricing which is too complex to specify in ONIX
        /// </summary>
        [XmlEnum("04")] ContactSupplier = 4,
        /// <summary>
        /// When a collection that is not sold as a set nevertheless has its own ONIX record
        /// </summary>
        [XmlEnum("05")] NotSoldAsSet = 5,
        /// <summary>
        /// Unpriced, but available via a pre-determined revenue share agreement
        /// </summary>
        [XmlEnum("06")] RevenueShare = 6
    }
}
