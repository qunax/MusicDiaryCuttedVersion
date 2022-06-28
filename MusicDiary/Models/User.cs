using MusicDiary.Services;
using MusicDiary.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicDiary.Models
{
    public class User
    {

        private readonly IDataService<Track> _trackDataProvider;
        private readonly IDataService<Playlist> _playlistDataProvider;
        private readonly IDataService<Artist> _artistDataProvider;

        public TrackViewModel CurrentTrackViewModel { get; set; }
        public ArtistViewModel CurrentArtistViewModel { get; set; }
        public PlaylistViewModel CurrentPlaylistViewModel { get; set; }

        public User(IDataService<Track> trackDataProvider, IDataService<Playlist> playlistDataProvider, IDataService<Artist> artistDataProvider)
        {
            _trackDataProvider = trackDataProvider;
            _playlistDataProvider = playlistDataProvider;
            _artistDataProvider = artistDataProvider;
        }


        //METHODS OF WORKING WITH TRACKS


        public async Task<IEnumerable<Track>> GetAllTracks()
        {
            return await _trackDataProvider.GetAll();
        }

        public async Task<Track> GetTrackById(int Id)
        {
            return await _trackDataProvider.Get(Id);
        }

        public async Task AddTrack(Track track)
        {
            await _trackDataProvider.Create(track);
        }

        public async Task<bool> DeleteTrack(int id)
        {
            return await _trackDataProvider.Delete(id);
        }

        //METHODS OF WORKING WITH PLAYLISTS


        public async Task<IEnumerable<Playlist>> GetAllPlaylists()
        {
            return await _playlistDataProvider.GetAll();
        }

        public async Task AddPlaylist(Playlist playlist)
        {
            await _playlistDataProvider.Create(playlist);
        }


        //METHODS OF WORKING WITH ARTISTS


        public async Task<IEnumerable<Artist>> GetAllArtists()
        {
            return await _artistDataProvider.GetAll();
        }

        public async Task<Artist> GetArtistById(int Id)
        {
            return await _artistDataProvider.Get(Id);
        }

        public async Task AddArtist(Artist artist)
        {
            await _artistDataProvider.Create(artist);
        }

    }
}
