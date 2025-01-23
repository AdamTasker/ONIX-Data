using System.Xml.Serialization;

namespace OnixData.Version3.Xml.Enums
{
    [XmlType(IncludeInSchema = false)] public enum ProductIdentifierEnum { ProductIdentifier, productidentifier }
    [XmlType(IncludeInSchema = false)] public enum ProductFormEnum { ProductForm, b012 }
    [XmlType(IncludeInSchema = false)] public enum ProductFormDetailEnum { ProductFormDetail, b333 }
    [XmlType(IncludeInSchema = false)] public enum ProductFormFeatureEnum { ProductFormFeature, productformfeature }
    [XmlType(IncludeInSchema = false)] public enum ProductPackagingEnum { ProductPackaging, b225 }
    [XmlType(IncludeInSchema = false)] public enum ProductFormDescriptionEnum { ProductFormDescription, b014 }
    [XmlType(IncludeInSchema = false)] public enum ProductContentTypeEnum { ProductContentType, b385 }
    [XmlType(IncludeInSchema = false)] public enum MeasureEnum { Measure, measure }
    [XmlType(IncludeInSchema = false)] public enum CountryOfManufactureEnum { CountryOfManufacture, x316 }
    [XmlType(IncludeInSchema = false)] public enum SequenceNumberEnum { SequenceNumber, b034 }
    [XmlType(IncludeInSchema = false)] public enum TitleDetailEnum { TitleDetail, titledetail }
    [XmlType(IncludeInSchema = false)] public enum ContributorEnum { Contributor, contributor }
    [XmlType(IncludeInSchema = false)] public enum ContributorStatementEnum { ContributorStatement, b049 }
    [XmlType(IncludeInSchema = false)] public enum NoContributorEnum { NoContributor, n339 }
    [XmlType(IncludeInSchema = false)] public enum PersonNameEnum { PersonName, b036 }
    [XmlType(IncludeInSchema = false)] public enum CorporateNameEnum { CorporateName, b047 }
    [XmlType(IncludeInSchema = false)] public enum WebsiteEnum { Website, website }
    [XmlType(IncludeInSchema = false)] public enum CountryCodeEnum { CountryCode, b251 }
    [XmlType(IncludeInSchema = false)] public enum RegionCodeEnum { RegionCode, b398 }
    [XmlType(IncludeInSchema = false)] public enum ContentDateEnum { ContentDate, contentdate }
    [XmlType(IncludeInSchema = false)] public enum ContentAudienceEnum { ContentAudience, x427 }
    [XmlType(IncludeInSchema = false)] public enum TerritoryEnum { Territory, territory }
    [XmlType(IncludeInSchema = false)] public enum FeatureValueEnum { FeatureValue, x439 }
    [XmlType(IncludeInSchema = false)] public enum FeatureNoteEnum { FeatureNote, x440 }
    [XmlType(IncludeInSchema = false)] public enum ResourceLinkEnum { ResourceLink, x435 }
    [XmlType(IncludeInSchema = false)] public enum UnpricedItemTypeEnum { UnpricedItemType, j192 }
}
