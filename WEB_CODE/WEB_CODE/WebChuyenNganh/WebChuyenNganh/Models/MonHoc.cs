using System.ComponentModel.DataAnnotations;

namespace WebChuyenNganh.Models
{
    public class MonHoc
    {
        [Key]
        public string MaMon { get; set; }
        public string MaCTDT { get; set; }
        public string MaMonCN { get; set; }
        public string TenMon { get; set; }

        // Khai báo khóa ngoại
       

    }
}
