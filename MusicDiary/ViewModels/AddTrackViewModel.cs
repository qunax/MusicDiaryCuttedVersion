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
    public class AddTrackViewModel : ViewModelBase
    {

        private readonly User _user;
        private readonly ObservableCollection<Artist> _artists;

        public IEnumerable<Artist> Artists => _artists;

        private string _trackCover;
        public string TrackCover
        {
            get
            {
                return _trackCover;
            }
            set
            {
                _trackCover = value;
                OnPropertyChanged(nameof(TrackCover));
            }
        }


        private string _trackTitle;
        public string TrackTitle
        {
            get
            {
                return _trackTitle;
            }
            set
            {
                _trackTitle = value;
                OnPropertyChanged(nameof(TrackTitle));
            }
        }

        private string _trackGenre;
        public string TrackGenre
        {
            get
            {
                return _trackGenre;
            }
            set
            {
                _trackGenre = value;
                OnPropertyChanged(nameof(TrackGenre));
            }
        }

        private string _trackAlbumname;
        public string TrackAlbumName
        {
            get
            {
                return _trackAlbumname;
            }
            set
            {
                _trackAlbumname = value;
                OnPropertyChanged(nameof(TrackAlbumName));
            }
        }

        private Artist _trackArtist;
        public Artist TrackArtist
        {
            get
            {
                return _trackArtist;
            }
            set
            {
                _trackArtist = value;
                OnPropertyChanged(nameof(TrackArtist));
            }
        }

        private string _trackText;
        public string TrackText
        {
            get
            {
                return _trackText;
            }
            set
            {
                _trackText = value;
                OnPropertyChanged(nameof(TrackText));
            }
        }



        public ICommand LoadArtistsInTrackCommand { get; }
        public ICommand AddCoverCommand { get; }
        public ICommand CancelCommand { get; }
        public ICommand SubmitCommand { get; }

        public AddTrackViewModel(User user, NavigationService mainMenuNavigationService)
        {

            _artists = new ObservableCollection<Artist>();

            LoadArtistsInTrackCommand = new LoadArtistInTrackCommand(user, this);
            CancelCommand = new NavigateCommand(mainMenuNavigationService);
            SubmitCommand = new AddNewTrackCommand(user, this, mainMenuNavigationService);
        }

        public static AddTrackViewModel LoadViewModel(User user, NavigationService mainMenuNavigationService)
        {
            AddTrackViewModel viewModel = new AddTrackViewModel(user, mainMenuNavigationService);

            viewModel.LoadArtistsInTrackCommand.Execute(null);

            return viewModel;
        }

        public void UpdateArtists(IEnumerable<Artist> artists)
        {
            _artists.Clear();

            foreach(Artist artist in artists)
            {
                _artists.Add(artist);
            }
        }
    }
}
