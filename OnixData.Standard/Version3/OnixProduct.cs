using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Xml.Serialization;

using OnixData.Version3.Content;
using OnixData.Version3.Language;
using OnixData.Version3.Market;
using OnixData.Version3.Price;
using OnixData.Version3.Publishing;
using OnixData.Version3.Related;
using OnixData.Version3.Supply;
using OnixData.Version3.Text;
using OnixData.Version3.Title;
using OnixData.Version3.Xml.Enums;

namespace OnixData.Version3
{
    /// <remarks/>
    [XmlType(AnonymousType = true)]
    public partial class OnixProduct
    {
        #region CONSTANTS

        public const int CONST_PRODUCT_TYPE_PROP = 1;
        public const int CONST_PRODUCT_TYPE_ISBN = 2;
        public const int CONST_PRODUCT_TYPE_EAN = 3;
        public const int CONST_PRODUCT_TYPE_UPC = 4;
        public const int CONST_PRODUCT_TYPE_ISMN = 5;
        public const int CONST_PRODUCT_TYPE_DOI = 6;
        public const int CONST_PRODUCT_TYPE_LCCN = 13;
        public const int CONST_PRODUCT_TYPE_GTIN = 14;
        public const int CONST_PRODUCT_TYPE_ISBN13 = 15;

        #endregion

        #region Parsing Error

        private string InputXml;
        private Exception ParsingError;

        public string GetInputXml() { return InputXml; }
        public void SetInputXml(string value) { InputXml = value; }

        public bool IsValid() { return (ParsingError == null); }

        public Exception GetParsingError() { return ParsingError; }
        public void SetParsingError(Exception value) { ParsingError = value; }

        #endregion

        #region ONIX Helpers

        public OnixSubject BisacCategoryCode
        {
            get
            {
                OnixSubject FoundSubject = new OnixSubject();

                if ((DescriptiveDetail != null) &&
                    (DescriptiveDetail.Subject != null) &&
                    (DescriptiveDetail.Subject.Length > 0))
                {
                    FoundSubject =
                        DescriptiveDetail.Subject.Where(x => x.SubjectSchemeIdentifierNum == OnixSubject.CONST_SUBJ_SCHEME_BISAC_CAT_ID).LastOrDefault();
                }

                return FoundSubject;
            }
        }

        public OnixSubject BisacRegionCode
        {
            get
            {
                OnixSubject FoundSubject = new OnixSubject();

                if ((DescriptiveDetail != null) &&
                    (DescriptiveDetail.Subject != null) &&
                    (DescriptiveDetail.Subject.Length > 0))
                {
                    FoundSubject =
                        DescriptiveDetail.Subject.Where(x => x.SubjectSchemeIdentifierNum == OnixSubject.CONST_SUBJ_SCHEME_REGION_ID).LastOrDefault();
                }

                return FoundSubject;
            }
        }

        public string Description
        {
            get
            {
                OnixCollateralDetail descCollateralDetail = CollateralDetail;

                string TempDescription = "";
                if (descCollateralDetail != null)
                {
                    OnixTextContent DescTextContent =
                        descCollateralDetail.OnixTextContentList
                            .Where(
                                x => (!string.IsNullOrEmpty(x.Text)) && (
                                    (x.TextType == 3) ||
                                    (x.TextType == 2)
                                )
                            )
                            .OrderBy(x => x.TextType)
                            .LastOrDefault();

                    if (DescTextContent != null)
                        TempDescription = DescTextContent.Text;
                }

                return TempDescription;
            }
        }

        private string isbnField;
        public string ISBN
        {
            get
            {
                OnixProductId[] ProductIdList = ProductIdentifier;

                string TempISBN = this.isbnField;
                if (string.IsNullOrEmpty(TempISBN))
                {
                    if ((ProductIdList != null) && (ProductIdList.Length > 0))
                    {
                        OnixProductId IsbnProductId =
                            ProductIdList.Where(x => x.ProductIDType == CONST_PRODUCT_TYPE_ISBN).LastOrDefault();

                        if ((IsbnProductId != null) && !string.IsNullOrEmpty(IsbnProductId.IDValue))
                            TempISBN = this.isbnField = IsbnProductId.IDValue;
                    }
                }

                return TempISBN;
            }
            set
            {
                this.isbnField = value;
            }
        }

