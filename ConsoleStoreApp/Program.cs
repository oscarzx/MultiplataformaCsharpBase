// See https://aka.ms/new-console-template for more information
using StoresApiClient.RestServices;

Console.WriteLine("Hello, World!");

HttpClient branchHttpClient = new() { BaseAddress = new("https://localhost:7043/branches") };

BranchRestService branchRestService = new(branchHttpClient);

var branchResponse = await branchRestService.GetAll();

if(branchResponse.ResponseStatus == StoresApiClient.Enums.ResponseStatus.Success)
{
	foreach (var branch in branchResponse.Response)
	{
		Console.WriteLine(branch);
	}
}

var newBranch = branchResponse.Response.Last() with { BranchId = 7 };

var newBranchResponse = await branchRestService.Post(newBranch);

if(newBranchResponse.ResponseStatus == StoresApiClient.Enums.ResponseStatus.Success)
	Console.WriteLine(newBranchResponse.Response);