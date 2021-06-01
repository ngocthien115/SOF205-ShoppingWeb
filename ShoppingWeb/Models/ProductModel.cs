using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingWeb.Models
{
    public class ProductModel
    {
        private WEBBANHANGContext db = new WEBBANHANGContext();
        #region Danh sách view điện thoại
        public List<Sanpham> DSSP()
        {
            var ls = db.Sanphams.ToList();
            var lsPhone = from dienthoais in ls
                          where dienthoais.MaLoai == "IP" || dienthoais.MaLoai == "SS" || dienthoais.MaLoai == "HW" ||
                          dienthoais.MaLoai == "XM" || dienthoais.MaLoai == "VS"
                          select dienthoais;

            return ls;
        }
        public List<Sanpham> DSiPhone()
        {
            var ls = db.Sanphams.ToList();
            var lsPhone = from dienthoais in ls
                          where dienthoais.MaLoai == "IP"
                          select dienthoais;
            return lsPhone.ToList();
        }
        public List<Sanpham> dsSamsung()
        {
            var ls = db.Sanphams.ToList();
            var lsPhone = from dienthoais in ls
                          where dienthoais.MaLoai == "SS"
                          select dienthoais;
            return lsPhone.ToList();
        }
        public List<Sanpham> dsVsmart()
        {
            var ls = db.Sanphams.ToList();
            var lsPhone = from dienthoais in ls
                          where dienthoais.MaLoai == "VS"
                          select dienthoais;
            return lsPhone.ToList();
        }
        public List<Sanpham> dsXiaomi()
        {
            var ls = db.Sanphams.ToList();
            var lsPhone = from dienthoais in ls
                          where dienthoais.MaLoai == "XM"
                          select dienthoais;
            return lsPhone.ToList();
        }
        public List<Sanpham> dsHuawei()
        {
            var ls = db.Sanphams.ToList();
            var lsPhone = from dienthoais in ls
                          where dienthoais.MaLoai == "HW"
                          select dienthoais;
            return lsPhone.ToList();
        }
        #endregion
        // View Tablet
        public List<Sanpham> tablet()
        {
            var ls = db.Sanphams.ToList();
            var lsTab = from tablet in ls
                          where tablet.MaLoai == "TAB"
                          select tablet;
            return lsTab.ToList();
        }

        // View Laptop
        public List<Sanpham> laptop()
        {
            var ls = db.Sanphams.ToList();
            var lsTab = from tablet in ls
                        where tablet.MaLoai == "LAPTOP"
                        select tablet;
            return lsTab.ToList();
        }
        public List<Sanpham> macbook()
        {
            var ls = db.Sanphams.ToList();
            var lsTab = from tablet in ls
                        where tablet.MaLoai == "MB"
                        select tablet;
            return lsTab.ToList();
        }
    }
}
