using MusicDiary.Commands;
using MusicDiary.Models;
using MusicDiary.Services;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace MusicDiary.ViewModels
{
    public class MakePlaylistViewModel : ViewModelBase
    {
        private readonly ObservableCollection<TrackViewModel> _tracks;

        public IEnumerable<TrackViewModel> Tracks => _tracks;


        private string _playlistCover;
        public string PlaylistCover
        {
            get
            {
                return _playlistCover;
            }
            set
            {
                _playlistCover = value;
                OnPropertyChanged(nameof(PlaylistCover));
            }
        }

        private string _playlistTitle;
        public string PlaylistTitle
        {
            get
            {
                return _playlistTitle;
            }
            set
            {
                _playlistTitle = value;
                OnPropertyChanged(nameof(PlaylistTitle));
            }
        }


        private TrackViewModel _selectedTrackViewModel;
        public TrackViewModel SelectedTrackViewModel
        {
            get
            {
                return _selectedTrackViewModel;
            }
            set
            {
                _selectedTrackViewModel = value;
                OnPropertyChanged(nameof(SelectedTrackViewModel));
            }
        }



        public ICommand LoadTracksCommand { get; }
        public ICommand AddCover { get; }
        public ICommand CancelCommand { get; }
        public ICommand SubmitCommand { get; }

        public MakePlaylistViewModel(User user, NavigationService mainMenuNavigationService)
        {
            _tracks = new ObservableCollection<TrackViewModel>();

            LoadTracksCommand = new LoadTracksCommand(user, this);
            AddCover = new AddCoverCommand(this);
            CancelCommand = new NavigateCommand(mainMenuNavigationService);
            SubmitCommand = new MakeNewPlaylistCommand(user, this, mainMenuNavigationService);
        }

        public static MakePlaylistViewModel LoadViewModel(User user, NavigationService mainMenuNavigationService)
        {
            MakePlaylistViewModel viewModel = new MakePlaylistViewModel(user, mainMenuNavigationService);

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
