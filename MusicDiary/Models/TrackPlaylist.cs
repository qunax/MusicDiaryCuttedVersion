

namespace MusicDiary.Models
{
    public class TrackPlaylist
    {
        public int Id { get; set; }

        public int TrackId { get; set; }
        public Track Track { get; set; }
        public int PlaylistId { get; set; }
        public Playlist Playlist { get; set; }
    }
}
