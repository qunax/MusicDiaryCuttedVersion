using MusicDiary.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace MusicDiary.ViewModels
{
    public class PlaylistViewModel : ViewModelBase
    {
        private readonly User _user;
        private readonly Playlist _playlist;
        private readonly ObservableCollection<TrackViewModel> _tracks;


        public ObservableCollection<TrackViewModel> Tracks => _tracks;
        public ICollection<TrackPlaylist> tracksPlaylists => _playlist.Tracks;


        public int PlaylistId => _playlist.Id;
        public string PlaylistName => _playlist.Name;
        public string PlaylistCover => _playlist?.Cover;

        public PlaylistViewModel(User user, Playlist playlist)
        {
            _tracks = new ObservableCollection<TrackViewModel>();
            _user = user;
            _playlist = playlist;
            GetTracks();
        }

        private async Task GetTracks()
        {
            foreach(TrackPlaylist trackPlaylist in _playlist.Tracks)
            {
                Track track = await _user.GetTrackById(trackPlaylist.TrackId);
                _tracks.Add(new TrackViewModel(_user, track));
            }
        }
    }
}
