namespace LoadBalancer.LoadBalancer;

public class LoadBalancer : ILoadBalancer
{
   
    private readonly SortedDictionary<string,int> _services;
    private ILoadBalancerStrategy _currentStrategy;
    private readonly object _servicesLockObject = new object();
    public LoadBalancer(ILoadBalancerStrategy strategy)
    {
        _services = new SortedDictionary<string,int>();
        _currentStrategy = strategy;
    }

    public List<string> GetAllServices()
    {
        lock (_servicesLockObject)
        {
            return _services.Keys.ToList();
        }
    }

    public int AddService(string serviceName)
    {
        lock (_servicesLockObject)
        {
            _services.Add(serviceName, 0);
            return _services.Count;
        }
    }

    public string RemoveService(string serviceName)
    {
        lock (_servicesLockObject)
        {
            _services.Remove(serviceName);
            return serviceName;
        }
    }
    
    public string SetService(string serviceName, int numberOfConnections)
    {
        lock (_servicesLockObject)
        {
            _services[serviceName] = numberOfConnections;
            return serviceName;
        }
    
    }

    public ILoadBalancerStrategy GetActiveStrategy()
    {
        return _currentStrategy;
    }

    public void SetActiveStrategy(ILoadBalancerStrategy strategy)
    {
        _currentStrategy = strategy;
    }

    public string NextService()
    {
        lock (_servicesLockObject)
        {
            return _currentStrategy.NextService(_services);
        }
    }
}