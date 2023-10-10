using Unity;

public class UnityResolver
{
    private readonly IUnityContainer _container;

    public UnityResolver(IUnityContainer container)
    {
        _container = container;
    }

    public T Resolve<T>()
    {
        return _container.Resolve<T>();
    }

    public void RegisterType<TFrom, TTo>() where TTo : TFrom
    {
        _container.RegisterType<TFrom, TTo>();
    }
}
