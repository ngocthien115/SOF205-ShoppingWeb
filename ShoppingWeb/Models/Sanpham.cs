using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace ShoppingWeb.Models
{
    public partial class Sanpham
    {
        public Sanpham()
        {
            Chitietgiohangs = new HashSet<Chitietgiohang>();
        }

        public int MaSp { get; set; }
        public string TenSp { get; set; }
        public string MoTa { get; set; }
        public int SoLuongKho { get; set; }
        public string HinhSp { get; set; }
        public int GiaBan { get; set; }
        public string MaLoai { get; set; }
        [NotMapped]
        public IFormFile imageFile { get; set; }
        public virtual Loaisanpham MaLoaiNavigation { get; set; }
        public virtual ICollection<Chitietgiohang> Chitietgiohangs { get; set; }
    }
}
