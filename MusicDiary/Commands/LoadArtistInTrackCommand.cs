using MusicDiary.Models;
using MusicDiary.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;

namespace MusicDiary.Commands
{
    public class LoadArtistInTrackCommand : AsyncCommandBase
    {
        private readonly User _user;
        private readonly AddTrackViewModel _addTrackViewModel;

        public LoadArtistInTrackCommand(User user, AddTrackViewModel addTrackViewModel)
        {
            _user = user;
            _addTrackViewModel = addTrackViewModel;
        }


        public override async Task ExecuteAsync(object parameter)
        {
            try
            {
                IEnumerable<Artist> artists = await _user.GetAllArtists();
                _addTrackViewModel.UpdateArtists(artists);
            }
            catch (Exception)
            {
                MessageBox.Show("Failed to load artists.", "Error",
                   MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
