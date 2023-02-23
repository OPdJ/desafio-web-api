using Autofac;
using DesafioWebAPI.Infra.CrossCutting.IoC.Modules;
using System;

namespace DesafioWebAPI.Infra.CrossCutting.IoC
{
    public class IoC
    {
        public ContainerBuilder ContainerBuilder { get; set; }
        public IoC()
        {
            ContainerBuilder = GetAutofacModules();
        }

        public ContainerBuilder GetAutofacModules()
        {
            var builder = new ContainerBuilder();

            builder.RegisterModule<AutoMapperAutofacModule>();
            builder.RegisterModule<RepositoryAutofacModule>();
            builder.RegisterModule<ApplicationAutofacModule>();
            builder.RegisterModule<ServiceAutofacModule>();

            return builder;
        }
    }
}
