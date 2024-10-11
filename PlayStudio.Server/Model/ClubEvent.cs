using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlayStudio.Server.Model
{
    [Table("ClubEvent")]

    public class ClubEvent
    {
        [Key]
        public Guid Id { get; set; }
        public required GameClub Club { get; set; }
        public required Guid ClubId { get; set; }

        [Required]
        [MaxLength(50)]
        public string Title { get; set; }

        [MaxLength(255)]
        public string? Description { get; set; }

        [Required]
        public DateTime ScheduledDateTime { get; set; }
    }
}
