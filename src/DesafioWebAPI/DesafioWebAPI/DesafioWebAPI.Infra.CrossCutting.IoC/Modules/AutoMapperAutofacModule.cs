using Autofac;
using AutoMapper;
using DesafioWebAPI.Infra.CrossCutting.MappingConfig.Configs;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesafioWebAPI.Infra.CrossCutting.IoC.Modules
{
    public class AutoMapperAutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(context => new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<AutoMapperConfig>();
            }))
            .AsSelf()
            .SingleInstance();

            builder.Register(c =>
            {
                var context = c.Resolve<IComponentContext>();
                var config = context.Resolve<MapperConfiguration>();
                return config.CreateMapper(context.Resolve);
            })
            .As<IMapper>()
            .InstancePerLifetimeScope();

            base.Load(builder);
        }
    }
}

