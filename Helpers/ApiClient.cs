using RestSharp;
using System;
using System.Net;
using Newtonsoft.Json;
using System.Collections.Generic;

public class ApiClient
{
    private readonly RestClient _client;
    private readonly string _authToken;

    public ApiClient(string baseUrl, string token)
    {
        _authToken = token;
        _client = new RestClient(new RestClientOptions(baseUrl));
    }

    public RestResponse SendRequest(string endpoint, Method method, object body = null)
    {
        var request = new RestRequest(endpoint, method);

        // Add headers
        request.AddHeader("Authorization", $"Bearer {_authToken}");
        request.AddHeader("Content-Type", "application/json");

        // Add body if needed
        if (body != null)
        {
            var jsonBody = JsonConvert.SerializeObject(body);
            request.AddStringBody(jsonBody, DataFormat.Json);
        }

        var response = _client.Execute(request);
        return response;
    }

    public T DeserializeResponse<T>(RestResponse response)
    {
        return JsonConvert.DeserializeObject<T>(response.Content);
    }
}
