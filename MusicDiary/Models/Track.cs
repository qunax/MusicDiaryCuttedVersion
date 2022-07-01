using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicDiary.Models
{
    public class Track
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public string AlbumTitle { get; set; }
        public int ArtistId { get; set; }
        public Artist Artist { get; set; }
        public string Text { get; set; }

        public string Cover { get; set; }

        //public ICollection<TrackPlaylist> Playlists { get; set; }
        public ICollection<TrackPlaylist> Playlists { get; set; }

        
        public Track()
        {
            Playlists = new HashSet<TrackPlaylist>();
        }

    }
}
