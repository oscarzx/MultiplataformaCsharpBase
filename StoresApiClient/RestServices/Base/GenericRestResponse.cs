using StoresApiClient.Enums;
using StoresApiClient.Interfaces;

namespace StoresApiClient.RestServices.Base;

public class GenericRestResponse<U> : IRestResponse<U> where U : class
{
    public ResponseStatus ResponseStatus { get; set; }
    public string ResponseMessage { get; set; }
    public U Response { get; set; }
}
