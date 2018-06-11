using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    class Vinho
    {
        [Key]
        public int VinhoID { get; set; }

        [Required]
        public string NomeVinho { get; set; }

        [Required]
        public double Valor { get; set; }

        public float Score { get; set; }
        
        public List<AtributosVinho> atributos { get; set; }
    }
}
