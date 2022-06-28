using MusicDiary.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicDiary.ViewModels
{
    public class ArtistViewModel : ViewModelBase
    {
        private readonly Artist _artist;



        public string ArtistName => _artist.Name;
        public string InfoAboutArtist => _artist.InfoAbout;

        public string ArtistAvatar => _artist.Avatar;


        public ArtistViewModel(Artist artist)
        {
            _artist = artist;
        }

    }
}
