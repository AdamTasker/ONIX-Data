using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnixData.Version3.Supply
{
    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class OnixSupplierId : OnixIdentifier
    {
        #region CONSTANTS

        public const int CONST_SUPPL_ID_TYPE_PROP   = 2;
        public const int CONST_SUPPL_ID_TYPE_BV     = 4;
        public const int CONST_SUPPL_ID_TYPE_GER_PI = 5;
        public const int CONST_SUPPL_ID_TYPE_GLN    = 6;
        public const int CONST_SUPPL_ID_TYPE_SAN    = 7;
        
        #endregion

        public OnixSupplierId()
        {
            SupplierIDType = -1;
        }

        private int    supplierIDTypeField;

        #region Reference Tags

        /// <remarks/>
        public int SupplierIDType
        {
            get
            {
                return this.supplierIDTypeField;
            }
            set
            {
                this.supplierIDTypeField = value;
            }
        }

        #endregion

        #region Short Tags

        /// <remarks/>
        public int j345
        {
            get { return SupplierIDType; }
            set { SupplierIDType = value; }
        }

        #endregion
    }
}
