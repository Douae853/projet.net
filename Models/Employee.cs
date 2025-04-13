namespace projet.net.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string Nom { get; set; } = string.Empty;
        public string Prenom { get; set; } = string.Empty;
        public string Poste { get; set; } = string.Empty;
        public int IdRestaurant { get; set; }
    }
}
