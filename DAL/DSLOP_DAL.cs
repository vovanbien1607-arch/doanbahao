using System;
using System.Collections;
using System.Linq;
using DAL.Model;

namespace DAL
{
    public class DSLOP_DAL
    {
        // Kết nối bằng DbContext (EF)
        QLTHPcontext db = new QLTHPcontext();

        // Lấy danh sách lớp + kèm tên hệ (TENHE) để hiển thị trên Grid
        public IEnumerable GetListDSLOP()
        {
            var list =
                (from lop in db.DSLOP
                 join he in db.HEDT on lop.MAHE equals he.MAHE
                 select new
                 {
                     lop.MALO,
                     lop.TENLOP,
                     lop.MAHE,
                     he.TENHE
                 }).ToList();

            return list;
        }

        // Thêm lớp
        public void Insert(DSLOP lop)
        {
            // kiểm tra trùng mã lớp
            var exist = db.DSLOP.FirstOrDefault(x => x.MALO == lop.MALO);
            if (exist != null)
                throw new Exception("Mã lớp đã tồn tại!");

            // kiểm tra MAHE có tồn tại (tránh lỗi FK)
            var he = db.HEDT.FirstOrDefault(h => h.MAHE == lop.MAHE);
            if (he == null)
                throw new Exception("Mã hệ không tồn tại! Vui lòng chọn mã hệ đúng (CD/DH/TC).");

            db.DSLOP.Add(lop);
            db.SaveChanges();
        }

        // Cập nhật lớp
        public void Update(DSLOP lop)
        {
            var exist = db.DSLOP.FirstOrDefault(x => x.MALO == lop.MALO);
            if (exist == null)
                throw new Exception("Không tìm thấy lớp cần cập nhật!");

            // kiểm tra MAHE có tồn tại
            var he = db.HEDT.FirstOrDefault(h => h.MAHE == lop.MAHE);
            if (he == null)
                throw new Exception("Mã hệ không tồn tại! Vui lòng chọn mã hệ đúng (CD/DH/TC).");

            exist.TENLOP = lop.TENLOP;
            exist.MAHE = lop.MAHE;

            db.SaveChanges();
        }

        // Xóa lớp
        public void Delete(string malo)
        {
            var exist = db.DSLOP.FirstOrDefault(x => x.MALO == malo);
            if (exist == null)
                throw new Exception("Không tìm thấy lớp cần xóa!");

            // Nếu lớp đang có sinh viên => không cho xóa (tránh lỗi FK)
            bool hasSV = db.DSSV.Any(sv => sv.MALO == malo);
            if (hasSV)
                throw new Exception("Lớp đang có sinh viên, không thể xóa!");

            db.DSLOP.Remove(exist);
            db.SaveChanges();
        }
    }
}
