using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using OnixData.Legacy.Lists;

namespace OnixData.Legacy
{
    /// <remarks/>
    [XmlType(AnonymousType = true)]
    public partial class OnixLegacyProductId
    {

        #region Reference Tags

        [XmlChoiceIdentifier("ProductIDTypeChoice")]
        [XmlElement("ProductIDType")]
        [XmlElement("b221")]
        public OnixList5 ProductIDType { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum ProductIDTypeEnum { ProductIDType, b221 }
        [XmlIgnore]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ProductIDTypeEnum ProductIDTypeChoice
        {
            get { return SerializationSettings.UseShortTags ? ProductIDTypeEnum.b221 : ProductIDTypeEnum.ProductIDType; }
            set { }
        }

        [XmlChoiceIdentifier("IDTypeNameChoice")]
        [XmlElement("IDTypeName")]
        [XmlElement("b233")]
        public string IDTypeName { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum IDTypeNameEnum { IDTypeName, b233 }
        [XmlIgnore]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public IDTypeNameEnum IDTypeNameChoice
        {
            get { return SerializationSettings.UseShortTags ? IDTypeNameEnum.b233 : IDTypeNameEnum.IDTypeName; }
            set { }
        }

        [XmlChoiceIdentifier("IDValueChoice")]
        [XmlElement("IDValue")]
        [XmlElement("b244")]
        public string IDValue { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum IDValueEnum { IDValue, b244 }
        [XmlIgnore]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public IDValueEnum IDValueChoice
        {
            get { return SerializationSettings.UseShortTags ? IDValueEnum.b244 : IDValueEnum.IDValue; }
            set { }
        }

        #endregion

    }
}
