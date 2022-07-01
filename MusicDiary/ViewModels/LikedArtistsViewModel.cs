using MusicDiary.Commands;
using MusicDiary.Models;
using MusicDiary.Services;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace MusicDiary.ViewModels
{
    public class LikedArtistsViewModel : ViewModelBase
    {
        private readonly ObservableCollection<ArtistViewModel> _artists;


        public IEnumerable<ArtistViewModel> Artists => _artists;

        private ArtistViewModel _artistSelectedItem;
        public ArtistViewModel ArtistSelectedItem
        {
            get
            {
                return _artistSelectedItem;
            }
            set
            {
                _artistSelectedItem = value;
                OnPropertyChanged(nameof(ArtistSelectedItem));
            }
        }


        public ICommand LoadArtistsCommand { get; }
        public ICommand BackCommand { get; }
        public ICommand MoreArtistInformationCommand { get; }
        public ICommand DeleteArtistCommand { get; }
        public ICommand AddArtistCommand { get; } 


        public LikedArtistsViewModel(User user, NavigationService homePageNavigationSErvice, NavigationService addArtistNavigationService,
            NavigationService artistInfoNavigationService, NavigationService likedArtistsNavigationService)
        {
            _artists = new ObservableCollection<ArtistViewModel>();

            LoadArtistsCommand = new LoadArtistsCommand(user, this);
            BackCommand = new NavigateCommand(homePageNavigationSErvice);
            MoreArtistInformationCommand = new MoreInformationArtistCommand(this, artistInfoNavigationService, user);
            DeleteArtistCommand = new DeleteArtistCommand(this, likedArtistsNavigationService, user);
            AddArtistCommand = new NavigateCommand(addArtistNavigationService);

            user.CurrentArtistViewModel = _artistSelectedItem;
        }
        public static LikedArtistsViewModel LoadViewModel(User user, NavigationService homePageNavigationSErvice, NavigationService addArtistNavigationService,
            NavigationService artistInfoNavigationService, NavigationService likedArtistsNavigationService)
        {
            
            LikedArtistsViewModel viewModel = new LikedArtistsViewModel(user, homePageNavigationSErvice,
                addArtistNavigationService, artistInfoNavigationService, likedArtistsNavigationService);

            viewModel.LoadArtistsCommand.Execute(null);

            return viewModel;
        }

        public void UpdateArtists(IEnumerable<Artist> artists)
        {
            _artists.Clear();

            foreach (Artist artist in artists)
            {
                ArtistViewModel artistViewModel = new ArtistViewModel(artist);
                _artists.Add(artistViewModel);
            }
        }
    }
}
