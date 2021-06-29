namespace SimpleTrader.WPF.ViewModels.Factories
{
    public class PortfolioWindowViewModelFactory : ISimpleTraderViewModelFactory<PortfolioWindowViewModel>
    {
        public PortfolioWindowViewModel CreateViewModel() => new PortfolioWindowViewModel();  
    }
}
