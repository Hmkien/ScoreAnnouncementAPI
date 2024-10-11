using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ScoreAnnouncementAPI.Models.Entities
{
    public class RequireForm
    {
        [Key]
        public int RequireFormCode { get; set; }
        public string StudenCode { get; set; }
        public string FileDocx { get; set; }
        public string? Note { get; set; }
        public string? Status { get; set; }
        [ForeignKey("StudentCode")]
        public StudentExam? StudentExam { get; set; }
    }

}