        private long eanField = -1;
        public long EAN
        {
            get
            {
                OnixProductId[] ProductIdList = ProductIdentifier;

                long TempEAN = this.eanField;
                if (TempEAN <= 0)
                {
                    if ((ProductIdList != null) && (ProductIdList.Length > 0))
                    {
                        OnixProductId EanProductId =
                            ProductIdList.Where(x => (x.ProductIDType == CONST_PRODUCT_TYPE_EAN) ||
                                                     (x.ProductIDType == CONST_PRODUCT_TYPE_ISBN13)).LastOrDefault();

                        if ((EanProductId != null) && !string.IsNullOrEmpty(EanProductId.IDValue))
                            TempEAN = this.eanField = Convert.ToInt64(EanProductId.IDValue);
                    }
                }

                return TempEAN;
            }
            set
            {
                this.eanField = value;
            }
        }

        public string ImprintName
        {
            get
            {
                string FoundImprintName = "";

                if ((PublishingDetail != null) &&
                    (PublishingDetail.OnixImprintList != null) &&
                    (PublishingDetail.OnixImprintList.Length > 0))
                {
                    FoundImprintName = PublishingDetail.OnixImprintList[0].ImprintName;
                }

                return FoundImprintName;
            }
        }

        public string LastDateForReturns
        {
            get
            {
                string sLastDt = "";

                var SoughtSupplyDetail = USDRetailSupplyDetail;


                if ((SoughtSupplyDetail != null) &&
                    (SoughtSupplyDetail.OnixSupplyDateList != null) &&
                    (SoughtSupplyDetail.OnixSupplyDateList.Length > 0))
                {
                    var SoughtDate =
                        SoughtSupplyDetail.OnixSupplyDateList.Where(x => x.IsLasteDateForReturns()).FirstOrDefault();

                    if ((SoughtDate != null) && !string.IsNullOrEmpty(SoughtDate.Date))
                        sLastDt = SoughtDate.Date;
                }

                return sLastDt;
            }
        }

        public string LIBRARY_CONGRESS_NUM
        {
            get
            {
                string sLibCongressNum = "";

                OnixProductId[] ProductIdList = ProductIdentifier;

                if ((ProductIdList != null) && (ProductIdList.Length > 0))
                {
                    OnixProductId LccnProductId =
                        ProductIdList.Where(x => (x.ProductIDType == CONST_PRODUCT_TYPE_LCCN)).LastOrDefault();

                    if ((LccnProductId != null) && !string.IsNullOrEmpty(LccnProductId.IDValue))
                        sLibCongressNum = LccnProductId.IDValue;
                }

                return sLibCongressNum;
            }
        }

        public string NumberOfPages
        {
            get
            {
                string sNumOfPages = "";

                if ((this.ContentDetail != null) && (this.ContentDetail.PrimaryContentItem != null))
                    sNumOfPages = this.ContentDetail.PrimaryContentItem.NumberOfPages;

                if (string.IsNullOrEmpty(sNumOfPages))
                {
                    if ((this.DescriptiveDetail != null) && (this.DescriptiveDetail.Extent != null))
                    {
                        if (this.DescriptiveDetail.PageNumber > 0)
                            sNumOfPages = this.DescriptiveDetail.PageNumber.ToString();
                    }
                }

                return sNumOfPages;
            }
        }

        public string ProductForm
        {
            get { return (this.DescriptiveDetail != null ? this.DescriptiveDetail.ProductForm : ""); }
        }

        public string ProductFormDetail
        {
            get { return (this.DescriptiveDetail != null ? this.DescriptiveDetail.ProductForm : ""); }
        }

        public string[] ProductFormDetailList
        {
            get { return (this.DescriptiveDetail != null ? this.DescriptiveDetail.ProductFormDetail : new string[0]); }
        }

        public string PrimaryContentType
        {
            get { return (this.DescriptiveDetail != null ? this.DescriptiveDetail.PrimaryContentType : ""); }
        }

        public string[] AllProductContentTypeList
        {
            get { return (this.DescriptiveDetail != null ? this.DescriptiveDetail.OnixAllContentTypeList : new string[0]); }
        }

        public string[] ProductContentTypeList
        {
            get { return (this.DescriptiveDetail != null ? this.DescriptiveDetail.ProductContentType : new string[0]); }
        }

        public string PROPRIETARY_ID
        {
            get
            {
                string sPropId = "";

                OnixProductId[] ProductIdList = ProductIdentifier;

                if ((ProductIdList != null) && (ProductIdList.Length > 0))
                {
                    OnixProductId PropProductId =
                        ProductIdList.Where(x => (x.ProductIDType == CONST_PRODUCT_TYPE_PROP)).LastOrDefault();

                    if ((PropProductId != null) && !string.IsNullOrEmpty(PropProductId.IDValue))
                        sPropId = PropProductId.IDValue;
                }

                return sPropId;
            }
        }

