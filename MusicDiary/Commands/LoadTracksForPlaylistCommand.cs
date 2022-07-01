using MusicDiary.Models;
using MusicDiary.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;

namespace MusicDiary.Commands
{
    public class LoadTracksForPlaylistCommand : AsyncCommandBase
    {
        private readonly User _user;
        private readonly PlaylistInfoViewModel _playlistInfoViewModel;

        public LoadTracksForPlaylistCommand(User user, PlaylistInfoViewModel playlistInfoViewModel)
        {
            _user = user;
            _playlistInfoViewModel = playlistInfoViewModel;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            try
            {
                List<Track> tracks = await _user.GetTracksByPlaylistId(_playlistInfoViewModel.PlaylistViewModel.PlaylistId);
                _playlistInfoViewModel.UpdateTracks(_user, tracks);
            }
            catch(Exception ex)
            {
                MessageBox.Show("Failed to load tracks.", "Error",
                   MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
