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
    public class MoreInformationPlaylistCommand : CommandBase
    {
        private readonly MyPlaylistsViewModel _myPlaylistsViewModel;
        private readonly NavigationService _playlistInfoNavigationService;
        private readonly User _user;

        public MoreInformationPlaylistCommand(MyPlaylistsViewModel myPlaylistsViewModel, NavigationService playlistInfoNavigationService, User user)
        {
            _myPlaylistsViewModel = myPlaylistsViewModel;
            _playlistInfoNavigationService = playlistInfoNavigationService;
            _user = user;
        }

        public override void Execute(object parameter)
        {
            try
            {
                _user.CurrentPlaylistViewModel = _myPlaylistsViewModel.PlaylistSelectedItem;
                _playlistInfoNavigationService.Navigate();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load playlist information.", "Error",
                   MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
