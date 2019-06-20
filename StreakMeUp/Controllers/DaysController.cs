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
    [Route("api/habits/{habitId:int}/days")]
    public class DaysController : ControllerBase
    {
        private readonly IDayRepository _repository;

        public DaysController(IDayRepository repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// This action returns all days for a habit.
        /// </summary>
        /// <param name="habitId"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<Day[]>> GetAllDays(int habitId)
        {
            try
            {
                var results = await _repository.GetAllDaysAsync(habitId);

                if (!results.Any())
                {
                    return NotFound("No days found!");
                }

                return Ok(results);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        /// <summary>
        /// This action returns a single day for a habit.
        /// </summary>
        /// <param name="habitId"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Day>> GetDay(int habitId, int id)
        {
            try
            {
                var result = await _repository.GetDayAsync(habitId, id);

                if (result == null)
                {
                    return NotFound($"No day with an id of {id} found!");
                }

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
