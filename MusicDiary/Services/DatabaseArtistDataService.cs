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
    public class DatabaseArtistDataService : IDataService<Artist>
    {
        private readonly MusicDiaryDbContextFactory _dbContextFactory;

        public DatabaseArtistDataService(MusicDiaryDbContextFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public async Task Create(Artist artist)
        {
            using (MusicDiaryDbContext context = _dbContextFactory.CreateDbContext())
            {
                context.Artists.Add(artist);
                await context.SaveChangesAsync();
            }
        }

        public async Task<bool> Delete(int id)
        {
            using (MusicDiaryDbContext context = _dbContextFactory.CreateDbContext())
            {
                Artist artist = await context.Set<Artist>().FirstOrDefaultAsync((e) => e.Id == id);
                context.Set<Artist>().Remove(artist);
                await context.SaveChangesAsync();

                return true;
            }
        }

        public async Task<Artist> Get(int id)
        {
            using (MusicDiaryDbContext context = _dbContextFactory.CreateDbContext())
            {
                Artist artist = await context.Artists.FirstOrDefaultAsync((e) => e.Id == id);
                return artist;
            }
        }

        public async Task<IEnumerable<Artist>> GetAll()
        {
            using (MusicDiaryDbContext context = _dbContextFactory.CreateDbContext())
            {
                return await context.Artists.ToListAsync();
            }
        }

        public Task<Artist> Update(int id, Artist entity)
        {
            throw new NotImplementedException();
        }
    }
}
