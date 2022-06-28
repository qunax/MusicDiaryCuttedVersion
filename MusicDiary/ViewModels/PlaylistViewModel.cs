using MusicDiary.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicDiary.ViewModels
{
    public class PlaylistViewModel : ViewModelBase
    {
        private readonly Playlist _playlist;

        private readonly ObservableCollection<Track> _tracks;

        public string PlaylistName => _playlist.Name;
        public string PlaylistCover => _playlist?.Cover;

        public PlaylistViewModel(Playlist playlist)
        {
            _playlist = playlist;
        }
    }
}
