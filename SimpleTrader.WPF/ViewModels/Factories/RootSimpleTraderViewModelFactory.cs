using SimpleTrader.WPF.State.Navigators;
using SimpleTrader.WPF.ViewModels.Base;
using System;

namespace SimpleTrader.WPF.ViewModels.Factories
{
    public class RootSimpleTraderViewModelFactory : IRootSimpleTraderViewModelFactory
    {
        private readonly ISimpleTraderViewModelFactory<HomeWindowViewModel> _homeWindowViewModelFactory;
        private readonly ISimpleTraderViewModelFactory<PortfolioWindowViewModel> _portfolioWindowViewModelFactory;

        //Не Создаем с помощью фабрики, чтобы сохранять последние состояния страницы и введеных данных.
        private readonly BuyWindowViewModel _buyWindowViewModel;
        private readonly ISimpleTraderViewModelFactory<SellWindowViewModel> _sellWindowViewModelFactory;
        private readonly ISimpleTraderViewModelFactory<LoginWindowViewModel> _loginWindowViewModelFactory;

        public RootSimpleTraderViewModelFactory(ISimpleTraderViewModelFactory<HomeWindowViewModel> homeWindowViewModelFactory,
                                                    ISimpleTraderViewModelFactory<PortfolioWindowViewModel> portfolioWindowViewModelFactory,
                                                    BuyWindowViewModel buyWindowViewModel,
                                                    ISimpleTraderViewModelFactory<SellWindowViewModel> sellWindowViewModelFactory, ISimpleTraderViewModelFactory<LoginWindowViewModel> loginWindowViewModelFactory)
        {
            _homeWindowViewModelFactory = homeWindowViewModelFactory;
            _portfolioWindowViewModelFactory = portfolioWindowViewModelFactory;
            _buyWindowViewModel = buyWindowViewModel;
            _sellWindowViewModelFactory = sellWindowViewModelFactory;
            _loginWindowViewModelFactory = loginWindowViewModelFactory;
        }

        public ViewModelBase CreateViewModel(ViewType viewType)
        {
            return viewType switch
            {
                ViewType.Login => _loginWindowViewModelFactory.CreateViewModel(),
                ViewType.Home => _homeWindowViewModelFactory.CreateViewModel(),
                ViewType.Portfolio => _portfolioWindowViewModelFactory.CreateViewModel(),
                ViewType.Buy => _buyWindowViewModel,
                ViewType.Sell => _sellWindowViewModelFactory.CreateViewModel(),
                _ => throw new ArgumentException("The ViewType does not have a ViewModel", "ViewType"),
            };
        }
    }
}
