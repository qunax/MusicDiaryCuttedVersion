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
    public class DeleteArtistCommand : AsyncCommandBase
    {
        private readonly LikedArtistsViewModel _likedArtistsViewModel;
        private readonly NavigationService _likedArtistsNavigationService;
        private readonly User _user;

        public DeleteArtistCommand(LikedArtistsViewModel likedArtistsViewModel, NavigationService likedArtistsNavigationService, User user)
        {
            _likedArtistsViewModel = likedArtistsViewModel;
            _likedArtistsNavigationService = likedArtistsNavigationService;
            _user = user;
        }

        public async override Task ExecuteAsync(object parameter)
        {
            _user.CurrentArtistViewModel = _likedArtistsViewModel.ArtistSelectedItem;
            try
            {
                bool result = await _user.DeleteArtist(_user.CurrentArtistViewModel.ArtistId);
                if (result)
                {
                    MessageBox.Show("Artist was deleted successfully.", "Success",
                   MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("Failed to delete artist.", "Error",
                   MessageBoxButton.OK, MessageBoxImage.Error);
                }
                _likedArtistsNavigationService.Navigate();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to delete artist.", "Error",
                   MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
