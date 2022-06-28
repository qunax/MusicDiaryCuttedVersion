using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicDiary.Models
{
    public class Artist
    {
        public Artist(string name, string infoAbout)
        {
            Name = name;
            InfoAbout = infoAbout;
            Avatar = "artist.png";
        }

        public Artist(string name, string infoAbout, string avatar)
        {
            Name = name;
            InfoAbout = infoAbout;
            Avatar = avatar;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string InfoAbout { get; set; }
        public string Avatar { get; set; }  
    }
}
