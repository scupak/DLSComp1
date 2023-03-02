namespace LoadBalancer.LoadBalancer;

public class LoadBalancer : ILoadBalancer
{
    public List<string> GetAllServices()
    {
        throw new NotImplementedException();
    }

    public int AddService(string url)
    {
        throw new NotImplementedException();
    }

    public int RemoveService(int id)
    {
        throw new NotImplementedException();
    }

    public ILoadBalancerStrategy GetActiveStrategy()
    {
        throw new NotImplementedException();
    }

    public void SetActiveStrategy(ILoadBalancerStrategy strategy)
    {
        throw new NotImplementedException();
    }

    public string NextService()
    {
        throw new NotImplementedException();
    }
}