using ApiSmarterByPractice.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiSmarterByPractice.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        public DbSet<UserScores> UserScoress { get; set; }
    }
}
