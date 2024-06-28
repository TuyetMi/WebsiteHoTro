using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;
using System.Diagnostics;
using WebChuyenNganh.Models;

namespace WebChuyenNganh.Controllers
{
    public class SinhVienController : Controller
    {
        private readonly DBConnect dbContext;

        public SinhVienController(DBConnect dbContext)
        {
            this.dbContext = dbContext;
        }
        
        public IActionResult Index()
        {
            return View();
        }
        
        public ActionResult Diem(string mssv)
        {
            if (string.IsNullOrEmpty(mssv))
            {
                // Nếu không có giá trị, có thể xử lý bằng cách redirect hoặc hiển thị thông báo lỗi
                return RedirectToAction("Index", "Home"); // Ví dụ chuyển hướng đến trang chủ
            }

            // Chuỗi truy vấn SQL
            string query = $@"SELECT SinhVien.HoTenSV,SinhVien.MaSV,SinhVien.MaCTDT,SinhVien.Lop, MonHoc.TenMon, Diem.DIEM
FROM Diem
JOIN SinhVien ON Diem.MaSV = SinhVien.MaSV
JOIN MonHoc ON Diem.MaMon = MonHoc.MaMon
WHERE Diem.MaSV = '{mssv}'";

            // Kết nối đến cơ sở dữ liệu
            using (SqlConnection con = new SqlConnection("Data Source=LAPTOP-1I64VKT5\\MAYAO;Initial Catalog=DoAnChuyenNganh;User ID=huy;Password=123;TrustServerCertificate=True;"))
            {
                con.Open();

                // Thực hiện truy vấn SQL
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    List<Diem> diemList = new List<Diem>();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            TempData["HoTenSV"] = dr["HoTenSV"].ToString();
                            TempData["MaSV"] = dr["MaSV"].ToString();
                            TempData["Lop"] = dr["Lop"].ToString();
                            TempData["MaCTDT"] = dr["MaCTDT"].ToString();
                            // Xử lý từng dòng kết quả và tạo các đối tượng Diem
                            Diem diem = new Diem
                            {
                               
                                MaMon = dr["TenMon"].ToString(),
                                DIEM = Convert.IsDBNull(dr["DIEM"]) ? (float?)null : Convert.ToSingle(dr["DIEM"])
                            };

                            
                            // Thêm vào danh sách
                            diemList.Add(diem);
                            
                        }
                    }

                    // Truyền dữ liệu đến view
                    return View(diemList);
                    
                }
            }
        }
        public ActionResult CTDT(string mssv)
        {
            

            // Chuỗi truy vấn SQL
            string query = $@"SELECT * From ChuongTrinhDaoTao";

            // Kết nối đến cơ sở dữ liệu
            using (SqlConnection con = new SqlConnection("Data Source=LAPTOP-1I64VKT5\\MAYAO;Initial Catalog=DoAnChuyenNganh;User ID=huy;Password=123;TrustServerCertificate=True;"))
            {
                con.Open();

                // Thực hiện truy vấn SQL
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    List<ChuongTrinhDaoTao> CTDTList = new List<ChuongTrinhDaoTao>();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            ChuongTrinhDaoTao ctdt = new ChuongTrinhDaoTao
                            {
                                MaCTDT = dr["MaCTDT"].ToString(),
                                TenCTDT = dr["TenCTDT"].ToString(),
                                // Các trường khác nếu cần
                            };

                            // Thêm đối tượng vào danh sách
                            CTDTList.Add(ctdt);



                        }
                    }

                    // Truyền dữ liệu đến view
                    return View(CTDTList);

                }
            }
        }
        [HttpPost]
        public ActionResult ThemChuongTrinhDaoTao(string maCTDT, string tenCTDT)
        {
            // Kết nối đến cơ sở dữ liệu
            using (SqlConnection con = new SqlConnection("Data Source=LAPTOP-1I64VKT5\\MAYAO;Initial Catalog=DoAnChuyenNganh;User ID=huy;Password=123;TrustServerCertificate=True;"))
            {
                con.Open();

                // Chuỗi truy vấn SQL để thêm CTDT vào cơ sở dữ liệu
                string insertQuery = $@"INSERT INTO ChuongTrinhDaoTao (MaCTDT, TenCTDT) 
                                VALUES (N'{maCTDT}', N'{tenCTDT}')";

                // Thực hiện truy vấn SQL để thêm dữ liệu
                using (SqlCommand cmd = new SqlCommand(insertQuery, con))
                {
                    cmd.ExecuteNonQuery();
                }
            }

            // Chuyển hướng hoặc trả về View tùy thuộc vào logic của bạn
            return RedirectToAction("CTDT", "SinhVien");
        }

    }
}

    
