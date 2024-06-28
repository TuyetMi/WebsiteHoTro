using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebChuyenNganh.Models
{
    public class ChuongTrinhDaoTao
    {
        [Key]
        public string MaCTDT { get; set; }
        public string TenCTDT { get; set; }
        
    }
}
