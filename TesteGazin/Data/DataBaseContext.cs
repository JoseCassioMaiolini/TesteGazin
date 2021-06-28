using Microsoft.EntityFrameworkCore;
using TesteGazinAPI.Models;

namespace TesteGazinAPI.Data
{
    public class DataBaseContext : DbContext
    {
        public DataBaseContext()
        {
        }

        public DataBaseContext(DbContextOptions<DataBaseContext> options)
            : base(options)
        {
        }

        public DbSet<DesenvolvedoresModel> DesenvolvedorItems { get; set; }
    }
}