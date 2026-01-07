using System.Collections;
using DAL;
using DAL.Model;

namespace BLL
{
    
    public class DSLOP_BLL
    {
        DSLOP_DAL dal = new DSLOP_DAL();

        public IEnumerable GetListDSLOP()
        {
            return dal.GetListDSLOP();
        }

        public void Insert(DSLOP lop)
        {
            dal.Insert(lop);
        }

        public void Update(DSLOP lop)
        {
            dal.Update(lop);
        }

        public void Delete(string malo)
        {
            dal.Delete(malo);
        }
    }
}
