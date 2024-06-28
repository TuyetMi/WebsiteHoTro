using System.ComponentModel.DataAnnotations;

namespace WebChuyenNganh.Models
{
    public class SinhVien
    {
        [Key]
        public string MaSV { get; set; }
        public string MaCTDT { get; set; }
        public string MaCN { get; set; }
        public string Lop { get; set; }
        public string HoTenSV { get; set; }
        public string Password { get; set; }

        // Quan hệ khóa ngoại
        public ChuongTrinhDaoTao ChuongTrinhDaoTao { get; set; }
        public ChuyenNganh ChuyenNganh { get; set; }
        public ICollection<Diem> Diem { get; set; }
    }
}
