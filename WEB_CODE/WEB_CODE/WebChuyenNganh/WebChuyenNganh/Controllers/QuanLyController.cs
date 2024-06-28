using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using WebChuyenNganh.Models;

namespace WebChuyenNganh.Controllers
{
    public class QuanLyController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        
        public ActionResult MonHoc()
        {
            // Chuỗi truy vấn SQL
            string query = $@"SELECT * From MonHoc";

            // Kết nối đến cơ sở dữ liệu
            using (SqlConnection con = new SqlConnection("Data Source=LAPTOP-1I64VKT5\\MAYAO;Initial Catalog=DoAnChuyenNganh;User ID=huy;Password=123;TrustServerCertificate=True;"))
            {
                con.Open();

                // Thực hiện truy vấn SQL
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    List<MonHoc> CTDTList = new List<MonHoc>();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            MonHoc mh = new MonHoc
                            {
                                MaMon = dr["MaMon"].ToString(),
                                MaCTDT = dr["MaCTDT"].ToString(),
                                MaMonCN = dr["MaCTDT"].ToString(),
                                TenMon = dr["TenMon"].ToString(),
                                // Khởi tạo danh sách môn học cho mỗi chương trình đào tạo
                            };
                            CTDTList.Add(mh);
                        }
                    }
                    // Truyền dữ liệu đến view
                    return View(CTDTList);

                }
            }
        }
        [HttpPost]
        public ActionResult TimKiemMonHoc(string maCTDT)
        {
            // Kết nối đến cơ sở dữ liệu
            using (SqlConnection con = new SqlConnection("Data Source=LAPTOP-1I64VKT5\\MAYAO;Initial Catalog=DoAnChuyenNganh;User ID=huy;Password=123;TrustServerCertificate=True;"))
            {
                con.Open();

                // Chuỗi truy vấn SQL để tìm kiếm MonHoc dựa trên maCTDT
                string searchQuery = $@"SELECT * FROM MonHoc WHERE MaCTDT = N'{maCTDT}'";

                // Thực hiện truy vấn SQL
                using (SqlCommand cmd = new SqlCommand(searchQuery, con))
                {
                    List<MonHoc> monHocList = new List<MonHoc>();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            MonHoc monHoc = new MonHoc
                            {
                                MaMon = dr["MaMon"].ToString(),
                                MaCTDT = dr["MaCTDT"].ToString(),
                                TenMon = dr["TenMon"].ToString()
                            };

                            // Thêm đối tượng vào danh sách
                            monHocList.Add(monHoc);
                        }
                    }

                    // Truyền dữ liệu đến view
                    return View("MonHoc", monHocList);
                }
            }
        }
        [HttpPost]
        public ActionResult ThemMonHoc(string maMon, string maCTDT, string tenMon)
        {
            // Kết nối đến cơ sở dữ liệu
            using (SqlConnection con = new SqlConnection("Data Source=LAPTOP-1I64VKT5\\MAYAO;Initial Catalog=DoAnChuyenNganh;User ID=huy;Password=123;TrustServerCertificate=True;"))
            {
                con.Open();

                // Chuỗi truy vấn SQL để thêm môn học vào cơ sở dữ liệu
                string insertQuery = $@"INSERT INTO MonHoc (MaMon, MaCTDT, TenMon) 
                            VALUES (N'{maMon}', N'{maCTDT}', N'{tenMon}')";

                // Thực hiện truy vấn SQL để thêm dữ liệu
                using (SqlCommand cmd = new SqlCommand(insertQuery, con))
                {
                    cmd.ExecuteNonQuery();
                }
            }
            // Chuyển hướng hoặc trả về View tùy thuộc vào logic của bạn
            return RedirectToAction("MonHoc", "QuanLy");
        }

        public ActionResult SuaMonHoc(string maMon, string maCTDT, string tenMon)
        {
            // Kết nối đến cơ sở dữ liệu
            using (SqlConnection con = new SqlConnection("Data Source=LAPTOP-1I64VKT5\\MAYAO;Initial Catalog=DoAnChuyenNganh;User ID=huy;Password=123;TrustServerCertificate=True;"))
            {
                con.Open();

                // Chuỗi truy vấn SQL để cập nhật môn học trong cơ sở dữ liệu
                string updateQuery = $@"UPDATE MonHoc 
                            SET TenMon = N'{tenMon}'
                            WHERE MaMon = N'{maMon}' AND MaCTDT = N'{maCTDT}'";

                // Thực hiện truy vấn SQL để cập nhật dữ liệu
                using (SqlCommand cmd = new SqlCommand(updateQuery, con))
                {
                    cmd.ExecuteNonQuery();
                }
            }
            // Chuyển hướng hoặc trả về View tùy thuộc vào logic của bạn
            return RedirectToAction("MonHoc", "QuanLy");
        }

        public ActionResult XoaMonHoc(string maMon, string maCTDT)
        {
            // Kết nối đến cơ sở dữ liệu
            using (SqlConnection con = new SqlConnection("Data Source=LAPTOP-1I64VKT5\\MAYAO;Initial Catalog=DoAnChuyenNganh;User ID=huy;Password=123;TrustServerCertificate=True;"))
            {
                con.Open();

                // Chuỗi truy vấn SQL để xóa môn học từ cơ sở dữ liệu
                string deleteQuery = $@"DELETE FROM MonHoc WHERE MaMon = N'{maMon}' ";

                // Thực hiện truy vấn SQL để xóa dữ liệu
                using (SqlCommand cmd = new SqlCommand(deleteQuery, con))
                {
                    cmd.ExecuteNonQuery();
                }
            }
            // Chuyển hướng hoặc trả về View tùy thuộc vào logic của bạn
            return RedirectToAction("MonHoc", "QuanLy");
        }

        public ActionResult CTDT()
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
                                // Khởi tạo danh sách môn học cho mỗi chương trình đào tạo
                                
                            };

                            // Gọi hàm để lấy danh sách môn học
                            

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
            return RedirectToAction("CTDT", "QuanLy");
        }
        public ActionResult SuaChuongTrinhDaoTao(string maCTDT, string tenCTDT)
        {
            // Kết nối đến cơ sở dữ liệu
            using (SqlConnection con = new SqlConnection("Data Source=LAPTOP-1I64VKT5\\MAYAO;Initial Catalog=DoAnChuyenNganh;User ID=huy;Password=123;TrustServerCertificate=True;"))
            {
                con.Open();

                // Chuỗi truy vấn SQL để cập nhật CTDT trong cơ sở dữ liệu
                string updateQuery = $@"UPDATE ChuongTrinhDaoTao 
                                SET TenCTDT = N'{tenCTDT}'
                                WHERE MaCTDT = N'{maCTDT}'";

                // Thực hiện truy vấn SQL để cập nhật dữ liệu
                using (SqlCommand cmd = new SqlCommand(updateQuery, con))
                {
                    cmd.ExecuteNonQuery();
                }
            }
            // Chuyển hướng hoặc trả về View tùy thuộc vào logic của bạn
            return RedirectToAction("CTDT", "QuanLy");
        }
        public ActionResult XoaChuongTrinhDaoTao(string maCTDT)
        {
            // Kết nối đến cơ sở dữ liệu
            using (SqlConnection con = new SqlConnection("Data Source=LAPTOP-1I64VKT5\\MAYAO;Initial Catalog=DoAnChuyenNganh;User ID=huy;Password=123;TrustServerCertificate=True;"))
            {
                con.Open();

                // Chuỗi truy vấn SQL để xóa CTDT từ cơ sở dữ liệu
                string deleteQuery = $@"DELETE FROM ChuongTrinhDaoTao WHERE MaCTDT = N'{maCTDT}'";

                // Thực hiện truy vấn SQL để xóa dữ liệu
                using (SqlCommand cmd = new SqlCommand(deleteQuery, con))
                {
                    cmd.ExecuteNonQuery();
                }
            }
            // Chuyển hướng hoặc trả về View tùy thuộc vào logic của bạn
            return RedirectToAction("CTDT", "QuanLy");
        }
    }

}
