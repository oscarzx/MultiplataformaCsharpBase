namespace StoresAPI.CSharpBase.Routes;

public static class ReportsRoutes
{
    public static IEndpointRouteBuilder AddReportsRoutes(this IEndpointRouteBuilder app)
    {
        app.MapGet("/reports", async (ReportsRepository reportsRepository) =>
        {
            var reports = await reportsRepository.GetAllAsync();
            List<dtos.ReportDTO> result = new();

            foreach (var report in reports)
                result.Add(new dtos.ReportDTO(report.ReportId,
                report.ReportDate,
                report.Photo1,
                report.Photo2,
                report.Photo3,
                report.Photo4,
                report.ClientNumber,
                report.ClientName,
                report.ClientEmail,
                report.ClientPhoneNumber,
                report.ClientCountryCode,
                report.ClientCity,
                report.ClientDocument,
                report.ClientDocumentNumber,
                report.ReportDescription,
                report.Amount));
            return result;

        }).WithTags("Gets");

        app.MapPost("/reports", async (ReportsRepository reportsRepository, dtos.ReportDTO report) =>
        {
            var newReport = await reportsRepository.PostAsync(new Report(report.ReportId,
                report.ReportDate,
                report.Photo1,
                report.Photo2,
                report.Photo3,
                report.Photo4,
                report.ClientNumber,
                report.ClientName,
                report.ClientEmail,
                report.ClientPhoneNumber,
                report.ClientCountryCode,
                report.ClientCity,
                report.ClientDocument,
                report.ClientDocumentNumber,
                report.ReportDescription,
                report.Amount));

            dtos.ReportDTO result = new(newReport.ReportId,
                newReport.ReportDate,
                newReport.Photo1,
                newReport.Photo2,
                newReport.Photo3,
                newReport.Photo4,
                newReport.ClientNumber,
                newReport.ClientName,
                newReport.ClientEmail,
                newReport.ClientPhoneNumber,
                newReport.ClientCountryCode,
                newReport.ClientCity,
                newReport.ClientDocument,
                newReport.ClientDocumentNumber,
                newReport.ReportDescription,
                newReport.Amount);
            return Results.Ok(newReport);
        }).WithTags("Posts");

        return app;
    }
}