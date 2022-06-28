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
    public class LoadTracksForArtistCommand : AsyncCommandBase
    {
        private readonly User _user;
        private readonly ArtistInfoViewModel _artistInfoViewModel;
        //private readonly LikedArtistsViewModel _likedArtistsViewModel;

        public LoadTracksForArtistCommand(User user, ArtistInfoViewModel artistInfoViewModel)
        {
            _user = user;
            _artistInfoViewModel = artistInfoViewModel;
            //_likedArtistsViewModel = likedArtistsViewModel;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            try
            {
                //_user.CurrentArtistViewModel = _likedArtistsViewModel.ArtistSelectedItem;
                IEnumerable<Track> tracks = await _user.GetTracksByArtistId(_user.CurrentArtistViewModel.ArtistId);
                _artistInfoViewModel.UpdateTracks(_user, tracks);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load tracks.", "Error",
                   MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
