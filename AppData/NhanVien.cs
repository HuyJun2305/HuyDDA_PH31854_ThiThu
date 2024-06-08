using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppData
{
    public class NhanVien
    {
        [Key]
        public Guid Id { get; set; }
        [StringLength(30,ErrorMessage = "Độ dài không quá 30 kí tự")]

        public string Ten { get; set; }
        [Range(18,50, ErrorMessage = "Tuổi chỉ từ 18 - 50")]

        public int Tuoi { get; set; }
        [EmailAddress(ErrorMessage = "Email phải đúng định dạng")]
        public string Email { get; set; }

        [Range(5000000,30000000, ErrorMessage = "Lương phải từ 5 triệu - 30 triệu")]
        public int Luong { get; set; }

        public bool TrangThai { get; set; }

    }
}
