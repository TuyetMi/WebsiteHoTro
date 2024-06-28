using Microsoft.AspNetCore.Mvc;
using System;
using WebChuyenNganh.Models;
using System.Data.SqlClient;

namespace WebChuyenNganh.Controllers
{
    public class AccountController : Controller
    {

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        SqlConnection con = new SqlConnection();
        SqlCommand com = new SqlCommand();
        SqlDataReader dr;
        void ConnectionString()
        {
            con.ConnectionString = "Data Source=LAPTOP-1I64VKT5\\MAYAO;Initial Catalog=DoAnChuyenNganh;User ID=huy;Password=123;TrustServerCertificate=True;";
        }
        [HttpPost]
        public ActionResult Login(SinhVien sv)
        {
            try
            {
                ConnectionString();
                con.Open();
                com.Connection = con;
                com.CommandText = "SELECT * FROM SinhVien WHERE MaSV=@MaSV AND Password=@Password";
                com.Parameters.AddWithValue("@MaSV", sv.MaSV);
                com.Parameters.AddWithValue("@Password", sv.Password);

                dr = com.ExecuteReader();
                if (dr.Read())
                {
                    TempData["HoTenSV"] = dr["HoTenSV"].ToString();
                    TempData["MaSV"] = dr["MaSV"].ToString();
                    TempData["Lop"] = dr["Lop"].ToString();
                    TempData["MaCTDT"] = dr["MaCTDT"].ToString();

                    sv.HoTenSV = dr["HoTenSV"].ToString();
                    sv.MaSV = dr["MaSV"].ToString();
                    sv.Lop = dr["Lop"].ToString();
                    sv.MaCTDT = dr["MaCTDT"].ToString();

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewBag.Error = "Mã sinh viên hoặc mật khẩu không đúng. Vui lòng thử lại.";
                    return View("Login");
                }
            }
            catch (Exception ex)
            {
                // Ghi log nếu có lỗi
                // Log.Error("Exception during SinhVien login", ex);
                ViewBag.Error = "Đã xảy ra lỗi trong quá trình đăng nhập. Vui lòng thử lại.";
                return View("Login");
            }
            finally
            {
                con.Close();
            }
        }
        [HttpPost]
        public ActionResult Login1(GiangVien gv)
        {
            ConnectionString();
            con.Open();
            com.Connection = con;
            com.CommandText = "select * from GiangVien where taikhoan='" + gv.taikhoan + "' and Password='" + gv.Password + "'";
            dr = com.ExecuteReader();
            if (dr.Read())
            {
                // Lưu thông tin người dùng vào TempData
                TempData["HoTenGV"] = dr["HoTenGV"].ToString();
                return RedirectToAction("Index", "QuanLy"); // Chuyển hướng đến action "Index" của "HomeController"
            }
            else
            {
                con.Close();
                ViewBag.Error = "Tài khoản hoặc mật khẩu không đúng. Vui lòng thử lại.";
                return View("Login");
            }
        }
        public IActionResult Logout()
        {
            // Xoá thông tin đăng nhập (ví dụ: xóa TempData)
            TempData.Remove("HoTenSV");
            TempData.Remove("MaSV");
            TempData.Remove("Lop");

            // Chuyển hướng về trang đăng nhập (Login)
            return RedirectToAction("Login");
        }
            
        
    }
}