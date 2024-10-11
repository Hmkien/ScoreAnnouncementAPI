using System.ComponentModel.DataAnnotations;

namespace ScoreAnnouncementAPI.Models.Entities
{
    public class ExamType
    {
        [Key]
        public string ExamTypeId { get; set; }
        public string ExamTypeName { get; set; }

    }
}