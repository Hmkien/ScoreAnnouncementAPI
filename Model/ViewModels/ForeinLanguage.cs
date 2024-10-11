using System.ComponentModel.DataAnnotations;

namespace ScoreAnnouncementAPI.Models.ViewModels
{
    public class ForeinLanguage
    {
        [Display(Name = "Mã sinh viên")]
        public string StudentCode { get; set; }
        [Display(Name = "Họ ")]
        public string LastName { get; set; }
        [Display(Name = "Tên")]
        public string FirstName { get; set; }
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
        [Display(Name = "Ghi chú")]
        public string? Note { get; set; }
        [Display(Name = "Khóa học")]
        public string? Course { get; set; }

        [Display(Name = "Khoa")]
        public string? Faculty { get; set; }
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        public string? Email { get; set; }

        [Display(Name = "Số điện thoại")]
        public string? PhoneNumber { get; set; }
    }
}