using System;
using System.Collections.Generic;

namespace StoresAPI.CSharpBase.StoresContexto
{
    public partial class Report
    {
        public string ReportId { get; set; } = null!;
        public DateTime? ReportDate { get; set; }
        public string? Photo1 { get; set; }
        public string? Photo2 { get; set; }
        public string? Photo3 { get; set; }
        public string? Photo4 { get; set; }
        public string? ClientNumber { get; set; }
        public string? ClientName { get; set; }
        public string? ClientEmail { get; set; }
        public string? ClientPhoneNumber { get; set; }
        public string? ClientCountryCode { get; set; }
        public string? ClientCity { get; set; }
        public string? ClientDocument { get; set; }
        public string? ClientDocumentNumber { get; set; }
        public string? ReportDescription { get; set; }
        public decimal? Amount { get; set; }

        public Report()
        {

        }

        public Report(string reportId, DateTime? reportDate, string? photo1, string? photo2, string? photo3, string? photo4, string? clientNumber, string? clientName, string? clientEmail, string? clientPhoneNumber, string? clientCountryCode, string? clientCity, string? clientDocument, string? clientDocumentNumber, string? reportDescription, decimal? amount)
        {
            ReportId = reportId;
            ReportDate = reportDate;
            Photo1 = photo1;
            Photo2 = photo2;
            Photo3 = photo3;
            Photo4 = photo4;
            ClientNumber = clientNumber;
            ClientName = clientName;
            ClientEmail = clientEmail;
            ClientPhoneNumber = clientPhoneNumber;
            ClientCountryCode = clientCountryCode;
            ClientCity = clientCity;
            ClientDocument = clientDocument;
            ClientDocumentNumber = clientDocumentNumber;
            ReportDescription = reportDescription;
            Amount = amount;
        }
    }
}
