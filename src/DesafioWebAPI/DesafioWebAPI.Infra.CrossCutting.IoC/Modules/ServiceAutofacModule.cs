using Autofac;
using DesafioWebAPI.Domain.Services.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesafioWebAPI.Infra.CrossCutting.IoC.Modules
{
    public class ServiceAutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(typeof(Service<>).Assembly)
               .Where(a => a.Name.EndsWith("Service"))
               .AsImplementedInterfaces()
               .InstancePerLifetimeScope();

            base.Load(builder);
        }
    }
}
