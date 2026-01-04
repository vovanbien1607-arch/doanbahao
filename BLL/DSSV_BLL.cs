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

            // Nếu có chọn học kỳ → tạo bản ghi THUHP đầu tiên
            if (!string.IsNullOrWhiteSpace(maHP))
            {
                using (var db = new QLTHPcontext())
                {
                    var thuHP = new THUHP
                    {
                        MASV = sv.MASV,
                        MAHP = maHP,
                        NGAYTHU = DateTime.Today,
                        SOTIEN = 0, // Có thể lấy từ bảng HOCPHI nếu cần
                       
                    };
                    db.THUHP.Add(thuHP);
                    db.SaveChanges();
                }
            }
        }

        public void Update(DSSV sv, string maHP = null)
        {
            dal.Update(sv);

            // Nếu người dùng chọn học kỳ mới → thêm bản ghi THUHP nếu chưa có cho kỳ đó
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