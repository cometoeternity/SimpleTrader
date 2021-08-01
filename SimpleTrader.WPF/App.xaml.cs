using Microsoft.AspNet.Identity;
using Microsoft.Extensions.DependencyInjection;
using SimpleTrader.Domain.Models;
using SimpleTrader.Domain.Services;
using SimpleTrader.Domain.Services.AuthenticationServices;
using SimpleTrader.Domain.Services.TransactionServices;
using SimpleTrader.EntityFrameworkCore;
using SimpleTrader.EntityFrameworkCore.Services;
using SimpleTrader.FinancialModelingPrepAPI.Services;
using SimpleTrader.WPF.State.Accounts;
using SimpleTrader.WPF.State.Assets;
using SimpleTrader.WPF.State.Authenticators;
using SimpleTrader.WPF.State.Navigators;
using SimpleTrader.WPF.ViewModels;
using SimpleTrader.WPF.ViewModels.Base;
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
            services.AddSingleton<IAccountService, AccountDataService>();
            services.AddSingleton<IAuthenticationService, AuthenticationService>();
            services.AddSingleton<IBuyStockService, BuyStockService>();
            services.AddSingleton<IMajorIndexService, MajorIndexService>();

            services.AddSingleton<IPasswordHasher, PasswordHasher>();

            services.AddSingleton<ISimpleTraderViewModelFactory, SimpleTraderViewModelFactory>();
            services.AddSingleton<BuyWindowViewModel>();
            services.AddSingleton<PortfolioWindowViewModel>();
            services.AddSingleton<LoginWindowViewModel>();
            services.AddSingleton<AssetSummaryViewModel>();
            services.AddSingleton<HomeWindowViewModel>(services => new HomeWindowViewModel(
                    MajorIndexListViewModel.LoadMajorIndexViewModel(
                        services.GetRequiredService<IMajorIndexService>()),
                    services.GetRequiredService<AssetSummaryViewModel>()));

            services.AddSingleton<CreateViewModel<HomeWindowViewModel>>(services =>
            {
                return () => services.GetRequiredService<HomeWindowViewModel>();
            });

            services.AddSingleton<CreateViewModel<BuyWindowViewModel>>(services =>
            {
                return () => services.GetRequiredService<BuyWindowViewModel>();
            });

            services.AddSingleton<CreateViewModel<PortfolioWindowViewModel>>(services =>
            {
                return () => services.GetRequiredService<PortfolioWindowViewModel>();
            });


            services.AddSingleton<ViewModelDelegateRenavigator<HomeWindowViewModel>>();
            services.AddSingleton<CreateViewModel<LoginWindowViewModel>>(services =>
            {
                return () => new LoginWindowViewModel(
                    services.GetRequiredService<IAuthenticator>(),
                    services.GetRequiredService<ViewModelDelegateRenavigator<HomeWindowViewModel>>());
            });

            services.AddSingleton<INavigator, Navigator>();
            services.AddSingleton<IAuthenticator, Authenticator>();
            services.AddSingleton<IAccountStore, AccountStore>();
            services.AddSingleton<AssetStore>();

            services.AddScoped<MainWindowViewModel>();
            services.AddScoped<BuyWindowViewModel>();
            services.AddScoped<MainWindow>(s => new MainWindow(s.GetRequiredService<MainWindowViewModel>()));

            return services.BuildServiceProvider();
        }
    }
}
