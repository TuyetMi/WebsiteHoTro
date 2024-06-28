
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebChuyenNganh.Models
{
    public class Diem
    {

        public string HoTenSV { get; set; }
        public string MaSV { get; set; }

        public string MaMon { get; set; }
        public float? DIEM { get; set; }

        public string MaCTDT { get; set; }
        public string MaCN { get; set; }
        public string Lop { get; set; }

    }
}
