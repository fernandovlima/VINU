using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    class User
    {
        [Key]
        public int UserID { get; set; }

        [Required] 
        public string Login { get; set; }

        [Required] 
        public string Senha { get; set; }

        [Required] 
        public string Nome { get; set; }

        public List<Vinho> VinhosFavoritos { get; set; } 
    }
}
