using System.Collections.Generic;

namespace MusicDiary.Models
{
    public class Playlist
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Cover { get; set; }

        public ICollection<TrackPlaylist> Tracks { get; set; }


        public Playlist()
        {
            Tracks = new HashSet<TrackPlaylist>();
        }
    }
}
