using AutoMapper;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using Domain.Services;
using Infrastructure.Persist.AutoMapper;
using Infrastructure.Persist.Repositories;
using Unity;
using Unity.Lifetime;

namespace IoC.Unity
{
    public static class DependencyResolver
    {
        public static void Resolve(UnityContainer container)
        {
            Configuration(container);
            Services(container);
            Repositories(container);
        }

        public static void Configuration(UnityContainer container)
        {
            var mapper = AutoMapperConfig.Configure();
            container.RegisterInstance<IMapper>(mapper);
        }


        public static void Services(UnityContainer container)
        {
            container.RegisterType<ICustomerService, CustomerService>(new HierarchicalLifetimeManager());
        }

        public static void Repositories(UnityContainer container)
        {
            container.RegisterType(typeof(IBaseRepository<,>), typeof(BaseRepository<,>));
            container.RegisterType<ICustomerRepository, CustomerRepository>(new HierarchicalLifetimeManager());
        }
    }
}