using System.Configuration;
using Autofac;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using RemoteNotes.BLL.Activities;
using RemoteNotes.BLL.Contract.Activity;
using RemoteNotes.BLL.Contract.Rule;
using RemoteNotes.BLL.Contract.UseCase;
using RemoteNotes.BLL.Rules;
using RemoteNotes.BLL.UseCases;
using RemoteNotes.DAL;
using RemoteNotes.DAL.Contract;
using RemoteNotes.DAL.Contract.Provider;

namespace RemoteNotes.Service
{
    internal sealed class DependencyConfiguration
    {
        public static IContainer Container { get; private set; }

        public static void Configure()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<LoggingService>();

            builder.RegisterType<MySqlProvider>().As<IDbProvider<MySqlConnection>>()
                .WithParameter("connectionString", ConfigurationManager.AppSettings["DatabaseConnectionString"]);

            builder.RegisterType<RepositoryFactory>().As<IRepositoryFactory>();
            builder.RegisterType<ValidationRuleFactory>().As<IValidationRuleFactory>();
            builder.RegisterType<ActivitiesFactory>().As<IActivitiesFactory>();
            builder.RegisterType<UseCaseFactory>().As<IUseCaseFactory>();

            Container = builder.Build();
        }
    }
}