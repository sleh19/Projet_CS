using System;
using System.ComponentModel.DataAnnotations;
namespace projet.Models
{
    public class Achat
    {
        [Key]
        [Required]
        public int Id { get; set; }
        public  string NomProd { get; set; }
        public float Prix { get; set; }
        public int quantite { get; set; }
        public double Total { get; set; }
    }
}
