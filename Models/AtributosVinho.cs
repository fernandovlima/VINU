using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    class AtributosVinho
    {
        [Key]
        public int AtributosVinhoID { get; set; }

        public string NomeAtributo { get; set; }

        public string ValorAtr { get; set; }

    }
}