        public string ProprietaryImprintName
        {
            get
            {
                string FoundImprintName = "";

                if (this.PublishingDetail != null)
                {
                    OnixImprint[] ImprintList = this.PublishingDetail.OnixImprintList;
                    if ((ImprintList != null) && (ImprintList.Length > 0))
                    {
                        OnixImprint FoundImprint = ImprintList.Where(x => x.IsProprietaryName()).LastOrDefault();

                        if (FoundImprint != null)
                            FoundImprintName = FoundImprint.ImprintName;
                    }
                }

                return FoundImprintName;
            }
        }

        public List<OnixSupplierId> ProprietarySupplierIds
        {
            get
            {
                List<OnixSupplierId> PropSupplierIds = new List<OnixSupplierId>();

                if (this.ProductSupply != null)
                {
                    foreach (OnixProductSupply TmpSupply in this.ProductSupply)
                    {
                        foreach (OnixSupplyDetail TmpSupplyDetail in TmpSupply.OnixSupplyDetailList)
                        {
                            TmpSupplyDetail.OnixSupplierList
                                           .Where(x => x.OnixSupplierIdList != null &&
                                                       x.OnixSupplierIdList.Any(y => y.SupplierIDType == OnixSupplierId.CONST_SUPPL_ID_TYPE_PROP))
                                           .ToList()
                                           .ForEach(x => PropSupplierIds.AddRange(x.OnixSupplierIdList));
                        }
                    }
                }

                return PropSupplierIds;
            }
        }

        public string PublisherName
        {
            get
            {
                string FoundPubName = "";

                if ((PublishingDetail != null) &&
                    (PublishingDetail.OnixPublisherList != null) &&
                    (PublishingDetail.OnixPublisherList.Length > 0))
                {
                    List<int> SoughtPubTypes =
                        new List<int>() { 0, OnixPublisher.CONST_PUB_ROLE_PUBLISHER, OnixPublisher.CONST_PUB_ROLE_CO_PUB };

                    OnixPublisher FoundPublisher =
                        PublishingDetail.OnixPublisherList.Where(x => SoughtPubTypes.Contains(x.PublishingRole)).LastOrDefault();

                    if ((FoundPublisher != null) && !string.IsNullOrEmpty(FoundPublisher.PublisherName))
                        FoundPubName = FoundPublisher.PublisherName;
                    else
                    {
                        FoundPublisher =
                            PublishingDetail.OnixPublisherList.Where(x => x.PublishingRole == OnixPublisher.CONST_PUB_ROLE_IN_ASSOC).LastOrDefault();

                        if ((FoundPublisher != null) && !string.IsNullOrEmpty(FoundPublisher.PublisherName))
                            FoundPubName = FoundPublisher.PublisherName;
                    }
                }

                return FoundPubName;
            }
        }

        public string PublishingStatus
        {
            get { return (PublishingDetail != null) ? PublishingDetail.PublishingStatus : ""; }
        }

        public OnixContributor PrimaryAuthor
        {
            get
            {
                OnixContributor MainAuthor = new OnixContributor();

                if ((DescriptiveDetail.Contributor != null) && (DescriptiveDetail.Contributor.Length > 0))
                {
                    MainAuthor =
                        DescriptiveDetail.Contributor.Where(x => x.ContributorRole.Contains(OnixContributor.CONST_CONTRIB_ROLE_AUTHOR)).FirstOrDefault();
                }

                return MainAuthor;
            }
        }

        public OnixMeasure Height
        {
            get { return GetMeasurement(OnixMeasure.CONST_MEASURE_TYPE_HEIGHT); }
        }

        public OnixMeasure Thick
        {
            get { return GetMeasurement(OnixMeasure.CONST_MEASURE_TYPE_THICK); }
        }

        public OnixMeasure Weight
        {
            get { return GetMeasurement(OnixMeasure.CONST_MEASURE_TYPE_WEIGHT); }
        }

        public OnixMeasure Width
        {
            get { return GetMeasurement(OnixMeasure.CONST_MEASURE_TYPE_WIDTH); }
        }

        public bool HasMissingSalesRightsData()
        {
            return (this.PublishingDetail != null) ? this.PublishingDetail.MissingSalesRightsDataFlag : false;
        }

        public bool HasNoSalesRightsinUS()
        {
            return (this.PublishingDetail != null) ? this.PublishingDetail.NoSalesRightsInUSFlag : false;
        }

        public bool HasNotForSaleRights()
        {
            bool bNotForSalesRights = false;

            if ((this.PublishingDetail != null) && (this.PublishingDetail.OnixSalesRightsList != null) && (this.PublishingDetail.OnixSalesRightsList.Count() > 0))
            {
                bNotForSalesRights = this.PublishingDetail.OnixSalesRightsList.Any(x => x.HasNotForSalesRights);
            }

            return bNotForSalesRights;
        }

