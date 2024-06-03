using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnixData.Version3.Publishing
{
    public class OnixImprintIdentifier : OnixIdentifier
    {
        #region CONSTANTS

        public const int CONST_IMPRINT_ROLE_PROP = 1;

        #endregion

        public OnixImprintIdentifier()
        {
            ImprintIDType = "";
        }

        private string imprintIdTypeField;

        #region Reference Tags

        /// <remarks/>
        public string ImprintIDType
        {
            get
            {
                return this.imprintIdTypeField;
            }
            set
            {
                this.imprintIdTypeField = value;
            }
        }

        #endregion

        #region Helper Methods

        public int GetImprintIDTypeNum()
        {
            int nIdTypeNum = -1;

            if (!String.IsNullOrEmpty(this.ImprintIDType))
            {
                Int32.TryParse(this.ImprintIDType, out nIdTypeNum);
            }

            return nIdTypeNum;
        }

        #endregion

        #region Short Tags

        /// <remarks/>
        public string x445
        {
            get { return ImprintIDType; }
            set { ImprintIDType = value; }
        }

        #endregion

    }
}
