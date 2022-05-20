using System;
using System.ComponentModel.DataAnnotations;
namespace projet.Models
{
    public class Produit
    {
        
        [Required]
        public int Id { get; set; }       
        [Required]
        public string Nom { get; set; }
        [Required]
        public int Quantite { get; set; }
        [Required]
        public double PrixUnitaire { get; set; }
        [Required]
        public string Marque { get; set; }

    }
}
