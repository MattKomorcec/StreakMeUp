using Data;
using Data.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HabitsController : ControllerBase
    {
        private readonly IHabitRepository _repository;

        public HabitsController(IHabitRepository repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// This action returns all habits.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<Habit[]>> GetAllHabits()
        {
            try
            {
                var results = await _repository.GetAllHabitsAsync();

                if (!results.Any())
                {
                    return NotFound("No habits yet!");
                }

                return Ok(results);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        /// <summary>
        /// This action returns a single habit.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Habit>> GetHabit(int id)
        {
            try
            {
                var result = await _repository.GetHabitAsync(id);

                if (result == null)
                {
                    return NotFound($"No habit with an id of {id}!");
                }

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        /// <summary>
        /// This action creates a new habit.
        /// </summary>
        /// <param name="habit"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<Habit>> CreateHabit(Habit habit)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest("Something wrong with the model!");
                }

                _repository.Add<Habit>(habit);

                if (await _repository.SaveChangesAsync())
                {
                    return Ok();
                }
                else
                {
                    return BadRequest("Something bad happened!");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
