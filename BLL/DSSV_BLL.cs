using DAL;
using DAL.Model;
using System.Collections;

namespace BLL
{
    public class DSSV_BLL
    {
        private readonly DSSV_DAL dal = new DSSV_DAL();

        public IEnumerable GetListStaff()
        {
            return dal.GetListStaff();
        }

        public void Insert(DSSV sv)
        {
            dal.Insert(sv);
        }

        public void Update(DSSV sv)
        {
            dal.Update(sv);
        }

        public void Delete(string masv)
        {
            dal.Delete(masv);
        }

        public bool Exists(string masv)
        {
            return dal.Exists(masv);
        }

        public bool ExistsClass(string malo)
        {
            return dal.ExistsClass(malo);
        }
    }
}
