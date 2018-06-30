using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Wine
    {
        [Key]
        public int VinhoID { get; set; }

        [Required]
        public string NomeVinho { get; set; }

        [Required]
        public double Valor { get; set; }

        public float Score { get; set; }
        
        public ICollection<AtributosVinho> atributos { get; set; }
    }
}
