using System.ComponentModel.DataAnnotations;

namespace UVEMS.DAL.Models
{
    public class EventDetails
    {
        [Key]
        public int EventId { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 1)]
        public string EventName { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 1)]
        public string EventCategory { get; set; }

        [Required]
        public DateTime EventDate { get; set; }

        public string? Description { get; set; }

        [Required]
        public string Status { get; set; } = "Active"; // Default value

        // Navigation Property
        public ICollection<SessionInfo>? Sessions { get; set; }

        // Optional: track participants for this event
        public ICollection<ParticipantEventDetails>? ParticipantEvents { get; set; }
    }
}
