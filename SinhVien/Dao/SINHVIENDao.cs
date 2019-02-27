using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SinhVien.Entities;
namespace SinhVien.Dao
{
     public class SINHVIENDao
     {
          SinhVienDbContext db = null;
          public SINHVIENDao()
          {
               db = new SinhVienDbContext();
          }
          public bool CheckID(int ma)
          {
               var check = db.SINHVIENs.Find(ma);
               if (check == null)
                    return true;
               return false;
          }
          public bool AddSINHVIEN(SINHVIEN sv)
          {
               if (CheckID(sv.MA))
               {
                    db.SINHVIENs.Add(sv);
                    db.SaveChanges();
                    return true;
               }
               return false;
          }
          public bool UpdateSINHVIEN(SINHVIEN sv)
          {
               if (!CheckID(sv.MA))
               {
                    var temp = db.SINHVIENs.Find(sv.MA);
                    temp.HOTEN = sv.HOTEN;
                    temp.LOP = sv.LOP;
                    temp.QUEQUAN = sv.QUEQUAN;
                    temp.NGAYSINH = sv.NGAYSINH;
                    db.SaveChanges();
                    return true;
               }
               return false;
          }
          public bool DeleteSINHVIEN(int ma)
          {
               if (!CheckID(ma))
               {
                    SINHVIEN sv = db.SINHVIENs.Find(ma);
                    db.SINHVIENs.Remove(sv);
                    db.SaveChanges();
                    return true;
               }
               return false;
          }
     }
}