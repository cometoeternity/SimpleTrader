namespace SimpleTrader.WPF.ViewModels.Factories
{
    public class SellWindowViewModelFactory : ISimpleTraderViewModelFactory<SellWindowViewModel>
    {
        public SellWindowViewModel CreateViewModel() => new SellWindowViewModel();  
    }
}