        public bool HasOutsideUSCountrySalesRights()
        {
            return (this.PublishingDetail != null) ? this.PublishingDetail.SalesRightsInNonUSCountryFlag : false;
        }

        public bool HasSalesRights()
        {
            bool bSalesRights = false;

            if ((this.PublishingDetail != null) && (this.PublishingDetail.OnixSalesRightsList != null) && (this.PublishingDetail.OnixSalesRightsList.Count() > 0))
            {
                bSalesRights = this.PublishingDetail.OnixSalesRightsList.Any(x => x.HasSalesRights);
            }

            return bSalesRights;
        }

        public bool HasUSDPrice()
        {
            bool bHasUSDPrice = false;

            if (this.ProductSupply != null)
            {
                foreach (OnixProductSupply TmpProductSupply in this.ProductSupply)
                {
                    foreach (OnixSupplyDetail TmpSupplyDetail in TmpProductSupply.OnixSupplyDetailList)
                    {
                        OnixPrice[] Prices = TmpSupplyDetail.OnixPriceList;

                        bHasUSDPrice = Prices.Any(x => x.HasSoughtPriceTypeCode() && (x.CurrencyCode == "USD"));

                        if (bHasUSDPrice)
                            break;
                    }
                }
            }

            return bHasUSDPrice;
        }


        public bool HasUSDRetailPrice()
        {
            bool bHasSoughtPrice = false;

            if (this.ProductSupply != null)
            {
                foreach (OnixProductSupply TmpProductSupply in this.ProductSupply)
                {
                    foreach (OnixSupplyDetail TmpSupplyDetail in TmpProductSupply.OnixSupplyDetailList)
                    {
                        OnixPrice[] Prices = TmpSupplyDetail.OnixPriceList;

                        bHasSoughtPrice =
                            Prices.Any(x => (x.PriceType == OnixPrice.CONST_PRICE_TYPE_RRP_EXCL) && (x.CurrencyCode == "USD"));

                        if (bHasSoughtPrice)
                            break;
                    }
                }
            }

            return bHasSoughtPrice;
        }

        public bool HasUSRights()
        {
            bool bHasUSRights = false;

            bHasUSRights = (this.PublishingDetail != null) ? this.PublishingDetail.SalesRightsInUSFlag : false;

            return bHasUSRights;
        }

        public bool HasWorldSalesRights()
        {
            return (this.PublishingDetail != null) ? this.PublishingDetail.SalesRightsAllWorldFlag : false;
        }

        public string SeriesNumber
        {
            get
            {
                string FoundSeriesNum = "";

                if (DescriptiveDetail != null)
                    FoundSeriesNum = DescriptiveDetail.SeriesNumber;

                return FoundSeriesNum;
            }
        }

        public string SeriesTitle
        {
            get
            {
                string FoundSeriesTitle = "";

                if (DescriptiveDetail != null)
                    FoundSeriesTitle = DescriptiveDetail.SeriesTitle;

                return FoundSeriesTitle;
            }
        }

        public OnixPrice USDCostPrice
        {
            get
            {
                OnixPrice USDPrice = new OnixPrice();

                OnixSupplyDetail TargetSupplyDetail = USDRetailSupplyDetail;

                if ((TargetSupplyDetail != null) && (TargetSupplyDetail.OnixPriceList != null) && (TargetSupplyDetail.OnixPriceList.Length > 0))
                {
                    OnixPrice[] Prices = TargetSupplyDetail.OnixPriceList;

                    USDPrice =
                        Prices.Where(x => x.HasSoughtSupplyCostPriceType() && (x.CurrencyCode == "USD")).FirstOrDefault();

                    if (USDPrice == null)
                        USDPrice = new OnixPrice();
                }

                return USDPrice;
            }
        }

        public OnixPrice USDRetailPrice
        {
            get
            {
                OnixPrice USDPrice = new OnixPrice();
                OnixSupplyDetail TargetSupplyDetail = USDRetailSupplyDetail;

                if ((TargetSupplyDetail != null) && (TargetSupplyDetail.OnixPriceList != null) && (TargetSupplyDetail.OnixPriceList.Length > 0))
                {
                    OnixPrice[] Prices = TargetSupplyDetail.OnixPriceList;

                    USDPrice =
                        Prices.Where(x => (x.PriceType == OnixPrice.CONST_PRICE_TYPE_RRP_EXCL) && (x.CurrencyCode == "USD")).FirstOrDefault();

                    if (USDPrice == null)
                        USDPrice = new OnixPrice();
                }

                return USDPrice;
            }
        }

