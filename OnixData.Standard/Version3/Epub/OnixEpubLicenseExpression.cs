using System;
using System.Collections.Generic;
using System.Text;

namespace OnixData.Version3.Epub
{
    /// <summary>
    /// A composite that carries details of a link to an expression of the license terms, which may be in human-readable or machine-readable form.
    /// </summary>
    public partial class OnixEpubLicenseExpression
    {

        /// <summary>
        /// An ONIX code identifying the nature or format of the license expression specified in the <see cref="EpubLicenseExpressionLink"/> element.
        /// Mandatory within the <see cref="OnixEpubLicenseExpression"/> composite, and non-repeating.
        /// </summary>
        /// <remarks>Onix List 218</remarks>
        public string EpubLicenseExpressionType { get; set; }

        /// <summary>
        /// A short free-text name for a license expression type, when the code in <see cref="EpubLicenseExpressionType"/> provides insufficient detail – for example when a machine-readable license is expressed using a particular proprietary encoding scheme.
        /// Optional and non-repeating, and must be included when (and only when) the <see cref="EpubLicenseExpressionType"/> element indicates the expression is encoded in a proprietary way.
        /// </summary>
        public string EpubLicenseExpressionTypeName { get; set; }

        /// <summary>
        /// The URI for the license expression.
        /// Mandatory in each instance of the <see cref="OnixEpubLicenseExpression"/> composite, and non-repeating.
        /// </summary>
        public string EpubExpressionLink { get; set; }
    }
}
