using MusicDiary.Models;

namespace MusicDiary.ViewModels
{
    public class ArtistViewModel : ViewModelBase
    {
        private readonly Artist _artist;


        public int ArtistId => _artist.Id;
        public string ArtistName => _artist.Name;
        public string InfoAboutArtist => _artist.InfoAbout;

        public string ArtistAvatar => _artist.Avatar;


        public ArtistViewModel(Artist artist)
        {
            _artist = artist;
        }

    }
}
