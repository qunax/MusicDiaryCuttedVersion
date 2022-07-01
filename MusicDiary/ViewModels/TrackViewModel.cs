using MusicDiary.Commands;
using MusicDiary.Models;
using MusicDiary.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MusicDiary.ViewModels
{
    public class TrackViewModel : ViewModelBase
    {
        private readonly User _user;
        private Artist _artist;
        private readonly Track _track;


        public int Id => _track.Id;
        public string TrackName => _track.Title;
        public string TrackGenre => _track.Genre;
        public string AlbumTitle => _track.AlbumTitle;
        public string ArtistOfTrack => _artist.Name;
        public string TrackText => _track.Text;
        public string TrackCover => _track.Cover;


        private bool _isSelected;
        public bool IsSelected
        {
            get
            {
                return _isSelected;
            }
            set
            {
                _isSelected = value;
                OnPropertyChanged(nameof(IsSelected));
            }
        }


        public TrackViewModel(User user,Track track)
        {
            _user = user;
            _track = track;
            IsSelected = false;
            GetArtist();
        }

        private async Task GetArtist()
        {
            _artist = await _user.GetArtistById(_track.ArtistId);
        }
    }
}
