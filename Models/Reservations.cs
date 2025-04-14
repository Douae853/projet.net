using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace project_asp_net.Models
{
    public class ReservationContext : DbContext
    {
        public ReservationContext(DbContextOptions<ReservationContext> options) : base(options)
        {
        }

        public DbSet<Reservation> Reservations { get; set; }
    }

    [Table("Réservation")]
    public class Reservation
    {
        [Key]
        [Column("id_reservation")]
        public int Id { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public TimeSpan Heure { get; set; }

        [Required]
        [Column("nombre_personnes")]
        public int NombrePersonnes { get; set; }

        [Column("service_special")]
        [MaxLength(100)]
        public string? ServiceSpecial { get; set; }

        [Required]
        [Column("status")]
        [MaxLength(50)]
        public string Status { get; set; } = "en attente";


        [Column("Nom_utilisateur")]
        public String NomUtilisateur { get; set; }


        [Column("id_table")]
        public int IdTable { get; set; }



    }


}
