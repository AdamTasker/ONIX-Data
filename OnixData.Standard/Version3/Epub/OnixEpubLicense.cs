using System;
using System.Collections.Generic;
using System.Text;

namespace OnixData.Version3.Epub
{
    /// <summary>
    /// A composite carrying the name or title of the license governing use of the product, and a link to the license terms in eye-readable or machine-readable form.
    /// </summary>
    public partial class OnixEpubLicense
    {
        /// <summary>
        /// The name or title of the license.
        /// Mandatory in any <see cref="OnixEpubLicense"/> composite, and repeatable to provide the license name in multiple languages.
        /// The language attribute is optional for a single instance of <see cref="EpubLicenseName"/>, but must be included in each instance if <see cref="EpubLicenseName"/> is repeated.
        /// </summary>
        public string[] EpubLicenseName { get; set; }

        /// <summary>
        /// An optional composite that carries details of a link to an expression of the license terms, which may be in human-readable or machine-readable form.
        /// Repeatable when there is more than one expression of the license.
        /// </summary>
        public OnixEpubLicenseExpression[] EpubLicenseExpression { get; set; }
    }
}
