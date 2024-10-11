using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace OnixData.Legacy.Lists
{
    public enum OnixList1
    {
        [XmlEnum("01")] EarlyNotification = 1,
        [XmlEnum("02")] AdvanceNotificationConfirmed = 2,
        [XmlEnum("03")] NotificationConfirmedOnPublication = 3,
        [XmlEnum("04")] UpdatePartial = 4,
        [XmlEnum("05")] Delete = 5,
        [XmlEnum("08")] NoticeOfSale = 8,
        [XmlEnum("09")] NoticeOfAcquisition = 9,
        [XmlEnum("12")] UpdateSupplyDetailOnly = 12,
        [XmlEnum("13")] UpdateMarketRepresentationOnly = 13,
        [XmlEnum("14")] UpdateSupplyDetailAndMarketRepresentation = 14,
        [XmlEnum("88")] TestUpdatePartial = 88,
        [XmlEnum("89")] TestRecord = 89
    }
}
