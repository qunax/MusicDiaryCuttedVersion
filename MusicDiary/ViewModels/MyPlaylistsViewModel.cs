using MusicDiary.Commands;
using MusicDiary.Models;
using MusicDiary.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MusicDiary.ViewModels
{
    public class MyPlaylistsViewModel : ViewModelBase
    {
        private readonly ObservableCollection<PlaylistViewModel> _playlists;

        public IEnumerable<PlaylistViewModel> Playlists => _playlists;

        public ICommand BackCommand { get; }
        public ICommand MakePlaylistCommand { get; }


        public MyPlaylistsViewModel(NavigationService homePageNavigationSErvice, NavigationService makePlaylistNavigationService)
        {
            

            BackCommand = new NavigateCommand(homePageNavigationSErvice);
            MakePlaylistCommand = new NavigateCommand(makePlaylistNavigationService);
        }
    }
}
