using MusicDiary.Models;
using MusicDiary.Services;
using MusicDiary.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MusicDiary.Commands
{
    public class AddNewArtistCommand : AsyncCommandBase
    {
        private readonly User _user;
        private AddArtistViewModel _addArtistViewModel;
        private readonly NavigationService _mainMenuNavigationService;



        public AddNewArtistCommand(User user, AddArtistViewModel addArtistViewModel, NavigationService mainMenuNavigationService)
        {
            _user = user;
            _addArtistViewModel = addArtistViewModel;
            _addArtistViewModel.PropertyChanged += OnViewPropertyChanged;
            _mainMenuNavigationService = mainMenuNavigationService;
        }

        private void OnViewPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(AddArtistViewModel.ArtistName))
            {
                OnCanExecuteChanged();
            }
        }

        public override bool CanExecute(object parameter)
        {
            return !string.IsNullOrEmpty(_addArtistViewModel.ArtistName)
                && base.CanExecute(parameter);
        }


        public override async Task ExecuteAsync(object parameter)
        {

            Artist artist = new Artist
            {
                Name = _addArtistViewModel.ArtistName,
                InfoAbout = _addArtistViewModel.ArtistInfo,
                Avatar = _addArtistViewModel.ArtistAvatar
            };

            

            try
            {
                await _user.AddArtist(artist);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to add artist.", "Error",
                   MessageBoxButton.OK, MessageBoxImage.Error);
            }

            _mainMenuNavigationService.Navigate();
        }
    }
}
