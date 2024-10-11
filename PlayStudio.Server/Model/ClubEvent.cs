using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace PlayStudio.Server.Model
{
      [Table("ClubEvent")]

      public class ClubEvent
      {
            [Key]
            public Guid Id { get; set; }

            [JsonIgnore]
            [Required]
            public GameClub Club { get; set; } = new();

            [Required]
            public Guid ClubId { get; set; }

            [Required]
            [MaxLength(50)]
            public string Title { get; set; } = string.Empty;

            [MaxLength(255)]
            public string? Description { get; set; }

            [Required]
            public DateTime ScheduledDateTime { get; set; }
      }
}
