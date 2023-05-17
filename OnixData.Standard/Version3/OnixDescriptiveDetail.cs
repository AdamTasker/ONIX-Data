using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Xml.Serialization;

using OnixData.Version3.Audience;
using OnixData.Version3.Epub;
using OnixData.Version3.Language;
using OnixData.Version3.ProductPart;
using OnixData.Version3.Title;

namespace OnixData.Version3
{
    /// <summary>
    /// The descriptive detail block covers data elements which are essentially part of the factual description of the form and content of a product.
    /// </summary>
    [XmlType(AnonymousType = true)]
    public partial class OnixDescriptiveDetail
    {

        #region ONIX Lists

        public string[] OnixAllContentTypeList
        {
            get
            {
                List<string> AllContentTypes = new List<string>();

                if (PrimaryContentType != null)
                    AllContentTypes.Add(PrimaryContentType);

                if (ProductContentType != null)
                    AllContentTypes.AddRange(ProductContentType);

                return AllContentTypes.ToArray();
            }
        }

        public string[] OnixAudCodeList
        {
            get
            {
                string[] AudCodes = null;

                OnixAudience[] AudienceList = Audience;

                if ((AudienceList != null) && (AudienceList.Length > 0))
                {
                    OnixAudience[] OnixAudCodeList =
                        AudienceList.Where(x => x.AudienceCodeType == OnixAudience.CONST_AUD_TYPE_ONIX).ToArray();

                    if ((OnixAudCodeList != null) && (OnixAudCodeList.Length > 0))
                    {
                        AudCodes = new string[OnixAudCodeList.Length];

                        for (int i = 0; i < OnixAudCodeList.Length; ++i)
                        {
                            OnixAudience TmpAud = OnixAudCodeList[i];

                            AudCodes[i] = (!string.IsNullOrEmpty(TmpAud.AudienceCodeValue)) ? TmpAud.AudienceCodeValue : "";
                        }
                    }
                }
                else
                    AudCodes = new string[0];

                return AudCodes;
            }
        }

        public OnixSubject[] OnixMainSubjectList
        {
            get
            {
                OnixSubject[] MainSubjects = new OnixSubject[0];

                if ((Subject != null) && (Subject.Length > 0))
                {
                    var MainSubjList =
                        Subject.Where(x => x.IsMainSubject()).ToList();

                    if (MainSubjList != null)
                        MainSubjects = MainSubjList.ToArray();
                }

                return MainSubjects;
            }
        }

        #endregion

        #region Helper Methods

        public string AudienceAgeFrom
        {
            get
            {
                string sAudAgeFrom = "";

                OnixAudienceRange[] AudRangeList = this.AudienceRange;

                if ((AudRangeList != null) && (AudRangeList.Length > 0))
                {
                    foreach (OnixAudienceRange TempAudRange in AudRangeList)
                    {
                        if (!string.IsNullOrEmpty(TempAudRange.USAgeFrom))
                            sAudAgeFrom = TempAudRange.USAgeFrom;
                    }
                }

                if (string.IsNullOrEmpty(sAudAgeFrom))
                    sAudAgeFrom = TranslateAudienceGradeToAge(AudienceGradeFrom);

                return sAudAgeFrom;
            }
        }

        public string AudienceAgeTo
        {
            get
            {
                string sAudAgeTo = "";

                OnixAudienceRange[] AudRangeList = this.AudienceRange;

                if ((AudRangeList != null) && (AudRangeList.Length > 0))
                {
                    foreach (OnixAudienceRange TempAudRange in AudRangeList)
                    {
                        if (!string.IsNullOrEmpty(TempAudRange.USAgeTo))
                            sAudAgeTo = TempAudRange.USAgeTo;
                    }
                }

                if (string.IsNullOrEmpty(sAudAgeTo))
                    sAudAgeTo = TranslateAudienceGradeToAge(AudienceGradeTo);

                return sAudAgeTo;
            }
        }

