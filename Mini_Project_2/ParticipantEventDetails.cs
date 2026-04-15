using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UVEMS.DAL.Models
{
    public class ParticipantEventDetails
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [ForeignKey("User")]
        public string ParticipantEmailId { get; set; }

        public UserInfo? User { get; set; }

        [Required]
        [ForeignKey("Event")]
        public int EventId { get; set; }

        public EventDetails? Event { get; set; }

        public bool IsAttended { get; set; } = false;

        [ForeignKey("Session")]
        public int? SessionId { get; set; }

        public SessionInfo? Session { get; set; }
    }
}
