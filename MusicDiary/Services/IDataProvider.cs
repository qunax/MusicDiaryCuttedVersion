using System.Collections.Generic;
using System.Threading.Tasks;

namespace MusicDiary.Services
{
    public interface IDataService<T>
    {
        Task<IEnumerable<T>> GetAll();

        Task<T> Get(int id);

        Task Create(T entity);

        Task<T> Update(int id, T entity);

        Task<bool> Delete(int id);
    }
}
