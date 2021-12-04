using Autofac;
using ExchangeOffice.IRepositories;
using ExchangeOffice.IServices;
using ExchangeOffice.Presenters;
using ExchangeOffice.Repositories;
using ExchangeOffice.Services;

namespace ExchangeOffice.App.Autofac
{
    public static class AutofacBuilder
    {
        public static IContainer Build()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<ApplicationContext>().As<ApplicationContext>().InstancePerLifetimeScope();

            #region Repositories
            builder.RegisterType<RepositoryCashers>().As<IRepositoryCashers>();
            builder.RegisterType<RepositoryCurrencies>().As<IRepositoryCurrencies>();
            builder.RegisterType<RepositoryCurrencyRates>().As<IRepositoryCurrencyRates>();
            builder.RegisterType<RepositoryOperationHistories>().As<IRepositoryOperationHistories>();
            builder.RegisterType<RepositoryСurrencyLimits>().As<IRepositoryСurrencyLimits>();
            #endregion

            #region Services
            builder.RegisterType<AuthService>().As<IAuthService>();
            builder.RegisterType<CurrencyService>().As<ICurrencyService>();
            builder.RegisterType<CurrencyLimitService>().As<ICurrencyLimitService>();
            builder.RegisterType<CurrencyRateService>().As<ICurrencyRateService>();
            builder.RegisterType<DateTimeService>().As<IDateTimeService>();
            builder.RegisterType<OperationService>().As<IOperationService>();
            #endregion

            #region Presenters
            builder.RegisterType<AuthPresenter>().As<AuthPresenter>();
            #endregion

            return builder.Build();
        }
    }
}
