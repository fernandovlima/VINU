using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class FavoriteWines
    {
        private int userId;
        private int vinhoID;

        public FavoriteWines(int userId, int vinhoID)
        {
            this.userId = userId;
            this.vinhoID = vinhoID;
        }

        [Key]
        public int FavoriteWinesID { get; set; }

        [Required]
        public User UserID { get; set; }

        [Required]
        public Wine WineID { get; set; }
    }
}