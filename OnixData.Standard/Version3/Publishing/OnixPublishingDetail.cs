using System;
using System.Collections.Generic;
using System.Linq;
using OnixData.Version3.Lists;

namespace OnixData.Version3.Publishing
{
    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class OnixPublishingDetail
    {
        public OnixPublishingDetail()
        {
            PublishingStatus = "";

            Imprint        = new OnixImprint[0];
            Publisher      = new OnixPublisher[0];
            PublishingDate = new OnixPubDate[0];
            SalesRights    = new OnixSalesRights[0];

            salesRightsList = null;
            notForSaleList  = null;

            SalesRightsInUSFlag        = SalesRightsInNonUSCountryFlag = false;
            NoSalesRightsInUSFlag      = SalesRightsAllWorldFlag       = false;
        }

        public bool SalesRightsInUSFlag { get; set; }
        public bool SalesRightsInNonUSCountryFlag { get; set; }
        public bool NoSalesRightsInUSFlag { get; set; }
        public bool SalesRightsAllWorldFlag { get; set; }

        private string pubStatusField;

        private OnixImprint[]   imprintField;
        private OnixImprint[]   shortImprintField;

        private OnixPubDate[]   pubDateField;
        private OnixPubDate[]   shortPubDateField;

        private OnixPublisher[] publisherField;
        private OnixPublisher[] shortPublisherField;

        private OnixSalesRights[] salesRightsField;
        private OnixSalesRights[] shortSalesRightsField;

        private List<string> salesRightsList;
        private List<string> notForSaleList;

        private OnixList46? rowSalesRightsTypeField;
        private string countryOfPublicationField;

        #region ONIX Lists

        public OnixImprint[] OnixImprintList
        {
            get
            {
                OnixImprint[] Imprints = null;

                if (this.imprintField != null)
                    Imprints = this.imprintField;
                else if (this.shortImprintField != null)
                    Imprints = this.shortImprintField;
                else
                    Imprints = new OnixImprint[0];

                return Imprints;
            }
        }

        public OnixPublisher[] OnixPublisherList
        {
            get
            {
                OnixPublisher[] Publishers = null;

                if (this.publisherField != null)
                    Publishers = this.publisherField;
                else if (this.shortPublisherField != null)
                    Publishers = this.shortPublisherField;
                else
                    Publishers = new OnixPublisher[0];

                return Publishers;
            }
        }

        public OnixPubDate[] OnixPublishingDateList
        {
            get
            {
                OnixPubDate[] PubDates = null;

                if (this.pubDateField != null)
                    PubDates = this.pubDateField;
                else if (this.shortPubDateField != null)
                    PubDates = this.shortPubDateField;
                else
                    PubDates = new OnixPubDate[0];

                return PubDates;
            }
        }

        public OnixSalesRights[] OnixSalesRightsList
        {
            get
            {
                OnixSalesRights[] SalesRights = null;

                if (this.salesRightsField != null)
                    SalesRights = this.salesRightsField;
                else if (this.shortSalesRightsField != null)
                    SalesRights = this.shortSalesRightsField;
                else
                    SalesRights = new OnixSalesRights[0];

                if (SalesRights != null)
                {
                    if (salesRightsList == null)
                    {
                        salesRightsList = new List<string>();

                        SalesRights.Where(x => x.HasSalesRights)
                                   .ToList()
                                   .Where(x => !String.IsNullOrEmpty(x.Territory.CountriesIncluded))
                                   .ToList()
                                   .ForEach(x => salesRightsList.AddRange(x.Territory.CountriesIncluded.Split(' ').ToList()));

                        SalesRights.Where(x => x.HasSalesRights)
                                   .ToList()
                                   .Where(x => !String.IsNullOrEmpty(x.Territory.RegionsIncluded))
                                   .ToList()
                                   .ForEach(x => salesRightsList.AddRange(x.Territory.RegionsIncluded.Split(' ').ToList()));
                    }

                    if (notForSaleList == null)
                    {
                        notForSaleList = new List<string>();

                        SalesRights.Where(x => x.HasNotForSalesRights)
                                   .ToList()
                                   .Where(x => !String.IsNullOrEmpty(x.Territory.CountriesIncluded))
                                   .ToList()
                                   .ForEach(x => notForSaleList.AddRange(x.Territory.CountriesIncluded.Split(' ').ToList()));

                        SalesRights.Where(x => x.HasNotForSalesRights)
                                   .ToList()
                                   .Where(x => !String.IsNullOrEmpty(x.Territory.RegionsIncluded))
                                   .ToList()
                                   .ForEach(x => notForSaleList.AddRange(x.Territory.RegionsIncluded.Split(' ').ToList()));
                    }
                }

                return SalesRights;
            }
        }

        #endregion

        #region Helper Methods

        public List<string> ForSaleRightsList
        {
            get { return salesRightsList; }
        }

        public List<string> NotForSaleRightsList
        {
            get { return notForSaleList; }
        }

        public string OnSaleDate
        {
            get
            {
                OnixPubDate[] DateList = this.OnixPublishingDateList;

                string sOnSaleDate = "";

                if ((DateList != null) && (DateList.Length > 0))
                {
                    OnixPubDate FoundOnSaleDate =
                        DateList.Where(x => x.PublishingDateRole == OnixList163.SalesEmbargoDate).LastOrDefault();

                    if ((FoundOnSaleDate != null) && !string.IsNullOrEmpty(FoundOnSaleDate.Date.Value))
                        sOnSaleDate = FoundOnSaleDate.Date.ReadableDate;
                }

                return sOnSaleDate;
            }
        }

        public string PublicationDate
        {
            get
            {
                OnixPubDate[] PubDtList = this.OnixPublishingDateList;

                string sPubDate = "";

                if ((PubDtList != null) && (PubDtList.Length > 0))
                {
                    OnixPubDate FoundPubDate =
                        PubDtList
                        .Where(x => (x.PublishingDateRole == OnixList163.PublicationDate) || (x.PublishingDateRole == OnixList163.PublicationDateOfPrintCounterpart))
                        .LastOrDefault();

                    if ((FoundPubDate != null) && !string.IsNullOrEmpty(FoundPubDate.Date.Value))
                        sPubDate = FoundPubDate.Date.ReadableDate;
                }

                return sPubDate;
            }
        }

        public void SetRightsFlags()
        {
            OnixList46[] aSalesRightsColl    = OnixSalesRights.SALES_WITH_RIGHTS_COLL;
            OnixList46[] aNonSalesRightsColl = OnixSalesRights.NO_SALES_RIGHTS_COLL;

            OnixSalesRights[] SalesRightsList = 
                this.OnixSalesRightsList.Where(x => aSalesRightsColl.Contains(x.SalesRightsType)).ToArray();

            OnixSalesRights[] NotForSaleRightsList = 
                this.OnixSalesRightsList.Where(x => aNonSalesRightsColl.Contains(x.SalesRightsType)).ToArray();

            if ((SalesRightsList != null) && (SalesRightsList.Length > 0))
            {
                SalesRightsInUSFlag =
                    Array.Exists(SalesRightsList, x => aSalesRightsColl.Contains(x.SalesRightsType) && (x.RightsIncludedCountryList.Contains("US")));

                SalesRightsInNonUSCountryFlag =
                    Array.Exists(SalesRightsList, x => aSalesRightsColl.Contains(x.SalesRightsType) &&
                                             !x.RightsIncludedCountryList.Contains("US")    &&
                                             !x.RightsIncludedRegionList.Contains("WORLD")  &&
                                             !x.RightsIncludedRegionList.Contains("ROW"));

                NoSalesRightsInUSFlag =
                    Array.Exists(SalesRightsList, x => aNonSalesRightsColl.Contains(x.SalesRightsType) && x.RightsIncludedCountryList.Contains("US"));
                if (!NoSalesRightsInUSFlag)
                {
                    NoSalesRightsInUSFlag = 
                        Array.Exists(SalesRightsList, x => aSalesRightsColl.Contains(x.SalesRightsType) &&
                                            x.RightsExcludedCountryList.Contains("US"));
                }

                SalesRightsAllWorldFlag =
                    Array.Exists(SalesRightsList, x => aSalesRightsColl.Contains(x.SalesRightsType) && 
                                             (x.RightsIncludedRegionList.Contains("WORLD") || x.RightsIncludedRegionList.Contains("ROW")));
            }

            if ((NotForSaleRightsList != null) && (NotForSaleRightsList.Length > 0))
            {
                if (!NoSalesRightsInUSFlag)
                {
                    NoSalesRightsInUSFlag =
                        Array.Exists(NotForSaleRightsList, x => x.RightsIncludedCountryList.Contains("US"));
                }
            }

            if (ROWSalesRightsType != null)
            {
                if (!SalesRightsAllWorldFlag)
                {
                    SalesRightsAllWorldFlag =
                        OnixSalesRights.SALES_WITH_RIGHTS_COLL.Contains(ROWSalesRightsType.Value);
                }
            }
        }

        #endregion

        #region Reference Tags

        /// <remarks/>
        public string PublishingStatus
        {
            get { return this.pubStatusField; }
            set { this.pubStatusField = value; }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Imprint")]
        public OnixImprint[] Imprint
        {
            get { return this.imprintField; }
            set { this.imprintField = value; }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Publisher")]
        public OnixPublisher[] Publisher
        {
            get { return this.publisherField; }
            set { this.publisherField = value; }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("PublishingDate")]
        public OnixPubDate[] PublishingDate
        {
            get { return this.pubDateField; }
            set { this.pubDateField = value; }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("SalesRights")]
        public OnixSalesRights[] SalesRights
        {
            get { return this.salesRightsField; }
            set { this.salesRightsField = value; }
        }

        public OnixList46? ROWSalesRightsType
        {
            get { return this.rowSalesRightsTypeField; }
            set { this.rowSalesRightsTypeField = value; }
        }
        
        public string CountryOfPublication
        {
            get { return this.countryOfPublicationField; }
            set { this.countryOfPublicationField = value; }
        }

        #endregion

        #region Short Tags

        /// <remarks/>
        public string b394
        {
            get { return this.PublishingStatus; }
            set { this.PublishingStatus = value; }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("imprint")]
        public OnixImprint[] imprint
        {
            get { return this.shortImprintField; }
            set { this.shortImprintField = value; }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("publisher")]
        public OnixPublisher[] publisher
        {
            get { return this.shortPublisherField; }
            set { this.shortPublisherField = value; }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("publishingdate")]
        public OnixPubDate[] publishingdate
        {
            get { return this.shortPubDateField; }
            set { this.shortPubDateField = value; }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("salesrights")]
        public OnixSalesRights[] salesrights
        {
            get { return this.shortSalesRightsField; }
            set { this.shortSalesRightsField = value; }
        }

        public OnixList46? x456
        {
            get { return this.ROWSalesRightsType; }
            set { this.ROWSalesRightsType = value; }
        }
        
        public string b083
        {
            get { return this.CountryOfPublication; }
            set { this.CountryOfPublication = value; }
        }

        #endregion
    }

}
