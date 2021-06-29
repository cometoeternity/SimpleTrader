using Microsoft.Extensions.DependencyInjection;
using SimpleTrader.Domain.Models;
using SimpleTrader.Domain.Services;
using SimpleTrader.Domain.Services.TransactionServices;
using SimpleTrader.EntityFrameworkCore;
using SimpleTrader.EntityFrameworkCore.Services;
using SimpleTrader.FinancialModelingPrepAPI.Services;
using SimpleTrader.WPF.State.Navigators;
using SimpleTrader.WPF.ViewModels;
using SimpleTrader.WPF.ViewModels.Factories;
using System;
using System.Windows;

namespace SimpleTrader.WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            IServiceProvider serviceProvider = CreateServiceProvider();

            Window window = serviceProvider.GetRequiredService<MainWindow>();
            window.Show();

            base.OnStartup(e);
        }

        private IServiceProvider CreateServiceProvider()
        {
            IServiceCollection services = new ServiceCollection();
            services.AddSingleton<SimpleTraderDbContextFactory>();
            services.AddSingleton<IStockPriceService,StockPriceService>();
            services.AddSingleton<IDataService<Account>, AccountDataService>();
            services.AddSingleton<IBuyStockService, BuyStockService>();
            services.AddSingleton<IMajorIndexService, MajorIndexService>();

            services.AddSingleton<ISimpleTraderViewModelAbstractFactory, SimpleTraderViewModelAbstractFactory>();
            services.AddSingleton<ISimpleTraderViewModelFactory<HomeWindowViewModel>, HomeWindowViewModelFactory>();
            services.AddSingleton<ISimpleTraderViewModelFactory<MajorIndexListViewModel>, MajorIndexListViewModelFactory>();
            services.AddSingleton<ISimpleTraderViewModelFactory<PortfolioWindowViewModel>, PortfolioWindowViewModelFactory>();
            services.AddSingleton<ISimpleTraderViewModelFactory<BuyWindowViewModel>, BuyWindowViewModelFactory>();
            services.AddSingleton<ISimpleTraderViewModelFactory<SellWindowViewModel>, SellWindowViewModelFactory>();

            services.AddScoped<INavigator, Navigator>();
            services.AddScoped<MainWindowViewModel>();
            services.AddScoped<MainWindow>(s => new MainWindow(s.GetRequiredService<MainWindowViewModel>()));

            return services.BuildServiceProvider();
        }
    }
}
