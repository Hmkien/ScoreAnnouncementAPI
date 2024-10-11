using System.ComponentModel.DataAnnotations;

namespace ScoreAnnouncementAPI.Models.Entities
{
    public class ScoreELTC
    {
        [Key]
        public int ScoreELTCId { get; set; }
        [Display(Name = "B1")]
        public string B1Score { get; set; }
        [Display(Name = "B2")]
        public string B2Score { get; set; }
        [Display(Name = "B3")]
        public string B3Score { get; set; }
        [Display(Name = "B")]
        public string BScore { get; set; }
        [Display(Name = "C1")]
        public string C1Score { get; set; }
        [Display(Name = "C2")]
        public string C2Score { get; set; }
        [Display(Name = "C")]
        public string CScore { get; set; }
        [Display(Name = "A")]
        public string Ascore { get; set; }
        [Display(Name = "Kết quả")]
        public string Result { get; set; }
        [Display(Name = "Ghi chú")]
        public string? Note { get; set; }
    }
}