using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnixData.Version3.Related
{
    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class OnixWorkIdentifier : OnixIdentifier
    {
        public OnixWorkIdentifier()
        {
            WorkIDType = -1;
        }

        private int    workIDTypeField;

        #region Reference Tags

        /// <remarks/>
        public int WorkIDType
        {
            get
            {
                return this.workIDTypeField;
            }
            set
            {
                this.workIDTypeField = value;
            }
        }

        #endregion

        #region Short Tags

        /// <remarks/>
        public int b201
        {
            get {  return this.workIDTypeField; }
            set { this.workIDTypeField = value; }
        }

        #endregion
    }
}
