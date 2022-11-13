using Microsoft.EntityFrameworkCore;
using OVAPI.Models;

namespace OVAPI
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<UserModel> Users { get; set; }
    }
}
