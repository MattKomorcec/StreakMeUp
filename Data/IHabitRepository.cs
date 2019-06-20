using Data.Entities;
using System.Threading.Tasks;

namespace Data
{
    public interface IHabitRepository
    {
        // General actions
        void Add<T>(T entity) where T : class;

        void Remove<T>(T entity) where T : class;

        Task<bool> SaveChangesAsync();

        // Habits
        Task<Habit[]> GetAllHabitsAsync();
        
        Task<Habit> GetHabitAsync(int id);
    }
}
