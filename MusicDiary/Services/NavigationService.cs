using MusicDiary.Stores;
using MusicDiary.ViewModels;
using System;

namespace MusicDiary.Services
{
    public class NavigationService
    {
        private readonly NavigationStore _navigationStore;
        private readonly Func<ViewModelBase> _createViewModel;

        public NavigationService(NavigationStore navigationStore, Func<ViewModelBase> createViewModel)
        {
            _navigationStore = navigationStore;
            _createViewModel = createViewModel;
        }


        public void Navigate()
        {
            _navigationStore.CurrentViewModel = _createViewModel();
        }

    }
}
