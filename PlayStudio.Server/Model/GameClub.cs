using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace PlayStudio.Server.Model
{
    [Table("GameClub")]
    public class GameClub
    {
        [Key]
        public Guid Id { get; set; }

        [MaxLength(20)]
        public string Name { get; set; }

        [MaxLength(255)]
        public string? Description { get; set; }

        [JsonIgnore]
        public ICollection<ClubEvent> Events { get; } = new List<ClubEvent>();
    }
}
