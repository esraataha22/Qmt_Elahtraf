using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Qimt2.Data
{
    [Table("Report")]
    public class Report
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RepId { get; set; }
        [Required (ErrorMessage = "ادخل عنوان التقرير باللغة العربية")]
        public string title_Ar { get; set; }
        [Required(ErrorMessage = "ادخل عنوان التقرير باللغة الإنجليزية")]
        public string title_En { get; set; }
        public string point_Ar { get; set; }
        public string point_En { get; set; }
        [Required(ErrorMessage = "ادخل فقراتفقرات التقرير باللغة العربية")]
        public string paragraph_Ar { get; set; }
        [Required(ErrorMessage = "ادخل عنوان التقرير باللغة الإنجليزية")]
        public string paragraph_En { get; set; }

        public string? Photo { get; set; }
        [NotMapped]
        public virtual IFormFile? file { get; set; }

        public int? ParentId { get; set; }


    }
}
