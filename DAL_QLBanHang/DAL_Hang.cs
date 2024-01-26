﻿using System;
using DTO_QLBanHang;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_QLBanHang
{
    public class DAL_Hang : DAL_IHang
    {
        public int Delete(Hang hang)
        {
            using (QLBanHangEntities1 db = new QLBanHangEntities1())
            {
                db.Hangs.Attach(hang);
                db.Hangs.Remove(hang);
                return db.SaveChanges();
            }
        }

        public Hang Get(int maHang)
        {
            using (QLBanHangEntities1 db = new QLBanHangEntities1())
            {
                return db.Hangs.Find(maHang);
            }
        }

        public List<Hang> GetAll()
        {
            using (QLBanHangEntities1 db = new QLBanHangEntities1())
            {
                return db.Hangs.ToList();
            }
        }
        public Hang Insert(Hang hang)
        {
            using (QLBanHangEntities1 db = new QLBanHangEntities1())
            {
                db.Hangs.Add(hang);
                db.SaveChanges();
                return hang;
            }
        }

        public int Update(Hang hang)
        {
            using (QLBanHangEntities1 db = new QLBanHangEntities1())
            {
                db.Hangs.Attach(hang);
                db.Entry(hang).State = System.Data.Entity.EntityState.Modified;
                return db.SaveChanges();
            }
        }

        public List<Hang> Search(string key)
        {
            if (string.IsNullOrEmpty(key))
            {
                return GetAll();
            }

            using (QLBanHangEntities1 db = new QLBanHangEntities1())
            {
                return db.Hangs.Where(h => h.TenHang.Contains(key)).ToList();
            }
        }
    }
}
