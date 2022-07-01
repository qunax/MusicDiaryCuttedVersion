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
    public class DeletePlaylistCommand : AsyncCommandBase
    {
        private readonly User _user;
        private readonly MyPlaylistsViewModel _myPlaylistsViewModel;
        private readonly NavigationService _myPlaylistNavigationService;

        public DeletePlaylistCommand(User user, MyPlaylistsViewModel myPlaylistsViewModel, NavigationService myPlaylistNavigationService)
        {
            _user = user;
            _myPlaylistsViewModel = myPlaylistsViewModel;
            _myPlaylistNavigationService = myPlaylistNavigationService;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            _user.CurrentPlaylistViewModel = _myPlaylistsViewModel.PlaylistSelectedItem;
            try
            {
                bool result = await _user.DeletePlaylist(_user.CurrentPlaylistViewModel.PlaylistId);
                if (result)
                {
                    MessageBox.Show("Playlist was deleted successfully.", "Success",
                   MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("Failed to delete playlist.", "Error",
                   MessageBoxButton.OK, MessageBoxImage.Error);
                }
                _myPlaylistNavigationService.Navigate();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to delete playlist.", "Error",
                   MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
