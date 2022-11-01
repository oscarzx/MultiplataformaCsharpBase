using StoreDTOs;
using StoresApiClient.RestServices.Base;

namespace StoresApiClient.RestServices;

public class CountryRestService : GenericRestClient<CountryDTO, CountryDTO>
{
    public CountryRestService(HttpClient httpClient)
        : base(httpClient)
    {

    }
}
