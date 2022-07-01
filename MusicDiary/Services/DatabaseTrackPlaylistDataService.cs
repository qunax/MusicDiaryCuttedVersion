using Microsoft.EntityFrameworkCore;
using MusicDiary.DBContexts;
using MusicDiary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicDiary.Services
{
    public class DatabaseTrackPlaylistDataService : IDataService<TrackPlaylist>
    {
        private readonly MusicDiaryDbContextFactory _dbContextFactory;

        public DatabaseTrackPlaylistDataService(MusicDiaryDbContextFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public Task Create(TrackPlaylist entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<TrackPlaylist> Get(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TrackPlaylist>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<TrackPlaylist> Update(int id, TrackPlaylist entity)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Track>> GetTracksByPlaylistId(int Id)
        {
            using (MusicDiaryDbContext context = _dbContextFactory.CreateDbContext())
            {
                List<TrackPlaylist> trackPlaylists = await context.TrackPlaylist.Where(tp => tp.PlaylistId == Id).ToListAsync();
                List<Track> tracks = new List<Track>();
                foreach(TrackPlaylist trackPlaylist in trackPlaylists)
                {
                    tracks.Add(await context.Tracks.Where(t => t.Id == trackPlaylist.TrackId).FirstOrDefaultAsync());
                }
                return tracks;
            }
        }
    }
}
