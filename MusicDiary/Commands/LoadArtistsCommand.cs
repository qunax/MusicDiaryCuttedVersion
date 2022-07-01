using MusicDiary.Models;
using MusicDiary.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;

namespace MusicDiary.Commands
{
    public class LoadArtistsCommand : AsyncCommandBase
    {
        private readonly User _user;
        private readonly LikedArtistsViewModel _likedArtistsViewModel;


        public LoadArtistsCommand(User user, LikedArtistsViewModel likedArtistsViewModel)
        {
            _user = user;
            _likedArtistsViewModel = likedArtistsViewModel;
        }


        public override async Task ExecuteAsync(object parameter)
        {
            try
            {
                IEnumerable<Artist> artists = await _user.GetAllArtists();
                _likedArtistsViewModel.UpdateArtists(artists);
            }
            catch (Exception)
            {
                MessageBox.Show("Failed to load artists.", "Error",
                   MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
