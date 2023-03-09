using Common;
using LoadBalancer.LoadBalancer;
using Microsoft.AspNetCore.Mvc;
using RestSharp;

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
    public async void AddService(string serviceName)
    {

    }



}