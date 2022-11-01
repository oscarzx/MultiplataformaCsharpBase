using StoreDTOs;
using StoresApiClient.RestServices.Base;

namespace StoresApiClient.RestServices;

public class ReportRestService : GenericRestClient<ReportDTO, ReportDTO>
{
    public ReportRestService(HttpClient httpClient)
        : base(httpClient)
    {

    }
}
