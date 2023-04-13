using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnixData.Legacy
{
    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class OnixLegacyMeasure
    {
        #region CONSTANTS

        public static readonly Lists.OnixList48[] MEASURE_TYPES_DIM = 
            new Lists.OnixList48[] { Lists.OnixList48.Height, Lists.OnixList48.Width, Lists.OnixList48.Thickness, Lists.OnixList48.SphereDiameter };

        public static readonly Lists.OnixList48[] MEASURE_TYPES_WEIGHT = new Lists.OnixList48[] { Lists.OnixList48.UnitWeight };

        public static readonly Lists.OnixList50[] MEASURE_WEIGHTS_US = new Lists.OnixList50[] { Lists.OnixList50.Pounds, Lists.OnixList50.Ounces };

        #endregion

        public OnixLegacyMeasure()
        {
            Measurement     = "";
        }

        private Lists.OnixList48  measureTypeCodeField;
        private string            measurementField;
        private Lists.OnixList50  measureUnitCodeField;

        #region Reference Tags

        /// <remarks/>
        public Lists.OnixList48 MeasureTypeCode
        {
            get
            {
                return this.measureTypeCodeField;
            }
            set
            {
                this.measureTypeCodeField = value;
            }
        }

        /// <remarks/>
        public string Measurement
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

        public decimal MeasurementNum
        {
            get
            {
                decimal nMeasurementVal = 0;

                if (!String.IsNullOrEmpty(Measurement))
                    Decimal.TryParse(Measurement, out nMeasurementVal);

                return nMeasurementVal;
            }
        }

        /// <remarks/>
        public Lists.OnixList50 MeasureUnitCode
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
        public Lists.OnixList48 c093
        {
            get { return MeasureTypeCode; }
            set { MeasureTypeCode = value; }
        }

        /// <remarks/>
        public string c094
        {
            get { return Measurement; }
            set { Measurement = value; }
        }

        /// <remarks/>
        public Lists.OnixList50 c095
        {
            get { return MeasureUnitCode; }
            set { MeasureUnitCode = value; }
        }

        #endregion
    }
}
