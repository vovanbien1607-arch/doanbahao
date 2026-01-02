using System.Collections;
using DAL;
using DAL.Model;

namespace BLL
{
    public class THUHP_BLL
    {
        THUHP_DAL dal = new THUHP_DAL();

        public IEnumerable GetListThuHP()
        {
            return dal.GetListThuHP();
        }

        public void Insert(THUHP item)
        {
            dal.Insert(item);
        }

        public void Update(THUHP item)
        {
            dal.Update(item);
        }

        public void Delete(string masv, string mahp)
        {
            dal.Delete(masv, mahp);
        }
    }
}