        public string AudienceGradeFrom
        {
            get
            {
                string sAudGradeFrom = "";

                OnixAudienceRange[] AudRangeList = this.AudienceRange;

                if ((AudRangeList != null) && (AudRangeList.Length > 0))
                {
                    foreach (OnixAudienceRange TempAudRange in AudRangeList)
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

        public string AudienceGradeTo
        {
            get
            {
                string sAudGradeTo = "";

                OnixAudienceRange[] AudRangeList = this.AudienceRange;

                if ((AudRangeList != null) && (AudRangeList.Length > 0))
                {
                    foreach (OnixAudienceRange TempAudRange in AudRangeList)
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

        public string LanguageOfText
        {
            get
            {
                OnixLanguage[] LangList = Language;

                string sLangOfText = "";

                if ((LangList != null) && (LangList.Length > 0))
                {
                    OnixLanguage LangOfText =
                        LangList.Where(x => x.IsLanguageOfText()).LastOrDefault();

                    if ((LangOfText != null) && !string.IsNullOrEmpty(LangOfText.LanguageCode))
                        sLangOfText = LangOfText.LanguageCode;
                }

                return sLangOfText;
            }
        }

        public int PageNumber
        {
            get
            {
                int nPageNum = 0;

                if (this.Extent != null)
                {
                    OnixExtent[] PageCountExtents =
                        this.Extent
                            .Where(x => x.HasSoughtPageCountType() && (x.ExtentValueNum > 0))
                            .OrderBy(x => x.ExtentType)
                            .ToArray();

                    if ((PageCountExtents != null) && (PageCountExtents.Length > 0))
                    {
                        OnixExtent PageAmtTotalExtent =
                            PageCountExtents
                            .Where(x => x.ExtentType == OnixExtent.CONST_EXT_TYPE_TOTAL_PG_CT)
                            .FirstOrDefault();

                        if (PageAmtTotalExtent != null)
                            nPageNum = PageAmtTotalExtent.ExtentValueNum;
                        else
                        {
                            OnixExtent PageAmtFirstExtent = PageCountExtents[0];

                            if (PageAmtFirstExtent != null)
                                nPageNum = PageAmtFirstExtent.ExtentValueNum;
                        }
                    }
                }

                return nPageNum;
            }
        }

        public string SeriesNumber
        {
            get
            {
                OnixCollection[] CollList = this.Collection;

                string sSeriesNum = "";

                if ((CollList != null) && (CollList.Length > 0))
                {
                    OnixCollection SeriesCollection =
                        CollList.Where(x => x.IsSeriesType()).OrderBy(x => x.CollectionTypeNum).FirstOrDefault();

                    if ((SeriesCollection == null) || (SeriesCollection.CollectionTypeNum < 0))
                        SeriesCollection = CollList.Where(x => x.IsGeneralType()).FirstOrDefault();

                    if (SeriesCollection != null)
                    {
                        sSeriesNum = SeriesCollection.SeriesSequence;
                    }

                    if (string.IsNullOrEmpty(sSeriesNum) &&
                        (SeriesCollection != null) &&
                        (SeriesCollection.OnixTitleDetailList != null) &&
                        (SeriesCollection.OnixTitleDetailList.Length > 0))
                    {
                        var TitleDetailFound =
                            SeriesCollection.OnixTitleDetailList.Where(x => x.HasDistinctiveTitle()).FirstOrDefault();

                        if (TitleDetailFound != null)
                        {
                            var TitleElement =
                                TitleDetailFound.OnixTitleElementList.Where(x => !string.IsNullOrEmpty(x.PartNumber)).FirstOrDefault();

                            if (TitleElement != null)
                                sSeriesNum = TitleElement.PartNumber;
                        }
                    }
                }

                if (string.IsNullOrEmpty(sSeriesNum))
                {
                    if ((this.TitleDetail != null) &&
                        (this.TitleDetail.TitleTypeNum == OnixTitleElement.CONST_TITLE_TYPE_PRODUCT))
                    {
                        var MainTitleDetail = this.TitleDetail;

                        if (MainTitleDetail != null)
                        {
                            var TitleElement =
                                MainTitleDetail.OnixTitleElementList.Where(x => !string.IsNullOrEmpty(x.PartNumber)).FirstOrDefault();

                            if (TitleElement != null)
                                sSeriesNum = TitleElement.PartNumber;
                        }
                    }
                }

                return sSeriesNum;
            }
        }

        public string SeriesTitle
        {
            get
            {
                OnixCollection[] CollList = this.Collection;

                string sSeriesTitle = "";

                if ((CollList != null) && (CollList.Length > 0))
                {
                    OnixCollection SeriesCollection =
                        CollList.Where(x => x.IsSeriesType()).OrderBy(x => x.CollectionTypeNum).FirstOrDefault();

                    if ((SeriesCollection == null) || (SeriesCollection.CollectionTypeNum < 0))
                        SeriesCollection = CollList.Where(x => x.IsGeneralType()).FirstOrDefault();

                    if (SeriesCollection != null)
                    {
                        var SeriesTitleDetail =
                            SeriesCollection.OnixTitleDetailList
                                            .Where(x => x.HasDistinctiveTitle())
                                            .Where(x => !string.IsNullOrEmpty(x.AssembledSeriesName))
                                            .FirstOrDefault();

                        if ((SeriesTitleDetail != null) && !string.IsNullOrEmpty(SeriesTitleDetail.AssembledSeriesName))
                        {
                            sSeriesTitle = SeriesTitleDetail.AssembledSeriesName;
                        }
                    }
                }

                return sSeriesTitle;
            }
        }

        #endregion

        #region Reference Tags

        /// <summary>
        /// An ONIX code which indicates whether a product consists of a single item or multiple items. Mandatory in an occurrence of <see cref="OnixDescriptiveDetail"/>, and non-repeating.
        /// </summary>
        /// <remarks>Onix List 2</remarks>
        [XmlChoiceIdentifier("ProductCompositionChoice")]
        [XmlElement("ProductComposition")]
        [XmlElement("x314")]
        public int ProductComposition { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum ProductCompositionEnum { ProductComposition, x314 }
        [XmlIgnore, DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ProductCompositionEnum ProductCompositionChoice
        {
            get { return SerializationSettings.UseShortTags ? ProductCompositionEnum.x314 : ProductCompositionEnum.ProductComposition; }
            set { }
        }

        /// <summary>
        /// An ONIX code which indicates the primary form of a product.
        /// Mandatory in an occurrence of <see cref="OnixDescriptiveDetail"/>, and non-repeating.
        /// In ONIX 3.0, the handling of multiple-item products has been changed so that the form of the contained items is now specified only in the <see cref="ProductPart"/> composite, which must be included for full description of any multiple-item product.
        /// </summary>
        /// <remarks>Onix List 150</remarks>
        [XmlChoiceIdentifier("ProductFormChoice")]
        [XmlElement("ProductForm")]
        [XmlElement("b012")]
        public string ProductForm { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum ProductFormEnum { ProductForm, b012 }
        [XmlIgnore, DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ProductFormEnum ProductFormChoice
        {
            get { return SerializationSettings.UseShortTags ? ProductFormEnum.b012 : ProductFormEnum.ProductForm; }
            set { }
        }

        /// <summary>
        /// An ONIX code which provides added detail of the medium and/or format of the product.
        /// Optional, and repeatable in order to provide multiple additional details.
        /// </summary>
        /// <remarks>Onix List 175</remarks>
        [XmlChoiceIdentifier("ProductFormDetailChoice")]
        [XmlElement("ProductFormDetail")]
        [XmlElement("b333")]
        public string[] ProductFormDetail { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum ProductFormDetailEnum { ProductFormDetail, b333 }
        [XmlIgnore, DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
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

        /// <summary>
        /// An optional group of data elements which together describe an aspect of product form that is too specific to be covered in the <see cref="ProductForm"/> and <see cref="ProductFormDetail"/> elements.
        /// Repeatable in order to describe different aspects of the product form.
        /// </summary>
        [XmlChoiceIdentifier("ProductFormFeatureChoice")]
        [XmlElement("ProductFormFeature")]
        [XmlElement("productformfeature")]
        public OnixProductFormFeature[] ProductFormFeature { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum ProductFormFeatureEnum { ProductFormFeature, productformfeature }
        [XmlIgnore, DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
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

        /// <summary>
        /// An ONIX code which indicates the type of outer packaging used for the product.
        /// Optional and non-repeating.
        /// </summary>
        /// <remarks>Onix List 80</remarks>
        [XmlChoiceIdentifier("ProductPackagingChoice")]
        [XmlElement("ProductPackaging")]
        [XmlElement("b225")]
        public string ProductPackaging { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum ProductPackagingEnum { ProductPackaging, b225 }
        [XmlIgnore, DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ProductPackagingEnum ProductPackagingChoice
        {
            get { return SerializationSettings.UseShortTags ? ProductPackagingEnum.b225 : ProductPackagingEnum.ProductPackaging; }
            set { }
        }

        /// <summary>
        /// If product form codes do not adequately describe the product, a short text description may be added to give a more detailed specification of the product form.
        /// The field is optional, and repeatable to provide parallel descriptions in multiple languages.
        /// The language attribute is optional for a single instance of <see cref="ProductFormDescription"/>, but must be included in each instance if <see cref="ProductFormDescription"/> is repeated to provide parallel descriptions in multiple languages.
        /// </summary>
        [XmlChoiceIdentifier("ProductFormDescriptionChoice")]
        [XmlElement("ProductFormDescription")]
        [XmlElement("b014")]
        public string[] ProductFormDescription { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum ProductFormDescriptionEnum { ProductFormDescription, b014 }
        [XmlIgnore, DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ProductFormDescriptionEnum[] ProductFormDescriptionChoice
        {
            get
            {
                if (ProductFormDescription == null) return null;
                ProductFormDescriptionEnum choice = SerializationSettings.UseShortTags ? ProductFormDescriptionEnum.b014 : ProductFormDescriptionEnum.ProductFormDescription;
                ProductFormDescriptionEnum[] result = new ProductFormDescriptionEnum[ProductFormDescription.Length];
                for (int i = 0; i < ProductFormDescription.Length; i++) result[i] = choice;
                return result;
            }
            set { }
        }

        /// <summary>
        /// An ONIX code which indicates a trade category which is somewhat related to, but not properly an attribute of, product form.
        /// Optional and non-repeating.
        /// </summary>
        /// <remarks>Onix List 12</remarks>
        [XmlChoiceIdentifier("TradeCategoryChoice")]
        [XmlElement("TradeCategory")]
        [XmlElement("b384")]
        public string TradeCategory { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum TradeCategoryEnum { TradeCategory, b384 }
        [XmlIgnore, DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public TradeCategoryEnum TradeCategoryChoice
        {
            get { return SerializationSettings.UseShortTags ? TradeCategoryEnum.b384 : TradeCategoryEnum.TradeCategory; }
            set { }
        }

        /// <summary>
        /// An ONIX code which indicates the primary or only content type included in a product.
        /// The element is intended to be used in particular for digital products, when the sender wishes to make it clear that one of a number of content types (eg text, audio, video) is the primary type for the product.
        /// Other content types may be specified in <see cref="ProductContentType"/>.
        /// Optional and non-repeating.
        /// </summary>
        /// <remarks>Onix List 81</remarks>
        [XmlChoiceIdentifier("PrimaryContentTypeChoice")]
        [XmlElement("PrimaryContentType")]
        [XmlElement("x416")]
        public string PrimaryContentType { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum PrimaryContentTypeEnum { PrimaryContentType, x416 }
        [XmlIgnore, DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public PrimaryContentTypeEnum PrimaryContentTypeChoice
        {
            get { return SerializationSettings.UseShortTags ? PrimaryContentTypeEnum.x416 : PrimaryContentTypeEnum.PrimaryContentType; }
            set { }
        }

        /// <summary>
        /// An ONIX code which indicates a content type included in a product.
        /// The element is intended to be used in particular for digital products, to specify content types other than the primary type, or to list content types when none is singled out as the primary type.
        /// Optional, and repeatable to list multiple content types.
        /// </summary>
        /// <remarks>Onix List 81</remarks>
        [XmlChoiceIdentifier("ProductContentTypeChoice")]
        [XmlElement("ProductContentType")]
        [XmlElement("b385")]
        public string[] ProductContentType { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum ProductContentTypeEnum { ProductContentType, b385 }
        [XmlIgnore, DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
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

        /// <summary>
        /// An optional group of data elements which together identify a measurement and the units in which it is expressed; used to specify the overall dimensions of a physical product including its packaging (if any).
        /// Repeatable to provide multiple combinations of dimension and unit.
        /// </summary>
        [XmlChoiceIdentifier("MeasureChoice")]
        [XmlElement("Measure")]
        [XmlElement("measure")]
        public OnixMeasure[] Measure { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum MeasureEnum { Measure, measure }
        [XmlIgnore, DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public MeasureEnum[] MeasureChoice
        {
            get
            {
                if (Measure == null) return null;
                MeasureEnum choice = SerializationSettings.UseShortTags ? MeasureEnum.measure : MeasureEnum.Measure;
                MeasureEnum[] result = new MeasureEnum[Measure.Length];
                for (int i = 0; i < Measure.Length; i++) result[i] = choice;
                return result;
            }
            set { }
        }

        /// <summary>
        /// An ISO code identifying the country of manufacture of a single-item product, or of a multiple-item product when all items are manufactured in the same country.
        /// This information is needed in some countries to meet regulatory requirements.
        /// Optional and non-repeating.
        /// </summary>
        /// <remarks>Onix List 91</remarks>
        [XmlChoiceIdentifier("CountryOfManufactureChoice")]
        [XmlElement("CountryOfManufacture")]
        [XmlElement("x316")]
        public string CountryOfManufacture { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum CountryOfManufactureEnum { CountryOfManufacture, x316 }
        [XmlIgnore, DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public CountryOfManufactureEnum CountryOfManufactureChoice
        {
            get { return SerializationSettings.UseShortTags ? CountryOfManufactureEnum.x316 : CountryOfManufactureEnum.CountryOfManufacture; }
            set { }
        }

        /// <summary>
        /// An ONIX code specifying whether a digital product has DRM or other technical protection features.
        /// Optional, and repeatable if a product has two or more kinds of protection (ie different parts of a product are protected in different ways).
        /// </summary>
        /// <remarks>Onix List 144</remarks>
        [XmlChoiceIdentifier("EpubTechnicalProtectionChoice")]
        [XmlElement("EpubTechnicalProtection")]
        [XmlElement("x317")]
        public string[] EpubTechnicalProtection { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum EpubTechnicalProtectionEnum { EpubTechnicalProtection, x317 }
        [XmlIgnore, DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public EpubTechnicalProtectionEnum[] EpubTechnicalProtectionChoice
        {
            get
            {
                if (EpubTechnicalProtection == null) return null;
                EpubTechnicalProtectionEnum choice = SerializationSettings.UseShortTags ? EpubTechnicalProtectionEnum.x317 : EpubTechnicalProtectionEnum.EpubTechnicalProtection;
                EpubTechnicalProtectionEnum[] result = new EpubTechnicalProtectionEnum[EpubTechnicalProtection.Length];
                for (int i = 0; i < EpubTechnicalProtection.Length; i++) result[i] = choice;
                return result;
            }
            set { }
        }

        /// <summary>
        /// An optional group of data elements which together describe a usage constraint on a digital product (or the absence of such a constraint), whether enforced by DRM technical protection, inherent in the platform used, or specified by license agreement.
        /// Repeatable in order to describe multiple constraints on usage.
        /// </summary>
        [XmlChoiceIdentifier("EpubUsageConstraintChoice")]
        [XmlElement("EpubUsageConstraint")]
        [XmlElement("epubusageconstraint")]
        public OnixEpubUsageConstraint[] EpubUsageConstraint { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum EpubUsageConstraintEnum { EpubUsageConstraint, epubusageconstraint }
        [XmlIgnore, DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public EpubUsageConstraintEnum[] EpubUsageConstraintChoice
        {
            get
            {
                if (EpubUsageConstraint == null) return null;
                EpubUsageConstraintEnum choice = SerializationSettings.UseShortTags ? EpubUsageConstraintEnum.epubusageconstraint : EpubUsageConstraintEnum.EpubUsageConstraint;
                EpubUsageConstraintEnum[] result = new EpubUsageConstraintEnum[EpubUsageConstraint.Length];
                for (int i = 0; i < EpubUsageConstraint.Length; i++) result[i] = choice;
                return result;
            }
            set { }
        }

        /// <summary>
        /// An optional and non-repeatable composite carrying the name or title of the license governing use of the product, and a link to the license terms in eye-readable or machine-readable form.
        /// </summary>
        [XmlChoiceIdentifier("EpubLicenseChoice")]
        [XmlElement("EpubLicense")]
        [XmlElement("epublicense")]
        public OnixEpubLicense EpubLicense { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum EpubLicenseEnum { EpubLicense, epublicense }
        [XmlIgnore, DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public EpubLicenseEnum EpubLicenseChoice
        {
            get { return SerializationSettings.UseShortTags ? EpubLicenseEnum.epublicense : EpubLicenseEnum.EpubLicense; }
            set { }
        }

        /// <summary>
        /// The scale of a map, expressed as a ratio 1:nnnnn; only the number nnnnn is carried in the data element, without spaces or punctuation.
        /// Optional, and repeatable if a product comprises maps with two or more different scales.
        /// </summary>
        [XmlChoiceIdentifier("MapScaleChoice")]
        [XmlElement("MapScale")]
        [XmlElement("b063")]
        public decimal MapScale { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum MapScaleEnum { MapScale, b063 }
        [XmlIgnore, DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public MapScaleEnum MapScaleChoice
        {
            get { return SerializationSettings.UseShortTags ? MapScaleEnum.b063 : MapScaleEnum.MapScale; }
            set { }
        }

        /// <summary>
        /// An optional group of data elements which together define a product classification (not to be confused with a subject classification).
        /// The intended use is to enable national or international trade classifications (also known as commodity codes) to be carried in an ONIX record.
        /// The composite is repeatable if parts of the product are classified differently within a single product classification scheme, or to provide classification codes from multiple classification schemes.
        /// </summary>
        [XmlChoiceIdentifier("ProductClassificationChoice")]
        [XmlElement("ProductClassification")]
        [XmlElement("productclassification")]
        public OnixProductClassification[] ProductClassification { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum ProductClassificationEnum { ProductClassification, productclassification }
        [XmlIgnore, DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ProductClassificationEnum[] ProductClassificationChoice;

        /// <summary>
        /// A group of data elements which together describe an item which is part of or contained within a multiple-component or multiple-item product or a trade pack.
        /// The composite must be repeated for each item or component.
        /// </summary>
        [XmlChoiceIdentifier("ProductPartChoice")]
        [XmlElement("ProductPart")]
        [XmlElement("productpart")]
        public OnixProductPart[] ProductPart { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum ProductPartEnum { ProductPart, productpart }
        [XmlIgnore, DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ProductPartEnum[] ProductPartChoice
        {
            get
            {
                if (ProductPart == null) return null;
                ProductPartEnum choice = SerializationSettings.UseShortTags ? ProductPartEnum.productpart : ProductPartEnum.ProductPart;
                ProductPartEnum[] result = new ProductPartEnum[ProductPart.Length];
                for (int i = 0; i < ProductPart.Length; i++) result[i] = choice;
                return result;
            }
            set { }
        }

        /// <summary>
        /// An optional group of data elements which carry attributes of a collection of which the product is part.
        /// The composite is repeatable, to provide details when the product belongs to multiple collections.
        /// </summary>
        [XmlChoiceIdentifier("CollectionChoice")]
        [XmlElement("Collection")]
        [XmlElement("collection")]
        public OnixCollection[] Collection { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum CollectionEnum { Collection, collection }
        [XmlIgnore, DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public CollectionEnum[] CollectionChoice
        {
            get
            {
                if (Collection == null) return null;
                CollectionEnum choice = SerializationSettings.UseShortTags ? CollectionEnum.collection : CollectionEnum.Collection;
                CollectionEnum[] result = new CollectionEnum[Collection.Length];
                for (int i = 0; i < Collection.Length; i++) result[i] = choice;
                return result;
            }
            set { }
        }

        /// <remarks/>
        public string AudienceCode
        {
            get { return this.audienceCodeField; }
            set { this.audienceCodeField = value; }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Audience")]
        public OnixAudience[] Audience
        {
            get { return this.audienceField; }
            set { this.audienceField = value; }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("AudienceRange")]
        public OnixAudienceRange[] AudienceRange
        {
            get { return this.audienceRangeField; }
            set { this.audienceRangeField = value; }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("EditionType")]
        public string[] EditionType
        {
            get { return this.editionTypeField; }
            set { this.editionTypeField = value; }
        }

        /// <remarks/>
        public int EditionNumber
        {
            get { return this.editionNumberField; }
            set { this.editionNumberField = value; }
        }

        /// <remarks/>
        public string EditionStatement
        {
            get { return this.editionStatementField; }
            set { this.editionStatementField = value; }
        }

        public string EpubType
        {
            get { return this.epubTypeField; }
            set { this.epubTypeField = value; }
        }

        public string EpubTypeVersion
        {
            get { return this.epubTypeVersionField; }
            set { this.epubTypeVersionField = value; }
        }

        public string EpubFormatDescription
        {
            get { return this.epubFormatDescriptionField; }
            set { this.epubFormatDescriptionField = value; }
        }

        public string EpubTypeNote
        {
            get { return this.epubTypeNoteField; }
            set { this.epubTypeNoteField = value; }
        }

        public string IllustrationsNote
        {
            get { return this.illustrationsNoteField; }
            set { this.illustrationsNoteField = value; }
        }

        public string NumberOfIllustrations
        {
            get { return this.numOfIllustrationsField; }
            set { this.numOfIllustrationsField = value; }
        }

        /// <remarks/>
        public OnixTitleDetail TitleDetail
        {
            get { return this.titleDetailField; }
            set { this.titleDetailField = value; }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Contributor")]
        public OnixContributor[] Contributor
        {
            get { return this.contributorField; }
            set { this.contributorField = value; }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Extent")]
        public OnixExtent[] Extent
        {
            get { return this.extentField; }
            set { this.extentField = value; }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Language")]
        public OnixLanguage[] Language
        {
            get { return this.languageField; }
            set { this.languageField = value; }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Subject")]
        public OnixSubject[] Subject
        {
            get { return this.subjectField; }
            set { this.subjectField = value; }
        }

        #endregion

        #region Support Methods

        public string TranslateAudienceGradeToAge(string psGradeValue)
        {
            int nAgeVal = 0;
            string sAgeVal = "";

            if (!string.IsNullOrEmpty(psGradeValue))
            {
                if ((psGradeValue == OnixAudienceRange.CONST_AUD_GRADE_PRESCHOOL_CD) || (psGradeValue == OnixAudienceRange.CONST_AUD_GRADE_PRESCHOOL_TXT))
                    nAgeVal = 4;
                else if ((psGradeValue == OnixAudienceRange.CONST_AUD_GRADE_KNDGRTN_CD) || (psGradeValue == OnixAudienceRange.CONST_AUD_GRADE_KNDGRTN_TXT))
                    nAgeVal = 5;
                else if (int.TryParse(psGradeValue, out nAgeVal))
                    nAgeVal += 5;
            }

            if (nAgeVal > 0)
                sAgeVal = nAgeVal.ToString();

            return sAgeVal;
        }

        #endregion 
    }
}
