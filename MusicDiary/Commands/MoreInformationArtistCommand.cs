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
    public class MoreInformationArtistCommand : CommandBase
    {
        private readonly LikedArtistsViewModel _likedArtistsViewModel;
        private readonly NavigationService _artistInfoNavigationService;
        private readonly User _user;

        public MoreInformationArtistCommand(LikedArtistsViewModel likedArtistsViewModel, NavigationService artistInfoNavigationService, User user)
        {
            _likedArtistsViewModel = likedArtistsViewModel;
            _artistInfoNavigationService = artistInfoNavigationService;
            _user = user;
        }


        public override void Execute(object parameter)
        {
            try
            {
                _user.CurrentArtistViewModel = _likedArtistsViewModel.ArtistSelectedItem;
                _artistInfoNavigationService.Navigate();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load artist information.", "Error",
                   MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
