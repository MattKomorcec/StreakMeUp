using Data.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Data
{
    public class DayRepository : IDayRepository
    {
        private readonly StreakMeUpDbContext _context;

        public DayRepository(StreakMeUpDbContext context)
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
        /// Returns all days.
        /// </summary>
        /// <returns></returns>
        public async Task<Day[]> GetAllDaysAsync(int habitId)
        {
            return await _context.Days
                .Where(d => d.HabitId == habitId)
                .ToArrayAsync();
        }

        /// <summary>
        /// Returns a single day.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Day> GetDayAsync(int habitId, int id)
        {
            return await _context.Days
                .Where(d => d.HabitId == habitId)
                .Where(d => d.DayId == id)
                .FirstOrDefaultAsync();
        }
    }
}
