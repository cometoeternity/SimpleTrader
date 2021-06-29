using SimpleTrader.Domain.Services;
 
namespace SimpleTrader.WPF.ViewModels.Factories
{
    public class MajorIndexListViewModelFactory : ISimpleTraderViewModelFactory<MajorIndexListViewModel>
    {
        private readonly IMajorIndexService _majorIndexService;

        public MajorIndexListViewModelFactory(IMajorIndexService majorIndexService)
        {
            _majorIndexService = majorIndexService;
        }

        public MajorIndexListViewModel CreateViewModel() => MajorIndexListViewModel.LoadMajorIndexViewModel(_majorIndexService);
       
    }
}
