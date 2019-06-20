using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;

namespace Data
{
    public class StreakMeUpDbContext : DbContext
    {
        private readonly IConfiguration _config;

        public StreakMeUpDbContext(DbContextOptions options, IConfiguration config) : base(options)
        {
            _config = config;
            // This is needed, as sometimes it fails to create a database
            Database.EnsureCreated();
        }

        public DbSet<Habit> Habits { get; set; }
        public DbSet<Day> Days { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_config.GetConnectionString("StreakMeUp"));
        }

        protected override void OnModelCreating(ModelBuilder bldr)
        {
            bldr.Entity<Habit>()
              .HasData(new
              {
                  HabitId = 1,
                  Title = "First Habit",
                  Description = "No description yet",
                  DaysGoal = 25
              });

            bldr.Entity<Day>()
              .HasData(new
              {
                  DayId = 1,
                  HabitId = 1,
                  Description = "First day of many",
                  Complete = false,
                  Date = DateTime.Today
              });
        }
    }
}