        public OnixPrice USDValidPrice
        {
            get
            {
                OnixPrice USDPrice = new OnixPrice();

                if ((USDValidPriceList != null) && (USDValidPriceList.Count > 0))
                    USDPrice = USDValidPriceList.ElementAt(0);

                return USDPrice;
            }
        }

        public List<OnixPrice> USDValidPriceList
        {
            get
            {
                List<OnixPrice> USDPriceList = new List<OnixPrice>();

                if (this.ProductSupply != null)
                {
                    foreach (OnixProductSupply TmpPrdSupply in this.ProductSupply)
                    {
                        foreach (var TmpSupplyDetail in TmpPrdSupply.OnixSupplyDetailList)
                        {
                            if (TmpSupplyDetail != null)
                            {
                                if ((TmpSupplyDetail != null) &&
                                    (TmpSupplyDetail.OnixPriceList != null) &&
                                    (TmpSupplyDetail.OnixPriceList.Length > 0))
                                {
                                    OnixPrice[] Prices = TmpSupplyDetail.OnixPriceList;

                                    var TmpPriceList =
                                        Prices.Where(x => x.HasSoughtPriceTypeCode() && (x.CurrencyCode == "USD")).ToArray();

                                    if ((TmpPriceList != null) && (TmpPriceList.Length > 0))
                                        USDPriceList.AddRange(TmpPriceList);
                                }
                            }
                        }
                    }
                }

                return USDPriceList;
            }
        }

        public OnixSupplyDetail USDRetailSupplyDetail
        {
            get
            {
                OnixSupplyDetail SupplyDetail = new OnixSupplyDetail();

                if (this.ProductSupply != null)
                {
                    foreach (OnixProductSupply TmpPrdSupply in this.ProductSupply)
                    {
                        foreach (OnixSupplyDetail TmpSupplyDetail in TmpPrdSupply.OnixSupplyDetailList)
                        {
                            OnixPrice[] Prices = TmpSupplyDetail.OnixPriceList;

                            OnixPrice USDPrice =
                                Prices.Where(x => (x.PriceType == OnixPrice.CONST_PRICE_TYPE_RRP_EXCL) && (x.CurrencyCode == "USD")).FirstOrDefault();

                            if ((USDPrice != null) && (USDPrice.PriceAmountNum > 0))
                            {
                                SupplyDetail = TmpSupplyDetail;
                                break;
                            }
                        }
                    }
                }

                return SupplyDetail;
            }
        }

        private string upcField;
        public string UPC
        {
            get
            {
                OnixProductId[] ProductIdList = ProductIdentifier;

                string TempUPC = this.upcField;
                if (string.IsNullOrEmpty(TempUPC))
                {
                    if ((ProductIdList != null) && (ProductIdList.Length > 0))
                    {
                        OnixProductId UpcProductId =
                            ProductIdList.Where(x => x.ProductIDType == CONST_PRODUCT_TYPE_UPC).LastOrDefault();

                        if ((UpcProductId != null) && !string.IsNullOrEmpty(UpcProductId.IDValue))
                            TempUPC = this.upcField = UpcProductId.IDValue;
                    }
                }

                return TempUPC;
            }
            set
            {
                this.upcField = value;
            }
        }

        public string Title
        {
            get
            {
                string ProductTitle = "";

                if ((DescriptiveDetail != null) &&
                    (DescriptiveDetail.TitleDetail != null) &&
                    (DescriptiveDetail.TitleDetail.Where((td) => td.TitleTypeNum == OnixTitleElement.CONST_TITLE_TYPE_PRODUCT) != null))
                {
                    OnixTitleDetail ProductTitleDetail = DescriptiveDetail.TitleDetail.Where((td) => td.TitleTypeNum == OnixTitleElement.CONST_TITLE_TYPE_PRODUCT).First();

                    if (ProductTitleDetail.FirstTitleElement != null)
                    {
                        ProductTitle = ProductTitleDetail.FirstTitleElement.Title;

                        if (!string.IsNullOrEmpty(ProductTitleDetail.FirstTitleElement.Subtitle))
                            ProductTitle += ": " + ProductTitleDetail.FirstTitleElement.Subtitle;
                    }
                }

                return ProductTitle;
            }
        }

        #endregion

        #region Reference Tags

