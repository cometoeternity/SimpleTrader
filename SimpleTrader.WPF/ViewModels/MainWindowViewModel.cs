using SimpleTrader.WPF.State.Navigators;
using SimpleTrader.WPF.ViewModels.Base;

namespace SimpleTrader.WPF.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public INavigator Navigator { get; set; }


        //С помощью этого конструктора при включении приложения будет сразу открываться
        //ViewType.Home
        public MainWindowViewModel(INavigator navigator)
        {
            Navigator = navigator;
            Navigator.UpdateCurrentViewModelCommand.Execute(ViewType.Home);
        }
    }
}
