using MusicDiary.Models;
using MusicDiary.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MusicDiary.Commands
{
    public class LoadTracksCommand : AsyncCommandBase
    {
        private readonly User _user;
        private readonly LikedTracksViewModel _likedTracksViewModel;

        public LoadTracksCommand(User user, LikedTracksViewModel likedTracksViewModel)
        {
            _user = user;
            _likedTracksViewModel = likedTracksViewModel;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            try
            {
                IEnumerable<Track> tracks = await _user.GetAllTracks();
                _likedTracksViewModel.UpdateTracks(_user, tracks);
            }
            catch (Exception)
            {
                MessageBox.Show("Failed to load tracks.", "Error",
                   MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
