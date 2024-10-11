using System.ComponentModel.DataAnnotations;

namespace ScoreAnnouncementAPI.Models.ViewModels
{
    public class CC_CNTT_CB
    {
        [Display(Name = "Số CMND/CCCD")]
        public string IdentityNumber { get; set; }

        [Display(Name = "Họ ")]
        public string LastName { get; set; }
        [Display(Name = "Tên")]
        public string FirstName { get; set; }

        [Display(Name = "Ngày sinh")]
        public string? BirthDay { get; set; }
        [Display(Name = "Giới tính ")]
        public string? Gender { get; set; }
        [Display(Name = "Nơi sinh ")]
        public string? Address { get; set; }
        public string? Email { get; set; }
        [Display(Name = "Dân tộc")]
        public string? national { get; set; }
        [Display(Name = "Số báo danh")]
        public string? IdentificationCode { get; set; }
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