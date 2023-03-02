namespace LoadBalancer.LoadBalancer;

public interface ILoadBalancerStrategy
{
    public string NextService(List<string> services);
}