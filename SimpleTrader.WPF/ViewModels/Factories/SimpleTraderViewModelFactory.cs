using SimpleTrader.WPF.State.Navigators;
using SimpleTrader.WPF.ViewModels.Base;
using System;

namespace SimpleTrader.WPF.ViewModels.Factories
{
    public class SimpleTraderViewModelFactory : ISimpleTraderViewModelFactory
    {
        private readonly CreateViewModel<HomeWindowViewModel> _createHomeWindowViewModel;
        private readonly CreateViewModel<PortfolioWindowViewModel> _createPortfolioWindowViewModel;
        private readonly CreateViewModel<BuyWindowViewModel> _createBuyWindowViewModel;
        private readonly CreateViewModel<LoginWindowViewModel> _createLoginWindowViewModel;

        public SimpleTraderViewModelFactory(CreateViewModel<HomeWindowViewModel> createHomeWindowViewModel,
                                            CreateViewModel<PortfolioWindowViewModel> createPortfolioWindowViewModel, 
                                            CreateViewModel<BuyWindowViewModel> createBuyWindowViewModel, 
                                            CreateViewModel<LoginWindowViewModel> createLoginWindowViewModel)
        {
            _createHomeWindowViewModel = createHomeWindowViewModel;
            _createPortfolioWindowViewModel = createPortfolioWindowViewModel;
            _createBuyWindowViewModel = createBuyWindowViewModel;
            _createLoginWindowViewModel = createLoginWindowViewModel;
        }

        public ViewModelBase CreateViewModel(ViewType viewType)
        {
            return viewType switch
            {
                ViewType.Login => _createLoginWindowViewModel(),
                ViewType.Home =>_createHomeWindowViewModel(),
                ViewType.Portfolio => _createPortfolioWindowViewModel(),
                ViewType.Buy => _createBuyWindowViewModel(),
                _ => throw new ArgumentException("The ViewType does not have a ViewModel", "ViewType"),
            };
        }
    }
}
