using MusicDiary.Models;
using MusicDiary.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;

namespace MusicDiary.Commands
{
    public class LoadTracksCommand : AsyncCommandBase
    {
        private readonly User _user;
        private readonly LikedTracksViewModel _likedTracksViewModel;
        private readonly MakePlaylistViewModel _makePlaylistViewModel;

        public LoadTracksCommand(User user, LikedTracksViewModel likedTracksViewModel)
        {
            _user = user;
            _likedTracksViewModel = likedTracksViewModel;
        }

        public LoadTracksCommand(User user, MakePlaylistViewModel makePlaylistViewModel)
        {
            _user = user;
            _makePlaylistViewModel = makePlaylistViewModel;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            try
            {
                IEnumerable<Track> tracks = await _user.GetAllTracks();
                if (_likedTracksViewModel != null)
                {
                    _likedTracksViewModel.UpdateTracks(_user, tracks);
                }
                else if (_makePlaylistViewModel != null)
                {
                    _makePlaylistViewModel.UpdateTracks(_user, tracks);
                }
                
            }
            catch (Exception)
            {
                MessageBox.Show("Failed to load tracks.", "Error",
                   MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
