using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Qimt2.Data
{
    [Table("Employee")]
    public class Employee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required (ErrorMessage = "ادخل الإسم ثلاثى")]
        public string Name { get; set; }
        [Required (ErrorMessage = "ادخل العمـر")]
        public string Age { get; set; }
        [Required(ErrorMessage = "ادخل العنوان بالتفصيل ")]
        public string Address { get; set; }
        [Required (ErrorMessage = "ادخل الوظيفـه")]
        public string Role { get; set; }
        [Required (ErrorMessage = "ادخل الراتـب")]
        public int Salary { get; set; }

    }
}
