using MusicDiary.Models;
using MusicDiary.Services;
using MusicDiary.ViewModels;
using System;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows;

namespace MusicDiary.Commands
{
    public class AddNewTrackCommand : AsyncCommandBase
    {
        private readonly User _user;
        private AddTrackViewModel _addTrackViewModel;
        private readonly NavigationService _mainMenunavigationService;



        public AddNewTrackCommand(User user, AddTrackViewModel addTrackViewModel, NavigationService mainMenuNavigationService)
        {
            _user = user;
            _addTrackViewModel = addTrackViewModel;
            _addTrackViewModel.PropertyChanged += OnViewPropertyChanged;
            _mainMenunavigationService = mainMenuNavigationService;
        }

        private void OnViewPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(AddTrackViewModel.TrackTitle) ||
                e.PropertyName == nameof(AddTrackViewModel.TrackGenre) ||
                e.PropertyName == nameof(AddTrackViewModel.TrackAlbumName) ||
                e.PropertyName == nameof(AddTrackViewModel.TrackArtist))
            {
                OnCanExecuteChanged();
            }
        }

        public override bool CanExecute(object parameter)
        {
            return !string.IsNullOrEmpty(_addTrackViewModel.TrackTitle)
                && !string.IsNullOrEmpty(_addTrackViewModel.TrackGenre)
                && !string.IsNullOrEmpty(_addTrackViewModel.TrackAlbumName)
                && !string.IsNullOrEmpty(_addTrackViewModel.TrackArtist.Name)
                && (_addTrackViewModel.TrackArtist != null)
                && base.CanExecute(parameter);
        }

        public override async Task ExecuteAsync(object parameter)
        {
            Track track = new Track
            {
                Title = _addTrackViewModel.TrackTitle,
                Genre = _addTrackViewModel.TrackGenre,
                AlbumTitle = _addTrackViewModel.TrackAlbumName,
                ArtistId = _addTrackViewModel.TrackArtist.Id,
                Text = _addTrackViewModel.TrackText,
                Cover = _addTrackViewModel.TrackCover
            };


            try
            {
                await _user.AddTrack(track);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to add track.", "Error",
                   MessageBoxButton.OK, MessageBoxImage.Error);
            }

            _mainMenunavigationService.Navigate();
        }

    }
}
