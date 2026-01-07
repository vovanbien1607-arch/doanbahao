using DAL;
using DAL.Model;
using System;
using System.Linq;

namespace BLL
{
    public class DSSV_BLL
    {
        private readonly DSSV_DAL dal = new DSSV_DAL();

        public System.Collections.IEnumerable GetListStaff()
        {
            return dal.GetListStaff();
        }

        public void Insert(DSSV sv, string maHP = null)
        {
            dal.Insert(sv);

            if (!string.IsNullOrWhiteSpace(maHP))
            {
                using (var db = new QLTHPcontext())
                {
                    var thuHP = new THUHP
                    {
                        MASV = sv.MASV,
                        MAHP = maHP,
                        NGAYTHU = DateTime.Today,
                        SOTIEN = 0, 
                       
                    };
                    db.THUHP.Add(thuHP);
                    db.SaveChanges();
                }
            }
        }

        public void Update(DSSV sv, string maHP = null)
        {
            dal.Update(sv);

           
            if (!string.IsNullOrWhiteSpace(maHP))
            {
                using (var db = new QLTHPcontext())
                {
                    bool exists = db.THUHP.Any(t => t.MASV == sv.MASV && t.MAHP == maHP);
                    if (!exists)
                    {
                        var thuHP = new THUHP
                        {
                            MASV = sv.MASV,
                            MAHP = maHP,
                            NGAYTHU = DateTime.Today,
                            SOTIEN = 0,
                            
                        };
                        db.THUHP.Add(thuHP);
                        db.SaveChanges();
                    }
                }
            }
        }

        public void Delete(string masv)
        {
            dal.Delete(masv);
        }
    }
}