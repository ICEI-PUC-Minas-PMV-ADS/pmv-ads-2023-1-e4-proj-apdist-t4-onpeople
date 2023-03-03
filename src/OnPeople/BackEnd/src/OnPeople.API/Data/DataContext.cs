using Microsoft.EntityFrameworkCore;
using OnPeople.API.Models.Empresas;

namespace OnPeople.API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<Empresa> Empresas { get; set; }
    }
}