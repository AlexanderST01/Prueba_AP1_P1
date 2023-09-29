using Microsoft.EntityFrameworkCore;
using Prueba_AP1_P1.Models;

namespace Prueba_AP1_P1.DAL
{
    public class Context: DbContext
    {
        public DbSet<Ingresos> Ingresos { get; set; }
        public Context(DbContextOptions<Context> options): base(options) { }
    }
}
