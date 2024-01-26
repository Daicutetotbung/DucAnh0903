using System;
using DTO_QLBanHang;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_QLBanHang
{
    public class DAL_KhachHang:DAL_IKhachHang
    {
        public int Delete(Khach khach)
        {
            using (QLBanHangEntities1 db = new QLBanHangEntities1())
            {
                db.Khaches.Attach(khach);
                db.Khaches.Remove(khach);
                return db.SaveChanges();
            }
        }

        public Khach Get(string dienthoai)
        {
            using (QLBanHangEntities1 db = new QLBanHangEntities1())
            {
                return db.Khaches.Find(dienthoai);
            }
        }

        public List<Khach> GetAll()
        {
            using (QLBanHangEntities1 db = new QLBanHangEntities1())
            {
                return db.Khaches.ToList();
            }
        }
        public int Insert(Khach khach)
        {
            using (QLBanHangEntities1 db = new QLBanHangEntities1())
            {
                db.Khaches.Add(khach);
                return db.SaveChanges();
            }
        }

        public int Update(Khach khach)
        {
            using (QLBanHangEntities1 db = new QLBanHangEntities1())
            {
                db.Khaches.Attach(khach);
                db.Entry(khach).State = System.Data.Entity.EntityState.Modified;
                return db.SaveChanges();
            }
        }

        public List<Khach> Search(string key)
        {
            if (string.IsNullOrEmpty(key))
            {
                return GetAll();
            }

            using (QLBanHangEntities1 db = new QLBanHangEntities1())
            {
                return db.Khaches.Where(k => k.TenKhach.Contains(key)).ToList();
            }
        }
    }
}
