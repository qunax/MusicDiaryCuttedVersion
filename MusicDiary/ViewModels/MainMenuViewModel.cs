using MusicDiary.Commands;
using MusicDiary.Services;
using MusicDiary.Stores;
using System.Windows.Input;

namespace MusicDiary.ViewModels
{
    public class MainMenuViewModel : ViewModelBase
    {
        private readonly NavigationStore _innerNavigationStore;

        public ViewModelBase InnerCurrentViewModel => _innerNavigationStore.CurrentViewModel;

        public MainMenuViewModel(NavigationStore navigationStore,
            NavigationService likedTracksNavigationService,
            NavigationService likedArtistsNavigationService,
            NavigationService likedAlbumsNavigationService)
        {
            _innerNavigationStore = navigationStore;
            _innerNavigationStore.CurrentViewModelChanged += OnCurrentViewModelChanged;

            OpenLikedTracksCommand = new NavigateCommand(likedTracksNavigationService);
            OpenLikedArtistsCommand = new NavigateCommand(likedArtistsNavigationService);
            OpenMyPlaylistsCommand = new NavigateCommand(likedAlbumsNavigationService);

        }

        private void OnCurrentViewModelChanged()
        {
            OnPropertyChanged(nameof(InnerCurrentViewModel));
        }

        public ICommand OpenLikedTracksCommand { get; }
        public ICommand OpenLikedArtistsCommand { get; }
        public ICommand OpenMyPlaylistsCommand { get; }
    }
}
