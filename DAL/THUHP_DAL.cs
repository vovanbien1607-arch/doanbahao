using System;
using System.Collections;
using System.Linq;
using DAL.Model;

namespace DAL
{
    public class THUHP_DAL
    {
        QLTHPcontext db = new QLTHPcontext();

        // Grid: THUHP + HOTEN + KYHP
        public IEnumerable GetListThuHP()
        {
            var list =
                (from t in db.THUHP
                 join sv in db.DSSV on t.MASV equals sv.MASV
                 join hp in db.HOCPHI on t.MAHP equals hp.MAHP
                 select new
                 {
                     t.MASV,
                     sv.HOTEN,
                     t.MAHP,
                     hp.KYHP,
                     t.NGAYQD,
                     t.NGAYTHU,
                     t.SOTIEN
                 }).ToList();

            return list;
        }

        public void Insert(THUHP item)
        {

            var exist = db.THUHP.FirstOrDefault(x => x.MASV == item.MASV && x.MAHP == item.MAHP);
            if (exist != null) throw new Exception("Đã tồn tại thu học phí với MASV + MAHP này!");

            db.THUHP.Add(item);
            db.SaveChanges();
        }

        public void Update(THUHP item)
        {
            
            var exist = db.THUHP.FirstOrDefault(x => x.MASV == item.MASV && x.MAHP == item.MAHP);
            if (exist == null) throw new Exception("Không tìm thấy dữ liệu để cập nhật!");

            exist.NGAYQD = item.NGAYQD;
            exist.NGAYTHU = item.NGAYTHU;
            exist.SOTIEN = item.SOTIEN;

            db.SaveChanges();
        }

        public void Delete(string masv, string mahp)
        {
            var exist = db.THUHP.FirstOrDefault(x => x.MASV == masv && x.MAHP == mahp);
            if (exist == null) throw new Exception("Không tìm thấy dữ liệu để xóa!");

            db.THUHP.Remove(exist);
            db.SaveChanges();
        }
    }
}
