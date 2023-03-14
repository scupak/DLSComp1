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
        client = new RestClient();
    }

    [HttpGet]
    [Route("Search")]
    public async Task<SearchResult> Search(string terms, int numberOfResults)
    {
        throw new NotImplementedException();
    }

    [HttpPost]
    [Route("AddService")]
    public async Task<IActionResult> AddService(string serviceName)
    {
        Console.WriteLine("called loadbalancer add service");
        // Here we want to check if the given service name is correct
        // So we attempt to ping to check the connection

        try
        {
            var request = new RestRequest($"http://{serviceName}/Search/ping");
            var response = await client.GetAsync(request);
            response.ThrowIfError();

            if (response.StatusCode == HttpStatusCode.OK)
            {
                loadBalancer.AddService(serviceName);

                Console.WriteLine($"Succefully connected and added the service with name: {serviceName} to the list");
                Console.WriteLine("Current list of services:");
                foreach (var service in loadBalancer.GetAllServices())
                {
                    Console.WriteLine(service);
                }
                return Ok("Connection succesfully, you have been added to the list of services");
            }
            else
            {
                throw new BadHttpRequestException("Connection Failed");
            }

        }
        catch (Exception ex)
        {
            return BadRequest("Connection Failed");
        }




    }

    [HttpGet]
    [Route("ping")]
    public IActionResult Ping()
    {
        Console.WriteLine("Ping");
        return Ok("ping");
    }



}