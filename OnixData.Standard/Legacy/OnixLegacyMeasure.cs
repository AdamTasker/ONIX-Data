using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace OnixData.Legacy
{
    /// <remarks/>
    [XmlType(AnonymousType = true)]
    public partial class OnixLegacyMeasure
    {
        #region CONSTANTS

        public static readonly Lists.OnixList48[] MEASURE_TYPES_DIM = 
            new Lists.OnixList48[] { Lists.OnixList48.Height, Lists.OnixList48.Width, Lists.OnixList48.Thickness, Lists.OnixList48.SphereDiameter };

        public static readonly Lists.OnixList48[] MEASURE_TYPES_WEIGHT = new Lists.OnixList48[] { Lists.OnixList48.UnitWeight };

        public static readonly Lists.OnixList50[] MEASURE_WEIGHTS_US = new Lists.OnixList50[] { Lists.OnixList50.Pounds, Lists.OnixList50.Ounces };

        #endregion

        #region Reference Tags

        [XmlChoiceIdentifier("MeasureTypeCodeChoice")]
        [XmlElement("MeasureTypeCode")]
        [XmlElement("c093")]
        public Lists.OnixList48 MeasureTypeCode { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum MeasureTypeCodeEnum { MeasureTypeCode, c093 }
        [XmlIgnore]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public MeasureTypeCodeEnum MeasureTypeCodeChoice
        {
            get { return SerializationSettings.UseShortTags ? MeasureTypeCodeEnum.c093 : MeasureTypeCodeEnum.MeasureTypeCode; }
            set { } 
        }

        [XmlChoiceIdentifier("MeasurementChoice")]
        [XmlElement("Measurement")]
        [XmlElement("c094")]
        public decimal Measurement { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum MeasurementEnum { Measurement, c094 }
        [XmlIgnore]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public MeasurementEnum MeasurementChoice
        {
            get { return SerializationSettings.UseShortTags ? MeasurementEnum.c094 : MeasurementEnum.Measurement; }
            set { }
        }

        [XmlChoiceIdentifier("MeasurementUnitCodeChoice")]
        [XmlElement("MeasurementUnitCode")]
        [XmlElement("c095")]
        public Lists.OnixList50? MeasureUnitCode { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum MeasurementUnitCodeEnum { MeasurementUnitCode, c095 }
        [XmlIgnore]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public MeasurementUnitCodeEnum MeasurementUnitCodeChoice
        {
            get { return SerializationSettings.UseShortTags ? MeasurementUnitCodeEnum.c095 : MeasurementUnitCodeEnum.MeasurementUnitCode; }
            set { }
        }

        #endregion
    }
}
