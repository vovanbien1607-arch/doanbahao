using System;
using System.Collections.Generic;
using System.Linq;
using DAL.Model;

namespace DAL
{
    public class HEDT_DAL
    {
        QLTHPcontext db = new QLTHPcontext();


        public List<HEDT> GetAll()
        {
            return db.HEDT.OrderBy(x => x.MAHE).ToList();
        }

        public void Insert(HEDT he)
        {
           
            var exists = db.HEDT.FirstOrDefault(x => x.MAHE == he.MAHE);
            if (exists != null)
                throw new Exception("Mã hệ đã tồn tại!");

            db.HEDT.Add(he);
            db.SaveChanges();
        }

        public void Update(HEDT he)
        {
            var exists = db.HEDT.FirstOrDefault(x => x.MAHE == he.MAHE);
            if (exists == null)
                throw new Exception("Không tìm thấy mã hệ để cập nhật!");

            exists.TENHE = he.TENHE;
            exists.HPCB = he.HPCB;

            db.SaveChanges();
        }


        public void Delete(string mahe)
        {
            var exists = db.HEDT.FirstOrDefault(x => x.MAHE == mahe);
            if (exists == null)
                throw new Exception("Không tìm thấy mã hệ để xóa!");

            bool used = db.DSLOP.Any(l => l.MAHE == mahe);
            if (used)
                throw new Exception("Không thể xóa vì MAHE đang được sử dụng trong bảng DSLOP!");

            db.HEDT.Remove(exists);
            db.SaveChanges();
        }
    }
}
