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
    public class DatabasePlaylistDataService : IDataService<Playlist>
    {
        private readonly MusicDiaryDbContextFactory _dbContextFactory;

        public DatabasePlaylistDataService(MusicDiaryDbContextFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public async Task Create(Playlist playlist)
        {
            using (MusicDiaryDbContext context = _dbContextFactory.CreateDbContext())
            {
                context.Playlists.Add(playlist);
                await context.SaveChangesAsync();
            }
        }

        public async Task<bool> Delete(int id)
        {
            using (MusicDiaryDbContext context = _dbContextFactory.CreateDbContext())
            {
                Playlist playlist = await context.Set<Playlist>().FirstOrDefaultAsync((e) => e.Id == id);
                context.Set<Playlist>().Remove(playlist);
                await context.SaveChangesAsync();

                return true;
            }
        }

        public Task<Playlist> Get(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Playlist>> GetAll()
        {
            using (MusicDiaryDbContext context = _dbContextFactory.CreateDbContext())
            {
                return await context.Playlists.ToListAsync();
            }
        }

        public Task<Playlist> Update(int id, Playlist entity)
        {
            throw new NotImplementedException();
        }
    }
}
