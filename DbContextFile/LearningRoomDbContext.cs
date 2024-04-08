using Microsoft.EntityFrameworkCore;
using MyLearningRoomBackend.Models;

namespace MyLearningRoomBackend.DbContextFile
{
    public class LearningRoomDbContext : DbContext
    {
        public LearningRoomDbContext(DbContextOptions<LearningRoomDbContext> options) : base(options)
        {

        }

        public DbSet<UserModel> Users { get; set; }
    }
}
