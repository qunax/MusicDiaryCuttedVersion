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
    public class DatabaseTrackDataService : IDataService<Track>
    {
        private readonly MusicDiaryDbContextFactory _dbContextFactory;

        public DatabaseTrackDataService(MusicDiaryDbContextFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public async Task Create(Track track)
        {
            using(MusicDiaryDbContext context = _dbContextFactory.CreateDbContext())
            {
                context.Tracks.Add(track);
                await context.SaveChangesAsync();
            }
        }

        public async Task<bool> Delete(int id)
        {
            using (MusicDiaryDbContext context = _dbContextFactory.CreateDbContext())
            {
                Track track = await context.Set<Track>().FirstOrDefaultAsync((e) => e.Id == id);
                context.Set<Track>().Remove(track);
                await context.SaveChangesAsync();

                return true;
            }
        }

        public async Task<Track> Get(int id)
        {
            using (MusicDiaryDbContext context = _dbContextFactory.CreateDbContext())
            {
                Track track = await context.Tracks.FirstOrDefaultAsync((e) => e.Id == id);
                return track;
            }
        }

        public async Task<IEnumerable<Track>> GetAll()
        {
            using (MusicDiaryDbContext context = _dbContextFactory.CreateDbContext())
            {
                return await context.Tracks.ToListAsync();
            }
        }

        public Task<Track> Update(int id, Track entity)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Track>> GetTracksByArtistId(int id)
        {
            using (MusicDiaryDbContext context = _dbContextFactory.CreateDbContext())
            {
                return await context.Tracks.Where(t => t.ArtistId == id).ToListAsync();
            }
        }
    }
}
