using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Xml.Serialization;

namespace OnixData.Legacy
{
    [XmlType(AnonymousType = true)]
    public class OnixLegacyBatchBonus
    {
        [XmlChoiceIdentifier("BatchQuantityChoice")]
        [XmlElement("BatchQuantity")]
        [XmlElement("j264")]
        public int BatchQuantity { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum BatchQuantityEnum { BatchQuantity, j264 }
        [XmlIgnore]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public BatchQuantityEnum BatchQuantityChoice
        {
            get { return SerializationSettings.UseShortTags ? BatchQuantityEnum.j264 : BatchQuantityEnum.BatchQuantity; }
            set { }
        }

        [XmlChoiceIdentifier("FreeQuantityChoice")]
        [XmlElement("FreeQuantity")]
        [XmlElement("j265")]
        public int FreeQuantity { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum FreeQuantityEnum { FreeQuantity, j265 }
        [XmlIgnore]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public FreeQuantityEnum FreeQuantityChoice
        {
            get { return SerializationSettings.UseShortTags ? FreeQuantityEnum.j265 : FreeQuantityEnum.FreeQuantity; }
            set { }
        }
    }
}
