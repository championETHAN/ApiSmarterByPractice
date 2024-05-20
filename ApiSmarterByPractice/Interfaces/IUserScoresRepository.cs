using ApiSmarterByPractice.DTO;
using ApiSmarterByPractice.Models;
using Microsoft.AspNetCore.Mvc;

namespace ApiSmarterByPractice.Interfaces
{
    public interface IUserScoresRepository
    {
        Task<ICollection<UserScores>> GetUserScoress();
        //returns all userScores
        Task<UserScores> GetUserScores(int id);
        bool UserScoresExists(int userScoresId);


    }
}
