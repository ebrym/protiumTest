using Autofac;
using AutoMapper;
using Protium.Data;
using Protium.Data.Entity;
using Protium.Repository.Dto;
using Protium.Repository.Interface;
namespace Protium.Repository.AutofacModule
{
    public class AutofacRepoModule: Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<DataContext>().InstancePerLifetimeScope();

            // register dependency convention
            builder.RegisterAssemblyTypes(typeof(IDependencyRegister).Assembly)
                .AssignableTo<IDependencyRegister>()
                .As<IDependencyRegister>()
                .AsImplementedInterfaces().InstancePerLifetimeScope();

           


            base.Load(builder);
           
        }
    }    
}
