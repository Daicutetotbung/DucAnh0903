﻿using DTO_QLBanHang;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_QLBanHang
{
    public class DAL_NhanVien : DAL_INhanVien
    {
        
        public int CreatePassword(string email, string newPass)
        {
            using (QLBanHangEntities1 db = new QLBanHangEntities1())
            {
                NhanVien nv = db.NhanViens.FirstOrDefault(n => n.Email == email);
                if (nv == null) return 0;
                
                nv.MatKhau = newPass;
                return db.SaveChanges();
            }
            
        }

        public NhanVien DangNhap(string email, string matkhau)
        {
            if (email == "" || matkhau == "") return null;
            using (QLBanHangEntities1 db = new QLBanHangEntities1())
            {
                return db.NhanViens.FirstOrDefault(n => n.Email == email );
            }
        }

        public int Delete(NhanVien nhanVien)
        {
            using (QLBanHangEntities1 db = new QLBanHangEntities1())
            {
                db.NhanViens.Attach(nhanVien);
                if (nhanVien.Hangs.Any() || nhanVien.Khaches.Any())
                    return 0;
                db.NhanViens.Remove(nhanVien);
                return db.SaveChanges();

            }
        }

        public NhanVien Get(string maNV)
        {
            using (QLBanHangEntities1 db = new QLBanHangEntities1())
            {
                return db.NhanViens.Find(maNV);
            }
        }

        
        public List<NhanVien> GetAll()
        {
            // throw new NotImplementedException();
            using (QLBanHangEntities1 db = new QLBanHangEntities1())
            {
                return db.NhanViens.ToList();
            }
        }

        public List<NhanVien> GetAllByEmail(string key)
        {
            throw new NotImplementedException();
        }

        public NhanVien GetByEmail(string email)
        {
            using (QLBanHangEntities1 db = new QLBanHangEntities1())
            {
                return db.NhanViens.FirstOrDefault(n => n.Email == email);
            }
        }

        public int Insert(string email, string tenNV, string diachi, string vaiTro, string tinhtrang, string matkhau)
        {
            throw new NotImplementedException();
            
        }

        public int Insert(NhanVien nhanVien)
        {
            using (QLBanHangEntities1 db = new QLBanHangEntities1())
            {
                try
                {
                    int a = db.sp_InsertNhanVien(nhanVien.Email, nhanVien.TenNV, nhanVien.DiaChi, nhanVien.VaiTro, nhanVien.TinhTrang, nhanVien.MatKhau);
                    return a;
                }
                catch (Exception)
                {
                    return 0;
                }
            }
        }

        public int Update(NhanVien nhanVien)
        {
            using (QLBanHangEntities1 db = new QLBanHangEntities1())
            {
                db.NhanViens.Attach(nhanVien);
                db.Entry(nhanVien).State = System.Data.Entity.EntityState.Modified;
                return db.SaveChanges();
            }
        }

        public int UpdatePassword(string email, string oldPass, string newPass)
        {
            using (QLBanHangEntities1 db = new QLBanHangEntities1())
            {
                NhanVien nv = db.NhanViens.FirstOrDefault(n => n.Email == email);
                if (nv == null) return 0;
                if (nv.MatKhau != oldPass) return 0;
                nv.MatKhau = newPass;
                return db.SaveChanges();
            }
        }
    }
}
