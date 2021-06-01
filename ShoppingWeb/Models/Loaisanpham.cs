using System;
using System.Collections.Generic;

#nullable disable

namespace ShoppingWeb.Models
{
    public partial class Loaisanpham
    {
        public Loaisanpham()
        {
            Sanphams = new HashSet<Sanpham>();
        }

        public string MaLoai { get; set; }
        public string TenLoai { get; set; }

        public virtual ICollection<Sanpham> Sanphams { get; set; }
    }
}
