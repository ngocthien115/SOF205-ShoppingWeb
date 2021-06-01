using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

#nullable disable

namespace ShoppingWeb.Models
{
    public partial class WEBBANHANGContext : DbContext
    {
        public WEBBANHANGContext()
        {
        }

        public WEBBANHANGContext(DbContextOptions<WEBBANHANGContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Chitietgiohang> Chitietgiohangs { get; set; }
        public virtual DbSet<Giohang> Giohangs { get; set; }
        public virtual DbSet<Khachhang> Khachhangs { get; set; }
        public virtual DbSet<Loaisanpham> Loaisanphams { get; set; }
        public virtual DbSet<Sanpham> Sanphams { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var builder = new ConfigurationBuilder()
                                    .SetBasePath(Directory.GetCurrentDirectory())
                                    .AddJsonFile("appsettings.json");
            var configuration = builder.Build();
            optionsBuilder.UseSqlServer(configuration["ConnectionStrings:DefaultConnection"]);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Chitietgiohang>(entity =>
            {
                entity.HasKey(e => new { e.MaGioHang, e.MaSanPham })
                    .HasName("PK__CHITIETG__3AAC69E1C9A2D22E");

                entity.ToTable("CHITIETGIOHANG");

                entity.HasOne(d => d.MaGioHangNavigation)
                    .WithMany(p => p.Chitietgiohangs)
                    .HasForeignKey(d => d.MaGioHang)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_MaGioHang");

                entity.HasOne(d => d.MaSanPhamNavigation)
                    .WithMany(p => p.Chitietgiohangs)
                    .HasForeignKey(d => d.MaSanPham)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_MaSP");
            });

            modelBuilder.Entity<Giohang>(entity =>
            {
                entity.HasKey(e => e.MaGioHang)
                    .HasName("PK__GIOHANG__F5001DA33029F022");

                entity.ToTable("GIOHANG");

                entity.Property(e => e.SdtKh)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("SDT_KH");

                entity.Property(e => e.ThanhTien).HasColumnType("smallmoney");

                entity.HasOne(d => d.SdtKhNavigation)
                    .WithMany(p => p.Giohangs)
                    .HasForeignKey(d => d.SdtKh)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_SDT_KH");
            });

            modelBuilder.Entity<Khachhang>(entity =>
            {
                entity.HasKey(e => e.SdtKh)
                    .HasName("PK__KHACHHAN__DE78DCDA12A3C2FF");

                entity.ToTable("KHACHHANG");

                entity.Property(e => e.SdtKh)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("SDT_KH");

                entity.Property(e => e.DiaChi).HasMaxLength(500);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.MatKhau)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TenKh)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("TenKH");
            });

            modelBuilder.Entity<Loaisanpham>(entity =>
            {
                entity.HasKey(e => e.MaLoai)
                    .HasName("PK__LOAISANP__730A5759700D5751");

                entity.ToTable("LOAISANPHAM");

                entity.Property(e => e.MaLoai)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.TenLoai)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Sanpham>(entity =>
            {
                entity.HasKey(e => e.MaSp)
                    .HasName("PK__SANPHAM__2725081C96AE5311");

                entity.ToTable("SANPHAM");

                entity.Property(e => e.MaSp).HasColumnName("MaSP");

                entity.Property(e => e.GiaBan).HasColumnType("smallmoney");

                entity.Property(e => e.HinhSp)
                    .IsRequired()
                    .HasMaxLength(200)
                    .HasColumnName("HinhSP");

                entity.Property(e => e.MaLoai)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.MoTa)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.TenSp)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("TenSP");

                entity.HasOne(d => d.MaLoaiNavigation)
                    .WithMany(p => p.Sanphams)
                    .HasForeignKey(d => d.MaLoai)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_MaLoai_LSP");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
