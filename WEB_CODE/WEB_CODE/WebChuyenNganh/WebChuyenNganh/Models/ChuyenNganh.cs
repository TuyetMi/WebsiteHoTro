using System.ComponentModel.DataAnnotations;

namespace WebChuyenNganh.Models
{
    public class ChuyenNganh
    {
        [Key]
        public string MaCN { get; set; }
        public string TenCN { get; set; }

        public ICollection<SinhVien> SinhVien { get; set; }

    }
}
