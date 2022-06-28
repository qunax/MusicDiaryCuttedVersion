using MusicDiary.Models;
using MusicDiary.Services;
using MusicDiary.ViewModels;
using System;
using System.Threading.Tasks;
using System.Windows;

namespace MusicDiary.Commands
{
    public class MoreInformationTrackCommand : CommandBase
    {
        private readonly LikedTracksViewModel _likedTracksViewModel;
        private readonly NavigationService _trackInfoNavigationService;
        private readonly User _user;

        public MoreInformationTrackCommand(LikedTracksViewModel likedTracksViewModel, User user, NavigationService trackInfoNavigationService)
        {
            _likedTracksViewModel = likedTracksViewModel;
            _trackInfoNavigationService = trackInfoNavigationService;
            _user = user;
        }


        public override void Execute(object parameter)
        {
            try
            {
                _user.CurrentTrackViewModel = _likedTracksViewModel.TrackSelectedItem;
                _trackInfoNavigationService.Navigate();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Failed to load track information.", "Error",
                   MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
