using System.ComponentModel;
using System.Xml.Serialization;

namespace OnixData.Version3.Text
{
    /// <summary>
    /// A group of data elements which together describe a prize or award won by the product or work.
    /// </summary>
    public partial class OnixPrize
    {
        /// <summary>
        /// The name of a prize or award which the product or work has received.
        /// Mandatory in each occurrence of the <see cref="OnixPrize"/> composite, and repeatable to provide a parallel award name in multiple languages.
        /// The language attribute is optional for a single instance of <see cref="PrizeName"/>, but must be included in each instance if <see cref="PrizeName"/> is repeated.
        /// </summary>
        [XmlChoiceIdentifier("PrizeNameChoice")]
        [XmlElement("PrizeName")]
        [XmlElement("g126")]
        public string[] PrizeName { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum PrizeNameEnum { PrizeName, g126 }
        [XmlIgnore, DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public PrizeNameEnum[] PrizeNameChoice
        {
            get
            {
                if (PrizeName == null) return null;
                PrizeNameEnum choice = SerializationSettings.UseShortTags ? PrizeNameEnum.g126 : PrizeNameEnum.PrizeName;
                PrizeNameEnum[] result = new PrizeNameEnum[PrizeName.Length];
                for (int i = 0; i < PrizeName.Length; i++) result[i] = choice;
                return result;
            }
            set { }
        }

        /// <summary>
        /// The year in which a prize or award was given.
        /// Optional and non-repeating.
        /// </summary>
        [XmlChoiceIdentifier("PrizeYearChoice")]
        [XmlElement("PrizeYear")]
        [XmlElement("g127")]
        public string PrizeYear { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum PrizeYearEnum { PrizeYear, g127 }
        [XmlIgnore, DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public PrizeYearEnum PrizeYearChoice
        {
            get { return SerializationSettings.UseShortTags ? PrizeYearEnum.g127 : PrizeYearEnum.PrizeYear; }
            set { }
        }

        /// <summary>
        /// An ISO standard code identifying the country in which a prize or award is given.
        /// Optional and non-repeating.
        /// </summary>
        /// <remarks>Onix List 91</remarks>
        [XmlChoiceIdentifier("PrizeCountryChoice")]
        [XmlElement("PrizeCountry")]
        [XmlElement("g128")]
        public string PrizeCountry { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum PrizeCountryEnum { PrizeCountry, g128 }
        [XmlIgnore, DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public PrizeCountryEnum PrizeCountryChoice
        {
            get { return SerializationSettings.UseShortTags ? PrizeCountryEnum.g128 : PrizeCountryEnum.PrizeCountry; }
            set { }
        }

        /// <summary>
        /// An ONIX code identifying the region in which a prize or award is given.
        /// Optional and non-repeatable.
        /// A region is an area which is not a country, but which is precisely defined in geographical terms, eg Newfoundland and Labrador, Florida.
        /// If both country and region are specified, the region must be within the country.
        /// Note that US States have region codes, while US overseas territories have distinct ISO Country Codes.
        /// </summary>
        /// <remarks>Onix List 49 where possible and appropriate</remarks>
        [XmlChoiceIdentifier("PrizeRegionChoice")]
        [XmlElement("PrizeRegion")]
        [XmlElement("x556")]
        public string PrizeRegion { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum PrizeRegionEnum { PrizeRegion, x556 }
        [XmlIgnore, DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public PrizeRegionEnum PrizeRegionChoice
        {
            get { return SerializationSettings.UseShortTags ? PrizeRegionEnum.x556 : PrizeRegionEnum.PrizeRegion; }
            set { }
        }

        /// <summary>
        /// An ONIX code indicating the achievement of the product in relation to a prize or award, eg winner, runner-up, shortlisted.
        /// Optional and non-repeating.
        /// </summary>
        /// <remarks>Onix List 41</remarks>
        [XmlChoiceIdentifier("PrizeCodeChoice")]
        [XmlElement("PrizeCode")]
        [XmlElement("g129")]
        public string PrizeCode { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum PrizeCodeEnum { PrizeCode, g129 }
        [XmlIgnore, DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public PrizeCodeEnum PrizeCodeChoice
        {
            get { return SerializationSettings.UseShortTags ? PrizeCodeEnum.g129 : PrizeCodeEnum.PrizeCode; }
            set { }
        }

        /// <summary>
        /// <para>A short free-text description of the prize or award, intended primarily for display.
        /// Optional, and repeatable if the text is provided in more than one language.
        /// The language attribute is optional for a single instance of <see cref="PrizeStatement"/>, but must be included in each instance if <see cref="PrizeStatement"/> is repeated.</para>
        ///
        /// <para><see cref="PrizeStatement"/> is intended for display purposes only.
        /// When used, a <see cref="PrizeStatement"/> must be complete in itself, ie it should not be treated as merely supplementary to other elements within the <see cref="OnixPrize"/> composite.
        /// Nor should <see cref="PrizeStatement"/> be supplied instead of those other elements – at minimum, the <see cref="PrizeCode"/> element, and whenever appropriate the <see cref="PrizeYear"/> element should be supplied.</para>
        /// </summary>
        [XmlChoiceIdentifier("PrizeStatementChoice")]
        [XmlElement("PrizeStatement")]
        [XmlElement("x503")]
        public string[] PrizeStatement { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum PrizeStatementEnum { PrizeStatement, x503 }
        [XmlIgnore, DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public PrizeStatementEnum[] PrizeStatementChoice
        {
            get
            {
                if (PrizeStatement == null) return null;
                PrizeStatementEnum choice = SerializationSettings.UseShortTags ? PrizeStatementEnum.x503 : PrizeStatementEnum.PrizeStatement;
                PrizeStatementEnum[] result = new PrizeStatementEnum[PrizeStatement.Length];
                for (int i = 0; i < PrizeStatement.Length; i++) result[i] = choice;
                return result;
            }
            set { }
        }

        /// <summary>
        /// Free text listing members of the jury that awarded the prize.
        /// Optional, and repeatable if the text is provided in more than one language.
        /// The language attribute is optional for a single instance of <see cref="PrizeJury"/>, but must be included in each instance if <see cref="PrizeJury"/> is repeated.
        /// </summary>
        [XmlChoiceIdentifier("PrizeJuryChoice")]
        [XmlElement("PrizeJury")]
        [XmlElement("g343")]
        public string[] PrizeJury { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum PrizeJuryEnum { PrizeJury, g343 }
        [XmlIgnore, DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public PrizeJuryEnum[] PrizeJuryChoice
        {
            get
            {
                if (PrizeJury == null) return null;
                PrizeJuryEnum choice = SerializationSettings.UseShortTags ? PrizeJuryEnum.g343 : PrizeJuryEnum.PrizeJury;
                PrizeJuryEnum[] result = new PrizeJuryEnum[PrizeJury.Length];
                for (int i = 0; i < PrizeJury.Length; i++) result[i] = choice;
                return result;
            }
            set { }
        }
    }
}
