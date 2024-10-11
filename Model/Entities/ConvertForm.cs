using System.ComponentModel.DataAnnotations;

namespace ScoreAnnouncementAPI.Models.Entities
{
    public class ConvertForm
    {
        [Key]
        public int ConvertFormId { get; set; }
        [Display(Name = "Mã sinh viên")]
        [Required]
        public string StudentCode { get; set; }
        [Display(Name = "Tên")]
        [Required]
        public string FirstName { get; set; }
        [Display(Name = "Họ")]
        public string LastName { get; set; }
        [Display(Name = "Số diện thoại")]
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        [Display(Name = "Loại chứng chỉ")]
        public string CertificateType { get; set; }
        [Display(Name = "Tên chứng chỉ")]
        [Required]
        public string CertificateName { get; set; }
        [Display(Name = "Ngày gửi")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime SendDate { get; set; } = DateTime.Now;
        [Display(Name = "Ảnh minh chứng")]
        public string Image { get; set; }
        public string fileDocx { get; set; }
        [Display(Name = "Ghi chú")]
        public string? Note { get; set; }
        [Display(Name = "Trạng thái")]
        public string? Status { get; set; } = "New";
    }
}