using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnixData.Version3.Epub
{
    /// <summary>
    /// An group of data elements which together describe a usage constraint on a digital product (or the absence of such a constraint), whether enforced by DRM technical protection, inherent in the platform used, or specified by license agreement.
    /// </summary>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public class OnixEpubUsageConstraint
    {
        #region CONSTANTS

        public const int CONST_CONSTRAINT_TYPE_PREVIEW = 1;
        public const int CONST_CONSTRAINT_TYPE_PRINT   = 2;
        public const int CONST_CONSTRAINT_TYPE_COPY    = 3;
        public const int CONST_CONSTRAINT_TYPE_SHARE   = 4;
        public const int CONST_CONSTRAINT_TYPE_TTS     = 5;
        public const int CONST_CONSTRAINT_TYPE_LEND    = 6;
        public const int CONST_CONSTRAINT_TYPE_TIME    = 7;
        public const int CONST_CONSTRAINT_TYPE_RENEW   = 8;
        public const int CONST_CONSTRAINT_TYPE_MU      = 9;
        public const int CONST_CONSTRAINT_TYPE_PVW_LCL = 10;

        public const int CONST_CONSTRAINT_STS_UNLIMITED  = 1;
        public const int CONST_CONSTRAINT_STS_LIMITED    = 2;
        public const int CONST_CONSTRAINT_STS_PROHIBITED = 3;

        #endregion

        public OnixEpubUsageConstraint()
        {
            EpubUsageType = EpubUsageStatus = "";

            usageLimitField = shortUsageLimitField = new OnixEpubUsageLimit[0];
        }

        private string epubUsageTypeField;
        private string epubUsageStatusField;

        private OnixEpubUsageLimit[] usageLimitField;
        private OnixEpubUsageLimit[] shortUsageLimitField;

        #region ONIX Lists

        public OnixEpubUsageLimit[] OnixEpubUsageLimitList
        {
            get
            {
                OnixEpubUsageLimit[] Limits = new OnixEpubUsageLimit[0];

                if (this.usageLimitField != null)
                    Limits = this.usageLimitField;
                else if (this.shortUsageLimitField != null)
                    Limits = this.shortUsageLimitField;
                else
                    Limits = new OnixEpubUsageLimit[0];

                return Limits;
            }
        }

        #endregion

        #region Reference Tags

        /// <summary>
        /// An ONIX code specifying a usage of a digital product.
        /// Mandatory in each occurrence of the <see cref="OnixEpubUsageConstraint"/> composite, and non-repeating.
        /// </summary>
        /// <remarks>Onix List 145</remarks>
        public string EpubUsageType
        {
            get { return this.epubUsageTypeField; }
            set { this.epubUsageTypeField = value; }
        }

        /// <summary>
        /// An ONIX code specifying the status of a usage of a digital product, eg permitted without limit, permitted with limit, prohibited.
        /// Mandatory in each occurrence of the <see cref="OnixEpubUsageConstraint"/> composite, and non-repeating.
        /// </summary>
        /// <remarks>Onix List 146</remarks>
        public string EpubUsageStatus
        {
            get { return this.epubUsageStatusField; }
            set { this.epubUsageStatusField = value; }
        }

        /// <summary>
        /// An optional group of data elements which together specify a quantitative limit on a particular type of usage of a digital product.
        /// Repeatable in order to specify two or more limits on the usage type.
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute("EpubUsageLimit")]
        public OnixEpubUsageLimit[] EpubUsageLimit
        {
            get { return this.usageLimitField; }
            set { this.usageLimitField = value; }
        }

        #endregion

        #region Short Tags

        public string x318
        {
            get { return EpubUsageType; }
            set { EpubUsageType = value; }
        }

        public string x319
        {
            get { return EpubUsageStatus; }
            set { EpubUsageStatus = value; }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("epubusagelimit")]
        public OnixEpubUsageLimit[] epubusagelimit
        {
            get { return this.shortUsageLimitField; }
            set { this.shortUsageLimitField = value; }
        }

        #endregion
    }
}
