namespace StoreDTOs;

public record BranchDTO(int BranchId, string Name, string Location);
public record NewBranch(string Name, string Location);
public record CountryDTO(int CountryId, string Name, string CountryCode);
public record NewCountry(string Name, string CountryCode);
public record ReportDTO(string ReportId,
    DateTime? ReportDate,
    string? Photo1,
    string? Photo2,
    string? Photo3,
    string? Photo4,
    string? ClientNumber,
    string? ClientName,
    string? ClientEmail,
    string? ClientPhoneNumber,
    string? ClientCountryCode,
    string? ClientCity,
    string? ClientDocument,
    string? ClientDocumentNumber,
    string? ReportDescription,
    decimal? Amount);