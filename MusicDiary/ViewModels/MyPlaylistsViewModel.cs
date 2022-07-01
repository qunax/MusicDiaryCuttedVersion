using MusicDiary.Commands;
using MusicDiary.Models;
using MusicDiary.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MusicDiary.ViewModels
{
    public class MyPlaylistsViewModel : ViewModelBase
    {
        private readonly User _user;
        private readonly ObservableCollection<PlaylistViewModel> _playlists;

        public IEnumerable<PlaylistViewModel> Playlists => _playlists;

        private PlaylistViewModel _playlistSelectedItem;
        public PlaylistViewModel PlaylistSelectedItem
        {
            get
            {
                return _playlistSelectedItem;
            }
            set
            {
                _playlistSelectedItem = value;
                OnPropertyChanged(nameof(PlaylistSelectedItem));
            }
        }


        public ICommand LoadPlaylistsCommand { get; }
        public ICommand BackCommand { get; }
        public ICommand MorePlaylistInformationCommand { get; }
        public ICommand DeletePlaylistCommand { get; }
        public ICommand MakePlaylistCommand { get; }


        public MyPlaylistsViewModel(User user, NavigationService homePageNavigationSErvice, NavigationService makePlaylistNavigationService,
            NavigationService playlistInfonavigationService, NavigationService myPlaylistsNavigationService)
        {
            _user = user;
            _playlists = new ObservableCollection<PlaylistViewModel>();

            LoadPlaylistsCommand = new LoadPlaylistsCommand(user, this);
            BackCommand = new NavigateCommand(homePageNavigationSErvice);
            MorePlaylistInformationCommand = new MoreInformationPlaylistCommand(this, playlistInfonavigationService, user);
            DeletePlaylistCommand = new DeletePlaylistCommand(user, this, myPlaylistsNavigationService);
            MakePlaylistCommand = new NavigateCommand(makePlaylistNavigationService);

            user.CurrentPlaylistViewModel = _playlistSelectedItem;
        }

        public static MyPlaylistsViewModel LoadViewModel(User user, NavigationService homePageNavigationSErvice, NavigationService makePlaylistNavigationService,
            NavigationService playlistInfonavigationService, NavigationService myPlaylistsNavigationService)
        {
            MyPlaylistsViewModel viewModel = new MyPlaylistsViewModel(user, homePageNavigationSErvice, makePlaylistNavigationService,
                playlistInfonavigationService, myPlaylistsNavigationService);

            viewModel.LoadPlaylistsCommand.Execute(null);

            return viewModel;
        }

        public void UpdatePlaylists(IEnumerable<Playlist> playlists)
        {
            _playlists.Clear();

            foreach (Playlist playlist in playlists)
            {
                PlaylistViewModel playlistViewModel = new PlaylistViewModel(_user, playlist);
                _playlists.Add(playlistViewModel);
            }
        }
    }
}
