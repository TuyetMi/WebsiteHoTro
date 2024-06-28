using Microsoft.EntityFrameworkCore;

namespace WebChuyenNganh.Models
{
    public partial class DBConnect : DbContext
    {
        public DBConnect(DbContextOptions<DBConnect> options) : base(options)
        {
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Định nghĩa các quan hệ khóa ngoại
            


        // Quan hệ SinhVien - ChuongTrinhDaoTao
        //modelBuilder.Entity<SinhVien>()
        //        .HasOne(sv => sv.ChuongTrinhDaoTao)
        //        .WithMany(ctdt => ctdt.SinhVien)
        //        .HasForeignKey(sv => sv.MaCTDT);

        //    // Quan hệ SinhVien - ChuyenNganh
        //    modelBuilder.Entity<SinhVien>()
        //        .HasOne(sv => sv.ChuyenNganh)
        //        .WithMany(cn => cn.SinhVien)
        //        .HasForeignKey(sv => sv.MaCN);

        //    // Quan hệ MonHoc - ChuongTrinhDaoTao
        //    modelBuilder.Entity<MonHoc>()
        //        .HasOne(mh => mh.ChuongTrinhDaoTao)
        //        .WithMany(ctdt => ctdt.MonHoc)
        //        .HasForeignKey(mh => mh.MaCTDT);

            // Quan hệ Diem - SinhVien
            
            modelBuilder.Entity<Diem>()
        .HasKey(d => new { d.MaSV, d.MaMon });

            base.OnModelCreating(modelBuilder);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.LogTo(Console.WriteLine);
        }
        public DbSet<ChuongTrinhDaoTao> ChuongTrinhDaoTao { get; set; }
        public DbSet<ChuyenNganh> ChuyenNganh { get; set; }
        public DbSet<SinhVien> SinhVien { get; set; }
        public DbSet<MonHoc> MonHoc { get; set; }
        public DbSet<Diem> Diem { get; set; }
    }
}
