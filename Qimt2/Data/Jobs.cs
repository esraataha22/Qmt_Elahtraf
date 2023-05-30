using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Qimt2.Data
{
    [Table("Jobs")]
    public class Jobs
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required(ErrorMessage = "ادخل ااسم الوظيفة")]
        public string Name { get; set; }
        public string? About { get; set; }
        [Required(ErrorMessage = "ادخل متطلبات الوظيفة")]
        public string Requirements { get; set; }
        [Required(ErrorMessage = "ادخل مسئوليات الوظيفة")]
        public string Responsibilities { get; set; }
    }
}
