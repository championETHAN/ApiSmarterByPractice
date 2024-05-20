using ApiSmarterByPractice.Data;
using ApiSmarterByPractice.DTO;
using ApiSmarterByPractice.Interfaces;
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
        private readonly IUserScoresRepository _userScoresRepository;
        private readonly DataContext _context;
        public UserScoresController(IUserScoresRepository userScoresRepository, DataContext context)
        {
            _userScoresRepository = userScoresRepository;
            _context = context;
        }


        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<UserScores>))]

        public async Task<IActionResult> GetUserScoress()
        {
            var userScores = _userScoresRepository.GetUserScoress();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(await userScores);
        }

        [HttpGet("userScoresId")]
        [ProducesResponseType(200, Type = typeof(UserScores))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetUserScores(int userScoresId)
        {

            if (!_userScoresRepository.UserScoresExists(userScoresId))
                return NotFound();

            var userScores = _userScoresRepository.GetUserScores(userScoresId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(await userScores);
            //[HttpGet("{id}")]
            //public async Task<ActionResult<UserScores>> GetUserScoresById(int id)
            //{
            //    if (_context.UserScoress == null)
            //    {
            //        return NotFound();
            //    }

            //    var userScores = await _context.UserScoress.FindAsync(id);

            //    if (userScores == null)
            //    {
            //        return NotFound();
            //    }
            //    return userScores;
            //}
        }

        [HttpPost]
        public IActionResult CreateUserScores(UserScoresDTO userScoresDTO, int ReactionTimeDTO, int SequenceMemoryDTO, int TimeDTO
                                                            , int AimTrainerDTO, int NumberMemoryDTO
                                                            , int VerbalMemoryDTO, int ChimpTestDTO
                                                            , int VisualMemoryDTO, int TypingTestDTO)
        {
            var InputData = new UserScoresDTO() 
            {

                ReactionTime = ReactionTimeDTO,
                SequenceMemory = SequenceMemoryDTO,
                AimTrainer = AimTrainerDTO,
                NumberMemory = NumberMemoryDTO,
                VerbalMemory = VerbalMemoryDTO,
                ChimpTest = ChimpTestDTO,
                VisualMemory = VisualMemoryDTO,
                TypingTest = TypingTestDTO,
                Time = TimeDTO
            };


            var userscoreEntity = new UserScores()
            {
                InputDate = DateTime.Now,
                ReactionTime = InputData.ReactionTime,
                SequenceMemory = InputData.SequenceMemory,
                AimTrainer = InputData.AimTrainer,
                NumberMemory = InputData.NumberMemory,
                VerbalMemory = InputData.VerbalMemory,
                ChimpTest = InputData.ChimpTest,
                VisualMemory = InputData.VisualMemory,
                TypingTest = InputData.TypingTest,
                Time = InputData.Time

            };
            _context.UserScoress.Add(userscoreEntity);
            _context.SaveChanges();

            return Ok(userscoreEntity);
            //[HttpPost]
            //public async Task<ActionResult<UserScores>> PostUserScores(UserScores userScores)
            //{
            //    _context.UserScoress.Add(userScores);
            //    await _context.SaveChangesAsync();

            //    return CreatedAtAction(nameof(GetUserScores), new { id = userScores.Id }, userScores);
            //}
        }


        [HttpPut]
        public async Task<IActionResult> PutUserScores(UserScoresDTO userScoresDTO, int IdDTO, int ReactionTimeDTO, int SequenceMemoryDTO, int TimeDTO
                                                            , int AimTrainerDTO, int NumberMemoryDTO
                                                            , int VerbalMemoryDTO, int ChimpTestDTO
                                                            , int VisualMemoryDTO, int TypingTestDTO)
        {
            var InputData = new UserScoresDTO()
            {
                ReactionTime = ReactionTimeDTO,
                SequenceMemory = SequenceMemoryDTO,
                AimTrainer = AimTrainerDTO,
                NumberMemory = NumberMemoryDTO,
                VerbalMemory = VerbalMemoryDTO,
                ChimpTest = ChimpTestDTO,
                VisualMemory = VisualMemoryDTO,
                TypingTest = TypingTestDTO,
                Time = TimeDTO
            };


        var userscoreEntity = new UserScores()
        {
            Id = IdDTO,
            InputDate = DateTime.Now,
            ReactionTime = InputData.ReactionTime,
            SequenceMemory = InputData.SequenceMemory,
            AimTrainer = InputData.AimTrainer,
            NumberMemory = InputData.NumberMemory,
            VerbalMemory = InputData.VerbalMemory,
            ChimpTest = InputData.ChimpTest,
            VisualMemory = InputData.VisualMemory,
            TypingTest = InputData.TypingTest,
            Time = InputData.Time

        };

        var EntryInDbById = _context.UserScoress.Entry(userscoreEntity).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if(!UserScoresAvailable(IdDTO))
                {
                    return NotFound("This Id isnt found");
                }
                else 
                {
                    throw;
                }
            }
            return Ok(userscoreEntity);
        }

        private bool UserScoresAvailable(int id)
        {
            return (_context.UserScoress?.Any(s => s.Id == id)).GetValueOrDefault();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserScores(int id)
        {
            if (_context.UserScoress == null)
            {
                return NotFound();
            }
            var userScores = await _context.UserScoress.FindAsync(id);

            if (userScores == null)
            {
                return NotFound();
            }
            _context.UserScoress.Remove(userScores);

            await _context.SaveChangesAsync();

            return Ok();
        }
    }

}
