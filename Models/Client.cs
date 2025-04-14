using Microsoft.EntityFrameworkCore;

namespace project_asp_net.Models
{
    public class ClientContext : DbContext
    {
        public ClientContext(DbContextOptions<ClientContext> options) : base(options)
        {
        }

        public DbSet<Client> Clients { get; set; }
    }

    public class Client
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Email { get; set; }
        public int Téléphone { get; set; }
        public string ville { get; set; }
        public int ProgrammeFidelite { get; set; }
        
    }
}
