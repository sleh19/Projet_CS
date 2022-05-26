using System;
using System.ComponentModel.DataAnnotations;
namespace projet.Models
{
    public class Client
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public int NumCin { get; set; }
        [Required]
        public string Prenom { get; set; }
        [Required]
        public string Nom { get; set; }
        [Required]
        public string TypeClient { get; set; }
        [Required]
        public string Adresse { get; set; }
        [Required]
        public int NumPhone { get; set; }
    }
}
