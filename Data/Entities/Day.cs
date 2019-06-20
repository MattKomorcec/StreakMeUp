using System;
using System.ComponentModel.DataAnnotations;

namespace Data.Entities
{
    public class Day
    {
        public int DayId { get; set; }

        [Required]
        public int HabitId { get; set; }

        [Required]
        public DateTime Date { get; set; } = DateTime.Today;

        public string Description { get; set; }

        public bool Complete { get; set; } = false;
    }
}
