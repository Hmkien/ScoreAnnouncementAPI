using System;
using System.ComponentModel.DataAnnotations;

namespace ScoreAnnouncementAPI.Models.Entities
{
    public class Student
    {
        [Key]
        [Display(Name = "Mã sinh viên")]
        public string StudentCode { get; set; }

        [Display(Name = "Họ ")]
        public string LastName { get; set; }
        [Display(Name = "Tên")]
        public string FirstName { get; set; }

        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        public string? Email { get; set; }

        [Display(Name = "Số điện thoại")]
        public string? PhoneNumber { get; set; }

        [Display(Name = "Miễn chuẩn đầu ra")]
        public int? Note { get; set; } = 0;

        [Display(Name = "Khóa học")]
        public string? Course { get; set; }

        [Display(Name = "Khoa")]
        public string? Faculty { get; set; }

        [Display(Name = "Hoạt động")]
        public bool? IsActive { get; set; }

        [Display(Name = "Đã xóa")]
        public bool? IsDelete { get; set; }
        [Display(Name = "Trạng thái")]
        public string? Status { get; set; }
    }
}
