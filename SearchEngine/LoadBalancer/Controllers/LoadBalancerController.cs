using Common;
using LoadBalancer.LoadBalancer;
using Microsoft.AspNetCore.Mvc;
using RestSharp;
using System.Net;

namespace LoadBalancer.Controllers;

[ApiController]
[Route("[controller]")]
public class LoadBalancerController : ControllerBase
{
    private readonly ILoadBalancer loadBalancer;
    public RestClient client;
    public LoadBalancerController(ILoadBalancer loadBalancer)
    {
        this.loadBalancer = loadBalancer;
        client = new RestClient("http://");
    }

    [HttpGet]
    [Route("search")]
    public async Task<SearchResult> Search(string terms, int numberOfResults)
    {
        throw new NotImplementedException();
    }

    [HttpPost]
    [Route("addService")]
    public async Task<IActionResult> AddService(string serviceName)
    {
        // Here we want to check if the given service name is correct
        // So we attempt to ping to check the connection

        try
        {
            var request = new RestRequest($"{serviceName}/ping");
            var response = await client.GetAsync(request);
            response.ThrowIfError();

            if (response.StatusCode == HttpStatusCode.OK)
            {
                loadBalancer.AddService(serviceName);
                return Ok();
            }
            else
            {
                throw new BadHttpRequestException("Connection Failed");
            }

        }
        catch (Exception ex)
        {
            return BadRequest("Could't connect to specified service");
        }
        



    }



}