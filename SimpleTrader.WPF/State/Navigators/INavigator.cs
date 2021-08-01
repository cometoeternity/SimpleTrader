using SimpleTrader.WPF.ViewModels.Base;
using System;
using System.Windows.Input;

namespace SimpleTrader.WPF.State.Navigators
{

    public enum ViewType
    {
        Login,
        Home,
        Portfolio,
        Buy,
        Sell
    }
    public interface INavigator
    {
        ViewModelBase CurrentViewModel { get; set; }
        event Action StateChanged;
    }
}
