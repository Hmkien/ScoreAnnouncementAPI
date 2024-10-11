using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ScoreAnnouncementAPI.Models.Entities
{
    public class ScoreIT
    {
        [Key]
        public int ScoreITCode { get; set; }
        [ForeignKey("StudentCode")]
        public string? StudentCode { get; set; }
        [ForeignKey("IdentityNumber")]
        public string? IdentityNumber { get; set; }
        [ForeignKey("ExamId")]
        public int examId { get; set; }
        [Display(Name = "Điểm thực hành")]
        public string PracticalScore { get; set; }
        [Display(Name = "Word")]
        public string? WordScore { get; set; }
        [Display(Name = "Excel")]
        public string? ExcelScore { get; set; }
        [Display(Name = "PowerPoint")]
        public string? PowerPointScore { get; set; }
        [Display(Name = "Điểm lý thuyết")]
        public string TheoryScore { get; set; }
        [Display(Name = "Tổng điểm")]
        public string? TotalScore { get; set; }
        [Display(Name = "Xếp loại")]
        public string? Result { get; set; }
        [Display(Name = "Ghi chú")]
        public string? Note { get; set; }


    }
}