namespace StoresApiClient.Interfaces;

public interface IRestService<T, U> where U : class where T : class
{
    Task<IRestResponse<IEnumerable<U>>> GetAll(string uri);
    Task<IRestResponse<U>> Get(int id, string uri);
    Task<IRestResponse<U>> Post(T content, string uri);
}
