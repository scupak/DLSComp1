namespace LoadBalancer.LoadBalancer;

public interface ILoadBalancer
{
    public List<string> GetAllServices();
    public int AddService(string serviceName);
    public string RemoveService(string serviceName);
    public string SetService(string serviceName, int numberOfConnections);
    public ILoadBalancerStrategy GetActiveStrategy();
    public void SetActiveStrategy(ILoadBalancerStrategy strategy);
    public string NextService();
}