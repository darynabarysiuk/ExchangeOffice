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

            builder.RegisterType<ApplicationContext>().As<ApplicationContext>().SingleInstance();

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
            builder.RegisterType<CheckService>().As<ICheckService>();
            #endregion

            #region Presenters
            builder.RegisterType<AuthPresenter>().As<AuthPresenter>();
            builder.RegisterType<MainPresenter>().As<MainPresenter>();
            builder.RegisterType<HandlingClientPresenter>().As<HandlingClientPresenter>();
            builder.RegisterType<OperationHistoryPresenter>().As<OperationHistoryPresenter>();
            builder.RegisterType<SimulationNextDayPresenter>().As<SimulationNextDayPresenter>();
            builder.RegisterType<ExchangeLimitPresenter>().As<ExchangeLimitPresenter>();
            builder.RegisterType<ExchangeRatesPresenter>().As<ExchangeRatesPresenter>();
            #endregion

            return builder.Build();
        }
    }
}
