using Data.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Data
{
    public class HabitRepository : IHabitRepository
    {
        private readonly StreakMeUpDbContext _context;

        public HabitRepository(StreakMeUpDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// This method adds an entity to the context.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        public void Add<T>(T entity) where T : class
        {
            _context.Add<T>(entity);
        }

        /// <summary>
        /// This method removes an entity from the context.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        public void Remove<T>(T entity) where T : class
        {
            _context.Remove<T>(entity);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }

        /// <summary>
        /// Returns all habits.
        /// </summary>
        /// <returns></returns>
        public async Task<Habit[]> GetAllHabitsAsync()
        {
            return await _context.Habits
                .Include(h => h.Days)
                .ToArrayAsync();
        }

        /// <summary>
        /// Returns a single habit.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Habit> GetHabitAsync(int id)
        {
            return await _context.Habits
                .Where(h => h.HabitId == id)
                .FirstOrDefaultAsync();
        }
    }
}
