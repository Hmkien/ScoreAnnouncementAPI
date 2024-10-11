using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ScoreAnnouncementAPI.Models.Entities
{
    public class ScoreFL
    {
        [Key]
        public int ScoreFLCode { get; set; }
        [Display(Name = "Mã kì thi")]
        [ForeignKey("ExamId")]
        public int ExamId { get; set; }
        [Display(Name = "Mã sinh viên")]
        public string StudentCode { get; set; }
        [Display(Name = "Nói")]
        public string SpeakingScore { get; set; }
        [Display(Name = "Đọc")]
        public string ReadingScore { get; set; }
        [Display(Name = "Viết")]
        public string WritingScore { get; set; }
        [Display(Name = "Nghe")]
        public string ListeningScore { get; set; }
        public string? TotalScore { get; set; }
        [Display(Name = "Xếp hạng")]
        public string? Result { get; set; }
        public string? Note { get; set; }


    }
}