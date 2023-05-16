using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnixData.Version3.Epub
{
    /// <summary>
    /// An group of data elements which together specify a quantitative limit on a particular type of usage of a digital product.
    /// </summary>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public class OnixEpubUsageLimit
    {
        public OnixEpubUsageLimit()
        {
            Quantity = EpubUsageUnit = "";
        }

        private string quantityField;
        private string epubUsageUnitField;

        #region Reference Tags

        /// <summary>
        /// A numeric value representing the maximum permitted quantity of a particular type of usage.
        /// Mandatory in each occurrence of the <see cref="OnixEpubUsageLimit"/> composite, and non-repeating.
        /// </summary>
        public string Quantity
        {
            get { return this.quantityField; }
            set { this.quantityField = value; }
        }

        /// <summary>
        /// An ONIX code for a unit in which a permitted usage quantity is stated.
        /// Mandatory in each occurrence of the <see cref="OnixEpubUsageLimit"/> composite, and non-repeating.
        /// </summary>
        /// <remarks>Onix List 147</remarks>
        public string EpubUsageUnit
        {
            get { return this.epubUsageUnitField; }
            set { this.epubUsageUnitField = value; }
        }

        #endregion

        #region Short Tags

        public string x320
        {
            get { return Quantity; }
            set { Quantity = value; }
        }

        public string x321
        {
            get { return EpubUsageUnit; }
            set { EpubUsageUnit = value; }
        }

        #endregion
    }
}