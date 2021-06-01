using System;
using System.Collections.Generic;

#nullable disable

namespace ShoppingWeb.Models
{
    public partial class Giohang
    {
        public Giohang()
        {
            Chitietgiohangs = new HashSet<Chitietgiohang>();
        }

        public int MaGioHang { get; set; }
        public string SdtKh { get; set; }
        public decimal ThanhTien { get; set; }

        public virtual Khachhang SdtKhNavigation { get; set; }
        public virtual ICollection<Chitietgiohang> Chitietgiohangs { get; set; }
    }
}
