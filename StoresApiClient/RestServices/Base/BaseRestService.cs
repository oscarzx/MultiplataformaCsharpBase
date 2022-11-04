using StoresApiClient.Enums;
using StoresApiClient.Interfaces;
using System;
using System.Text;
using System.Text.Json;

namespace StoresApiClient.RestServices.Base;

public abstract class BaseRestService
{
    private readonly HttpClient _httpClient;

	public BaseRestService(HttpClient httpClient)
	{
		_httpClient = httpClient;
		_httpClient.Timeout = TimeSpan.FromSeconds(40);
	}

	public async Task<IRestResponse<W>> SendRequest<V, W>
		(HttpMethod httpMethod, V content = null!, string uri = "")
		where V : class
		where W : class
	{
		GenericRestResponse<W> genericRestResponse = new()
		{
			ResponseStatus = ResponseStatus.Error,
			ResponseMessage = "UnexpectedError"
		};

		try
		{
			HttpResponseMessage httpResponseMessage = await SendHttpRequest(httpMethod, content, uri);

			if (httpResponseMessage.IsSuccessStatusCode)
			{
				genericRestResponse.ResponseStatus = ResponseStatus.Success;
				genericRestResponse.ResponseMessage = "Success";

				await ParseResponse(genericRestResponse, httpResponseMessage);
			}
			else
			{
				genericRestResponse.ResponseStatus = ResponseStatus.BadRequest;
				genericRestResponse.ResponseMessage = "Error during sending";
			}
		}
		catch(TimeoutException)
		{
            genericRestResponse.ResponseStatus = ResponseStatus.Timeout;
            genericRestResponse.ResponseMessage = "Timeout";
        }
		catch (Exception ex)
		{
            genericRestResponse.ResponseStatus = ResponseStatus.Error;
            genericRestResponse.ResponseMessage = ex.Message;
        }

		return genericRestResponse;
    }

	protected virtual async Task ParseResponse<W>(GenericRestResponse<W> genericRestResponse, 
		HttpResponseMessage httpResponseMessage) 
		where W : class
	{
		if (typeof(W) == typeof(string))
			genericRestResponse.Response = 
				await httpResponseMessage.Content.ReadAsStringAsync() as W;
		else
			genericRestResponse.Response = JsonSerializer.Deserialize<W>(await
				httpResponseMessage.Content.ReadAsStringAsync(), 
				new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
	}

	protected async Task<HttpResponseMessage>SendHttpRequest<V>
		(HttpMethod httpMethod, V content, string uri)
		where V : class
	{
		StringContent stringContent = default;

		if(content is not null)
		{
			string jsonContent = JsonSerializer.Serialize(content);
			stringContent = new StringContent(jsonContent, Encoding.UTF8, "application/json");
		}

		HttpRequestMessage httpRequestMessage = new(httpMethod, uri);
		if (stringContent is not null)
			httpRequestMessage.Content = stringContent;
		return await _httpClient.SendAsync(httpRequestMessage);
	}
}
