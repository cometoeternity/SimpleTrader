using SimpleTrader.WPF.ViewModels.Base;

namespace SimpleTrader.WPF.ViewModels.Factories
{
    public interface ISimpleTraderViewModelFactory<T> where T : ViewModelBase
    {
        T CreateViewModel();
    }
}
