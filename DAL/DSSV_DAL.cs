using DAL.Model;
using System.Collections;
using System.Linq;

namespace DAL
{
    public class DSSV_DAL
    {
        QLTHPcontext db = new QLTHPcontext();

        public IEnumerable GetListStaff()
        {
            var list =
                (from sv in db.DSSV
                 join lop in db.DSLOP on sv.MALO equals lop.MALO
               
                 select new
                 {
                     sv.MASV,
                     sv.HOTEN,
                     sv.NGAYSINH,
                     sv.MALO,
     
                     sv.DIENUIT
                 }).ToList();

            return list;
        }

        public bool Exists(string masv)
        {
            return db.DSSV.Any(x => x.MASV == masv);
        }

        public bool ExistsClass(string malo)
        {
            return db.DSLOP.Any(x => x.MALO == malo);
        }

        public void Insert(DSSV sv)
        {
            db.DSSV.Add(sv);
            db.SaveChanges();
        }

        public void Update(DSSV sv)
        {
            var existing = db.DSSV.FirstOrDefault(x => x.MASV == sv.MASV);
            if (existing == null) return;

            existing.HOTEN = sv.HOTEN;
            existing.NGAYSINH = sv.NGAYSINH;
            existing.MALO = sv.MALO;
            existing.DIENUIT = sv.DIENUIT;

            db.SaveChanges();
        }

        public void Delete(string masv)
        {
            var existing = db.DSSV.FirstOrDefault(x => x.MASV == masv);
            if (existing == null) return;

            // Nếu SV có THUHP thì SQL sẽ chặn do FK => cần xóa THUHP trước hoặc bật cascade
            // ở đây xử lý xóa THUHP trước:
            var thu = db.THUHP.Where(t => t.MASV == masv).ToList();
            if (thu.Count > 0)
            {
                db.THUHP.RemoveRange(thu);
            }

            db.DSSV.Remove(existing);
            db.SaveChanges();
        }
    }
}
