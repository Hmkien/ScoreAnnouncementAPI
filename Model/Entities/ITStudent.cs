using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ScoreAnnouncementAPI.Models.Entities
{
    public class ITStudent
    {
        [Key]
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
        [Display(Name = "Ghi chú")]
        public string? Note { get; set; }
        [ForeignKey("ExamId")]
        public int ExamId { get; set; }

    }
}
