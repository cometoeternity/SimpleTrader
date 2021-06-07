using SimpleTrader.FinancialModelingPrepAPI.Services;
using SimpleTrader.WPF.ViewModels.Base;

namespace SimpleTrader.WPF.ViewModels
{
    public class HomeWindowViewModel : ViewModelBase
    {
        public MajorIndexViewModel MajorIndexViewModel { get; set; }
        public HomeWindowViewModel(MajorIndexViewModel majorIndexViewModel)
        {
            MajorIndexViewModel = majorIndexViewModel;
        }
    }
}
