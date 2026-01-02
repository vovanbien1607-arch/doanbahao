using DAL;
using DAL.Model;

namespace BLL
{
    public class User_BLL
    {
        private readonly User_DAL dal = new User_DAL();

        public USERS Login(string u, string p) => dal.Login(u, p);
        public bool Exists(string u) => dal.Exists(u);
        public void Register(USERS user) => dal.Register(user);
        public bool ChangePassword(string u, string oldP, string newP) => dal.ChangePassword(u, oldP, newP);
    }
}
