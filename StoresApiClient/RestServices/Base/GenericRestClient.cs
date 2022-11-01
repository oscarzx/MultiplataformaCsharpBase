using StoresApiClient.Interfaces;
using System;

namespace StoresApiClient.RestServices.Base;

public class GenericRestClient<T, U> : BaseRestService, IRestService<T, U>
    where U : class where T : class
{
    public GenericRestClient(HttpClient httpClient)
        : base(httpClient)
    {

    }

    public async Task<IRestResponse<U>> Get(int id, string uri = "")
        => await SendRequest<U, U>(HttpMethod.Get, uri: $"{uri}/{id}");

    public async Task<IRestResponse<IEnumerable<U>>> GetAll(string uri = "")
        => await SendRequest<U, IEnumerable<U>>(HttpMethod.Get, uri: $"{uri}");

    public async Task<IRestResponse<U>> Post(T content, string uri = "")
        => await SendRequest<T, U>(HttpMethod.Post, content, $"{uri}");
}
