using System.ComponentModel.DataAnnotations;

namespace ScoreAnnouncementAPI.Models.ViewModels
{
    public class CNTT_CB_CDR
    {
        [Display(Name = "Mã sinh viên")]
        public string StudentCode { get; set; }
        [Display(Name = "Họ ")]
        public string LastName { get; set; }
        [Display(Name = "Tên")]
        public string FirstName { get; set; }
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
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        public string? Email { get; set; }

        [Display(Name = "Số điện thoại")]
        public string? PhoneNumber { get; set; }
        [Display(Name = "Khóa học")]
        public string? Course { get; set; }

        [Display(Name = "Khoa")]
        public string? Faculty { get; set; }
    }
}