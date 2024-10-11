using System.ComponentModel.DataAnnotations;

namespace ScoreAnnouncementAPI.Models.Entities
{
    public class StudentRegistration
    {
        [Key]
        public Guid StudentRegistrationId { get; set; }
        public string? StudentCode { get; set; }
        public string? IdentityNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string? Note { get; set; }
    }
}