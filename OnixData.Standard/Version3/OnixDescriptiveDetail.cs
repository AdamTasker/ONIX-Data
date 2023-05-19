using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Xml.Serialization;

using OnixData.Version3.Audience;
using OnixData.Version3.Content;
using OnixData.Version3.Epub;
using OnixData.Version3.Event;
using OnixData.Version3.Language;
using OnixData.Version3.ProductPart;
using OnixData.Version3.Text;
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
                        (SeriesCollection.TitleDetail != null) &&
                        (SeriesCollection.TitleDetail.Length > 0))
                    {
                        var TitleDetailFound =
                            SeriesCollection.TitleDetail.Where(x => x.HasDistinctiveTitle()).FirstOrDefault();

                        if (TitleDetailFound != null)
                        {
                            var TitleElement =
                                TitleDetailFound.TitleElement.Where(x => !string.IsNullOrEmpty(x.PartNumber)).FirstOrDefault();

                            if (TitleElement != null)
                                sSeriesNum = TitleElement.PartNumber;
                        }
                    }
                }

                if (string.IsNullOrEmpty(sSeriesNum))
                {
                    if ((this.TitleDetail != null) &&
                        (this.TitleDetail[0].TitleTypeNum == OnixTitleElement.CONST_TITLE_TYPE_PRODUCT))
                    {
                        var MainTitleDetail = this.TitleDetail[0];

                        if (MainTitleDetail != null)
                        {
                            var TitleElement =
                                MainTitleDetail.TitleElement.Where(x => !string.IsNullOrEmpty(x.PartNumber)).FirstOrDefault();

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
                            SeriesCollection.TitleDetail
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

        /// <summary>
        /// An empty element that provides a positive indication that a product does not belong to a collection (a ‘set’ or ‘series’).
        /// This element is intended to be used in an ONIX accreditation scheme to confirm that collection information is being consistently supplied in publisher ONIX feeds.
        /// Optional and non-repeating.
        /// Must only be sent in a record that has no instances of the <see cref="Collection"/> composite and has no collection level title elements in <see cref="OnixTitleDetail.TitleElement"/>.
        /// </summary>
        [XmlChoiceIdentifier("NoCollectionChoice")]
        [XmlElement("NoCollection")]
        [XmlElement("x411")]
        public string NoCollection { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum NoCollectionEnum { NoCollection, x411 }
        [XmlIgnore, DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public NoCollectionEnum NoCollectionChoice
        {
            get { return SerializationSettings.UseShortTags ? NoCollectionEnum.x411 : NoCollectionEnum.NoCollection; }
            set { }
        }

        /// <summary>
        /// A group of data elements which together give the text of a title and specify its type.
        /// At least one title detail element is mandatory in each occurrence of the <see cref="OnixDescriptiveDetail"/> composite, to give the primary form of the product title.
        /// The composite is repeatable with different title types.
        /// </summary>
        [XmlChoiceIdentifier("TitleDetailChoice")]
        [XmlElement("TitleDetail")]
        [XmlElement("titledetail")]
        public OnixTitleDetail[] TitleDetail { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum TitleDetailEnum { TitleDetail, titledetail }
        [XmlIgnore, DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public TitleDetailEnum[] TitleDetailChoice
        {
            get
            {
                if (TitleDetail == null) return null;
                TitleDetailEnum choice = SerializationSettings.UseShortTags ? TitleDetailEnum.titledetail : TitleDetailEnum.TitleDetail;
                TitleDetailEnum[] result = new TitleDetailEnum[TitleDetail.Length];
                for (int i = 0; i < TitleDetail.Length; i++) result[i] = choice;
                return result;
            }
            set { }
        }

        /// <summary>
        /// An ONIX code identifying a thesis type, when the ONIX record describes an item which was originally presented as an academic thesis or dissertation.
        /// Optional and non-repeating.
        /// </summary>
        /// <remarks>Onix List 72</remarks>
        [XmlChoiceIdentifier("ThesisTypeChoice")]
        [XmlElement("ThesisType")]
        [XmlElement("b368")]
        public string ThesisType { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum ThesisTypeEnum { ThesisType, b368 }
        [XmlIgnore, DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ThesisTypeEnum ThesisTypeChoice
        {
            get { return SerializationSettings.UseShortTags ? ThesisTypeEnum.b368 : ThesisTypeEnum.ThesisType; }
            set { }
        }

        /// <summary>
        /// The name of an academic institution to which a thesis was presented.
        /// Optional and non-repeating, but if this element is present, <see cref="ThesisType"/> must also be present.
        /// </summary>
        [XmlChoiceIdentifier("ThesisPresentedToChoice")]
        [XmlElement("ThesisPresentedTo")]
        [XmlElement("b369")]
        public string ThesisPresentedTo { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum ThesisPresentedToEnum { ThesisPresentedTo, b369 }
        [XmlIgnore, DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ThesisPresentedToEnum ThesisPresentedToChoice
        {
            get { return SerializationSettings.UseShortTags ? ThesisPresentedToEnum.b369 : ThesisPresentedToEnum.ThesisPresentedTo; }
            set { }
        }

        /// <summary>
        /// The year in which a thesis was presented.
        /// Optional and non-repeating, but if this element is present, <see cref="ThesisType"/> must also be present.
        /// </summary>
        [XmlChoiceIdentifier("ThesisYearChoice")]
        [XmlElement("ThesisYear")]
        [XmlElement("b370")]
        public string ThesisYear { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum ThesisYearEnum { ThesisYear, b370 }
        [XmlIgnore, DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ThesisYearEnum ThesisYearChoice
        {
            get { return SerializationSettings.UseShortTags ? ThesisYearEnum.b370 : ThesisYearEnum.ThesisYear; }
            set { }
        }

        /// <summary>
        /// A group of data elements which together describe a personal or corporate contributor to the product.
        /// Optional, and repeatable to describe multiple contributors.
        /// </summary>
        [XmlElement("ContributorChoice")]
        [XmlElement("Contributor")]
        [XmlElement("contributor")]
        public OnixContributor[] Contributor { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum ContributorEnum { Contributor, contributor }
        [XmlIgnore, DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ContributorEnum[] ContributorChoice
        {
            get
            {
                if (Contributor == null) return null;
                ContributorEnum choice = SerializationSettings.UseShortTags ? ContributorEnum.contributor : ContributorEnum.Contributor;
                ContributorEnum[] result = new ContributorEnum[Contributor.Length];
                for (int i = 0; i < Contributor.Length; i++) result[i] = choice;
                return result;
            }
            set { }
        }

        /// <summary>
        /// Free text showing how the authorship should be described in an online display, when a standard concatenation of individual contributor elements would not give a satisfactory presentation.
        /// Optional, and repeatable if parallel text is provided in multiple languages.
        /// The language attribute is optional for a single instance of <see cref="ContributorStatement"/>, but must be included in each instance if <see cref="ContributorStatement"/> is repeated.
        /// When the <see cref="ContributorStatement"/> field is sent, the receiver should use it to replace all name detail sent in the <see cref="Contributor"/> composite for display purposes only.
        /// It does not replace the <see cref="OnixContributor.BiographicalNote"/> element.
        /// The individual name detail must also be sent in the <see cref="Contributor"/> composite for indexing and retrieval purposes.
        /// </summary>
        [XmlChoiceIdentifier("ContributorStatementChoice")]
        [XmlElement("ContributorStatement")]
        [XmlElement("b049")]
        public string[] ContributorStatement { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum ContributorStatementEnum { ContributorStatement, b049 }
        [XmlIgnore, DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ContributorStatementEnum[] ContributorStatementChoice
        {
            get
            {
                if (ContributorStatement == null) return null;
                ContributorStatementEnum choice = SerializationSettings.UseShortTags ? ContributorStatementEnum.b049 : ContributorStatementEnum.ContributorStatement;
                ContributorStatementEnum[] result = new ContributorStatementEnum[ContributorStatement.Length];
                for (int i = 0; i < ContributorStatement.Length; i++) result[i] = choice;
                return result;
            }
            set { }
        }

        /// <summary>
        /// An empty element that provides a positive indication that a product has no stated authorship.
        /// Intended to be used in an ONIX accreditation scheme to confirm that author information is being consistently supplied in publisher ONIX feeds.
        /// Optional and non-repeating.
        /// Must only be sent in a record that has no other elements from <see cref="Contributor"/>.
        /// </summary>
        [XmlChoiceIdentifier("NoContributorChoice")]
        [XmlElement("NoContributor")]
        [XmlElement("n339")]
        public string NoContributor { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum NoContributorEnum { NoContributor, n339 }
        [XmlIgnore, DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public NoContributorEnum NoContributorChoice
        {
            get { return SerializationSettings.UseShortTags ? NoContributorEnum.n339 : NoContributorEnum.NoContributor; }
            set { }
        }

        /// <summary>
        /// A group of data elements which together describe an event to which the product is related.
        /// Optional, and repeatable if the product contains material from or is related to two or more events.
        /// </summary>
        [XmlChoiceIdentifier("EventChoice")]
        [XmlElement("Event")]
        [XmlElement("event")]
        public OnixEvent[] Event { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum EventEnum { Event, @event }
        [XmlIgnore, DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public EventEnum[] EventChoice
        {
            get
            {
                if (Event == null) return null;
                EventEnum choice = SerializationSettings.UseShortTags ? EventEnum.@event : EventEnum.Event;
                EventEnum[] result = new EventEnum[Event.Length];
                for (int i = 0; i < Event.Length; i++) result[i] = choice;
                return result;
            }
            set { }
        }

        /// <summary>
        /// An ONIX code, indicating the type of a version or edition.
        /// Optional, and repeatable if the product has characteristics of two or more types (eg ‘revised’ and ‘annotated’).
        /// </summary>
        /// <remarks>Onix List 21</remarks>
        [XmlChoiceIdentifier("EditionTypeChoice")]
        [XmlElement("EditionType")]
        [XmlElement("x419")]
        public string[] EditionType { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum EditionTypeEnum { EditionType, x419 }
        [XmlIgnore, DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public EditionTypeEnum[] EditionTypeChoice
        {
            get
            {
                if (EditionType == null) return null;
                EditionTypeEnum choice = SerializationSettings.UseShortTags ? EditionTypeEnum.x419 : EditionTypeEnum.EditionType;
                EditionTypeEnum[] result = new EditionTypeEnum[EditionType.Length];
                for (int i = 0; i < EditionType.Length; i++) result[i] = choice;
                return result;
            }
            set { }
        }

        /// <summary>
        /// The number of a numbered edition.
        /// Optional and non-repeating.
        /// Normally sent only for the second and subsequent editions of a work, but by agreement between parties to an ONIX exchange a first edition may be explicitly numbered.
        /// </summary>
        [XmlChoiceIdentifier("EditionNumberChoice")]
        [XmlElement("EditionNumber")]
        [XmlElement("b057")]
        public int EditionNumber { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum EditionNumberEnum { EditionNumber, b057 }
        [XmlIgnore, DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public EditionNumberEnum EditionNumberChoice
        {
            get { return SerializationSettings.UseShortTags ? EditionNumberEnum.b057 : EditionNumberEnum.EditionNumber; }
            set { }
        }

        /// <summary>
        /// The number of a numbered revision within an edition number.
        /// To be used only where a publisher uses such two-level numbering to indicate revisions which do not constitute a new edition under a new ISBN or other distinctive product identifier.
        /// Optional and non-repeating. If this field is used, an <see cref="EditionNumber"/> must also be present.
        /// </summary>
        [XmlChoiceIdentifier("EditionVersionNumberChoice")]
        [XmlElement("EditionVersionNumber")]
        [XmlElement("b217")]
        public string EditionVersionNumber { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum EditionVersionNumberEnum { EditionVersionNumber, b217 }
        [XmlIgnore, DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public EditionVersionNumberEnum EditionVersionNumberChoice
        {
            get { return SerializationSettings.UseShortTags ? EditionVersionNumberEnum.b217 : EditionVersionNumberEnum.EditionVersionNumber; }
            set { }
        }

        /// <summary>
        /// A short free-text description of a version or edition.
        /// Optional, and repeatable if parallel text is provided in multiple languages.
        /// The language attribute is optional for a single instance of <see cref="EditionStatement"/>, but must be included in each instance if <see cref="EditionStatement"/> is repeated.
        /// When used, an <see cref="EditionStatement"/> must be complete in itself, ie it should not be treated as merely supplementary to an <see cref="EditionType"/> or an <see cref="EditionNumber"/>, nor as a replacement for them.
        /// Appropriate edition type and number must also be sent, for indexing and retrieval.
        /// An <see cref="EditionStatement"/> should be strictly limited to describing features of the content of the edition, and should not include aspects such as rights or market restrictions which are properly covered elsewhere in the ONIX record.
        /// </summary>
        [XmlChoiceIdentifier("EditionStatementChoice")]
        [XmlElement("EditionStatement")]
        [XmlElement("b058")]
        public string[] EditionStatement { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum EditionStatementEnum { EditionStatement, b058 }
        [XmlIgnore, DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public EditionStatementEnum[] EditionStatementChoice
        {
            get
            {
                if (EditionStatement == null) return null;
                EditionStatementEnum choice = SerializationSettings.UseShortTags ? EditionStatementEnum.b058 : EditionStatementEnum.EditionStatement;
                EditionStatementEnum[] result = new EditionStatementEnum[EditionStatement.Length];
                for (int i = 0; i < EditionStatement.Length; i++) result[i] = choice;
                return result;
            }
            set { }
        }

        /// <summary>
        /// An empty element that provides a positive indication that a product does not carry any edition information.
        /// Intended to be used an ONIX accreditation scheme to confirm that edition information is being consistently supplied in publisher ONIX feeds.
        /// Optional and non-repeating.
        /// Must only be sent in a record that has no instances of <see cref="EditionType"/>, <see cref="EditionNumber"/>, <see cref="EditionVersionNumber"/>, or <see cref="EditionStatement"/>.
        /// </summary>
        [XmlChoiceIdentifier("NoEditionChoice")]
        [XmlElement("NoEdition")]
        [XmlElement("n386")]
        public string NoEdition { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum NoEditionEnum { NoEdition, n386 }
        [XmlIgnore, DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public NoEditionEnum NoEditionChoice
        {
            get { return SerializationSettings.UseShortTags ? NoEditionEnum.n386 : NoEditionEnum.NoEdition; }
            set { }
        }

        /// <summary>
        /// A group of data elements which together describe features of the content of an edition of a religious text, and intended to meet the special needs of religious publishers and booksellers.
        /// Optional and non-repeating.
        /// </summary>
        [XmlChoiceIdentifier("ReligiousTextChoice")]
        [XmlElement("ReligiousText")]
        [XmlElement("religioustext")]
        public OnixReligiousText ReligiousText { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum ReligiousTextEnum { ReligiousText, religioustext }
        [XmlIgnore, DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ReligiousTextEnum ReligiousTextChoice
        {
            get { return SerializationSettings.UseShortTags ? ReligiousTextEnum.religioustext : ReligiousTextEnum.ReligiousText; }
            set { }
        }

        /// <summary>
        /// A group of data elements which together represent a language, and specify its role and, where required, whether it is a country variant.
        /// Optional, and repeatable to specify multiple languages and their various roles.
        /// </summary>
        [XmlChoiceIdentifier("LanguageChoice")]
        [XmlElement("Language")]
        [XmlElement("language")]
        public OnixLanguage[] Language { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum LanguageEnum { Language, langauge }
        [XmlIgnore, DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public LanguageEnum[] LanguageChoice
        {
            get
            {
                if (Language == null) return null;
                LanguageEnum choice = SerializationSettings.UseShortTags ? LanguageEnum.langauge : LanguageEnum.Language;
                LanguageEnum[] result = new LanguageEnum[Language.Length];
                for (int i = 0; i < Language.Length; i++) result[i] = choice;
                return result;
            }
            set { }
        }

        /// <summary>
        /// A group of data elements which together describe an extent pertaining to the product.
        /// Optional, but in practice required for most products, eg to give the number of pages in a printed book or paginated e-book, or to give the running time of an audiobook.
        /// Repeatable to specify different extent types or units
        /// </summary>
        [XmlChoiceIdentifier("ExtentChoice")]
        [XmlElement("Extent")]
        [XmlElement("extent")]
        public OnixExtent[] Extent { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum ExtentEnum { Extent, extent }
        [XmlIgnore, DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ExtentEnum[] ExtentChoice
        {
            get
            {
                if (Extent == null) return null;
                ExtentEnum choice = SerializationSettings.UseShortTags ? ExtentEnum.extent : ExtentEnum.Extent;
                ExtentEnum[] result = new ExtentEnum[Extent.Length];
                for (int i = 0; i < Extent.Length; i++) result[i] = choice;
                return result;
            }
            set { }
        }

        /// <summary>
        /// An ONIX code indicating whether a book or other textual (usually printed) product has illustrations.
        /// The more informative free text field <see cref="IllustrationsNote"/> and/or the <see cref="AncillaryContent"/> composite are strongly preferred.
        /// This element has been added specifically to cater for a situation where a sender of product information maintains only a yes/no flag, and it should not otherwise be used.
        /// Optional and non-repeating.        
        /// </summary>
        /// <remarks>Onix List 152</remarks>
        [XmlChoiceIdentifier("IllustratedChoice")]
        [XmlElement("Illustrated")]
        [XmlElement("x422")]
        public int Illustrated { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum IllustratedEnum { Illustrated, x422 }
        [XmlIgnore, DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public IllustratedEnum IllustratedChoice
        {
            get { return SerializationSettings.UseShortTags ? IllustratedEnum.x422 : IllustratedEnum.Illustrated; }
            set { }
        }

        /// <summary>
        /// The total number of illustrations in a book or other printed product.
        /// The more informative free text field <see cref="IllustrationsNote"/> and/or the <see cref="AncillaryContent"/> composite are strongly preferred, but where a sender of product information maintains only a simple numeric field, the <see cref="NumberOfIllustrations"/> element may be used.
        /// Optional and non-repeating.
        /// </summary>
        [XmlChoiceIdentifier("NumberOfIllustrationsChoice")]
        [XmlElement("NumberOfIllustrations")]
        [XmlElement("b125")]
        public int NumberOfIllustrations { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum NumberOfIllustrationsEnum { NumberOfIllustrations, b125 }
        [XmlIgnore, DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public NumberOfIllustrationsEnum NumberOfIllustrationsChoice
        {
            get { return SerializationSettings.UseShortTags ? NumberOfIllustrationsEnum.b125 : NumberOfIllustrationsEnum.NumberOfIllustrations; }
            set { }
        }

        /// <summary>
        /// For books or other text media only, this data element carries text stating the number and type of illustrations.
        /// The text may also include other content items, eg maps, bibliography, tables, index etc.
        /// Optional, and repeatable if parallel notes are provided in multiple languages.
        /// The language attribute is optional for a single instance of <see cref="IllustrationsNote"/>, but must be included in each instance if <see cref="IllustrationsNote"/> is repeated.
        /// </summary>
        [XmlChoiceIdentifier("IllustrationsNoteChoice")]
        [XmlElement("IllustrationsNote")]
        [XmlElement("b062")]
        public string[] IllustrationsNote { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum IllustrationsNoteEnum { IllustrationsNote, b062 }
        [XmlIgnore, DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public IllustrationsNoteEnum[] IllustrationsNoteChoice
        {
            get
            {
                if (IllustrationsNote == null) return null;
                IllustrationsNoteEnum choice = SerializationSettings.UseShortTags ? IllustrationsNoteEnum.b062 : IllustrationsNoteEnum.IllustrationsNote;
                IllustrationsNoteEnum[] result = new IllustrationsNoteEnum[IllustrationsNote.Length];
                for (int i = 0; i < IllustrationsNote.Length; i++) result[i] = choice;
                return result;
            }
            set { }
        }

        /// <summary>
        /// A group of data elements which together specify the number of illustrations or other content items of a stated type which the product carries.
        /// Use of the <see cref="AncillaryContent"/> composite is optional, but is repeatable if necessary to specify different types of content items.
        /// </summary>
        [XmlChoiceIdentifier("AncillaryContentChoice")]
        [XmlElement("AncillaryContent")]
        [XmlElement("ancillarycontent")]
        public OnixAncillaryContent[] AncillaryContent { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum AncillaryContentEnum { AncillaryContent, ancillarycontent }
        [XmlIgnore, DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public AncillaryContentEnum[] AncillaryContentChoice
        {
            get
            {
                if (AncillaryContent == null) return null;
                AncillaryContentEnum choice = SerializationSettings.UseShortTags ? AncillaryContentEnum.ancillarycontent : AncillaryContentEnum.AncillaryContent;
                AncillaryContentEnum[] result = new AncillaryContentEnum[AncillaryContent.Length];
                for (int i = 0; i < AncillaryContent.Length; i++) result[i] = choice;
                return result;
            }
            set { }
        }

        /// <summary>
        /// An optional and repeatable group of data elements which together specify a subject classification or subject heading.
        /// </summary>
        [XmlChoiceIdentifier("SubjectChoice")]
        [XmlElement("Subject")]
        [XmlElement("subject")]
        public OnixSubject[] Subject { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum SubjectEnum { Subject, subject }
        [XmlIgnore, DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public SubjectEnum[] SubjectChoice
        {
            get
            {
                if (Subject == null) return null;
                SubjectEnum choice = SerializationSettings.UseShortTags ? SubjectEnum.subject : SubjectEnum.Subject;
                SubjectEnum[] result = new SubjectEnum[Subject.Length];
                for (int i = 0; i < Subject.Length; i++) result[i] = choice;
                return result;
            }
            set { }
        }

        /// <summary>
        /// An optional group of data elements which together represent the name of a person or organization – real or fictional – that is part of the subject of a product.
        /// Repeatable in order to name multiple persons or organizations.
        /// </summary>
        [XmlChoiceIdentifier("NameAsSubjectChoice")]
        [XmlElement("NameAsSubject")]
        [XmlElement("nameassubject")]
        public OnixNameAsSubject[] NameAsSubject { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum NameAsSubjectEnum { NameAsSubject, nameassubject }
        [XmlIgnore, DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public NameAsSubjectEnum[] NameAsSubjectChoice
        {
            get
            {
                if (NameAsSubject == null) return null;
                NameAsSubjectEnum choice = SerializationSettings.UseShortTags ? NameAsSubjectEnum.nameassubject : NameAsSubjectEnum.NameAsSubject;
                NameAsSubjectEnum[] result = new NameAsSubjectEnum[NameAsSubject.Length];
                for (int i = 0; i < NameAsSubject.Length; i++) result[i] = choice;
                return result;
            }
            set { }
        }

        /// <summary>
        /// <para>An ONIX code, originally derived from BISAC and BIC lists, which identifies the broad audience or readership for which a product is intended. 
        /// Optional, and repeatable if the product is intended for two or more groups.</para>
        /// <para>Deprecated, in favor of providing the same information within the <see cref="Audience"/> composite using code 01 from List 29.</para>
        /// </summary>
        /// <remarks>Onix List 28</remarks>
        [XmlChoiceIdentifier("AudienceCodeChoice")]
        [XmlElement("AudienceCode")]
        [XmlElement("b073")]
        public string[] AudienceCode { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum AudienceCodeEnum { AudienceCode, b073 }
        [XmlIgnore, DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public AudienceCodeEnum[] AudienceCodeChoice
        {
            get
            {
                if (AudienceCode == null) return null;
                AudienceCodeEnum choice = SerializationSettings.UseShortTags ? AudienceCodeEnum.b073 : AudienceCodeEnum.AudienceCode;
                AudienceCodeEnum[] result = new AudienceCodeEnum[AudienceCode.Length];
                for (int i = 0; i < AudienceCode.Length; i++) result[i] = choice;
                return result;
            }
            set { }
        }

        /// <summary>
        /// An optional group of data elements which together describe an audience to which the product is directed.
        /// Repeatable to specify multiple distinct audiences.
        /// </summary>
        [XmlChoiceIdentifier("AudienceChoice")]
        [XmlElement("Audience")]
        [XmlElement("audience")]
        public OnixAudience[] Audience { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum AudienceEnum { Audience, audience }
        [XmlIgnore, DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public AudienceEnum[] AudienceChoice
        {
            get
            {
                if (Audience == null) return null;
                AudienceEnum choice = SerializationSettings.UseShortTags ? AudienceEnum.audience : AudienceEnum.Audience;
                AudienceEnum[] result = new AudienceEnum[Audience.Length];
                for (int i = 0; i < Audience.Length; i++) result[i] = choice;
                return result;
            }
            set { }
        }

        /// <summary>
        /// An optional group of data elements which together describe an audience or readership range for which a product is intended.
        /// The composite can carry a single value from, to, or exact, or a pair of values with an explicit from and to.
        /// Repeatable to specify the audience range with different qualifiers.
        /// </summary>
        [XmlChoiceIdentifier("AudienceRangeChoice")]
        [XmlElement("AudienceRange")]
        [XmlElement("audiencerange")]
        public OnixAudienceRange[] AudienceRange { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum AudienceRangeEnum { AudienceRange, audiencerange }
        [XmlIgnore, DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public AudienceRangeEnum[] AudienceRangeChoice
        {
            get
            {
                if (AudienceRange == null) return null;
                AudienceRangeEnum choice = SerializationSettings.UseShortTags ? AudienceRangeEnum.audiencerange : AudienceRangeEnum.AudienceRange;
                AudienceRangeEnum[] result = new AudienceRangeEnum[AudienceRange.Length];
                for (int i = 0; i < AudienceRange.Length; i++) result[i] = choice;
                return result;
            }
            set { }
        }

        /// <summary>
        /// Free text describing the audience for which a product is intended.
        /// Optional, and repeatable if parallel descriptive text is provided in multiple languages.
        /// The language attribute is optional for a single instance of <see cref="AudienceDescription"/>, but must be included in each instance if <see cref="AudienceDescription"/> is repeated.
        /// </summary>
        [XmlChoiceIdentifier("AudienceDescriptionChoice")]
        [XmlElement("AudienceDescription")]
        [XmlElement("b207")]
        public string[] AudienceDescription { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum AudienceDescriptionEnum { AudienceDescription, b207 }
        [XmlIgnore, DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public AudienceDescriptionEnum[] AudienceDescriptionChoice
        {
            get
            {
                if (AudienceDescription == null) return null;
                AudienceDescriptionEnum choice = SerializationSettings.UseShortTags ? AudienceDescriptionEnum.b207 : AudienceDescriptionEnum.AudienceDescription;
                AudienceDescriptionEnum[] result = new AudienceDescriptionEnum[AudienceDescription.Length];
                for (int i = 0; i < AudienceDescription.Length; i++) result[i] = choice;
                return result;
            }
            set { }
        }

        /// <summary>
        /// An optional group of data elements which together describe the level of complexity of a text.
        /// Repeatable to specify the complexity using different schemes.
        /// </summary>
        [XmlChoiceIdentifier("ComplexityChoice")]
        [XmlElement("Complexity")]
        [XmlElement("complexity")]
        public OnixComplexity[] Complexity { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum ComplexityEnum { Complexity, complexity }
        [XmlIgnore, DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ComplexityEnum[] ComplexityChoice
        {
            get
            {
                if (Complexity == null) return null;
                ComplexityEnum choice = SerializationSettings.UseShortTags ? ComplexityEnum.complexity : ComplexityEnum.Complexity;
                ComplexityEnum[] result = new ComplexityEnum[Complexity.Length];
                for (int i = 0; i < Complexity.Length; i++) result[i] = choice;
                return result;
            }
            set { }
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
