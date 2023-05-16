using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnixData.Version3
{
    /// <summary>
    /// An optional group of data elements which together identify a measurement and the units in which it is expressed; used to specify the overall dimensions of a physical product including its packaging (if any).
    /// </summary>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class OnixMeasure
    {
        #region CONSTANTS

        public const int CONST_MEASURE_TYPE_HEIGHT = 1;
        public const int CONST_MEASURE_TYPE_WIDTH  = 2;
        public const int CONST_MEASURE_TYPE_THICK  = 3;
        public const int CONST_MEASURE_TYPE_WEIGHT = 8;
        public const int CONST_MEASURE_TYPE_DIAMTR = 9;

        public const string CONST_MEASURE_METRIC_UNIT_CM = "cm";
        public const string CONST_MEASURE_METRIC_UNIT_GR = "gr";
        public const string CONST_MEASURE_METRIC_UNIT_MM = "mm";

        public const string CONST_MEASURE_USCS_UNIT_LB   = "lb";
        public const string CONST_MEASURE_USCS_UNIT_OZ   = "oz";
        public const string CONST_MEASURE_USCS_UNIT_IN   = "in";

        public readonly string[] CONST_METRIC_UNIT_TYPES
            = {
                CONST_MEASURE_METRIC_UNIT_CM, CONST_MEASURE_METRIC_UNIT_GR,
                CONST_MEASURE_METRIC_UNIT_MM
              };

        #endregion

        public OnixMeasure()
        {
            MeasureType = -1;

            Measurement = 0;

            MeasureUnitCode = "";
        }

        private int     measureTypeField;
        private decimal measurementField;
        private string  measureUnitCodeField;

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
        public int MeasureType
        {
            get
            {
                return this.measureTypeField;
            }
            set
            {
                this.measureTypeField = value;
            }
        }

        /// <summary>
        /// The number which represents the dimension specified in <see cref="MeasureType"/> in the measure units specified in <see cref="MeasureUnitCode"/>.
        /// Mandatory in each occurrence of the <see cref="OnixMeasure"/> composite, and non-repeating.
        /// </summary>
        public decimal Measurement
        {
            get
            {
                return this.measurementField;
            }
            set
            {
                this.measurementField = value;
            }
        }

        /// <summary>
        /// An ONIX code indicating the measure unit in which dimensions are given.
        /// Mandatory in each occurrence of the <see cref="OnixMeasure"/> composite, and non-repeating.
        /// This element must follow the dimension to which the measure unit applies.
        /// </summary>
        /// <remarks>Onix List 50</remarks>
        public string MeasureUnitCode
        {
            get
            {
                return this.measureUnitCodeField;
            }
            set
            {
                this.measureUnitCodeField = value;
            }
        }

        #endregion

        #region Short Tags

        /// <remarks/>
        public int x315
        {
            get { return MeasureType; }
            set { MeasureType = value; }
        }

        /// <remarks/>
        public decimal c094
        {
            get { return Measurement; }
            set { Measurement = value; }
        }

        /// <remarks/>
        public string c095
        {
            get { return MeasureUnitCode; }
            set { MeasureUnitCode = value; }
        }

        #endregion
    }
}
