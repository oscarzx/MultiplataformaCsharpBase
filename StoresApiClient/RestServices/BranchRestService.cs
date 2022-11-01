using StoreDTOs;
using StoresApiClient.RestServices.Base;

namespace StoresApiClient.RestServices;

public class BranchRestService : GenericRestClient<BranchDTO, BranchDTO>
{
    public BranchRestService(HttpClient httpClient)
        : base(httpClient)
    {

    }
}
