namespace StoresAPI.CSharpBase.Routes;

public static class CountriesRoutes
{
    public static IEndpointRouteBuilder AddCountriesRoutes(this IEndpointRouteBuilder app)
    {
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

        app.MapPost("/countries", async (CountriesRepository countriesRepository, dtos.CountryDTO country) =>
        {
            var newCountry = await countriesRepository.PostAsync(new(country.CountryId, country.Name, country.CountryCode));
            return Results.Ok(new dtos.CountryDTO(newCountry.CountryId, newCountry.Name, newCountry.CountryCode));
        }).WithTags("Posts");


        return app;
    }
}
