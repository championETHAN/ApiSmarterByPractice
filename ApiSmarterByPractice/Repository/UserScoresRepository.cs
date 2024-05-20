using ApiSmarterByPractice.Data;
using ApiSmarterByPractice.DTO;
using ApiSmarterByPractice.Interfaces;
using ApiSmarterByPractice.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiSmarterByPractice.Repository
{
    public class UserScoresRepository : IUserScoresRepository
    {
        private readonly DataContext _context;

        public UserScoresRepository(DataContext context)
        {
            _context = context;
            //this is the context...Where the UserScores are stored in the server
        }

        public async Task<ICollection<UserScores>> GetUserScoress()
        {
            return await _context.UserScoress.OrderBy(d => d.InputDate).ToListAsync();
        }

        public async Task<UserScores> GetUserScores(int id)
        {
            return await _context.UserScoress.Where(u => u.Id == id).FirstOrDefaultAsync();
        }

        public bool UserScoresExists(int userScoresId)
        {
            return _context.UserScoress.Any(i => i.Id == userScoresId);
        }
        public bool UserScoresAvailable(int id)
        {
            return (_context.UserScoress?.Any(s => s.Id == id)).GetValueOrDefault();
        }
    }
}
