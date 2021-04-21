using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyPortfolio.Models
{
    public class Contact
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage ="이름은 필수입니다.")]
        [DataType(DataType.Text)]
        [StringLength(50)] //db에서 데이터형식 지정하는 것과 같음
        public string Name { get; set; }
        [Required(ErrorMessage = "이메일은 필수입니다.")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required(ErrorMessage = "내용은 필수입니다.")]
        [DataType(DataType.Text)]
        public string Contents { get; set; }
        public DateTime RegDate { get; set; }
    }
}
