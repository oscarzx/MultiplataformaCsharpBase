using StoresAPI.CSharpBase.DTOs;
using StoresAPI.CSharpBase.Repositories;
using StoresAPI.CSharpBase.StoresContexto;
using dtos = StoresAPI.CSharpBase.DTOs;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSqlServer<StoresAPI.CSharpBase.StoresContexto.CSharpbaseContext>
    (builder.Configuration.GetConnectionString("StoresContext"));
builder.Services.AddScoped<CountriesRepository>();
builder.Services.AddScoped<BranchesRepository>();
builder.Services.AddScoped<ReportsRepository>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/countries", async (CountriesRepository countriesRepository) => 
{
    var countries = await countriesRepository.GetAllAsync();
    List<dtos.CountryDTO> result = new();

    foreach (var country in countries)
    {
        result.Add(new(country.CountryId, country.Name, country.CountryCode));
    }
    return result;

}).WithTags("Gets");

app.MapGet("/branches", (BranchesRepository branchesRepository) => branchesRepository.GetAllAsync())
    .WithTags("Gets");

app.MapGet("/reports", (ReportsRepository reportsRepository) => reportsRepository.GetAllAsync())
    .WithTags("Gets");

app.MapPost("/countries", async (CountriesRepository countriesRepository, Country country) =>
{
    var newCountry = await countriesRepository.PostAsync(country);
    return Results.Ok(newCountry);
})
    .WithTags("Posts");

app.MapPost("/branches", async (BranchesRepository branchesRepository, Branch branch) =>
{
    var newBranch = await branchesRepository.PostAsync(branch);
    return Results.Ok(new dtos.BranchDTO(newBranch.BranchId, newBranch.Name, newBranch.Location));
})
    .WithTags("Posts");

app.MapPost("/reports", async (ReportsRepository reportsRepository, Report report) =>
{
    var newReport = await reportsRepository.PostAsync(report);
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
})
    .WithTags("Posts");



app.Run();

//internal record WeatherForecast(DateTime Date, int TemperatureC, string? Summary)
//{
//    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
//}