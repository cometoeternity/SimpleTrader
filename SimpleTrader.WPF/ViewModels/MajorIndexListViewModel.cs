using SimpleTrader.Domain.Models;
using SimpleTrader.Domain.Services;
using SimpleTrader.WPF.ViewModels.Base;

namespace SimpleTrader.WPF.ViewModels
{
    public class MajorIndexListViewModel : ViewModelBase
    {
        private readonly IMajorIndexService _majorIndexService;

        private MajorIndex _dowJones;
        public MajorIndex DowJones
        {
            get
            {
                return _dowJones;
            }
            set
            {
                _dowJones = value;
                OnPropertyChanged(nameof(DowJones));
            }
        }
        private MajorIndex _nasdaq;
        public MajorIndex Nasdaq
        {
            get => _nasdaq;
            set
            {
                _nasdaq = value;
                OnPropertyChanged(nameof(Nasdaq));
            }
        }

        private MajorIndex _sp500;
        public MajorIndex SP500 
        { 
            get => _sp500; 
            set
            {
                _sp500 = value;
                OnPropertyChanged(nameof(SP500));
            }
        }

        public MajorIndexListViewModel(IMajorIndexService majorIndexService)
        {
            _majorIndexService = majorIndexService;
        }

        public static MajorIndexListViewModel LoadMajorIndexViewModel(IMajorIndexService majorIndexService)
        {
            MajorIndexListViewModel majorIndexViewModel = new MajorIndexListViewModel(majorIndexService);
            majorIndexViewModel.LoadMajorService();
            return majorIndexViewModel;
        }

        private void LoadMajorService()
        {
            _majorIndexService.GetMajorIndex(MajorIndexType.DowJones).ContinueWith((task) =>
            {
                if (task.Exception == null)
                {
                    DowJones = task.Result;
                }
            });
            _majorIndexService.GetMajorIndex(MajorIndexType.Nasdaq).ContinueWith((task) =>
            {
                if (task.Exception == null)
                {
                    Nasdaq = task.Result;
                }
            }); ;
            _majorIndexService.GetMajorIndex(MajorIndexType.SP500).ContinueWith((task) =>
            {
                if (task.Exception == null)
                {
                    SP500 = task.Result;
                }
            }); ;
        }
    }
}
