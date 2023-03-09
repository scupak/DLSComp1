using LoadBalancer.LoadBalancer;

namespace LoadBalancer.Strategies;

public class RoundRobinStrategy : ILoadBalancerStrategy
{
    public string NextService(SortedDictionary<string, int> services)
    {
        throw new NotImplementedException();
    }
}