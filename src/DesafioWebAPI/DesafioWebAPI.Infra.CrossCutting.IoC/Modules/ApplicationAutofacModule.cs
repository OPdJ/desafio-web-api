using Autofac;
using DesafioWebAPI.Application.Interfaces.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesafioWebAPI.Infra.CrossCutting.IoC.Modules
{
    public class ApplicationAutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(typeof(IAppService<>).Assembly)
               .Where(a => a.Name.EndsWith("AppService"))
               .AsImplementedInterfaces()
               .InstancePerLifetimeScope();

            base.Load(builder);
        }
    }
}
