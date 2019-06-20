using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Data.Entities
{
    public class Habit
    {
        public int HabitId { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 3)]
        public string Title { get; set; }

        [StringLength(250)]
        public string Description { get; set; }

        [Required]
        [Range(1, 5000)]
        public int DaysGoal { get; set; }

        public IEnumerable<Day> Days { get; set; } = new List<Day>();
    }
}
