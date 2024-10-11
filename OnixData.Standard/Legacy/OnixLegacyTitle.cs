using OnixData.Version3.Market;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using OnixData.Legacy.Xml.Enums;

namespace OnixData.Legacy
{
    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class OnixLegacyTitle
    {
        #region CONSTANTS

        public const int CONST_TITLE_TYPE_UN_TITLE = 0;
        public const int CONST_TITLE_TYPE_DIST_TITLE = 1;

        #endregion

        #region ONIX Helpers

        public string OnixDistinctiveTitle
        {
            get
            {
                StringBuilder TitleBuilder = new StringBuilder();

                if ((this.TitleType == OnixLegacyTitle.CONST_TITLE_TYPE_UN_TITLE) ||
                    (this.TitleType == OnixLegacyTitle.CONST_TITLE_TYPE_DIST_TITLE))
                {
                    if (!String.IsNullOrEmpty(this.TitleText))
                        TitleBuilder.Append(this.TitleText.Trim());
                    else if (!String.IsNullOrEmpty(this.TitleWithoutPrefix))
                    {
                        if (!String.IsNullOrEmpty(this.TitlePrefix))
                            TitleBuilder.Append(this.TitlePrefix.Trim()).Append(" ");

                        TitleBuilder.Append(this.TitleWithoutPrefix.Trim());
                    }

                    if ((TitleBuilder.Length > 0) && !String.IsNullOrEmpty(this.Subtitle))
                        TitleBuilder.Append(": ").Append(this.Subtitle.Trim());
                }

                return TitleBuilder.ToString();
            }
        }

        #endregion

        #region Reference Tags

        [XmlChoiceIdentifier("TitleTypeChoice")]
        [XmlElement("TitleType")]
        [XmlElement("b202")]
        public int TitleType { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum TitleTypeEnum { TitleType, b202 }
        [XmlIgnore]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public TitleTypeEnum TitleTypeChoice
        {
            get { return SerializationSettings.UseShortTags ? TitleTypeEnum.b202 : TitleTypeEnum.TitleType; }
            set { }
        }

        [XmlChoiceIdentifier("TitleTextChoice")]
        [XmlElement("TitleText")]
        [XmlElement("b203")]
        public string TitleText { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum TitleTextEnum { TitleText, b203 }
        [XmlIgnore]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public TitleTextEnum TitleTextChoice
        {
            get { return SerializationSettings.UseShortTags ? TitleTextEnum.b203 : TitleTextEnum.TitleText; }
            set { }
        }

        [XmlChoiceIdentifier("TitlePrefixChoice")]
        [XmlElement("TitlePrefix")]
        [XmlElement("b030")]
        public string TitlePrefix { get; set; }
        [XmlIgnore]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public TitlePrefixEnum TitlePrefixChoice
        {
            get { return SerializationSettings.UseShortTags ? TitlePrefixEnum.b030 : TitlePrefixEnum.TitlePrefix; }
            set { }
        }

        [XmlChoiceIdentifier("TitleWithoutPrefixChoice")]
        [XmlElement("TitleWithoutPrefix")]
        [XmlElement("b031")]
        public string TitleWithoutPrefix { get; set; }
        [XmlIgnore]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public TitleWithoutPrefixEnum TitleWithoutPrefixChoice
        {
            get { return SerializationSettings.UseShortTags ? TitleWithoutPrefixEnum.b031 : TitleWithoutPrefixEnum.TitleWithoutPrefix; }
            set { }
        }

        [XmlChoiceIdentifier("SubtitleChoice")]
        [XmlElement("Subtitle")]
        [XmlElement("b029")]
        public string Subtitle { get; set; }
        [XmlIgnore]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public SubtitleEnum SubtitleChoice
        {
            get { return SerializationSettings.UseShortTags ? SubtitleEnum.b029 : SubtitleEnum.Subtitle; }
            set { }
        }

        #endregion

    }
}
