using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class AtributosVinho
    {
        [Key]
        public int AtributosVinhoID { get; set; }

        public string NomeAtributo { get; set; }

        public string ValorAtr { get; set; }

		public string VinhoID { get; set; }

    }
}
