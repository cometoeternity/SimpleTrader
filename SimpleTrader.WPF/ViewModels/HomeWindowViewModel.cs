using SimpleTrader.FinancialModelingPrepAPI.Services;
using SimpleTrader.WPF.ViewModels.Base;

namespace SimpleTrader.WPF.ViewModels
{
    public class HomeWindowViewModel : ViewModelBase
    {
        public MajorIndexListViewModel MajorIndexListViewModel { get; set; }
        public HomeWindowViewModel(MajorIndexListViewModel majorIndexListViewModel)
        {
            MajorIndexListViewModel = majorIndexListViewModel;
        }
    }
}
