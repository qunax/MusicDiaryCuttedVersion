using MusicDiary.Services;
using MusicDiary.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicDiary.Commands
{
    public class MakeNewPlaylistCommand : CommandBase
    {
        private MakePlaylistViewModel _makePlaylistViewModel;
        private readonly NavigationService _mainMenuNavigationService;

        public MakeNewPlaylistCommand(MakePlaylistViewModel makePlaylistViewModel, NavigationService mainMenuNavigationService)
        {
            _makePlaylistViewModel = makePlaylistViewModel;
            _makePlaylistViewModel.PropertyChanged += OnViewPropertyChanged;
            _mainMenuNavigationService = mainMenuNavigationService;
        }

        private void OnViewPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if(e.PropertyName == nameof(MakePlaylistViewModel.PlaylistTitle))
            {
                OnCanExecuteChanged();
            }
        }
        public override bool CanExecute(object parameter)
        {
            return !string.IsNullOrEmpty(_makePlaylistViewModel.PlaylistTitle)
                && base.CanExecute(parameter);
        }

        public override void Execute(object parameter)
        {
            _mainMenuNavigationService.Navigate();
        }
    }
}
