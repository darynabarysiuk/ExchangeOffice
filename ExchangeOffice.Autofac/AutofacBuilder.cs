using Autofac;
using ExchangeOffice.IRepositories;
using ExchangeOffice.IServices;
using ExchangeOffice.Repositories;
using ExchangeOffice.Services;

namespace ExchangeOffice.App.Autofac
{
    public static class AutofacBuilder
    {
        public static IContainer Build()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<ApplicationContext>();

            #region Services
            builder.RegisterType<IAuthService>().As<AuthService>();
            builder.RegisterType<ICurrencyService>().As<CurrencyService>();
            builder.RegisterType<ICurrencyLimitService>().As<CurrencyLimitService>();
            builder.RegisterType<ICurrencyRateService>().As<CurrencyRateService>();
            builder.RegisterType<IDateTimeService>().As<DateTimeService>();
            builder.RegisterType<IOperationService>().As<OperationService>();
            #endregion

            #region Repositories
            builder.RegisterType<IRepositoryCashers>().As<RepositoryCashers>();
            builder.RegisterType<IRepositoryCurrencies>().As<RepositoryCurrencies>();
            builder.RegisterType<IRepositoryCurrencyRates>().As<RepositoryCurrencyRates>();
            builder.RegisterType<IRepositoryOperationHistories>().As<RepositoryOperationHistories>();
            builder.RegisterType<IRepositoryСurrencyLimits>().As<RepositoryСurrencyLimits>();
            #endregion

            return builder.Build();
        }
    }
}
