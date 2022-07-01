using MusicDiary.Commands;
using MusicDiary.Models;
using MusicDiary.Services;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace MusicDiary.ViewModels
{
    public class ArtistInfoViewModel : ViewModelBase
    {
        private readonly User _user;
        private readonly ArtistViewModel _artistViewModel;
        private readonly ObservableCollection<TrackViewModel> _tracks;

        public ArtistViewModel ArtistViewModel => _artistViewModel;
        public IEnumerable<TrackViewModel> Tracks => _tracks;


        public ICommand LoadTracksCommand { get; }
        public ICommand BackCommand { get; }

        public ArtistInfoViewModel(User user, NavigationService mainMenuNavigationService)
        {
            _tracks = new ObservableCollection<TrackViewModel>();
            _user = user;

            LoadTracksCommand = new LoadTracksForArtistCommand(user, this);
            BackCommand = new NavigateCommand(mainMenuNavigationService);
            _artistViewModel = user.CurrentArtistViewModel;
        }

        public static ArtistInfoViewModel LoadViewModel(User user, NavigationService mainMenuNavigationService)
        {
            ArtistInfoViewModel viewModel = new ArtistInfoViewModel(user, mainMenuNavigationService);

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
