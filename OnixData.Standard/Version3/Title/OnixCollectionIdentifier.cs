using System;
using System.Collections.Generic;
using System.Text;

namespace OnixData.Version3.Title
{
    /// <summary>
    /// A group of data elements which together specify an identifier of a bibliographic collection.
    /// </summary>
    public partial class OnixCollectionIdentifier : OnixIdentifier
    {

        /// <summary>
        /// An ONIX code identifying a scheme from which an identifier in the <see cref="IDValue"/> element is taken.
        /// Mandatory in each occurrence of the <see cref="OnixCollectionIdentifier"/> composite, and non-repeating.
        /// </summary>
        /// <remarks>Onix List 13</remarks>
        public string CollectionIDType { get; set; }
    }
}
