using ApiSmarterByPractice.Data;
using ApiSmarterByPractice.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ApiSmarterByPractice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserScoresController : ControllerBase
    {
        private readonly DataContext _dbContext;

        public UserScoresController(DataContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserScores>>> GetUserScores()
        {
            if(_dbContext.UserScoress == null)
            {
                return NotFound();
            }
            return await _dbContext.UserScoress.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserScores>> GetUserScoresById(int id)
        {
            if (_dbContext.UserScoress == null)
            {
                return NotFound();
            }

            var userScores = await _dbContext.UserScoress.FindAsync(id);

            if (userScores == null)
            {
                return NotFound();
            }
            return userScores;
        }

        [HttpPost]
        public async Task<ActionResult<UserScores>> PostUserScores(UserScores userScores)
        {
            _dbContext.UserScoress.Add(userScores);
            await _dbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetUserScores), new { id = userScores.Id }, userScores);
        }

        [HttpPut]
        public async Task<IActionResult> PutUserScores(int id, UserScores userScores)
        {
            if(id != userScores.Id)
            {
                return BadRequest();
            }
            _dbContext.Entry(userScores).State = EntityState.Modified;

            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserScoresAvailable(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return Ok();
        }

        private bool UserScoresAvailable(int id)
        {
            return (_dbContext.UserScoress?.Any(s => s.Id == id)).GetValueOrDefault();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserScores(int id)
        {
            if (_dbContext.UserScoress == null)
            {
                return NotFound();
            }
            var userScores = await _dbContext.UserScoress.FindAsync(id);

            if (userScores == null)
            {
                return NotFound();
            }
            _dbContext.UserScoress.Remove(userScores);

            await _dbContext.SaveChangesAsync();

            return Ok();
        }
    }
}
