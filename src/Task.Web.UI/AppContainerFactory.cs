using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Task.Web.UI
{
    public static class AppContainerFactory
    {

        public static ContainerBuilder RepositoryRegister(this ContainerBuilder containerBuilder)
        {
            containerBuilder
                .RegisterType<Repository.SQLServer.CustomerRepository>()
                .As<Repository.Infrastructures.ICustomerRepository>();
            containerBuilder.RegisterType<Repository.SQLServer.CarRepository>()
                .As<Repository.Infrastructures.ICarRepository>();
            containerBuilder.RegisterType<Repository.SQLServer.AppointmentRepository>()
                .As<Repository.Infrastructures.IAppointmentRepository>();

            return containerBuilder;
        }
        public static ContainerBuilder ServiceRegister(this ContainerBuilder containerBuilder)
        {
            containerBuilder
                .RegisterType<Core.CustomerService>()
                .As<Core.Infrastructures.ICustomerService>();

            return containerBuilder;
        }
        public static ContainerBuilder ValidatorRegister(this ContainerBuilder containerBuilder)
        {
            containerBuilder
                .RegisterType<Core.Validators.CustomerValidator>()
                .As<Core.Validators.ICustomerValidator>();

            return containerBuilder;
        }

        public static ContainerBuilder ComponentRegister(this ContainerBuilder containerBuilder)
        {
            containerBuilder
                .RegisterType<Core.OutputLogger>()
                .As<Core.Infrastructures.ILogger>();

            return containerBuilder;
        }
    }
}