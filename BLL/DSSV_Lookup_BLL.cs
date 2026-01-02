using System.Collections.Generic;
using System.Linq;
using DAL.Model;

namespace BLL
{
    public class DSSV_Lookup_BLL
    {
        QLTHPcontext db = new QLTHPcontext();

        public List<object> GetLookup()
        {
            return db.DSSV.Select(s => new
            {
                s.MASV,
                s.HOTEN
            }).ToList<object>();
        }
    }
}
