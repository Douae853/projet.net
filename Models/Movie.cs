using Microsoft.EntityFrameworkCore;

namespace project_asp_net.Models
{
    public class MovieContext : DbContext
    {
        public MovieContext(DbContextOptions<MovieContext> options) : base(options)
        {
        }

        public DbSet<Movie> Movies { get; set; }
    }

    public class Movie
    {
        public int id { get; set; }       // Clé primaire
        public string title { get; set; } // Titre du film
        public string genre { get; set; } // Genre du film
    }
}
