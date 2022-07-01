using MusicDiary.Commands;
using MusicDiary.Models;
using MusicDiary.Services;
using MusicDiary.Stores;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MusicDiary.ViewModels
{
    public class PlaylistInfoViewModel : ViewModelBase
    {
        private readonly User _user;
        private readonly PlaylistViewModel _playlistViewModel;
        private readonly ObservableCollection<TrackViewModel> _tracks;

        public PlaylistViewModel PlaylistViewModel => _playlistViewModel;
        public IEnumerable<TrackViewModel> Tracks => _tracks;

        public ICommand LoadTracksCommand { get; set; }
        public ICommand BackCommand { get; set; }

        public PlaylistInfoViewModel(User user, NavigationService mainMenuNavigationService)
        {
            _user = user;
            LoadTracksCommand = new LoadTracksForPlaylistCommand(user, this);
            BackCommand = new NavigateCommand(mainMenuNavigationService);
            _playlistViewModel = user.CurrentPlaylistViewModel;

            _tracks = _playlistViewModel.Tracks;
        }

        public static PlaylistInfoViewModel LoadViewModel(User user, NavigationService mainMenuNavigationService)
        {
            PlaylistInfoViewModel viewModel = new PlaylistInfoViewModel(user, mainMenuNavigationService);

            viewModel.LoadTracksCommand.Execute(null);

            return viewModel;
        }

        public void UpdateTracks(User user, IEnumerable<Track> tracks)
        {
            _tracks.Clear();

            foreach (Track track in tracks)
            {
                TrackViewModel trackViewModel = new TrackViewModel(user, track);
                _tracks.Add(trackViewModel);
            }
        }
    }
}
