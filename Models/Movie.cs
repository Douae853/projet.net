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
        public int id { get; set; }
        public string title { get; set; }
        public string genre { get; set; }
    }
}
