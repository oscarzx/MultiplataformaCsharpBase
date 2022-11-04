namespace StoresAPI.CSharpBase.Routes;

public static class BranchesRoutes
{
    public static IEndpointRouteBuilder AddBranchesRoutes(this IEndpointRouteBuilder app)
    {
        app.MapGet("/branches", async (BranchesRepository branchesRepository) =>
        {
            var branches = await branchesRepository.GetAllAsync();
            List<dtos.BranchDTO> result = new();

            foreach (var branch in branches)
                result.Add(new(branch.BranchId, branch.Name, branch.Location));
            return result;

        }).WithTags("Gets");

        app.MapPost("/branches", async (BranchesRepository branchesRepository, dtos.BranchDTO branch) =>
        {
            var newBranch = await branchesRepository.PostAsync(new(branch.BranchId, branch.Name, branch.Location));
            return Results.Ok(new dtos.BranchDTO(newBranch.BranchId, newBranch.Name, newBranch.Location));
        }).WithTags("Posts");

        return app;
    }
}
