using System;
using System.Collections.Generic;
using System.Text;

namespace OnixData.Version3
{
    /// <summary>
    /// A group of data elements which together define an identifier of the organization which is the source of the ONIX record.
    /// </summary>
    public partial class OnixRecordSourceIdentifier : OnixIdentifier
    {
        /// <summary>
        /// An ONIX code identifying the scheme from which the identifier in the <see cref="IDValue"/> element is taken.
        /// Mandatory in each occurrence of the <see cref="OnixRecordSourceIdentifier"/> composite, and non-repeating.
        /// </summary>
        /// <remarks>Onix List 44</remarks>
        public string RecordSourceIDType { get; set; }
    }
}
