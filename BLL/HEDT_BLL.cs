using System.Collections.Generic;
using DAL;
using DAL.Model;

namespace BLL
{
    public class HEDT_BLL
    {
        HEDT_DAL dal = new HEDT_DAL();

        public List<HEDT> GetAll()
        {
            return dal.GetAll();
        }

        public void Insert(HEDT he)
        {
            dal.Insert(he);
        }

        public void Update(HEDT he)
        {
            dal.Update(he);
        }

        public void Delete(string mahe)
        {
            dal.Delete(mahe);
        }
    }
}
