using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace VideoGameManagerV6.DataAccess
{
    public class GameGenre
    {
        public int Id { get; set; }

        [MaxLength(150)]
        [Required]
        public string Name { get; set; } = string.Empty;

        [JsonIgnore]
        public List<Game>? Games { get; set; }
    }

    public class Game
    {
        public int Id { get; set; }

        [MaxLength(150)]
        [Required]
        public string Name { get; set; } = string.Empty;
        
        public GameGenre? Genre { get; set; }

        public int PersonalRating { get; set; }

    }
}
