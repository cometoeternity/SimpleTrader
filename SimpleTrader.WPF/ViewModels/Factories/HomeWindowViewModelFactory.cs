namespace SimpleTrader.WPF.ViewModels.Factories
{
    public class HomeWindowViewModelFactory : ISimpleTraderViewModelFactory<HomeWindowViewModel>
    {
        private ISimpleTraderViewModelFactory<MajorIndexListViewModel> _majorIndexViewModelFactory;

        public HomeWindowViewModelFactory(ISimpleTraderViewModelFactory<MajorIndexListViewModel> majorIndexViewModelFactory)
        {
            _majorIndexViewModelFactory = majorIndexViewModelFactory;
        }

        public HomeWindowViewModel CreateViewModel() => new HomeWindowViewModel(_majorIndexViewModelFactory.CreateViewModel());
        
    }
}
