using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

using OnixData.Version3.Contributor;
using OnixData.Version3.Names;
using OnixData.Version3.Subject;
using OnixData.Version3.Supply;
using OnixData.Version3.Text;
using OnixData.Version3.Xml.Enums;

namespace OnixData.Version3
{
    /// <remarks/>
    [XmlType(AnonymousType = true)]
    public partial class OnixContributor : OnixNameBase
    {
        #region CONSTANTS
        public const string CONST_CONTRIB_ROLE_AUTHOR = "A01";
        public const string CONST_CONTRIB_ROLE_GHOST_AUTHOR = "A02";
        public const string CONST_CONTRIB_ROLE_SRNPLY_AUTHOR = "A03";
        public const string CONST_CONTRIB_ROLE_LIBRTO_AUTHOR = "A04";
        public const string CONST_CONTRIB_ROLE_LYRICS_AUTHOR = "A05";
        public const string CONST_CONTRIB_ROLE_EDITED_BY = "B01";
        public const string CONST_CONTRIB_ROLE_REVISED_BY = "B02";
        public const string CONST_CONTRIB_ROLE_RETOLD_BY = "B03";
        public const string CONST_CONTRIB_ROLE_COMPILED_BY = "C01";
        public const string CONST_CONTRIB_ROLE_SELECTED_BY = "C02";
        public const string CONST_CONTRIB_ROLE_PRODUCER = "D01";
        public const string CONST_CONTRIB_ROLE_DIRECTOR = "D02";
        public const string CONST_CONTRIB_ROLE_ACTOR = "E01";
        public const string CONST_CONTRIB_ROLE_DANCER = "E02";
        public const string CONST_CONTRIB_ROLE_NARRATOR = "E03";
        public const string CONST_CONTRIB_ROLE_COMMENTATOR = "E04";
        public const string CONST_CONTRIB_ROLE_VOCAL_SOLO = "E05";
        public const string CONST_CONTRIB_ROLE_FILMED_BY = "F01";
        public const string CONST_CONTRIB_ROLE_OTHER = "Z99";
        #endregion

        #region Reference Tags

