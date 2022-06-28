using MusicDiary.Models;
using MusicDiary.Services;
using MusicDiary.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MusicDiary.Commands
{
    public class DeleteTrackCommand : AsyncCommandBase
    {
        private readonly LikedTracksViewModel _likedTracksViewModel;
        private readonly NavigationService _likedTracksNavigationService;
        private readonly User _user;

        public DeleteTrackCommand(LikedTracksViewModel likedTracksViewModel, NavigationService likedTracksNavigationService, User user)
        {
            _likedTracksViewModel = likedTracksViewModel;
            _likedTracksNavigationService = likedTracksNavigationService;
            _user = user;
        }

        public async override Task ExecuteAsync(object parameter)
        {
            _user.CurrentTrackViewModel = _likedTracksViewModel.TrackSelectedItem;
            try
            {
                bool result = await _user.DeleteTrack(_user.CurrentTrackViewModel.Id);
                if (result)
                {
                    MessageBox.Show("Track was deleted successfully.", "Success",
                   MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("Failed to delete track.", "Error",
                   MessageBoxButton.OK, MessageBoxImage.Error);
                }
                _likedTracksNavigationService.Navigate();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Failed to delete track.", "Error",
                   MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
