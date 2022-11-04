using StoresAPI.CSharpBase.Repositories;
using StoresAPI.CSharpBase.Routes;
using StoresAPI.CSharpBase.StoresContexto;

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

app.AddBranchesRoutes().AddCountriesRoutes().AddReportsRoutes();

app.Run();