        /// <summary>
        /// A number which specifies a single overall sequence of contributor names.
        /// Optional and non-repeating.
        /// It is strongly recommended that each occurrence of the <see cref="OnixContributor"/> composite should carry a <see cref="SequenceNumber"/>.
        /// </summary>
        [XmlChoiceIdentifier("SequenceNumberChoice")]
        [XmlElement("SequenceNumber")]
        [XmlElement("b034")]
        public int SequenceNumber { get; set; }
        [XmlIgnore, DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public SequenceNumberEnum SequenceNumberChoice
        {
            get { return SerializationSettings.UseShortTags ? SequenceNumberEnum.b034 : SequenceNumberEnum.SequenceNumber; }
            set { }
        }

        /// <summary>
        /// An ONIX code indicating the role played by a person or corporate body in the creation of the product.
        /// Mandatory in each occurrence of a <see cref="OnixContributor"/> composite, and may be repeated if the same person or corporate body has more than one role in relation to the product.
        /// </summary>
        /// <remarks>Onix List 17</remarks>
        [XmlChoiceIdentifier("ContributorRoleChoice")]
        [XmlElement("ContributorRole")]
        [XmlElement("b035")]
        public string[] ContributorRole { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum ContributorRoleEnum { ContributorRole, b035 }
        [XmlIgnore, DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ContributorRoleEnum[] ContributorRoleChoice
        {
            get
            {
                if (ContributorRole == null) return null;
                ContributorRoleEnum choice = SerializationSettings.UseShortTags ? ContributorRoleEnum.b035 : ContributorRoleEnum.ContributorRole;
                ContributorRoleEnum[] result = new ContributorRoleEnum[ContributorRole.Length];
                for (int i = 0; i < ContributorRole.Length; i++) result[i] = choice;
                return result;
            }
            set { }
        }

        /// <summary>
        /// Used only when the <see cref="ContributorRole"/> code value is B06, B08 or B10 indicating a translator, to specify the source language from which the translation was made.
        /// This element makes it possible to specify a translator’s exact responsibility when a work involves translation from two or more languages.
        /// Optional, and repeatable in the event that a single person has been responsible for translation from two or more languages.
        /// </summary>
        /// <remarks>Onix List 74</remarks>
        [XmlChoiceIdentifier("FromLanguageChoice")]
        [XmlElement("FromLanguage")]
        [XmlElement("x412")]
        public string[] FromLanguage { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum FromLanguageEnum { FromLanguage, x412 }
        [XmlIgnore, DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public FromLanguageEnum[] FromLanguageChoice
        {
            get
            {
                if (FromLanguage == null) return null;
                FromLanguageEnum choice = SerializationSettings.UseShortTags ? FromLanguageEnum.x412 : FromLanguageEnum.FromLanguage;
                FromLanguageEnum[] result = new FromLanguageEnum[FromLanguage.Length];
                for (int i = 0; i < FromLanguage.Length; i++) result[i] = choice;
                return result;
            }
            set { }
        }

        /// <summary>
        /// Used only when the <see cref="ContributorRole"/> code value is B06, B08 or B10 indicating a translator, to specify the target language into which the translation was made.
        /// This element makes it possible to specify a translator’s exact responsibility when a work involves translation into two or more languages.
        /// Optional, and repeatable in the event that a single person has been responsible for translation to two or more languages.
        /// </summary>
        /// <remarks>Onix List 74</remarks>
        [XmlChoiceIdentifier("ToLanguageChoice")]
        [XmlElement("ToLanguage")]
        [XmlElement("x413")]
        public string[] ToLanguage { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum ToLanguageEnum { ToLanguage, x413 }
        [XmlIgnore, DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ToLanguageEnum[] ToLanguageChoice
        {
            get
            {
                if (ToLanguage == null) return null;
                ToLanguageEnum choice = SerializationSettings.UseShortTags ? ToLanguageEnum.x413 : ToLanguageEnum.ToLanguage;
                ToLanguageEnum[] result = new ToLanguageEnum[ToLanguage.Length];
                for (int i = 0; i < ToLanguage.Length; i++) result[i] = choice;
                return result;
            }
            set { }
        }

        /// <summary>
        /// A group of data elements which together specify a date associated with the person or organization identified in an occurrence of the <see cref="OnixContributor"/> composite, eg birth or death.
        /// Optional, and repeatable to allow multiple dates to be specified.
        /// </summary>
        [XmlChoiceIdentifier("ContributorDateChoice")]
        [XmlElement("ContributorDate")]
        [XmlElement("contributordate")]
        public OnixContributorDate[] ContributorDate { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum ContributorDateEnum { ContributorDate, contributordate }
        [XmlIgnore, DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ContributorDateEnum[] ContributorDateChoice
        {
            get
            {
                if (ContributorDate == null) return null;
                ContributorDateEnum choice = SerializationSettings.UseShortTags ? ContributorDateEnum.contributordate : ContributorDateEnum.ContributorDate;
                ContributorDateEnum[] result = new ContributorDateEnum[ContributorDate.Length];
                for (int i = 0; i < ContributorDate.Length; i++) result[i] = choice;
                return result;
            }
            set { }
        }

        /// <summary>
        /// An optional group of data elements which together describe a prize or award won by the product or work, and repeatable where it has gained multiple prizes or awards.
        /// </summary>
        [XmlChoiceIdentifier("PrizeChoice")]
        [XmlElement("Prize")]
        [XmlElement("prize")]
        public OnixPrize[] Prize { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum PrizeEnum { Prize, prize }
        [XmlIgnore, DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public PrizeEnum[] PrizeChoice
        {
            get
            {
                if (Prize == null) return null;
                PrizeEnum choice = SerializationSettings.UseShortTags ? PrizeEnum.prize : PrizeEnum.Prize;
                PrizeEnum[] result = new PrizeEnum[Prize.Length];
                for (int i = 0; i < Prize.Length; i++) result[i] = choice;
                return result;
            }
            set { }
        }

        /// <summary>
        /// A biographical note about a contributor to the product.
        /// Optional, and repeatable to provide parallel biographical notes in multiple languages.
        /// The language attribute is optional for a single instance of <see cref="BiographicalNote"/>, but must be included in each instance if <see cref="BiographicalNote"/> is repeated.
        /// May occur with a person name or with a corporate name.
        /// A biographical note in ONIX should always contain the name of the person or body concerned, and it should always be presented as a piece of continuous text consisting of full sentences.
        /// Some recipients of ONIX data feeds will not accept text which has embedded URLs.
        /// A contributor website link can be sent using the <see cref="Website"/> composite below.
        /// </summary>
        [XmlChoiceIdentifier("BiographicalNoteChoice")]
        [XmlElement("BiographicalNote")]
        [XmlElement("b044")]
        public string[] BiographicalNote { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum BiographicalNoteEnum { BiographicalNote, b044 }
        [XmlIgnore, DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public BiographicalNoteEnum[] BiographicalNoteChoice
        {
            get
            {
                if (BiographicalNote == null) return null;
                BiographicalNoteEnum choice = SerializationSettings.UseShortTags ? BiographicalNoteEnum.b044 : BiographicalNoteEnum.BiographicalNote;
                BiographicalNoteEnum[] result = new BiographicalNoteEnum[BiographicalNote.Length];
                for (int i = 0; i < BiographicalNote.Length; i++) result[i] = choice;
                return result;
            }
            set { }
        }

        /// <summary>
        /// An optional group of data elements which together identify and provide a pointer to a website which is related to the person or organization identified in an occurrence of the <see cref="OnixContributor"/> composite.
        /// Repeatable to provide links to multiple websites.
        /// </summary>
        [XmlChoiceIdentifier("WebsiteChoice")]
        [XmlElement("Website")]
        [XmlElement("website")]
        public OnixWebsite[] Website { get; set; }
        [XmlIgnore, DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public WebsiteEnum[] WebsiteChoice
        {
            get
            {
                if (Website == null) return null;
                WebsiteEnum choice = SerializationSettings.UseShortTags ? WebsiteEnum.website : WebsiteEnum.Website;
                WebsiteEnum[] result = new WebsiteEnum[Website.Length];
                for (int i = 0; i < Website.Length; i++) result[i] = choice;
                return result;
            }
            set { }
        }

        /// <summary>
        /// Brief text describing a contributor to the product, at the publisher’s discretion.
        /// Optional, and repeatable to provide parallel descriptions in multiple languages.
        /// The language attribute is optional for a single instance of <see cref="ContributorDescription"/>, but must be included in each instance if <see cref="ContributorDescription"/> is repeated.
        /// It may be used with either a person or corporate name, to draw attention to any aspect of a contributor’s background which supports the promotion of the book.
        /// </summary>
        [XmlChoiceIdentifier("ContributorDescriptionChoice")]
        [XmlElement("ContributorDescription")]
        [XmlElement("b048")]
        public string[] ContributorDescription { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum ContributorDescriptionEnum { ContributorDescription, b048 }
        [XmlIgnore, DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ContributorDescriptionEnum[] ContributorDescriptionChoice
        {
            get
            {
                if (ContributorDescription == null) return null;
                ContributorDescriptionEnum choice = SerializationSettings.UseShortTags ? ContributorDescriptionEnum.b048 : ContributorDescriptionEnum.ContributorDescription;
                ContributorDescriptionEnum[] result = new ContributorDescriptionEnum[ContributorDescription.Length];
                for (int i = 0; i < ContributorDescription.Length; i++) result[i] = choice;
                return result;
            }
            set { }
        }

        /// <summary>
        /// An optional group of data elements which together identify a geographical location with which a contributor is associated, used to support ‘local interest’ promotions.
        /// Repeatable to identify multiple geographical locations, each usually with a different relationship to the contributor.
        /// </summary>
        [XmlChoiceIdentifier("ContributorPlaceChoice")]
        [XmlElement("ContributorPlace")]
        [XmlElement("contributorplace")]
        public OnixContributorPlace[] ContributorPlace { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum ContributorPlaceEnum { ContributorPlace, contributorplace }
        [XmlIgnore, DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ContributorPlaceEnum[] ContributorPlaceChoice
        {
            get
            {
                if (ContributorPlace == null) return null;
                ContributorPlaceEnum choice = SerializationSettings.UseShortTags ? ContributorPlaceEnum.contributorplace : ContributorPlaceEnum.ContributorPlace;
                ContributorPlaceEnum[] result = new ContributorPlaceEnum[ContributorPlace.Length];
                for (int i = 0; i < ContributorPlace.Length; i++) result[i] = choice;
                return result;
            }
            set { }
        }

        #endregion
    }

    public partial class OnixNameAsSubject : OnixNameBase
    {
        public OnixSubjectDate[] SubjectDate { get; set; }
    }

    /// <remarks/>
    [XmlType(AnonymousType = true)]
    public partial class OnixNameBase : OnixAlternateName
    {

        /// <summary>
        /// An ONIX code indicating the type of a primary name.
        /// Optional, and non-repeating.
        /// If omitted, the default is ‘unspecified’.
        /// </summary>
        /// <remarks>Onix List 18</remarks>
        [XmlChoiceIdentifier("NameTypeChoice")]
        [XmlElement("NameType")]
        [XmlElement("x414")]
        public new string NameType { get; set; }
        [XmlIgnore, DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new NameTypeEnum NameTypeChoice
        {
            get { return SerializationSettings.UseShortTags ? NameTypeEnum.x414 : NameTypeEnum.NameType; }
            set { }
        }

        /// <remarks/>
        [XmlChoiceIdentifier("AlternativeNameChoice")]
        [XmlElement("AlternativeName")]
        [XmlElement("alternativename")]
        public OnixAlternateName[] AlternativeName { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum AlternativeNameEnum { AlternativeName, alternativename }
        [XmlIgnore, DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public AlternativeNameEnum[] AlternativeNameChoice
        {
            get
            {
                if (AlternativeName == null) return null;
                AlternativeNameEnum choice = SerializationSettings.UseShortTags ? AlternativeNameEnum.alternativename : AlternativeNameEnum.AlternativeName;
                AlternativeNameEnum[] result = new AlternativeNameEnum[AlternativeName.Length];
                for (int i = 0; i < AlternativeName.Length; i++) result[i] = choice;
                return result;
            }
            set { }
        }

        /// <summary>
        /// A group of data elements which together identify a contributor’s professional position and/or affiliation.
        /// Optional and repeatable to allow multiple positions and affiliations to be specified.
        /// </summary>
        [XmlChoiceIdentifier("ProfessionalAffiliationChoice")]
        [XmlElement("ProfessionalAffiliation")]
        [XmlElement("professionalaffiliation")]
        public OnixProfessionalAffiliation[] ProfessionalAffiliation { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum ProfessionalAffiliationEnum { ProfessionalAffiliation, professionalaffiliation }
        [XmlIgnore, DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ProfessionalAffiliationEnum[] ProfessionalAffiliationChoice
        {
            get
            {
                if (ProfessionalAffiliation == null) return null;
                ProfessionalAffiliationEnum choice = SerializationSettings.UseShortTags ? ProfessionalAffiliationEnum.professionalaffiliation : ProfessionalAffiliationEnum.ProfessionalAffiliation;
                ProfessionalAffiliationEnum[] result = new ProfessionalAffiliationEnum[ProfessionalAffiliation.Length];
                for (int i = 0; i < ProfessionalAffiliation.Length; i++) result[i] = choice;
                return result;
            }
            set { }
        }
    }

    /// <remarks/>
    [XmlType(AnonymousType = true)]
    public partial class OnixAlternateName
    {
        #region CONSTANTS

        public const int CONST_NAME_TYPE_UNKNOWN   = 0;
        public const int CONST_NAME_TYPE_PSEUDONYM = 1;
        public const int CONST_NAME_TYPE_AUTH_CNTL = 2;
        public const int CONST_NAME_TYPE_EARLIER   = 3;
        public const int CONST_NAME_TYPE_REAL      = 4;
        public const int CONST_NAME_TYPE_TRANSLIT  = 6;
        public const int CONST_NAME_TYPE_LATER     = 7;

        public readonly int[] CONST_SOUGHT_NAME_TYPES = { CONST_NAME_TYPE_PSEUDONYM, CONST_NAME_TYPE_REAL };

        private static readonly HashSet<string> CONST_ALL_ALLOWED_SUFFIX_LIST =
            new HashSet<string>()
{
"I", "II", "III", "IV", "V", "VI", "VII", "VIII", "IX", "X"
, "XI", "XII", "XIII", "XIV", "XV", "XVI", "XVII", "XVIII", "XIX"
, "XX", "XXI", "XXII", "XXIII", "2nd", "3rd", "AB", "ACE", "AG", "ASC"
, "B.V.", "BA", "BBA", "BE", "BS", "BSN", "CA", "CC", "CFP", "CM"
, "Co.", "Co., Ltd.", "Corp.", "CPA", "CQ", "DBE", "DC", "DD", "DDS", "DGA"
, "DMD", "DO", "DPM", "DSM", "DVM", "Esq", "fils", "FRS", "GmbH", "GOQ"
, "Inc", "JD", "Jr", "KBE", "KC", "KCB", "KG", "KK", "Lit B", "Lit D"
, "Litt B", "Litt D", "LLB", "LLC", "LLD", "LLM", "LM", "LOM", "LPN", "Ltd"
, "MA", "MBA", "MBE", "MD", "MFA", "MH", "MHA", "MLA", "MNA", "MP"
, "MPP", "MS", "MSc", "N.V.", "OBE", "OC", "OD", "OM", "OQ", "PC"
, "père", "PhD", "plc", "Pty", "Pty Ltd", "QC", "RCAF", "RCMP", "RCN", "Ret"
, "RN", "RS", "S.A.de C.V.", "S.p.A.", "S.r.l.", "SA", "SJ", "Sr", "USA", "USAF"
, "USCG", "USMC", "USN", "VC", "VMD", "Y.K."
};

        private static readonly HashSet<string> CONST_ALL_ALLOWED_FILTERED_SUFFIX_LIST =
            new HashSet<string>()
{
"I", "II", "III", "IV", "V", "VI", "VII", "VIII", "IX", "X"
, "XI", "XII", "XIII", "XIV", "XV", "XVI", "XVII", "XVIII", "XIX"
, "XX", "XXI", "XXII", "XXIII", "2ND", "3RD", "AB", "ACE", "AG", "ASC"
, "BV", "BA", "BBA", "BE", "BS", "BSN", "CA", "CC", "CFP", "CM"
, "CO", "CO,LTD", "CORP", "CPA", "CQ", "DBE", "DC", "DD", "DDS", "DGA"
, "DMD", "DO", "DPM", "DSM", "DVM", "ESQ", "FILS", "FRS", "GMBH", "GOQ"
, "INC", "JD", "JR", "KBE", "KC", "KCB", "KG", "KK", "LITB", "LITD"
, "LITTB", "LITTD", "LLB", "LLC", "LLD", "LLM", "LM", "LOM", "LPN", "LTD"
, "MA", "MBA", "MBE", "MD", "MFA", "MH", "MHA", "MLA", "MNA", "MP"
, "MPP", "MS", "MSC", "NV", "OBE", "OC", "OD", "OM", "OQ", "PC"
, "PÈRE", "PHD", "PLC", "PTY", "PTYLTD", "QC", "RCAF", "RCMP", "RCN", "RET"
, "RN", "RS", "SADECV", "SPA", "SRL", "SA", "SJ", "SR", "USA", "USAF"
, "USCG", "USMC", "USN", "VC", "VMD", "YK"
};

        #endregion

        #region ONIX Helpers

        /// <remarks/>
        public OnixNameIdentifier GetFirstNameIdentifier(int pnNameIdTypeNum)
        {
            var firstNameID =
                NameIdentifier
                .Where(x => (x.NameIDTypeNum == pnNameIdTypeNum) && (!string.IsNullOrEmpty(x.IDValue)))
                .FirstOrDefault();

            return (firstNameID != null) ? firstNameID : new OnixNameIdentifier();
        }

        public OnixNameIdentifier GetFirstProprietaryNameId()
        {
            return GetFirstNameIdentifier(OnixNameIdentifier.CONST_NAME_TYPE_ID_PROP);
        }

        /// <remarks/>
        public string OnixNamesBeforeKey
        {
            get
            {
                if (string.IsNullOrEmpty(onixNamesBeforeKey))
                    DetermineContribFields();

                return onixNamesBeforeKey;
            }
        }

        /// <remarks/>
        public string OnixKeyNames
        {
            get
            {
                if (string.IsNullOrEmpty(onixKeyNames))
                    DetermineContribFields();

                return onixKeyNames;
            }
        }

        /// <remarks/>
        public string OnixLettersAndTitles
        {
            get
            {
                if (string.IsNullOrEmpty(onixLettersAndTitles))
                    DetermineContribFields();

                return onixLettersAndTitles;
            }
        }

        public bool IsSoughtNameType()
        {
            return CONST_SOUGHT_NAME_TYPES.Contains(NameTypeNum);
        }

        public int NameTypeNum
        {
            get
            {
                int nTypeNum = -1;

                if (!string.IsNullOrEmpty(NameType))
                    int.TryParse(NameType, out nTypeNum);

                return nTypeNum;
            }
        }

        #endregion

        private string onixNamesBeforeKey;
        private string onixKeyNames;
        private string onixLettersAndTitles;

        #region Reference Tags

        /// <summary>
        /// An ONIX code indicating the type of the name sent in an occurrence of the <see cref="OnixAlternativeName"/> composite.
        /// Mandatory in each occurrence of the composite, and non-repeating.
        /// </summary>
        /// <remarks>Onix List 18</remarks>
        [XmlChoiceIdentifier("NameTypeChoice")]
        [XmlElement("NameType")]
        [XmlElement("x414")]
        public string NameType { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum NameTypeEnum { NameType, x414 }
        [XmlIgnore, DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public NameTypeEnum NameTypeChoice
        {
            get { return SerializationSettings.UseShortTags ? NameTypeEnum.x414 : NameTypeEnum.NameType; }
            set { }
        }

        /// <summary>
        /// A group of data elements which together specify a name identifier, used here to carry an identifier for a person or organization name given in an occurrence of the <see cref="OnixContributor"/> composite.
        /// Optional and repeatable to specify name identifiers of different types for the same person or organization name.
        /// </summary>
        [XmlChoiceIdentifier("NameIdentifierChoice")]
        [XmlElement("NameIdentifier")]
        [XmlElement("nameidentifier")]
        public OnixNameIdentifier[] NameIdentifier { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum NameIdentifierEnum { NameIdentifier, nameidentifier }
        [XmlIgnore, DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public NameIdentifierEnum[] NameIdentifierChoice
        {
            get
            {
                if (NameIdentifier == null) return null;
                NameIdentifierEnum choice = SerializationSettings.UseShortTags ? NameIdentifierEnum.nameidentifier : NameIdentifierEnum.NameIdentifier;
                NameIdentifierEnum[] result = new NameIdentifierEnum[NameIdentifier.Length];
                for (int i = 0; i < NameIdentifier.Length; i++) result[i] = choice;
                return result;
            }
            set { }
        }

        /// <summary>
        /// The name of a person who contributed to the creation of the product, unstructured, and presented in normal order.
        /// Optional and non-repeating.
        /// </summary>
        [XmlChoiceIdentifier("PersonNameChoice")]
        [XmlElement("PersonName")]
        [XmlElement("b036")]
        public string PersonName { get; set; }
        [XmlIgnore, DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public PersonNameEnum PersonNameChoice
        {
            get { return SerializationSettings.UseShortTags ? PersonNameEnum.b036 : PersonNameEnum.PersonName; }
            set { }
        }

        /// <summary>
        /// The name of a person who contributed to the creation of the product, presented with the element used for alphabetical sorting placed first (‘inverted order’).
        /// Optional and non-repeating.
        /// </summary>
        [XmlChoiceIdentifier("PersonNameInvertedChoice")]
        [XmlElement("PersonNameInverted")]
        [XmlElement("b037")]
        public string PersonNameInverted { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum PersonNameInvertedEnum { PersonNameInverted, b037 }
        [XmlIgnore, DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public PersonNameInvertedEnum PersonNameInvertedChoice
        {
            get { return SerializationSettings.UseShortTags ? PersonNameInvertedEnum.b037 : PersonNameInvertedEnum.PersonNameInverted; }
            set { }
        }


        /// <summary>
        /// The first part of a structured name of a person who contributed to the creation of the product:
        /// qualifications and/or titles preceding a person’s names, eg ‘Professor’ or ‘HRH Prince’ or ‘Saint’.
        /// Optional and non-repeating.
        /// </summary>
        [XmlChoiceIdentifier("TitlesBeforeNamesChoice")]
        [XmlElement("TitlesBeforeNames")]
        [XmlElement("b038")]
        public string TitlesBeforeNames { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum TitlesBeforeNamesEnum { TitlesBeforeNames, b038 }
        [XmlIgnore, DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public TitlesBeforeNamesEnum TitlesBeforeNamesChoice
        {
            get { return SerializationSettings.UseShortTags ? TitlesBeforeNamesEnum.b038 : TitlesBeforeNamesEnum.TitlesBeforeNames; }
            set { }
        }

        /// <summary>
        /// The second part of a structured name of a person who contributed to the creation of the product:
        /// name(s) and/or initial(s) preceding a person’s key name(s), eg James J.
        /// Optional and non-repeating.
        /// </summary>
        [XmlChoiceIdentifier("NamesBeforeKeyChoice")]
        [XmlElement("NamesBeforeKey")]
        [XmlElement("b039")]
        public string NamesBeforeKey { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum NamesBeforeKeyEnum { NamesBeforeKey, b039 }
        [XmlIgnore, DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public NamesBeforeKeyEnum NamesBeforeKeyChoice
        {
            get { return SerializationSettings.UseShortTags ? NamesBeforeKeyEnum.b039 : NamesBeforeKeyEnum.NamesBeforeKey; }
            set { }
        }

        /// <summary>
        /// The third part of a structured name of a person who contributed to the creation of the product:
        /// a prefix which precedes the key name(s) but which is not to be treated as part of the key name, eg ‘van’ in Ludwig van Beethoven.
        /// This element may also be used for titles that appear after given names and before key names, eg ‘Lord’ in Alfred, Lord Tennyson.
        /// Optional and non-repeating.
        /// </summary>
        [XmlChoiceIdentifier("PrefixToKeyChoice")]
        [XmlElement("PrefixToKey")]
        [XmlElement("b247")]
        public string PrefixToKey { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum PrefixToKeyEnum { PrefixToKey, b247 }
        [XmlIgnore, DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public PrefixToKeyEnum PrefixToKeyChoice
        {
            get { return SerializationSettings.UseShortTags ? PrefixToKeyEnum.b247 : PrefixToKeyEnum.PrefixToKey; }
            set { }
        }

        /// <summary>
        /// The fourth part of a structured name of a person who contributed to the creation of the product:
        /// key name(s), ie the name elements normally used to open an entry in an alphabetical list, eg ‘Smith’ or ‘Garcia Marquez’ or ‘Madonna’ or ‘Francis de Sales’ (in Saint Francis de Sales).
        /// Non-repeating.
        /// Required if <see cref="TitlesBeforeNames"/>, <see cref="NamesBeforeKey"/>, <see cref="PrefixToKey"/>, <see cref="NamesAfterKey"/>, <see cref="SuffixToKey"/>, <see cref="LettersAfterNames"/>, or <see cref="TitlesAfterNames"/> are used.
        /// </summary>
        [XmlChoiceIdentifier("KeyNamesChoice")]
        [XmlElement("KeyNames")]
        [XmlElement("b040")]
        public string KeyNames { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum KeyNamesEnum { KeyNames, b040 }
        [XmlIgnore, DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public KeyNamesEnum KeyNamesChoice
        {
            get { return SerializationSettings.UseShortTags ? KeyNamesEnum.b040 : KeyNamesEnum.KeyNames; }
            set { }
        }

        /// <summary>
        /// The fifth part of a structured name of a person who contributed to the creation of the product:
        /// name suffix, or name(s) following a person’s key name(s), eg ‘Ibrahim’ (in Anwar Ibrahim).
        /// Optional and non-repeating.
        /// </summary>
        [XmlChoiceIdentifier("NamesAfterKeyChoice")]
        [XmlElement("NamesAfterKey")]
        [XmlElement("b041")]
        public string NamesAfterKey { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum NamesAfterKeyEnum { NamesAfterKey, b041 }
        [XmlIgnore, DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public NamesAfterKeyEnum NamesAfterKeyChoice
        {
            get { return SerializationSettings.UseShortTags ? NamesAfterKeyEnum.b041 : NamesAfterKeyEnum.NamesAfterKey; }
            set { }
        }

        /// <summary>
        /// The sixth part of a structured name of a person who contributed to the creation of the product:
        /// a suffix following a person’s key name(s), eg ‘Jr’ or ‘III’.
        /// Optional and non-repeating.
        /// </summary>
        [XmlChoiceIdentifier("SuffixToKeyChoice")]
        [XmlElement("SuffixToKey")]
        [XmlElement("b248")]
        public string SuffixToKey { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum SuffixToKeyEnum { SuffixToKey, b248 }
        [XmlIgnore, DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public SuffixToKeyEnum SuffixToKeyChoice
        {
            get { return SerializationSettings.UseShortTags ? SuffixToKeyEnum.b248 : SuffixToKeyEnum.SuffixToKey; }
            set { }
        }

        /// <summary>
        /// The seventh part of a structured name of a person who contributed to the creation of the product:
        /// qualifications and honors following a person’s names, eg ‘CBE FRS’.
        /// Optional and non-repeating.
        /// </summary>
        [XmlChoiceIdentifier("LettersAfterNamesChoice")]
        [XmlElement("LettersAfterNames")]
        [XmlElement("b042")]
        public string LettersAfterNames { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum LettersAfterNamesEnum { LettersAfterNames, b042 }
        [XmlIgnore, DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public LettersAfterNamesEnum LettersAfterNamesChoice
        {
            get { return SerializationSettings.UseShortTags ? LettersAfterNamesEnum.b042 : LettersAfterNamesEnum.LettersAfterNames; }
            set { }
        }

        /// <summary>
        /// The eighth part of a structured name of a person who contributed to the creation of the product:
        /// titles following a person’s names, eg ‘Duke of Edinburgh’.
        /// Optional and non-repeating.
        /// </summary>
        [XmlChoiceIdentifier("TitlesAfterNamesChoice")]
        [XmlElement("TitlesAfterNames")]
        [XmlElement("b043")]
        public string TitlesAfterNames { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum TitlesAfterNamesEnum { TitlesAfterNames, b043 }
        [XmlIgnore, DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public TitlesAfterNamesEnum TitlesAfterNamesChoice
        {
            get { return SerializationSettings.UseShortTags ? TitlesAfterNamesEnum.b043 : TitlesAfterNamesEnum.TitlesAfterNames; }
            set { }
        }

        /// <summary>
        /// An optional ONIX code specifying the gender of a personal contributor.
        /// Not repeatable.
        /// Note that this indicates the gender of the contributor’s public identity (which may be pseudonymous) based on designations used in ISO 5218, rather than the gender identity, biological sex or sexuality of a natural person.
        /// </summary>
        /// <remarks>Onix List 229</remarks>
        [XmlChoiceIdentifier("GenderChoice")]
        [XmlElement("Gender")]
        [XmlElement("x524")]
        public string Gender { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum GenderEnum { Gender, x524 }
        [XmlIgnore, DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public GenderEnum GenderChoice
        {
            get { return SerializationSettings.UseShortTags ? GenderEnum.x524 : GenderEnum.Gender; }
            set { }
        }

        /// <summary>
        /// The name of a corporate body which contributed to the creation of the product, unstructured.
        /// Optional and non-repeating.
        /// </summary>
        [XmlChoiceIdentifier("CorporateNameChoice")]
        [XmlElement("CorporateName")]
        [XmlElement("b047")]
        public string CorporateName { get; set; }
        [XmlIgnore, DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public CorporateNameEnum CorporateNameChoice
        {
            get { return SerializationSettings.UseShortTags ? CorporateNameEnum.b047 : CorporateNameEnum.CorporateName; }
            set { }
        }

        /// <summary>
        /// The name of a corporate body which contributed to the creation of the product, presented in inverted order, with the element used for alphabetical sorting placed first.
        /// Optional and non-repeating.
        /// </summary>
        [XmlChoiceIdentifier("CorporateNameInvertedChoice")]
        [XmlElement("CorporateNameInverted")]
        [XmlElement("x443")]
        public string CorporateNameInverted { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum CorporateNameInvertedEnum { CorporateNameInverted, x443 }
        [XmlIgnore, DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public CorporateNameInvertedEnum CorporateNameInvertedChoice
        {
            get { return SerializationSettings.UseShortTags ? CorporateNameInvertedEnum.x443 : CorporateNameInvertedEnum.CorporateNameInverted; }
            set { }
        }

        /// <summary>
        /// An ONIX code allowing a positive indication to be given when authorship is unknown or anonymous, or when as a matter of editorial policy only a limited number of contributors are named.
        /// Optional and non-repeating.
        /// </summary>
        /// <remarks>Onix List 19</remarks>
        [XmlChoiceIdentifier("UnnamedPersonsChoice")]
        [XmlElement("UnnamedPersons")]
        [XmlElement("b249")]
        public string UnnamedPersons { get; set; }
        [XmlType(IncludeInSchema = false)]
        public enum UnnamedPersonsEnum { UnnamedPersons, b249 }
        [XmlIgnore, DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public UnnamedPersonsEnum UnnamedPersonsChoice
        {
            get { return SerializationSettings.UseShortTags ? UnnamedPersonsEnum.b249 : UnnamedPersonsEnum.UnnamedPersons; }
            set { }
        }

        #endregion

        #region Support Methods

        private void DetermineContribFields()
        {
            StringBuilder KeyNamePrefixBuilder = new StringBuilder();
            StringBuilder KeyNameBuilder = new StringBuilder();
            StringBuilder LettersTitlesBuilder = new StringBuilder();

            if (!string.IsNullOrEmpty(this.KeyNames))
            {
                KeyNameBuilder.Append(this.KeyNames);

                if (!string.IsNullOrEmpty(this.NamesBeforeKey))
                    KeyNamePrefixBuilder.Append(this.NamesBeforeKey);
            }
            else if (!string.IsNullOrEmpty(this.PersonNameInverted))
            {
                string[] NameComponents = this.PersonNameInverted.Split(new char[1] { ',' });

                if (NameComponents.Length > 0)
                {
                    KeyNameBuilder.Append(NameComponents[0]);

                    if (NameComponents.Length > 1)
                    {
                        string sKeynamePrefixBuffer = NameComponents[1];

                        string[] AltNameComponents = sKeynamePrefixBuffer.Split(new char[1] { ' ' });

                        for (int i = 0; i < AltNameComponents.Length; ++i)
                        {
                            if (KeyNamePrefixBuilder.Length > 0)
                                KeyNamePrefixBuilder.Append(" ");

                            KeyNamePrefixBuilder.Append(AltNameComponents[i]);
                        }
                    }
                }
            }
            else if (!string.IsNullOrEmpty(this.PersonName))
            {
                string[] NameComponents = this.PersonName.Split(new char[1] { ' ' });

                if (NameComponents.Length == 1)
                    KeyNameBuilder.Append(NameComponents[NameComponents.Length - 1]);
                else if (NameComponents.Length > 1)
                {
                    bool bLongSuffix = false;
                    bool bExtraLongSuffix = false;
                    string sPossibleSuffix = "";

                    if (NameComponents.Length > 4)
                    {
                        sPossibleSuffix = NameComponents[NameComponents.Length - 3] + " " + NameComponents[NameComponents.Length - 2] + " " + NameComponents[NameComponents.Length - 1];
                        bExtraLongSuffix = true;
                    }
                    else if (NameComponents.Length > 3)
                    {
                        sPossibleSuffix = NameComponents[NameComponents.Length - 2] + " " + NameComponents[NameComponents.Length - 1];
                        bLongSuffix = true;
                    }
                    else
                    {
                        sPossibleSuffix = NameComponents[NameComponents.Length - 1];
                        bLongSuffix = bExtraLongSuffix = false;
                    }

                    int nKeyNameIndex = (NameComponents.Length - 1);
                    if (WithinAllowedSuffixDomain(sPossibleSuffix))
                    {
                        LettersTitlesBuilder.Append(sPossibleSuffix);

                        if (bExtraLongSuffix)
                            nKeyNameIndex = (NameComponents.Length - 4);
                        else if (bLongSuffix)
                            nKeyNameIndex = (NameComponents.Length - 3);
                        else
                            nKeyNameIndex = (NameComponents.Length - 2);
                    }

                    KeyNameBuilder.Append(NameComponents[nKeyNameIndex]);

                    for (int i = 0; i < nKeyNameIndex; ++i)
                    {
                        if (KeyNamePrefixBuilder.Length > 0)
                            KeyNamePrefixBuilder.Append(" ");

                        KeyNamePrefixBuilder.Append(NameComponents[i]);
                    }
                }
            }
            else if (!string.IsNullOrEmpty(this.CorporateName))
            {
                KeyNameBuilder.Append(CorporateName);
            }

            if (!string.IsNullOrEmpty(LettersAfterNames))
            {
                LettersTitlesBuilder.Clear();
                LettersTitlesBuilder.Append(LettersAfterNames);
            }

            if (!string.IsNullOrEmpty(TitlesAfterNames))
            {
                if (LettersTitlesBuilder.Length > 0)
                    LettersTitlesBuilder.Append(" ");

                LettersTitlesBuilder.Append(TitlesAfterNames);
            }

            if (!string.IsNullOrEmpty(PrefixToKey))
                KeyNamePrefixBuilder.Append(" " + PrefixToKey);

            if (!string.IsNullOrEmpty(SuffixToKey))
                LettersTitlesBuilder.Insert(0, SuffixToKey + " ");

            onixNamesBeforeKey = KeyNamePrefixBuilder.ToString().Trim();
            onixKeyNames = KeyNameBuilder.ToString().Trim();
            onixLettersAndTitles = LettersTitlesBuilder.ToString().Trim();
        }

        public static bool WithinAllowedSuffixDomain(string psTestSuffix, bool pbTryFilteredVersion = true)
        {
            bool bSuffixMatch = false;

            if (!string.IsNullOrEmpty(psTestSuffix))
            {
                bSuffixMatch = CONST_ALL_ALLOWED_SUFFIX_LIST.Contains(psTestSuffix);

                if (!bSuffixMatch && pbTryFilteredVersion)
                {
                    string psFilteredSuffix = psTestSuffix.Replace(".", "").Replace(" ", "").ToUpper();

                    bSuffixMatch = CONST_ALL_ALLOWED_FILTERED_SUFFIX_LIST.Contains(psFilteredSuffix);
                }
            }

            return bSuffixMatch;
        }

        #endregion
    }
}