        /// <summary>
        /// For every product, you must choose a single record reference which will uniquely identify the Information record which you send out about that product, and which will remain as its permanent identifier every time you send an update.
        /// It doesn’t matter what reference you choose, provided that it is unique and permanent.
        /// This record reference doesn’t identify the product – even though you may choose to use the ISBN or another product identifier as a part or the whole of your record reference – it identifies your information record about the product, so that the person to whom you are sending an update can match it with what you have previously sent.
        /// A good way of generating references which are not part of a recognized product identification scheme but which can be guaranteed to be unique is to prefix a product identifier or a meaningless row ID from your internal database with a reversed Internet domain name which is registered to your organization (reversal prevents the record reference appearing to be a resolvable URL).
        /// Alternatively, use a UUID.
        /// This field is mandatory and non-repeating.
        /// </summary>
        [XmlChoiceIdentifier("RecordReferenceChoice")]
        [XmlElement("RecordReference")]
        [XmlElement("a001")]
        public string RecordReference { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum RecordReferenceEnum { RecordReference, a001 }
        [XmlIgnore, DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public RecordReferenceEnum RecordReferenceChoice
        {
            get { return SerializationSettings.UseShortTags ? RecordReferenceEnum.a001 : RecordReferenceEnum.RecordReference; }
            set { }
        }

        /// <summary>
        /// An ONIX code which indicates the type of notification or update which you are sending.
        /// Mandatory and non-repeating.
        /// </summary>
        /// <remarks>Onix List 1</remarks>
        [XmlChoiceIdentifier("NotificationTypeChoice")]
        [XmlElement("NotificationType")]
        [XmlElement("a002")]
        public int NotificationType { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum NotificationTypeEnum { NotificationType, a002 }
        [XmlIgnore, DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public NotificationTypeEnum NotificationTypeChoice
        {
            get { return SerializationSettings.UseShortTags ? NotificationTypeEnum.a002 : NotificationTypeEnum.NotificationType; }
            set { }
        }

        /// <summary>
        /// Free text which indicates the reason why an ONIX record is being deleted.
        /// Optional and repeatable, and may occur only when the <see cref="NotificationType"/> element carries the code value 05.
        /// The language attribute is optional for a single instance of <see cref="DeletionText"/>, but must be included in each instance if <see cref="DeletionText"/> is repeated.
        /// Note that it refers to the reason why the record is being deleted, not the reason why a product has been ‘deleted’ (in industries which use this terminology when a product is withdrawn).
        /// </summary>
        [XmlChoiceIdentifier("DeletionTextChoice")]
        [XmlElement("DeletionText")]
        [XmlElement("a199")]
        public string[] DeletionText { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum DeletionTextEnum { DeletionText, a199 }
        [XmlIgnore, DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public DeletionTextEnum[] DeletionTextChoice
        {
            get
            {
                if (DeletionText == null) return null;
                DeletionTextEnum choice = SerializationSettings.UseShortTags ? DeletionTextEnum.a199 : DeletionTextEnum.DeletionText;
                DeletionTextEnum[] result = new DeletionTextEnum[DeletionText.Length];
                for (int i = 0; i < DeletionText.Length; i++) result[i] = choice;
                return result;
            }
            set { }
        }

        /// <summary>
        /// An ONIX code which indicates the type of source which has issued the ONIX record.
        /// Optional and non-repeating, independently of the occurrence of any other field.
        /// </summary>
        /// <remarks>Onix List 3</remarks>
        [XmlChoiceIdentifier("RecordSourceTypeChoice")]
        [XmlElement("RecordSourceType")]
        [XmlElement("a194")]
        public int RecordSourceType { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum RecordSourceTypeEnum { RecordSourceType, a194 }
        [XmlIgnore, DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public RecordSourceTypeEnum RecordSourceTypeChoice
        {
            get { return SerializationSettings.UseShortTags ? RecordSourceTypeEnum.a194 : RecordSourceTypeEnum.RecordSourceType; }
            set { }
        }

        /// <summary>
        /// A group of data elements which together define an identifier of the organization which is the source of the ONIX record.
        /// Optional, and repeatable in order to send multiple identifiers for the same organization.
        /// </summary>
        [XmlChoiceIdentifier("RecordSourceIdentifierChoice")]
        [XmlElement("RecordSourceIdentifier")]
        [XmlElement("recordsourceidentifier")]
        public OnixRecordSourceIdentifier[] RecordSourceIdentifier { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum RecordSourceIdentifierEnum { RecordSourceIdentifier, recordsourceidentifier }
        [XmlIgnore, DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public RecordSourceIdentifierEnum[] RecordSourceIdentifierChoice
        {
            get
            {
                if (RecordSourceIdentifier == null) return null;
                RecordSourceIdentifierEnum choice = SerializationSettings.UseShortTags ? RecordSourceIdentifierEnum.recordsourceidentifier : RecordSourceIdentifierEnum.RecordSourceIdentifier;
                RecordSourceIdentifierEnum[] result = new RecordSourceIdentifierEnum[RecordSourceIdentifier.Length];
                for (int i = 0; i < RecordSourceIdentifier.Length; i++) result[i] = choice;
                return result;
            }
            set { }
        }

        /// <summary>
        /// The name of the party which issued the record, as free text.
        /// Optional and non-repeating, independently of the occurrence of any other field.
        /// </summary>
        [XmlChoiceIdentifier("RecordSourceNameChoice")]
        [XmlElement("RecordSourceName")]
        [XmlElement("a197")]
        public string RecordSourceName { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum RecordSourceNameEnum { RecordSourceName, a197 }
        [XmlIgnore, DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public RecordSourceNameEnum RecordSourceNameChoice
        {
            get { return SerializationSettings.UseShortTags ? RecordSourceNameEnum.a197 : RecordSourceNameEnum.RecordSourceName; }
            set { }
        }

        /// <summary>
        /// <para>A group of data elements which together specify an identifier of a product in accordance with a particular scheme.</para>
        /// 
        /// <para>Mandatory within <see cref="OnixProduct"/>, and repeatable with different identifiers for the same product.
        /// As well as standard identifiers, the composite allows proprietary identifiers (for example SKUs assigned by wholesalers or vendors) to be sent as part of the ONIX record.</para>
        /// 
        /// <para>ISBN-13 numbers in their unhyphenated form constitute a range of EAN.UCC GTIN-13 numbers that has been reserved for the international book trade.
        /// Effective from 1 January 2007, it was agreed by ONIX national groups that it should be mandatory in an ONIX <see cref="OnixProduct"/> record for any item carrying an ISBN-13 to include the ISBN-13 labelled as an EAN.UCC GTIN-13 number (ProductIDType code 03), since this is how the ISBN-13 will be used in book trade transactions.
        /// For many ONIX applications this will also be sufficient.</para>
        /// 
        /// <para>For some ONIX applications, however, particularly when data is to be supplied to the library sector, there may be reasons why the ISBN-13 must also be sent labelled distinctively as an ISBN-13 (ProductIDType code 15).
        /// Users should consult ‘good practice’ guidelines and/or discuss with their trading partners.</para>
        /// 
        /// <para>Note that for some identifiers such as ISBN, punctuation (typically hyphens or spaces for ISBNs) is used to enhance readability when printed, but the punctuation is dropped when carried in ONIX data.
        /// But for other identifiers – for example DOI – the punctuation is an integral part of the identifier and must always be included.</para>
        /// </summary>
        [XmlChoiceIdentifier("ProductIdentifierChoice")]
        [XmlElement("ProductIdentifier")]
        [XmlElement("productidentifier")]
        public OnixProductId[] ProductIdentifier { get; set; }
        [XmlIgnore, DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
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

        /// <summary>
        /// A group of data elements which together specify a barcode type and its position on a product.
        /// Optional: expected to be used only in North America.
        /// Repeatable if more than one type of barcode is carried on a single product.
        /// The absence of this composite does not mean that a product is not bar-coded.
        /// </summary>
        [XmlChoiceIdentifier("BarcodeChoice")]
        [XmlElement("Barcode")]
        [XmlElement("barcode")]
        public OnixBarcode[] Barcode { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum BarcodeEnum { Barcode, barcode }
        [XmlIgnore, DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public BarcodeEnum[] BarcodeChoice
        {
            get
            {
                if (Barcode == null) return null;
                BarcodeEnum choice = SerializationSettings.UseShortTags ? BarcodeEnum.barcode : BarcodeEnum.Barcode;
                BarcodeEnum[] result = new BarcodeEnum[Barcode.Length];
                for (int i = 0; i < Barcode.Length; i++) result[i] = choice;
                return result;
            }
            set { }
        }

        /// <summary>
        /// The descriptive detail block covers data elements which are essentially part of the factual description of the form and content of a product.
        /// The block as a whole is non-repeating.
        /// It is mandatory in any <see cref="OnixProduct"/> record unless <see cref="NotificationType"/> indicates that the record is an update notice which carries only those blocks in which changes have occurred.
        /// </summary>
        [XmlChoiceIdentifier("DescriptiveDetailChoice")]
        [XmlElement("DescriptiveDetail")]
        [XmlElement("descriptivedetail")]
        public OnixDescriptiveDetail DescriptiveDetail { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum DescriptiveDetailEnum { DescriptiveDetail, descriptivedetail };
        [XmlIgnore, DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public DescriptiveDetailEnum DescriptiveDetailChoice
        {
            get { return SerializationSettings.UseShortTags ? DescriptiveDetailEnum.descriptivedetail : DescriptiveDetailEnum.DescriptiveDetail; }
            set { }
        }

        [XmlChoiceIdentifier("CollateralDetailChoice")]
        [XmlElement("CollateralDetail")]
        [XmlElement("collateraldetail")]
        public OnixCollateralDetail CollateralDetail { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum CollateralDetailEnum { CollateralDetail, collateraldetail };
        [XmlIgnore, DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public CollateralDetailEnum CollateralDetailChoice
        {
            get { return SerializationSettings.UseShortTags ? CollateralDetailEnum.collateraldetail : CollateralDetailEnum.CollateralDetail; }
            set { }
        }

        /// <remarks/>
        [XmlChoiceIdentifier("ContentDetailChoice")]
        [XmlElement("ContentDetail")]
        [XmlElement("contentdetail")]
        public OnixContentDetail ContentDetail { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum ContentDetailEnum { ContentDetail, contentdetail };
        [XmlIgnore, DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ContentDetailEnum ContentDetailChoice
        {
            get { return SerializationSettings.UseShortTags ? ContentDetailEnum.contentdetail : ContentDetailEnum.ContentDetail; }
            set { }
        }

        /// <remarks/>
        [XmlChoiceIdentifier("PublishingDetailChoice")]
        [XmlElement("PublishingDetail")]
        [XmlElement("publishingdetail")]
        public OnixPublishingDetail PublishingDetail { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum PublishingDetailEnum { PublishingDetail, publishingdetail }
        [XmlIgnore, DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public PublishingDetailEnum PublishingDetailChoice
        {
            get { return SerializationSettings.UseShortTags ? PublishingDetailEnum.publishingdetail : PublishingDetailEnum.PublishingDetail; }
            set { }
        }

        /// <remarks/>
        [XmlChoiceIdentifier("RelatedMaterialChoice")]
        [XmlElement("RelatedMaterial")]
        [XmlElement("relatedmaterial")]
        public OnixRelatedMaterial RelatedMaterial { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum RelatedMaterialEnum { RelatedMaterial, relatedmaterial }
        [XmlIgnore, DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public RelatedMaterialEnum RelatedMaterialChoice
        {
            get { return SerializationSettings.UseShortTags ? RelatedMaterialEnum.relatedmaterial : RelatedMaterialEnum.RelatedMaterial; }
            set { }
        }

        /// <remarks/>
        [XmlChoiceIdentifier("ProductSupplyChoice")]
        [XmlElement("ProductSupply")]
        [XmlElement("productsupply")]
        public OnixProductSupply[] ProductSupply { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum ProductSupplyEnum { ProductSupply, productsupply }
        [XmlIgnore, DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ProductSupplyEnum[] ProductSupplyChoice
        {
            get
            {
                if (ProductSupply == null) return null;
                ProductSupplyEnum choice = SerializationSettings.UseShortTags ? ProductSupplyEnum.productsupply : ProductSupplyEnum.ProductSupply;
                ProductSupplyEnum[] result = new ProductSupplyEnum[ProductSupply.Length];
                for (int i = 0; i < ProductSupply.Length; i++) result[i] = choice;
                return result;
            }
            set { }
        }

        #endregion

        #region Support Methods

        public OnixMeasure GetMeasurement(int pnType, bool pbMetricPreferred = false)
        {
            OnixMeasure FoundMeasurement = new OnixMeasure();

            if ((DescriptiveDetail != null) &&
                (DescriptiveDetail.Measure != null) &&
                (DescriptiveDetail.Measure.Length > 0))
            {
                OnixMeasure[] MeasureList = DescriptiveDetail.Measure;

                OnixMeasure MeasureType = null;

                MeasureType = MeasureList.Where(x => (x.MeasureType == pnType) && !x.IsMetricUnitType()).LastOrDefault();
                if (MeasureType != null)
                    FoundMeasurement = MeasureType;
                
                if ((MeasureType == null) || (MeasureType.Measurement == 0) || pbMetricPreferred)
                {
                    MeasureType = MeasureList.Where(x => (x.MeasureType == pnType) && x.IsMetricUnitType()).LastOrDefault();

                    if (MeasureType != null)
                        FoundMeasurement = MeasureType;
                }
            }

            return FoundMeasurement;
        }

        public string GetVolumeMeasurementUnit()
        {
            string sVolumeUnit = "";

            if (!string.IsNullOrEmpty(this.Thick.MeasureUnitCode))
                sVolumeUnit = this.Thick.MeasureUnitCode;
            else if (!string.IsNullOrEmpty(this.Height.MeasureUnitCode))
                sVolumeUnit = this.Height.MeasureUnitCode;
            else if (!string.IsNullOrEmpty(this.Width.MeasureUnitCode))
                sVolumeUnit = this.Width.MeasureUnitCode;

            return sVolumeUnit;
        }

        #endregion
    }
}
