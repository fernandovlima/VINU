using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class User
    {
        [Key]
        public int UserID { get; set; }

        [Required] 
        public string Login { get; set; }

        [Required] 
        public string Senha { get; set; }

        [Required] 
        public string Nome { get; set; }

        public ICollection<FavoriteWines> VinhosFavoritos { get; set; } 
    }
}
