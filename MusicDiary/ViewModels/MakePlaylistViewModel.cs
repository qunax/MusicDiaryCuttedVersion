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
    public class MakePlaylistViewModel : ViewModelBase
    {
        private readonly ObservableCollection<TrackViewModel> _tracks;

        public IEnumerable<TrackViewModel> Tracks => _tracks;


        private string _playlistCover;
        public string PlaylistCover
        {
            get
            {
                return _playlistCover;
            }
            set
            {
                _playlistCover = value;
                OnPropertyChanged(nameof(PlaylistCover));
            }
        }

        private string _playlistTitle;
        public string PlaylistTitle
        {
            get
            {
                return _playlistTitle;
            }
            set
            {
                _playlistTitle = value;
                OnPropertyChanged(nameof(PlaylistTitle));
            }
        }


        public ICommand AddCover { get; }
        public ICommand CancelCommand { get; }
        public ICommand SubmitCommand { get; }

        public MakePlaylistViewModel(NavigationService mainMenuNavigationService)
        {
            



            CancelCommand = new NavigateCommand(mainMenuNavigationService);
            SubmitCommand = new MakeNewPlaylistCommand(this, mainMenuNavigationService);
        }
    }
}
