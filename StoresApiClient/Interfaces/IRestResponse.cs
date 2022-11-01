using StoresApiClient.Enums;
namespace StoresApiClient.Interfaces;

public interface IRestResponse<U> where U : class
{
    ResponseStatus ResponseStatus { get; set; }
    string ResponseMessage { get; set; }
    U Response { get; set; }
}
