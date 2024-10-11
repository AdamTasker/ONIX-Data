using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using OnixData.Legacy.Xml.Enums;
using OnixData.Legacy.Lists;

namespace OnixData.Legacy
{
    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class OnixLegacyBaseProduct
    {

        #region ONIX Helpers

        public string ISBN10
        {
            get
            {
                OnixLegacyProductId[] ProductIdList = ProductIdentifier;

                string TempISBN = this.ISBN;
                if (string.IsNullOrEmpty(TempISBN))
                {
                    if ((ProductIdList != null) && (ProductIdList.Length > 0))
                    {
                        OnixLegacyProductId IsbnProductId =
                            ProductIdList.Where(x => x.ProductIDType == OnixList5.ISBN10).FirstOrDefault();

                        if ((IsbnProductId != null) && !string.IsNullOrEmpty(IsbnProductId.IDValue))
                            TempISBN = IsbnProductId.IDValue;
                    }
                }

                return TempISBN;
            }
        }

        public string ISBN13
        {
            get
            {
                OnixLegacyProductId[] ProductIdList = ProductIdentifier;

                string TempEAN = this.EAN13;
                if (string.IsNullOrEmpty(TempEAN))
                {
                    if ((ProductIdList != null) && (ProductIdList.Length > 0))
                    {
                        OnixLegacyProductId EanProductId =
                            ProductIdList.Where(x => (x.ProductIDType == OnixList5.GTIN13) ||
                                                     (x.ProductIDType == OnixList5.ISBN13)).FirstOrDefault();

                        if ((EanProductId != null) && !string.IsNullOrEmpty(EanProductId.IDValue))
                            TempEAN = EanProductId.IDValue;
                    }
                }

                return TempEAN;
            }
        }

        public string LIBRARY_CONGRESS_NUM
        {
            get
            {
                string sLibCongressNum = "";

                OnixLegacyProductId[] ProductIdList = ProductIdentifier;

                if ((ProductIdList != null) && (ProductIdList.Length > 0))
                {
                    OnixLegacyProductId LccnProductId =
                        ProductIdList.Where(x => (x.ProductIDType == OnixList5.LCCN)).FirstOrDefault();

                    if ((LccnProductId != null) && !string.IsNullOrEmpty(LccnProductId.IDValue))
                        sLibCongressNum = LccnProductId.IDValue;
                }

                return sLibCongressNum;
            }
        }

        public string PROPRIETARY_ID
        {
            get
            {
                string sPropId = "";

                OnixLegacyProductId[] ProductIdList = ProductIdentifier;

                if ((ProductIdList != null) && (ProductIdList.Length > 0))
                {
                    OnixLegacyProductId PropProductId =
                        ProductIdList.Where(x => (x.ProductIDType == OnixList5.Proprietary)).FirstOrDefault();

                    if ((PropProductId != null) && !string.IsNullOrEmpty(PropProductId.IDValue))
                        sPropId = PropProductId.IDValue;
                }

                return sPropId;
            }
        }

        public string UPCCode
        {
            get
            {
                OnixLegacyProductId[] ProductIdList = ProductIdentifier;

                string TempUPC = this.UPC;
                if (string.IsNullOrEmpty(TempUPC))
                {
                    if ((ProductIdList != null) && (ProductIdList.Length > 0))
                    {
                        OnixLegacyProductId UpcProductId =
                            ProductIdList.Where(x => x.ProductIDType == OnixList5.UPC).FirstOrDefault();

                        if ((UpcProductId != null) && !string.IsNullOrEmpty(UpcProductId.IDValue))
                            TempUPC = UpcProductId.IDValue;
                    }
                }

                return TempUPC;
            }
        }

        #endregion

        #region Reference Tags

        [XmlChoiceIdentifier("RecordReferenceChoice")]
        [XmlElement("RecordReference")]
        [XmlElement("a001")]
        public string RecordReference { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum RecordReferenceEnum { RecordReference, a001 }
        [XmlIgnore]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public RecordReferenceEnum RecordReferenceChoice
        {
            get { return SerializationSettings.UseShortTags ? RecordReferenceEnum.a001 : RecordReferenceEnum.RecordReference; }
            set { }
        }

        [XmlChoiceIdentifier("NotificationTypeChoice")]
        [XmlElement("NotificationType")]
        [XmlElement("a002")]
        public OnixList1 NotificationType { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum NotificationTypeEnum { NotificationType, a002 }
        [XmlIgnore]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public NotificationTypeEnum NotificationTypeChoice
        {
            get { return SerializationSettings.UseShortTags ? NotificationTypeEnum.a002 : NotificationTypeEnum.NotificationType; }
            set { }
        }

        [XmlChoiceIdentifier("ISBNChoice")]
        [XmlElement("ISBN")]
        [XmlElement("b004")]
        public string ISBN { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum ISBNEnum { ISBN, b004 }
        [XmlIgnore]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ISBNEnum ISBNChoice
        {
            get { return SerializationSettings.UseShortTags ? ISBNEnum.b004 : ISBNEnum.ISBN; }
            set { }
        }

        [XmlChoiceIdentifier("EAN13Choice")]
        [XmlElement("EAN13")]
        [XmlElement("b005")]
        public string EAN13 { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum EAN13Enum { EAN13, b005 }
        [XmlIgnore]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public EAN13Enum EAN13Choice
        {
            get { return SerializationSettings.UseShortTags ? EAN13Enum.b005 : EAN13Enum.EAN13; }
            set { }
        }

        [XmlChoiceIdentifier("UPCChoice")]
        [XmlElement("UPC")]
        [XmlElement("b006")]
        public string UPC { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum UPCEnum { UPC, b006 }
        [XmlIgnore]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public UPCEnum UPCChoice
        {
            get { return SerializationSettings.UseShortTags ? UPCEnum.b006 : UPCEnum.UPC; }
            set { }
        }

        [XmlChoiceIdentifier("ProductIdentifierChoice")]
        [XmlElement("ProductIdentifier")]
        [XmlElement("productidentifier")]
        public OnixLegacyProductId[] ProductIdentifier { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum ProductIdentifierEnum { ProductIdentifier, productidentifier }
        [XmlIgnore]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ProductIdentifierEnum[] ProductIdentifierChoice
        {
            get
            {
                if (ProductIdentifier == null) return null;
                ProductIdentifierEnum choice = SerializationSettings.UseShortTags ? ProductIdentifierEnum.productidentifier : ProductIdentifierEnum.ProductIdentifier;
                ProductIdentifierEnum[] result = new ProductIdentifierEnum[ProductIdentifier.Length];
                for (int i = 0; i < ProductIdentifier.Length; i++) result[i] = choice;
                return result;
            }
            set { }
        }

        [XmlChoiceIdentifier("BarcodeChoice")]
        [XmlElement("Barcode")]
        [XmlElement("b246")]
        public string Barcode { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum BarcodeEnum { Barcode, b246 }
        [XmlIgnore]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public BarcodeEnum BarcodeChoice
        {
            get { return SerializationSettings.UseShortTags ? BarcodeEnum.b246 : BarcodeEnum.Barcode; }
            set { }
        }

        [XmlChoiceIdentifier("ProductFormChoice")]
        [XmlElement("ProductForm")]
        [XmlElement("b012")]
        public OnixList7 ProductForm { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum ProductFormEnum { ProductForm, b012 }
        [XmlIgnore]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ProductFormEnum ProductFormChoice
        {
            get { return SerializationSettings.UseShortTags ? ProductFormEnum.b012 : ProductFormEnum.ProductForm; }
            set { }
        }

        [XmlChoiceIdentifier("ProductFormDetailChoice")]
        [XmlElement("ProductFormDetail")]
        [XmlElement("b333")]
        public OnixList78[] ProductFormDetail { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum ProductFormDetailEnum { ProductFormDetail, b333 }
        [XmlIgnore]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ProductFormDetailEnum[] ProductFormDetailChoice
        {
            get
            {
                if (ProductFormDetail == null) return null;
                ProductFormDetailEnum choice = SerializationSettings.UseShortTags ? ProductFormDetailEnum.b333 : ProductFormDetailEnum.ProductFormDetail;
                ProductFormDetailEnum[] result = new ProductFormDetailEnum[ProductFormDetail.Length];
                for (int i = 0; i < ProductFormDetail.Length; i++) result[i] = choice;
                return result;
            }
            set { }
        }

        [XmlChoiceIdentifier("ProductFormFeatureChoice")]
        [XmlElement("ProductFormFeature")]
        [XmlElement("productformfeature")]
        public OnixLegacyProductFormFeature[] ProductFormFeature { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum ProductFormFeatureEnum { ProductFormFeature, productformfeature }
        [XmlIgnore]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ProductFormFeatureEnum[] ProductFormFeatureChoice
        {
            get
            {
                if (ProductFormFeature == null) return null;
                ProductFormFeatureEnum choice = SerializationSettings.UseShortTags ? ProductFormFeatureEnum.productformfeature : ProductFormFeatureEnum.ProductFormFeature;
                ProductFormFeatureEnum[] result = new ProductFormFeatureEnum[ProductFormFeature.Length];
                for (int i = 0; i < ProductFormFeature.Length; i++) result[i] = choice;
                return result;
            }
            set { }
        }

        [XmlChoiceIdentifier("ProductFormDescriptionChoice")]
        [XmlElement("ProductFormDescription")]
        [XmlElement("b014")]
        public string ProductFormDescription { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum ProductFormDescriptionEnum { ProductFormDescription, b014 }
        [XmlIgnore]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ProductFormDescriptionEnum ProductFormDescriptionChoice
        {
            get { return SerializationSettings.UseShortTags ? ProductFormDescriptionEnum.b014 : ProductFormDescriptionEnum.ProductFormDescription; }
            set { }
        }

        [XmlChoiceIdentifier("NumberOfPiecesChoice")]
        [XmlElement("NumberOfPieces")]
        [XmlElement("b210")]
        public int NumberOfPieces { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum NumberOfPiecesEnum { NumberOfPieces, b210 }
        [XmlIgnore]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public NumberOfPiecesEnum NumberOfPiecesChoice
        {
            get { return SerializationSettings.UseShortTags ? NumberOfPiecesEnum.b210 : NumberOfPiecesEnum.NumberOfPieces; }
            set { }
        }

        [XmlChoiceIdentifier("TradeCategoryChoice")]
        [XmlElement("TradeCategory")]
        [XmlElement("b384")]
        public OnixList12 TradeCategory { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum TradeCategoryEnum { TradeCategory, b384 }
        [XmlIgnore]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public TradeCategoryEnum TradeCategoryChoice
        {
            get { return SerializationSettings.UseShortTags ? TradeCategoryEnum.b384 : TradeCategoryEnum.TradeCategory; }
            set { }
        }

        [XmlChoiceIdentifier("ProductContentTypeChoice")]
        [XmlElement("ProductContentType")]
        [XmlElement("b385")]
        public OnixList81[] ProductContentType { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum ProductContentTypeEnum { ProductContentType, b385 }
        [XmlIgnore]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ProductContentTypeEnum[] ProductContentTypeChoice
        {
            get
            {
                if (ProductContentType == null) return null;
                ProductContentTypeEnum choice = SerializationSettings.UseShortTags ? ProductContentTypeEnum.b385 : ProductContentTypeEnum.ProductContentType;
                ProductContentTypeEnum[] result = new ProductContentTypeEnum[ProductContentType.Length];
                for (int i = 0; i < ProductContentType.Length; i++) result[i] = choice;
                return result;
            }
            set { }
        }

        [XmlChoiceIdentifier("EpubTypeChoice")]
        [XmlElement("EpubType")]
        [XmlElement("b211")]
        public OnixList10 EpubType { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum EpubTypeEnum { EpubType, b211 }
        [XmlIgnore]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public EpubTypeEnum EpubTypeChoice
        {
            get { return SerializationSettings.UseShortTags ? EpubTypeEnum.b211 : EpubTypeEnum.EpubType; }
            set { }
        }

        [XmlChoiceIdentifier("EpubTypeVersionChoice")]
        [XmlElement("EpubTypeVersion")]
        [XmlElement("b212")]
        public string EpubTypeVersion { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum EpubTypeVersionEnum { EpubTypeVersion, b212 }
        [XmlIgnore]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public EpubTypeVersionEnum EpubTypeVersionChoice
        {
            get { return SerializationSettings.UseShortTags ? EpubTypeVersionEnum.b212 : EpubTypeVersionEnum.EpubTypeVersion; }
            set { }
        }

        [XmlChoiceIdentifier("EpubFormatDescriptionChoice")]
        [XmlElement("EpubFormatDescription")]
        [XmlElement("b216")]
        public string EpubFormatDescription { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum EpubFormatDescriptionEnum { EpubFormatDescription, b216 }
        [XmlIgnore]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public EpubFormatDescriptionEnum EpubFormatDescriptionChoice
        {
            get { return SerializationSettings.UseShortTags ? EpubFormatDescriptionEnum.b216 : EpubFormatDescriptionEnum.EpubFormatDescription; }
            set { }
        }

        [XmlChoiceIdentifier("EpubTypeNoteChoice")]
        [XmlElement("EpubTypeNote")]
        [XmlElement("b277")]
        public string EpubTypeNote { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum EpubTypeNoteEnum { EpubTypeNote, b277 }
        [XmlIgnore]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public EpubTypeNoteEnum EpubTypeNoteChoice
        {
            get { return SerializationSettings.UseShortTags ? EpubTypeNoteEnum.b277 : EpubTypeNoteEnum.EpubTypeNote; }
            set { }
        }

        [XmlChoiceIdentifier("DistinctiveTitleChoice")]
        [XmlElement("DistinctiveTitle")]
        [XmlElement("b028")]
        public string DistinctiveTitle { get; set; }
        [XmlIgnore]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public DistinctiveTitleEnum DistinctiveTitleChoice
        {
            get { return SerializationSettings.UseShortTags ? DistinctiveTitleEnum.b028 : DistinctiveTitleEnum.DistinctiveTitle; }
            set { }
        }

        [XmlChoiceIdentifier("TitlePrefixChoice")]
        [XmlElement("TitlePrefix")]
        [XmlElement("b030")]
        public string TitlePrefix { get; set; }
        [XmlIgnore]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public TitlePrefixEnum TitlePrefixChoice
        {
            get { return SerializationSettings.UseShortTags ? TitlePrefixEnum.b030 : TitlePrefixEnum.TitlePrefix; }
            set { }
        }

        [XmlChoiceIdentifier("TitleWithoutPrefixChoice")]
        [XmlElement("TitleWithoutPrefix")]
        [XmlElement("b031")]
        public string TitleWithoutPrefix { get; set; }
        [XmlIgnore]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public TitleWithoutPrefixEnum TitleWithoutPrefixChoice
        {
            get { return SerializationSettings.UseShortTags ? TitleWithoutPrefixEnum.b031 : TitleWithoutPrefixEnum.TitleWithoutPrefix; }
            set { }
        }

        [XmlChoiceIdentifier("SubtitleChoice")]
        [XmlElement("Subtitle")]
        [XmlElement("b029")]
        public string Subtitle { get; set; }
        [XmlIgnore]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public SubtitleEnum SubtitleChoice
        {
            get { return SerializationSettings.UseShortTags ? SubtitleEnum.b029 : SubtitleEnum.Subtitle; }
            set { }
        }

        [XmlChoiceIdentifier("ImprintNameChoice")]
        [XmlElement("ImprintName")]
        [XmlElement("b079")]
        public string ImprintName { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum ImprintNameEnum { ImprintName, b079 }
        [XmlIgnore]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ImprintNameEnum ImprintNameChoice
        {
            get { return SerializationSettings.UseShortTags ? ImprintNameEnum.b079 : ImprintNameEnum.ImprintName; }
            set { }
        }

        [XmlChoiceIdentifier("PublisherNameChoice")]
        [XmlElement("PublisherName")]
        [XmlElement("b081")]
        public string PublisherName { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum PublisherNameEnum { PublisherName, b081 }
        [XmlIgnore]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public PublisherNameEnum PublisherNameChoice
        {
            get { return SerializationSettings.UseShortTags ? PublisherNameEnum.b081 : PublisherNameEnum.PublisherName; }
            set { }
        }

        [XmlChoiceIdentifier("PublisherChoice")]
        [XmlElement("Publisher")]
        [XmlElement("publisher")]
        public OnixLegacyPublisher[] Publisher { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum PublisherEnum { Publisher, publisher }
        [XmlIgnore]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public PublisherEnum[] PublisherChoice
        {
            get
            {
                if (Publisher == null) return null;
                PublisherEnum choice = SerializationSettings.UseShortTags ? PublisherEnum.publisher : PublisherEnum.Publisher;
                PublisherEnum[] result = new PublisherEnum[Publisher.Length];
                for (int i = 0; i < Publisher.Length; i++) result[i] = choice;
                return result;
            }
            set { }
        }

        public string OnixPublisherName
        {
            get
            {
                string FoundPubName = "";

                if (!string.IsNullOrEmpty(PublisherName))
                    FoundPubName = PublisherName;
                else if ((Publisher != null) && (Publisher.Length > 0))
                {
                    List<int> SoughtPubTypes =
                        new List<int>() { 0, OnixLegacyPublisher.CONST_PUB_ROLE_PUBLISHER, OnixLegacyPublisher.CONST_PUB_ROLE_CO_PUB };

                    OnixLegacyPublisher FoundPublisher =
                        Publisher.Where(x => SoughtPubTypes.Contains(x.PublishingRole)).FirstOrDefault();

                    if ((FoundPublisher != null) && !string.IsNullOrEmpty(FoundPublisher.PublisherName))
                        FoundPubName = FoundPublisher.PublisherName;
                }

                return FoundPubName;
            }
        }

        #endregion

    }
}
