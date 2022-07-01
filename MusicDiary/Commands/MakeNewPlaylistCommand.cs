using MusicDiary.Models;
using MusicDiary.Services;
using MusicDiary.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows;

namespace MusicDiary.Commands
{
    public class MakeNewPlaylistCommand : AsyncCommandBase
    {
        private readonly User _user;
        private MakePlaylistViewModel _makePlaylistViewModel;
        private readonly NavigationService _mainMenuNavigationService;
        private ObservableCollection<TrackViewModel> _selectedTracks;



        public MakeNewPlaylistCommand(User user, MakePlaylistViewModel makePlaylistViewModel, NavigationService mainMenuNavigationService)
        {
            _selectedTracks = new ObservableCollection<TrackViewModel>();

            _user = user;
            _makePlaylistViewModel = makePlaylistViewModel;
            _makePlaylistViewModel.PropertyChanged += OnViewPropertyChanged;
            _mainMenuNavigationService = mainMenuNavigationService;

            
        }

        private void OnViewPropertyChanged(object sender, PropertyChangedEventArgs e)
        {


            if(e.PropertyName == nameof(MakePlaylistViewModel.PlaylistTitle) ||
                e.PropertyName == nameof(MakePlaylistViewModel.SelectedTrackViewModel))
            {
                OnCanExecuteChanged();
            }
        }
        public override bool CanExecute(object parameter)
        {
            return !string.IsNullOrEmpty(_makePlaylistViewModel.PlaylistTitle)
                && base.CanExecute(parameter);
        }


        public override async Task ExecuteAsync(object parameter)
        {


            Playlist playlist = new Playlist
            {
                Name = _makePlaylistViewModel.PlaylistTitle,
                Cover = _makePlaylistViewModel.PlaylistCover,
                Tracks = new List<TrackPlaylist>()
            };

            foreach (TrackViewModel trackVM in _makePlaylistViewModel.Tracks)
            {
                if (trackVM.IsSelected)
                {
                    Track track = await _user.GetTrackById(trackVM.Id);
                    TrackPlaylist connector = new TrackPlaylist
                    {
                        TrackId = track.Id,
                        PlaylistId = playlist.Id
                    };

                    playlist.Tracks.Add(connector);
                }
            }

            try
            {
                await _user.AddPlaylist(playlist);


            }
            catch(Exception ex)
            {
                MessageBox.Show("Failed to add playlist.", "Error",
                   MessageBoxButton.OK, MessageBoxImage.Error);
            }

            _mainMenuNavigationService.Navigate();
        }
    }
}
