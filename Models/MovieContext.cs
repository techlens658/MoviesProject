using Microsoft.EntityFrameworkCore;
namespace MoviesProject.Models
{
    public class MovieContext : DbContext
    {
        public MovieContext(DbContextOptions<MovieContext> options) : base(options)
        { }
        public DbSet<Movie> Movies { get; set; } = null!;
        public DbSet<Artist> Artists { get; set; } = null!;
    }
}
