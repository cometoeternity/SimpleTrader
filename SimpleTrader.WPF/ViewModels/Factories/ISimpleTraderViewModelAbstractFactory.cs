using SimpleTrader.WPF.State.Navigators;
using SimpleTrader.WPF.ViewModels.Base;

namespace SimpleTrader.WPF.ViewModels.Factories
{
    public interface ISimpleTraderViewModelAbstractFactory
    {
        ViewModelBase CreateViewModel(ViewType viewType);
    }
}
