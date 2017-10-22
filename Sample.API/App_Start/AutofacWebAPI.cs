using Autofac;
using Autofac.Integration.WebApi;
using Sample.Domain.Abstract;
using Sample.Domain.Entities;
using Sample.Infrastructure;
using System.Data.Entity;
using System.Reflection;
using System.Web.Http;

namespace Sample.API
{
    public class AutofacWebAPI
    {
        public static void Initialize(HttpConfiguration config)
        {
            Initialize(config, RegisterServices(new ContainerBuilder()));
        }

        public static void Initialize(HttpConfiguration config, IContainer container)
        {
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }

        private static IContainer RegisterServices(ContainerBuilder builder)
        {
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            // Services
            builder.RegisterType<SampleDataService>()
                .As<ISampleDataService>()
                .InstancePerRequest();

            //EF DbContext
            builder.RegisterType<EntitiesContext>()
                .As<DbContext>()
                .InstancePerRequest();

            // Register repositories by using Autofac's OpenGenerics feature
            builder.RegisterGeneric(typeof(EntityRepository<>))
                .As(typeof(IEntityRepository<>))
                .InstancePerRequest();

            return builder.Build();
        }
    }
}