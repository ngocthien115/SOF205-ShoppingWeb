using System;
using System.Collections.Generic;

#nullable disable

namespace ShoppingWeb.Models
{
    public partial class Khachhang
    {
        public Khachhang()
        {
            Giohangs = new HashSet<Giohang>();
        }

        public string SdtKh { get; set; }
        public string TenKh { get; set; }
        public string DiaChi { get; set; }
        public string Email { get; set; }
        public string MatKhau { get; set; }

        public virtual ICollection<Giohang> Giohangs { get; set; }
    }
}
