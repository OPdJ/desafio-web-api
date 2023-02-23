using Autofac;
using DesafioWebAPI.Infra.Data.Context;
using DesafioWebAPI.Infra.Data.Context.Interfaces;
using DesafioWebAPI.Infra.Data.Repository.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesafioWebAPI.Infra.CrossCutting.IoC.Modules
{
    public class RepositoryAutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(typeof(Repository<>).Assembly)
                .Where(a => a.Name.EndsWith("Repository"))
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>()
                .InstancePerLifetimeScope();

            base.Load(builder);
        }
    }
}
