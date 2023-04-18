using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace OnixData.Legacy
{
    /// <remarks/>
    [XmlType(AnonymousType = true)]
    [XmlRoot(Namespace = "", IsNullable = false)]
    public partial class OnixLegacyProduct : OnixLegacyBaseProduct
    {
        #region CONSTANTS

        private const char CONST_KEYWORDS_DELIM = ';';

        #endregion

        public OnixLegacyProduct()
        {
            SalesRightsInUS = SalesRightsInNonUSCountry = false;
            NoSalesRightsInUS = SalesRightsAllWorld = false;

            RecordReference = "";
            NotificationType = NumberOfPieces = TradeCategory = -1;

            ProductIdentifier = new OnixLegacyProductId[0];

            BookFormDetail = "";
            ProductFormDetail = new Lists.OnixList78[0];
            ProductFormDescription = "";
            ProductContentType = new string[0];
            EpubType = EpubTypeVersion = EpubFormatDescription = "";

            AudienceCode = null;
            EditionTypeCode = null;
            EditionNumber = null;

            ProductFormFeature = new OnixLegacyProductFormFeature();

            ContributorStatement = "";

            Language = new OnixLegacyLanguage[0];

            NumberOfPages = PagesArabic = PagesRoman = "";

            Illustrations = new OnixLegacyIllustrations();

            BASICMainSubject = "";
            MainSubject = new OnixLegacySubject[0];

            Title = new OnixLegacyTitle[0];

            Audience = new OnixLegacyAudience[0];
            AudienceRange = new OnixLegacyAudRange[0];
            Contributor = new OnixLegacyContributor[0];
            Extent = new OnixLegacyExtent[0];
            Series = new OnixLegacySeries[0];
            Set = new OnixLegacySet[0];
            Subject = new OnixLegacySubject[0];
            Complexity = new OnixLegacyComplexity[0];
            Imprint = new OnixLegacyImprint[0];
            Measure = new OnixLegacyMeasure[0];
            MediaFile = new OnixLegacyMediaFile[0];
            OtherText = new OnixLegacyOtherText[0];
            RelatedProduct = new OnixLegacyRelatedProduct[0];
            SalesRights = new OnixLegacySalesRights[0];

            NotForSale = new OnixLegacyNotForSale[0];

            CityOfPublication = CountryOfPublication = PublishingStatus = "";
            AnnouncementDate = TradeAnnouncementDate = "";

            PublicationDate = YearFirstPublished = "";

            usdPriceField = null;

            SupplyDetail = new OnixLegacySupplyDetail[0];
            ProductClassification = new OnixLegacyProductClassification[0];

            ParsingError = null;
        }

        private bool SalesRightsInUS;
        private bool SalesRightsInNonUSCountry;
        private bool NoSalesRightsInUS;
        private bool SalesRightsAllWorld;

        private OnixLegacyPrice usdPriceField;

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

        public OnixLegacySubject BisacCategoryCode
        {
            get
            {
                OnixLegacySubject FoundSubject = new OnixLegacySubject();

                OnixLegacySubject[] SubjectList = Subject;
                if ((SubjectList != null) && (SubjectList.Length > 0))
                {
                    FoundSubject =
                        SubjectList.Where(x => x.SubjectSchemeIdentifierNum == OnixLegacySubject.CONST_SUBJ_SCHEME_BISAC_CAT_ID).LastOrDefault();
                }

                return FoundSubject;
            }
        }

        public OnixLegacySubject BisacRegionCode
        {
            get
            {
                OnixLegacySubject FoundSubject = new OnixLegacySubject();

                OnixLegacySubject[] SubjectList = Subject;
                if ((SubjectList != null) && (SubjectList.Length > 0))
                {
                    FoundSubject =
                        SubjectList.Where(x => x.SubjectSchemeIdentifierNum == OnixLegacySubject.CONST_SUBJ_SCHEME_REGION_ID).LastOrDefault();
                }

                return FoundSubject;
            }
        }

        public bool HasFutureRetailPrice()
        {
            bool bHasFuturePrice = false;

            if (SupplyDetail != null)
            {
                foreach (OnixLegacySupplyDetail TmpSupplyDetail in SupplyDetail)
                {
                    if ((TmpSupplyDetail.OnixPriceList != null) && (TmpSupplyDetail.OnixPriceList.Length > 0))
                    {
                        bHasFuturePrice =
                            TmpSupplyDetail.OnixPriceList.Any(x => !string.IsNullOrEmpty(x.PriceEffectiveFrom) && (x.PriceTypeCode == OnixLegacyPrice.CONST_PRICE_TYPE_RRP_EXCL));

                        if (bHasFuturePrice)
                            break;
                    }
                }
            }

            return bHasFuturePrice;
        }

        public bool HasUSDPrice()
        {
            bool bHasUSDPrice = false;

            if (SupplyDetail != null)
            {
                foreach (OnixLegacySupplyDetail TmpSupplyDetail in SupplyDetail)
                {
                    if ((TmpSupplyDetail.OnixPriceList != null) && (TmpSupplyDetail.OnixPriceList.Length > 0))
                    {
                        bHasUSDPrice =
                            TmpSupplyDetail.OnixPriceList.Any(x => x.HasSoughtPriceTypeCode() && (x.CurrencyCode == "USD"));

                        if (bHasUSDPrice)
                            break;
                    }
                }
            }

            return bHasUSDPrice;
        }

        public bool HasUSDRetailPrice()
        {
            bool bHasUSDPrice = false;

            if (SupplyDetail != null)
            {
                foreach (OnixLegacySupplyDetail TmpSupplyDetail in SupplyDetail)
                {
                    if ((TmpSupplyDetail.OnixPriceList != null) && (TmpSupplyDetail.OnixPriceList.Length > 0))
                    {
                        bHasUSDPrice =
                            TmpSupplyDetail.OnixPriceList.Any(x => x.HasSoughtRetailPriceType() && (x.CurrencyCode == "USD"));

                        if (bHasUSDPrice)
                            break;
                    }
                }
            }

            return bHasUSDPrice;
        }

        public bool HasOtherCountryRights()
        {
            SetRightsFlags();

            return SalesRightsInNonUSCountry;
        }

        public bool HasNoneUSRights()
        {
            SetRightsFlags();

            return NoSalesRightsInUS;
        }

        public bool HasUSRights()
        {
            SetRightsFlags();

            return SalesRightsInUS;
        }

        public bool HasWorldRights()
        {
            SetRightsFlags();

            return SalesRightsAllWorld;
        }

        public OnixLegacyMeasure Height
        {
            get { return GetMeasurement(Lists.OnixList48.Height); }
        }

        public OnixLegacyMeasure Thick
        {
            get { return GetMeasurement(Lists.OnixList48.Thickness); }
        }

        public OnixLegacyMeasure Weight
        {
            get { return GetMeasurement(Lists.OnixList48.UnitWeight); }
        }

        public OnixLegacyMeasure Width
        {
            get { return GetMeasurement(Lists.OnixList48.Width); }
        }

        public string Keywords
        {
            get
            {
                string FoundKeywords = "";
                OnixLegacySubject FoundSubject = new OnixLegacySubject();

                OnixLegacySubject[] SubjectList = Subject;
                if ((SubjectList != null) && (SubjectList.Length > 0))
                {
                    FoundSubject =
                        SubjectList.Where(x => x.SubjectSchemeIdentifierNum == OnixLegacySubject.CONST_SUBJ_SCHEME_KEYWORDS).LastOrDefault();
                }

                if ((FoundSubject != null) && !string.IsNullOrEmpty(FoundSubject.SubjectHeadingText))
                    FoundKeywords = FoundSubject.SubjectHeadingText;

                return FoundKeywords;
            }
        }

        public string[] KeywordsList
        {
            get
            {
                string[] asKeywordsList = new string[0];

                if ((Keywords != null) && !string.IsNullOrEmpty(Keywords) && Keywords.Contains(CONST_KEYWORDS_DELIM))
                    asKeywordsList = Keywords.Split(CONST_KEYWORDS_DELIM);

                return asKeywordsList;
            }
        }

        public string OnixAudienceAgeFrom
        {
            get
            {
                string sAudAgeFrom = "";

                OnixLegacyAudRange[] AudRangeList = AudienceRange;
                if ((AudRangeList != null) && (AudRangeList.Length > 0))
                {
                    foreach (OnixLegacyAudRange TempAudRange in AudRangeList)
                    {
                        if (!string.IsNullOrEmpty(TempAudRange.USAgeFrom))
                            sAudAgeFrom = TempAudRange.USAgeFrom;
                    }
                }

                if (string.IsNullOrEmpty(sAudAgeFrom))
                    sAudAgeFrom = TranslateAudienceGradeToAge(OnixAudienceGradeFrom);

                return sAudAgeFrom;
            }
        }

        public string OnixAudienceAgeTo
        {
            get
            {
                string sAudAgeTo = "";

                OnixLegacyAudRange[] AudRangeList = AudienceRange;
                if ((AudRangeList != null) && (AudRangeList.Length > 0))
                {
                    foreach (OnixLegacyAudRange TempAudRange in AudRangeList)
                    {
                        if (!string.IsNullOrEmpty(TempAudRange.USAgeTo))
                            sAudAgeTo = TempAudRange.USAgeTo;
                    }
                }

                if (string.IsNullOrEmpty(sAudAgeTo))
                    sAudAgeTo = TranslateAudienceGradeToAge(OnixAudienceGradeTo);

                return sAudAgeTo;
            }
        }

        public string OnixAudienceCode
        {
            get
            {
                string sAudCode = "";

                if ((AudienceCode != null) && (AudienceCode.Length > 0))
                    sAudCode = AudienceCode.Last();
                else
                {
                    OnixLegacyAudience[] AudienceList = Audience;
                    if ((AudienceList != null) && (AudienceList.Length > 0))
                    {
                        OnixLegacyAudience OnixAudCode =
                            AudienceList.Where(x => x.AudienceCodeType == OnixLegacyAudience.CONST_AUD_TYPE_ONIX).LastOrDefault();

                        if ((OnixAudCode != null) && !string.IsNullOrEmpty(OnixAudCode.AudienceCodeValue))
                            sAudCode = OnixAudCode.AudienceCodeValue;
                    }
                }

                return sAudCode;
            }
        }

        public string OnixAudienceGradeFrom
        {
            get
            {
                string sAudGradeFrom = "";

                OnixLegacyAudRange[] AudRangeList = AudienceRange;
                if ((AudRangeList != null) && (AudRangeList.Length > 0))
                {
                    foreach (OnixLegacyAudRange TempAudRange in AudRangeList)
                    {
                        if (!string.IsNullOrEmpty(TempAudRange.USGradeFrom))
                            sAudGradeFrom = TempAudRange.USGradeFrom;
                        else if (!string.IsNullOrEmpty(TempAudRange.USGradeExact))
                            sAudGradeFrom = TempAudRange.USGradeExact;
                    }
                }

                return sAudGradeFrom;
            }
        }

        public string OnixAudienceGradeTo
        {
            get
            {
                string sAudGradeTo = "";

                OnixLegacyAudRange[] AudRangeList = AudienceRange;
                if ((AudRangeList != null) && (AudRangeList.Length > 0))
                {
                    foreach (OnixLegacyAudRange TempAudRange in AudRangeList)
                    {
                        if (!string.IsNullOrEmpty(TempAudRange.USGradeTo))
                            sAudGradeTo = TempAudRange.USGradeTo;
                        else if (!string.IsNullOrEmpty(TempAudRange.USGradeExact))
                            sAudGradeTo = TempAudRange.USGradeExact;
                    }
                }

                return sAudGradeTo;
            }
        }

        public string OnixNumberOfPages
        {
            get
            {
                int nNumberOfPages = -1;
                string sTmpNumOfPages = "";

                if (!string.IsNullOrEmpty(NumberOfPages))
                {
                    try
                    {
                        nNumberOfPages = Convert.ToInt32(NumberOfPages);
                        sTmpNumOfPages = (nNumberOfPages >= 0) ? NumberOfPages : "";
                    }
                    catch { }
                }

                if (!string.IsNullOrEmpty(PagesArabic) && (nNumberOfPages < 0))
                {
                    try
                    {
                        nNumberOfPages = Convert.ToInt32(PagesArabic);
                        sTmpNumOfPages = (nNumberOfPages >= 0) ? PagesArabic : "";
                    }
                    catch { }
                }

                if (string.IsNullOrEmpty(sTmpNumOfPages))
                {
                    if (!string.IsNullOrEmpty(NumberOfPages))
                        sTmpNumOfPages = NumberOfPages;
                    else if (!string.IsNullOrEmpty(PagesArabic))
                        sTmpNumOfPages = PagesArabic;
                }

                return sTmpNumOfPages;
            }
        }

        private OnixLegacyTitle OnixChosenTitleFromList
        {
            get
            {
                OnixLegacyTitle FoundTitle = null;

                OnixLegacyTitle[] TitleList = Title;
                if ((TitleList != null) && (TitleList.Length > 0))
                {
                    FoundTitle =
                        TitleList.Where(x =>
                            x.TitleType == OnixLegacyTitle.CONST_TITLE_TYPE_DIST_TITLE || !string.IsNullOrEmpty(x.OnixDistinctiveTitle)).LastOrDefault();

                    if ((FoundTitle == null) || string.IsNullOrEmpty(FoundTitle.OnixDistinctiveTitle))
                    {
                        FoundTitle =
                            TitleList.Where(x =>
                                x.TitleType == OnixLegacyTitle.CONST_TITLE_TYPE_UN_TITLE || !string.IsNullOrEmpty(x.OnixDistinctiveTitle)).LastOrDefault();

                        if ((FoundTitle == null) || string.IsNullOrEmpty(FoundTitle.OnixDistinctiveTitle))
                            FoundTitle = TitleList.Where(x => (x.TitleType < 0)).LastOrDefault();
                    }
                }

                return FoundTitle;
            }
        }

        public string OnixTitle
        {
            get
            {
                StringBuilder TitleBuilder = new StringBuilder();

                if (string.IsNullOrEmpty(Subtitle))
                {
                    OnixLegacyTitle FoundTitle = OnixChosenTitleFromList;

                    if ((FoundTitle != null) && !string.IsNullOrEmpty(FoundTitle.Subtitle))
                        Subtitle = FoundTitle.Subtitle;
                }

                if (!string.IsNullOrEmpty(DistinctiveTitle))
                {
                    TitleBuilder.Append(DistinctiveTitle.Trim());

                    if (!string.IsNullOrEmpty(Subtitle))
                        TitleBuilder.Append(": ").Append(Subtitle.Trim());
                }
                else if (!string.IsNullOrEmpty(TitleWithoutPrefix))
                {
                    if (!string.IsNullOrEmpty(TitlePrefix))
                        TitleBuilder.Append(TitlePrefix.Trim()).Append(" ");

                    TitleBuilder.Append(TitleWithoutPrefix.Trim());

                    if (!string.IsNullOrEmpty(Subtitle))
                        TitleBuilder.Append(": ").Append(Subtitle.Trim());
                }
                else
                {
                    OnixLegacyTitle FoundTitle = OnixChosenTitleFromList;

                    if ((FoundTitle != null) && !string.IsNullOrEmpty(FoundTitle.OnixDistinctiveTitle))
                        TitleBuilder.Append(FoundTitle.OnixDistinctiveTitle.Trim());
                }

                return TitleBuilder.ToString();
            }
        }

        public string OnixDescription
        {
            get
            {
                string Description = "";

                foreach (OnixLegacyOtherText ot in OtherText)
                {
                    if (ot.TextTypeCode == 3 && !string.IsNullOrEmpty(ot.Text))
                    {
                        Description = ot.Text;
                        break;
                    }
                    else if (ot.TextTypeCode == 2 && !string.IsNullOrEmpty(ot.Text))
                    {
                        Description = ot.Text;
                    }
                }

                return Description;
            }
        }

        public OnixLegacyContributor PrimaryAuthor
        {
            get
            {
                OnixLegacyContributor PrimaryAuthor = new OnixLegacyContributor();

                OnixLegacyContributor[] ContributorList = Contributor;
                if ((ContributorList != null) && (ContributorList.Length > 0))
                {
                    PrimaryAuthor =
                        ContributorList.Where(x => x.ContributorRole == OnixLegacyContributor.CONST_CONTRIB_ROLE_AUTHOR).FirstOrDefault();
                }

                return PrimaryAuthor;
            }
        }

        public string ProprietaryImprintName
        {
            get
            {
                string FoundImprintName = "";

                OnixLegacyImprint[] ImprintList = Imprint;
                if ((ImprintList != null) && (ImprintList.Length > 0))
                {
                    OnixLegacyImprint FoundImprint =
                        ImprintList.Where(x => x.NameCodeType == OnixLegacyImprint.CONST_IMPRINT_ROLE_PROP).LastOrDefault();

                    if (FoundImprint != null)
                        FoundImprintName = FoundImprint.ImprintName;
                }

                return FoundImprintName;
            }
        }

        public List<OnixLegacySupplierId> ProprietarySuppliers
        {
            get
            {
                List<OnixLegacySupplierId> PropSuppliers = new List<OnixLegacySupplierId>();

                if (SupplyDetail != null)
                {
                    foreach (OnixLegacySupplyDetail TmpSupplyDetail in SupplyDetail)
                    {
                        if ((TmpSupplyDetail.OnixSupplierIdList != null) && (TmpSupplyDetail.OnixSupplierIdList.Length > 0))
                        {
                            List<OnixLegacySupplierId> TmpPropSuppliers =
                                TmpSupplyDetail.OnixSupplierIdList.Where(x => x.SupplierIDType == OnixLegacySupplierId.CONST_SUPPL_ID_TYPE_PROP).ToList();

                            PropSuppliers.AddRange(TmpPropSuppliers);
                        }
                    }
                }

                return PropSuppliers;
            }
        }

        public string SeriesNumber
        {
            get
            {
                string FoundSeriesNum = "";

                OnixLegacySeries[] SeriesList = Series;
                if ((SeriesList != null) && (SeriesList.Length > 0))
                {
                    OnixLegacySeries FoundSeries = SeriesList.Where(x => !string.IsNullOrEmpty(x.NumberWithinSeries)).LastOrDefault();
                    if (FoundSeries != null)
                        FoundSeriesNum = FoundSeries.NumberWithinSeries;
                }

                return FoundSeriesNum;
            }
        }

        public string SeriesTitle
        {
            get
            {
                string FoundSeriesTitle = "";

                OnixLegacySeries[] SeriesList = Series;
                if ((SeriesList != null) && (SeriesList.Length > 0))
                    FoundSeriesTitle = SeriesList[0].TitleOfSeries;

                return FoundSeriesTitle;
            }
        }

        public OnixLegacyPrice USDValidPrice
        {
            get
            {
                if (usdPriceField != null)
                    return usdPriceField;

                OnixLegacyPrice USDPrice = USDRetailPrice;

                if ((USDRetailPrice == null) || (USDRetailPrice.PriceAmountNum < 0))
                {
                    if (SupplyDetail != null)
                    {
                        foreach (OnixLegacySupplyDetail TmpSupplyDetail in SupplyDetail)
                        {
                            if ((TmpSupplyDetail.OnixPriceList != null) && (TmpSupplyDetail.OnixPriceList.Length > 0))
                            {
                                OnixLegacyPrice[] Prices = TmpSupplyDetail.OnixPriceList;

                                USDPrice =
                                    Prices.Where(x => x.HasSoughtPriceTypeCode() && (x.CurrencyCode == "USD")).FirstOrDefault();

                                if ((USDPrice != null) && (USDPrice.PriceAmountNum >= 0))
                                    break;
                            }
                        }
                    }
                }

                usdPriceField = USDPrice;

                return USDPrice;
            }
        }

        public OnixLegacyPrice USDSupplyCostPrice
        {
            get
            {
                OnixLegacyPrice USDPrice = new OnixLegacyPrice();

                if (SupplyDetail != null)
                {
                    foreach (OnixLegacySupplyDetail TmpSupplyDetail in SupplyDetail)
                    {
                        if ((TmpSupplyDetail.OnixPriceList != null) && (TmpSupplyDetail.OnixPriceList.Length > 0))
                        {
                            OnixLegacyPrice[] Prices = TmpSupplyDetail.OnixPriceList;

                            USDPrice =
                                Prices.Where(x => x.HasSoughtSupplyCostPriceType() && (x.CurrencyCode == "USD")).FirstOrDefault();

                            if ((USDPrice != null) && (USDPrice.PriceAmountNum >= 0))
                                break;
                        }
                    }
                }

                return USDPrice;
            }
        }

        public OnixLegacyPrice USDRetailPrice
        {
            get
            {
                OnixLegacyPrice USDPrice = new OnixLegacyPrice();

                if (SupplyDetail != null)
                {
                    foreach (OnixLegacySupplyDetail TmpSupplyDetail in SupplyDetail)
                    {
                        if ((TmpSupplyDetail.OnixPriceList != null) && (TmpSupplyDetail.OnixPriceList.Length > 0))
                        {
                            OnixLegacyPrice[] Prices = TmpSupplyDetail.OnixPriceList;

                            USDPrice =
                                Prices.Where(x => x.HasSoughtRetailPriceType() && (x.CurrencyCode == "USD")).FirstOrDefault();

                            if ((USDPrice != null) && (USDPrice.PriceAmountNum >= 0))
                                break;
                        }
                    }
                }

                return USDPrice;
            }
        }

        public OnixLegacySupplyDetail USDSupplyDetail
        {
            get
            {
                bool bFoundDetails = false;

                OnixLegacySupplyDetail FoundSupplyDetail = new OnixLegacySupplyDetail();

                if (SupplyDetail != null)
                {
                    foreach (OnixLegacySupplyDetail TmpSupplyDetail in SupplyDetail)
                    {
                        if (TmpSupplyDetail.HasUSDPrice())
                        {
                            bFoundDetails = true;
                            FoundSupplyDetail = TmpSupplyDetail;
                            break;
                        }
                    }
                }

                // If we can't find one that mentions a USD price, we'll just accept the first one
                if (!bFoundDetails)
                {
                    if ((SupplyDetail != null) && (SupplyDetail.Length > 0))
                        FoundSupplyDetail = SupplyDetail[0];
                }

                return FoundSupplyDetail;
            }
        }

        #endregion

        #region Reference Tags

        /// <summary>
        /// An ONIX code specifying more detail of the product format when the product is a book. Repeatable when two or more coded characteristics apply.
        /// This field is optional, but must only be included when the code in the <see cref="OnixLegacyBaseProduct.ProductForm"/> element begins with letter B.
        /// 
        /// This field will be superseded by the new element <see cref="OnixLegacyBaseProduct.ProductFormDetail"/>, and the code list will not be further developed.
        /// The field is retained only for purposes of upwards compatibility, and its use is now to be deprecated.
        /// </summary>
        [XmlChoiceIdentifier("BookFormDetailChoice")]
        [XmlElement("BookFormDetail")]
        [XmlElement("b013")]
        public string BookFormDetail { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum BookFormDetailEnum { BookFormDetail, b013 };
        [XmlIgnore]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public BookFormDetailEnum BookFormDetailChoice;

        /// <summary>
        /// An ONIX code which indicates the type of packaging used for the product.
        /// Optional and non-repeating.
        /// </summary>
        [XmlChoiceIdentifier("ProductPackagingChoice")]
        [XmlElement("ProductPackaging")]
        [XmlElement("b225")]
        public Lists.OnixList80 ProductPackaging { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum ProductPackagingEnum { ProductPackaging, b225 };
        [XmlIgnore]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ProductPackagingEnum ProductPackagingChoice;

        /// <summary>
        /// An ONIX code, indicating the type of a version or edition.
        /// Optional, and repeatable if the product has characteristics of two or more types (eg revised and annotated).
        /// </summary>
        [XmlChoiceIdentifier("EditionTypeCodesChoice")]
        [XmlElement("EditionTypeCode")]
        [XmlElement("b056")]
        public string[] EditionTypeCode { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum EditionTypeCodeEnum { EditionTypeCode, b056 };
        [XmlIgnore]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public EditionTypeCodeEnum[] EditionTypeCodesChoice;

        /// <summary>
        /// The number of a numbered edition.
        /// Optional and non-repeating.
        /// Normally sent only for the second and subsequent editions of a work, but by agreement between parties to an ONIX exchange a first edition may be explicitly numbered.
        /// </summary>
        [XmlChoiceIdentifier("EditionNumbersChoice")]
        [XmlElement("EditionNumber")]
        [XmlElement("b057")]
        public string[] EditionNumber { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum EditionNumberEnum { EditionNumber, b057 };
        [XmlIgnore]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public EditionNumberEnum[] EditionNumbersChoice;

        /// <summary>
        /// A short free-text description of a version or edition.
        /// Optional and non-repeating.
        /// When used, must carry a complete description of the nature of the edition, ie it should not be treated as merely supplementary to an <see cref="EditionTypeCode"/> or an <see cref="EditionNumber"/>.
        /// The element should be strictly limited to describing features of the content of the edition, and should not include aspects such as rights or market restrictions which are properly covered elsewhere in the ONIX record.
        /// </summary>
        [XmlChoiceIdentifier("EditionStatementChoice")]
        [XmlElement("EditionStatement")]
        [XmlElement("b058")]
        public string EditionStatement { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum EditionStatementEnum { EditionStatement, b058 };
        [XmlIgnore]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public EditionStatementEnum EditionStatementChoice;

        /// <summary>
        /// A repeatable group of data elements which together give the text of a title of a content item and specify its type, used here to give alternate forms of title for a content item.
        /// </summary>
        [XmlChoiceIdentifier("TitlesChoice")]
        [XmlElement("Title")]
        [XmlElement("title")]
        public OnixLegacyTitle[] Title { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum TitleEnum { Title, title };
        [XmlIgnore]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public TitleEnum[] TitlesChoice;

        /// <summary>
        /// A repeatable group of data elements which together describe a personal or corporate contributor to the series. The composite is optional in any occurrence of the <Series> composite.
        /// </summary>
        [XmlChoiceIdentifier("ContributorsChoice")]
        [XmlElement("Contributor")]
        [XmlElement("contributor")]
        public OnixLegacyContributor[] Contributor { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum ContributorEnum { Contributor, contributor };
        [XmlIgnore]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ContributorEnum[] ContributorsChoice;

        /// <summary>
        /// Free text showing how the authorship should be described in an online display, when a standard concatenation of individual contributor elements would not give a satisfactory presentation.
        /// When this field is sent, the receiver should use it to replace all name detail sent in the <see cref="OnixLegacyContributor"/> composite for display purposes only.
        /// It does not replace the <see cref="OnixLegacyContributor.BiographicalNote"/> element.
        /// The individual name detail must also be sent in the <see cref="OnixLegacyContributor"/> composite for indexing and retrieval.
        /// </summary>
        [XmlChoiceIdentifier("ContributorStatementChoice")]
        [XmlElement("ContributorStatement")]
        [XmlElement("b049")]
        public string ContributorStatement { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum ContributorStatementEnum { ContributorStatement, b049 };
        [XmlIgnore]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ContributorStatementEnum ContributorStatementChoice;

        /// <summary>
        /// A repeatable group of data elements which together represent a language, and specify its role and, where required, whether it is a country variant.
        /// </summary>
        [XmlChoiceIdentifier("LanguageChoice")]
        [XmlElement("Language")]
        [XmlElement("language")]
        public OnixLegacyLanguage[] Language { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum LanguageEnum { Language, language };
        [XmlIgnore]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public LanguageEnum[] LanguageChoice;

        /// <summary>
        /// An indication of the total number of pages in a book or other printed product. This is not intended to represent a precise count of numbered and unnumbered pages.
        /// It is usually sufficient to take the number from the last numbered page.
        /// If there are two or more separate numbering sequences (eg xviii + 344), the numbers in each sequence may be added together to make an overall total (in this case 362), but do not count unnumbered pages except if the book does not have numbered pages at all.
        ///
        /// For multi-volume books, enter the total for all the volumes combined.
        ///
        /// This field is optional, but it is normally required for a printed book unless the <see cref="PagesRoman"/> and <see cref="PagesArabic"/> elements are used, and is non-repeating.
        /// </summary>
        [XmlChoiceIdentifier("NumberOfPagesChoice")]
        [XmlElement("NumberOfPages")]
        [XmlElement("b061")]
        public string NumberOfPages { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum NumberOfPagesEnum { NumberOfPages, b061 };
        [XmlIgnore]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public NumberOfPagesEnum NumberOfPagesChoice;

        /// <summary>
        /// The number of pages numbered in roman numerals.
        /// The <see cref="PagesRoman"/> and <see cref="PagesArabic"/> elements together represent an alternative to <see cref="NumberOfPages"/> where there is a requirement to specify these numbering sequences separately.
        /// For most ONIX applications, however, <see cref="NumberOfPages"/> will be preferred.
        /// Optional and non-repeating.
        /// </summary>
        [XmlChoiceIdentifier("PagesRomanChoice")]
        [XmlElement("PagesRoman")]
        [XmlElement("b254")]
        public string PagesRoman { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum PagesRomanEnum { PagesRoman, b254 };
        [XmlIgnore]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public PagesRomanEnum PagesRomanChoice;

        /// <summary>
        /// The number of pages numbered in Arabic numerals.
        /// The <see cref="PagesRoman"/> and <see cref="PagesArabic"/> elements together represent an alternative to <see cref="NumberOfPages"/> where there is a requirement to specify these numbering sequences separately.
        /// For most ONIX applications, however, <see cref="NumberOfPages"/> will be preferred.
        /// Optional and non-repeating.
        /// </summary>
        [XmlChoiceIdentifier("PagesArabicChoice")]
        [XmlElement("PagesArabic")]
        [XmlElement("b255")]
        public string PagesArabic { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum PagesArabicEnum { PagesArabic, b255 };
        [XmlIgnore]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public PagesArabicEnum PagesArabicChoice;

        /// <summary>
        /// A repeatable group of data elements which together specify the number of illustrations or other content items of a stated type which the product carries.
        /// Use of the <see cref="OnixLegacyIllustrations"/> composite is optional.
        /// </summary>
        [XmlChoiceIdentifier("IllustrationsChoice")]
        [XmlElement("Illustrations")]
        [XmlElement("illustrations")]
        public OnixLegacyIllustrations Illustrations { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum IllustrationsEnum { Illustrations, illustrations };
        [XmlIgnore]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public IllustrationsEnum IllustrationsChoice;

        /// <summary>
        /// A BISAC subject category code which identifies the main subject of the product.
        /// Optional and non-repeating.
        /// Additional BISAC subject category codes may be sent using the <see cref="OnixLegacySubject"/> composite.
        /// 
        /// Note that the data element reference name was assigned during a period when the BISAC name had been changed to “BASIC”.
        /// The name has now officially reverted to “BISAC”, but the ONIX data element name cannot be changed for reasons of upwards compatibility.
        /// </summary>
        [XmlChoiceIdentifier("BASICMainSubjectChoice")]
        [XmlElement("BASICMainSubject")]
        [XmlElement("b064")]
        public string BASICMainSubject { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum BASICMainSubjectEnum { BASICMainSubject, b064 };
        [XmlIgnore]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public BASICMainSubjectEnum BASICMainSubjectChoice;

        /// <summary>
        /// An optional and repeatable group of data elements which together describe a main subject classification or subject heading which is taken from a recognized scheme other than BISAC or BIC.
        /// </summary>
        [XmlChoiceIdentifier("MainSubjectChoice")]
        [XmlElement("MainSubject")]
        [XmlElement("mainsubject")]
        public OnixLegacySubject[] MainSubject { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum MainSubjectEnum { MainSubject, mainsubject };
        [XmlIgnore]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public MainSubjectEnum[] MainSubjectChoice;

        /// <summary>
        /// An ONIX code, derived from BISAC and BIC lists, which identifies the broad audience or readership for whom a product is intended.
        /// Optional, and repeatable if the product is intended for two or more groups.
        /// </summary>
        [XmlChoiceIdentifier("AudienceCodesChoice")]
        [XmlElement("AudienceCode")]
        [XmlElement("b073")]
        public string[] AudienceCode { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum AudienceCodeEnum { AudienceCode, b073 };
        [XmlIgnore]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public AudienceCodeEnum[] AudienceCodesChoice;

        /// <summary>
        /// A repeatable group of data elements which together describe an extent pertaining to the product.
        /// </summary>
        [XmlChoiceIdentifier("ExtentChoice")]
        [XmlElement("Extent")]
        [XmlElement("extent")]
        public OnixLegacyExtent[] Extent { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum ExtentEnum { Extent, extent };
        [XmlIgnore]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ExtentEnum[] ExtentChoice;

        /// <summary>
        /// A repeatable group of data elements which together describe a series of which the product is part.
        /// </summary>
        [XmlChoiceIdentifier("SeriesChoice")]
        [XmlElement("Series")]
        [XmlElement("series")]
        public OnixLegacySeries[] Series { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum SeriesEnum { Series, series };
        [XmlIgnore]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public SeriesEnum[] SeriesChoice;

        /// <summary>
        /// A repeatable group of data elements which together describe a set of which the product is part.
        /// </summary>
        [XmlChoiceIdentifier("SetChoice")]
        [XmlElement("Set")]
        [XmlElement("set")]
        public OnixLegacySet[] Set { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum SetEnum { Set, set };
        [XmlIgnore]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public SetEnum[] SetChoice;

        /// <summary>
        /// An optional and repeatable group of data elements which together describe a subject classification or subject heading which is additional to the BISAC, BIC or other main subject category.
        /// </summary>
        [XmlChoiceIdentifier("SubjectsChoice")]
        [XmlElement("Subject")]
        [XmlElement("subject")]
        public OnixLegacySubject[] Subject { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum SubjectEnum { Subject, subject };
        [XmlIgnore]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public SubjectEnum[] SubjectsChoice;

        /// <summary>
        /// An optional and repeatable group of data elements which together describe the level of complexity of a text.
        /// </summary>
        [XmlChoiceIdentifier("ComplexityChoice")]
        [XmlElement("Complexity")]
        [XmlElement("complexity")]
        public OnixLegacyComplexity[] Complexity { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum ComplexityEnum { Complexity, complexity };
        [XmlIgnore]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ComplexityEnum[] ComplexityChoice;

        /// <summary>
        /// A repeatable group of data elements which together describe an audience to which the product is directed.
        /// </summary>
        [XmlChoiceIdentifier("AudienceChoice")]
        [XmlElement("Audience")]
        [XmlElement("audience")]
        public OnixLegacyAudience[] Audience { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum AudienceEnum { Audience, audience };
        [XmlIgnore]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public AudienceEnum[] AudienceChoice;

        /// <summary>
        /// An optional and repeatable group of data elements which together describe an audience or readership range for which a product is intended.
        /// The composite can carry a single value from, to, or exact, or a pair of values with an explicit from and to.
        /// </summary>
        [XmlChoiceIdentifier("AudienceRangesChoice")]
        [XmlElement("AudienceRange")]
        [XmlElement("audiencerange")]
        public OnixLegacyAudRange[] AudienceRange { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum AudienceRangeEnum { AudienceRange, audiencerange };
        [XmlIgnore]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public AudienceRangeEnum[] AudienceRangesChoice;

        /// <summary>
        /// An optional and repeatable group of data elements which together identify and either include, or provide pointers to, text related to the product.
        /// </summary>
        [XmlChoiceIdentifier("OtherTextChoice")]
        [XmlElement("OtherText")]
        [XmlElement("othertext")]
        public OnixLegacyOtherText[] OtherText { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum OtherTextEnum { OtherText, othertext };
        [XmlIgnore]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public OtherTextEnum[] OtherTextChoice;

        /// <summary>
        /// A repeatable group of data elements which together identify and provide pointers to, an image, audio or video file related to the product.
        /// </summary>
        [XmlChoiceIdentifier("MediaFilesChoice")]
        [XmlElement("MediaFile")]
        [XmlElement("mediafile")]
        public OnixLegacyMediaFile[] MediaFile { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum MediaFileEnum { MediaFile, mediafile };
        [XmlIgnore]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public MediaFileEnum[] MediaFilesChoice;

        /// <summary>
        /// A repeatable group of data elements which together identify an imprint or brand under which the product is marketed. The composite must carry either a name code or a name or both.
        /// </summary>
        [XmlChoiceIdentifier("ImprintsChoice")]
        [XmlElement("Imprint")]
        [XmlElement("imprint")]
        public OnixLegacyImprint[] Imprint { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum ImprintEnum { Imprint, imprint };
        [XmlIgnore]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ImprintEnum[] ImprintsChoice;

        /// <summary>
        /// The name of a city or town associated with the imprint or publisher.
        /// Optional, and repeatable if the imprint carries two or more cities of publication.
        ///
        /// A place of publication is normally given in the form in which it appears on the title page.
        /// If the place name appears in more than one language, use the language of the title carried in the ONIX record.
        /// If this criterion does not apply, use the form that appears first. Alternatively, some ONIX applications may follow their own “house style”.
        /// </summary>
        [XmlChoiceIdentifier("CityOfPublicationChoice")]
        [XmlElement("CityOfPublication")]
        [XmlElement("b209")]
        public string CityOfPublication { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum CityOfPublicationEnum { CityOfPublication, b209 };
        [XmlIgnore]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public CityOfPublicationEnum CityOfPublicationChoice;

        /// <summary>
        /// A code identifying the country where the product is issued.
        /// Optional and non-repeating.
        /// </summary>
        [XmlChoiceIdentifier("CountryOfPublicationChoice")]
        [XmlElement("CountryOfPublication")]
        [XmlElement("b083")]
        public string CountryOfPublication { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum CountryOfPublicationEnum { CountryOfPublication, b083 };
        [XmlIgnore]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public CountryOfPublicationEnum CountryOfPublicationChoice;

        /// <summary>
        /// An ONIX code which identifies the status of a published product.
        /// Optional and non-repeating, but it is very strongly recommended that this element should be included in all ONIX Books Product records, and it is possible that it may be made mandatory in a future release, or that it will be treated as mandatory in national ONIX accreditation schemes.
        ///
        /// Where the element is sent by a sender who is not the publisher, based on information that has been previously supplied by the publisher, it is strongly recommended that the element should carry a datestamp attribute to indicate its likely reliability.
        /// </summary>
        [XmlChoiceIdentifier("PublishingStatusChoice")]
        [XmlElement("PublishingStatus")]
        [XmlElement("b394")]
        public string PublishingStatus { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum PublishingStatusEnum { PublishingStatus, b394 };
        [XmlIgnore]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public PublishingStatusEnum PublishingStatusChoice;

        /// <summary>
        /// Date when information about the product can be issued to the general public. (Some publishers issue advance information under embargo.)
        /// Optional and non-repeating.
        /// </summary>
        [XmlChoiceIdentifier("AnnouncementDateChoice")]
        [XmlElement("AnnouncementDate")]
        [XmlElement("b086")]
        public string AnnouncementDate { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum AnnouncementDateEnum { AnnouncementDate, b086 };
        [XmlIgnore]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public AnnouncementDateEnum AnnouncementDateChoice;

        /// <summary>
        /// Date when information about the product can be issued to the book trade, while remaining embargoed for the general public. (Some publishers issue advance information under embargo.)
        /// Optional and non-repeating.
        /// </summary>
        [XmlChoiceIdentifier("TradeAnnouncementDateChoice")]
        [XmlElement("TradeAnnouncementDate")]
        [XmlElement("b362")]
        public string TradeAnnouncementDate { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum TradeAnnouncementDateEnum { TradeAnnouncementDate, b362 };
        [XmlIgnore]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public TradeAnnouncementDateEnum TradeAnnouncementDateChoice;

        /// <summary>
        /// The date of first publication of this product in the home market of the publisher (that is, under the current ISBN or other identifier, as distinct from the date of first publication of the work, which may be given in <see cref="YearFirstPublished"/> on the next page).
        /// In advance information, this will be an expected date, which should be replaced by the actual date of publication when known.
        /// The date should be given as precisely as possible, but in early notifications a month and year are sufficient; and for backlist titles the year of publication is sufficient.
        ///
        /// Note that in advance information this date must not be interpreted as the date when the product will first be available in a territory other than the publisher’s home market.
        /// See the <see cref="OnixLegacySupplyDetail"/> and <see cref="OnixLegacyMarketRepresentation"/> composites for other market-specific detail.
        ///
        /// Optional and non-repeating.
        /// </summary>
        [XmlChoiceIdentifier("PublicationDateChoice")]
        [XmlElement("PublicationDate")]
        [XmlElement("b003")]
        public string PublicationDate { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum PublicationDateEnum { PublicationDate, b003 };
        [XmlIgnore]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public PublicationDateEnum PublicationDateChoice;

        public uint PublicationDateNum
        {
            get
            {
                uint nPubDateVal = 0;

                if (!string.IsNullOrEmpty(PublicationDate))
                    uint.TryParse(PublicationDate, out nPubDateVal);

                return nPubDateVal;
            }
        }

        /// <summary>
        /// The year when the work first appeared in any language or edition, if different from the copyright year.
        /// Optional and non-repeating.
        /// </summary>
        [XmlChoiceIdentifier("YearFirstPublishedChoice")]
        [XmlElement("YearFirstPublished")]
        [XmlElement("b088")]
        public string YearFirstPublished { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum YearFirstPublishedEnum { YearFirstPublished, b088 };
        [XmlIgnore]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public YearFirstPublishedEnum YearFirstPublishedChoice;

        public uint YearFirstPublishedNum
        {
            get
            {
                uint nYearFirstPubVal = 0;

                if (!string.IsNullOrEmpty(YearFirstPublished))
                    uint.TryParse(YearFirstPublished, out nYearFirstPubVal);

                return nYearFirstPubVal;
            }
        }

        /// <summary>
        /// A repeatable group of data elements which together identify territorial sales rights which a publisher chooses to exercise in a product.
        /// The <see cref="OnixLegacySalesRights"/> composite may occur once for each value of <see cref="SalesRightsType"/>.
        /// </summary>
        [XmlChoiceIdentifier("SalesRightsChoice")]
        [XmlElement("SalesRights")]
        [XmlElement("salesrights")]
        public OnixLegacySalesRights[] SalesRights { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum SalesRightsEnum { SalesRights, salesrights };
        [XmlIgnore]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public SalesRightsEnum[] SalesRightsChoice;

        /// <summary>
        /// A repeatable group of data elements which together identify a country or countries in which the product is not for sale, together with the ISBN and/or other product identifier and/or the name of the publisher of the same work in the specified country/ies.
        /// </summary>
        [XmlChoiceIdentifier("NotForSaleChoice")]
        [XmlElement("NotForSale")]
        [XmlElement("notforsale")]
        public OnixLegacyNotForSale[] NotForSale { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum NotForSaleEnum { NotForSale, notforsale };
        [XmlIgnore]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public NotForSaleEnum[] NotForSaleChoice;

        /// <summary>
        /// An optional and repeatable group of data elements which together identify a measurement and the units in which it is expressed.
        /// </summary>
        [XmlChoiceIdentifier("MeasurementsChoice")]
        [XmlElement("Measure")]
        [XmlElement("measure")]
        public OnixLegacyMeasure[] Measure { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum MeasureEnum { Measure, measure };
        [XmlIgnore]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public MeasureEnum[] MeasurementsChoice;

        /// <summary>
        /// A repeatable group of data elements which together define a product classification (NOT to be confused with a subject classification).
        /// The intended use is to enable national or international trade classifications (aka commodity codes) to be carried in an ONIX record.
        /// </summary>
        [XmlChoiceIdentifier("ProductClassificationsChoice")]
        [XmlElement("ProductClassification")]
        [XmlElement("productclassification")]
        public OnixLegacyProductClassification[] ProductClassification { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum ProductClassificationEnum { ProductClassification, productclassification };
        [XmlIgnore]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ProductClassificationEnum[] ProductClassificationsChoice;

        /// <summary>
        /// A repeatable group of data elements which together describe a product which has a specified relationship to the product which is described in the ONIX record.
        /// Although for reasons of upwards compatibility the composite includes individual fields for ISBN and EAN-13 number, use of the nested <see cref="OnixLegacyProductId"/> composite is to be preferred, since it allows any recognized identifier scheme (eg DOI) to be used.
        ///
        /// The minimum required content of an occurrence of the <see cref="OnixLegacyRelatedProduct"/> composite is a <see cref="OnixLegacyRelatedProduct.RelationCode"/> and either a product identifier or a <see cref="OnixLegacyBaseProduct.ProductForm"/> value.
        /// In other words, it is valid to list related products by relationship and identifier only, or by relationship and form only.
        /// </summary>
        [XmlChoiceIdentifier("RelatedProductsChoice")]
        [XmlElement("RelatedProduct")]
        [XmlElement("relatedproduct")]
        public OnixLegacyRelatedProduct[] RelatedProduct { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum RelatedProductEnum { RelatedProduct, relatedproduct };
        [XmlIgnore]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public RelatedProductEnum[] RelatedProductsChoice;

        /// <summary>
        /// A repeatable group of data elements which together give details of a trade supply source and the product price and availability from that source.
        /// </summary>
        [XmlChoiceIdentifier("SupplyDetailsChoice")]
        [XmlElement("SupplyDetail")]
        [XmlElement("supplydetail")]
        public OnixLegacySupplyDetail[] SupplyDetail { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum SupplyDetailEnum { SupplyDetail, supplydetail };
        [XmlIgnore]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public SupplyDetailEnum[] SupplyDetailsChoice;

        #endregion

        #region Support Methods

        public OnixLegacyMeasure GetMeasurement(Lists.OnixList48 Type, bool PreferUSMeasurement = true)
        {
            OnixLegacyMeasure FoundMeasurement = new OnixLegacyMeasure();

            OnixLegacyMeasure[] MeasureList = Measure;
            if ((MeasureList != null) && (MeasureList.Length > 0))
            {
                if (PreferUSMeasurement)
                {
                    if (OnixLegacyMeasure.MEASURE_TYPES_DIM.Contains(Type))
                    {
                        FoundMeasurement =
                            MeasureList.Where(x => (x.MeasureTypeCode == Type) &&
                                                   (x.MeasureUnitCode == Lists.OnixList50.Inches)).LastOrDefault();
                    }
                    else if (OnixLegacyMeasure.MEASURE_TYPES_WEIGHT.Contains(Type))
                    {
                        FoundMeasurement =
                            MeasureList.Where(x => (x.MeasureTypeCode == Type) &&
                                                   (OnixLegacyMeasure.MEASURE_WEIGHTS_US.Contains(x.MeasureUnitCode))).LastOrDefault();
                    }
                }

                if (FoundMeasurement == null)
                {
                    FoundMeasurement =
                        MeasureList.Where(x => x.MeasureTypeCode == Type).LastOrDefault();

                    if (FoundMeasurement == null)
                        FoundMeasurement = new OnixLegacyMeasure();
                }
            }

            return FoundMeasurement;
        }

        public void SetRightsFlags()
        {
            int[] aSalesRightsColl = new int[] { OnixLegacySalesRights.CONST_SR_TYPE_FOR_SALE_WITH_EXCL_RIGHTS,
                                                 OnixLegacySalesRights.CONST_SR_TYPE_FOR_SALE_WITH_NONEXCL_RIGHTS };

            int[] aNonSalesRightsColl = new int[] { OnixLegacySalesRights.CONST_SR_TYPE_NOT_FOR_SALE };

            OnixLegacySalesRights[] SalesRightsList = SalesRights;
            OnixLegacyNotForSale[] NotForSaleRightsList = NotForSale;

            if ((SalesRightsList != null) && (SalesRightsList.Length > 0))
            {
                SalesRightsInUS =
                    SalesRightsList.Any(x => aSalesRightsColl.Contains(x.SalesRightsTypeNum) && (x.RightsCountryList.Contains("US")));

                SalesRightsInNonUSCountry =
                    SalesRightsList.Any(x => aSalesRightsColl.Contains(x.SalesRightsTypeNum) &&
                                             !x.RightsCountryList.Contains("US") &&
                                             !x.RightsTerritoryList.Contains("WORLD") &&
                                             !x.RightsTerritoryList.Contains("ROW"));

                NoSalesRightsInUS =
                    SalesRightsList.Any(x => aNonSalesRightsColl.Contains(x.SalesRightsTypeNum) && x.RightsCountryList.Contains("US"));

                SalesRightsAllWorld =
                    SalesRightsList.Any(x => aSalesRightsColl.Contains(x.SalesRightsTypeNum) &&
                                             (x.RightsTerritoryList.Contains("WORLD") || x.RightsTerritoryList.Contains("ROW")));
            }

            if ((NotForSaleRightsList != null) && (NotForSaleRightsList.Length > 0))
            {
                if (!NoSalesRightsInUS)
                {
                    NoSalesRightsInUS =
                        NotForSaleRightsList.Any(x => x.RightsCountryList.Contains("US"));
                }
            }
        }

        public string TranslateAudienceGradeToAge(string psGradeValue)
        {
            int nAgeVal = 0;
            string sAgeVal = "";

            if (!String.IsNullOrEmpty(psGradeValue))
            {
                if ((psGradeValue == OnixLegacyAudRange.CONST_AUD_GRADE_PRESCHOOL_CD) || (psGradeValue == OnixLegacyAudRange.CONST_AUD_GRADE_PRESCHOOL_TXT))
                    nAgeVal = 4;
                else if ((psGradeValue == OnixLegacyAudRange.CONST_AUD_GRADE_KNDGRTN_CD) || (psGradeValue == OnixLegacyAudRange.CONST_AUD_GRADE_KNDGRTN_TXT))
                    nAgeVal = 5;
                else if (Int32.TryParse(psGradeValue, out nAgeVal))
                    nAgeVal += 5;
            }

            if (nAgeVal > 0)
                sAgeVal = Convert.ToString(nAgeVal);

            return sAgeVal;
        }

        #endregion
    }
}
