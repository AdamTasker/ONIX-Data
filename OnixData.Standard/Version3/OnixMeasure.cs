using System.ComponentModel;
using System.Linq;
using System.Xml.Serialization;

namespace OnixData.Version3
{
    /// <summary>
    /// An optional group of data elements which together identify a measurement and the units in which it is expressed; used to specify the overall dimensions of a physical product including its packaging (if any).
    /// </summary>
    [XmlType(AnonymousType = true)]
    public partial class OnixMeasure
    {
        #region CONSTANTS

        public const int CONST_MEASURE_TYPE_HEIGHT = 1;
        public const int CONST_MEASURE_TYPE_WIDTH = 2;
        public const int CONST_MEASURE_TYPE_THICK = 3;
        public const int CONST_MEASURE_TYPE_WEIGHT = 8;
        public const int CONST_MEASURE_TYPE_DIAMTR = 9;

        public const string CONST_MEASURE_METRIC_UNIT_CM = "cm";
        public const string CONST_MEASURE_METRIC_UNIT_GR = "gr";
        public const string CONST_MEASURE_METRIC_UNIT_MM = "mm";

        public const string CONST_MEASURE_USCS_UNIT_LB = "lb";
        public const string CONST_MEASURE_USCS_UNIT_OZ = "oz";
        public const string CONST_MEASURE_USCS_UNIT_IN = "in";

        public readonly string[] CONST_METRIC_UNIT_TYPES
            = {
                CONST_MEASURE_METRIC_UNIT_CM, CONST_MEASURE_METRIC_UNIT_GR,
                CONST_MEASURE_METRIC_UNIT_MM
              };

        #endregion

        #region Helper Methods

        public bool IsMetricUnitType()
        {
            return CONST_METRIC_UNIT_TYPES.Contains(this.MeasureUnitCode);
        }

        #endregion

        #region Reference Tags

        /// <summary>
        /// An ONIX code indicating the dimension which is specified by an occurrence of the measure composite.
        /// Mandatory in each occurrence of the <see cref="OnixMeasure"/> composite, and non-repeating.
        /// </summary>
        /// <remarks>Onix List 48</remarks>
        [XmlChoiceIdentifier("MeasureTypeChoice")]
        [XmlElement("MeasureType")]
        [XmlElement("x315")]
        public int MeasureType { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum MeasureTypeEnum { MeasureType, x315 }
        [XmlIgnore, DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public MeasureTypeEnum MeasureTypeChoice
        {
            get { return SerializationSettings.UseShortTags ? MeasureTypeEnum.x315 : MeasureTypeEnum.MeasureType; }
            set { }
        }

        /// <summary>
        /// The number which represents the dimension specified in <see cref="MeasureType"/> in the measure units specified in <see cref="MeasureUnitCode"/>.
        /// Mandatory in each occurrence of the <see cref="OnixMeasure"/> composite, and non-repeating.
        /// </summary>
        [XmlChoiceIdentifier("MeasurementChoice")]
        [XmlElement("Measurement")]
        [XmlElement("c094")]
        public float Measurement { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum MeasurementEnum { Measurement, c094 }
        [XmlIgnore, DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public MeasurementEnum MeasurementChoice
        {
            get { return SerializationSettings.UseShortTags ? MeasurementEnum.c094 : MeasurementEnum.Measurement; }
            set { }
        }

        /// <summary>
        /// An ONIX code indicating the measure unit in which dimensions are given.
        /// Mandatory in each occurrence of the <see cref="OnixMeasure"/> composite, and non-repeating.
        /// This element must follow the dimension to which the measure unit applies.
        /// </summary>
        /// <remarks>Onix List 50</remarks>
        [XmlChoiceIdentifier("MeasureUnitCodeChoice")]
        [XmlElement("MeasureUnitCode")]
        [XmlElement("c095")]
        public string MeasureUnitCode { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum MeasureUnitCodeEnum { MeasureUnitCode, c095 }
        [XmlIgnore, DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public MeasureUnitCodeEnum MeasureUnitCodeChoice
        {
            get { return SerializationSettings.UseShortTags ? MeasureUnitCodeEnum.c095 : MeasureUnitCodeEnum.MeasureUnitCode; }
            set { }
        }

        #endregion
    }
}
