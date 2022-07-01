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
    public class LoadPlaylistsCommand : AsyncCommandBase
    {
        private readonly User _user;
        private readonly MyPlaylistsViewModel _myPlaylistsViewModel;


        public LoadPlaylistsCommand(User user, MyPlaylistsViewModel myPlaylistsViewModel)
        {
            _user = user;
            _myPlaylistsViewModel = myPlaylistsViewModel;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            try
            {
                IEnumerable<Playlist> playlists = await _user.GetAllPlaylists();
                _myPlaylistsViewModel.UpdatePlaylists(playlists);
            }
            catch (Exception)
            {
                MessageBox.Show("Failed to load artists.", "Error",
                   MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
