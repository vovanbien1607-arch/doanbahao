using System.Collections.Generic;
using System.Linq;
using DAL.Model;

namespace BLL
{
    public class HOCPHI_Lookup_BLL
    {
        QLTHPcontext db = new QLTHPcontext();

        public List<object> GetLookup()
        {
            return db.HOCPHI.Select(h => new
            {
                h.MAHP,
                h.KYHP
            }).ToList<object>();
        }
    }
}
