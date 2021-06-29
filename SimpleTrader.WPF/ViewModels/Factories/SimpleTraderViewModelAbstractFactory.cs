using SimpleTrader.WPF.State.Navigators;
using SimpleTrader.WPF.ViewModels.Base;
using System;

namespace SimpleTrader.WPF.ViewModels.Factories
{
    public class SimpleTraderViewModelAbstractFactory : ISimpleTraderViewModelAbstractFactory
    {
        private readonly ISimpleTraderViewModelFactory<HomeWindowViewModel> _homeWindowViewModelFactory;
        private readonly ISimpleTraderViewModelFactory<PortfolioWindowViewModel> _portfolioWindowViewModelFactory;
        private readonly ISimpleTraderViewModelFactory<BuyWindowViewModel> _buyWindowViewModelFactory;
        private readonly ISimpleTraderViewModelFactory<SellWindowViewModel> _sellWindowViewModelFactory;

        public SimpleTraderViewModelAbstractFactory(ISimpleTraderViewModelFactory<HomeWindowViewModel> homeWindowViewModelFactory)
        {
            _homeWindowViewModelFactory = homeWindowViewModelFactory;
        }

        public SimpleTraderViewModelAbstractFactory(ISimpleTraderViewModelFactory<HomeWindowViewModel> homeWindowViewModelFactory,
                                                    ISimpleTraderViewModelFactory<PortfolioWindowViewModel> portfolioWindowViewModelFactory, 
                                                    ISimpleTraderViewModelFactory<BuyWindowViewModel> buyWindowViewModelFactory, 
                                                    ISimpleTraderViewModelFactory<SellWindowViewModel> sellWindowViewModelFactory)
        {
            _homeWindowViewModelFactory = homeWindowViewModelFactory;
            _portfolioWindowViewModelFactory = portfolioWindowViewModelFactory;
            _buyWindowViewModelFactory = buyWindowViewModelFactory;
            _sellWindowViewModelFactory = sellWindowViewModelFactory;
        }

        public ViewModelBase CreateViewModel(ViewType viewType)
        {
            return viewType switch
            {
                ViewType.Home => _homeWindowViewModelFactory.CreateViewModel(),
                ViewType.Portfolio => _portfolioWindowViewModelFactory.CreateViewModel(),
                ViewType.Buy => _buyWindowViewModelFactory.CreateViewModel(),
                ViewType.Sell => _sellWindowViewModelFactory.CreateViewModel(),
                _ => throw new ArgumentException("The ViewType does not have a ViewModel", "ViewType"),
            };
        }
    }
}
