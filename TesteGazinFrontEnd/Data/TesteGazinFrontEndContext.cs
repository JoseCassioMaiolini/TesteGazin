using Microsoft.EntityFrameworkCore;

namespace TesteGazinFrontEnd.Data
{
    public class TesteGazinFrontEndContext : DbContext
    {
        public TesteGazinFrontEndContext (DbContextOptions<TesteGazinFrontEndContext> options)
            : base(options)
        {
        }

        public DbSet<TesteGazinFrontEnd.Models.Desenvolvedor> Desenvolvedor { get; set; }
    }
}
