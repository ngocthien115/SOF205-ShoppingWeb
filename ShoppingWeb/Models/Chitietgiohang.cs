using System;
using System.Collections.Generic;

#nullable disable

namespace ShoppingWeb.Models
{
    public partial class Chitietgiohang
    {
        public int MaGioHang { get; set; }
        public int MaSanPham { get; set; }
        public int SoLuong { get; set; }

        public virtual Giohang MaGioHangNavigation { get; set; }
        public virtual Sanpham MaSanPhamNavigation { get; set; }
    }
}
