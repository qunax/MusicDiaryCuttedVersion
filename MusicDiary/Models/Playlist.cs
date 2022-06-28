using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicDiary.Models
{
    public class Playlist
    {
        private readonly List<Track> _tracks;



        public int Id { get; set; }
        public string Name { get; set; }
        public string Cover { get; set; }

        


        
    }
}
