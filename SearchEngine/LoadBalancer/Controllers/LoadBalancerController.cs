using Common;
using LoadBalancer.LoadBalancer;
using Microsoft.AspNetCore.Mvc;

namespace LoadBalancer.Controllers;

[ApiController]
[Route("[controller]")]
public class LoadBalancerController : ControllerBase
{
    ILoadBalancer loadBalancer;
    public LoadBalancerController(ILoadBalancer loadBalancer)
    {
        this.loadBalancer = loadBalancer;
    }

    [HttpGet]
    [Route("search")]
    public async Task<SearchResult> Search(string terms, int numberOfResults)
    {
        throw new NotImplementedException();
    }


}