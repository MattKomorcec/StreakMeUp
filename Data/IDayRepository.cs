using Data.Entities;
using System.Threading.Tasks;

namespace Data
{
    public interface IDayRepository
    {
        // General actions
        void Add<T>(T entity) where T : class;

        void Remove<T>(T entity) where T : class;

        Task<bool> SaveChangesAsync();

        // Habits
        Task<Day[]> GetAllDaysAsync(int habitId);

        Task<Day> GetDayAsync(int habitId, int id);
    }
}
