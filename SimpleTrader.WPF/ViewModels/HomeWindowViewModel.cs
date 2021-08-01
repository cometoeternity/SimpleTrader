using SimpleTrader.FinancialModelingPrepAPI.Services;
using SimpleTrader.WPF.ViewModels.Base;

namespace SimpleTrader.WPF.ViewModels
{
    public class HomeWindowViewModel : ViewModelBase
    {
        public MajorIndexListViewModel MajorIndexListViewModel { get; }
        public AssetSummaryViewModel AssetSummaryViewModel { get; }

        public HomeWindowViewModel(MajorIndexListViewModel majorIndexListViewModel, AssetSummaryViewModel assetSummaryViewModel)
        {
            MajorIndexListViewModel = majorIndexListViewModel;
            AssetSummaryViewModel = assetSummaryViewModel;
        }
    }
}
